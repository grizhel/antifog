import * as React from "react";
import {
	Navigate,
	Route,
	Routes,
	useNavigate,
	useNavigation,
} from "react-router";
import Tags from "./Tags";
import { Breadcrumb, Flex, Menu, Tabs } from "antd";

export default function Content() {
	const menuItems = [
		{
			label: "Information",
			key: "information",
			__breadcrumb: [{ title: "Information" }],
		},
		{
			label: "Tags",
			key: "tags",
			__breadcrumb: [{ title: "Tags" }],
		},
	];
	const [selectedMenuEvent, setSelectedMenuEvent] = React.useState({
		key: "information",
	});
	const [breadcrumb, setBreadcrumbs] = React.useState(
		menuItems.find((q) => q.key == selectedMenuEvent.key).__breadcrumb
	);
	const navigate = useNavigate();
	return (
		<Flex gap="middle" vertical>
			<Menu
				mode="horizontal"
				onClick={(e) => {
					setSelectedMenuEvent(e);
					setBreadcrumbs(menuItems.find((q) => q.key == e.key).__breadcrumb);
					navigate(e.key);
				}}
				selectedKeys={[selectedMenuEvent.key]}
				items={menuItems}
			/>
			<Breadcrumb items={breadcrumb} />
			<Routes>
				<Route path="/tags" element={<Tags />} />
				<Route path="/information" element={<></>} />
				<Route path="*" element={<Navigate to={"information"} />} />
			</Routes>
		</Flex>
	);
}
