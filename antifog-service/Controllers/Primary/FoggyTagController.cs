using antifog_service.Messages.Controllers.Primary;
using antifog_service.Models.Primary;
using antifog_service.Services.Primary;

using Grizhla.UtilitiesCore.API;
using Grizhla.UtilitiesCore.API.Models;

using Microsoft.AspNetCore.Mvc;

namespace antifog_service.Controllers.Primary;

[Route("api/v1/[controller]/[action]")]
public class FoggyTagController : GrizhlaController
{
	private readonly FoggyTagService _foggyTagService;

	public FoggyTagController(FoggyTagService foggyTagService)
	{
		this._foggyTagService = foggyTagService;
	}

	[HttpGet]
	public async Task<GrizhlaResult<List<FoggyTag>>> ListAsync()
	{
		return await _foggyTagService.ListAsync();
	}

	[HttpPost]
	public async Task<GrizhlaResult<FoggyTag>> CreateAsync(FoggyTag foggyTag)
	{
		return await _foggyTagService.CreateAsync(foggyTag);
	}

	[HttpPut]
	public async Task<GrizhlaResult<FoggyTag>> UpdateAsync(FoggyTag foggyTag)
	{
		return await _foggyTagService.UpdateAsync(foggyTag);
	}

	[HttpDelete]
	public async Task<GrizhlaResult<FoggyTag>> DeleteAsync(Guid foggyTagId)
	{
		return await _foggyTagService.DeleteAsync(foggyTagId);
	}
}
