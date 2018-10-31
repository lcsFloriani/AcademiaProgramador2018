import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { DataStateChangeEvent, SelectionEvent } from '@progress/kendo-angular-grid';

import { ReceiverDeleteCommand, Receiver } from '../shared/receiver.model';
import { GridUtilsComponent } from '../../../shared/grid-utils/grid-utils-component';
import { ReceiverGridService, ReceiverService } from '../shared/receiver-shared/receiver.service';
@Component({
    templateUrl: './receiver-list.component.html',
})
export class ReceiverListComponent extends GridUtilsComponent {

    constructor(
        private receiverService: ReceiverService,
        public gridService: ReceiverGridService,
        private router: Router,
        private route: ActivatedRoute) {
        super();
        this.gridService.query(this.createFormattedState());
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

    public redirectOpenReceiver(): void {
        this.router.navigate(['./', `${this.getSelectedEntities()[0].id}`],
            { relativeTo: this.route });
    }

    public redirectOpenReceiverLink(receiver: Receiver): void {
        this.router.navigate(['./', `${receiver.id}`],
            { relativeTo: this.route });
    }

    public deleteReceiver(): void {

        this.gridService.loading = true;

        const command: ReceiverDeleteCommand = new ReceiverDeleteCommand(this.getSelectedEntities());
        this.receiverService.remove(command)
            .take(1).do(() => {
                this.gridService.loading = false;
            })
            .subscribe((x: any) => {
                this.selectedRows = [];
                this.gridService.query(this.createFormattedState());
            },  (err: HttpErrorResponse) => {
                // Erro de chamada http.
                this.gridService.loading = false;
                alert('Ocorreu um problema, na conexão com o servidor!');
            });
    }
}
