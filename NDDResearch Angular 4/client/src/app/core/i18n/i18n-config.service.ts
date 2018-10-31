import { Injectable, EventEmitter } from '@angular/core';
import { LanguageTypes } from './i18n-language-types.model';
import { NDDIntlService } from 'ndd-ng-intl';
import { NDDTranslationService } from 'ndd-ng-translation';
import { Subject } from 'rxjs/Subject';

import { AuthenticationTokenService } from '../authentication/authentication-token.service';
import { LocalStorageService } from '../storage/local-storage.service';
import { LocalStorageKeys } from '../storage/local-storage.enum';
import { RoleTypes } from '../authentication/shared/role-types.enum';

@Injectable()
export class I18nConfigService {

    private static TRANSLATION_FETCH_DELAY: number = 500;

    public onFirstCurrentLangChanged: EventEmitter<any>;

    private document: Document;
    private navigator: Navigator;

    constructor(
        private intlService: NDDIntlService,
        private translationService: NDDTranslationService,
        private authTokenService: AuthenticationTokenService,
        private localStorageService: LocalStorageService,
    ) {
        this.document = window.document;
        this.navigator = window.navigator;
        this.onFirstCurrentLangChanged = new EventEmitter<any>();
    }

    public setLanguage(): void {
        let navLang: LanguageTypes = <any>this.localStorageService.getValue(LocalStorageKeys.CurrentLanguage);

        if (!navLang) {
            navLang = this.validateNavigatorLanguage(this.navigator.language.toLowerCase());
        }
        this.translationService.currentLang = <any>navLang;
        this.setIntlPartnerCulture(<any>navLang);
    }

    public subscribeLanguageChange(ngUnsubscribe: Subject<void>): void {
        // Monitora primeira alteração de idioma.
        this.translationService.onFirstCurrentLangChanged
            .takeUntil(ngUnsubscribe)
            .subscribe((routeParam: string) => {
                this.translationService
                    .fetch(routeParam)
                    .delay(I18nConfigService.TRANSLATION_FETCH_DELAY)
                    .take(1)
                    .subscribe(() => this.onFirstCurrentLangChanged.emit());
            });

        // Monitora alterações de idioma.
        this.translationService.onCurrentLangChanged
            .takeUntil(ngUnsubscribe)
            .subscribe((routeParam: string) => {
                this.setIntlPartnerCulture(routeParam);
                this.document.location.reload();
            });
    }

    private setIntlPartnerCulture(culture: string): void {
        // tslint:disable-next-line:no-bitwise
        if (this.authTokenService.role & RoleTypes.Partner) {
            this.intlService.culture = culture;
        }
    }

    private validateNavigatorLanguage(navLang: string): LanguageTypes {
        switch (navLang) {
            case LanguageTypes.English.toString():
                return LanguageTypes.English;
            case LanguageTypes.Spanish.toString():
                return LanguageTypes.Spanish;
            case LanguageTypes.Portuguese.toString():
                return LanguageTypes.Portuguese;
            default:
                break;
        }
        if (navLang.includes('en')) {
            return LanguageTypes.English;
        } else if (navLang.includes('es')) {
            return LanguageTypes.Spanish;
        } else if (navLang.includes('pt')) {
            return LanguageTypes.Portuguese;
        } else {
            return LanguageTypes.Portuguese;
        }
    }
}
