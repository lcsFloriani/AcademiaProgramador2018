import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs/Subject';

import { Order, OrderEditCommand } from '../../shared/order-model';
import { OrderService, OrderResolveService } from './../../shared/order-service';
import { Product } from '../../../product/shared/product.model';
import { Observable } from 'rxjs/Observable';
import { ProductSharedService } from '../../../product/shared/product.service';

@Component({
    templateUrl: './order-edit.component.html',
})

export class OrderEditComponent implements OnInit {
    public order: Order;
    public orderService: OrderService;
    public isLoading: boolean = false;
    public title: string = 'Editar Pedido';
    public trezentos: number = 300;
    public orderEditForm: FormGroup = this.fb.group({
        id: ['', Validators.required],
        customer: ['', Validators.required],
        quantity: ['', Validators.required],
        productName: ['', Validators.required],
        productId: [''],
    });
    public data: Product[];

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private fb: FormBuilder,
        private service: OrderService,
        private resolver: OrderResolveService,
        private serviceProduct: ProductSharedService,
        private router: Router,
        private route: ActivatedRoute) {
        this.orderService = this.service;
    }

    public ngOnInit(): void {
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((order: Order) => {
                this.isLoading = false;
                this.order = Object.assign(new Order(), order);
                this.orderEditForm.setValue({
                    id: this.order.id,
                    customer: this.order.customer,
                    productName: this.order.productName,
                    productId: this.order.productId,
                    quantity: this.order.quantity,
                });
            });
    }

    public redirect(): void {
        this.router.navigate(['../'], { relativeTo: this.route });
    }

    public onEdit(): void {
        const orderEdit: OrderEditCommand = new OrderEditCommand(this.orderEditForm.value);
        orderEdit.SetProduct(this.getSelectedProduct());
        this.isLoading = true;
        this.orderService.put(orderEdit)
            .take(1)
            .subscribe(() => {
                this.isLoading = false;
                this.resolver.resolveFromRouteAndNotify();
                this.redirect();
            });
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

    private getSelectedProduct(): Product {
        return this.data.filter((product: Product) => product.name === this.orderEditForm.value.productName).shift();
    }
}
