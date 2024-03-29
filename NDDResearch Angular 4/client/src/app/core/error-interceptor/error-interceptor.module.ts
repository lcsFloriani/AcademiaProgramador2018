import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { AuthModule } from '../authentication/authentication.module';
import { SharedModule } from '../../shared/shared.module';
import { ErrorInterceptor } from './error-interceptor.service';

@NgModule({
    imports: [
        SharedModule,
        RouterModule,
        AuthModule,
    ],
    exports: [],
    declarations: [],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    ],
})
export class ErrorInterceptorModule { }
