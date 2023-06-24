export interface ServerError {
	message: string;
	statusCode: number;
}

export interface SuccessResult<T> {
	data: T;
	message: string;
}

export interface ValidationError {
	valid: boolean;
	errors: FieldValidationError[];
}

export interface FieldValidationError {
	field: string;
	errors: string[];
}

export const ValidationHelper = {
	isFieldInError: (errors: FieldValidationError[], fieldName: string) => {
		return errors.map((error) => error.field).indexOf(fieldName) > -1;
	},
	getFieldErrorSummary:(errors: FieldValidationError[], fieldName: string) => {
		var retVal = "";
		errors
			.filter((error) => error.field === fieldName)
			.forEach((error) => {
				error.errors.forEach((str) => (retVal += str + " "));
			});
		return retVal;
	},
	hasGenericError: (errors: FieldValidationError[]) => {
		return errors.map((error) => error.field).indexOf("") > -1;
	},
	getGenericErrorSummary: (errors: FieldValidationError[]) => {
		var retVal = "";
		errors
			.filter((error) => error.field === "")
			.forEach((error) => {
				error.errors.forEach((str) => (retVal += str + " "));
			});
		return retVal;
	}
}