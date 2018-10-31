(function PizzaCreate() {
    'use strict';

    var self = this;
    var button = document.querySelector('#btnPlaceOrder');
    var smallRadio = document.querySelector('#small');
    var pizza = new Pizza();
    var customer = new Customer();

    initialize();

    function initialize() {
        pizza.customer = customer;
        smallRadio.checked = true;
        CustomerForm.initialize(customer, validateForm);
        PizzaSummary.updateType(pizza);
        button.addEventListener('click', onSubmit);
        validateForm();
        setSizeRadioEvents();
        setToppingsCheckboxEvents();
    }

    function validateForm() {
        var state = CustomerForm.validate();
        if (state) {
            button.classList.remove('form__button--disabled');
        } else {
            button.classList.add('form__button--disabled');
        }
        button.disabled = !state;
    }

    /** Events */

    function onSubmit() {
        alert('Pizza !!');
        console.log(pizza);
    }

    function setSizeRadioEvents() {
        for (var type in pizzaTypes) {
            var radio = document.querySelector('#' + type);
            radio.addEventListener('click', function (event) {
                pizza.type = pizzaTypes[event.srcElement.value];
                PizzaSummary.updateType(pizza);
                PizzaSummary.updateToppingsSummary(pizza);
                PizzaSummary.updateTotal(pizza);
            });
        }
    }

    function setToppingsCheckboxEvents() {
        for (var topping in pizzaToppings) {
            (function (property) {
                var checkbox = document.querySelector('#' + property);
                checkbox.addEventListener('click', function () {
                    if (checkbox.checked) {
                        pizza.toppings.push(property);
                    } else {
                        var index = pizza.toppings.indexOf(property);
                        pizza.toppings.splice(index, 1);
                    }
                    PizzaSummary.updateToppingsSummary(pizza);

                    PizzaSummary.updateTotal(pizza);
                });
            })(topping);
        }
    }
})();