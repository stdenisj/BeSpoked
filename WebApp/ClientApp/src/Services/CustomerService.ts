import { ServerCustomer, deserializeCustomer } from "../Entities/Customer";
import { WebClient } from "./server/WebClient";

const controllerRoot = "Customers"

export const CustomerService = {
    getAll: () => WebClient.Get(controllerRoot, (salesTeam:ServerCustomer[]) => salesTeam.map(deserializeCustomer)),
    get: (id:string) => WebClient.Get(`${controllerRoot}/${id}`, deserializeCustomer),
}