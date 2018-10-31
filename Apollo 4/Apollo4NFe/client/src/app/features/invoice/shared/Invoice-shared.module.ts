import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { InvoiceGridService, InvoiceService, InvoiceResolveService } from './invoice.service';

@NgModule({
    declarations: [],
    imports: [ CommonModule ],
    exports: [],
    providers: [ InvoiceGridService, InvoiceService, InvoiceResolveService ],
})
export class InvoiceSharedModule {}
