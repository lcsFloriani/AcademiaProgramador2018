import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import { NDDIntlService } from 'ndd-ng-intl';

import { Customer } from '../shared/model/customer.model';
import { CustomerResolveService } from '../shared/customer-resolve.service';

@Component({
    templateUrl: './customer-view.component.html',
})

export class CustomerViewComponent implements OnInit, OnDestroy {
    public customer: Customer;
    public infoItems: object[];
    public title: string;
    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(
        private customerResolverService: CustomerResolveService,
        private nddIntlService: NDDIntlService,
    ) { }

    public ngOnInit(): void {
        this.customerResolverService.onChanges
        .takeUntil(this.ngUnsubscribe)
        .subscribe((customer: Customer) => {
            this.customer = customer;
            this.createProperty();
        });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    private createProperty(): void {
        this.title = this.customer.displayName;
        this.infoItems = [
            {
                value: this.customer.name,
                description: 'NDDName',
            },
            {
                value: '-',
                description: 'NDDDealer',
            },
            {
                value: this.nddIntlService.formatDate(new Date(this.customer.creationDate), 'd'),
                description: 'NDDCreationDate',
            },
            {
                value: this.customer.key,
                description: 'NDDKey',
            },
        ];
    }
}
