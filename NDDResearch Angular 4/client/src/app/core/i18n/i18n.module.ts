import { NgModule } from '@angular/core';
import { NDDTranslationConfig } from 'ndd-ng-translation';
import { NDDDialogI18nServiceConfig } from 'ndd-ng-dialog';
import {
    NDDI18nKendoTranslationGridServiceConfig,
    NDDI18nKendoTranslationDatePickerServiceConfig,
    NDDI18nKendoTranslationTimePickerServiceConfig,
} from 'ndd-ng-kendo-translation';
import { NDDButtonsI18nServiceConfig } from 'ndd-ng-buttons';
import { NDDGridI18nServiceConfig } from 'ndd-ng-grid';

import { SharedModule } from '../../shared/shared.module';
import { I18nConfigService } from './i18n-config.service';
import {
    nddTranslationConfigValue,
    nddKendoTranslationGridConfigValue,
    nddDialogI18nServiceConfigValue,
    nddButtonsI18nServiceConfigValue,
    nddGridI18nServiceGonfigValue,
    nddIntlServiceConfigValue,
} from './i18n-resources.config';
import { NDDIntlServiceConfig } from 'ndd-ng-intl';

@NgModule({
    imports: [SharedModule],
    exports: [],
    declarations: [],
    providers: [
        I18nConfigService,
        { provide: NDDTranslationConfig, useValue: nddTranslationConfigValue },
        { provide: NDDButtonsI18nServiceConfig, useValue: nddButtonsI18nServiceConfigValue },
        { provide: NDDDialogI18nServiceConfig, useValue: nddDialogI18nServiceConfigValue },
        { provide: NDDGridI18nServiceConfig, useValue: nddGridI18nServiceGonfigValue },
        { provide: NDDIntlServiceConfig, useValue: nddIntlServiceConfigValue },
        // Kendo Translation
        { provide: NDDI18nKendoTranslationGridServiceConfig, useValue: nddKendoTranslationGridConfigValue.GRID },
        { provide: NDDI18nKendoTranslationDatePickerServiceConfig, useValue: nddKendoTranslationGridConfigValue.DATEPICKER },
        { provide: NDDI18nKendoTranslationTimePickerServiceConfig, useValue: nddKendoTranslationGridConfigValue.TIMEPICKER },
    ],
})
export class I18nModule { }
