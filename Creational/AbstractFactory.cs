using System;

namespace CreationalExt
{
    public interface Dough
    {
        public string ToString();
    }
    public class ThickCrustDough : Dough
    {
        public override String ToString()
        {
            return "ThickCrust style extra thick crust dough";
        }
    }
    public class ThinCrustDough : Dough
    {
        public override String ToString()
        {
            return "Thin Crust Dough";
        }
    }

    public interface Sauce
    {
        public string ToString();
    }
    public class MarinaraSauce : Sauce
    {
        public override string ToString()
        {
            return "Marinara Sauce";
        }
    }
    public class PlumTomatoSauce : Sauce
    {
        public override string ToString()
        {
            return "Tomato sauce with plum tomatoes";
        }
    }

    public interface Cheese
    {
        public string ToString();
    }
    public class MozzarellaCheese : Cheese
    {
        public override string ToString()
        {
            return "Shredded Mozzarella";
        }
    }
    public class ParmesanCheese : Cheese
    {
        public override string ToString()
        {
            return "Shredded Parmesan";
        }
    }
    public class ReggianoCheese : Cheese
    {
        public override string ToString()
        {
            return "Reggiano Cheese";
        }
    }

    public interface Clams
    {
        public string ToString();
    }
    public class FreshClams : Clams
    {
        public override string ToString()
        {
            return "Fresh Clams from Long Island Sound";
        }
    }
    public class FrozenClams : Clams
    {
        public override string ToString()
        {
            return "Frozen Clams from Chesapeake Bay";
        }
    }

    public interface Pepperoni
    {
        public string ToString();
    }
    public class SlicedPepperoni : Pepperoni
    {
        public override string ToString()
        {
            return "Sliced Pepperoni";
        }
    }

    public interface Veggies
    {
        public string ToString();
    }
    public class Spinach : Veggies
    {
        public override string ToString()
        {
            return "Spinach";
        }
    }
    public class BlackOlives : Veggies
    {
        public override string ToString()
        {
            return "Black Olives";
        }
    }
    public class Eggplant : Veggies
    {
        public override string ToString()
        {
            return "Eggplant";
        }
    }
    public class Garlic : Veggies
    {
        public override string ToString()
        {
            return "Garlic";
        }
    }
    public class Mushroom : Veggies
    {
        public override string ToString()
        {
            return "Mushroom";
        }
    }
    public class Onion : Veggies
    {
        public override string ToString()
        {
            return "Onion";
        }
    }
    public class RedPepper : Veggies
    {
        public override string ToString()
        {
            return "Red Pepper";
        }
    }

    public interface PizzaIngredientFactory
    {
        public Dough createDough();
        public Sauce createSauce();
        public Cheese createCheese();
        public Veggies[] createVeggies();
        public Pepperoni createPepperoni();
        public Clams createClam();
    }
    public class NYPizzaIngredientFactory : PizzaIngredientFactory
    {
        public Dough createDough()
        {
            return new ThinCrustDough();
        }
        public Sauce createSauce()
        {
            return new MarinaraSauce();
        }
        public Cheese createCheese()
        {
            return new ReggianoCheese();
        }
        public Veggies[] createVeggies()
        {
            Veggies[] veggies = { new Garlic(), new Onion(), new Mushroom(), new RedPepper() };
            return veggies;
        }
        public Pepperoni createPepperoni()
        {
            return new SlicedPepperoni();
        }
        public Clams createClam()
        {
            return new FreshClams();
        }
    }
    public class ChicagoPizzaIngredientFactory : PizzaIngredientFactory
    {
        public Dough createDough()
        {
            return new ThickCrustDough();
        }
        public Sauce createSauce()
        {
            return new PlumTomatoSauce();
        }
        public Cheese createCheese()
        {
            return new MozzarellaCheese();
        }
        public Veggies[] createVeggies()
        {
            Veggies[] veggies = { new BlackOlives(), new Spinach(), new Eggplant() };
            return veggies;
        }
        public Pepperoni createPepperoni()
        {
            return new SlicedPepperoni();
        }
        public Clams createClam()
        {
            return new FrozenClams();
        }
    }

    public abstract class Pizza
    {
        public string name;
        public Dough dough;
        public Sauce sauce;
        public Veggies[] veggies;
        public Cheese cheese;
        public Pepperoni pepperoni;
        public Clams clam;

        public abstract void prepare();
        public void bake()
        {
            Console.WriteLine("Bake for 25 minutes at 350");
        }
        public void cut()
        {
            Console.WriteLine("Cutting the pizza into diagonal slices");
        }
        public void box()
        {
            Console.WriteLine("Place pizza in official PizzaStore box");
        }
        public void setName(String name)
        {
            this.name = name;
        }
        public String getName()
        {
            return name;
        }
        public override string ToString()
        {
            string result = $" ---- {this.name} ----";
            if (this.dough != null)
            {
                result = result + $"---- {this.dough} ----";
            }
            if (this.sauce != null)
            {
                result = result + $"---- {this.sauce} ----";
            }
            if (this.cheese != null)
            {
                result = result + $"---- {this.cheese} ----";
            }
            if (this.veggies != null)
            {
                for (int i = 0; i < veggies.Length; i++)
                {
                    result = result + $"---- {this.veggies[i]} ----";
                }
            }
            return result;
        }
    }
    public class CheesePizza : Pizza
    {
        PizzaIngredientFactory ingredientFactory;
        public CheesePizza(PizzaIngredientFactory ingredientFactory)
        {
            this.ingredientFactory = ingredientFactory;
        }
        public override void prepare()
        {
            Console.WriteLine("Preparing " + this.name);
            this.dough = ingredientFactory.createDough();
            this.sauce = ingredientFactory.createSauce();
            this.cheese = ingredientFactory.createCheese();
        }
    }
    public class ClamPizza : Pizza
    {
        PizzaIngredientFactory ingredientFactory;
        public ClamPizza(PizzaIngredientFactory ingredientFactory)
        {
            this.ingredientFactory = ingredientFactory;
        }
        public override void prepare()
        {
            Console.WriteLine("Preparing " + name);
            this.dough = ingredientFactory.createDough();
            this.sauce = ingredientFactory.createSauce();
            this.cheese = ingredientFactory.createCheese();
            this.clam = ingredientFactory.createClam();
        }
    }
    public class PepperoniPizza : Pizza
    {
        PizzaIngredientFactory ingredientFactory;
        public PepperoniPizza(PizzaIngredientFactory ingredientFactory)
        {
            this.ingredientFactory = ingredientFactory;
        }
        public override void prepare()
        {
            Console.WriteLine("Preparing " + name);
            this.dough = ingredientFactory.createDough();
            this.sauce = ingredientFactory.createSauce();
            this.cheese = ingredientFactory.createCheese();
            this.veggies = ingredientFactory.createVeggies();
            this.pepperoni = ingredientFactory.createPepperoni();
        }
    }
    public class VeggiePizza : Pizza
    {
        PizzaIngredientFactory ingredientFactory;
        public VeggiePizza(PizzaIngredientFactory ingredientFactory)
        {
            this.ingredientFactory = ingredientFactory;
        }
        public override void prepare()
        {
            Console.WriteLine("Preparing " + name);
            this.dough = ingredientFactory.createDough();
            this.sauce = ingredientFactory.createSauce();
            this.cheese = ingredientFactory.createCheese();
            this.veggies = ingredientFactory.createVeggies();
        }
    }

    public abstract class PizzaStore
    {
        public abstract Pizza createPizza(String item);
        public Pizza orderPizza(String type)
        {
            Pizza pizza = createPizza(type);
            Console.WriteLine("--- Making a " + pizza.getName() + " ---");
            pizza.prepare();
            pizza.bake();
            pizza.cut();
            pizza.box();
            return pizza;
        }
    }
    public class NYPizzaStore : PizzaStore
    {
        public override Pizza createPizza(String item)
        {
            Pizza pizza = null;
            PizzaIngredientFactory ingredientFactory =
                new NYPizzaIngredientFactory();

            if (item.Equals("cheese"))
            {
                pizza = new CheesePizza(ingredientFactory);
                pizza.setName("New York Style Cheese Pizza");
            }
            else if (item.Equals("veggie"))
            {
                pizza = new VeggiePizza(ingredientFactory);
                pizza.setName("New York Style Veggie Pizza");
            }
            else if (item.Equals("clam"))
            {
                pizza = new ClamPizza(ingredientFactory);
                pizza.setName("New York Style Clam Pizza");
            }
            else if (item.Equals("pepperoni"))
            {
                pizza = new PepperoniPizza(ingredientFactory);
                pizza.setName("New York Style Pepperoni Pizza");
            }
            return pizza;
        }
    }
    public class ChicagoPizzaStore : PizzaStore
    {
        public override Pizza createPizza(String item)
        {
            Pizza pizza = null;
            PizzaIngredientFactory ingredientFactory =
            new ChicagoPizzaIngredientFactory();

            if (item.Equals("cheese"))
            {
                pizza = new CheesePizza(ingredientFactory);
                pizza.setName("Chicago Style Cheese Pizza");
            }
            else if (item.Equals("veggie"))
            {
                pizza = new VeggiePizza(ingredientFactory);
                pizza.setName("Chicago Style Veggie Pizza");
            }
            else if (item.Equals("clam"))
            {
                pizza = new ClamPizza(ingredientFactory);
                pizza.setName("Chicago Style Clam Pizza");
            }
            else if (item.Equals("pepperoni"))
            {
                pizza = new PepperoniPizza(ingredientFactory);
                pizza.setName("Chicago Style Pepperoni Pizza");
            }
            return pizza;
        }
    }

    public class PizzaTestDrive
    {
        public static void Test()
        {
            PizzaStore nyStore = new NYPizzaStore();
            PizzaStore chicagoStore = new ChicagoPizzaStore();

            Pizza pizza = nyStore.orderPizza("cheese");
            Console.WriteLine("Ethan ordered a " + pizza + "\n");

            pizza = chicagoStore.orderPizza("cheese");
            Console.WriteLine("Joel ordered a " + pizza + "\n");

            pizza = nyStore.orderPizza("clam");
            Console.WriteLine("Ethan ordered a " + pizza + "\n");

            pizza = chicagoStore.orderPizza("clam");
            Console.WriteLine("Joel ordered a " + pizza + "\n");

            pizza = nyStore.orderPizza("pepperoni");
            Console.WriteLine("Ethan ordered a " + pizza + "\n");

            pizza = chicagoStore.orderPizza("pepperoni");
            Console.WriteLine("Joel ordered a " + pizza + "\n");

            pizza = nyStore.orderPizza("veggie");
            Console.WriteLine("Ethan ordered a " + pizza + "\n");

            pizza = chicagoStore.orderPizza("veggie");
            Console.WriteLine("Joel ordered a " + pizza + "\n");
        }
    }

}