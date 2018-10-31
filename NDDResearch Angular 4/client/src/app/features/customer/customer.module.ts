import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NDDTitlebarModule } from 'ndd-ng-titlebar';
import { NDDTranslationModule } from 'ndd-ng-translation';
import { NDDTabsbarModule } from 'ndd-ng-tabsbar';
import { NDDButtonsModule } from 'ndd-ng-buttons';
import { NDDFormModule } from 'ndd-ng-form';
import { NDDSpinnerModule } from 'ndd-ng-spinner';
import { NDDGridModule } from 'ndd-ng-grid';

import { CustomerRoutingModule } from './customer-routing.module';
import { CustomerListComponent } from './customer-list/customer-list.component';
import { CustomerCreateComponent } from './customer-create/customer-create.component';
import { NDDInputCustomerNameDirective } from './shared/ndd-input-customer-name.component';
import { CustomerViewComponent } from './customer-view/customer-view.component';
import { CustomerInfoDetailComponent } from './customer-view/detail/customer-info-detail.component';
import { CustomerInfoEditComponent } from './customer-view/edit/customer-info-edit.component';
import { CustomerSharedModule } from './shared/customer-shared.module';

import { CustomerActionFields } from './customer-list/values/customer-action-fields.model';

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
        CustomerRoutingModule,
        CustomerSharedModule,
        NDDGridModule,
    ],
    exports: [
        NDDInputCustomerNameDirective,
    ],
    declarations: [
        NDDInputCustomerNameDirective,
        CustomerListComponent,
        CustomerCreateComponent,
        CustomerViewComponent,
        CustomerInfoDetailComponent,
        CustomerInfoEditComponent,
    ],
    providers: [
        CustomerActionFields,
    ],
})
export class CustomerModule {}
