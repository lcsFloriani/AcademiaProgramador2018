import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { GridDataResult, SelectableSettings, DataStateChangeEvent, SelectionEvent } from '@progress/kendo-angular-grid';
import { State } from '@progress/kendo-data-query';

import { InvoiceDeleteCommand, Invoice } from '../shared/invoice.model';
import { InvoiceService, InvoiceGridService } from '../shared/invoice.service';
import { GridUtilsComponent } from '../../../shared/grid-utils/grid-utils-component';

@Component({
    templateUrl: './invoice-list.component.html',
})
export class InvoiceListComponent extends GridUtilsComponent {
    public view: Observable<GridDataResult>;
    public mode: any = 'single';
    public checkboxOnly: any = true;
    public selectableSettings: SelectableSettings;
    public selectedKeys: number[] = [];
    public state: State = {
        skip: 0,
        take: 13,
    };
    constructor(
        private productServ: InvoiceService,
        private queryService: InvoiceGridService,
        private router: Router,
        private route: ActivatedRoute) {
        super();
        this.view = queryService;
        this.queryService.query(this.createFormattedState());
        this.setSelectableSettings();
    }
    public onClick(): void {
        this.router.navigate(['create'], { relativeTo: this.route });
    }

    public addItemInvoice(): void {
        this.router.navigate([`${this.getSelectedEntities()[0].id}`, 'addItemInvoice'], { relativeTo: this.route });
    }

    public redirectOpenInvoice(): void {
        this.router.navigate(['./', `${this.getSelectedEntities()[0].id}`], { relativeTo: this.route });
    }

    public redirectOpenInvoiceLink(invoice: Invoice): void {
        this.router.navigate(['./', `${invoice.id}`],
            { relativeTo: this.route });
    }

    public deleteInvoice(): void {
        const command: InvoiceDeleteCommand = new InvoiceDeleteCommand(this.getSelectedEntities());
        this.productServ.delete(command)
            .take(1)
            .subscribe((x: any) => {
                this.selectedRows = [];
                this.queryService.query(this.createFormattedState());
            });
    }

    public setSelectableSettings(): void {
        this.selectableSettings = {
            checkboxOnly: this.checkboxOnly,
            mode: this.mode,
        };
    }

    public onSelectionChange(event: SelectionEvent): void {
        this.updateSelectedRows(event.selectedRows, true);
        this.updateSelectedRows(event.deselectedRows, false);
    }

    public dataStateChange(state: DataStateChangeEvent): void {
        this.state = state;
        this.queryService.query(this.createFormattedState());
    }
}
