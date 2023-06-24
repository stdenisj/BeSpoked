export interface Product {
    id: string;
    name: string;
    manufacturer: string;
    style: ProductStyle;
    purchasePrice: number;
    salePrice: number;
    quantityOnHand: number;
    commissionPercentage: number;
}

export enum ProductStyle {
    Mountain = 1,
    Race = 2,
    Kids = 3,
}

export type ServerProduct = Product;

export function deserializeProduct(serverResponse:ServerProduct):Product{
    return {...serverResponse }
}