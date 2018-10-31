import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { AuthenticationService } from './authentication.service';
import { AuthenticationStatusService } from './authentication-status.service';

@Injectable()
export class AuthGuardService {
    constructor(private authenticationService: AuthenticationService, private statusService: AuthenticationStatusService) { }

    public canLoad(): Observable<boolean> {
        if (this.statusService.loggedIn) {
            return Observable.of(true);
        } else {
            return this.authenticationService.isAlive()
                .catch(() => {
                    return Observable.of(false);
                });
        }
    }

    public canActivate(): Observable<boolean> {
        return this.canLoad();
    }
}
