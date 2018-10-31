import { Receiver } from './../../receiver/shared/receiver.model';
import { Conveyor } from '../../conveyor/shared/conveyor.model';
import { Emitter } from '../../emitter/shared/emitter.model';
import { ItemInvoice } from '../../item-invoices/shared/item-invoice.model';

export class Invoice {
    public id: number;
    public entryDate: Date;
    public natureOperation: string;
    public valueFreight: number;
    public conveyor: Conveyor;
    public emitter: Emitter;
    public receiver: Receiver;
    public items: ItemInvoice[] = [];
}
export class InvoiceDeleteCommand {
    public invoiceIds: number[] = [];

    constructor(products: Invoice[]) {
        this.invoiceIds = products.map((c: Invoice) => c.id);
    }
}
export class InvoiceRegisterCommand {
    public entryDate: Date;
    public natureOperation: string;
    public valueFreight: number;
    public conveyorId: number;
    public emitterId: number;
    public receiverId: number;
    constructor(invoice: Invoice) {
        this.entryDate = invoice.entryDate;
        this.natureOperation = invoice.natureOperation;
        this.valueFreight = invoice.valueFreight;
    }
    public SetEmitter(emitter: Emitter): void {
        this.emitterId = emitter.id;
    }
    public SetConveyor(conveyor: Conveyor): void {
        this.conveyorId = conveyor.id;
    }
    public SetReceiver(receiver: Receiver): void {
        this.receiverId = receiver.id;
    }
}

export class InvoiceUpdateCommand {
    public id: number;
    public entryDate: Date;
    public natureOperation: string;
    public valueFreight: number;
    public conveyorId: number;
    public emitterId: number;
    public receiverId: number;

    constructor(id: number, invoice: Invoice, emitter: Emitter, conveyor: Conveyor, receiver: Receiver) {
        this.map(id, invoice, emitter, conveyor, receiver);
    }

    private map(id: number, invoice: Invoice, emitter: Emitter, conveyor: Conveyor, receiver: Receiver): void {
        this.id = id;
        this.entryDate = invoice.entryDate;
        this.natureOperation = invoice.natureOperation;
        this.valueFreight = invoice.valueFreight;
        this.emitterId = emitter.id;
        this.conveyorId = conveyor.id;
        this.receiverId = receiver.id;
    }
}

export class InvoiceFormModel {
    public entryDate: Date;
    public natureOperation: string;
    public valueFreight: number;
    public conveyor: string;
    public emitter: string;
    public receiver: string;

    constructor(invoice: Invoice) {
        this.map(invoice);
    }

    private map(invoice: Invoice): void {
        this.entryDate = invoice.entryDate;
        this.natureOperation = invoice.natureOperation;
        this.valueFreight = invoice.valueFreight;
        this.emitter = invoice.emitter.fantasyName;
        this.conveyor = invoice.conveyor.nameCompanyName;
        this.receiver = invoice.receiver.nameCompanyName;
    }

}
