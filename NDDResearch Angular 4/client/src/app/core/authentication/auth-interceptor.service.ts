import { LocalStorageKeys } from './../storage/local-storage.enum';
import { HttpInterceptor, HttpHandler, HttpRequest, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';

import { LocalStorageService } from './../storage/local-storage.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

    constructor(
        private localStorageService: LocalStorageService,
    ) { }

    public intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        req = this.addToken(req);

        return next.handle(req);
    }

    private addToken(req: HttpRequest<any>): HttpRequest<any> {
        const token: string = this.localStorageService.getValue(LocalStorageKeys.Token);

        if (token) {
            req = req.clone({ headers: req.headers.set('Authorization', 'Bearer ' + token) });
        }

        return req;
    }
}
