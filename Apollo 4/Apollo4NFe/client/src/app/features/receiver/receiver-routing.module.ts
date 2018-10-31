import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ReceiverListComponent } from './receiver-list/receiver-list.component';
import { ReceiverViewComponent } from './receiver-view/receiver-view.component';
import { ReceiverResolveService } from './shared/receiver-shared/receiver.service';
import { ReceiverCreatorComponent } from './receiver-creator/receiver-creator.component';
import { ReceiverEditComponent } from './receiver-view/receiver-edit/receiver-edit.component';
import { ReceiverDetailComponent } from './receiver-view/receiver-detail/receiver-detail.component';

const receiverRoutes: Routes = [
    {
        path: '',
        component: ReceiverListComponent,
    },
    {
        path: 'create',
        component: ReceiverCreatorComponent,
        data: {
            breadcrumbOptions: {
                breadcrumbLabel: 'Criar Destinatário',
            },
        },
    },
    {
        path: ':receiverId',
        resolve: {
            ReceiverResolveService,
        },
        data: {
            breadcrumbOptions: {
                breadcrumbLabel: 'Destinatário',
            },
        },
        children:
            [
                {
                    path: '',
                    component: ReceiverViewComponent,
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
                                    component: ReceiverDetailComponent,
                                },
                                {
                                    path: 'edit',
                                    component: ReceiverEditComponent,
                                    data: {
                                        breadcrumbOptions: {
                                            breadcrumbLabel: 'Editar Destinatário',
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
    imports: [RouterModule.forChild(receiverRoutes)],
    exports: [RouterModule],
    declarations: [],
    providers: [],
})
export class ReceiverRoutingModule { }
