import { Component } from '@angular/core';
import { GridUtilsComponent } from '../../../shared/grid-utils/grid-utils-component';
import { State } from '@progress/kendo-data-query/dist/es/main';
import { OrderGridService, OrderService } from '../shared/order.service';
import { Router, ActivatedRoute } from '@angular/router';
import { DataStateChangeEvent, SelectionEvent } from '@progress/kendo-angular-grid';
import { Order, OrderRemoveCommand } from '../shared/order.model';

@Component({
    templateUrl: './order-list.component.html',
})

export class OrderListComponent extends GridUtilsComponent {

    [x: string]: any;
    public state: State = {
        skip: 0,
        take: 10,
    };

    constructor(private gridService: OrderGridService, private order: OrderService, private router: Router, private route: ActivatedRoute,) {
        super();
        this.gridService.query(this.createFormattedState());
    }

    public redirectOpenOrder(): void {
        this.router.navigate(['./', `${this.getSelectedEntities()[0].id}`], { relativeTo: this.route });
    }

    public redirectAddOrder(): void {
        this.router.navigate(['./', `adicionar`], { relativeTo: this.route });
    }

    public dataStateChange(state: DataStateChangeEvent): void {
        this.state = state;
        this.gridService.query(this.createFormattedState());
        this.selectedRows = [];
    }

    public onSelectionChange(event: SelectionEvent): void {
        this.updateSelectedRows(event.selectedRows, true);
        this.updateSelectedRows(event.deselectedRows, false);
    }

    public deleteOrder(): void {
        const entities: Order[] = this.getSelectedEntities();

        const ordersToDelete: OrderRemoveCommand = new OrderRemoveCommand();

        ordersToDelete.orderIds = entities.map((o: Order) => o.id);

        this.order.deleteOrders(ordersToDelete)
            .take(1)
            .do(() => this.gridService.loading = false)
            .subscribe(() => {
                this.selectedRows = [];
                this.gridService.query(this.createFormattedState());
            });
    }
}
