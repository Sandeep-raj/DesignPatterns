using System;

namespace Behavioral
{
    public abstract class Beverage
    {
        public string description;
        public abstract string getDescription();
        public abstract double cost();

    }
    public abstract class CondimentDecorator : Beverage
    {
        public Beverage beverage;
    }

    public class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            this.description = "House Blend";
        }
        public override string getDescription()
        {
            return this.description;
        }
        public override double cost()
        {
            return 1.2;
        }
    }
    public class DarkRoast : Beverage
    {
        public DarkRoast()
        {
            this.description = "Dark Roast";
        }
        public override string getDescription()
        {
            return this.description;
        }
        public override double cost()
        {
            return 1.7;
        }
    }
    public class Expresso : Beverage
    {
        public Expresso()
        {
            this.description = "Expresso Coffee";
        }
        public override string getDescription()
        {
            return this.description;
        }
        public override double cost()
        {
            return 2.2;
        }
    }
    public class Decaf : Beverage
    {
        public Decaf()
        {
            this.description = "Decaf Coffee";
        }
        public override string getDescription()
        {
            return this.description;
        }
        public override double cost()
        {
            return 0.8;
        }
    }

    public class Milk : CondimentDecorator
    {
        public Milk(Beverage beverage)
        {
            this.beverage = beverage;
        }
        public override string getDescription()
        {
            return beverage.getDescription() + ", Milk";
        }

        public override double cost()
        {
            return beverage.cost() + 0.2;
        }
    }
    public class Mocha : CondimentDecorator
    {
        public Mocha(Beverage beverage)
        {
            this.beverage = beverage;
        }
        public override string getDescription()
        {
            return beverage.getDescription() + ", Mocha";
        }

        public override double cost()
        {
            return beverage.cost() + 0.4;
        }
    }
    public class Soy : CondimentDecorator
    {
        public Soy(Beverage beverage)
        {
            this.beverage = beverage;
        }
        public override string getDescription()
        {
            return beverage.getDescription() + ", Soy";
        }

        public override double cost()
        {
            return beverage.cost() + 0.3;
        }
    }
    public class Whip : CondimentDecorator
    {
        public Whip(Beverage beverage)
        {
            this.beverage = beverage;
        }
        public override string getDescription()
        {
            return beverage.getDescription() + ", Whip";
        }

        public override double cost()
        {
            return beverage.cost() + 0.2;
        }
    }


    public class DecoratorTest
    {
        public static void Test()
        {
            // Test 1
            Beverage beverage1 = new Expresso();
            beverage1 = new Milk(beverage1);
            beverage1 = new Whip(beverage1);
            Console.WriteLine(beverage1.getDescription() + " " + beverage1.cost());

            // Test 2
            Beverage beverage2 = new DarkRoast();
            beverage2 = new Mocha(beverage2);
            beverage2 = new Mocha(beverage2);
            Console.WriteLine(beverage2.getDescription() + " " + beverage2.cost());
        }
    }


}