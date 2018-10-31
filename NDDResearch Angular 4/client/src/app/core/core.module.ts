import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { NDDGridGlobalConfigModule } from 'ndd-ng-grid/config';

import { SharedModule } from '../shared/shared.module';
import { LayoutModule } from './layout/layout.module';
import { UserMenuModule } from './user-menu/user-menu.module';
import { StorageModule } from './storage/storage.module';
import { I18nModule } from './i18n/i18n.module';
import { PageReloadModule } from './page-reload/page-reload.module';
import { AuthModule } from './authentication/authentication.module';
import { ErrorInterceptorModule } from './error-interceptor/error-interceptor.module';

@NgModule({
    imports: [
        SharedModule,
        LayoutModule,
        UserMenuModule,
        StorageModule,
        I18nModule,
        AuthModule,
        PageReloadModule,
        HttpClientModule,
        ErrorInterceptorModule,
        NDDGridGlobalConfigModule.forRoot({
            i18n: true,
            defaultExportCsvIcon: 'ndd-font ndd-font-export-csv',
            defaultFileName: 'data.csv',
            gridPageSize: 50,
            headerCancelButtonText: 'SMTActions',
            headerDropdownText: 'SMTCancel',
        }),
    ],
    exports: [PageReloadModule],
    declarations: [],
    providers: [],
})

export class CoreModule {}
