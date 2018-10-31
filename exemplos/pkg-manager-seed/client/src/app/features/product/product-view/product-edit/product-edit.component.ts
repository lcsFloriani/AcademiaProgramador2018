import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { ProductService, ProductResolveService } from '../../shared/product.service';
import { Product, ProductEditCommand } from '../../shared/product.model';
import { Subject } from 'rxjs/Subject';

@Component({
    templateUrl: './product-edit.component.html',
})

export class ProductEditComponent implements OnInit {
    public product: Product;
    public productService: ProductService;
    public isLoading: boolean = false;
    public title: string = 'Editar Produto';

    public productEditForm: FormGroup = this.fb.group({
        id: ['', Validators.required],
        name: ['', Validators.required],
        sale: ['', Validators.required],
        expense: ['', Validators.required],
        isAvailable: ['', Validators.required],
        manufacture: ['', [Validators.required]],
        expiration: ['', [Validators.required]],
    });
    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private fb: FormBuilder,
        private service: ProductService,
        private resolver: ProductResolveService,
        private router: Router,
        private route: ActivatedRoute) {
        this.productService = this.service;
    }

    public ngOnInit(): void {
        const index: number = 16;
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((product: Product) => {
                this.isLoading = false;
                this.product = Object.assign(new Product(), product);
                this.productEditForm.setValue({
                    id: this.product.id,
                    name: this.product.name,
                    sale: this.product.sale,
                    expense: this.product.expense,
                    isAvailable: this.product.isAvailable,
                    manufacture: new Date(this.product.manufacture).toISOString().slice(0, index),
                    expiration: new Date(this.product.expiration).toISOString().slice(0, index),
                });
            });

    }
    public redirect(): void {
        this.router.navigate(['../'], { relativeTo: this.route });
    }

    public onEdit(): void {
        const productEdit: ProductEditCommand = new ProductEditCommand(this.productEditForm.value);
        this.isLoading = true;
        this.productService.put(productEdit)
            .take(1)
            .subscribe(() => {
                this.isLoading = false;
                this.resolver.resolveFromRouteAndNotify();
                this.redirect();
            });
    }
}
