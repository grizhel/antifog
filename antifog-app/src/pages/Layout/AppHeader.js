import { Menu } from "antd";
import { Header } from "antd/es/layout/layout";
import * as React from "react";
import { useLocation, useNavigate } from "react-router";

export default function AppHeader() {
	const menuItems = [
		{
			label: "Information",
			key: "/information",
		},
		{
			label: "Tags",
			key: "/tags",
		},
	];

	const navigate = useNavigate();
	const location = useLocation();

	const [selectedMenuEvent, setSelectedMenuEvent] = React.useState({
		path: location.pathname,
	});

	return (
		<Header style={{ display: "flex", alignItems: "center" }}>
			<img alt="" src={"android-chrome-192x192.png"} style={{ height: 64 }} />
			<Menu
				style={{ paddingLeft: 10 }}
				theme="dark"
				mode="horizontal"
				onClick={(e) => {
					setSelectedMenuEvent(e);
					navigate(e.key);
				}}
				selectedKeys={[selectedMenuEvent.key]}
				items={menuItems}
			/>
		</Header>
	);
}
