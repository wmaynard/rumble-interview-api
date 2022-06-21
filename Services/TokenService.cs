using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Rumble.Platform.Common.Exceptions;
using Rumble.Platform.Common.Models;
using Rumble.Platform.Common.Services;
using Rumble.Platform.Common.Utilities;
using Rumble.Platform.Interview.Models;

namespace Rumble.Platform.Interview.Services;

public class TokenService : PlatformMongoService<Token>
{
	public TokenService() : base("tokens") { }

	public Token Find(string screenname, string password) =>
		_collection
			.Find(filter: token => token.Screenname == screenname && token.Password == password)
			.FirstOrDefault() 
			?? throw new PlatformException("Account not found.", code: ErrorCode.NotSpecified);

	public new int Delete(string screenname) => (int)_collection.DeleteMany(filter: token => token.Screenname == screenname).DeletedCount;
	
	public bool Exists(string screenname, string password) =>
		0 < _collection
			.CountDocuments(filter: token => token.Screenname == screenname && token.Password == password);

	public bool UsernameTaken(string screenname) =>
		0 < _collection
			.CountDocuments(filter: token => token.Screenname == screenname);
	public void Save(Token token)
	{
		try
		{
			Find(token.Screenname, token.Password);
		}
		catch (PlatformException)
		{
			_collection.InsertOne(token);
		}
	}
}

