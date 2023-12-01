using CompanionAppShared.Scales;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CompanionAppShared;

[JsonDerivedType(typeof(NineHolePegTest), typeDiscriminator: "NineHolePegTest")]
public class ScaleBase : IScale
{
	public ScalesIDs Id { get; set; } = ScalesIDs.NotSet;
	public string Name { get; set; } = string.Empty;
	public string ShortName { get; set; } = string.Empty;

	public string Serialize()
	{
		var options = new JsonSerializerOptions
		{
			WriteIndented = true,
		};
		return JsonSerializer.Serialize(this, options);
	}
}
