import { OnInit, OnDestroy, Component } from '@angular/core';
import { Subject } from 'rxjs/Subject';

import { Product } from '../shared/product.model';
import { ProductResolveService } from '../shared/product.service';

@Component({
    templateUrl: './product-view.component.html',
})
export class ProductViewComponent implements OnInit, OnDestroy {
    public product: Product;
    public infoItems: object[];
    public title: string;
    private ngUnsubscribe: Subject<void> = new Subject<void>();
    constructor(private resolver: ProductResolveService) {
    }

    public ngOnInit(): void {
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((product: Product) => {
                this.product = product;
                this.createProperty();
            });
    }
    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }
    public createProperty(): void {
        this.title = this.product.description;
        const codeProduct: string =
            'Código: ' + this.product.code;
        this.infoItems = [
            {
                value: codeProduct,
                description: codeProduct,
            },
        ];
    }
}
