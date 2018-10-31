import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import { NDDTranslationService } from 'ndd-ng-translation';
import { NDDDialogService } from 'ndd-ng-dialog';
import { LanguageTypes } from './../../i18n/i18n-language-types.model';
import { AuthenticationTokenService } from './../../authentication/authentication-token.service';
import { RoleTypes } from './../../authentication/shared/role-types.enum';

@Component({
    templateUrl: './user-menu-content.component.html',
    selector: 'ndd-user-menu-content',
})
export class UserMenuContentComponent implements OnInit, OnDestroy {
    public showActionMySettings: boolean;
    public initialCurrentLang: string;
    public languages: LanguageTypes;
    public selectLanguage: boolean = false;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(
        private translationService: NDDTranslationService,
        private dialogService: NDDDialogService,
        private authTokenService: AuthenticationTokenService,
    ) { }

    public ngOnInit(): void {
        this.languages = LanguageTypes.Values;
        this.initialCurrentLang = this.getLanguageName(this.translationService.currentLang);
        // tslint:disable-next-line:no-bitwise
        if ((this.authTokenService.role & (RoleTypes.User | RoleTypes.AdministratorsOnly))
            // tslint:disable-next-line:no-bitwise
            && !(this.authTokenService.role & RoleTypes.Partner)) {
            this.showActionMySettings = true;
        }
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public changeLanguage(): void {
        this.selectLanguage = true;
    }

    public setLanguage(lang: LanguageTypes): void {
        if (this.translationService.currentLang === <any>lang) {
            this.dialogService.alert({ message: 'NDDLanguageSelectedNoHasChanged' });
            this.selectLanguage = false;
        } else {
            this.dialogService.confirm({ message: 'NDDConfirmLanguageChange' })
                .subscribe((response: boolean) => {
                    if (response) {
                        this.translationService.currentLang = <any>lang;
                        this.selectLanguage = false;
                    }
                });
        }
    }

    private getLanguageName(lang: string): string {
        const language: any = (<any>LanguageTypes.Values)
            .find((value: any) => value.id === lang);

        return language.name;
    }
}
