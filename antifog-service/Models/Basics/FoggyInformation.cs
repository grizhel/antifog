using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Grizhla.UtilitiesCore.EF.Attributes;
using Grizhla.UtilitiesCore.EF.StructuralUtilities;

using Microsoft.EntityFrameworkCore;

namespace antifog_service.Models.Basics;

[Table(nameof(FoggyInformation))]
public class FoggyInformation : GrizhlaRecord
{
	[Key]
	public Guid FoggyInformationId { get; set; } = Guid.NewGuid();

	public required string InformationText { get; set; }

	[JsonB]
	public required FoggyInformationTagInfo? TagInfo { get; set; }

	public override Guid GetPrimaryKey()
	{
		return this.FoggyInformationId;
	}
}

public class FoggyInformationTagInfo
{
	public required FoggyTag FoggyTag { get; set; }

	public List<FoggyTagStructuredKeyValuePair>? FoggyTagValuePair { get; set; } = [];
}

public class FoggyTagStructuredKeyValuePair
{
	public required string Key { get; set; }

	public required string Value { get; set; }
}