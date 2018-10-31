import { ProductSharedService } from './../../product/shared/product.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs/Observable';

import { OrderService } from './../shared/order-service';
import { OrderRegisterCommand } from '../shared/order-model';
import { Product } from '../../product/shared/product.model';

@Component({
    templateUrl: './order-create.component.html',
})
export class OrderCreateComponent implements OnInit {
    public listItems: Product[] = [];
    public orderService: OrderService;
    public isLoading: boolean = true;
    public title: string = 'Cadastro de pedidos';
    public trezentos: number = 300;
    public orderCreateForm: FormGroup = this.fb.group({
            customer: ['', Validators.required],
            quantity: ['', Validators.required],
            product: ['', Validators.required],
        },
    );

    public data: Product[];

        constructor(private fb: FormBuilder,
        private service: OrderService,
        private router: Router,
        private route: ActivatedRoute, private serviceProduct: ProductSharedService) {
        this.orderService = this.service;
    }
    public redirect(): void {
        this.router.navigate(['../'], { relativeTo: this.route });
    }
    public onCreate(): void {
        const orderCreate: OrderRegisterCommand = new OrderRegisterCommand(this.orderCreateForm.value);
        orderCreate.SetProduct(this.data.filter((product: Product) => product.name === this.orderCreateForm.value.product)[0]);
        this.orderService.post(orderCreate)
            .take(1)
            .subscribe(() => {
                this.isLoading = true;
                this.redirect();
            });
    }
    public ngOnInit(): void {
        this.isLoading = false;
    }
    public onAutoCompleteChange(value: string): void {
        Observable.of(value)
          .delay(this.trezentos)
          .do((value: any) => {
            this.serviceProduct.query(value);
          })
          .switchMap((value: any, index: number) => this.serviceProduct)
          .subscribe((response: any) => {
            this.data = response;
          });
      }
}
