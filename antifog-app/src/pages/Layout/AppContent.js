import * as React from "react";
import { Route, Routes } from "react-router";
import FoggyTags from "../FoggyTags";

export default function AppContent() {
	return (
		<div
			style={{
				paddingLeft: 48,
				paddingRight: 48,
				minHeight: "calc(100vh - 180px)",
			}}
		>
			<Routes>
				<Route path="/" element={<></>} />
				<Route path="/tags" element={<FoggyTags />} />
				<Route path="/information" element={<></>} />
			</Routes>
		</div>
	);
}
