import { Product } from '../../product/shared/product.model';

export class ItemInvoice {
    public id: number;
    public quantity: number;
    // Public invoiceProcess: InvoiceInProcess;
    public product: Product;

    public static calcTotal(unitaryValue: number, quantity: number): number {
        const total: number = unitaryValue * quantity;

        return total;
    }
}
export class ItemInvoiceRegisterCommand {
    public invoiceId: number;
    public itemInvoice: number;
    public quantity: number;
    constructor(invoiceId: number, itemInvoice: ItemInvoice) {
        this.invoiceId = invoiceId;
        this.itemInvoice = itemInvoice.product.id;
        this.quantity = itemInvoice.quantity;
    }
}
export class ItemInvoiceDeleteCommand {
    public invoiceId: number;
    public itemsInvoiceId: number[] = [];
    constructor(invoiceId: number, itemInvoice: ItemInvoice[]) {
        this.invoiceId = invoiceId;
        for (const item of itemInvoice) {
            this.itemsInvoiceId.push(item.id);
        }
    }
}
