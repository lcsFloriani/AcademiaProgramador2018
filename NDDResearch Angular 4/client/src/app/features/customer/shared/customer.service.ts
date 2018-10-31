import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { NDDGridService } from 'ndd-ng-grid';

import { CORE_CONFIG_TOKEN, ICoreConfig } from '../../../core/core.config';
import { Customer, CustomerDeleteCommand } from './model/customer.model';
import { Site } from '../../site/shared/model/site.model';
import { BaseService } from './../../../core/utils/services/base-service';

@Injectable()
export class CustomerGridService extends NDDGridService {
    constructor(httpClient: HttpClient, @Inject(CORE_CONFIG_TOKEN) config: ICoreConfig) {
        super(httpClient, `${ config.apiEndpoint }api/customers`);
    }
}

@Injectable()
export class CustomerService extends BaseService{
    private api: string;

    constructor(@Inject(CORE_CONFIG_TOKEN) config: ICoreConfig, public http: HttpClient) {
        super(http);
        this.api = `${ config.apiEndpoint }api/customers`;
    }

    public getAll(): Observable<any> {
        return this.http.get(`${ this.api }`).map((response: any) => response);
    }

    public get(id: number): Observable<Customer> {
        return this.http.get(`${ this.api }/${ id }`).map((response: Customer) => response);
    }

    public getSites(customerId: number): Observable<Site[]> {
        return this.http.get(`${ this.api }/${ customerId }/sites`).map((response: any) => response);
    }

    public create(customerCreateCommand: Customer): Observable<number> {
        return this.http.post(`${ this.api }`, customerCreateCommand).map((response: number) => response);
    }

    public update(customerUpdateCommand: Customer): Observable<boolean> {
        return this.http.put(`${ this.api }`, customerUpdateCommand).map((response: boolean) => response);
    }

    public delete(deviceRemoveCommand: CustomerDeleteCommand): Observable<boolean> {
        return this.deleteRequestWithBody(`${ this.api }`, deviceRemoveCommand).map((response: boolean) => response);
    }
}
