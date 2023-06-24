import { Grid } from "@mui/material";
import { LoadingPage } from "../../Components/LoadingPage";
import { isMobile } from "../../Hooks/isMobile";
import { useAppData } from "../../Providers/AppDataProvider";
import { ProductCard } from "./Components/ProductCard";

export function ProductListPage(){
    const appData = useAppData();
    const mobile = isMobile();

    if(appData.productsLoading)
        return <LoadingPage />

    return (
            <Grid
                container
                sx={{ p: mobile ? 2 : 0 }}
                justifyContent={mobile ? "center" : "normal"}
                spacing={2}
            >
                { appData.products.map(p => <ProductCard product={p} /> ) }
            </Grid>
    )
}