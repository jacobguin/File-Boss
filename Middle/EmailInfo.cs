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

[JsonSerializable(typeof(EmailInfo))]
[JsonSourceGenerationOptions(
	GenerationMode = JsonSourceGenerationMode.Default,
	PropertyNamingPolicy = JsonKnownNamingPolicy.Unspecified,
	WriteIndented = true,
	DefaultIgnoreCondition = JsonIgnoreCondition.Never)]
public partial class EmailInfoContext : JsonSerializerContext;
