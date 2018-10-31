import { INDDGridColumn } from 'ndd-ng-grid';

export const customerGridColumns: INDDGridColumn[] = [
    {
        field: 'name',
        title: 'NDDName',
        titleI18n: true,
        titleWhenResponsive: true,
        routerLink: { router: '/customers', paramName: 'id' },
        width: '200px',
    },
    {
        field: 'displayName',
        title: 'NDDDisplayName',
        titleI18n: true,
    },
];
