import { AddressRegisterCommand, Address } from '../../address/address.model';

export class Emitter {
    public id: number;
    public fantasyName: string;
    public companyName: string;
    public cnpj: string;
    public stateRegistration: string;
    public municipalRegistration: string;
    public address: Address;
}

export class EmitterRegisterCommand {
    public fantasyName: string;
    public companyName: string;
    public cnpj: string;
    public stateRegistration: string;
    public municipalRegistration: string;
    public address: AddressRegisterCommand;

    constructor(emitter: Emitter) {
        this.fantasyName = emitter.fantasyName;
        this.companyName = emitter.companyName;
        this.cnpj = emitter.cnpj;
        this.stateRegistration = emitter.stateRegistration;
        this.municipalRegistration = emitter.municipalRegistration;
        this.address = new AddressRegisterCommand(emitter.address);
    }
}

export class EmitterUpdateCommand {
    public id: number;
    public fantasyName: string;
    public companyName: string;
    public cnpj: string;
    public stateRegistration: string;
    public municipalRegistration: string;
    public address: AddressRegisterCommand;

    constructor(emitter: Emitter) {
        this.id = emitter.id;
        this.fantasyName = emitter.fantasyName;
        this.companyName = emitter.companyName;
        this.cnpj = emitter.cnpj;
        this.stateRegistration = emitter.stateRegistration;
        this.municipalRegistration = emitter.municipalRegistration;
        this.address = new AddressRegisterCommand(emitter.address);
    }
}

export class EmitterDeleteCommand {
    public emitterIds: number[] = [];
    constructor(emitters: Emitter[]) {
        this.emitterIds = emitters.map((e: Emitter) => e.id);
    }
}
