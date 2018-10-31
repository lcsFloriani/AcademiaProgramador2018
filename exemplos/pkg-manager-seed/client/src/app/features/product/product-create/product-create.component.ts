import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { ProductService } from '../shared/product.service';
import { ProductRegisterCommand } from '../shared/product.model';
import { ProductValidator } from '../shared/product.validator';

@Component({
  templateUrl: './product-create.component.html',
})

export class ProductCreateComponent implements OnInit {
  public productService: ProductService;
  public isLoading: boolean = false;
  public title: string = 'Cadastro de produtos';
  public productCreateForm: FormGroup = this.fb.group({
    name: ['', Validators.required],
    sale: ['', Validators.required],
    expense: ['', Validators.required],
    isAvailable: ['', Validators.required],
    manufacture: ['', [Validators.required]],
    expiration: ['', [Validators.required]],
  }, { validator: ProductValidator.checkDate },
);
  constructor(private fb: FormBuilder,
    private service: ProductService,
    private router: Router,
    private route: ActivatedRoute) {
    this.productService = this.service;

  }
  public ngOnInit(): void {
    //
  }
  public redirect(): void {
    this.router.navigate(['/'], { relativeTo: this.route });
  }
  public onCreate(): void {
    const productCreate: ProductRegisterCommand = new ProductRegisterCommand(this.productCreateForm.value);
    this.productService.post(productCreate)
      .take(1)
      .subscribe(() => {
        this.isLoading = true;
        this.redirect();
      });
  }
}
