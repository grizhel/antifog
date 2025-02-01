
using System.Net;

using antifog_service.Models.Primary;

using Grizhla.UtilitiesCore.API.Models;

namespace antifog_service.Services.Primary;

public class BasicService
{
	private readonly TagService tagService;

	public BasicService(TagService tagService)
	{
		this.tagService = tagService;
	}

	public async Task<ProcessResult<object>> DoAsync(GrizhlaRequest grizhlaRequest)
	{
		string controllerName = grizhlaRequest.ControllerAction.ControllerName;
		string actionName = grizhlaRequest.ControllerAction.ActionName;
		switch(controllerName)
		{
			case "Tag":
				switch(actionName)
				{
					case "Add":
						if(grizhlaRequest.ControllerAction.Args != null && grizhlaRequest.ControllerAction.Args.TryGetValue(FoggyArgKeys.argument, out object? foggyTag))
						{
							if(foggyTag == null || foggyTag is not FoggyTag)
							{
								return ProcessResult<object>.ProcessFailed(HttpStatusCode.BadRequest);
							}
							return ProcessResult<object>.Processed(await tagService.AddAsync((FoggyTag)foggyTag));
						}
						break;
					case "List":
						return ProcessResult<object>.Processed(await tagService.ListAsync());
				}
				break;
		}
		return ProcessResult<object>.ProcessFailed(HttpStatusCode.BadRequest);
	}
}