import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs/Subject';

import 'rxjs/add/observable/of';
import 'rxjs/add/observable/throw';
import 'rxjs/add/observable/empty';
import 'rxjs/add/operator/takeUntil';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/filter';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/delay';
import 'rxjs/add/operator/take';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/switchMap';

import { I18nConfigService } from './core/i18n/i18n-config.service';

@Component({
    selector: 'ndd-app',
    templateUrl: './app.component.html',
})
export class AppComponent implements OnInit, OnDestroy {

    public showLoader: boolean = true;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(
        private i18nConfigService: I18nConfigService,
    ) {}

    public ngOnInit(): void {
        // Configuração para exibir/ocultar o carregamento inicial
        this.i18nConfigService.onFirstCurrentLangChanged
            .takeUntil(this.ngUnsubscribe)
            .subscribe((): void => {
                // Oculta loader carregado na navegação inicial.
                this.showLoader = false;
            });
        this.i18nConfigService.subscribeLanguageChange(this.ngUnsubscribe);
        this.i18nConfigService.setLanguage();
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }
}
