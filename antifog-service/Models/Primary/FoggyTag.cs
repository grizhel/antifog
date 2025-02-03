using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Grizhla.UtilitiesCore.EF.Basic;
using Grizhla.UtilitiesCore.EF.StructuralUtilities;
using Grizhla.UtilitiesCore.EF.Attributes;
using Microsoft.EntityFrameworkCore;

namespace antifog_service.Models.Primary;


[Table(nameof(FoggyTag))]
[Index(nameof(TagName), IsUnique = true)]
public class FoggyTag : GrizhlaRecord
{
	[Key]
	public Guid FoggyTagId { get; set; } = Guid.NewGuid();

	[StringNotText]
	public required string TagName { get; set; }

	public string? Explanation { get; set; }

	[JsonB]
	public FoggyTagDataStructure? FoggyTagDataStructure { get; set; }

	public override Guid GetPrimaryKey()
	{
		return this.FoggyTagId;
	}
}

public class FoggyTagDataStructure 
{
	public required List<FoggyTagDataStructureField> Fields { get; set; } = [];
}

public class FoggyTagDataStructureField
{
	public required string FieldName { get; set; }

	public int Order { get; set; }
}


