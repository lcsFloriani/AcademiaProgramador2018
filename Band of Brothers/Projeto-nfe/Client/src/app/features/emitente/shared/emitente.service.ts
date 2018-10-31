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
import { Emitente, EmitenteDeleteCommand, EmitenteRegisterCommand, EmitenteEditCommand } from './emitente.model';
import { NDDBreadcrumbService } from '../../../shared/ndd-ng-breadcrumb';

@Injectable()
export class EmitenteGridService extends BehaviorSubject<GridDataResult> {

    public loading: boolean;
    private api: string;

    constructor(
        @Inject(CORE_CONFIG_TOKEN) config: ICoreConfig,
        private http: HttpClient,
    ) {
        super(null);
        this.api = `${config.apiEndpoint}api/emitentes`;
    }

    public query(state: any): void {
        this.fetch(state)
            .subscribe((x: any) => super.next(x));
    }

    protected fetch(state: any): Observable<GridDataResult> {
        const queryStr: any = `${toODataString(state)}&$count=true`;
        this.loading = true;

        return this.http
            .get(`${this.api}?${queryStr}`)
            .map((response: any) => (<GridDataResult>{
                data: response.items,
                total: parseInt(response.count, 10),
            }))
            .do(() => this.loading = false);
    }
}

@Injectable()
export class EmitenteService extends BaseService {
    private api: string;

    constructor(@Inject(CORE_CONFIG_TOKEN) config: ICoreConfig,
        public http: HttpClient) {
        super(http);
        this.api = `${config.apiEndpoint}api/emitentes`;
    }

    public post(emitente: EmitenteRegisterCommand): Observable<boolean> {
        return this.http.post(this.api, emitente).map((response: boolean) => response);
    }

    public put(emitente: EmitenteEditCommand): Observable<boolean> {
        return this.http.put(this.api, emitente).map((response: boolean) => response);
    }

    public get(id: number): Observable<Emitente> {
        return this.http.get(`${this.api}/${id}`).map((response: Emitente) => response);
    }

    public delete(emitenteDeleteCommand: EmitenteDeleteCommand): Observable<boolean> {
        return this.deleteRequestWithBody(this.api, emitenteDeleteCommand);
    }

}

@Injectable()
export class EmitenteResolveService extends AbstractResolveService<Emitente>{
    constructor(private service: EmitenteService,
        router: Router,
        private breadcrumbService: NDDBreadcrumbService) {
        super(router);
        this.paramsProperty = 'emitenteId';
    }

    protected loadEntity(emitenteId: number): Observable<Emitente> {
        return this.service
            .get(emitenteId)
            .take(1)
            .do((emitente: Emitente) => {
                this.breadcrumbService.setMetadata({
                    id: 'emitente',
                    label: emitente.nome,
                    sizeLimit: true,
                });
            });
    }
}

@Injectable()
export class EmitenteSharedService extends BehaviorSubject<any> {
    private api: string;

    constructor(@Inject(CORE_CONFIG_TOKEN) config: ICoreConfig,
                private http: HttpClient) {
        super(null);
        this.api = `${config.apiEndpoint}api/emitentes`;
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
