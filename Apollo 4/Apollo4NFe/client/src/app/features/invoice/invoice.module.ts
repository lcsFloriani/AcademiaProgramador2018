import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { GridModule } from '@progress/kendo-angular-grid';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';

import { SharedModule } from '../../shared/shared.module';
import { InvoiceRoutingModule } from './invoice-routing.module';
import { InvoiceSharedModule } from './shared/Invoice-shared.module';
import { InvoiceViewComponent } from './invoice-view/invoice-view.component';
import { InvoiceListComponent } from './invoice-list/invoice-list.component';
import { InvoiceFormComponent } from './invoice-form/invoice-form.component';
import { InvoiceCreatorComponent } from './invoice-creator/invoice-creator.component';
import { InvoiceEditComponent } from './invoice-view/invoice-edit/invoice-edit.component';
import { ItemInvoiceComponent } from '../item-invoices/item-invoice/item-invoice.component';
import { EmitterSharedModule } from '../emitter/shared/emitter-shared/emitter-shared.module';
import { ConveyorSharedModule } from '../conveyor/shared/conveyor-shared/conveyor-shared.module';
import { ReceiverSharedModule } from '../receiver/shared/receiver-shared/receiver-shared.module';
import { InvoiceDetailComponent } from './invoice-view/invoice-details/invoice-detail.component';
import { ItemInvoiceSharedModule } from '../item-invoices/shared/item-invoice-shared/item-invoice-shared.module';

@NgModule({
    imports: [
        SharedModule,
        HttpClientModule,
        InvoiceRoutingModule,
        EmitterSharedModule,
        ReceiverSharedModule,
        ConveyorSharedModule,
        InvoiceSharedModule,
        GridModule,
        DropDownsModule,
        ItemInvoiceSharedModule,
    ],
    declarations: [
        InvoiceCreatorComponent,
        InvoiceListComponent,
        InvoiceFormComponent,
        InvoiceDetailComponent,
        InvoiceViewComponent,
        ItemInvoiceComponent,
        InvoiceEditComponent,
    ],
    providers: [],
})
export class InvoiceModule { }
