import { NgModule } from '@angular/core';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';

import { AddressFormComponent } from './address-form/address-form.component';
import { AddressDetailComponent } from './address-detail/address-detail.component';
import { SharedModule } from './../../shared/shared.module';
import { StatePipe } from './state.pipe';

@NgModule({
    imports: [
        SharedModule,
        DropDownsModule,
    ],
    declarations: [
        AddressFormComponent,
        AddressDetailComponent,
        StatePipe,
    ],
    providers: [],
    exports: [
        AddressFormComponent,
        AddressDetailComponent,
        StatePipe,
    ],
})
export class AddressSharedModule {

}
