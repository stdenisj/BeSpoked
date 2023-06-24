import { ServerSalesPerson, deserializeSalesPerson } from "../Entities/SalesPerson";
import { UpdateSalesPersonRequest } from "../Pages/SalesTeam/Components/UpdateSalesPersonForm";
import { WebClient } from "./server/WebClient";

const controllerRoot = "SalesTeam"

export const SalesTeamService = {
    getAll: () => WebClient.Get(controllerRoot, (salesTeam:ServerSalesPerson[]) => salesTeam.map(deserializeSalesPerson)),
    get: (id:string) => WebClient.Get(`${controllerRoot}/${id}`, deserializeSalesPerson),
    update: (id:string, request:UpdateSalesPersonRequest) => WebClient.Put.Validated(controllerRoot, {id, ...request}, deserializeSalesPerson)
}