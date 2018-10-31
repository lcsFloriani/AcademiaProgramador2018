import { Router } from '@angular/router';
import { Injectable, EventEmitter } from '@angular/core';
import { INDDGridHeaderAction } from 'ndd-ng-grid';

import { Site } from '../../shared/model/site.model';

@Injectable()
export class SiteActionFields {
    public onDelete: EventEmitter<Site> = new EventEmitter();

    private site: Site;

    public getActionFields(router: Router, customerId: number): INDDGridHeaderAction[] {
        return [
            {
                id: 'site-list-actions-create',
                name: 'NDDCreate',
                icon: 'ndd-font ndd-font-create',
                i18n: true,
                callback: (): void => {
                    router.navigate([`/customers/${ customerId }/sites/create`]);
                },
            },
            {
                id: 'site-list-actions-delete',
                name: 'NDDDelete',
                icon: 'ndd-font ndd-font-delete',
                i18n: true,
                callback: (): void => {
                    this.onDelete.emit(this.site);
                },
                needSingleGridRowSelected: true,
            },
            {
                id: 'site-list-actions-open',
                name: 'NDDOpen',
                icon: 'ndd-font ndd-font-open',
                i18n: true,
                callback: (): void => {
                    router.navigate([`/customers/${ customerId }/sites/${ this.site.id }`]);
                },
                needSingleGridRowSelected: true,
            },
        ];
    }

    public setSelection(site: Site): void {
        this.site = site;
    }
}
