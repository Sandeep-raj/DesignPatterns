using System;

namespace Behavioral
{
    public abstract class CaffeineBeverage
    {
        public void prepareRecipe()
        {
            boilWater();
            brew();
            pourInCup();
            addCondiments();
        }
        public abstract void brew();
        public abstract void addCondiments();
        public void boilWater()
        {
            Console.WriteLine("Boiling water");
        }
        public void pourInCup()
        {
            Console.WriteLine("Pouring into cup");
        }
    }
    public class Coffee : CaffeineBeverage
    {
        public override void brew()
        {
            Console.WriteLine("Dripping Coffee through filter");
        }
        public override void addCondiments()
        {
            Console.WriteLine("Adding Sugar and Milk");
        }
    }
    public class Tea : CaffeineBeverage
    {
        public override void brew()
        {
            Console.WriteLine("Steeping the tea");
        }
        public override void addCondiments()
        {
            Console.WriteLine("Adding Lemon");
        }
    }



    // Template Method Hook Pattern
    public abstract class CaffeineBeverageWithHook
    {
        public void prepareRecipe()
        {
            boilWater();
            brew();
            pourInCup();
            if (customerWantsCondiments())
            {
                addCondiments();
            }
        }
        public abstract void brew();
        public abstract void addCondiments();
        public void boilWater()
        {
            Console.WriteLine("Boiling water");
        }
        public void pourInCup()
        {
            Console.WriteLine("Pouring into cup");
        }
        public virtual Boolean customerWantsCondiments()
        {
            return true;
        }
    }
    public class CoffeeWithHook : CaffeineBeverageWithHook
    {
        public override void brew()
        {
            Console.WriteLine("Dripping Coffee through filter");
        }
        public override void addCondiments()
        {
            Console.WriteLine("Adding Sugar and Milk");
        }
        public override Boolean customerWantsCondiments()
        {
            String answer = getUserInput();
            if (answer.ToLower().StartsWith("y"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private String getUserInput()
        {
            String answer = null;
            Console.WriteLine("Would you like milk and sugar with your coffee (y/n)? ");
            answer = Console.ReadLine();
            return answer;
        }
    }
    public class TeaWithHook : CaffeineBeverageWithHook
    {
        public override void brew()
        {
            Console.WriteLine("Steeping the tea");
        }
        public override void addCondiments()
        {
            Console.WriteLine("Adding Lemon");
        }
        public override Boolean customerWantsCondiments()
        {

            String answer = getUserInput();

            if (answer.ToLower().StartsWith("y"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private String getUserInput()
        {
            // get the user's response
            String answer = null;

            Console.WriteLine("Would you like lemon with your tea (y/n)? ");
            answer = Console.ReadLine();
            return answer;
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////


    public class BeverageTestDrive
    {
        public static void main(String[] args)
        {
            Tea tea = new Tea();
            Coffee coffee = new Coffee();

            Console.WriteLine("\nMaking tea...");
            tea.prepareRecipe();

            Console.WriteLine("\nMaking coffee...");
            coffee.prepareRecipe();

            TeaWithHook teaHook = new TeaWithHook();
            CoffeeWithHook coffeeHook = new CoffeeWithHook();

            Console.WriteLine("\nMaking tea...");
            teaHook.prepareRecipe();

            Console.WriteLine("\nMaking coffee...");
            coffeeHook.prepareRecipe();
        }
    }
}