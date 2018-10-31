import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { State, toODataString } from '@progress/kendo-data-query';

import { ICoreConfig, CORE_CONFIG_TOKEN } from '../../../../core/core.config';
import { BaseService } from '../../../../core/utils';
import { AbstractResolveService } from '../../../../core/utils/abstract-resolve.service';
import { NDDBreadcrumbService } from '../../../../shared/ndd-ng-breadcrumb';
import { Conveyor, ConveyorDeleteCommand, ConveyorUpdateCommand, ConveyorRegisterCommand } from '../conveyor.model';

@Injectable()
export class ConveyorGridService extends BehaviorSubject<GridDataResult>{
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
            .get(`${this.config.apiEndpoint}api/conveyors?${queryStr}`)
            .map((response: any) => (<GridDataResult>{
                data: response.items,
                total: parseInt(response.count, 10),
            }))
            .do(() => this.loading = false);
    }
}

@Injectable()
export class ConveyorService extends BaseService {
    private api: string;

    constructor(public httpCliente: HttpClient,
        @Inject(CORE_CONFIG_TOKEN) private config: ICoreConfig) {
        super(httpCliente);
        this.api = `${this.config.apiEndpoint}api/conveyors`;
    }
    public post(conveyor: ConveyorRegisterCommand): Observable<boolean> {
        return this.http.post(this.api, conveyor).map((response: boolean) => response);
    }

    public put(conveyor: ConveyorUpdateCommand): Observable<boolean> {
        return this.http.put(this.api, conveyor).map((response: boolean) => response);
    }

    public get(id: number): Observable<Conveyor> {
        return this.http.get(`${this.api}/${id}`).map((response: Conveyor) => response);
    }

    public delete(conveyorDeleteCommand: ConveyorDeleteCommand): Observable<boolean> {
        return this.deleteRequestWithBody(this.api, conveyorDeleteCommand);
    }
}

@Injectable()
export class ConveyorResolveService extends AbstractResolveService<Conveyor> {

    constructor(private conveyorService: ConveyorService,
        private breadcrumbService: NDDBreadcrumbService, router: Router) {
        super(router);
        this.paramsProperty = 'conveyorId';
    }

    protected loadEntity(conveyorId: number): Observable<Conveyor> {
        return this.conveyorService
            .get(conveyorId)
            .take(1)
            .do((conveyor: Conveyor) => {
                this.breadcrumbService.setMetadata({
                    id: 'conveyor',
                    label: conveyor.nameCompanyName,
                    sizeLimit: true,
                });
            });
    }
}
@Injectable()
export class ConveyorSharedService extends BehaviorSubject<any> {
    private api: string;

    constructor(@Inject(CORE_CONFIG_TOKEN) config: ICoreConfig,
                private http: HttpClient) {
        super(null);
        this.api = `${config.apiEndpoint}api/conveyors`;
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
