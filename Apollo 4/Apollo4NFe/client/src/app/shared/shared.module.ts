
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NDDTabsbarModule } from './ndd-ng-tabsbar/component';
import { NDDBreadcrumbModule } from './ndd-ng-breadcrumb';
import { NDDTitlebarModule } from './ndd-ng-titlebar/component';

import { NgxMaskModule } from 'ngx-mask';
@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        NDDTabsbarModule,
        NDDBreadcrumbModule,
        NDDTitlebarModule,
        NgxMaskModule.forRoot(),
    ],
    exports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        NDDTitlebarModule,
        NDDTabsbarModule,
        NgxMaskModule,
    ],
    declarations: [],
    providers: [],
})
export class SharedModule { }
