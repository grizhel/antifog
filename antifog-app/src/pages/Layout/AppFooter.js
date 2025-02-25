import { Footer } from "antd/es/layout/layout";

export default function AppFooter() {
	return (
		<Footer
			style={{
				textAlign: "center",
				width: "100%",
			}}
		>
			<a
				href="https://github.com/grizhel?tab=repositories"
				rel="noreferrer"
				target="_blank"
			>
				Grizhël's Anti-Fog App ©{new Date().getFullYear()}
			</a>
		</Footer>
	);
}
