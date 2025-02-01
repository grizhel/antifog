import axios from "axios";

export function tagList() {
	return axios.post(process.env.REACT_APP_TAG_API_URL, {
		controllerAction: {
			controllerName: "Tag",
			actionName: "List",
		},
	});
}
