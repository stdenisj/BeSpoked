import { Grid } from "@mui/material";
import { LoadingPage } from "../../Components/LoadingPage";
import { useAppData } from "../../Providers/AppDataProvider";
import { isMobile } from "../../Hooks/isMobile";
import { SalesPersonCard } from "./Components/SalesPersonCard";

export function SalesTeamListPage(){
    const appData = useAppData();
    const mobile = isMobile();

    if(appData.salesTeamLoading)
        return <LoadingPage />

    return (
            <Grid
                container
                sx={{ p: mobile ? 2 : 0 }}
                justifyContent={mobile ? "center" : "normal"}
                spacing={2}
            >
                { appData.salesTeam.map(p => <SalesPersonCard person={p} /> ) }
            </Grid>
    )
}