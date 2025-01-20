using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace antifog_service.Models.Basics;

public class FoggyInformation
{
	[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int FoggyInformationId { get; set; }
}
