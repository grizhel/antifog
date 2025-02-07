namespace antifog_service.Messages.Controllers.Primary;

public static class FoggyTagControllerMessages
{
	public static readonly string TAG_CREATE_SUCCESS = "PROCESS.TAG.CREATE.SUCCESS";
	public static readonly string TAG_CREATE_FAILURE = "PROCESS.TAG.CREATE.FAILURE";

	public static readonly string TAG_LIST_SUCCESS = "PROCESS.TAG.LIST.SUCCESS";
	public static readonly string TAG_LIST_FAILURE = "PROCESS.TAG.CREATE.FAILURE";

	public static readonly string TAG_CREATE_FAILURE_CONFLICT = "PROCESS.TAG.CREATE.FAILURE.CONFLICT";

	public static readonly string TAG_UPDATE_FAILURE = "PROCESS.TAG.UPDATE.SUCCESS";
	public static readonly string TAG_UPDATE_SUCCESS = "PROCESS.TAG.UPDATE.FAILURE";

	public static readonly string TAG_DELETE_FAILURE = "PROCESS.TAG.DELETE.SUCCESS";
	public static readonly string TAG_DELETE_SUCCESS = "PROCESS.TAG.DELETE.FAILURE";
}
