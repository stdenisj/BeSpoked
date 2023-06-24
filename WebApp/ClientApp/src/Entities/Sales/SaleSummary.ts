export interface SaleSummary {
    id: string;
    saleDate: Date;
    salePrice: number;
    customerName: string;
    salesPersonName: string;
    commissionAmount: number;
    productName: string;
    productManufacturer: string;
}

export type ServerSaleSummary = Omit<SaleSummary, "saleDate" | "id"> & { saleDate: string, saleId: string }

export function deserializeSaleSummary(serverResponse:ServerSaleSummary):SaleSummary {
    return {...serverResponse, saleDate: new Date(serverResponse.saleDate), id: serverResponse.saleId}
}