import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { toODataString } from '@progress/kendo-data-query';
import { Router } from '@angular/router';

import { CORE_CONFIG_TOKEN, ICoreConfig } from './../../../core/core.config';
import { BaseService } from './../../../core/utils/base-service';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { AbstractResolveService } from '../../../core/utils/abstract-resolve.service';
import { Product, ProductDeleteCommand, ProductRegisterCommand, ProductEditCommand } from './product.model';
import { NDDBreadcrumbService } from '../../../shared/ndd-ng-breadcrumb';

@Injectable()
export class ProductGridService extends BehaviorSubject<GridDataResult> {

    public loading: boolean;
    private BASE_URL: string = 'http://localhost:9005/api/products';
    constructor(
        private http: HttpClient,
    ) {
        super(null);
    }

    public query(state: any): void {
        this.fetch(state)
            .subscribe((x: any) => super.next(x));
    }

    protected fetch(state: any): Observable<GridDataResult> {
        const queryStr: any = `${toODataString(state)}&$count=true`;
        this.loading = true;

        return this.http
            .get(`${this.BASE_URL}?${queryStr}`)
            .map((response: any) => (<GridDataResult>{
                data: response.items,
                total: parseInt(response.count, 10),
            }))
            .do(() => this.loading = false);
    }
}

@Injectable()
export class ProductService extends BaseService {
    private api: string;

    constructor(@Inject(CORE_CONFIG_TOKEN) config: ICoreConfig,
        public http: HttpClient) {
        super(http);
        this.api = `${config.apiEndpoint}api/products`;
    }

    public post(product: ProductRegisterCommand): Observable<boolean> {
        return this.http.post(this.api, product).map((response: boolean) => response);
    }

    public put(product: ProductEditCommand): Observable<boolean> {
        return this.http.put(this.api, product).map((response: boolean) => response);
    }

    public get(id: number): Observable<Product> {
        return this.http.get(`${this.api}/${id}`).map((response: Product) => response);
    }

    public delete(productDeleteCommand: ProductDeleteCommand): Observable<boolean> {
        return this.deleteRequestWithBody(this.api, productDeleteCommand);
    }

}

@Injectable()
export class ProductResolveService extends AbstractResolveService<Product>{
    constructor(private service: ProductService,
        router: Router,
        private breadcrumbService: NDDBreadcrumbService) {
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
                    label: product.name,
                    sizeLimit: true,
                });
            });
    }
}

@Injectable()
export class ProductSharedService extends BehaviorSubject<any> {
    private api: string;

    constructor(@Inject(CORE_CONFIG_TOKEN) config: ICoreConfig,
                private http: HttpClient) {
        super(null);
        this.api = `${config.apiEndpoint}api/products`;
    }

    public query(filterValue: string): void {
        return this.fetch(filterValue)
            .subscribe((x: any) => super.next(x));
    }

    public clean(): void {
        return super.next([]);
    }

    private fetch(filterValue: string): any {
        const queryStr: string = `$skip=0&$count=true&$filter=contains(tolower(Name), tolower('${filterValue}'))`;

        return this.http
            .get(`${this.api}?${queryStr}`)
            .map((response: any) => response.items);
    }
}
