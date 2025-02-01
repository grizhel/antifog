import * as React from "react";
import { tagList } from "../crud/basic.crud";
import { Button, Flex, Table } from "antd";
import { EyeOutlined } from "@ant-design/icons";

export default function Tags(props) {
	const [initialized, setInitialized] = React.useState(false);
	const [foggyTags, setFoggyTags] = React.useState([]);
	const [columns, setColumns] = React.useState([]);
	const [showAddDialog, setShowAddDialog] = React.useState(false);
	const [loading, setLoading] = React.useState(false);
	const [showFoggyTagDataStructure, setShowFoggyTagDataStructure] =
		React.useState(false);
	const [relatedFoggyTag, setRelatedFoggyTag] = React.useState({});

	React.useEffect(() => {
		const _columns = [
			{ key: "foggyTagId", title: "Tag ID", display: false },
			{ key: "tagName", title: "Tag Name" },
			{
				key: "action",
				title: "Details",
				render: (_, record) => {
					return (
						<Flex gap="middle" justify="flex-start" align="center">
							<Flex>
								<Button
									onClick={() => {
										const _foggyTag = record;
										const _showFoggyTagDataStructure = true;
										setRelatedFoggyTag(_foggyTag);
										setShowFoggyTagDataStructure(true);
									}}>
									<EyeOutlined />
								</Button>
							</Flex>
						</Flex>
					);
				},
			},
		];
		tagList().then((res) => {
			const _foggyTags = res.data.model;
			setFoggyTags(_foggyTags);
			setColumns(_columns);
			setInitialized(true);
		});
	}, []);
	return (
		initialized && (
			<>
				<Flex gap="middle" vertical>
					<Flex align="center" justify="flex-end" gap="middle">
						<Button
							type="primary"
							onClick={() => {
								setShowAddDialog(true);
								setLoading(true);
							}}
							loading={loading}>
							New
						</Button>
					</Flex>
					<Table datasource={foggyTags} columns={columns} />
				</Flex>
			</>
		)
	);
}
