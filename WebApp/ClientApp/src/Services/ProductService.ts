import { ServerProduct, deserializeProduct } from "../Entities/Product";
import { WebClient } from "./server/WebClient";

const controllerRoot = "Products"

interface UpdateProductRequest {
    id: string;
    salesPrice: number;
    quantity: number;
}

export const ProductService = {
    getAll: () => WebClient.Get(controllerRoot, (salesTeam:ServerProduct[]) => salesTeam.map(deserializeProduct)),
    get: (id:string) => WebClient.Get(`${controllerRoot}/${id}`, deserializeProduct),
    update: (request:UpdateProductRequest) => WebClient.Put.Validated(controllerRoot, request, deserializeProduct)
}