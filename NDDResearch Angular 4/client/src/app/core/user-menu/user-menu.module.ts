import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NDDTranslationModule } from 'ndd-ng-translation';

import { UserMenuContentComponent } from './content/user-menu-content.component';
import { UserConfigViewEnterpriseComponent } from './view-enterprise/user-menu-view-enterprise.component';

@NgModule({
    imports: [
        CommonModule,
        NDDTranslationModule,
    ],
    exports: [
        UserConfigViewEnterpriseComponent,
        UserMenuContentComponent,
    ],
    declarations: [
        UserConfigViewEnterpriseComponent,
        UserMenuContentComponent,
    ],
})
export class UserMenuModule { }
