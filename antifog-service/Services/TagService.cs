using antifog_service.Models;
using antifog_service.Models.Basics;

namespace antifog_service.Services;

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
}
