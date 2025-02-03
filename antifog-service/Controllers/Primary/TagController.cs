using antifog_service.Messages.Controllers.Primary;
using antifog_service.Models.Primary;
using antifog_service.Services.Primary;

using Grizhla.UtilitiesCore.API;
using Grizhla.UtilitiesCore.API.Models;

using Microsoft.AspNetCore.Mvc;

namespace antifog_service.Controllers.Primary;

[Route("api/v1/[controller]/[action]")]
public class TagController : GrizhlaController
{
	private readonly TagService _tagService;

	public TagController(TagService tagService)
	{
		this._tagService = tagService;
	}

	[HttpGet]
	public async Task<GrizhlaResult<List<FoggyTag>>> ListAsync()
	{
		return await _tagService.ListAsync();
	}

	[HttpPost]
	public async Task<GrizhlaResult<FoggyTag>> CreateAsync(FoggyTag tag)
	{
		return await _tagService.CreateAsync(tag);
	}
}
