import { Router } from '@angular/router';
import { Injectable, EventEmitter } from '@angular/core';

import { INDDGridHeaderAction } from 'ndd-ng-grid';
import { Customer } from '../../shared/model/customer.model';

@Injectable()
export class CustomerActionFields {
    public onDelete: EventEmitter<Customer[]> = new EventEmitter();
    private customers: Customer[];

    public getCustomerActionFields(router: Router): INDDGridHeaderAction[] {
        return [
            {
                id: 'customer-list-actions-create',
                name: 'NDDCreate',
                icon: 'ndd-font ndd-font-create',
                i18n: true,
                callback: (): void => {
                    router.navigate([`/customers/create`]);
                },
            },
            {
                id: 'customer-list-actions-delete',
                name: 'NDDDelete',
                icon: 'ndd-font ndd-font-delete',
                i18n: true,
                callback: (): void => {
                    this.onDelete.emit(this.customers);
                },
                needSingleGridRowSelected: true,
                needMultiGridRowSelected: true,
            },
            {
                id: 'customer-list-actions-open',
                name: 'NDDOpen',
                icon: 'ndd-font ndd-font-open',
                i18n: true,
                callback: (): void => {
                    router.navigate([`/customers/${ this.customers[0].id }`]);
                },
                needSingleGridRowSelected: true,
            },
        ];
    }

    public setSelection(customers: Customer[]): void {
        this.customers = customers;
    }
}
