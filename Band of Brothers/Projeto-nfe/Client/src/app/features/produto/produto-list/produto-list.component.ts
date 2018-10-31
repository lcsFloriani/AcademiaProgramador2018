import { Router, ActivatedRoute } from '@angular/router';
import { Component } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { GridDataResult, DataStateChangeEvent, SelectionEvent } from '@progress/kendo-angular-grid';
import { State } from '@progress/kendo-data-query';

import { ProdutoGridService } from '../shared/produto.grid.service';
import { ProdutoService } from '../shared/produto.service';
import { GridUtilsComponent } from '../../../shared/grid-utils/grid-utils-component';
/*import { ProdutoDeleteCommand } from '../shared/produto.model';
*/
@Component({
    templateUrl: './produto-list.component.html',
})

export class ProdutoListComponent extends GridUtilsComponent {
    public view: Observable<GridDataResult>;
    public produtoService: ProdutoService;
    public state: State = {
        skip: 0,
        take: 10,
    };

    constructor(private serviceGrid: ProdutoGridService, private service: ProdutoService, private router: Router,
        private route: ActivatedRoute) {
        super();
        this.view = this.serviceGrid;
        this.produtoService = this.service;
        this.serviceGrid.query(this.createFormattedState());
    }

 /*   public deleteProduto(): void {
        this.serviceGrid.loading = true;
        const produtoToDelete: ProdutoDeleteCommand = new ProdutoDeleteCommand(this.getSelectedEntities());

        this.produtoService.delete(produtoToDelete)
            .take(1)
            .do(() => this.serviceGrid.loading = false)
            .subscribe(() => {
                this.selectedRows = [];
                this.serviceGrid.query(this.createFormattedState());
            });
    }
    */
    public addproduto(): void {
        this.router.navigate(['create'], {
            relativeTo: this.route,
        });
    }
    public redirectOpenProduto(): void {
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
