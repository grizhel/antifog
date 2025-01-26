using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Grizhla.UtilitiesCore.EF.Basic;
using Grizhla.UtilitiesCore.EF.StructuralUtilities;
using Grizhla.UtilitiesCore.EF.Attributes;

namespace antifog_service.Models.Basics;


[Table(nameof(FoggyTag))]
public class FoggyTag : GrizhlaRecord
{
	[Key]
	public Guid FoggyTagId { get; set; } = Guid.NewGuid();

	[StringNotText]
	public required string TagName { get; set; }

	[JsonB]
	public FoggyTagDataStructure? FoggyTagDataStructure { get; set; }

	public override Guid GetPrimaryKey()
	{
		return this.FoggyTagId;
	}
}

public class FoggyTagDataStructure
{
	public required FoggyTagDataStructureFields FoggyTagStructureFields { get; set; }
}

public class FoggyTagDataStructureFields
{
	public required List<FoggyTagDataStructureField> Fields { get; set; } = [];
}

public class FoggyTagDataStructureField
{
	public required string FieldName { get; set; }

	public int Order { get; set; }
}


