import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { toODataString } from '@progress/kendo-data-query';

import { BaseService } from '../../../core/utils';
import { CORE_CONFIG_TOKEN, ICoreConfig } from '../../../core/core.config';
import { OrderDeleteCommand, Order, OrderRegisterCommand, OrderEditCommand } from './order-model';
import { AbstractResolveService } from '../../../core/utils/abstract-resolve.service';
import { Router } from '@angular/router';
import { NDDBreadcrumbService } from '../../../shared/ndd-ng-breadcrumb';

@Injectable()
export class OrderGridService extends BehaviorSubject<GridDataResult> {

    public loading: boolean;
    private BASE_URL: string = 'http://localhost:9005/api/orders';
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
export class OrderService extends BaseService {
    private api: string;
    constructor(@Inject(CORE_CONFIG_TOKEN) config: ICoreConfig,
        public http: HttpClient) {
        super(http);
        this.api = `${config.apiEndpoint}api/orders`;
    }
    public post(order: OrderRegisterCommand): Observable<boolean> {
        return this.http.post(this.api, order).map((response: boolean) => response);
    }
    public get(id: number): Observable<Order> {
        return this.http.get(`${this.api}/${id}`).map((response: Order) => response);
    }
    public delete(orderDeleteCommand: OrderDeleteCommand): Observable<boolean> {
        return this.deleteRequestWithBody(this.api, orderDeleteCommand);
    }
    public put(orderEditCommand: OrderEditCommand): Observable<boolean> {
        return this.http.put(this.api, orderEditCommand).map((response: boolean) => response);
    }
}

@Injectable()
export class OrderResolveService extends AbstractResolveService<Order>{

    constructor(private service: OrderService,
        router: Router,
        private breadcrumbService: NDDBreadcrumbService) {
        super(router);
        this.paramsProperty = 'orderId';
    }

    protected loadEntity(orderId: number): Observable<Order> {
        return this.service
            .get(orderId)
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
