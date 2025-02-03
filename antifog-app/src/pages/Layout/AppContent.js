import * as React from "react";
import { Route, Routes } from "react-router";
import Tags from "../Tags";

export default function AppContent() {
	return (
		<div
			style={{
				paddingLeft: 48,
				paddingRight: 48,
			}}>
			<Routes>
				<Route path="/" element={<></>} />
				<Route path="/tags" element={<Tags />} />
				<Route path="/information" element={<></>} />
			</Routes>
		</div>
	);
}
