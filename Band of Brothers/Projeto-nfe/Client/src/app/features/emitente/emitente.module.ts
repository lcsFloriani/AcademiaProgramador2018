import { ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { GridModule } from '@progress/kendo-angular-grid';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

import { NDDBreadcrumbModule } from './../../shared/ndd-ng-breadcrumb/component/ndd-ng-breadcrumb.module';
import { EmitenteViewComponent } from './emitente-view/emitente-view.component';
import { EmitenteDetailComponent } from './emitente-view/emitente-detail/emitente-detail.component';
import { EmitenteListComponent } from './emitente-list/emitente-list.component';
import { EmitenteRoutingModule } from './emitente-routing.module';
import { EmitenteGridService, EmitenteResolveService, EmitenteSharedService, EmitenteService } from './shared/emitente.service';
import { NDDTabsbarModule } from '../../shared/ndd-ng-tabsbar/component';
import { NDDTitlebarModule } from '../../shared/ndd-ng-titlebar/component';
import { EmitenteCreateComponent } from './emitente-create/emitente-create.component';
import { EmitenteEditComponent } from './emitente-view/emitente-edit/emitente-edit.component';

@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        EmitenteRoutingModule,
        GridModule,
        HttpClientModule,
        NDDTabsbarModule,
        NDDBreadcrumbModule,
        NDDTitlebarModule,
    ],
    exports: [],
    declarations: [
        EmitenteListComponent,
        EmitenteDetailComponent,
        EmitenteViewComponent,
        EmitenteCreateComponent,
        EmitenteEditComponent,
    ],
    providers: [
        EmitenteGridService,
        EmitenteResolveService,
        EmitenteSharedService,
        EmitenteService,
    ],
})

export class EmitenteModule {

}
