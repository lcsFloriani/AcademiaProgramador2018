import { Injectable, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { CORE_CONFIG_TOKEN, ICoreConfig } from '../../../core/core.config';
import { Observable } from 'rxjs/Observable';

import { BaseService } from '../../../core/utils';
import { AbstractResolveService } from '../../../core/utils/abstract-resolve.service';
import { NDDBreadcrumbService } from '../../../shared/ndd-ng-breadcrumb';

import {Produto } from './produto.model';

@Injectable()
export class ProdutoService extends BaseService {
     private BASE_URL: string = 'http://localhost:63934/';
    private api: string;

    constructor( @Inject(CORE_CONFIG_TOKEN) config: ICoreConfig, public http: HttpClient) {
        super(http);

        this.api = `${this.BASE_URL}api/produtos`;
    }

    public get(entityId: number): Observable<Produto> {
        return this.http.get(`${this.api}/${entityId}`).map((response: Produto) => response);
    }

}

@Injectable()
export class ProdutoResolveService extends AbstractResolveService<Produto>{

    constructor(private produtoService: ProdutoService, router: Router, private breadcrumbService: NDDBreadcrumbService) {
        super(router);
        this.paramsProperty = 'produtoId';
    }

    protected loadEntity(entityId: number): Observable<Produto> {
        return this.produtoService.get(entityId).take(1).do((produto: Produto) => {
            this.breadcrumbService.setMetadata({
                id: 'produto',
                label: produto.descricao,
                sizeLimit: true,
            });
        });
    }
}
