import { Breadcrumb, Menu } from "antd";
import { Header } from "antd/es/layout/layout";
import * as React from "react";
import { useLocation, useNavigate } from "react-router";

export default function AppHeader() {
	const menuItems = [
		{
			label: "Information",
			key: "/information",
			__breadcrumb: [{ title: "Information" }],
		},
		{
			label: "Tags",
			key: "/tags",
			__breadcrumb: [{ title: "Tags" }],
		},
	];
	const navigate = useNavigate();
	const location = useLocation();

	const [selectedMenuEvent, setSelectedMenuEvent] = React.useState({
		key: location.pathname,
	});
	const [breadcrumb, setBreadcrumbs] = React.useState("");

	return (
		<Header style={{ display: "flex", alignItems: "center" }}>
			<img alt="" src={"android-chrome-192x192.png"} style={{ height: 64 }} />
			<Menu
				style={{ paddingLeft: 10 }}
				theme="dark"
				mode="horizontal"
				onClick={(e) => {
					setSelectedMenuEvent(e);
					setBreadcrumbs(menuItems.find((q) => q.key === e.key).__breadcrumb);
					navigate(e.key);
				}}
				selectedKeys={[selectedMenuEvent.key]}
				items={menuItems}
			/>
			<Breadcrumb items={breadcrumb} />
		</Header>
	);
}
