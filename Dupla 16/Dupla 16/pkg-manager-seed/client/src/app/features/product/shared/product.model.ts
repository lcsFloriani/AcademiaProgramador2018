export class Product {
    public id: number;
    public name: string;
    public sale: number;
    public expense: number;
    public isAvailable: boolean;
    public manufacture: Date;
    public expiration: Date;

    public calculateDate(): number {
        const mili: number = 1000;
        const min: number = 60;
        const hours: number = 60;
        const day: number = 24;
        const date: number = this.expiration.getTime() - this.manufacture.getTime();
        const expirationDays: number = Math.round(Math.ceil(date / (mili * min * hours * day)));

        return expirationDays;
    }

    public calculateSale(): number {
        const result: number = this.sale - this.expense;

        return result;
    }
}

export class ProductRemoveCommand {
    public productIds: number[];
}

export class ProductRegisterCommand {

    public name: string;
    public sale: number;
    public expense: number;
    public isAvailable: boolean;
    public manufacture: string;
    public expiration: string;

    constructor(product: Product) {
        this.name = product.name;
        this.sale = product.sale;
        this.expense = product.expense;
        this.expiration = new Date(product.expiration).toISOString();
        this.manufacture = new Date(product.manufacture).toISOString();
        this.isAvailable = product.isAvailable;
    }
}

export class ProductUpdateCommand {

    public id: number;
    public name: string;
    public sale: number;
    public expense: number;
    public isAvailable: boolean;
    public manufacture: string;
    public expiration: string;

    constructor(product: Product) {
        this.id = product.id,
        this.name = product.name;
        this.sale = product.sale;
        this.expense = product.expense;
        this.expiration = new Date(product.expiration).toISOString();
        this.manufacture = new Date(product.manufacture).toISOString();
        this.isAvailable = product.isAvailable;
    }
}
