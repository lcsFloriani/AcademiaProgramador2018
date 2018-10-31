import { Router, ActivatedRoute } from '@angular/router';
import { Component } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { GridDataResult, DataStateChangeEvent, SelectionEvent } from '@progress/kendo-angular-grid';
import { State } from '@progress/kendo-data-query';

import { ProductService, ProductGridService } from '../shared/product.service';
import { GridUtilsComponent } from '../../../shared/grid-utils/grid-utils-component';
import { ProductDeleteCommand } from '../shared/product.model';

@Component({
    templateUrl: './product-list.component.html',
})

export class ProductListComponent extends GridUtilsComponent {
    public view: Observable<GridDataResult>;
    public productService: ProductService;
    public state: State = {
        skip: 0,
        take: 10,
    };

    constructor(private serviceGrid: ProductGridService, private service: ProductService, private router: Router,
        private route: ActivatedRoute) {
        super();
        this.view = this.serviceGrid;
        this.productService = this.service;
        this.serviceGrid.query(this.createFormattedState());
    }

    public deleteProduct(): void {
        this.serviceGrid.loading = true;
        const productToDelete: ProductDeleteCommand = new ProductDeleteCommand(this.getSelectedEntities());

        this.productService.delete(productToDelete)
            .take(1)
            .do(() => this.serviceGrid.loading = false)
            .subscribe(() => {
                this.selectedRows = [];
                this.serviceGrid.query(this.createFormattedState);
            });
    }
    public addProduct(): void {
        this.router.navigate(['create'], {
            relativeTo: this.route,
        });
    }
    public redirectOpenProduct(): void {
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
