import { Pipe, PipeTransform } from '@angular/core';

import { EnumValues } from 'enum-values';
import { State } from './address.model';

@Pipe({ name: 'nddState' })
export class StatePipe implements PipeTransform {
    public transform(value: any): any {
        return  EnumValues.getNameFromValue(State, value);
    }
}
