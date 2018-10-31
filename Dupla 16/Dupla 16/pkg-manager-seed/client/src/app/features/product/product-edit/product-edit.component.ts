import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs/Subject';
import { relative } from 'path';

import { ProductValidators } from '../shared/product.validators';
import { ProductService, ProductResolveService } from '../shared/product.service';
import { ProductUpdateCommand, Product } from '../shared/product.model';

@Component({
    templateUrl: './product-edit.component.html',
})

export class ProductEditComponent implements OnInit, OnDestroy {

    public product: Product;
    private ngUnsubscribe: Subject<void> = new Subject<void>();
    private formEdit: FormGroup = this.fb.group({
        name: ['', Validators.required],
        sale: ['', Validators.required],
        expense: ['', Validators.required],
        isAvailable: ['', Validators.required],
        manufacture: ['', Validators.required],
        expiration: ['', Validators.required],
    }, { validator: ProductValidators.checkDatas });

    constructor(private resolver: ProductResolveService, private fb: FormBuilder,
        private service: ProductService, private router: Router, private route: ActivatedRoute) {
    }
    public ngOnInit(): void {
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((product: Product) => {
                this.product = Object.assign(new Product(), product);
                this.formEdit.patchValue({
                    name: product.name,
                    sale: product.sale,
                    expense: product.expense,
                    isAvailable: product.isAvailable,
                    manufacture: new Date(product.manufacture).toISOString().split('T')[0],
                    expiration: new Date(product.expiration).toISOString().split('T')[0],
                });
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public onSubmit(): void {
        const cmd: ProductUpdateCommand = new ProductUpdateCommand(this.formEdit.value);
        cmd.id = this.product.id,
            this.service.put(cmd)
                .take(1)
                .subscribe(() => {
                    this.resolver.resolveFromRouteAndNotify();
                    this.router.navigate(['../'], { relativeTo: this.route });
                });
    }

}
