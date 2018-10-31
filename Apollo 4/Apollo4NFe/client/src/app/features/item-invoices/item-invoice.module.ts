import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { GridModule } from '@progress/kendo-angular-grid';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';

import { SharedModule } from 'src/app/shared/shared.module';
import { NddFormModule } from 'src/app/shared/ndd-form/ndd-form.module';
import { ItemInvoiceRoutingModule } from './item-invoice-routing.module';
import { ItemInvoiceComponent } from './item-invoice/item-invoice.component';
import { ItemInvoiceSharedModule } from './shared/item-invoice-shared/item-invoice-shared.module';

@NgModule({
    imports: [
        SharedModule,
        HttpClientModule,
        GridModule,
        DropDownsModule,
        NddFormModule,
        ItemInvoiceRoutingModule,
        ItemInvoiceSharedModule,
    ],
    declarations: [
        ItemInvoiceComponent,
    ],
    providers: [],
})
export class ItemInvoiceModule {

}
