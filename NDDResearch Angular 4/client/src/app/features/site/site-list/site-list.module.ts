import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { NDDGridModule } from 'ndd-ng-grid';

import { SiteListRoutingModule } from './site-list-routing.module';
import { SiteListComponent } from './site-list.component';
import { SiteActionFields } from './values/site-action-fields.model';
import { SiteGridColumns } from './values/site-grid-columns.model';
import { SiteSharedModule } from '../shared/site-shared.module';

@NgModule({
    imports: [
        CommonModule,
        NDDGridModule,
        SiteSharedModule,
        SiteListRoutingModule,
    ],
    exports: [
    ],
    declarations: [
        SiteListComponent,
    ],
    providers: [
        SiteActionFields,
        SiteGridColumns,
    ],
})
export class SiteListModule {}
