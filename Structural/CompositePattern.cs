using System;
using System.Collections.Generic;

namespace Structural
{
    public interface Iterator
    {
        Boolean hasNext();
        MenuComponent next();
    }
    public abstract class MenuComponent
    {
        public string name;
        public string description;
        public String getName()
        {
            return name;
        }
        public String getDescription()
        {
            return description;
        }
        public virtual double getPrice()
        {
            throw new NotImplementedException();
        }
        public virtual Boolean isVegetarian()
        {
            throw new NotImplementedException();
        }
        public virtual void addItem(MenuComponent menuComponent)
        {
            throw new NotImplementedException();
        }
        public abstract void print();
        public virtual Iterator createIterator()
        {
            return new NoIterator();
        }
    }

    public class NoIterator : Iterator
    {
        public Boolean hasNext()
        {
            return false;
        }
        public MenuComponent next()
        {
            return null;
        }
    }

    public class MenuItem : MenuComponent
    {
        public Boolean vegetarian;
        public double price;
        public MenuItem(String name,
                        String description,
                        Boolean vegetarian,
                        double price)
        {
            this.name = name;
            this.description = description;
            this.vegetarian = vegetarian;
            this.price = price;
        }
        public override double getPrice()
        {
            return price;
        }
        public override Boolean isVegetarian()
        {
            return vegetarian;
        }
        public override string ToString()
        {
            return ($"{name} {price} {description}");
        }
        public override void print()
        {
            Console.WriteLine($"{name}({(isVegetarian() ? "V" : "")}) {price} {description}");
        }
    }

    public class DinerMenu : MenuComponent
    {
        public static int MAX_ITEMS = 7;
        public int numberOfItems = 0;
        MenuComponent[] menuItems;

        public DinerMenu()
        {
            menuItems = new MenuComponent[MAX_ITEMS];

            addItem(new MenuItem("Vegetarian BLT",
                "(Fakin') Bacon with lettuce & tomato on whole wheat", true, 2.99));
            addItem(new MenuItem("BLT",
                "Bacon with lettuce & tomato on whole wheat", false, 2.99));
            addItem(new MenuItem("Soup of the day",
                "Soup of the day, with a side of potato salad", false, 3.29));
            addItem(new MenuItem("Hotdog",
                "A hot dog, with sauerkraut, relish, onions, topped with cheese",
                false, 3.05));
            addItem(new MenuItem("Steamed Veggies and Brown Rice",
                "Steamed vegetables over brown rice", true, 3.99));
            addItem(new MenuItem("Pasta",
                "Spaghetti with Marinara Sauce, and a slice of sourdough bread",
                true, 3.89));
            addItem(new DessertMenu());
        }
        public override void addItem(MenuComponent menuComponent)
        {
            if (numberOfItems >= MAX_ITEMS)
            {
                Console.WriteLine("Sorry, menu is full!  Can't add item to menu");
            }
            else
            {
                menuItems[numberOfItems] = menuComponent;
                numberOfItems = numberOfItems + 1;
            }
        }
        public MenuComponent[] getMenuItems()
        {
            return menuItems;
        }

        public override Iterator createIterator()
        {
            return new DinerMenuIterator(menuItems);
            // To test Alternating menu items, comment out above line,
            // and uncomment the line below.
            //return new AlternatingDinerMenuIterator(menuItems);
        }

        public override string ToString()
        {
            return "Objectville Diner Menu";
        }

        public override void print()
        {
            Console.WriteLine("Objectville Diner Menu");
        }
        // other menu methods here
    }
    public class PancakeHouseMenu : MenuComponent
    {
        List<MenuComponent> menuItems;
        public PancakeHouseMenu()
        {
            menuItems = new List<MenuComponent>();

            addItem(new MenuItem("K&B's Pancake Breakfast",
                "Pancakes with scrambled eggs and toast",
                true,
                2.99));

            addItem(new MenuItem("Regular Pancake Breakfast",
                "Pancakes with fried eggs, sausage",
                false,
                2.99));

            addItem(new MenuItem("Blueberry Pancakes",
                "Pancakes made with fresh blueberries",
                true,
                3.49));

            addItem(new MenuItem("Waffles",
                "Waffles with your choice of blueberries or strawberries",
                true,
                3.59));
        }
        public override void addItem(MenuComponent menuComponent)
        {
            menuItems.Add(menuComponent);
        }
        public List<MenuComponent> getMenuItems()
        {
            return menuItems;
        }
        public override Iterator createIterator()
        {
            return new PancakeHouseMenuIterator(menuItems);
        }
        public override string ToString()
        {
            return "Objectville Pancake House Menu";
        }

        public override void print()
        {
            Console.WriteLine("Objectville Pancake House Menu");
        }
        // other menu methods here
    }
    public class DessertMenu : MenuComponent
    {
        List<MenuComponent> menuItems;
        public DessertMenu()
        {
            menuItems = new List<MenuComponent>();

            addItem(new MenuItem("Apple Pie",
                "Apple Pie with the flaky crust, topped with vanilla ice-cream", true, 1.59));
            addItem(new MenuItem("CheeseCake",
                "Creamy New York Cheese cake, with a chocolate Graham crust", false, 1.99));
            addItem(new MenuItem("Sorbet",
                "A scoup of raspberry and a scoup of lime", true, 1.89));
        }
        public override void addItem(MenuComponent menuComponent)
        {
            menuItems.Add(menuComponent);
        }
        public List<MenuComponent> getMenuItems()
        {
            return menuItems;
        }
        public override Iterator createIterator()
        {
            return new DessertMenuIterator(menuItems);
            // To test Alternating menu items, comment out above line,
            // and uncomment the line below.
            //return new AlternatingDinerMenuIterator(menuItems);
        }
        public override string ToString()
        {
            return "Objectville Diner Dessert Menu";
        }
        public override void print()
        {
            Console.WriteLine("Objectville Diner Dessert Menu");
        }
        // other menu methods here
    }

    public class DinerMenuIterator : Iterator
    {
        MenuComponent[] items;
        int position = 0;
        public DinerMenuIterator(MenuComponent[] items)
        {
            this.items = items;
        }
        public MenuComponent next()
        {
            MenuComponent menuItem = items[position];
            position = position + 1;
            return menuItem;
        }
        public Boolean hasNext()
        {
            if (position >= items.Length || items[position] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    public class PancakeHouseMenuIterator : Iterator
    {
        List<MenuComponent> items;
        int position = 0;
        public PancakeHouseMenuIterator(List<MenuComponent> items)
        {
            this.items = items;
        }
        public MenuComponent next()
        {
            MenuComponent item = items[position];
            position = position + 1;
            return item;
        }
        public Boolean hasNext()
        {
            if (position >= items.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    public class DessertMenuIterator : Iterator
    {
        List<MenuComponent> items;
        int position = 0;
        public DessertMenuIterator(List<MenuComponent> items)
        {
            this.items = items;
        }
        public MenuComponent next()
        {
            MenuComponent item = items[position];
            position = position + 1;
            return item;
        }
        public Boolean hasNext()
        {
            if (position >= items.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public class AllMenus : MenuComponent
    {
        List<MenuComponent> allMenus = new List<MenuComponent>();
        public AllMenus(List<MenuComponent> menus)
        {
            this.allMenus = menus;
        }
        public override void print()
        {
            Console.WriteLine(" --- All Menus --- ");
        }
        public override Iterator createIterator()
        {
            return new AllMenuIterator(this.allMenus);
        }
    }
    public class AllMenuIterator : Iterator
    {
        List<MenuComponent> allMenus;
        int position = 0;
        public AllMenuIterator(List<MenuComponent> menu)
        {
            this.allMenus = menu;
        }

        public Boolean hasNext()
        {
            if (position < this.allMenus.Count)
            {
                return true;
            }
            return false;
        }
        public MenuComponent next()
        {
            MenuComponent menuComponent = this.allMenus[position];
            position += 1;
            return menuComponent;
        }
    }

    public class CompositeIterator : Iterator
    {
        public Stack<Iterator> menuItrator;
        public CompositeIterator(Iterator iterator)
        {
            menuItrator = new Stack<Iterator>();
            menuItrator.Push(iterator);
        }
        public Boolean hasNext()
        {
            if (menuItrator.Count == 0)
            {
                return false;
            }
            else
            {
                Iterator curIterator = menuItrator.Peek();
                if (!curIterator.hasNext())
                {
                    menuItrator.Pop();
                    return hasNext();
                }
                return true;
            }
        }
        public MenuComponent next()
        {
            if (hasNext())
            {
                Iterator currIterator = menuItrator.Peek();
                MenuComponent menuComponent = currIterator.next();
                if (menuComponent.GetType().ToString() != "Structural.MenuItem")
                {
                    menuItrator.Push(menuComponent.createIterator());
                    return next();
                }
                else
                {
                    return menuComponent;
                }
            }
            return null;
        }
    }

    public class Waitress
    {
        MenuComponent allMenus = null;
        public Waitress(List<MenuComponent> menus)
        {
            this.allMenus = new AllMenus(menus);
        }

        public void printMenu()
        {
            this.allMenus.print();
            Iterator menuIterator = this.allMenus.createIterator();
            while (menuIterator.hasNext())
            {
                MenuComponent currentMenu = menuIterator.next();
                currentMenu.print();
                if (currentMenu.GetType().ToString() != "MenuItem")
                {
                    printMenu(currentMenu.createIterator());
                }
            }
        }

        public void printMenu(Iterator iterator)
        {
            while (iterator.hasNext())
            {
                MenuComponent currentMenuComponent = iterator.next();
                currentMenuComponent.print();
                if (currentMenuComponent.GetType().ToString() != "MenuItem")
                {
                    printMenu(currentMenuComponent.createIterator());
                }
            }
        }

        public void PrintAllVegItems()
        {
            Iterator iterator = new CompositeIterator(allMenus.createIterator());
            while (iterator.hasNext())
            {
                MenuComponent menuItem = iterator.next();
                Console.WriteLine(menuItem.getName());
            }
        }
    }

    public class TestCompositePattern
    {
        public static void Test()
        {
            List<MenuComponent> menus = new List<MenuComponent>() { new DinerMenu(), new PancakeHouseMenu() };
            Waitress waitress = new Waitress(menus);
            waitress.printMenu();
            waitress.PrintAllVegItems();
        }
    }

}