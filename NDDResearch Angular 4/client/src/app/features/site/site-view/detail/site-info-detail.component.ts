import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Subject } from 'rxjs/Subject';

import { SiteService } from '../../shared/site.service';
import { Site } from '../../shared/model/site.model';

@Component({
    templateUrl: './site-info-detail.component.html',
})

export class SiteInfoDetailComponent implements OnInit, OnDestroy {

    public isLoading: boolean;
    public site: Site;

    private siteId: number;
    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private siteService: SiteService,
    ) { }

    public ngOnInit(): void {
        this.isLoading = true;

        this.route.params
            .takeUntil(this.ngUnsubscribe)
            .subscribe((params: Params) => {
                this.siteId = params.siteId;
                this.loadSite();
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public onEdit(): void {
        this.router.navigate([this.router.url + `/edit`], { skipLocationChange: true });
    }

    private loadSite(): void {
        this.siteService
            .get(this.siteId)
            .take(1)
            .subscribe((response: Site) => {
                this.isLoading = false;

                this.site = response;
            });
    }
}
