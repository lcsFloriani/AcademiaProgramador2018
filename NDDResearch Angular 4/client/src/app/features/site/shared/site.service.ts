import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

import { NDDGridService } from 'ndd-ng-grid';
import { BaseService } from '../../../core/utils/services';

import { CORE_CONFIG_TOKEN, ICoreConfig } from '../../../core/core.config';

import { Site, SiteDeleteCommand } from './model/site.model';

@Injectable()
export class SiteGridService extends NDDGridService {
    constructor(httpClient: HttpClient, @Inject(CORE_CONFIG_TOKEN) private config: ICoreConfig) {
        super(httpClient, `${ config.apiEndpoint }`);
    }

    public setUrlParam(customerId: string): void {
        this.url = `${ this.config.apiEndpoint }api/customers/${ customerId }/sites`;
    }
}

@Injectable()
export class SiteService extends BaseService {
    private api: string;

    constructor(@Inject(CORE_CONFIG_TOKEN) config: ICoreConfig, http: HttpClient) {
        super(http);
        this.api = `${ config.apiEndpoint }api/sites`;
    }

    public getAll(): Observable<any> {
        return this.http.get(`${ this.api }`).map((response: any) => response);
    }

    public get(id: number): Observable<Site> {
        return this.http.get(`${ this.api }/${ id }`).map((response: Site) => response);
    }

    public create(command: Site): Observable<number> {
        return this.http.post(`${ this.api }`, command).map((response: number) => response);
    }

    public update(command: Site): Observable<boolean> {
        return this.http.put(`${ this.api }/${ command.id }`, command).map((response: boolean) => response);
    }

    public delete(command: SiteDeleteCommand): Observable<boolean> {
        return this.deleteRequestWithBody(`${ this.api }`, command);
    }
}
