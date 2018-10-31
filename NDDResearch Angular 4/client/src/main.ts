import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { enableProdMode } from '@angular/core';
import { AppModule } from './app/app.module';

import './main.scss';
import './app/shared/fonts/ndd-ng-icon.font';

/* Intl */

// Brasil
import '@progress/kendo-angular-intl/locales/pt/all';
// Alemanha
import '@progress/kendo-angular-intl/locales/de/all';
// Espanha
import '@progress/kendo-angular-intl/locales/es/all';
// Estados Unidos
import '@progress/kendo-angular-intl/locales/en/all';
// França
import '@progress/kendo-angular-intl/locales/fr/all';

((): void => {
    if (ENV === 'production') {
        enableProdMode();
    }

    platformBrowserDynamic().bootstrapModule(AppModule);
})();
