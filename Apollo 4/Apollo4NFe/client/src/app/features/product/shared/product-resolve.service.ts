import { AbstractResolveService } from '../../../core/utils/abstract-resolve.service';
import { Injectable } from '@angular/core';
import { Product } from './product.model';
import { ProductService } from './product.service';
import { NDDBreadcrumbService } from '../../../shared/ndd-ng-breadcrumb';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ProductResolveService extends AbstractResolveService<Product> {

    constructor(private service: ProductService,
        private breadcrumbService: NDDBreadcrumbService,
        router: Router) {
        super(router);
        this.paramsProperty = 'productId';
    }
    protected loadEntity(productId: number): Observable<Product> {
        return this.service
            .get(productId)
            .take(1)
            .do((product: Product) => {
                this.breadcrumbService.setMetadata({
                    id: 'product',
                    label: product.code,
                    sizeLimit: true,
                });
            });
    }
}
