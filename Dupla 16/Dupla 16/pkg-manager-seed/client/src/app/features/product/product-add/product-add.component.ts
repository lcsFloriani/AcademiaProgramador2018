import { ProductValidators } from './../shared/product.validators';

import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Product, ProductRegisterCommand } from '../shared/product.model';
import { FormArray, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { ProductService } from '../shared/product.service';
import { Router } from '@angular/router';
@Component({
    templateUrl: './product-add.component.html',
})

export class ProductAddComponent {

    public title: string = 'Criar Produtos';

    private form: FormGroup = this.fb.group({
        name: ['', Validators.required],
        sale: ['', Validators.required],
        expense: ['', Validators.required],
        isAvailable: ['', Validators.required],
        manufacture: ['', Validators.required],
        expiration: ['', Validators.required],
    }, { validator: ProductValidators.checkDatas });

    constructor(private fb: FormBuilder, private service: ProductService, private router: Router) {
    }

    public onSubmit(): void {
        const cmd: ProductRegisterCommand = new ProductRegisterCommand(this.form.value);
        this.service.post(cmd)
        .take(1)
        .subscribe(() => {
            this.router.navigate(['produtos']);
        });
    }
}
