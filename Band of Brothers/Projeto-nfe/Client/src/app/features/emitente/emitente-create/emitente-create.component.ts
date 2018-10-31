import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { EmitenteService } from '../shared/emitente.service';
import { EmitenteRegisterCommand } from '../shared/emitente.model';
import { EmitenteValidator } from '../shared/emitente.validator';

@Component({
  templateUrl: './emitente-create.component.html',
})

export class EmitenteCreateComponent implements OnInit {
  public emitenteService: EmitenteService;
  public isLoading: boolean = false;
  public title: string = 'Cadastro de produtos';
  public emitenteCreateForm: FormGroup = this.fb.group({
    name: ['', Validators.required],
    sale: ['', Validators.required],
    expense: ['', Validators.required],
    isAvailable: ['', Validators.required],
    manufacture: ['', [Validators.required]],
    expiration: ['', [Validators.required]],
  }, { validator: EmitenteValidator.checkDate },
);
  constructor(private fb: FormBuilder,
    private service: EmitenteService,
    private router: Router,
    private route: ActivatedRoute) {
    this.emitenteService = this.service;

  }
  public ngOnInit(): void {
    //
  }
  public redirect(): void {
    this.router.navigate(['/'], { relativeTo: this.route });
  }
  public onCreate(): void {
    const emitenteCreate: EmitenteRegisterCommand = new EmitenteRegisterCommand(this.emitenteCreateForm.value);
    this.emitenteService.post(emitenteCreate)
      .take(1)
      .subscribe(() => {
        this.isLoading = true;
        this.redirect();
      });
  }
}
