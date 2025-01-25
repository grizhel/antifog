using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Grizhla.UtilitiesCore.EF.Basic;
using Grizhla.UtilitiesCore.EF.StructuralUtilities;

namespace antifog_service.Models.Basics;

[Table(nameof(FoggyTag))]
public class FoggyTag : GrizhlaRecord
{
	[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int FoggyTagId { get; set; }

	public required string TagName { get; set; }

	public override string GetPrimaryKey()
	{
		return FoggyTagId.ToString();
	}
}
