import { v4 as uuid } from "uuid";

const antdNotificationProps = {
	duration: 5,
	pauseOnHover: true,
	style: { width: 480 },
};

const treeFormation = (object, primaryKey, childFieldName) => {
	const fieldNames = Object.keys(object);
	const treeViewData = fieldNames.map((q) => ({
		title: q,
		key: uuid(),
		children:
			childFieldName &&
			object[childFieldName] &&
			treeFormation(object[childFieldName], primaryKey, childFieldName),
	}));
	return treeViewData;
};

export { antdNotificationProps, uuid, treeFormation };
