export interface Customer {
    id: string;
    firstName: string;
    lastName: string;
    phone: string;
    startDate: Date;
}

export type ServerCustomer = Omit<Customer, "startDate"> & { startDate: string}

export function deserializeCustomer(serverResponse:ServerCustomer):Customer{
    return {
        ...serverResponse,
        startDate: new Date(serverResponse.startDate),
    }
}