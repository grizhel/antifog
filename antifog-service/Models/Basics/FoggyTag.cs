using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Grizhla.UtilitiesCore.EF.Basic;
using Grizhla.UtilitiesCore.EF.StructuralUtilities;

namespace antifog_service.Models.Basics;

[Table(nameof(FoggyTag))]
public class FoggyTag : GrizhlaRecord
{
	[Key]
	public Guid FoggyTagId { get; set; } = Guid.NewGuid();

	[Column(TypeName = "varchar(63)")]
	public required string TagName { get; set; }

	public override Guid GetPrimaryKey()
	{
		return this.FoggyTagId;
	}
}
