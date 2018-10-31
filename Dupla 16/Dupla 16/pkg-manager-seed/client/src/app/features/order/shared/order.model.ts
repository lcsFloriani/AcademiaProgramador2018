import { Product } from '../../product/shared/product.model';

export class Order {
    public id: number;
    public customer: string;
    public quantity: number;
    public productName: Product;
    public productId: number;
    public total: number;

    public calculateTotal(): number {
        this.total = this.productName.sale * this.quantity;

        return this.total;
    }
}

export class OrderRemoveCommand {
    public orderIds: number[];
}

export class OrderRegisterCommand {
    public customer: string;
    public quantity: number;
    public productId: number;

    constructor(order: Order) {
        this.customer = order.customer;
        this.quantity = order.quantity;
        this.productId = order.productId;
    }
}
