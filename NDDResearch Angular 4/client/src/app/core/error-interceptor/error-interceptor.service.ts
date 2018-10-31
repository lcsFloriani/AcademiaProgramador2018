import { Router } from '@angular/router';
import { HttpInterceptor, HttpHandler, HttpRequest, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';

import { AuthenticationTokenService } from '../authentication/authentication-token.service';

import { IErrorResponse } from './shared/error-response.model';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    private static HTTP_STATUS_401: number = 401;
    private static HTTP_STATUS_403: number = 403;
    private static HTTP_STATUS_404: number = 404;
    private readonly notFoundRoute: string = '/page-not-found';
    private readonly unauthorizedRoute: string = '/page-unauthorized';
    private readonly forbiddenRoute: string = '/page-forbidden';
    private readonly loginRoute: string = '/login';

    constructor(
        private router: Router,
        private authService: AuthenticationTokenService,
    ) { }

    public intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).do((event: HttpEvent<any>) => {
            //
        }, (response: any) => {
            if (response instanceof HttpErrorResponse) {
                switch (response.status) {
                    case (ErrorInterceptor.HTTP_STATUS_401): {
                        this.handleUnauthorized();
                        break;
                    }
                    case (ErrorInterceptor.HTTP_STATUS_403): {
                        this.handleForbidden();
                        break;
                    }
                    default: {
                        const error: IErrorResponse = response.error;
                        switch (error.errorCode) {
                            case (ErrorInterceptor.HTTP_STATUS_404): {
                                this.handleNotFound();
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        });
    }

    private handleNotFound(): void {
        this.router.navigate([this.notFoundRoute]);
    }

    private handleUnauthorized(): void {
        const url: string = this.getCurrentUrl();

        if (this.authService.token.UserId === undefined) {
            this.router.navigate([this.loginRoute]);

            return;
        }

        if (url) {
            this.router.navigate([this.unauthorizedRoute], { queryParams: { returnUrl: url } });
        } else {
            this.router.navigate([this.unauthorizedRoute]);
        }
    }

    private handleForbidden(): void {
        this.router.navigate([this.forbiddenRoute]);
    }

    private getCurrentUrl(): string {
        const url: string = this.router.url;
        if (url.includes(this.loginRoute)
            || url.includes(this.unauthorizedRoute)
            || url.includes(this.notFoundRoute)
            || url.includes(this.forbiddenRoute)) {

            return null;
        } else {

            return url;
        }
    }
}
