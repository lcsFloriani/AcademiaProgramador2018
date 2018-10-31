import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductDropdownService, ItemInvoiceService, ItemInvoiceGridService } from './item-invoice.service';

@NgModule({
    declarations: [],
    imports: [ CommonModule ],
    exports: [],
    providers: [ ItemInvoiceGridService, ItemInvoiceService, ProductDropdownService ],
})
export class ItemInvoiceSharedModule {

}
