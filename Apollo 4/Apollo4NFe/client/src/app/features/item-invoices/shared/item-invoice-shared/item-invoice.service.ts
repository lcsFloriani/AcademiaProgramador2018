import { ItemInvoiceDeleteCommand } from './../item-invoice.model';
import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { State, toODataString } from '@progress/kendo-data-query';

import { ICoreConfig, CORE_CONFIG_TOKEN } from '../../../../core/core.config';
import { BaseService } from '../../../../core/utils';
import { ItemInvoiceRegisterCommand } from '../item-invoice.model';

@Injectable()
export class ItemInvoiceGridService extends BehaviorSubject<GridDataResult>{
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
            .get(`${this.config.apiEndpoint}api/ItemInvoice?${queryStr}`)
            .map((response: any) => (<GridDataResult>{
                data: response.items,
                total: parseInt(response.count, 10),
            }))
            .do(() => this.loading = false);
    }
}

@Injectable()
export class ItemInvoiceService extends BaseService {
    private api: string;

    constructor(public httpCliente: HttpClient,
        @Inject(CORE_CONFIG_TOKEN) private config: ICoreConfig) {
        super(httpCliente);
        this.api = `${this.config.apiEndpoint}api/ItemInvoice`;
    }
    public post(command: ItemInvoiceRegisterCommand): Observable<boolean> {
        return this.http.post(this.api, command).map((response: boolean) => response);
    }
    public delete(command: ItemInvoiceDeleteCommand): Observable<boolean> {
        return this.deleteRequestWithBody(this.api, command);
    }
}
@Injectable()
export class ProductDropdownService extends BehaviorSubject<any> {
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
        const queryStr: string = `$skip=0&$count=true&$filter=contains(tolower(description), tolower('${filterValue}'))`;

        return this.http
            .get(`${this.api}?${queryStr}`)
            .map((response: any) => response.items);
    }
}
