import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { GridModule } from '@progress/kendo-angular-grid';

import { SharedModule } from '../../shared/shared.module';
import { EmitterRoutingModule } from './emitter-routing.module';
import { EmitterListComponent } from './emitter-list/emitter-list.component';
import { EmitterSharedModule } from './shared/emitter-shared/emitter-shared.module';
import { EmitterFormComponent } from './emitter-form/emitter-form.component';
import { EmitterCreatorComponent } from './emitter-creator/emitter-creator.component';
import { AddressSharedModule } from './../address/address-shared.module';
import { EmitterViewComponent } from './emitter-view/emitter-view.component';
import { EmitterEditComponent } from './emitter-view/emitter-edit/emitter-edit.component';
import { EmitterDetailComponent } from './emitter-view/emitter-detail/emitter.detail.component';
import { NddFormModule } from '../../shared/ndd-form/ndd-form.module';

@NgModule({
    imports: [
        SharedModule,
        HttpClientModule,
        EmitterRoutingModule,
        EmitterSharedModule,
        GridModule,
        AddressSharedModule,
        NddFormModule,
    ],
    declarations: [
        EmitterListComponent,
        EmitterCreatorComponent,
        EmitterFormComponent,
        EmitterViewComponent,
        EmitterDetailComponent,
        EmitterEditComponent,
    ],
    providers: [],
})
export class EmitterModule {

}
