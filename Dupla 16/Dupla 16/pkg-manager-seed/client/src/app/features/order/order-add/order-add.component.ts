import { ProductService } from './../../product/shared/product.service';
import { Order } from './../shared/order.model';
import { Component } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Router } from '@angular/router';
import { OrderService } from '../shared/order.service';
import { OrderRegisterCommand } from '../shared/order.model';
import { Observable } from 'rxjs/Observable';
import { Product } from '../../product/shared/product.model';

@Component({
    templateUrl: './order-add.component.html',
})

export class OrderAddComponent {

    public data: Product[];
    public title: string = 'Criar Vendas';
    public order: Order;
    public total: number = 0;
    private view: Observable<any>;
    private form: FormGroup;

    constructor(private fb: FormBuilder, private service: OrderService, private router: Router,
        private productService: ProductService) {
        this.form = this.fb.group({
            customer: ['', Validators.required],
            quantity: ['', Validators.required],
            product: [null, Validators.required],
        });
    }

    public getCalculate(): void {
        this.total = this.order.calculateTotal();
    }
    public onSubmit(): void {
        const cmd: OrderRegisterCommand = new OrderRegisterCommand(this.form.value);
        this.service.post(cmd)
            .take(1)
            .subscribe(() => {
                this.router.navigate(['produtos']);
            });
    }

    public onAutoCompleteChange(value: string): void {
        Observable.of(value)
            .delay(300)
            .switchMap((value: string, index: number) => this.productService.getByName(value))
            .take(1)
            .subscribe((response: Product[]) => {
                this.data = response;
            });
    }
}
