import { AxiosRequestConfig } from "axios";
import { CustomAxios } from "./CustomAxios";
import { ServerError, SuccessResult, ValidationError } from "./ServerResponses";

type BaseServerResponse = {
	success: false;
	validation: false;
	error: false;
};
export type CoolServerError = Omit<BaseServerResponse & ServerError, "error" | "offline"> & 
	{
		error: true;
		offline: boolean;
	};

export type CoolValidationError = Omit<BaseServerResponse & ValidationError, "validation"> & { validation: true	};

export type CoolSuccessResult<T> = Omit<BaseServerResponse & SuccessResult<T>, "success"> &  { success: true };


type DefaultServerResult<OutputModel> = CoolServerError | CoolSuccessResult<OutputModel>;
type ValidatedServerResult<OutputModel> = CoolServerError | CoolSuccessResult<OutputModel> | CoolValidationError;
// eslint-disable-next-line @typescript-eslint/no-explicit-any
type DeserializeModel<T> = (serverModel: any) => T;

const runFetch = async <OutputModel>(url: string, config: AxiosRequestConfig, deserialize?: DeserializeModel<OutputModel>) => {
	const axiosClient = CustomAxios.create();
	const axiosResponse = await axiosClient(url, config);
	const result = axiosResponse.data as ValidatedServerResult<OutputModel>;
	if (result.success && deserialize) {
		result.data = deserialize(result.data);
	}
	return result;
};

export const WebClient = {
	Get: <OutputModel>(url: string, deserialize?: DeserializeModel<OutputModel>, data?: unknown) =>
		runFetch<OutputModel>(url, { method: "get", data }, deserialize) as Promise<DefaultServerResult<OutputModel>>,
	Put: {
		Validated: <OutputModel>(
			url: string,
			data: unknown,
			deserialize?: DeserializeModel<OutputModel>
		): Promise<ValidatedServerResult<OutputModel>> =>
			runFetch<OutputModel>(url, { method: "put", data, withCredentials: true }, deserialize) as Promise<ValidatedServerResult<OutputModel>>,
		Unvalidated: <OutputModel>(url: string, data: unknown, deserialize?: DeserializeModel<OutputModel>) =>
			runFetch<OutputModel>(url, { method: "put", data, withCredentials: true }, deserialize) as Promise<DefaultServerResult<OutputModel>>,
	},
	Post: {
		Validated: <OutputModel>(url: string, data: unknown, deserialize?: DeserializeModel<OutputModel>) =>
			runFetch<OutputModel>(url, { method: "post", data, withCredentials: true }, deserialize) as Promise<ValidatedServerResult<OutputModel>>,
		Unvalidated: <OutputModel>(url: string, data: unknown, deserialize?: DeserializeModel<OutputModel>) =>
			runFetch<OutputModel>(url, { method: "post", data, withCredentials: true }, deserialize) as Promise<DefaultServerResult<OutputModel>>,
	},
	Delete: (url: string) => runFetch(url, { method: "delete", withCredentials: true }, undefined) as Promise<ValidatedServerResult<unknown>>,
};
