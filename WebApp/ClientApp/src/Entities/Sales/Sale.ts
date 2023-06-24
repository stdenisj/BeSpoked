export interface Sale {
    id: string;
    customerId: string;
    salesPersonId: string;
    ProductId: string;
    salesDate: Date;
}

export type ServerSale = Omit<Sale, "salesDate"> & { salesDate: string }

export function deserializeSale(serverResponse:ServerSale):Sale {
    return {
        ...serverResponse,
        salesDate: new Date(serverResponse.salesDate)
    }
}