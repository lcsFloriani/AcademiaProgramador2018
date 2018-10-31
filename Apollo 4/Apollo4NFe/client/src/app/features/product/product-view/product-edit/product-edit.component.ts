import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Component, ChangeDetectionStrategy, OnInit} from '@angular/core';
import { Subject } from 'rxjs/Subject';

import { Product } from '../../shared/product.model';
import { ProductValidator } from '../../shared/product.validator';
import { ProductUpdateCommand } from './../../shared/product.model';
import { ProductService, ProductResolveService } from '../../shared/product.service';
@Component({
    selector: 'ndd-product-edit',
    changeDetection: ChangeDetectionStrategy.OnPush,
    templateUrl: './product-edit.component.html',
})
export class ProductEditComponent implements OnInit {
    public product: Product;
    public isLoading: boolean = true;
    public index: number = 16;
    private ngUnsubscribe: Subject<void> = new Subject<void>();
    // tslint:disable-next-line:member-ordering
    public formModel: FormGroup = this.fb.group({
        id: ['', Validators.required],
        code: ['', Validators.required],
        description: ['', [Validators.required]],
        unitaryValue: ['', [Validators.required, ProductValidator.checkValueEmpty]],
    });

    constructor(private fb: FormBuilder, private resolver: ProductResolveService,
        private productServ: ProductService,
        private router: Router,
        private route: ActivatedRoute) {}

    public ngOnInit(): void {
        this.resolver.onChanges
        .takeUntil(this.ngUnsubscribe)
        .subscribe((product: Product) => {
            this.product = Object.assign(new Product(), product);
            this.formModel.setValue({
                id: this.product.id,
                code: this.product.code,
                description: this.product.description,
                unitaryValue: this.product.unitaryValue,
              });
            this.isLoading = false;
        });
   }
   public redirect(): void {
    this.router.navigate(['/'], { relativeTo: this.route });
   }
   public onEdit(event: Event): void {
        const command: ProductUpdateCommand = Object.assign(new ProductUpdateCommand(), this.formModel.value);
        this.productServ.put(command)
        .take(1)
        .subscribe((x: any) => {
        this.redirect();
    });
   }
}
