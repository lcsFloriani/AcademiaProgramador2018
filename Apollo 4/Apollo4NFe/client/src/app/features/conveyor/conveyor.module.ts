import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { GridModule } from '@progress/kendo-angular-grid';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';

import { ConveyorEditComponent } from './conveyor-view/conveyor-edit/conveyor-edit.component';
import { ConveyorViewComponent } from './conveyor-view/conveyor-view.component';
import { ConveyorCreatorComponent } from './conveyor-creator/conveyor-creator.component';
import { ConveyorListComponent } from './conveyor-list/conveyor-list.component';
import { ConveyorFormComponent } from './conveyor-form/conveyor-form.component';
import { ConveyorDetailComponent } from './conveyor-view/conveyor-detail/conveyor-detail.component';
import { ConveyorRoutingModule } from './conveyor-routing.module';
import { SharedModule } from '../../shared/shared.module';
import { NddFormModule } from '../../shared/ndd-form/ndd-form.module';
import { ConveyorSharedModule } from './shared/conveyor-shared/conveyor-shared.module';
import { AddressSharedModule } from '../address/address-shared.module';
@NgModule({
    imports: [
        SharedModule,
        HttpClientModule,
        GridModule,
        DropDownsModule,
        AddressSharedModule,
        NddFormModule,
        ConveyorRoutingModule,
        ConveyorSharedModule,
    ],
    declarations: [
        ConveyorListComponent,
        ConveyorCreatorComponent,
        ConveyorFormComponent,
        ConveyorViewComponent,
        ConveyorDetailComponent,
        ConveyorEditComponent,
    ],
    providers: [],
})
export class ConveyorModule {

}
