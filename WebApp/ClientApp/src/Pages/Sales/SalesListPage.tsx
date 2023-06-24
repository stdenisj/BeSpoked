import { Fab, Grid, Paper } from "@mui/material";
import { isMobile } from "../../Hooks/isMobile";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import { useAppData } from "../../Providers/AppDataProvider";
import { useMemo } from "react";
import { LoadingPage } from "../../Components/LoadingPage";
import { CreateSaleDialog } from "./Components/CreateSaleDialog";

const columns:GridColDef[] = [
    {field: "id", headerName: "ID", minWidth: 150},
    {field: "saleDate", headerName: "Date", minWidth: 100},
    {field: "salePrice", headerName: "Price", minWidth: 100},
    {field: "customerName", headerName: "Customer Name", minWidth: 150},
    {field: "productName", headerName: "Product Name", minWidth: 150},
    {field: "productManufacturer", headerName: "Manufacturer", minWidth: 150},
    {field: "salesPersonName", headerName: "Sales Person", minWidth: 150},
    {field: "commissionAmount", headerName: "Commission", minWidth: 100}
]

export function SalesListPage(){
    const appData = useAppData();
    const { salesLoading, productsLoading, customersLoading, salesTeamLoading } = appData
    const mobile = isMobile();

    const finishedLoading = useMemo(() => !salesLoading && !productsLoading && !customersLoading && !salesTeamLoading, [appData] )

    if(!finishedLoading)
        return <LoadingPage />

    return (
        <Grid
            container
            sx={{ p: mobile ? 2 : 0 }}
            justifyContent={mobile ? "center" : "normal"}
            spacing={2}
        >
            <Grid item xs={12} sx={{ height: 1/1}}>
                <Paper elevation={2}>
                    <DataGrid 
                        columns={columns} 
                        rows={appData.sales} 
                    />
                </Paper>
            </Grid>
            <CreateSaleDialog />
        </Grid>
    )
}