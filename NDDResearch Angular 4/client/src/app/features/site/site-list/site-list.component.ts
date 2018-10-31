import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Subject } from 'rxjs/Subject';
import { NDDDialogService } from 'ndd-ng-dialog';

import {
    INDDGrid,
    INDDGridHeader,
    NDDGridBuilderService,
} from 'ndd-ng-grid';

import { SiteGridService, SiteService } from '../shared/site.service';
import { Site, SiteDeleteCommand } from '../shared/model/site.model';

import { SiteActionFields } from './values/site-action-fields.model';
import { SiteGridColumns } from './values/site-grid-columns.model';
import { siteFilterSearchbar } from './values/site-filter-searchbar.model';

@Component({
    templateUrl: './site-list.component.html',
})
export class SiteListComponent implements OnInit, OnDestroy {
    public gridOptions: INDDGrid = <INDDGrid>{};
    public gridHeaderOptions: INDDGridHeader = <INDDGridHeader>{};

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private siteGridService: SiteGridService,
        private siteService: SiteService,
        private gridBuilder: NDDGridBuilderService,
        public router: Router,
        private route: ActivatedRoute,
        private siteActionFields: SiteActionFields,
        private siteGridColumns: SiteGridColumns,
        private dialogService: NDDDialogService,
    ) {
        this.siteActionFields.onDelete
            .takeUntil(this.ngUnsubscribe)
            .subscribe((site: Site): void => {
                this.delete(site);
            });
    }

    public ngOnInit(): void {
        this.route.params
            .takeUntil(this.ngUnsubscribe)
            .subscribe((params: Params) => {
                this.siteGridService.setUrlParam(params.customerId);

                this.gridOptions = this.gridBuilder.getBuilder()
                    .identifier('site-list-grid')
                    .columns(this.siteGridColumns.getGridColumns(params.customerId))
                    .sourceService(this.siteGridService)
                    .sort('name')
                    .sortable()
                    .selectable(true)
                    .build();

                this.gridHeaderOptions = this.gridBuilder.getHeaderBuilder()
                    .actions(this.siteActionFields.getActionFields(this.router, params.customerId))
                    .filter(siteFilterSearchbar)
                    .build();
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public selection(items: any[]): void {
        this.siteActionFields.setSelection(items[0]);
    }

    private delete(site: Site): void {
        if (site.isDefault) {
            this.dialogService.alert({ message: 'NDDAlertRemoveDefaultSite' });
        } else {
            this.dialogService.confirm({ message: 'NDDConfirmRemoveSites', yesButton: 'NDDConfirmDialog', noButton: 'NDDCancel' })
                .subscribe((response: boolean) => {
                    if (response) {
                        const command: SiteDeleteCommand = { id: site.id };

                        this.siteService.delete(command)
                            .takeUntil(this.ngUnsubscribe)
                            .subscribe((data: any) => {
                                this.siteGridService.refresh();
                            });
                    }
                });
        }
    }
}
