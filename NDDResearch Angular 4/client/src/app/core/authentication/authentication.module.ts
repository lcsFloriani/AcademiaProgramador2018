import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { SharedModule } from '../../shared/shared.module';
import { CORE_CONFIG, CORE_CONFIG_TOKEN } from '../core.config';
import { StorageModule } from '../storage/storage.module';

import { AuthenticationTokenService } from './authentication-token.service';
import { AuthenticationStatusService } from './authentication-status.service';
import { AuthInterceptor } from './auth-interceptor.service';
import { AuthenticationProfileService } from './authentication-profile.service';
import { AuthGuardService } from './auth-guard.service';
import { AuthenticationService } from './authentication.service';

@NgModule({
    imports: [
        SharedModule,
        RouterModule,
        StorageModule,
    ],
    exports: [],
    declarations: [],
    providers: [
        { provide: CORE_CONFIG_TOKEN, useValue: CORE_CONFIG },
        { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
        AuthenticationProfileService,
        AuthenticationStatusService,
        AuthenticationTokenService,
        AuthenticationService,
        AuthGuardService,
    ],
})
export class AuthModule { }
