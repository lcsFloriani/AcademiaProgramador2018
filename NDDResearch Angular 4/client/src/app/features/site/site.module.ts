import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NDDTitlebarModule } from 'ndd-ng-titlebar';
import { NDDTranslationModule } from 'ndd-ng-translation';
import { NDDTabsbarModule } from 'ndd-ng-tabsbar';
import { NDDButtonsModule } from 'ndd-ng-buttons';
import { NDDFormModule } from 'ndd-ng-form';
import { NDDSpinnerModule } from 'ndd-ng-spinner';

import { SiteRoutingModule } from './site-routing.module';
import { SiteCreateComponent } from './site-create/site-create.component';
import { SiteViewComponent } from './site-view/site-view.component';
import { SiteInfoDetailComponent } from './site-view/detail/site-info-detail.component';
import { SiteInfoEditComponent } from './site-view/edit/site-info-edit.component';
import { SiteSharedModule } from './shared/site-shared.module';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        NDDSpinnerModule,
        NDDTitlebarModule,
        NDDTabsbarModule,
        NDDTranslationModule,
        NDDFormModule,
        NDDButtonsModule,
        SiteRoutingModule,
        SiteSharedModule,
    ],
    exports: [],
    declarations: [
        SiteCreateComponent,
        SiteViewComponent,
        SiteInfoDetailComponent,
        SiteInfoEditComponent,
    ],
    providers: [],
})
export class SiteModule {}
