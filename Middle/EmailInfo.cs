using System.Text.Json.Serialization;

namespace Middle;

public class EmailInfo
{
	[JsonInclude]
	[JsonPropertyName("email")]
	public string Email { get; set; } = default!;
	[JsonInclude]
	[JsonPropertyName("password")]
	public string Password { get; set; } = default!;
	[JsonInclude]
	[JsonPropertyName("dn")]
	public string DisplayName { get; set; } = default!;
}
