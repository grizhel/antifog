import axios from "axios";

export function listTag() {
	return axios.get(`${process.env.REACT_APP_TAG_API_URL}/List`);
}

export function createTag(foggyTag) {
	return axios.post(`${process.env.REACT_APP_TAG_API_URL}/Create`, foggyTag);
}
