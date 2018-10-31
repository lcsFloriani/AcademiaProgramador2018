import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { ReactiveFormFeature } from 'ndd-ng-form';

import { CustomerService } from '../shared/customer.service';
import { Customer } from '../shared/model/customer.model';

@Component({
    templateUrl: './customer-create.component.html',
})
export class CustomerCreateComponent extends ReactiveFormFeature implements OnInit {
    constructor(
        private customerService: CustomerService,
        route: ActivatedRoute,
        router: Router,
    ) {
        super(router, route);
        this.parentRoute = 'customers';
    }

    public ngOnInit(): void {
        this.onInit();
        this.parentRoute = '../';
    }

    public onSubmit(): void {
        if (this.validate()) {
            this.createCustomer()
                .take(1)
                .subscribe(this.successCallback(() => {
                    this.form.markAsPristine();
                    this.router.navigate([this.parentRoute], { relativeTo: this.route });
                }), this.errorCallback((errorCode: number) => this.error(errorCode)));
        }
    }

    public onSaveAndOpen(): void {
        if (this.validate()) {
            this.createCustomer()
                .take(1)
                .subscribe(this.successCallback(() => {
                    this.form.markAsPristine();
                    this.router.navigate([`${this.parentRoute}${this.objectId}`], { relativeTo: this.route });
                }), this.errorCallback((errorCode: number) => this.error(errorCode)));
        }
    }

    public onSaveAndCreate(): void {
        if (this.validate()) {
            this.createCustomer()
                .take(1)
                .subscribe(this.successCallback(() => {
                    this.form.reset();
                }), this.errorCallback((errorCode: number) => this.error(errorCode)));
        }
    }

    // Private Methods
    protected initForm(): void {
        this.form = new FormGroup({
            name: new FormControl('', Validators.required),
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

    private createCustomer(): Observable<number> {
        const customerCreateCommand: Customer = this.form.value;

        return this.customerService
            .create(customerCreateCommand)
            .map((response: number) => {
                try {
                    return response;
                } finally {
                    this.isLoading = false;
                }
            });
    }

    private error(errorCode: number): void {
        const errorCodeConflict: number = 409;

        if (errorCode === errorCodeConflict) {
            this.form.controls.name.setErrors({ conflict: true });
        }
    }
}
