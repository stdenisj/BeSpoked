import axios, { AxiosError } from "axios";
import { CoolServerError, CoolSuccessResult, CoolValidationError } from "./WebClient";

const createOfflineServerError = (message: string): CoolServerError => ({ message, statusCode: 0, error: true, success: false, validation: false, offline: true });

const createServerError = (message: string, statusCode: number): CoolServerError => ({
	message,
	statusCode,
	error: true,
	success: false,
	validation: false,
	offline: false,
});

const serializeAxiosError = (axiosError: AxiosError): CoolServerError | CoolValidationError => {
	if (axiosError.code === "ERR_NETWORK" || axiosError.response === undefined) {
		return createOfflineServerError("Network Error");
	}
	const response = axiosError.response;
	if (response.status === 404) {
		return createServerError("Request was submitted to the incorrect location.", 404);
	}

	if (response.data === undefined) {
		return createServerError("Unknown error", 500);
	}

	const data = response.data as CoolServerError | CoolValidationError;
	if ("errors" in data) {
		const validationResult: CoolValidationError = {
			valid: false,
			errors: data.errors,
			error: false,
			success: false,
			validation: true,
		};
		return validationResult;
	}
	return createServerError(data.message, response.status);
};

const createAxiosWithInterceptors = () => {
	const instance = axios.create({ baseURL: "https://localhost:7043/api/"});
	instance
	instance.interceptors.response.use(
		(response) => {
			const success: CoolSuccessResult<unknown> = {
				data: response.data?.data,
				message: response.data?.message,
				error: false,
				success: true,
				validation: false,
			};
			return { ...response, data: success };
		},
		(error: Error | AxiosError<CoolServerError | CoolValidationError>) => {
			if (!axios.isAxiosError(error)) {
				console.log("axios.interceptors.response.use: Failed [Error]", error);
				return Promise.reject(error);
			}
			return Promise.resolve({ ...error, data: serializeAxiosError(error) });
		}
	);
	return instance;
}

export const CustomAxios = {
    create: () => createAxiosWithInterceptors(),
}