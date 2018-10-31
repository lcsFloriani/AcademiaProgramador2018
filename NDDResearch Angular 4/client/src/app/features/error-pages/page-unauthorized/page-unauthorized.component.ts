import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
    templateUrl: './page-unauthorized.component.html',
})
export class PageUnauthorizedComponent{
    public returnUrl: string;
    constructor(private activatedRoute: ActivatedRoute) {
        this.activatedRoute.queryParams.filter((params: any) => params.returnUrl).take(1).subscribe( (params: any) => {
            this.returnUrl = params.returnUrl;
        });
    }
}
