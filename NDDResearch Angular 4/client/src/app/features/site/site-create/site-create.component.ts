import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Observable } from 'rxjs/Observable';

import { ReactiveFormFeature } from 'ndd-ng-form';

import { SiteService } from '../shared/site.service';
import { Site } from '../shared/model/site.model';

@Component({
    templateUrl: './site-create.component.html',
})
export class SiteCreateComponent extends ReactiveFormFeature implements OnInit {
    private customerId: number;

    constructor(
        private siteService: SiteService,
        router: Router,
        route: ActivatedRoute,
    ) {
        super(router, route);
    }

    public ngOnInit(): void {
        super.onInit();

        this.route.params
            .take(1)
            .subscribe((params: Params) => {
                this.customerId = params.customerId;
                this.parentRoute = `/customers/${ this.customerId }/sites`;
            });
    }

    public onSubmit(): void {
        if (this.validate()) {
            this.createSite()
                .take(1)
                .subscribe(this.successCallback(() => {
                    this.router.navigate([this.parentRoute]);
                }), this.errorCallback((errorCode: number) => this.error(errorCode)));
        }
    }

    public onSaveAndOpen(): void {
        if (this.validate()) {
            this.createSite()
                .take(1)
                .subscribe(this.successCallback(() => {
                    this.router.navigate([`${this.parentRoute}/${this.objectId}`]);
                }), this.errorCallback((errorCode: number) => this.error(errorCode)));
        }
    }

    public onSaveAndCreate(): void {
        if (this.validate()) {
            this.createSite()
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
            isDefault: new FormControl(false),
            nationalIdNumber: new FormControl(''),
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

    private createSite(): Observable<number> {
        const command: Site = this.form.value;
        command.customerId = this.customerId;

        return this.siteService
            .create(command)
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
