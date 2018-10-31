import { INDDGridFilterSearchbarOptions } from 'ndd-ng-grid';
import { NDDFilterTypes } from 'ndd-ng-odata-query-filter';

export const customerFilterSearchbar: INDDGridFilterSearchbarOptions[] = [
    {
        field: 'name',
        type: NDDFilterTypes.String,
    },
    {
        field: 'displayName',
        type: NDDFilterTypes.String,
    },
];
