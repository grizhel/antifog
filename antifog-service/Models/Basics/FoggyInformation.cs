using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Grizhla.UtilitiesCore.EF.StructuralUtilities;

namespace antifog_service.Models.Basics;

[Table(nameof(FoggyInformation))]
public class FoggyInformation : GrizhlaRecord
{
	[Key]
	public Guid FoggyInformationId { get; set; } = Guid.NewGuid();

	public override Guid GetPrimaryKey()
	{
		return this.FoggyInformationId;
	}
}
