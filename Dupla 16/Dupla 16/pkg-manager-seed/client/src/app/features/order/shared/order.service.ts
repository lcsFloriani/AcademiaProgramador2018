import { Injectable, Inject } from '@angular/core';
import { BaseService } from '../../../core/utils';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { HttpClient } from '@angular/common/http';
import { CORE_CONFIG_TOKEN, ICoreConfig } from '../../../core/core.config';
import { State, toODataString } from '@progress/kendo-data-query/dist/es/main';
import { Observable } from 'rxjs/Observable';
import { AbstractResolveService } from '../../../core/utils/abstract-resolve.service';
import { Router } from '@angular/router';
import { NDDBreadcrumbService } from '../../../shared/ndd-ng-breadcrumb';
import { Order, OrderRemoveCommand, OrderRegisterCommand } from './order.model';
import { map } from '@progress/kendo-data-query/dist/es/transducers';

@Injectable()

export class OrderGridService extends BehaviorSubject<GridDataResult>{
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
            .get(`${this.config.apiEndpoint}api/orders?${queryStr}`)
            .map((response: any): GridDataResult => ({
                data: response.items,
                total: parseInt(response.count, 10),
            })).do(() => this.loading = false);
    }
}

export class OrderService extends BaseService {

    private api: string;

    constructor(@Inject(CORE_CONFIG_TOKEN) config: ICoreConfig, public http: HttpClient) {
        super(http);
        this.api = `${config.apiEndpoint}api/orders`;
    }

    public get(id: number): Observable<Order> {
        return this.http.get(`${this.api}/${id}`).map((response: Order) => {
            return response;
        });
    }
    public deleteOrders(cmd: OrderRemoveCommand): Observable<boolean> {
        return this.deleteRequestWithBody(this.api, cmd);
    }

    public post(cmd: OrderRegisterCommand): Observable<number> {
        return this.http.post(this.api, cmd).map((response: number) => response);
    }
}

@Injectable()
export class OrderResolveService extends AbstractResolveService<Order> {

    constructor(private service: OrderService, router: Router, private breadcrumbService: NDDBreadcrumbService) {
        super(router);
        this.paramsProperty = 'orderId';
    }
    protected loadEntity(entityId: number): Observable<Order> {
        return this.service
            .get(entityId)
            .take(1)
            .do((order: Order) => {
                this.breadcrumbService.setMetadata({
                    id: 'order',
                    label: order.customer,
                    sizeLimit: true,
                });
            });
    }
}
