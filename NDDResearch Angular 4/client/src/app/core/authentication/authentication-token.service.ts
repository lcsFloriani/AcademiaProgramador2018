
import { Injectable } from '@angular/core';
import { JwtHelper } from 'angular2-jwt';

import { RoleTypes } from './shared/role-types.enum';
import { IAuthToken } from './shared/authentication-token.model';
import { LocalStorageKeys } from './../storage/local-storage.enum';
import { LocalStorageService } from './../storage/local-storage.service';
@Injectable()
export class AuthenticationTokenService {

    private jwtHelper: JwtHelper = new JwtHelper();
    private currentUser: any = JSON.parse(this.localStorage.getValue(LocalStorageKeys.CurrentUser));

    constructor(private localStorage: LocalStorageService) { }

    public get token(): IAuthToken {
        if (!this.currentUser) {
            const t: string = this.localStorage.getValue(LocalStorageKeys.Token);

            if (t) {
                this.currentUser = this.jwtHelper.decodeToken(t);
            }
        }

        return this.currentUser || <IAuthToken>{};
    }

    public get role(): RoleTypes {
        return +this.token.rol;
    }

    public createToken(value: string): void {
        /* Armazena o token no Local Storage */
        this.localStorage.setValue(LocalStorageKeys.Token, value);
         /* Armazena o usuário atual no Local Storage */
         this.currentUser =  this.jwtHelper.decodeToken(value);
         this.localStorage.setValue(LocalStorageKeys.CurrentUser, JSON.stringify(this.currentUser));
    }

    public resetToken(): void {
        this.currentUser = null;
        this.localStorage.deleteValue(LocalStorageKeys.Token);
    }
}
