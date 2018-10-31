import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { RequestPasswordComponent } from './request-password/request-password.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { LoginComponent } from './login.component';

const routes: Routes = [
    {
        path: '',
        component: LoginComponent,
        children: [
            {
                path: '',
                component: LoginFormComponent,
            },
            {
                path: 'request-password',
                component: RequestPasswordComponent,
            },
        ],
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class LoginRoutingModule { }
