using Grizhla.UtilitiesCore.API;
using Grizhla.UtilitiesCore.API.Models;

using Microsoft.AspNetCore.Mvc;

namespace antifog_service.Controllers;

public class BasicsController:FoggyController
{
	public ActionResult Do()
	{
		return ByProcessResult<object>(ProcessResult<object>.Processed(null));
	}
}
