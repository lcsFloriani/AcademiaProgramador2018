import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';

import { IAuthProfile } from './shared/authentication-profile.model';
import { CORE_CONFIG_TOKEN, ICoreConfig } from '../core.config';
import { AuthenticationTokenService } from './authentication-token.service';
import { IAuthToken } from './shared/authentication-token.model';

@Injectable()
export class AuthenticationProfileService {
    public onRefreshAuthProfileData$: Subject<IAuthProfile> = new Subject<IAuthProfile>();

    constructor(
        @Inject(CORE_CONFIG_TOKEN) config: ICoreConfig,
        private authTokenService: AuthenticationTokenService,
    ) { }

    public getAuthProfile(): Observable<IAuthProfile> {
        const token: IAuthToken = this.authTokenService.token;
        const userdata: IAuthProfile = {
            email: token.email,
            unique_name: token.unique_name,
            userId:  Number.parseInt(token.UserId),
        };
        this.onRefreshAuthProfileData$.next(userdata);

        return Observable.of<IAuthProfile>(userdata);
    }
}
