import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import {
    INDDGrid,
    INDDGridHeader,
    NDDGridBuilderService,
} from 'ndd-ng-grid';
import { NDDDialogService } from 'ndd-ng-dialog';

import { Customer, CustomerDeleteCommand } from '../shared/model/customer.model';
import { CustomerService } from './../shared/customer.service';
import { CustomerGridService } from '../shared/customer.service';
import { CustomerActionFields } from './values/customer-action-fields.model';
import { customerFilterSearchbar } from './values/customer-filter-searchbar.model';
import { customerGridColumns } from './values/customer-grid-columns.model';
import { Subject } from 'rxjs/Subject';

@Component({
    templateUrl: './customer-list.component.html',
})
export class CustomerListComponent implements OnInit, OnDestroy {
    public gridOptions: INDDGrid = <INDDGrid>{};
    public gridHeaderOptions: INDDGridHeader = <INDDGridHeader>{};
    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(
        private customerGridService: CustomerGridService,
        private customerService: CustomerService,
        private gridBuilder: NDDGridBuilderService,
        public router: Router,
        private dialogService: NDDDialogService,
        private customerActionFields: CustomerActionFields) {

        this.customerActionFields.onDelete
            .takeUntil(this.ngUnsubscribe)
            .subscribe((customers: Customer[]): void => {
                this.delete(customers);
            });
    }

    public ngOnInit(): void {
        this.gridOptions = this.gridBuilder.getBuilder()
            .identifier('customer-list-grid')
            .columns(customerGridColumns)
            .sourceService(this.customerGridService)
            .sort('name')
            .sortable()
            .withExportCSV()
            .build();

        this.gridHeaderOptions = this.gridBuilder.getHeaderBuilder()
                .actions(this.customerActionFields.getCustomerActionFields(this.router))
                .filter(customerFilterSearchbar)
                .build();
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public selection(items: Customer[]): void {
        this.customerActionFields.setSelection(items);
    }

    private delete(customers: Customer[]): void {
        this.dialogService.confirm({ message: 'NDDConfirmRemoveCustomer', yesButton: 'NDDConfirmDialog', noButton: 'NDDCancel' })
            .subscribe((response: boolean) => {
                if (response) {
                    this.customerService
                        .delete(new CustomerDeleteCommand(customers))
                        .takeUntil(this.ngUnsubscribe)
                        .subscribe((data: any) => {
                            this.customerGridService.refresh();
                        }, (err: any) => this.error(err));
                }
            });
    }

    private error(err: any): void {
        const forbiddenErrorCode: number = 403;

        if (err.error.errorCode === forbiddenErrorCode) {
            this.dialogService.alert({ message: 'NDDCantRemoveDivision' });
        }
    }
}
