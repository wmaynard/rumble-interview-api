using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using Rumble.Platform.Common.Models;

namespace Rumble.Platform.Interview.Models;

public class Token : PlatformCollectionDocument
{
	[BsonElement("token"), BsonIgnoreIfNull]
	[JsonInclude, JsonPropertyName("bearerToken")]
	public string JWT { get; init; }
	
	[BsonElement("sn"), BsonIgnoreIfNull]
	[JsonIgnore]
	public string Screenname { get; init; }
	
	[BsonElement("pw"), BsonIgnoreIfNull]
	[JsonIgnore]
	public string Password { get; init; }
}