import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { EmitterViewComponent } from './emitter-view/emitter-view.component';
import { EmitterResolveService } from './shared/emitter-shared/emitter.service';
import { EmitterCreatorComponent } from './emitter-creator/emitter-creator.component';
import { EmitterListComponent } from './emitter-list/emitter-list.component';
import { EmitterDetailComponent } from './emitter-view/emitter-detail/emitter.detail.component';
import { EmitterEditComponent } from './emitter-view/emitter-edit/emitter-edit.component';

const emitterRoutes: Routes = [
    {
        path: '',
        component: EmitterListComponent,
    },
    {
        path: 'create',
        component: EmitterCreatorComponent,
        data: {
            breadcrumbOptions: {
                breadcrumbLabel: 'Criar Emitente',
            },
        },
    },
    {
        path: ':emitterId',
        resolve: {
            EmitterResolveService,
        },
        data: {
            breadcrumbOptions: {
                breadcrumbLabel: 'Emitter',
            },
        },
        children: [
            {
                path: '',
                component: EmitterViewComponent,
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
                                component: EmitterDetailComponent,
                            },
                            {
                                path: 'edit',
                                component: EmitterEditComponent,
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
    imports: [RouterModule.forChild(emitterRoutes)],
    exports: [RouterModule],
    declarations: [],
    providers: [],
})
export class EmitterRoutingModule {

}
