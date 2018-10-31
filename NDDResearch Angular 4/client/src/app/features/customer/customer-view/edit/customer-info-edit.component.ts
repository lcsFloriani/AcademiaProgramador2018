import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Subject } from 'rxjs/Subject';
import { Observable } from 'rxjs/Observable';
import { ReactiveFormFeature } from 'ndd-ng-form';

import { CustomerService } from '../../shared/customer.service';
import { Customer } from '../../shared/model/customer.model';
import { CustomerResolveService } from '../../shared/customer-resolve.service';

@Component({
    templateUrl: './customer-info-edit.component.html',
})
export class CustomerInfoEditComponent extends ReactiveFormFeature implements OnDestroy, OnInit {
    public customer: Customer;
    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(
        private customerResolverService: CustomerResolveService,
        private customerService: CustomerService,
        route: ActivatedRoute,
        router: Router,
    ) {
        super(router, route);
    }

    public ngOnInit(): void {
        this.isLoading = true;
        this.parentRoute = `../`;
        super.onInit();
        this.customerResolverService.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((customer: Customer) => {
                this.isLoading = false;
                this.customer = customer;
                // Populando o form
                this.form.patchValue({
                    displayName: this.customer.displayName,
                    phone: this.customer.phone,
                    nationalIdNumber: this.customer.nationalIdNumber,
                    webSite: this.customer.webSite,
                    address: {
                        country: this.customer.address.country,
                        state: this.customer.address.state,
                        city: this.customer.address.city,
                        postalCode: this.customer.address.postalCode,
                        street: this.customer.address.street,
                        additionalInfo: this.customer.address.additionalInfo,
                    },
                });
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public onSubmit(): void {
        if (this.validate()) {
            this.updateCustomer()
                .take(1)
                .subscribe(() => {
                    this.customerResolverService.resolveFromRouteAndNotify();
                    this.goToBackRoute();
                });
        }
    }

    protected initForm(): void {
        this.form = new FormGroup({
            displayName: new FormControl('', Validators.required),
            phone: new FormControl('', [Validators.required, Validators.pattern(/^[ 0-9\+\-\(\)]*$/)]),
            nationalIdNumber: new FormControl(''),
            webSite: new FormControl(''),
            address: new FormGroup({
                country: new FormControl('', Validators.required),
                state: new FormControl('', Validators.required),
                city: new FormControl('', Validators.required),
                postalCode: new FormControl('', Validators.required),
                street: new FormControl('', Validators.required),
                additionalInfo: new FormControl(''),
            }),
        });
    }
    private updateCustomer(): Observable<any> {
        this.isLoading = true;

        const customerUpdateCommand: Customer = this.form.value;

        customerUpdateCommand.id = this.customer.id;
        customerUpdateCommand.address.id = this.customer.address.id;

        return this.customerService
            .update(customerUpdateCommand)
            .map((response: any) => {
                try {
                    return response;
                } finally {
                    this.isLoading = false;
                }
            });
    }
}
