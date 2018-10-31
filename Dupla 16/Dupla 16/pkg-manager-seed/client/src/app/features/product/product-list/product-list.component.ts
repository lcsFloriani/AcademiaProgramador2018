
import { ProductGridService, ProductService } from './../shared/product.service';
import { ActivatedRoute, Router } from '@angular/router';
import { GridUtilsComponent } from './../../../shared/grid-utils/grid-utils-component';
import { Component } from '@angular/core';
import { State } from '@progress/kendo-data-query/dist/es/main';
import { DataStateChangeEvent, SelectionEvent } from '@progress/kendo-angular-grid';
import { ProductRemoveCommand, Product } from '../shared/product.model';

@Component({
    templateUrl: './product-list.component.html',
})

export class ProductListComponent extends GridUtilsComponent {

    [x: string]: any;
    public state: State = {
        skip: 0,
        take: 10,
    };

    constructor(private gridService: ProductGridService, private product: ProductService, private router: Router, private route: ActivatedRoute) {
        super();
        this.gridService.query(this.createFormattedState());
    }

    public redirectOpenProduct(): void {
        this.router.navigate(['./', `${this.getSelectedEntities()[0].id}`], { relativeTo: this.route });
    }

    public redirectAddProduct(): void {
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

    public deleteProduct(): void {
        const entities: Product[] = this.getSelectedEntities();

        const produtosToDelete: ProductRemoveCommand = new ProductRemoveCommand();

        produtosToDelete.productIds = entities.map((p: Product) => p.id);

        this.product.deleteProducts(produtosToDelete)
            .take(1)
            .do(() => this.gridService.loading = false)
            .subscribe(() => {
                this.selectedRows = [];
                this.gridService.query(this.createFormattedState());
            });
    }
}
