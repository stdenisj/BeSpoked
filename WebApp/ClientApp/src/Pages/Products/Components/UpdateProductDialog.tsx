import { Box, Button, Dialog, DialogActions, DialogContent, DialogTitle, FormControl, Grid, InputAdornment, InputLabel, OutlinedInput } from "@mui/material";
import { useState } from "react";
import { FieldValidationError, ValidationHelper } from "../../../Services/server/ServerResponses";
import { useAlert } from "../../../Providers/AlertProvider";
import { useAppData } from "../../../Providers/AppDataProvider";
import { ProductService } from "../../../Services/ProductService";
import { Product } from "../../../Entities/Product";

type Props = {
    open: boolean;
    onClose: () => void;
    product: Product;
};

export function UpdateProductDialog(props:Props){
    const { product, open } = props;
    const alerts = useAlert();
    const appData = useAppData();

    const [errors, setErrors] = useState<FieldValidationError[]>([]);
    const [disabled, setDisabled] = useState(false);

    const [updatedSalesPrice, setUpdatedSalesPrice] = useState(product.salePrice)
    const [updatedQuantity, setUpdatedQuantity] = useState(product.quantityOnHand)

    const handleUpdate = async() => {
        setErrors([]);

        const request = { quantity: updatedQuantity, salesPrice: updatedSalesPrice, id: product.id}

        setDisabled(true)
        const response = await ProductService.update(request);
        setDisabled(false)

        if(response.validation) return setErrors(response.errors);
        if(response.error) return alerts.serverError(response);

        appData.updateProduct(response.data);
        props.onClose();
    }

    return (
        <Dialog open={open} onClose={() => !disabled && props.onClose()}>
            <DialogTitle>Update {product.name}</DialogTitle>
            <DialogContent>
                <Box sx={{ m: 1 }} >
                    <Grid container spacing={2}>
                        <Grid item xs={12}>
                            <FormControl fullWidth>
                                <InputLabel htmlFor="outlined-adornment-amount">Amount</InputLabel>
                                <OutlinedInput
                                    id="outlined-adornment-amount"
                                    value={updatedSalesPrice}
                                    onChange={(e) => !isNaN(parseFloat(e.target.value)) && setUpdatedSalesPrice(+e.target.value)}
                                    startAdornment={<InputAdornment position="start">$</InputAdornment>}
                                    type="number"
                                    label="Amount"
                                    error={ValidationHelper.isFieldInError(errors, "SalePrice")}
                                />
                            </FormControl>
                        </Grid>
                        <Grid item xs={12}>
                            <FormControl fullWidth>
                                <InputLabel htmlFor="outlined-adornment-amount">Quantity</InputLabel>
                                <OutlinedInput
                                    id="outlined-adornment-amount"
                                    value={updatedQuantity}
                                    onChange={(e) => {
                                        if(!isNaN(parseFloat(e.target.value))) return setUpdatedQuantity(+e.target.value)
                                        else return setUpdatedQuantity(0)
                                    }}
                                    type="number"
                                    label="Quantity"
                                    error={ValidationHelper.isFieldInError(errors, "QuantityOnHand")}
                                />
                            </FormControl>
                        </Grid>
                    </Grid>
                </Box>
            </DialogContent>
            <DialogActions>
                <Button onClick={props.onClose} disabled={disabled}>Cancel</Button>
                <Button onClick={() => handleUpdate()} disabled={disabled}>Update</Button>
            </DialogActions>
        </Dialog>
    )
}