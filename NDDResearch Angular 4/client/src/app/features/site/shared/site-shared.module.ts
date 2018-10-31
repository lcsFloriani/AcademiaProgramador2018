import { NgModule } from '@angular/core';

import { SiteService, SiteGridService } from './site.service';
import { SiteResolveService } from './site-resolve.service';

@NgModule({
    providers: [
        SiteService,
        SiteGridService,
        SiteResolveService,
    ],
    exports: [],
})
export class SiteSharedModule {}
