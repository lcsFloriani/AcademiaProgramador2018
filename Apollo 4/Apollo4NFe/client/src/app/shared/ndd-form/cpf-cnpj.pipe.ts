import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'nddCpfCnpj' })
/* tslint:disable */
export class CpfCnpjPipe implements PipeTransform {

    private cpfLenght: number = 11;
    private cnpjLenght: number = 14;

    public transform(value: string): string {
        if (value) {
            value = value.toString();
            if (value.length === this.cpfLenght) {
                return this.formattedCPF(value);
            }

            if (value.length === this.cnpjLenght) {
                return this.formattedCNPJ(value);
            }
        }

        return value;
    }

    private formattedCPF(value: string): string {
        return value.substring(0, 3).concat('.')
            .concat(value.substring(3, 6))
            .concat('.')
            .concat(value.substring(6, 9))
            .concat('-')
            .concat(value.substring(9, 11));
    }

    private formattedCNPJ(value: string): string {
        return value.substring(0, 2).concat('.')
            .concat(value.substring(2, 5))
            .concat('.')
            .concat(value.substring(5, 8))
            .concat('/')
            .concat(value.substring(8, 12)
            .concat('-')
            .concat(value.substring(12, 14)));
    }
}
