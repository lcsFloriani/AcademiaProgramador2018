import { Component } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { GridDataResult, DataStateChangeEvent, SelectionEvent } from '@progress/kendo-angular-grid';
import { State } from '@progress/kendo-data-query';
import { Router, ActivatedRoute } from '@angular/router';

import { GridUtilsComponent } from '../../../shared/grid-utils/grid-utils-component';
import { OrderService, OrderGridService } from '../shared/order-service';
import { OrderDeleteCommand } from '../shared/order-model';

@Component({
    templateUrl: './order-list.component.html',
})

export class OrderListComponent extends GridUtilsComponent {
    public view: Observable<GridDataResult>;
    public orderService: OrderService;
    public state: State = {
        skip: 0,
        take: 10,
    };

    constructor(private serviceGrid: OrderGridService, private service: OrderService, private router: Router,
        private route: ActivatedRoute) {
        super();
        this.view = this.serviceGrid;
        this.orderService = this.service;
        this.serviceGrid.query(this.createFormattedState());
    }
    public deleteOrder(): void {
        this.serviceGrid.loading = true;
        const orderToDelete: OrderDeleteCommand = new OrderDeleteCommand(this.getSelectedEntities());

        this.orderService.delete(orderToDelete)
            .take(1)
            .do(() => this.serviceGrid.loading = false)
            .subscribe(() => {
                this.selectedRows = [];
                this.serviceGrid.query(this.createFormattedState);
            });
    }
    public addOrder(): void {
        this.router.navigate(['create'], {
            relativeTo: this.route,
        });
    }
    public redirectOpenOrder(): void {
        this.router.navigate(['./', `${this.getSelectedEntities()[0].id}`], { relativeTo: this.route });
    }

    public dataStateChange(state: DataStateChangeEvent): void {
        this.state = state;
        this.serviceGrid.query(this.createFormattedState());
        this.selectedRows = [];
    }

    public onSelectionChange(event: SelectionEvent): void {
        this.updateSelectedRows(event.selectedRows, true);
        this.updateSelectedRows(event.deselectedRows, false);
    }
}
