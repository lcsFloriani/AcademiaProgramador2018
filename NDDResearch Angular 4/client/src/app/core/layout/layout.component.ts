import { Component, ViewChild, ChangeDetectorRef, OnInit } from '@angular/core';
import { NDDTranslationService } from 'ndd-ng-translation';
import { NDDIntlService } from 'ndd-ng-intl';
import { NDDDialogService } from 'ndd-ng-dialog';
import { Subject } from 'rxjs/Subject';

import { AuthenticationProfileService } from '../authentication/authentication-profile.service';
import { UserMenuContentComponent } from '../user-menu/content/user-menu-content.component';
import { AuthenticationService } from '../authentication/authentication.service';
import { IAuthProfile } from '../authentication/shared/authentication-profile.model';
import { LanguageTypes } from '../i18n/i18n-language-types.model';

import { NDDSidebarService } from 'ndd-ng-sidebar';
import { NDDOffSidebarService } from 'ndd-ng-offsidebar';

@Component({
    selector: 'ndd-layout',
    templateUrl: './layout.component.html',
})
export class LayoutComponent implements OnInit {
    public pinned: boolean = false;

    public fullName: string = '';
    public email: string = '';

    @ViewChild(UserMenuContentComponent) public userMenuLang: UserMenuContentComponent;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(
        private sidebarService: NDDSidebarService,
        private authProfileService: AuthenticationProfileService,
        private authenticationService: AuthenticationService,
        private intlService: NDDIntlService,
        private translationService: NDDTranslationService,
        private dialogService: NDDDialogService,
        private offsidebarService: NDDOffSidebarService,
        private cdr: ChangeDetectorRef,
    ) { }

    public ngOnInit(): void {
        // Chamada inicial.
        this.authProfileService.getAuthProfile()
            .take(1)
            .subscribe(this.onRefreshAuthProfileData.bind(this));

        // Alterações após a inicialização.
        this.authProfileService.onRefreshAuthProfileData$
            .takeUntil(this.ngUnsubscribe)
            .subscribe(this.onRefreshAuthProfileData.bind(this));
        // Necessário para atualizar o sidebar
        this.cdr.detectChanges();
    }

    public closeOffSidebar(): void {
        this.userMenuLang.selectLanguage = false;
    }

    public logout(): void {
        this.authenticationService.logout(true);
    }

    public openOffSidebar(): void {
        this.offsidebarService.openOffSidebar('ndd-ng-offsidebar-user-menu');
    }

    public setLanguage(lang: LanguageTypes): void {
        if (this.translationService.currentLang === <any>lang) {
            this.dialogService.alert({ message: 'NDDLanguageSelectedNoHasChanged' });
        } else {
            this.dialogService
                .confirm({ message: 'NDDConfirmLanguageChange' })
                .subscribe((response: boolean) => {
                    if (response) {
                        this.translationService.currentLang = <any>lang;
                    }
                });
        }
    }

    public setPin(pinned: boolean): void {
        this.pinned = pinned;
    }

    public toggleSidebar(): void {
        this.sidebarService.toggleCollapse();
    }

    private onRefreshAuthProfileData(profile: IAuthProfile): void {
        this.fullName = profile.unique_name;
        this.email = profile.email;
        this.intlService.culture = 'pt-br';
    }
}
