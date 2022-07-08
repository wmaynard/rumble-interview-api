using Microsoft.AspNetCore.Mvc;
using Rumble.Platform.Common.Attributes;
using Rumble.Platform.Common.Exceptions;
using Rumble.Platform.Common.Utilities;
using Rumble.Platform.Common.Web;
using Rumble.Platform.Interview.Models;
using Rumble.Platform.Interview.Services;

namespace Rumble.Platform.Interview.Controllers;

[Route("interview/web-dev"), RequireAuth]
public class WebDevController : PlatformController
{
	// /interview/register, POST login, POST logout, mail
#pragma warning disable
	private readonly TokenService _tokenService;
#pragma warning restore

	[HttpPost, Route("login"), NoAuth]
	public ActionResult Login()
	{
		string screenname = Require<string>("screenname");
		string password = Require<string>("password");

		Token token = _tokenService.Find(screenname, password);

		_apiService
			.Request(PlatformEnvironment.Url("token/validate"))
			.AddAuthorization(token.JWT)
			.Get(out GenericData _, out int code);

		return Ok(new GenericData
		{
			{ "token", token.JWT }
		});
	}

	[HttpDelete, Route("account")]
	public ActionResult DeleteAccount()
	{
		return Ok(new GenericData
		{
			{ "deleted", _tokenService.Delete(Token.ScreenName) }
		});
	}

	[HttpPost, Route("register"), NoAuth]
	public ActionResult Register()
	{
		string screenname = Require<string>("screenname");
		string email = Require<string>("email");
		string password = Require<string>("password");

		GenericData failure = null;

		if (_tokenService.Exists(screenname, password))
			throw new PlatformException("That account already exists.", code: ErrorCode.MalformedRequest);
		if (_tokenService.UsernameTaken(screenname))
			throw new PlatformException("That username is taken.", code: ErrorCode.MalformedRequest);
		
		_apiService
			.Request(PlatformEnvironment.Url(endpoint: "/secured/token/generate"))
			.SetPayload(new GenericData
			{
				{ "aid", $"interview-{Guid.NewGuid()}"},
				{ "screenname", screenname },
				{ "discriminator", new Random().Next(1, 9999) },
				{ "origin", PlatformEnvironment.ServiceName },
				{ "email", email },
				{ "days", 5 }
			})
			.OnFailure((_, reply) =>
			{
				failure = reply;
			})
			.Post(out GenericData response, out int code);

		if (failure != null)
			return Problem(failure);

		Token token = new Token
		{
			JWT = response.Require<GenericData>("authorization").Require<string>("token"),
			Screenname = screenname,
			Password = password
		};
		
		_tokenService.Save(token);
		
		return failure == null
			? Ok()
			: Problem(failure);
	}

	[HttpGet, Route("mail")]
	public ActionResult Messages()
	{
		Mail[] messages =
		{
			new Mail(0, 2)
			{
				Title = "Welcome!",
				// Icon = PlatformEnvironment.Url("/interview/images/_iconToken.png")
				Icon = PlatformEnvironment.Url("https://eng.towersandtitans.com/img/rumble-logo.png")
			}, new Mail(loremIpsumStart: 8, 2)
			{
				Title = $"Expected server downtime at {DateTime.Now.AddDays(3)}",
				// Icon = PlatformEnvironment.Url("/interview/images/_iconPlatform.png")
				Icon = PlatformEnvironment.Url("https://eng.towersandtitans.com/img/rumble-logo.png")
			}
		};
		return Ok(new
		{
			Messages = messages
		});
	}
}