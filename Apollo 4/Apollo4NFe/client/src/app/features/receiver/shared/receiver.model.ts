import { Address } from '../../address/address.model';

export class Receiver {
    public id: number;
    public type: number;
    public nameCompanyName: string;
    public cpfCnpj: string;
    public stateRegistration: string;
    public address: Address;
}

export class ReceiverDeleteCommand {
    public receiverIds: number[] = [];

    constructor(receivers: Receiver[]) {
        this.receiverIds = receivers.map((c: Receiver) => c.id);
    }
}

export class ReceiverRegisterCommand {
    public type: number;
    public nameCompanyName: string;
    public cpfCnpj: string;
    public stateRegistration: string;
    public address: Address;

    constructor(model: ReceiverFormModel) {
        this.map(model);
    }

    private map(model: ReceiverFormModel): void {
        this.type = Number(model.type);

        switch (this.type.toString()) {
            case '1':
                this.nameCompanyName = model.individual.name;
                this.cpfCnpj = model.individual.cpf;
                break;
            case '2':
                this.nameCompanyName = model.enterprise.companyName;
                this.cpfCnpj = model.enterprise.cnpj;
                this.stateRegistration = model.enterprise.stateRegistration;
                break;
            default:
                break;
        }

        this.address = model.address;
    }

}

export class ReceiverUpdateCommand {

    public id: number;
    public type: number;
    public nameCompanyName: string;
    public cpfCnpj: string;
    public stateRegistration: string;
    public address: Address;

    constructor(receiver: ReceiverFormModel, id: number) {
        this.map(receiver, id);
    }

    private map(model: ReceiverFormModel, id: number): void {
        this.id = id;
        this.type = Number(model.type);
        this.address = model.address;

        switch (this.type.toString()) {
            case '1':
                this.nameCompanyName = model.individual.name;
                this.cpfCnpj = model.individual.cpf;
                break;
            case '2':
                this.nameCompanyName = model.enterprise.companyName;
                this.cpfCnpj = model.enterprise.cnpj;
                this.stateRegistration = model.enterprise.stateRegistration;
                break;
            default:
                break;
        }
    }

}

export class ReceiverIndividualFormModel {
    public name: string;
    public cpf: string;
}

export class ReceiverEnterpriseFormModel {
    public companyName: string;
    public cnpj: string;
    public stateRegistration: string;
}

export class ReceiverFormModel {
    public type: string;
    public individual: ReceiverIndividualFormModel;
    public enterprise: ReceiverEnterpriseFormModel;
    public address: Address;

    constructor(receiver: Receiver) {

        this.type = receiver.type.toString();
        this.address = receiver.address;

        switch (this.type.toString()) {
            case '1':
                this.individual = new ReceiverIndividualFormModel();
                this.individual.name = receiver.nameCompanyName;
                this.individual.cpf = receiver.cpfCnpj;
                break;
            case '2':
                this.enterprise = new ReceiverEnterpriseFormModel();
                this.enterprise.companyName = receiver.nameCompanyName;
                this.enterprise.cnpj = receiver.cpfCnpj;
                this.enterprise.stateRegistration = receiver.stateRegistration;
                break;
            default:
                break;
        }
    }

}
