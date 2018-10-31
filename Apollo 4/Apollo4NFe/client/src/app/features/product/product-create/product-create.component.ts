import { Component, ChangeDetectionStrategy, EventEmitter } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { ProductService } from '../shared/product.service';
import { ProductRegisterCommand } from '../shared/product.model';
import { ProductValidator } from '../shared/product.validator';

@Component({
    templateUrl: './product-create.component.html',
    changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ProductCreateComponent {
    public infoItems: object[];
    public title: string = 'Criar Produto';
    public submit: EventEmitter<FormGroup>;
    public formModel: FormGroup = this.fb.group({
        code: ['', Validators.required],
        description: ['', [Validators.required]],
        unitaryValue: ['', [Validators.required, ProductValidator.checkValueEmpty]],
    });
    constructor(private fb: FormBuilder, private productServ: ProductService,
                private router: Router,
                private route: ActivatedRoute) { }

    public redirect(): void {
        this.router.navigate(['../'], { relativeTo: this.route });
    }
    public onCreate(event: Event): void {
        const command: ProductRegisterCommand = Object.assign(new ProductRegisterCommand(), this.formModel.value);
        this.productServ.post(command)
        .take(1)
        .subscribe((x: any) => {
            this.redirect();
        });
    }

}
