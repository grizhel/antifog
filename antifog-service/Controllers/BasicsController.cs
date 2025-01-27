using System.Net;

using antifog_service.Services;

using Grizhla.UtilitiesCore.API;
using Grizhla.UtilitiesCore.API.Models;

using Microsoft.AspNetCore.Mvc;

namespace antifog_service.Controllers;

public class BasicsController : FoggyController
{
	private readonly BasicService _basicsService;

	public BasicsController(BasicService basicsService)
	{
		this._basicsService = basicsService;
	}

	[HttpPost]
	public async Task<ActionResult> DoAsync(GrizhlaRequest grizhlaRequest)
	{
		return ByProcessResult(await _basicsService.DoAsync(grizhlaRequest));
	}
}
