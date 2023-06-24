export interface SalesPerson {
    id: string;
    firstName: string;
    lastName: string;
    phone: string;
    startDate: Date;
    terminationDate: Date | null
    manager: string;
}

export type ServerSalesPerson = Omit<SalesPerson, "startDate" | "terminationDate"> & { startDate: string, terminationDate: string | null}

export function deserializeSalesPerson(serverResponse:ServerSalesPerson):SalesPerson{
    return {
        ...serverResponse,
        startDate: new Date(serverResponse.startDate),
        terminationDate: serverResponse.terminationDate ? new Date(serverResponse.startDate) : null
    }
}