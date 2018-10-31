
import { BaseService } from './../../../core/utils/base-service';
import { Observable } from 'rxjs/Observable';
import { CORE_CONFIG_TOKEN, ICoreConfig } from './../../../core/core.config';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Injectable, Inject } from '@angular/core';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { State, toODataString } from '@progress/kendo-data-query/dist/es/main';
import { AbstractResolveService } from '../../../core/utils/abstract-resolve.service';
import { Product, ProductRemoveCommand, ProductRegisterCommand, ProductUpdateCommand } from './product.model';
import { Router } from '@angular/router';
import { NDDBreadcrumbService } from '../../../shared/ndd-ng-breadcrumb';

@Injectable()

export class ProductGridService extends BehaviorSubject<GridDataResult>{
    public loading: boolean;

    constructor(private httpClient: HttpClient, @Inject(CORE_CONFIG_TOKEN) private config: ICoreConfig) {
        super(null);
    }

    public query(state: State): void {
        this.fetch(state).subscribe((result: GridDataResult) => super.next(result));
    }

    protected fetch(state: any): Observable<GridDataResult> {
        const queryStr: string = `${toODataString(state)}&$count=true`;
        this.loading = true;

        return this.httpClient
            .get(`${this.config.apiEndpoint}api/products?${queryStr}`)
            .map((response: any): GridDataResult => ({
                data: response.items,
                total: parseInt(response.count, 10),
            })).do(() => this.loading = false);
    }
}

@Injectable()

export class ProductService extends BaseService {
    private api: string;

    constructor(@Inject(CORE_CONFIG_TOKEN) config: ICoreConfig, public http: HttpClient) {
        super(http);
        this.api = `${config.apiEndpoint}api/products`;
    }

    public get(id: number): Observable<Product> {
        return this.http.get(`${this.api}/${id}`).map((response: Product)=> {
            response.expiration = new Date(response.expiration);
            response.manufacture = new Date(response.manufacture);

            return response;
        });
    }

    public getByName(filterValue: string): Observable<Product[]> {
        const queryStr: string = `$skip=0&$count=true&$filter=contains(tolower(Name), tolower('${filterValue}'))`;

        return this.http
            .get(`${this.api}?${queryStr}`)
           .map((response: any) => response.items);
    }

    public post(cmd: ProductRegisterCommand): Observable<number> {
        return this.http.post(this.api, cmd).map((response: number)=> response);
    }

    public put(cmd: ProductUpdateCommand): Observable<number> {
        return this.http.put(this.api, cmd).map((response: number)=> response);
    }

    public deleteProducts(cmd: ProductRemoveCommand): Observable<boolean> {
        return this.deleteRequestWithBody(this.api, cmd);
    }
}

@Injectable()
export class ProductResolveService extends AbstractResolveService<Product> {

    constructor(private service: ProductService, router: Router, private breadcrumbService: NDDBreadcrumbService) {
        super(router);
        this.paramsProperty = 'productId';
    }
    protected loadEntity(entityId: number): Observable<Product> {
        return this.service
        .get(entityId)
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
