import { Grid } from "@mui/material";
import { LoadingPage } from "../../Components/LoadingPage";
import { isMobile } from "../../Hooks/isMobile";
import { useAppData } from "../../Providers/AppDataProvider";
import { CustomerCard } from "./Components/CustomerCard";

export function CustomerListPage(){
    const appData = useAppData();
    const mobile = isMobile();

    if(appData.customersLoading)
        return <LoadingPage />

    return (
            <Grid
                container
                sx={{ p: mobile ? 2 : 0 }}
                justifyContent={mobile ? "center" : "normal"}
                spacing={2}
            >
                { appData.customers.map(c => <CustomerCard customer={c} /> ) }
            </Grid>
    )
}