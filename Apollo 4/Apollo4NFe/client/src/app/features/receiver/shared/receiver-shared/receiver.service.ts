import { Router } from '@angular/router';
import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { State, toODataString } from '@progress/kendo-data-query';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';

import { BaseService } from '../../../../core/utils';
import { ICoreConfig } from '../../../../core/core.config';
import { CORE_CONFIG_TOKEN } from './../../../../core/core.config';
import { NDDBreadcrumbService } from '../../../../shared/ndd-ng-breadcrumb';
import { AbstractResolveService } from '../../../../core/utils/abstract-resolve.service';
import { Receiver, ReceiverDeleteCommand, ReceiverRegisterCommand, ReceiverUpdateCommand } from '../receiver.model';

@Injectable()
export class ReceiverGridService extends BehaviorSubject<GridDataResult>{
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
            .get(`${this.config.apiEndpoint}api/receivers?${queryStr}`)
            .map((response: any) => (<GridDataResult>{
                data: response.items,
                total: parseInt(response.count, 10),
            }))
            .do(() => this.loading = false);
    }
}

@Injectable()
export class ReceiverService extends BaseService {
    private api: string;

    constructor(public httpCliente: HttpClient,
        @Inject(CORE_CONFIG_TOKEN) private config: ICoreConfig) {
        super(httpCliente);
        this.api = `${this.config.apiEndpoint}api/receivers`;
    }

    public add(command: ReceiverRegisterCommand): Observable<number> {
        return this.http.post(this.api, command).map((response: number) => response);
    }

    public put(command: ReceiverUpdateCommand): Observable<boolean> {
        return this.http.put(this.api, command).map((response: boolean) => response);
    }

    public get(id: number): Observable<Receiver> {
        return this.http.get(`${this.api}/${id}`).map((response: Receiver) => response);
    }

    public remove(command: ReceiverDeleteCommand): Observable<boolean> {
        return this.deleteRequestWithBody(`${this.api}`, command);
    }
}

@Injectable()
export class ReceiverResolveService extends AbstractResolveService<Receiver> {

    constructor(private emitterService: ReceiverService,
        private breadcrumbService: NDDBreadcrumbService, router: Router) {
        super(router);
        this.paramsProperty = 'receiverId';
    }

    protected loadEntity(emitterId: number): Observable<Receiver> {
        return this.emitterService
            .get(emitterId)
            .take(1)
            .do((receiver: Receiver) => {
                this.breadcrumbService.setMetadata({
                    id: 'receiver',
                    label: receiver.nameCompanyName,
                    sizeLimit: true,
                });
            });
    }
}
@Injectable()
export class ReceiverSharedService extends BehaviorSubject<any> {
    private api: string;

    constructor(@Inject(CORE_CONFIG_TOKEN) config: ICoreConfig,
                private http: HttpClient) {
        super(null);
        this.api = `${config.apiEndpoint}api/receivers`;
    }

    public query(filterValue: string): void {
        return this.fetch(filterValue)
            .subscribe((x: any) => super.next(x));
    }

    public clean(): void {
        return super.next([]);
    }

    private fetch(filterValue: string): any {
        const queryStr: string = `$skip=0&$count=true&$filter=contains(tolower(NameCompanyName), tolower('${filterValue}'))`;

        return this.http
            .get(`${this.api}?${queryStr}`)
            .map((response: any) => response.items);
    }
}
