import { Grid, List, ListItem, ListItemButton, ListItemText } from "@mui/material";
import { PropsWithChildren, useContext } from "react";
import { isMobile } from "../Hooks/isMobile";
import { AppThemeContext } from "../Providers/AppThemeProvider";
import { useNavigate, useLocation } from "react-router-dom";
import { routes } from "../routes";

export function AppLayout(props: PropsWithChildren<{}>) {
	const mobile = isMobile();
	return (mobile ? <MobileLayout>{props.children}</MobileLayout> : <DeskTopLayout>{props.children}</DeskTopLayout>)
}

function DeskTopLayout(props: PropsWithChildren<{}>) {
	const navigate = useNavigate();
	const [theme, setTheme]  = useContext(AppThemeContext)

	return (
		<div id="desktop-layout">
			<div
				id="desktop-layout-sidebar"
				style={{
					top: 0,
					bottom: 0,
					width: 240,
					position: "absolute",
					overflowX: "hidden",
					whiteSpace: "nowrap",
				}}
			>
				<div style={{ overflowY: "auto" }}>
					<Grid container>
						<List sx={{ width: 1 }} >
							<ListItem disablePadding>
								<ListItemButton onClick={() => navigate(routes.sales)}>
									<ListItemText primary="Sales" />
								</ListItemButton>
							</ListItem>
							<ListItem disablePadding>
								<ListItemButton onClick={() => navigate(routes.products)}>
									<ListItemText primary="Products" />
								</ListItemButton>
							</ListItem>
							<ListItem disablePadding>
								<ListItemButton onClick={() => navigate(routes.customers)}>
									<ListItemText primary="Customers" />
								</ListItemButton>
							</ListItem>
							<ListItem disablePadding>
								<ListItemButton onClick={() => navigate(routes.salesTeam)}>
									<ListItemText primary="Sales Team" />
								</ListItemButton>
							</ListItem>
							<ListItem disablePadding>
								<ListItemButton onClick={() => 
									theme === "dark" 
									? setTheme("light") 
									: setTheme("dark")
								}>
									<ListItemText primary={theme === "dark" ? "Light Mode" : "Dark Mode"} />
								</ListItemButton>
							</ListItem>
						</List>
					</Grid>
				</div>
			</div>
			<Grid
				id="desktop-layout-view"
				sx={{
					top: 0,
					bottom: 0,
					right: 0,
					left: 240,
					paddingTop: 2,
					paddingLeft: 4,
					paddingRight: 4,
					position: "absolute",
					overflowX: "hidden",
				}}
			>
				{props.children}
			</Grid>
		</div>
	);
}

function MobileLayout(props: PropsWithChildren<{}>) {
	const location = useLocation();
	const navigate = useNavigate();

	return (
		<div id="mobile-layout">
			<div
				id="mobile-layout-header-view"
				style={{
					position: "absolute",
					top: 0,
					left: 0,
					right: 0,
					bottom: 0,
					overflowY: "auto",
				}}
			>
				{props.children}
			</div>
		</div>
	);
}