import * as React from "react";
import { Button, Flex, Modal, notification, Table } from "antd";
import { EyeOutlined } from "@ant-design/icons";
import { listTag } from "../crud/tag.crud";
import { antdNotificationProps } from "../utils";
import { FoggyTagDataStructureView } from "./TagPartials/FoggyTagDataStructureView";
import { FoggyTagForm } from "./TagPartials/FoggyTagForm";

export default function FoggyTags(props) {
	const [api, contextHolder] = notification.useNotification();

	const [foggyTags, setFoggyTags] = React.useState([]);
	const [showAddDialog, setShowAddDialog] = React.useState(false);
	const [showFoggyTagDataStructure, setShowFoggyTagDataStructure] =
		React.useState(false);
	const [selectedFoggyTag, setSelectedFoggyTag] = React.useState({});

	const [columns] = React.useState([
		{
			key: "foggyTagId",
			dataIndex: "foggyTagId",
			title: "Tag ID",
			hidden: true,
		},
		{ key: "tagName", dataIndex: "tagName", title: "Tag Name" },
		{ key: "explanation", dataIndex: "explanation", title: "Explanation" },
		{
			key: "action",
			title: " ",
			render: (_, record) => {
				return (
					<Flex gap="middle" justify="flex-start" align="center">
						<Flex>
							<Button
								onClick={() => {
									const _foggyTag = record;
									setSelectedFoggyTag(_foggyTag);
									setShowFoggyTagDataStructure(true);
								}}
							>
								<EyeOutlined />
							</Button>
						</Flex>
					</Flex>
				);
			},
		},
	]);

	const tagTableTrigger = () => {
		listTag()
			.then((res) => {
				setFoggyTags(res.data.model.map((r) => ({ ...r, key: r.foggyTagId })));
			})
			.catch((err) => {
				api.error({
					message: err.data?.message ?? err.message ?? "Error",
					description: err.data?.description ?? "Unknown Error.",
					...antdNotificationProps,
				});
			});
	};

	React.useEffect(() => {
		tagTableTrigger();
	}, []);

	const closeAddDialog = React.useState(() => {
		setShowAddDialog(false);
	});

	return (
		<>
			{contextHolder}
			<Flex gap="middle" vertical>
				<Flex align="center" justify="flex-end" gap="middle">
					<Button
						type="primary"
						onClick={() => {
							setShowAddDialog(true);
						}}
					>
						New
					</Button>
				</Flex>
				<Table dataSource={foggyTags} columns={columns} />
			</Flex>
			<Modal
				title="New Tag"
				open={showAddDialog}
				onCancel={closeAddDialog}
				footer={null}
			>
				<FoggyTagForm
					onCancel={closeAddDialog}
					onFinish={() => {
						tagTableTrigger();
						setShowAddDialog(false);
					}}
				/>
			</Modal>
			<Modal
				title="Tag Data Structure"
				open={showFoggyTagDataStructure}
				onCancel={() => {
					setShowFoggyTagDataStructure(false);
				}}
				footer={null}
			>
				<FoggyTagDataStructureView foggyTag={selectedFoggyTag} />
			</Modal>
		</>
	);
}
