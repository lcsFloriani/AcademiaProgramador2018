import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LoadingBarRouterModule } from '@ngx-loading-bar/router';
import { NDDDialogModule } from 'ndd-ng-dialog';
import { NDDTranslationService } from 'ndd-ng-translation';
import { NDDNavbarModule } from 'ndd-ng-navbar';

import { SharedModule } from '../../shared/shared.module';
import { LayoutComponent } from './layout.component';
import { UserMenuModule } from './../user-menu/user-menu.module';
import { NDDOffSidebarModule } from 'ndd-ng-offsidebar';
import { NDDSidebarModule } from 'ndd-ng-sidebar';

@NgModule({
    imports: [
        SharedModule,
        RouterModule,
        UserMenuModule,
        NDDDialogModule,
        // Temp
        NDDNavbarModule,
        NDDSidebarModule,
        NDDOffSidebarModule,
        LoadingBarRouterModule,
    ],
    exports: [],
    declarations: [LayoutComponent],
    providers: [NDDTranslationService],
})
export class LayoutModule { }
