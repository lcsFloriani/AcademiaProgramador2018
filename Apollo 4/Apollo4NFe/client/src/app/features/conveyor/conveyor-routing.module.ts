import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ConveyorListComponent } from './conveyor-list/conveyor-list.component';
import { ConveyorCreatorComponent } from './conveyor-creator/conveyor-creator.component';
import { ConveyorViewComponent } from './conveyor-view/conveyor-view.component';
import { ConveyorDetailComponent } from './conveyor-view/conveyor-detail/conveyor-detail.component';
import { ConveyorEditComponent } from './conveyor-view/conveyor-edit/conveyor-edit.component';
import { ConveyorResolveService } from './shared/conveyor-shared/conveyor.service';
const conveyorRoutes: Routes = [
    {
        path: '',
        component: ConveyorListComponent,
    },
    {
        path: 'create',
        component: ConveyorCreatorComponent,
        data: {
            breadcrumbOptions: {
                breadcrumbLabel: 'Criar Transportador',
            },
        },
    },
    {
        path: ':conveyorId',
        resolve: {
            ConveyorResolveService,
        },
        data: {
            breadcrumbOptions: {
                breadcrumbLabel: 'Transportador',
            },
        },
        children: [
            {
                path: '',
                component: ConveyorViewComponent,
                children: [
                    {
                        path: '',
                        redirectTo: 'info',
                        pathMatch: 'full',
                    },
                    {
                        path: 'info',
                        children: [
                            {
                                path: '',
                                component: ConveyorDetailComponent,
                            },
                            {
                                path: 'edit',
                                component: ConveyorEditComponent,
                                data: {
                                    breadcrumbOptions: {
                                        breadcrumbLabel: 'Editar',
                                    },
                                },
                            },
                        ],
                    },
                ],
            },
        ],
    },
];
@NgModule({
    imports: [RouterModule.forChild(conveyorRoutes)],
    exports: [RouterModule],
    declarations: [],
    providers: [],
})
export class ConveyorRoutingModule {

}
