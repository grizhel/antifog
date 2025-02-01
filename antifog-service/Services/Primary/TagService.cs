using antifog_service.Models;
using antifog_service.Models.Primary;

using Grizhla.UtilitiesCore.API.Models;

using Microsoft.EntityFrameworkCore;

namespace antifog_service.Services.Primary;

public class TagService
{
	private readonly AntifogDBContext antifogDBContext;

	public TagService(AntifogDBContext antifogDBContext)
	{
		this.antifogDBContext = antifogDBContext;
	}

	public async Task<FoggyTag> AddAsync(FoggyTag tag)
	{
		await antifogDBContext.__FoggyTag.AddAsync(tag);
		await antifogDBContext.SaveChangesAsync();
		return tag;
	}

	public async Task<List<FoggyTag>> ListAsync()
	{
		return await antifogDBContext.__FoggyTag.ToListAsync();
	}
}
