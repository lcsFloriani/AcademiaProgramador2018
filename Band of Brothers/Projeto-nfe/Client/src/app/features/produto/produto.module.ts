import { ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { GridModule } from '@progress/kendo-angular-grid';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

import { NDDBreadcrumbModule } from '../../shared/ndd-ng-breadcrumb/component/ndd-ng-breadcrumb.module';
import { NDDTabsbarModule } from '../../shared/ndd-ng-tabsbar/component';
import { NDDTitlebarModule } from '../../shared/ndd-ng-titlebar/component';

import { ProdutoListComponent } from './produto-list/produto-list.component';
import { ProdutoRoutingModule } from './produto-routing.module';
import { ProdutoGridService } from './shared/produto.grid.service';
import { ProdutoResolveService, ProdutoService } from './shared/produto.service';
import { ProdutoSharedService } from './shared/produto.shared';
@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        GridModule,
        ProdutoRoutingModule,
        HttpClientModule,
        NDDTabsbarModule,
        NDDBreadcrumbModule,
        NDDTitlebarModule,
    ],
    exports: [],
    declarations: [
        ProdutoListComponent,
    ],
    providers: [
        ProdutoGridService,
        ProdutoResolveService,
        ProdutoSharedService,
        ProdutoService,
    ],
})

export class ProdutoModule {

}
