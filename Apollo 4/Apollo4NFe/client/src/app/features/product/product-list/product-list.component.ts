import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { State } from '@progress/kendo-data-query';
import { GridDataResult, SelectableSettings, SelectionEvent, DataStateChangeEvent } from '@progress/kendo-angular-grid';

import { ProductDeleteCommand, Product } from '../shared/product.model';
import { ProductService, QueryService } from '../shared/product.service';
import { GridUtilsComponent } from '../../../shared/grid-utils/grid-utils-component';
@Component({
    templateUrl: './product-list.component.html',
})
export class ProductListComponent extends GridUtilsComponent {
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
        private productServ: ProductService,
        private queryService: QueryService,
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

    public redirectOpenProduct(): void {
        this.router.navigate(['./', `${this.getSelectedEntities()[0].id}`], { relativeTo: this.route });
    }

    public redirectOpenProductLink(product: Product): void {
        this.router.navigate(['./', `${product.id}`],
            { relativeTo: this.route });
    }

    public deleteProduct(): void {
        const command: ProductDeleteCommand = new ProductDeleteCommand(this.getSelectedEntities());
        this.productServ.remove(command)
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
