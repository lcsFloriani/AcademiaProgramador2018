import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Subject } from 'rxjs/Subject';

import { Customer } from '../../shared/model/customer.model';
import { CustomerResolveService } from '../../shared/customer-resolve.service';

@Component({
    templateUrl: './customer-info-detail.component.html',
})

export class CustomerInfoDetailComponent implements OnInit, OnDestroy {

    public isLoading: boolean;
    public customer: Customer;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(
        private router: Router,
        private customerResolverService: CustomerResolveService,
    ) { }

    public ngOnInit(): void {
        this.isLoading = true;
        this.customerResolverService
            .onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((response: Customer) => {
                this.isLoading = false;
                this.customer = response;
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public onEdit(): void {
        this.router.navigate([this.router.url + `/edit`], { skipLocationChange: true });
    }
}
