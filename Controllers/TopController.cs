using Microsoft.AspNetCore.Mvc;
using Rumble.Platform.Common.Attributes;
using Rumble.Platform.Common.Web;

namespace Rumble.Platform.Interview.Controllers;

[Route("interview"), RequireAuth]
public class TopController : PlatformController { }