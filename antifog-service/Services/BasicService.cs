
using System.Net;

using antifog_service.Models.Basics;

using Grizhla.UtilitiesCore.API.Models;

namespace antifog_service.Services;

public class BasicService
{
	private readonly TagService tagService;

	public BasicService(TagService tagService)
	{
		this.tagService = tagService;
	}

	public async Task<ProcessResult<FoggyTag>> DoAsync(GrizhlaRequest grizhlaRequest)
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
								return ProcessResult<FoggyTag>.ProcessFailed(HttpStatusCode.BadRequest);
							}
							await tagService.AddAsync((FoggyTag)foggyTag);
							return ProcessResult<FoggyTag>.Processed(foggyTag as FoggyTag);
						}
						break;
				}
				break;
		}
		return ProcessResult<FoggyTag>.ProcessFailed(HttpStatusCode.BadRequest);
	}
}