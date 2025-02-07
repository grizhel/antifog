using System.Net;

using antifog_service.Messages.Controllers.Primary;
using antifog_service.Models;
using antifog_service.Models.Primary;

using Grizhla.UtilitiesCore.API.Models;

using Microsoft.EntityFrameworkCore;

namespace antifog_service.Services.Primary;

public class FoggyTagService
{
	private readonly AntifogDBContext antifogDBContext;

	public FoggyTagService(AntifogDBContext antifogDBContext)
	{
		this.antifogDBContext = antifogDBContext;
	}

	public async Task<GrizhlaResult<List<FoggyTag>>> ListAsync()
	{
		try
		{
			var list = await antifogDBContext.__FoggyTag.ToListAsync();
			return GrizhlaResult<List<FoggyTag>>.Processed(list, message: FoggyTagControllerMessages.TAG_LIST_SUCCESS);
		}
		catch(Exception ex)
		{
			return GrizhlaResult<List<FoggyTag>>.ProcessFailed(HttpStatusCode.InternalServerError, message: FoggyTagControllerMessages.TAG_LIST_FAILURE, description: $"{ex.Message}\n{ex.InnerException?.Message ?? ""}");
		}
	}

	public async Task<GrizhlaResult<FoggyTag>> CreateAsync(FoggyTag foggyTag)
	{
		try
		{
			await antifogDBContext.__FoggyTag.AddAsync(foggyTag);
			await antifogDBContext.SaveChangesAsync();
			return GrizhlaResult<FoggyTag>.Processed(foggyTag, message: FoggyTagControllerMessages.TAG_CREATE_SUCCESS);
		}
		catch(DbUpdateException dupex)
		{
			var ex = dupex.InnerException;
			if(ex != null)
			{
				if(ex.Message.Contains("duplicate key value violates unique constraint"))
				{
					return GrizhlaResult<FoggyTag>.ProcessFailed(HttpStatusCode.Conflict, message: FoggyTagControllerMessages.TAG_CREATE_FAILURE_CONFLICT, description: $"{dupex.Message}\n{dupex.InnerException?.Message ?? ""}");
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
			return GrizhlaResult<FoggyTag>.ProcessFailed(HttpStatusCode.InternalServerError, message: FoggyTagControllerMessages.TAG_CREATE_FAILURE, description: $"{ex.Message}\n{ex.InnerException?.Message ?? ""}");
		}
	}

	public async Task<GrizhlaResult<FoggyTag>> UpdateAsync(FoggyTag foggyTag)
	{
		try
		{
			var dbFoggyTag = await antifogDBContext.__FoggyTag.SingleAsync(q => q.FoggyTagId == foggyTag.FoggyTagId);
			dbFoggyTag.TagName = foggyTag.TagName;
			dbFoggyTag.Explanation = foggyTag.Explanation;
			dbFoggyTag.FoggyTagDataStructure = foggyTag.FoggyTagDataStructure;
			antifogDBContext.__FoggyTag.Update(dbFoggyTag);
			await antifogDBContext.SaveChangesAsync();
			return GrizhlaResult<FoggyTag>.Processed(dbFoggyTag, message: FoggyTagControllerMessages.TAG_UPDATE_SUCCESS);
		}
		catch(Exception ex)
		{
			return GrizhlaResult<FoggyTag>.ProcessFailed(HttpStatusCode.InternalServerError, message: FoggyTagControllerMessages.TAG_UPDATE_FAILURE, description: $"{ex.Message}\n{ex.InnerException?.Message ?? ""}");
		}
	}

	internal async Task<GrizhlaResult<FoggyTag>> DeleteAsync(Guid foggyTagId)
	{
		try
		{
			var dbFoggyTag = await antifogDBContext.__FoggyTag.SingleAsync(q => q.FoggyTagId == foggyTagId);			
			antifogDBContext.__FoggyTag.Remove(dbFoggyTag);
			await antifogDBContext.SaveChangesAsync();
			return GrizhlaResult<FoggyTag>.Processed(dbFoggyTag, message: FoggyTagControllerMessages.TAG_UPDATE_SUCCESS);
		}
		catch(Exception ex)
		{
			return GrizhlaResult<FoggyTag>.ProcessFailed(HttpStatusCode.InternalServerError, message: FoggyTagControllerMessages.TAG_UPDATE_FAILURE, description: $"{ex.Message}\n{ex.InnerException?.Message ?? ""}");
		}
	}
}
