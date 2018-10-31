import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

import { CORE_CONFIG_TOKEN, ICoreConfig } from '../core.config';
import { LocalStorageKeys } from './../storage/local-storage.enum';
import { LocalStorageService } from './../storage/local-storage.service';
import { AuthenticationStatusService } from './authentication-status.service';
import { AuthenticationTokenService } from './authentication-token.service';
import { IAuth } from './shared/authentication.model';
import { IRequestPasswordModel } from './shared/request-password.model';

@Injectable()
export class AuthenticationService {
    private apiUrl: string;
    private apiAuthUrl: string;
    private authRequestOptions: any;

    constructor(
        private http: HttpClient,
        private localStorageService: LocalStorageService,
        private authTokenService: AuthenticationTokenService,
        private statusService: AuthenticationStatusService,
        @Inject(CORE_CONFIG_TOKEN) private config: ICoreConfig,
    ) {
        this.apiUrl = config.apiEndpoint;
        this.apiAuthUrl = config.apiAuthEndpoint;
        this.authRequestOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' }),
        };
    }

    public requestPassword(data: IRequestPasswordModel): Observable<boolean> {
        const content: any = {
            dealerName: data.dealerName.trim(),
            userEmail: data.userEmail.trim(),
        };

        return this.http.post<boolean>(`${this.apiUrl}api/users/password`, content);
    }

    public login(data: IAuth, isDealer: boolean): Observable<void> {
        const body: HttpParams = new HttpParams({
            fromObject: {
                grant_type: 'password',
                username: data.username.trim(),
                client_id: this.config.client_id,
                password: encodeURIComponent(data.password),
            },
        });

        return this.http
            .post(`${this.apiAuthUrl}token`, body, this.authRequestOptions)
            .map((response: any) => {
                const token: any = response.access_token;

                /* Armazena as configurações no parceiro no Local Storage */
                const dealerSettings: any = this.setUpDealerSettings(response);
                this.localStorageService.setValue(LocalStorageKeys.DealerSettings, JSON.stringify(dealerSettings));

                this.handleAuthToken(true, token);
                /**Código provisório */
                this.localStorageService.setValue(LocalStorageKeys.CurrentLanguage, 'pt-br');
            });
    }

    public logout(redirectToLogin: boolean = false): void {
        this.handleAuthToken(false);
        if (redirectToLogin) {
            this.navigateToLogin();
        }
    }

    public isAlive(): Observable<any> {
        return this.http
            .get(`${this.apiUrl}api/public/is-alive`)
            .map((response: Response) => {
                this.statusService.loggedIn = true;

                return response;
            });
    }

    public setUpDealerSettings(response: any): any {
        return {
            dateFormat: response.dateFormat,
            dealer: response.dealer,
        };
    }

    public navigateToLogin(params?: any): void {
        this.statusService.navigateToLogin(params);
    }

    private handleAuthToken(login: boolean, token?: string): void {
        this.statusService.loggedIn = login;

        if (login) {
            this.authTokenService.createToken(token);
        } else {
            this.authTokenService.resetToken();
            this.localStorageService.deleteValue(LocalStorageKeys.CurrentUser);
        }
    }
}
