import { useState } from "react";
import { Product, ProductStyle } from "../../../Entities/Product";
import { Button, Card, CardActions, CardContent, Grid, Typography } from "@mui/material";
import { GridGrow } from "../../../Components/GridGrow";
import { UpdateProductDialog } from "./UpdateProductDialog";

type ProductCardProps = {
    product:Product
};

export function ProductCard(props:ProductCardProps){
    const { product } = props

    const [showUpdateDialog, setShowUpdateDialog] = useState(false);

    return(
        <Grid item xs={12} sm={6} md={4} lg={3}>
            <Card >
                <CardContent>
                    <Typography gutterBottom variant="h5" component="div">
                        {product.name}
                    </Typography>
                    <Typography gutterBottom variant="subtitle1" component="div" noWrap>
                        Manufacturer: {product.manufacturer}
                    </Typography>
                    <Typography variant="body2" color="text.secondary">
                        Purchase Price: {product.purchasePrice}
                    </Typography>
                    <Typography variant="body2" color="text.secondary">
                        Sale Price: {product.salePrice}
                    </Typography>
                    <Typography variant="body2" color="text.secondary">
                        Available: { product.quantityOnHand }
                    </Typography>
                    <Typography variant="body2" color="text.secondary">
                        Commission: { product.commissionPercentage }
                    </Typography>
                </CardContent>
                <CardActions>
                    <Typography variant="body2" color="text.secondary">
                        Style: { ProductStyle[product.style] }
                    </Typography>
                    <GridGrow />
                    <Button size="small" onClick={() => setShowUpdateDialog(true)}>Update</Button>
                </CardActions>
            </Card>
            { showUpdateDialog && 
                <UpdateProductDialog 
                    open={showUpdateDialog} 
                    onClose={() => setShowUpdateDialog(false)} 
                    product={product} 
                />
            }
        </Grid>
    )
}