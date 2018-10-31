import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { AbstractResolveService } from 'ndd-ng-route';

import { CustomerService } from './customer.service';
import { Customer } from './model/customer.model';
import { NDDBreadcrumbService } from 'ndd-ng-breadcrumb';

@Injectable()
export class CustomerResolveService extends AbstractResolveService<Customer>{

    constructor(private customerService: CustomerService,
        private breadcrumbService: NDDBreadcrumbService,
        router: Router) {
        super(router);
        this.paramsProperty = 'customerId';
    }

    protected loadEntity(customerId: number): Observable<Customer> {
        return this.customerService
            .get(customerId)
            .take(1)
            .do((customer: Customer) => {
                this.breadcrumbService.setMetadata({
                    id: 'customer',
                    label: customer.displayName,
                    sizeLimit: true,
                });
            });
    }
}
