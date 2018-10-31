import { NDDIntlServiceConfig } from 'ndd-ng-intl';
import { NDDTranslationConfig } from 'ndd-ng-translation';
import { NDDDialogI18nServiceConfig } from 'ndd-ng-dialog';
import { NDDButtonsI18nServiceConfig } from 'ndd-ng-buttons';
import { NDDGridI18nServiceConfig } from 'ndd-ng-grid';

import { CORE_CONFIG } from './../core.config';
import { LocalStorageKeys } from './../storage/local-storage.enum';

export const nddTranslationConfigValue: NDDTranslationConfig = {
    api: CORE_CONFIG.apiResourcesEndpoint,
    keys: {
        currentLangKey: LocalStorageKeys.CurrentLanguage,
        resourcesKey: LocalStorageKeys.Resources,
    },
};

export const nddIntlServiceConfigValue: NDDIntlServiceConfig = {
    keys: {
        cultureKey: LocalStorageKeys.CultureKey,
        currencyCultureKey: LocalStorageKeys.CurrencyCultureKey,
    },
};

export const nddKendoTranslationGridConfigValue: any = {
    GRID: {
        i18n: true,
        resources: {
            noRecords: 'NDDKendoGridNoRecords',
            pagerFirstPage: 'NDDKendoGridPagerFirstPage',
            pagerPreviousPage: 'NDDKendoGridPagerPreviousPage',
            pagerNextPage: 'NDDKendoGridPagerNextPage',
            pagerLastPage: 'NDDKendoGridPagerLastPage',
            pagerPage: 'NDDKendoGridPagerPage',
            pagerOf: 'NDDKendoGridPagerOf',
            pagerItems: 'NDDKendoGridPagerItems',
            pagerItemsPerPage: 'NDDKendoGridPagerItemsPerPage',
        },
    },
    DATEPICKER: {
        i18n: true,
        resources: {
            today: 'NDDKendoDatePickerToday',
            toggle: 'NDDKendoDatePickerToggle',
        },
    },
    TIMEPICKER: {
        i18n: true,
        resources: {
            accept: 'NDDKendoTimePickerAccept',
            acceptLabel: 'NDDKendoTimePickerAccept',
            cancel: 'NDDKendoTimePickerCancel',
            cancelLabel: 'NDDKendoTimePickerCancel',
            now: 'NDDKendoTimePickerNow',
            nowLabel: 'NDDKendoTimePickerNowLabel',
            toggle: 'NDDKendoTimePickerToggle',
        },
    },
};

export const nddDialogI18nServiceConfigValue: NDDDialogI18nServiceConfig = {
    i18n: true,
    resources: {
        alertTitle: 'NDDWarning',
        alertButton: 'NDDOk',
        confirmationTitle: 'NDDConfirmation',
        confirmationYesButton: 'NDDYes',
        confirmationNoButton: 'NDDNo',
    },
};

export const nddButtonsI18nServiceConfigValue: NDDButtonsI18nServiceConfig = {
    i18n: true,
    resources: {
        btnCancel: 'NDDCancel',
        btnSave: 'NDDSave',
        btnSaveAndCreate: 'NDDSaveCreate',
        btnSaveAndOpen: 'NDDSaveOpen',
    },
};

export const nddGridI18nServiceGonfigValue: NDDGridI18nServiceConfig = {
    i18n: true,
    resources: {
        columnLinkGoTo: 'NDDGoTo',
        searchbarPlaceholder: 'NDDSearch',
        advancedButton: 'NDDFilters',
        advancedHeaderActionApply: 'NDDApply',
        advancedHeaderActionClear: 'NDDClear',
        advancedHeaderActionHide: 'NDDHide',
        advancedHeaderActionClose: 'NDDClose',
        advancedColumnField: 'NDDField',
        advancedColumnOperator: 'NDDOperator',
        advancedColumnValue: 'NDDValue',
        advancedFooterActionNewClause: 'NDDNewClause',
        advancedOptionLogicalAnd: 'NDDAnd',
        advancedOptionLogicalOr: 'NDDOr',
        advancedOptionOperatorEquals: 'NDDEquals',
        advancedOptionOperatorContains: 'NDDContains',
        advancedOptionOperatorStartsWith: 'NDDStartsWith',
        advancedOptionOperatorEndsWith: 'NDDEndsWith',
        advancedOptionOperatorGreaterThan: 'NDDGreaterThan',
        advancedOptionOperatorGreaterThanOrEqual: 'NDDGreaterThanOrEqual',
        advancedOptionOperatorLessThan: 'NDDLessThan',
        advancedOptionOperatorLessThanOrEqual: 'NDDLessThanOrEqual',
        advancedOptionOperatorNotEquals: 'NDDNotEquals',
        advancedOptionOperatorNotContains: 'NDDNotContains',
        advancedOptionOperatorNotStartsWith: 'NDDNotStartsWith',
        advancedOptionOperatorNotEndsWith: 'NDDNotEndsWith',
    },
};
