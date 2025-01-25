using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Grizhla.UtilitiesCore.EF.StructuralUtilities;

namespace antifog_service.Models.Basics;

[Table(nameof(FoggyInformation))]
public class FoggyInformation : GrizhlaRecord
{
	[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int FoggyInformationId { get; set; }

	public override string GetPrimaryKey()
	{
		return this.FoggyInformationId.ToString();
	}
}
