import { Address } from '../../../../shared/models/address/address.model';

export class Site {
    public id?: number;
    public name: string;
    public isDefault: boolean;
    public nationalIdNumber?: string;
    public address: Address;
    public customerId: number;
}

export class SiteDeleteCommand {
    public id: number;
}
