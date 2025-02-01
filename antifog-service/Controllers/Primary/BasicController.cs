using System.Net;

using antifog_service.Services.Primary;

using Grizhla.UtilitiesCore.API;
using Grizhla.UtilitiesCore.API.Models;

using Microsoft.AspNetCore.Mvc;

namespace antifog_service.Controllers.Primary;

[Route("api/v1/[controller]")]
public class BasicController : FoggyController
{
	private readonly BasicService _basicsService;

	public BasicController(BasicService basicsService)
	{
		this._basicsService = basicsService;
	}

	[HttpPost]
	public async Task<ActionResult> DoAsync(GrizhlaRequest grizhlaRequest)
	{
		return ByProcessResult(await _basicsService.DoAsync(grizhlaRequest));
	}
}
