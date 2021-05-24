using System;

namespace Structural
{
    // final interface
    public interface Duck
    {
        public void quack();
        public void fly();
    }
    public interface Turkey
    {
        public void gobble();
        public void fly();
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////

    // Comcrete Implementaions
    public class MallardDuck : Duck
    {
        public void quack()
        {
            Console.WriteLine("Quack");
        }
        public void fly()
        {
            Console.WriteLine("I'm flying");
        }
    }
    public class WildTurkey : Turkey
    {
        public void gobble()
        {
            Console.WriteLine("Gobble gobble");
        }
        public void fly()
        {
            Console.WriteLine("I'm flying a short distance");
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////

    // Adapters
    public class DuckAdapter : Turkey
    {
        Duck duck;
        Random rand;
        public DuckAdapter(Duck duck)
        {
            this.duck = duck;
            rand = new Random();
        }
        public void gobble()
        {
            duck.quack();
        }
        public void fly()
        {
            if (rand.Next(5) == 0)
            {
                duck.fly();
            }
        }
    }
    public class TurkeyAdapter : Duck
    {
        Turkey turkey;
        public TurkeyAdapter(Turkey turkey)
        {
            this.turkey = turkey;
        }
        public void quack()
        {
            turkey.gobble();
        }
        public void fly()
        {
            for (int i = 0; i < 5; i++)
            {
                turkey.fly();
            }
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////

    // Client
    public class DuckTestDrive
    {
        public static void Test()
        {
            Duck duck = new MallardDuck();

            Turkey turkey = new WildTurkey();
            Duck turkeyAdapter = new TurkeyAdapter(turkey);

            Console.WriteLine("The Turkey says...");
            turkey.gobble();
            turkey.fly();

            Console.WriteLine("\nThe Duck says...");
            testDuck(duck);

            Console.WriteLine("\nThe TurkeyAdapter says...");
            testDuck(turkeyAdapter);
        }
        static void testDuck(Duck duck)
        {
            duck.quack();
            duck.fly();
        }
    }
    public class TurkeyTestDrive
    {
        public static void Test()
        {
            MallardDuck duck = new MallardDuck();
            Turkey duckAdapter = new DuckAdapter(duck);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("The DuckAdapter says...");
                duckAdapter.gobble();
                duckAdapter.fly();
            }
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////

}