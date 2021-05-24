using System;

namespace Behavioral
{
    public interface FlyBehavior
    {
        void fly();
    }
    public interface QuackBehavior
    {
        void quack();
    }

    public class FlyWithWings : FlyBehavior
    {
        public void fly()
        {
            Console.WriteLine("Fly with Wings");
        }
    }
    public class FlyNoWay : FlyBehavior
    {
        public void fly()
        {
            Console.WriteLine("Not Flying");
        }
    }
    public class FlyRocketPowered : FlyBehavior
    {
        public void fly()
        {
            Console.WriteLine($"Flying with Rocket Speed");
        }
    }
    public class Quack : QuackBehavior
    {
        public void quack()
        {
            Console.WriteLine("Quacking");
        }
    }
    public class Squeak : QuackBehavior
    {
        public void quack()
        {
            Console.WriteLine("Squeaking");
        }
    }
    public class MuteQuack : QuackBehavior
    {
        public void quack()
        {
            Console.WriteLine("Don't Quack");
        }
    }

    public abstract class Duck
    {
        public FlyBehavior flyBehavior { get; set; }
        public QuackBehavior quackBehavior { get; set; }
        public string type { get; set; }

        public abstract void swim();
        public abstract void display();
        public void performQuack()
        {
            quackBehavior.quack();
        }
        public void performFly()
        {
            flyBehavior.fly();
        }
        public void setFlyBehaviour(FlyBehavior flyBehavior)
        {
            this.flyBehavior = flyBehavior;
        }
        public void setQuackBehaviour(QuackBehavior quackBehavior)
        {
            this.quackBehavior = quackBehavior;
        }
    }

    public class MallardDuck : Duck
    {
        public MallardDuck()
        {
            this.type = "Mallard";
            this.setFlyBehaviour(new FlyWithWings());
            this.setQuackBehaviour(new Quack());
        }
        public override void swim()
        {
            Console.WriteLine($"{this.type} duck is swimming.");
        }
        public override void display()
        {
            Console.WriteLine($"We can see {this.type} duck");
        }
    }
    public class RedHeadDuck : Duck
    {
        public RedHeadDuck()
        {
            this.type = "Red Head";
            this.setFlyBehaviour(new FlyWithWings());
            this.setQuackBehaviour(new Quack());
        }
        public override void swim()
        {
            Console.WriteLine($"{this.type} duck is swimming.");
        }
        public override void display()
        {
            Console.WriteLine($"We can see {this.type} duck");
        }
    }
    public class RubberDuck : Duck
    {
        public RubberDuck()
        {
            this.type = "Rubber";
            this.setFlyBehaviour(new FlyNoWay());
            this.setQuackBehaviour(new Squeak());
        }
        public override void swim()
        {
            Console.WriteLine($"{this.type} duck is swimming.");
        }
        public override void display()
        {
            Console.WriteLine($"We can see {this.type} duck");
        }
    }
    public class DecoyDuck : Duck
    {
        public DecoyDuck()
        {
            this.type = "Decoy";
            this.setFlyBehaviour(new FlyNoWay());
            this.setQuackBehaviour(new MuteQuack());
        }
        public override void swim()
        {
            Console.WriteLine($"{this.type} duck is swimming.");
        }
        public override void display()
        {
            Console.WriteLine($"We can see {this.type} duck");
        }
    }

    public class StrategyTest
    {
        public static void Test()
        {
            Duck mallard = new MallardDuck();
            mallard.display();
            mallard.swim();
            mallard.performFly();
            mallard.performQuack();

            Duck model = new DecoyDuck();
            model.performFly();
            model.setFlyBehaviour(new FlyRocketPowered());
            model.performFly();
        }
    }
}