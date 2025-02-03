using System.Net;

using antifog_service.Messages.Controllers.Primary;
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

	public async Task<GrizhlaResult<FoggyTag>> CreateAsync(FoggyTag tag)
	{
		try
		{
			await antifogDBContext.__FoggyTag.AddAsync(tag);
			await antifogDBContext.SaveChangesAsync();
			return GrizhlaResult<FoggyTag>.Processed(tag, message: TagControllerMessages.TAG_CREATED_SUCCESS);
		}
		catch(DbUpdateException dupex)
		{
			var ex = dupex.InnerException;
			if(ex != null)
			{
				if(ex.Message.Contains("duplicate key value violates unique constraint"))
				{
					return GrizhlaResult<FoggyTag>.ProcessFailed(HttpStatusCode.Conflict, message: TagControllerMessages.TAG_CREATED_FAILURE_CONFLICT, description: $"{dupex.Message}\n{dupex.InnerException?.Message ?? ""}");
				}
				else
				{
					throw new NotImplementedException("DbUpdateException has InnerException");
				}
			}
			else
			{
				throw new NotImplementedException("DbUpdateException does not have InnerException");				
			}
		}
		catch(Exception ex)
		{
			return GrizhlaResult<FoggyTag>.ProcessFailed(HttpStatusCode.InternalServerError, message: TagControllerMessages.TAG_CREATED_FAILURE, description: $"{ex.Message}\n{ex.InnerException?.Message ?? ""}");
		}
	}

	public async Task<GrizhlaResult<List<FoggyTag>>> ListAsync()
	{
		try
		{
			var list = await antifogDBContext.__FoggyTag.ToListAsync();
			return GrizhlaResult<List<FoggyTag>>.Processed(list, message: TagControllerMessages.TAG_LIST_SUCCESS);
		}
		catch(Exception ex)
		{
			return GrizhlaResult<List<FoggyTag>>.ProcessFailed(HttpStatusCode.InternalServerError, message: TagControllerMessages.TAG_LIST_FAILURE, description: $"{ex.Message}\n{ex.InnerException?.Message ?? ""}");
		}
	}
}
