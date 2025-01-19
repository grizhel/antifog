import * as React from "react";
import PropTypes from "prop-types";
import AppBar from "@mui/material/AppBar";
import Toolbar from "@mui/material/Toolbar";

function Header(props) {
	return (
		<React.Fragment>
			<AppBar color="primary" position="sticky" elevation={0}>
				<Toolbar></Toolbar>
			</AppBar>
		</React.Fragment>
	);
}

Header.propTypes = {
	onDrawerToggle: PropTypes.func.isRequired,
};

export default Header;
