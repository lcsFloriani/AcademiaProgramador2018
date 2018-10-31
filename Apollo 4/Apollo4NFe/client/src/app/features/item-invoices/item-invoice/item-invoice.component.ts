import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { SelectionEvent, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { Subject } from 'rxjs/Subject';

import { Product } from '../../product/shared/product.model';
import { Invoice } from '../../invoice/shared/invoice.model';
import { ItemInvoiceDeleteCommand } from '../shared/item-invoice.model';
import { InvoiceResolveService } from '../../invoice/shared/invoice.service';
import { GridUtilsComponent } from '../../../shared/grid-utils/grid-utils-component';
import { ItemInvoice, ItemInvoiceRegisterCommand } from '../shared/item-invoice.model';
import { ItemInvoiceService } from '../shared/item-invoice-shared/item-invoice.service';
import { ProductDropdownService } from '../shared/item-invoice-shared/item-invoice.service';

@Component({
    templateUrl: './item-invoice.component.html',
})

export class ItemInvoiceComponent extends GridUtilsComponent implements OnInit {
    public title: string;
    public isLoading: boolean;
    public data: Product[];
    public trezentos: number = 300;
    public productList: ItemInvoice[] = [];
    public invoice: Invoice;
    public totalProducts: number = 0;
    public productAlreadyExist: boolean = false;
    public formModel: FormGroup = this.fb.group({
        product: ['', Validators.required],
        quantity: ['', Validators.required],
    });
    private onFilterChange: Subject<string> = new Subject<string>();
    private ngUnsubscribe: Subject<void> = new Subject<void>();
    constructor(private fb: FormBuilder,
        private productService: ProductDropdownService,
        private resolver: InvoiceResolveService,
        private service: ItemInvoiceService) {
        super();
    }

    public ngOnInit(): void {
        this.title = 'Inserir Produto';
        this.isLoading = false;
        this.invoice = new Invoice();
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((invoice: Invoice) => {
                this.invoice = invoice;
                this.productList = invoice.items;
                this.calculateTotal();
            });

        this.onFilterChange
            .debounceTime(this.trezentos)
            .do((value: any) => {
                this.productService.query(value);
            })
            .switchMap((value: any, index: number) => this.productService)
            .subscribe((response: any[]) => {
                this.data = response;
            });
    }

    public onSelectionChange(event: SelectionEvent): void {
        this.updateSelectedRows(event.selectedRows, true);
        this.updateSelectedRows(event.deselectedRows, false);
    }

    public dataStateChange(state: DataStateChangeEvent): void {
        this.state = state;
        this.selectedRows = [];
    }

    public onAutoCompleteChange(value: string): void {
        this.onFilterChange.next(value);
        this.productAlreadyExist = false;
    }

    public onAddItem(): void {
        const product: Product = this.data.filter((product: Product) => product.description === this.formModel.value.product)[0];
        const items: ItemInvoice[] = this.productList.filter((i: ItemInvoice) => i.product.id === product.id);
        if (items.length > 0) {
            this.productAlreadyExist = true;
        } else {
            this.productAlreadyExist = false;
            this.novoProduto(product);
        }
    }
    public onRemoveItem(): void {
        const itemsToDelete: ItemInvoiceDeleteCommand = new ItemInvoiceDeleteCommand(this.invoice.id, this.getSelectedEntities());

        this.service.delete(itemsToDelete)
            .take(1)
            .subscribe(() => {
                this.resolver.resolveFromRouteAndNotify();
            });
        this.calculateTotal();
    }

    private cleanFields(): void {
        this.formModel.reset();
    }

    private calculateTotal(): void {
        if (this.productList.length <= 0) {
            this.totalProducts = 0;
        }
        for (const itemInvoice of this.productList) {
            this.totalProducts += ItemInvoice.calcTotal(itemInvoice.product.unitaryValue, itemInvoice.quantity);
        }
    }

    private novoProduto(product: Product): void {
        const quantity: number = this.formModel.value.quantity;
        const item: ItemInvoice = new ItemInvoice();
        item.product = product;
        item.quantity = quantity;
        const itemInvoice: ItemInvoiceRegisterCommand = new ItemInvoiceRegisterCommand(this.invoice.id, item);
        this.service.post(itemInvoice)
            .take(1)
            .subscribe(() => {
                this.isLoading = true;
                this.resolver.resolveFromRouteAndNotify();
            });
        this.calculateTotal();
        this.cleanFields();
    }
}
