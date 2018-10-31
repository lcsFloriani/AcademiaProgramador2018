import { Address, AddressRegisterCommand } from '../../address/address.model';

export class Conveyor {
    public id: number;
    public personType: number;
    public nameCompanyName: string;
    public cpfCnpj: string;
    public freightResponsibility: string;
    public address: Address;
}
export enum PersonType {
    'Fisica' = 1,
    'Juridica' = 2,
}
export enum FreightResponsibility {
    'Emitente' = 1,
    'Destinatário' = 2,
}
export class ConveyorRegisterCommand {
    public personType: number;
    public nameCompanyName: string;
    public freightResponsibility: string;
    public cpfCnpj: string;
    public address: AddressRegisterCommand;

    constructor(model: ConveyorFormModel) {
        this.map(model);
    }
    private map(model: ConveyorFormModel): void {
        this.personType = Number(model.personType);
        this.freightResponsibility = model.freightResponsibility;

        switch (this.personType.toString()) {
            case '1':
                this.nameCompanyName = model.individual.name;
                this.cpfCnpj = model.individual.cpf;
                break;
            case '2':
                this.nameCompanyName = model.enterprise.companyName;
                this.cpfCnpj = model.enterprise.cnpj;
                break;
            default:
                break;
        }

        this.address = model.address;
    }
}
export class ConveyorUpdateCommand {
    public id: number;
    public personType: number;
    public nameCompanyName: string;
    public freightResponsibility: string;
    public cpfCnpj: string;
    public address: AddressRegisterCommand;

    constructor(conveyor: ConveyorFormModel, id: number) {
        this.map(conveyor, id);
    }
    private map(model: ConveyorFormModel, id: number): void {
        this.id = id;
        this.personType = Number(model.personType);
        this.freightResponsibility = model.freightResponsibility;
        this.address = model.address;
        switch (this.personType.toString()) {
            case '1':
                this.nameCompanyName = model.individual.name;
                this.cpfCnpj = model.individual.cpf;
                break;
            case '2':
                this.nameCompanyName = model.enterprise.companyName;
                this.cpfCnpj = model.enterprise.cnpj;
                break;
            default:
                break;
        }
    }
}
export class ConveyorIndividualFormModel {
    public name: string;
    public cpf: string;
}

export class ConveyorEnterpriseFormModel {
    public companyName: string;
    public cnpj: string;
}

export class ConveyorFormModel {
    public personType: string;
    public individual: ConveyorIndividualFormModel;
    public enterprise: ConveyorEnterpriseFormModel;
    public address: Address;
    public freightResponsibility: string;
    constructor(conveyor: Conveyor) {

        this.personType = conveyor.personType.toString();
        this.freightResponsibility = conveyor.freightResponsibility;
        this.address = conveyor.address;

        switch (this.personType.toString()) {
            case '1':
                this.individual = new ConveyorIndividualFormModel();
                this.individual.name = conveyor.nameCompanyName;
                this.individual.cpf = conveyor.cpfCnpj;
                break;
            case '2':
                this.enterprise = new ConveyorEnterpriseFormModel();
                this.enterprise.companyName = conveyor.nameCompanyName;
                this.enterprise.cnpj = conveyor.cpfCnpj;
                break;
            default:
                break;
        }
    }

}
export class ConveyorDeleteCommand {
    public conveyorsIds: number[] = [];
    constructor(emitters: Conveyor[]) {
        this.conveyorsIds = emitters.map((e: Conveyor) => e.id);
    }
}
