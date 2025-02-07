import * as React from "react";
import { Table } from "antd";

export const FoggyTagDataStructureView = (props) => {
	return (
		<Table
			dataSource={props.foggyTag.foggyTagDataStructure?.fields}
			columns={[
				{
					key: "fieldName",
					dataIndex: "fieldName",
					title: "Field Name",
				},
				{
					key: "order",
					dataIndex: "order",
					title: "Order",
				},
			]}
		/>
	);
};
