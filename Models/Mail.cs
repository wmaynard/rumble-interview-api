using System.Text.Json.Serialization;
using Rumble.Platform.Common.Models;
using Rumble.Platform.Common.Utilities.JsonTools;

namespace Rumble.Platform.Interview.Models;

public class Mail : PlatformDataModel
{
	public static readonly string[] LoremIpsum =
	{
		"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam ultricies scelerisque leo, eget vehicula nisi ullamcorper at. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nullam molestie magna sit amet tellus malesuada mollis. Pellentesque eleifend viverra elit quis pharetra. Cras scelerisque, velit vel porta pharetra, justo quam rhoncus augue, eget aliquam nisi arcu ut purus. Curabitur rhoncus venenatis ornare. Fusce pulvinar ut diam nec imperdiet.",
		"Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Sed gravida tortor vel leo ornare, sed varius risus consectetur. Aenean ut ligula eget nunc viverra semper. Nullam facilisis neque est, et ultrices ante pretium eget. Donec quis dapibus elit, euismod consequat enim. Ut eleifend vulputate cursus. Ut ut lorem at erat facilisis varius. Nulla aliquam lorem a justo condimentum, at tempor elit pulvinar. Sed non risus eu erat pharetra tincidunt. Maecenas ante nunc, rutrum sed enim in, aliquet porttitor tellus. Sed sit amet nunc arcu. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;",
		"Integer vel dignissim massa, ut fermentum mi. Integer erat eros, gravida sit amet enim quis, condimentum ullamcorper massa. Donec semper lorem in lorem blandit condimentum. Proin rutrum purus id varius vulputate. Proin a rutrum diam. Cras ac risus lorem. Ut pulvinar elit nec iaculis aliquet. Vestibulum finibus id leo at porttitor. Aliquam facilisis laoreet justo vitae consectetur. Etiam felis est, ultricies interdum nisl ac, elementum rutrum eros. Aliquam pulvinar tempor mi, ut fringilla erat sodales non. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Phasellus feugiat enim leo, faucibus pulvinar tortor iaculis quis. Nam vestibulum tortor in eleifend ullamcorper. Aenean id urna eget mauris sodales ullamcorper eget placerat lorem.",
		"Praesent quis faucibus leo, et congue ligula. Vivamus interdum, erat vitae maximus elementum, augue risus sodales neque, ac sagittis ipsum orci id velit. Fusce lacus dolor, pharetra a convallis molestie, ullamcorper id sapien. Donec consequat enim orci, in tincidunt odio tempor et. Nam et eros enim. Nulla at rhoncus ante, quis eleifend purus. Aenean eget mauris in velit condimentum lacinia vel nec nisi. Praesent a diam magna. Donec tincidunt volutpat ante, id efficitur sem pharetra non. Aenean ex turpis, condimentum consectetur aliquam vitae, volutpat quis leo. Sed quis nibh lorem. Nullam ac rhoncus magna. Nullam ac gravida metus. Donec ut mattis ipsum, ac porta justo.",
		"Aliquam consequat sodales turpis, at convallis nunc egestas vitae. Pellentesque elementum sit amet nisi quis faucibus. Integer nec leo sit amet est sodales pretium sed non urna. Vivamus imperdiet sit amet ex quis interdum. Ut euismod, risus vitae suscipit condimentum, leo sem lacinia sem, vel vulputate erat orci non quam. Nam aliquam nisl lectus, vitae aliquet quam ultrices eget. Nam mi lorem, gravida quis ante sit amet, bibendum volutpat ipsum. Vivamus non magna ac nisi varius iaculis. Aliquam convallis odio eu posuere vehicula. In faucibus, risus et varius sodales, nunc mauris auctor ante, at finibus velit turpis at quam. Etiam at dui nec libero pellentesque rhoncus. Proin felis nisl, viverra id tempor ac, vehicula quis tellus. Vestibulum egestas, mi quis venenatis ultrices, justo velit porttitor metus, tincidunt congue arcu nulla in magna. Curabitur vel libero eget enim vestibulum lacinia.",
		"Sed blandit orci eu laoreet volutpat. Morbi cursus lorem turpis. Duis pharetra lobortis massa. In viverra, dolor vel blandit dignissim, sem ante lacinia mi, eget aliquam nunc lectus eget ante. Aliquam scelerisque odio eu enim malesuada, in fringilla ante porta. Cras id tempus diam. Nulla dignissim id augue a faucibus. Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
		"Vivamus dui enim, consectetur sit amet imperdiet nec, varius vel mauris. Integer egestas pellentesque risus, dapibus consectetur nisi vestibulum ac. Nam porttitor ex in nunc ornare, et maximus velit tempus. Aliquam tristique consequat purus eget molestie. Quisque placerat rhoncus leo hendrerit facilisis. Duis facilisis urna tempor, dignissim purus eget, congue nisi. Quisque sit amet orci nec orci pharetra ornare. Etiam iaculis rutrum risus at dapibus. Nullam pulvinar, urna nec efficitur efficitur, elit dolor pretium nibh, vel luctus felis lacus sit amet turpis. Nunc a sem sed dolor sollicitudin suscipit vitae varius nulla. Maecenas consequat aliquam leo vitae posuere. Sed lacinia eu metus nec fringilla. Nulla ac lacinia diam. Vivamus maximus, lectus at viverra vulputate, mi nisl consectetur eros, quis pharetra turpis risus dapibus enim. Aliquam in ipsum volutpat, viverra leo nec, aliquam risus. Integer orci ipsum, posuere in consectetur vel, rutrum ac nulla.",
		"Morbi pulvinar, risus vel aliquam bibendum, lacus dui laoreet orci, ut iaculis nunc nisi id lorem. Duis consequat metus nec elit tincidunt, sit amet sodales nulla ultrices. In ac lectus nisl. Pellentesque fringilla massa pharetra libero viverra, sit amet dictum orci placerat. Duis suscipit sagittis aliquet. Donec magna augue, tincidunt vitae purus a, auctor venenatis dolor. Maecenas id erat at dui commodo cursus. Nullam eget imperdiet enim.",
		"Ut tempus posuere luctus. Nulla vestibulum felis ac felis facilisis, et aliquam odio aliquet. Nam id nisi gravida, euismod dui et, maximus tellus. Suspendisse tristique hendrerit ex, sed rhoncus velit. Praesent viverra risus a dictum aliquet. Morbi pharetra scelerisque porttitor. Fusce vehicula rutrum aliquet.",
		"Aliquam erat volutpat. Nam orci dui, porttitor nec turpis a, posuere accumsan quam. Morbi consectetur diam sed sagittis convallis. Morbi eget urna vitae metus venenatis ullamcorper nec et dui. Proin et tincidunt dui, ac tempor ex. Vivamus gravida dolor sed orci ultrices, id malesuada odio interdum. Donec dapibus ex id sapien pulvinar, vel hendrerit quam aliquam. Aliquam ornare accumsan iaculis. Nunc sagittis, lorem sit amet molestie ornare, leo ipsum pellentesque nunc, a aliquam ex augue eu odio. Nullam varius arcu nec ultrices malesuada. Pellentesque fringilla massa ut nisi suscipit gravida. Nulla porta pharetra neque, scelerisque convallis turpis. Morbi malesuada ipsum iaculis justo pharetra, ut tincidunt nisl tristique. Phasellus tempor ac sem vel molestie. Nulla ultricies lectus at ex condimentum, a eleifend odio suscipit."
	};
	
	[JsonInclude, JsonPropertyName("id")]
	public string ID { get; private set; }
	
	[JsonInclude, JsonPropertyName("title")]
	public string Title { get; init; }
	
	[JsonInclude, JsonPropertyName("message")]
	public string Message { get; init; }
	
	[JsonInclude, JsonPropertyName("icon")]
	public string Icon { get; init; }

	public Mail(int loremIpsumStart = 0, int loremIpsumCount = 1)
	{
		// Prevent index out of range errors
		while (loremIpsumStart > LoremIpsum.Length)
			loremIpsumStart = Math.Max(0, loremIpsumStart - LoremIpsum.Length);
		loremIpsumCount = Math.Min(loremIpsumStart + loremIpsumCount, LoremIpsum.Length - loremIpsumStart);
		
		ID = Guid.NewGuid().ToString();
		Message = string.Join("<br>", LoremIpsum.Skip(loremIpsumStart).Take(loremIpsumCount));
	}
}