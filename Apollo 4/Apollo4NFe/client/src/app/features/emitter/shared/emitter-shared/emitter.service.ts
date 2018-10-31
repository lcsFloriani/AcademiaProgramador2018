import { Injectable, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { State, toODataString } from '@progress/kendo-data-query';

import { BaseService } from '../../../../core/utils';
import { Emitter, EmitterRegisterCommand } from '../emitter.model';
import { NDDBreadcrumbService } from '../../../../shared/ndd-ng-breadcrumb';
import { ICoreConfig, CORE_CONFIG_TOKEN } from '../../../../core/core.config';
import { EmitterDeleteCommand, EmitterUpdateCommand } from './../emitter.model';
import { AbstractResolveService } from '../../../../core/utils/abstract-resolve.service';
@Injectable()
export class EmitterGridService extends BehaviorSubject<GridDataResult>{
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
            .get(`${this.config.apiEndpoint}api/emitters?${queryStr}`)
            .map((response: any) => (<GridDataResult>{
                data: response.items,
                total: parseInt(response.count, 10),
            }))
            .do(() => this.loading = false);
    }
}
@Injectable()
export class EmitterService extends BaseService {
    private api: string;

    constructor(public httpCliente: HttpClient,
        @Inject(CORE_CONFIG_TOKEN) private config: ICoreConfig) {
        super(httpCliente);
        this.api = `${this.config.apiEndpoint}api/emitters`;
    }
    public post(emitter: EmitterRegisterCommand): Observable<boolean> {
        return this.http.post(this.api, emitter).map((response: boolean) => response);
    }

    public put(emitter: EmitterUpdateCommand): Observable<boolean> {
        return this.http.put(this.api, emitter).map((response: boolean) => response);
    }

    public get(id: number): Observable<Emitter> {
        return this.http.get(`${this.api}/${id}`).map((response: Emitter) => response);
    }

    public delete(emitterDeleteCommand: EmitterDeleteCommand): Observable<boolean> {
        return this.deleteRequestWithBody(this.api, emitterDeleteCommand);
    }
}

@Injectable()
export class EmitterResolveService extends AbstractResolveService<Emitter> {

    constructor(private emitterService: EmitterService,
        private breadcrumbService: NDDBreadcrumbService, router: Router) {
        super(router);
        this.paramsProperty = 'emitterId';
    }

    protected loadEntity(emitterId: number): Observable<Emitter> {
        return this.emitterService
            .get(emitterId)
            .take(1)
            .do((emitter: Emitter) => {
                this.breadcrumbService.setMetadata({
                    id: 'emitter',
                    label: emitter.companyName,
                    sizeLimit: true,
                });
            });
    }
}
@Injectable()
export class EmitterSharedService extends BehaviorSubject<any> {
    private api: string;

    constructor(@Inject(CORE_CONFIG_TOKEN) config: ICoreConfig,
                private http: HttpClient) {
        super(null);
        this.api = `${config.apiEndpoint}api/emitters`;
    }

    public query(filterValue: string): void {
        return this.fetch(filterValue)
            .subscribe((x: any) => super.next(x));
    }

    public clean(): void {
        return super.next([]);
    }

    private fetch(filterValue: string): any {
        const queryStr: string = `$skip=0&$count=true&$filter=contains(tolower(FantasyName), tolower('${filterValue}'))`;

        return this.http
            .get(`${this.api}?${queryStr}`)
            .map((response: any) => response.items);
    }
}
