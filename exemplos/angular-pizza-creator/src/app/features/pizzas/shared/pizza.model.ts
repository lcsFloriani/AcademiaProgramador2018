import { Topping, PizzaSizes } from './pizza.enum';

export interface IPizzaPrices {
  small: IPizzaPrice,
  medium: IPizzaPrice,
  large: IPizzaPrice,
}
export class PizzaPrices {
  public static readonly SMALL: IPizzaPrice = { base: 9.99, toppings: 0.69 };
  public static readonly MEDIUM: IPizzaPrice = { base: 12.99, toppings: 0.99 };
  public static readonly LARGE: IPizzaPrice = { base: 16.99, toppings: 1.29 };

  public static readonly ALL_PRICES: IPizzaPrices = {
    small: PizzaPrices.SMALL,
    medium: PizzaPrices.MEDIUM,
    large: PizzaPrices.LARGE,
  };
}

export interface IPizzaPrice {
  base: number,
  toppings: number,
}

export class Toppings {
  public static readonly ALL_TOPPINGS: Topping[] = [Topping.Anchovy, Topping.Bacon,
  Topping.Basil, Topping.Chili, Topping.Mozzarella, Topping.Mushroom, Topping.Olive,
  Topping.Onion, Topping.Pepper, Topping.Pepperoni, Topping.Sweetcorn, Topping.Tomato];
}

export class ICustomer {
  public name: string;
  public email: string;
  public confirm: string;
  public phone: string;
  public address: string;
  public postcode: string;
}

export class Order {
  public customer: ICustomer;
  public pizzas: Pizza[];
}

export class Pizza {
  public size: PizzaSizes;
  public toppings: Toppings[];

  public static calculateTotal(size: PizzaSizes, toppings: Toppings[]): number {
    const price: IPizzaPrice = PizzaPrices.ALL_PRICES[size];

    return price.base + (price.toppings * toppings.length);
  }
  public static calculateTotalSet(value: Pizza[]): number {
    const price: number = value.reduce((acumulador: number, pizzaAtual: Pizza) => {
      return acumulador + Pizza.calculateTotal(pizzaAtual.size, pizzaAtual.toppings);
    }, 0);
    const priceFixed: number = 2;

    return +price.toFixed(priceFixed);
  }
}
