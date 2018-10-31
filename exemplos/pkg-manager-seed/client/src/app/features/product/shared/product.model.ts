export class Product {
    public id: number;
    public name: string;
    public sale: number;
    public expense: number;
    public isAvailable: boolean;
    public manufacture: Date;
    public expiration: Date;

    get calcResult(): number {
        return this.sale - this.expense;
    }
    get calcDate(): number {
        const segundosEmUmaHora: number = 3600;
        const umDiaEmHoras: number = 24;
        const umSegundoEmMilisegundos: number = 1000;
        const timeSpan: number = new Date(this.expiration).getTime() - new Date(this.manufacture).getTime();

        return Math.ceil(timeSpan / (umSegundoEmMilisegundos * segundosEmUmaHora * umDiaEmHoras));
    }
}
export class ProductDeleteCommand {
    public productIds: number[] = [];

    constructor(products: Product[]) {
        this.productIds = products.map((c: Product) => c.id);
    }
}
export class ProductRegisterCommand {
    public name: string;
    public sale: number;
    public expense: number;
    public isAvailable: boolean;
    public manufacture: Date;
    public expiration: Date;
    constructor(product: Product) {
        this.name = product.name;
        this.sale = product.sale;
        this.expense = product.expense;
        this.isAvailable = product.isAvailable;
        this.manufacture = new Date(product.manufacture.toString());
        this.expiration = new Date(product.expiration.toString());
    }
}

export class ProductEditCommand {
    public id: number;
    public name: string;
    public sale: number;
    public expense: number;
    public isAvailable: boolean;
    public manufacture: Date;
    public expiration: Date;
    constructor(product: Product) {
        this.id = product.id;
        this.name = product.name;
        this.sale = product.sale;
        this.expense = product.expense;
        this.isAvailable = product.isAvailable;
        this.manufacture = new Date(product.manufacture.toString());
        this.expiration = new Date(product.expiration.toString());
    }
}
