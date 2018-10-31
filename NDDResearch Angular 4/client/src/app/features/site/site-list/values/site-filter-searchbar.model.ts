import { INDDGridFilterSearchbarOptions } from 'ndd-ng-grid';
import { NDDFilterTypes } from 'ndd-ng-odata-query-filter';

export const siteFilterSearchbar: INDDGridFilterSearchbarOptions[] = [
    {
        field: 'name',
        type: NDDFilterTypes.String,
    },
];
