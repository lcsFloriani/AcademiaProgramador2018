import { Injectable, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { State, toODataString } from '@progress/kendo-data-query';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

import { BaseService } from '../../../core/utils';
import { NDDBreadcrumbService } from '../../../shared/ndd-ng-breadcrumb';
import { ICoreConfig, CORE_CONFIG_TOKEN } from '../../../core/core.config';
import { AbstractResolveService } from '../../../core/utils/abstract-resolve.service';
import { Invoice, InvoiceDeleteCommand, InvoiceRegisterCommand, InvoiceUpdateCommand } from './invoice.model';

@Injectable()
export class InvoiceGridService extends BehaviorSubject<GridDataResult> {
    public loading: boolean;

    constructor(private httpCliente: HttpClient,
        @Inject(CORE_CONFIG_TOKEN) private config: ICoreConfig) {
        super(null);
    }
    public query(state: State): void {
        this.fetch(state).subscribe((result: GridDataResult) => super.next(result));
    }
    protected fetch(state: any): Observable<GridDataResult> {
        const queryStr: string = `${toODataString(state)}&$count=true`;
        this.loading = true;

        return this.httpCliente
            .get(`${this.config.apiEndpoint}api/invoices?${queryStr}`)
            .map((response: any) => (<GridDataResult>{
                data: response.items,
                total: parseInt(response.count, 10),
            }))
            .do(() => this.loading = false);
    }
}

@Injectable()
export class InvoiceService extends BaseService {
    private api: string;

    constructor(public httpCliente: HttpClient,
        @Inject(CORE_CONFIG_TOKEN) private config: ICoreConfig) {
        super(httpCliente);
        this.api = `${this.config.apiEndpoint}api/invoices`;
    }

    public post(command: InvoiceRegisterCommand): Observable<boolean> {
        return this.http.post(this.api, command).map((response: boolean) => response);
    }

    public put(command: InvoiceUpdateCommand): Observable<boolean> {
        return this.http.put(this.api, command).map((response: boolean) => response);
    }

    public get(id: number): Observable<Invoice> {
        return this.http.get(`${this.api}/${id}`).map((response: Invoice) => response);
    }

    public delete(command: InvoiceDeleteCommand): Observable<boolean> {
        return this.deleteRequestWithBody(`${this.api}`, command);
    }
}
@Injectable()
export class InvoiceResolveService extends AbstractResolveService<Invoice> {

    constructor(private service: InvoiceService,
        private breadcrumbService: NDDBreadcrumbService,
        router: Router) {
        super(router);
        this.paramsProperty = 'invoiceId';
    }
    protected loadEntity(productId: number): Observable<Invoice> {
        return this.service
            .get(productId)
            .take(1)
            .do((invoice: Invoice) => {
                this.breadcrumbService.setMetadata({
                    id: 'InvoiceProcessing',
                    label: invoice.natureOperation,
                    sizeLimit: true,
                });
            });
    }
}
