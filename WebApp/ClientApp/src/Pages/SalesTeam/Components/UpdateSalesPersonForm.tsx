import { FieldValidationError, ValidationHelper } from "../../../Services/server/ServerResponses";
import { Grid, Typography, TextField } from "@mui/material";
import { routes } from "../../../routes";
import { PhoneTextField } from "../../../Components/PhoneTextField";
import { SalesPerson } from "../../../Entities/SalesPerson";

export interface UpdateSalesPersonRequest {
	firstName: string;
	lastName: string;
	phone: string;
	manager: string;
	terminationDate: Date | null;
}

interface UpdateSalesPersonFormProps {
	disabled: boolean;
	person:SalesPerson;
	errors: FieldValidationError[];
	onRequestUpdated: (request: UpdateSalesPersonRequest) => void;
	request: UpdateSalesPersonRequest;
}

export function UpdateSalesPersonForm(props: UpdateSalesPersonFormProps) {
	const { disabled, errors, request } = props;

	return (
		<Grid container justifyContent={"center"} spacing={2} sx={{p: 1}}>
			<Grid item md={5} sm={6} xs={6}>
				<TextField
					variant="outlined"
					disabled={disabled}
					label="First Name"
					fullWidth
					required
					type="text"
					value={request.firstName}
					onChange={(e) => props.onRequestUpdated({ ...request, firstName: e.target.value })}
					error={ValidationHelper.isFieldInError(errors, "First Name")}
					helperText={ValidationHelper.getFieldErrorSummary(errors, "First Name")}
				/>
			</Grid>
			<Grid item md={5} sm={6} xs={6}>
				<TextField
					variant="outlined"
					disabled={disabled}
					label="Last Name"
					fullWidth
					required
					type="text"
					value={request.lastName}
					onChange={(e) => props.onRequestUpdated({ ...request, lastName: e.target.value })}
					error={ValidationHelper.isFieldInError(errors, "Last Name")}
					helperText={ValidationHelper.getFieldErrorSummary(errors, "Last Name")}
				/>
			</Grid>
			<Grid item md={5} sm={6} xs={6}>
				<TextField
					variant="outlined"
					disabled={disabled}
					label="Manager"
					fullWidth
					required
					type="text"
					value={request.manager}
					onChange={(e) => props.onRequestUpdated({ ...request, manager: e.target.value })}
					error={ValidationHelper.isFieldInError(errors, "Manager")}
					helperText={ValidationHelper.getFieldErrorSummary(errors, "Manager")}
				/>
			</Grid>
			<Grid item md={5} sm={6} xs={12}>
				<PhoneTextField
					required
					fullWidth
					id="phoneNumber"
					label="Phone Number"
					type={"tel"}
					margin="dense"
					onChangePhoneNumber={(n) => props.onRequestUpdated({ ...request, phone: n })}
					value={request.phone}
					error={ValidationHelper.isFieldInError(errors, "Phone")}
					helperText={ValidationHelper.isFieldInError(errors,"Phone") && "Invaild Phone number"}
				/>
			</Grid>
		</Grid>
	);
}
