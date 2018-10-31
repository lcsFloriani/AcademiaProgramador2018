import { Directive, HostListener, OnInit, Injector } from '@angular/core';
import { NgControl, AbstractControl } from '@angular/forms';

@Directive({
    selector: '[nddInputCustomerName]',
})
export class NDDInputCustomerNameDirective implements OnInit {
    private control: AbstractControl;

    constructor(private injector: Injector) { }

    public ngOnInit(): void {
        this.control = this.injector.get(NgControl).control;
    }

    @HostListener('keypress', ['$event'])
    public onChange(event: KeyboardEvent): void {
        // Verifica se o caractere digitado é valido
        if (this.validateCustomerName(event.which)) {
            // Se o caractere não for valido cancela o evento (no caso a tecla pressionada)
            event.preventDefault();
        }
    }

    @HostListener('focusout', ['$event'])
    public onBlur(event: any): void {
        this.replaceSpaceToUnderline();
        event.preventDefault();
    }

    public replaceSpaceToUnderline(): void {
        if (this.control.value) {
            // Remove os espaços desnecessários (vários em sequencia e no final do nome) e substitui o restante dos espaços por underline
            this.control.setValue(this.control.value.trim().split(' ').join('_'));
        }
    }

    public validateCustomerName(keyPressed: number): boolean {
        // Obtem o caractere digitado de acordo com o char code
        const character: string = String.fromCharCode(keyPressed);

        // Regex para permitir apenas apenas letras, números e espaços
        const regex: any = /^[a-zA-Z0-9 _]+$/;

        // Retorna a validade do caractere diante o regex
        return !regex.test(character);
    }
}
