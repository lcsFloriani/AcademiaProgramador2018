import { NgModule } from '@angular/core';
import { NDDTooltipModule } from 'ndd-ng-tooltip';
import { NDDDropdownModule } from 'ndd-ng-dropdown';
import { NDDTabsbarModule } from 'ndd-ng-tabsbar';
import { NDDFormModule } from 'ndd-ng-form';

import { SharedModule } from '../../shared/shared.module';
import { LoginService } from './shared/login.service';
import { RequestPasswordComponent } from './request-password/request-password.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { LoginComponent } from './login.component';
import { LoginRoutingModule } from './login-routing.module';

@NgModule({
    imports: [
        SharedModule,
        NDDTooltipModule,
        NDDDropdownModule,
        NDDFormModule,
        NDDTabsbarModule,
        LoginRoutingModule,
    ],
    declarations: [
        LoginComponent,
        LoginFormComponent,
        RequestPasswordComponent,
    ],
    providers: [
        LoginService,
    ],
})
export class LoginModule { }
