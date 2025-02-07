import * as React from "react";
import { Button, Form, Input, notification, Space } from "antd";
import TextArea from "../../components/TextArea";
import { createTag } from "../../crud/tag.crud";
import { antdNotificationProps } from "../../utils";

export function FoggyTagDataStructureForm(props) {
	const [api, contextHolder] = notification.useNotification();
	const [form] = Form.useForm();

	const [layouts] = {
		layout: {
			labelCol: { span: 8 },
			wrapperCol: { span: 16 },
		},
		tailLayout: {
			wrapperCol: { offset: 8, span: 16 },
		},
	};

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
