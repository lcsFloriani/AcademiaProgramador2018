export class Product {
    public id?: number;
    public code: string = '';
    public description: string = '';
    public unitaryValue: number;
    public readonly aliquotICMS: number = 0.04;
    public readonly aliquotIPI: number = 0.10;
}
export class ProductDeleteCommand {
    public ids: number[] = [];

    constructor(products: Product[]) {
        this.ids = products.map((c: Product) => c.id);
    }
}
export class ProductRegisterCommand {
    public code: string = '';
    public description: string = '';
    public unitaryValue: number;
}

export class ProductUpdateCommand {
    public id: number;
    public code: string = '';
    public description: string = '';
    public unitaryValue: number;
}
