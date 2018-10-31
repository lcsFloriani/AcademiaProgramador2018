import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs/Subject';

import { Site } from '../shared/model/site.model';
import { SiteResolveService } from '../shared/site-resolve.service';

@Component({
    templateUrl: './site-view.component.html',
})

export class SiteViewComponent implements OnInit, OnDestroy {
    public isLoading: boolean;
    public site: Site;
    public infoItems: object[];
    public title: string;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(
        private siteResolverService: SiteResolveService,
    ) { }

    public ngOnInit(): void {
        this.isLoading = true;
        this.siteResolverService
            .onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((site: Site) => {
                this.isLoading = false;
                this.site = site;
                this.createProperty();
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    private createProperty(): void {
        this.title = this.site.name;
        this.infoItems = [
            {
                value: `${this.site.address.street}, ${this.site.address.city} - ${this.site.address.state}, ${this.site.address.postalCode}`,
                description: 'NDDAddress',
            },
        ];
    }
}
