'use strict';

var PizzaSummary = {};

(function PizzaSummaryControl() {

    var pizzaTypeDiv = document.querySelector('#pizzaType');
    var pizzaToppingDiv = document.querySelector('#pizzaToppings');
    var pizzaTotalDiv = document.querySelector('#pizzaTotal');

    var self = this;
    PizzaSummary.updateType = function (pizza) {
        pizzaTypeDiv.innerHTML = '<div class="form__group form__group--medium form__group--left-space"><span>PIZZA '
            + pizza.type +
            '</span></div><div class="form__group form__group--medium form__group--text-right form__group--left-space"><span>$' + pizza.getPizzaSizePrice() + '</span></div>';
    }
    PizzaSummary.updateToppingsSummary = function (pizza) {
        pizzaToppingDiv.innerHTML = '';
        for (var topping in pizza.toppings) {
            pizzaToppingDiv.innerHTML += '<div class="form__group form__group--medium form__group--left-space"><span>' + pizza.toppings[topping] + '</span></div><div class="form__group form__group--medium form__group--text-right form__group--left-space"><span> $' + pizza.getToppingUnitPrice() + '</span></div>';
        }
    }
    PizzaSummary.updateTotal = function (pizza) {
        pizzaTotalDiv.innerHTML = '<div class="form__group form__group--medium form__group--left-space"><span class="form__text">TOTAL</span></div> <div class="form__group form__group--medium form__group--text-right form__text--big"><span class="form__text">$' + pizza.calculateTotal() + '</span></div>';
    }
})();