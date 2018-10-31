import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Subject } from 'rxjs/Subject';
import { Observable } from 'rxjs/Observable';
import { ReactiveFormFeature } from 'ndd-ng-form';

import { SiteService } from '../../shared/site.service';
import { Site } from '../../shared/model/site.model';
import { SiteResolveService } from '../../shared/site-resolve.service';

@Component({
    templateUrl: './site-info-edit.component.html',
})
export class SiteInfoEditComponent extends ReactiveFormFeature implements OnDestroy, OnInit {
    public site: Site;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(
        private siteResolverService: SiteResolveService,
        private siteService: SiteService,
        route: ActivatedRoute,
        router: Router,
    ) {
        super(router, route);
    }

    public ngOnInit(): void {
        this.isLoading = true;
        super.onInit();
        this.parentRoute = '../';
        this.siteResolverService
            .onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((site: Site) => {
                this.objectId = site.id;
                this.isLoading = false;
                this.site = site;
                this.isLoading = false;

                // Populando o form
                this.form.patchValue({
                    name: this.site.name,
                    isDefault: this.site.isDefault,
                    nationalIdNumber: this.site.nationalIdNumber,
                    address: {
                        country: this.site.address.country,
                        state: this.site.address.state,
                        city: this.site.address.city,
                        postalCode: this.site.address.postalCode,
                        street: this.site.address.street,
                        additionalInfo: this.site.address.additionalInfo,
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
            this.updateSite()
                .take(1)
                .subscribe(() => {
                    this.siteResolverService.resolveFromRouteAndNotify();
                    this.goToBackRoute();
                });
        }
    }

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

    private updateSite(): Observable<any> {
        this.isLoading = true;

        const command: Site = this.form.value;
        command.id = this.site.id;
        command.address.id = this.site.address.id;

        return this.siteService
            .update(command)
            .map((response: any) => {
                try {
                    return response;
                } finally {
                    this.isLoading = false;
                }
            });
    }
}
