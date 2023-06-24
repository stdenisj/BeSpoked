import { Button, Dialog, DialogActions, DialogContent, Fab, FormControl, FormHelperText, Grid, InputLabel, MenuItem, Select } from "@mui/material"
import { useState } from "react"
import AddIcon from '@mui/icons-material/Add';
import { useAppData } from "../../../Providers/AppDataProvider";
import { FieldValidationError, ValidationHelper } from "../../../Services/server/ServerResponses";
import { SalesService } from "../../../Services/SalesService";
import { useAlert } from "../../../Providers/AlertProvider";

export function CreateSaleDialog(){
    const appData = useAppData();
    const alerts = useAlert();

    const [selectedCustomerId, setSelectedCustomerId] = useState<string>();
    const [selectedProductId, setSelectedProductId] = useState<string>();
    const [selectedSalesPersonId, setSelectedSalesPersonId] = useState<string>();
    const [errors, setErrors] = useState<FieldValidationError[]>([])
    const [disabled, setDisabled] = useState(false);
    const [showDialog, setShowDialog] = useState(false);

    const handleSave = async() => {
        setErrors([]);

        if(!selectedCustomerId) return setErrors([{field: "CustomerId", errors: ["Invalid Customer"]}]);
        if(!selectedProductId) return setErrors([{field: "ProductId", errors: ["Invalid Product"]}]);
        if(!selectedSalesPersonId) return setErrors([{field: "SalesPersonId", errors: ["Invalid Sales Person"]}]);

        const request = { customerId: selectedCustomerId, productId: selectedProductId, salesPersonId: selectedSalesPersonId };

        setDisabled(true);
        const response = await SalesService.create(request);
        setDisabled(false);

        if(response.error) return alerts.serverError(response);
        if(response.validation) return setErrors(response.errors);

        appData.addSale(response.data);
        setShowDialog(false)
        setSelectedCustomerId(undefined);
        setSelectedProductId(undefined);
        setSelectedSalesPersonId(undefined);
    }

    if(!showDialog)
        return (
            <Fab 
                color="primary" 
                aria-label="add" 
                sx={{position: "absolute",bottom: 15, right: 15}} 
                onClick={() => setShowDialog(true)}
            >
                <AddIcon />
            </Fab>
        )

    return (
        <Dialog open={showDialog} onClose={() => !disabled && setShowDialog(false)} disableEscapeKeyDown={disabled}>
            <DialogContent> 
                <Grid container spacing={2}>
                    <Grid item xs={12}>
                        <FormControl fullWidth sx={{ m: 1}}>
                            <InputLabel>Customer</InputLabel>
                            <Select
                                fullWidth
                                label="Customer"
                                value={selectedCustomerId}
                                onChange={(e) => setSelectedCustomerId(e.target.value)}
                                error={ValidationHelper.isFieldInError(errors, "CustomerId")}
                            >
                                { appData.customers.map(c => <MenuItem value={c.id}>{`${c.firstName} ${c.lastName}`}</MenuItem> )}
                            </Select>
                            { ValidationHelper.isFieldInError(errors, "CustomerId") &&
                                <FormHelperText error>{ValidationHelper.getFieldErrorSummary(errors, "CustomerId")}</FormHelperText>
                            }
                        </FormControl>
                    </Grid>
                    <Grid item xs={12}>
                        <FormControl fullWidth sx={{ m: 1}}>
                            <InputLabel>Product</InputLabel>
                            <Select
                                fullWidth
                                label="Product"
                                value={selectedProductId}
                                onChange={(e) => setSelectedProductId(e.target.value)}
                                error={ValidationHelper.isFieldInError(errors, "ProductId")}
                            >
                                { appData.products.map(p => <MenuItem value={p.id}>{`${p.name} - ${p.manufacturer}`}</MenuItem> )}
                            </Select>
                            { ValidationHelper.isFieldInError(errors, "ProductId") &&
                                <FormHelperText error>{ValidationHelper.getFieldErrorSummary(errors, "ProductId")}</FormHelperText>
                            }
                        </FormControl>
                    </Grid>
                    <Grid item xs={12}>
                        <FormControl fullWidth sx={{ m: 1}}>
                            <InputLabel>Sales Person</InputLabel>
                            <Select
                                fullWidth
                                label="Sales Person"
                                value={selectedSalesPersonId}
                                onChange={(e) => setSelectedSalesPersonId(e.target.value)}
                                error={ValidationHelper.isFieldInError(errors, "SalesPersonId")}
                            >
                                { appData.salesTeam.map(p => <MenuItem value={p.id}>{`${p.firstName} ${p.lastName}`}</MenuItem> )}
                            </Select>
                            { ValidationHelper.isFieldInError(errors, "SalesPersonId") &&
                                <FormHelperText error>{ValidationHelper.getFieldErrorSummary(errors, "SalesPersonId")}</FormHelperText>
                            }
                        </FormControl>
                    </Grid>
                </Grid>
            </DialogContent>
            <DialogActions>
                <Button color="error" onClick={() => setShowDialog(false)}>Cancel</Button>
                <Button color="primary" onClick={() => handleSave()}>Save</Button>
            </DialogActions>
        </Dialog>
    )
}