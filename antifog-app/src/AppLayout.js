import { Flex, Layout } from "antd";
import * as React from "react";
import AppHeader from "./pages/Layout/AppHeader";
import AppContent from "./pages/Layout/AppContent";
import AppFooter from "./pages/Layout/AppFooter";

export default function AppLayout() {
	return (
		<div
			style={{
				height: "100vh",
				display: "flex",
				flexDirection: "column",
				boxSizing: "border-box",
			}}>
			<Layout>
				<Flex gap="middle" vertical>
					<AppHeader />
					<AppContent />
					<AppFooter />
				</Flex>
			</Layout>
		</div>
	);
}
