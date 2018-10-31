
import { Component, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs/Subject';

import { IAuthProfile } from './../../authentication/shared/authentication-profile.model';
import { AuthenticationProfileService } from './../../authentication/authentication-profile.service';
@Component({
    selector: 'ndd-user-menu-view-enterprise',
    templateUrl: 'user-menu-view-enterprise.component.html',
})
export class UserConfigViewEnterpriseComponent implements OnDestroy {
    public enterprise: string;
    public domain: string;
    public logon: string;
    public email: string;
    public fullName: string;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private authProfileService: AuthenticationProfileService) {
        this.authProfileService.onRefreshAuthProfileData$
            .takeUntil(this.ngUnsubscribe)
            .subscribe((profile: IAuthProfile) => {
                this.logon = profile.unique_name;
                this.email = profile.email;
                this.fullName = profile.unique_name;
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }
}
