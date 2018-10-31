import { Injectable } from '@angular/core';

import { INDDGridColumn } from 'ndd-ng-grid';

@Injectable()
export class SiteGridColumns {
    public getGridColumns(customerId: number): INDDGridColumn[] {
        return [
            {
                icons: [
                    {
                        fontClass: 'ndd-font ndd-font-check',
                        tooltipText: 'NDDSiteDefault',
                        i18n: true,
                        conditions: [
                            { paramName: 'isDefault', valueExpected: true },
                        ],
                    },
                ],
                hideWhenResponsive: true,
            },
            {
                field: 'name',
                title: 'NDDName',
                routerLink: { router: `/customers/${ customerId }/sites`, paramName: 'id' },
                titleI18n: true,
            },
            {
                field: 'address.country',
                title: 'NDDCountry',
                titleI18n: true,
            },
            {
                field: 'address.state',
                title: 'NDDState',
                titleI18n: true,
            },
            {
                field: 'address.city',
                title: 'NDDCity',
                titleI18n: true,
            },
            {
                field: 'address.street',
                title: 'NDDAddress',
                titleI18n: true,
            },
        ];
    }
}
