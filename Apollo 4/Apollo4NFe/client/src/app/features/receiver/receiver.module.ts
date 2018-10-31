import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { GridModule } from '@progress/kendo-angular-grid';
import { RippleModule } from '@progress/kendo-angular-ripple';

import { SharedModule } from '../../shared/shared.module';
import { ReceiverRoutingModule } from './receiver-routing.module';
import { NddFormModule } from '../../shared/ndd-form/ndd-form.module';
import { AddressSharedModule } from '../address/address-shared.module';
import { ReceiverListComponent } from './receiver-list/receiver-list.component';
import { ReceiverFormComponent } from './receiver-form/receiver-form.component';
import { ReceiverViewComponent } from './receiver-view/receiver-view.component';
import { ReceiverSharedModule } from './shared/receiver-shared/receiver-shared.module';
import { ReceiverCreatorComponent } from './receiver-creator/receiver-creator.component';
import { ReceiverEditComponent } from './receiver-view/receiver-edit/receiver-edit.component';
import { ReceiverDetailComponent } from './receiver-view/receiver-detail/receiver-detail.component';

@NgModule({
    imports: [
        SharedModule,
        HttpClientModule,
        ReceiverRoutingModule,
        ReceiverSharedModule,
        GridModule,
        AddressSharedModule,
        NddFormModule,
        RippleModule,
    ],
    declarations: [
        ReceiverListComponent,
        ReceiverCreatorComponent,
        ReceiverFormComponent,
        ReceiverViewComponent,
        ReceiverDetailComponent,
        ReceiverEditComponent,
    ],
})

export class ReceiverModule {}
