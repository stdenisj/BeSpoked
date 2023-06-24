import { CircularProgress, Grid, Typography } from "@mui/material";

export function LoadingPage() {
	return (
		<Grid container sx={{ height: "80%" }} justifyContent={"center"} alignContent={"center"}>
			<Grid item xs={12} sx={{ textAlign: "center"}}>
				<CircularProgress />
			</Grid>
			<Grid item xs={12}>
				<Typography variant="h2" align="center">Loading...</Typography>
			</Grid>
		</Grid>
	);
}
