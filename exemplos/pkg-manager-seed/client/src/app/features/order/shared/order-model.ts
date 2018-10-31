import { Product } from '../../product/shared/product.model';

export class Order {
    public id: number;
    public customer: string;
    public quantity: number;
    public productId: number;
    public product: Product;
    public productName: string;
    public total: number;
}
export class OrderRegisterCommand {
    public customer: string;
    public quantity: number;
    public productId: number;
    public product: Product;
    public total: number;
    constructor(order: Order) {
        this.customer = order.customer;
        this.quantity = order.quantity;
    }
    public SetProduct(product: Product): void {
        this.productId = product.id;
    }
}
export class OrderDeleteCommand {
    public orderIds: number[] = [];

    constructor(orders: Order[]) {
        this.orderIds = orders.map((c: Order) => c.id);
    }
}
export class OrderEditCommand {
    public id: number;
    public customer: string;
    public quantity: number;
    public productId: number;
    public productName: string;
    public total: number;
    constructor(order: Order) {
        this.id = order.id;
        this.customer = order.customer;
        this.quantity = order.quantity;
        this.productId = order.productId;
        this.productName = order.productName;
    }
    public SetProduct(product: Product): void {
        this.productId = product.id;
    }
}
