import { Address } from '../../../../shared/models/address/address.model';

export class Customer {
    public id?: number;
    public name?: string;
    public displayName: string;
    public phone: string;
    public nationalIdNumber?: string;
    public webSite?: string;
    public address: Address;
    public creationDate?: Date;
    public key?: string;
}

export class CustomerDeleteCommand {
    public customerIds: number[];

    constructor(customer: Customer[]) {
        this.customerIds = customer.map((c: Customer) => c.id);
    }
}
