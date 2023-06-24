import { deserializeSale } from "../Entities/Sales/Sale";
import { ServerSaleSummary, deserializeSaleSummary } from "../Entities/Sales/SaleSummary";
import { WebClient } from "./server/WebClient";

const controllerRoot = "Sales"

export interface CreateSaleRequest {
    customerId: string;
    productId: string;
    salesPersonId: string;
}

export const SalesService = {
    getAll: () => WebClient.Get(controllerRoot, (sales:ServerSaleSummary[]) => sales.map(deserializeSaleSummary)),
    get: (id:string) => WebClient.Get(`${controllerRoot}/${id}`, deserializeSale),
    create: (request:CreateSaleRequest) => WebClient.Post.Validated(controllerRoot, request, deserializeSaleSummary)
}