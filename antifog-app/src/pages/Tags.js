import * as React from "react";
import {
	Button,
	Flex,
	Form,
	Input,
	Modal,
	notification,
	Space,
	Table,
} from "antd";
import { EyeOutlined } from "@ant-design/icons";
import TextArea from "../components/TextArea";
import { createTag, listTag } from "../crud/tag.crud";
import { antdNotificationProps } from "../utils";

export default function Tags(props) {
	const [api, contextHolder] = notification.useNotification();

	const [foggyTags, setFoggyTags] = React.useState([]);
	const [showAddDialog, setShowAddDialog] = React.useState(false);
	const [showFoggyTagDataStructure, setShowFoggyTagDataStructure] =
		React.useState(false);
	const [relatedFoggyTag, setRelatedFoggyTag] = React.useState({});

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
									setRelatedFoggyTag(_foggyTag);
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
				setFoggyTags(res.data.model.map((r, i) => ({ ...r, key: i })));
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

	const closeAddDialog = () => {
		setShowAddDialog(false);
	};

	console.log(foggyTags);

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
				<TagForm
					onCancel={closeAddDialog}
					onFinish={() => {
						tagTableTrigger();
						setShowAddDialog(false);
					}}
				/>
			</Modal>
		</>
	);
}

export function TagForm(props) {
	const [api, contextHolder] = notification.useNotification();
	const [form] = Form.useForm();

	const [layouts] = React.useState({
		layout: {
			labelCol: { span: 8 },
			wrapperCol: { span: 16 },
		},
		tailLayout: {
			wrapperCol: { offset: 8, span: 16 },
		},
	});

	const onFinish = (values) => {
		createTag(values)
			.then((res) => {
				if (res.data.success) {
					api.success({
						message: res.data?.message ?? "SUCCESS",
						description: res.data?.description ?? "Task is completed.",
						...antdNotificationProps,
					});
				} else {
					api.error({
						message: res.data?.message ?? res.message ?? "Error",
						description: res.data?.description ?? "Unknown Error.",
						...antdNotificationProps,
					});
				}
				if (props.onFinish) {
					props.onFinish(res.data);
				}
			})
			.catch((err) => {
				api.error({
					message: err.data?.message ?? err.message ?? "Error",
					description: err.data?.description ?? "Unknown Error.",
					...antdNotificationProps,
				});
			})
			.finally(() => {
				form.resetFields();
			});
	};

	const onCancel = () => {
		if (props.onCancel) {
			props.onCancel();
		}
		form.resetFields();
	};

	return (
		<>
			{contextHolder}
			<Form
				{...layouts.layout}
				form={form}
				name="add-new-tag"
				onFinish={onFinish}
				style={{ maxWidth: 600 }}
			>
				<Form.Item name="tagName" label="Tag Name" rules={[{ required: true }]}>
					<Input />
				</Form.Item>
				<Form.Item
					name="explanation"
					label="Explanation"
					rules={[{ required: true }]}
				>
					<TextArea rows={4} />
				</Form.Item>
				<Form.Item {...layouts.tailLayout}>
					<Space>
						<Button type="primary" htmlType="submit">
							Submit
						</Button>
						<Button htmlType="button" onClick={onCancel}>
							Cancel
						</Button>
					</Space>
				</Form.Item>
			</Form>
		</>
	);
}
