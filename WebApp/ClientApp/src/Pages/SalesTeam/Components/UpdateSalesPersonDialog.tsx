import { Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle } from "@mui/material";
import { SalesPerson } from "../../../Entities/SalesPerson";
import { UpdateSalesPersonForm, UpdateSalesPersonRequest } from "./UpdateSalesPersonForm";
import { useState } from "react";
import { FieldValidationError } from "../../../Services/server/ServerResponses";
import { SalesTeamService } from "../../../Services/SalesTeamService";
import { useAlert } from "../../../Providers/AlertProvider";
import { useAppData } from "../../../Providers/AppDataProvider";

type Props = {
    open: boolean;
    onClose: () => void;
    person: SalesPerson;
};

export function UpdateSalesPersonDialog(props:Props){
    const { person, open } = props;
    const alerts = useAlert();
    const appData = useAppData();

    const [errors, setErrors] = useState<FieldValidationError[]>([]);
    const [disabled, setDisabled] = useState(false);

    const [request, setRequest] = useState<UpdateSalesPersonRequest>({
		firstName: props.person.firstName,
		lastName: props.person.lastName,
		phone: props.person.phone,
		manager: props.person.manager,
		terminationDate: props.person.terminationDate
	});

    const handleUpdate = async() => {
        setErrors([]);

        setDisabled(true)
        const response = await SalesTeamService.update(person.id, request);
        setDisabled(false)

        if(response.validation) return setErrors(response.errors);
        if(response.error) return alerts.serverError(response);

        appData.updateSalesTeam(response.data);
        props.onClose();
    }

    return (
        <Dialog open={open} onClose={() => !disabled && props.onClose()}>
            <DialogTitle>Update {}</DialogTitle>
            <DialogContent>
                <UpdateSalesPersonForm disabled={disabled} errors={errors} request={request} onRequestUpdated={(request) => setRequest(request)} person={person}  />
            </DialogContent>
            <DialogActions>
            <Button onClick={props.onClose} disabled={disabled}>Cancel</Button>
            <Button onClick={() => handleUpdate()} disabled={disabled}>Update</Button>
            </DialogActions>
        </Dialog>
    )
}