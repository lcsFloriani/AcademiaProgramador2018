import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { AbstractResolveService } from 'ndd-ng-route';

import { SiteService } from './site.service';
import { Site } from './model/site.model';
import { NDDBreadcrumbService } from 'ndd-ng-breadcrumb';

@Injectable()
export class SiteResolveService extends AbstractResolveService<Site>{

    constructor(private siteService: SiteService,
        private breadcrumbService: NDDBreadcrumbService,
        router: Router) {
        super(router);
        this.paramsProperty = 'siteId';
    }

    public loadEntity(siteId: number): Observable<Site> {
        return this.siteService
            .get(siteId)
            .do((site: Site) => {
                this.breadcrumbService.setMetadata({
                    id: 'site',
                    label: site.name,
                    sizeLimit: true,
                });
            });
    }
}
