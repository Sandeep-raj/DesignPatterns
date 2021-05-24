using System;
using System.Collections.Generic;

namespace Creational
{
    public abstract class Pizza
    {
        public string name;
        public string dough;
        public string sauce;
        public List<string> toppings = new List<string>();

        public string getName()
        {
            return name;
        }
        public void prepare()
        {
            Console.WriteLine("Preparing " + name);
        }
        public virtual void bake()
        {
            Console.WriteLine("Baking " + name);
        }
        public virtual void cut()
        {
            Console.WriteLine("Cutting " + name);
        }
        public virtual void box()
        {
            Console.WriteLine("Boxing " + name);
        }

        public override string ToString()
        {
            string display = $@" ---- {name} ---- 
            ---- {dough} ----
            ---- {sauce} ----
            ";
            this.toppings.ForEach((topping) =>
            {
                display = display + $@" ---- {topping} ----";
            });
            return display;
        }
    }
    public class CheesePizza : Pizza
    {
        public CheesePizza()
        {
            this.name = "Cheese Pizza";
            this.dough = "Regular Crust";
            this.sauce = "Marinara Pizza Sauce";
            this.toppings.Add("Fresh Mozzarella");
            this.toppings.Add("Parmesan");
        }
    }
    public class ClamPizza : Pizza
    {
        public ClamPizza()
        {
            this.name = "Clam Pizza";
            this.dough = "Thin crust";
            this.sauce = "White garlic sauce";
            this.toppings.Add("Clams");
            this.toppings.Add("Grated parmesan cheese");
        }
    }
    public class PepperoniPizza : Pizza
    {
        public PepperoniPizza()
        {
            this.name = "Pepperoni Pizza";
            this.dough = "Crust";
            this.sauce = "Marinara sauce";
            this.toppings.Add("Sliced Pepperoni");
            this.toppings.Add("Sliced Onion");
            this.toppings.Add("Grated parmesan cheese");
        }
    }
    public class VeggiePizza : Pizza
    {
        public VeggiePizza()
        {
            this.name = "Veggie Pizza";
            this.dough = "Crust";
            this.sauce = "Marinara sauce";
            this.toppings.Add("Shredded mozzarella");
            this.toppings.Add("Grated parmesan");
            this.toppings.Add("Diced onion");
            this.toppings.Add("Sliced mushrooms");
            this.toppings.Add("Sliced red pepper");
            this.toppings.Add("Sliced black olives");
        }
    }

    public class NYStyleCheesePizza : Pizza
    {
        public NYStyleCheesePizza()
        {
            this.name = "NY Style Sauce and Cheese Pizza";
            this.dough = "Thin Crust Dough";
            this.sauce = "Marinara Sauce";
            this.toppings.Add("Grated Reggiano Cheese");
        }
    }
    public class NYStyleClamPizza : Pizza
    {
        public NYStyleClamPizza()
        {
            this.name = "NY Style Clam Pizza";
            this.dough = "Thin Crust Dough";
            this.sauce = "Marinara Sauce";
            this.toppings.Add("Grated Reggiano Cheese");
            this.toppings.Add("Fresh Clams from Long Island Sound");
        }
    }
    public class NYStylePepperoniPizza : Pizza
    {
        public NYStylePepperoniPizza()
        {
            this.name = "NY Style Pepperoni Pizza";
            this.dough = "Thin Crust Dough";
            this.sauce = "Marinara Sauce";
            this.toppings.Add("Grated Reggiano Cheese");
            this.toppings.Add("Sliced Pepperoni");
            this.toppings.Add("Garlic");
            this.toppings.Add("Onion");
            this.toppings.Add("Mushrooms");
            this.toppings.Add("Red Pepper");
        }
    }
    public class NYStyleVeggiePizza : Pizza
    {
        public NYStyleVeggiePizza()
        {
            this.name = "NY Style Veggie Pizza";
            this.dough = "Thin Crust Dough";
            this.sauce = "Marinara Sauce";
            this.toppings.Add("Grated Reggiano Cheese");
            this.toppings.Add("Garlic");
            this.toppings.Add("Onion");
            this.toppings.Add("Mushrooms");
            this.toppings.Add("Red Pepper");
        }
    }

    public class ChicagoStyleCheesePizza : Pizza
    {
        public ChicagoStyleCheesePizza()
        {
            this.name = "Chicago Style Deep Dish Cheese Pizza";
            this.dough = "Extra Thick Crust Dough";
            this.sauce = "Plum Tomato Sauce";
            this.toppings.Add("Shredded Mozzarella Cheese");
        }
        public override void cut()
        {
            Console.WriteLine("Cutting the pizza into square slices");
        }
    }
    public class ChicagoStyleClamPizza : Pizza
    {
        public ChicagoStyleClamPizza()
        {
            this.name = "Chicago Style Clam Pizza";
            this.dough = "Extra Thick Crust Dough";
            this.sauce = "Plum Tomato Sauce";
            this.toppings.Add("Shredded Mozzarella Cheese");
            this.toppings.Add("Frozen Clams from Chesapeake Bay");
        }

        public override void cut()
        {
            Console.WriteLine("Cutting the pizza into square slices");
        }
    }
    public class ChicagoStylePepperoniPizza : Pizza
    {
        public ChicagoStylePepperoniPizza()
        {
            this.name = "Chicago Style Pepperoni Pizza";
            this.dough = "Extra Thick Crust Dough";
            this.sauce = "Plum Tomato Sauce";
            this.toppings.Add("Shredded Mozzarella Cheese");
            this.toppings.Add("Black Olives");
            this.toppings.Add("Spinach");
            this.toppings.Add("Eggplant");
            this.toppings.Add("Sliced Pepperoni");
        }

        public override void cut()
        {
            Console.WriteLine("Cutting the pizza into square slices");
        }
    }
    public class ChicagoStyleVeggiePizza : Pizza
    {
        public ChicagoStyleVeggiePizza()
        {
            this.name = "Chicago Deep Dish Veggie Pizza";
            this.dough = "Extra Thick Crust Dough";
            this.sauce = "Plum Tomato Sauce";
            this.toppings.Add("Shredded Mozzarella Cheese");
            this.toppings.Add("Black Olives");
            this.toppings.Add("Spinach");
            this.toppings.Add("Eggplant");
        }

        public override void cut()
        {
            Console.WriteLine("Cutting the pizza into square slices");
        }
    }


    public class SimplePizzaFactory
    {
        public virtual Pizza createPizza(string type)
        {
            Pizza pizza = null;
            if (type.Equals("cheese"))
            {
                pizza = new CheesePizza();
            }
            else if (type.Equals("clam"))
            {
                pizza = new ClamPizza();
            }
            else if (type.Equals("pepperoni"))
            {
                pizza = new PepperoniPizza();
            }
            else if (type.Equals("veggie"))
            {
                pizza = new VeggiePizza();
            }
            return pizza;
        }
    }
    public class NYPizzaFactory : SimplePizzaFactory
    {
        public override Pizza createPizza(string type)
        {
            Pizza pizza = null;
            if (type.Equals("cheese"))
            {
                pizza = new NYStyleCheesePizza();
            }
            else if (type.Equals("clam"))
            {
                pizza = new NYStyleClamPizza();
            }
            else if (type.Equals("pepperoni"))
            {
                pizza = new NYStylePepperoniPizza();
            }
            else if (type.Equals("veggie"))
            {
                pizza = new NYStyleVeggiePizza();
            }
            return pizza;
        }
    }
    public class ChicagoPizzaFactory : SimplePizzaFactory
    {
        public override Pizza createPizza(string type)
        {
            Pizza pizza = null;
            if (type.Equals("cheese"))
            {
                pizza = new ChicagoStyleCheesePizza();
            }
            else if (type.Equals("clam"))
            {
                pizza = new ChicagoStyleClamPizza();
            }
            else if (type.Equals("pepperoni"))
            {
                pizza = new ChicagoStylePepperoniPizza();
            }
            else if (type.Equals("veggie"))
            {
                pizza = new ChicagoStyleVeggiePizza();
            }
            return pizza;
        }
    }


    // Simple Factory
    public class SimplePizzaStore
    {
        SimplePizzaFactory factory;
        public SimplePizzaStore(SimplePizzaFactory factory)
        {
            this.factory = factory;
        }
        public Pizza orderPizza(string type)
        {
            Pizza pizza;
            pizza = factory.createPizza(type);

            pizza.prepare();
            pizza.bake();
            pizza.cut();
            pizza.box();

            return pizza;
        }
    }
    ///////////


    // Factory Method
    public abstract class FactoryMethodPizzaStore
    {
        public Pizza pizza = null;
        public abstract Pizza createPizza(string type);
        public Pizza orderPizza(string type)
        {
            pizza = this.createPizza(type);

            pizza.prepare();
            pizza.bake();
            pizza.cut();
            pizza.box();

            return pizza;
        }
    }
    public class NYPizzaStore : FactoryMethodPizzaStore
    {
        public override Pizza createPizza(string type)
        {
            Pizza pizza = null;
            if (type.Equals("cheese"))
            {
                pizza = new NYStyleCheesePizza();
            }
            else if (type.Equals("clam"))
            {
                pizza = new NYStyleClamPizza();
            }
            else if (type.Equals("pepperoni"))
            {
                pizza = new NYStylePepperoniPizza();
            }
            else if (type.Equals("veggie"))
            {
                pizza = new NYStyleVeggiePizza();
            }
            return pizza;
        }
    }
    public class ChicagoPizzaStore : FactoryMethodPizzaStore
    {
        public override Pizza createPizza(string type)
        {
            Pizza pizza = null;
            if (type.Equals("cheese"))
            {
                pizza = new ChicagoStyleCheesePizza();
            }
            else if (type.Equals("clam"))
            {
                pizza = new ChicagoStyleClamPizza();
            }
            else if (type.Equals("pepperoni"))
            {
                pizza = new ChicagoStylePepperoniPizza();
            }
            else if (type.Equals("veggie"))
            {
                pizza = new ChicagoStyleVeggiePizza();
            }
            return pizza;
        }

    }
    ///////////



    public class SimpleFactoryTest
    {
        public static void Test()
        {
            // Simple Pizza Order
            SimplePizzaFactory simplePizzaFactory = new SimplePizzaFactory();
            SimplePizzaStore simplePizzaStore = new SimplePizzaStore(simplePizzaFactory);
            Pizza simplePizza = simplePizzaStore.orderPizza("cheese");
            Console.WriteLine(simplePizza.ToString());

            // Simple NY Pizza Order
            SimplePizzaFactory nyPizzaFactory = new NYPizzaFactory();
            SimplePizzaStore nyPizzaStore = new SimplePizzaStore(nyPizzaFactory);
            Pizza nyPizza = nyPizzaStore.orderPizza("clam");
            Console.WriteLine(nyPizza.ToString());

            // Simple Chicago Pizza Order
            SimplePizzaFactory chicagoPizzaFactory = new ChicagoPizzaFactory();
            SimplePizzaStore chicagoPizzaStore = new SimplePizzaStore(chicagoPizzaFactory);
            Pizza chicagoPizza = chicagoPizzaStore.orderPizza("pepperoni");
            Console.WriteLine(chicagoPizza.ToString());
        }
    }

    public class FactoryMethodPatternTest
    {
        public static void Test()
        {
            FactoryMethodPizzaStore NYPizzaStore = new NYPizzaStore();
            Pizza NYPizza = NYPizzaStore.orderPizza("pepperoni");
            Console.WriteLine(NYPizza.ToString());

            FactoryMethodPizzaStore chicagoPizzaStore = new ChicagoPizzaStore();
            Pizza ChicagoPizza = chicagoPizzaStore.orderPizza("clam");
            Console.WriteLine(ChicagoPizza.ToString());
        }
    }

}