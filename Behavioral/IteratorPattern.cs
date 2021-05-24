using System;
using System.Collections.Generic;

namespace Behavioral
{
    public interface Iterator
    {
        Boolean hasNext();
        MenuItem next();
    }
    public interface Menu
    {
        public Iterator createIterator();
    }
    public class MenuItem
    {
        String name;
        String description;
        Boolean vegetarian;
        double price;

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

        public String getName()
        {
            return name;
        }

        public String getDescription()
        {
            return description;
        }

        public double getPrice()
        {
            return price;
        }

        public Boolean isVegetarian()
        {
            return vegetarian;
        }
        public override string ToString()
        {
            return ($"{name} {price} {description}");
        }
    }

    public class DinerMenu : Menu
    {
        public static int MAX_ITEMS = 6;
        public int numberOfItems = 0;
        MenuItem[] menuItems;

        public DinerMenu()
        {
            menuItems = new MenuItem[MAX_ITEMS];

            addItem("Vegetarian BLT",
                "(Fakin') Bacon with lettuce & tomato on whole wheat", true, 2.99);
            addItem("BLT",
                "Bacon with lettuce & tomato on whole wheat", false, 2.99);
            addItem("Soup of the day",
                "Soup of the day, with a side of potato salad", false, 3.29);
            addItem("Hotdog",
                "A hot dog, with sauerkraut, relish, onions, topped with cheese",
                false, 3.05);
            addItem("Steamed Veggies and Brown Rice",
                "Steamed vegetables over brown rice", true, 3.99);
            addItem("Pasta",
                "Spaghetti with Marinara Sauce, and a slice of sourdough bread",
                true, 3.89);
        }
        public void addItem(String name, String description,
                             Boolean vegetarian, double price)
        {
            MenuItem menuItem = new MenuItem(name, description, vegetarian, price);
            if (numberOfItems >= MAX_ITEMS)
            {
                Console.WriteLine("Sorry, menu is full!  Can't add item to menu");
            }
            else
            {
                menuItems[numberOfItems] = menuItem;
                numberOfItems = numberOfItems + 1;
            }
        }

        public MenuItem[] getMenuItems()
        {
            return menuItems;
        }

        public Iterator createIterator()
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
        // other menu methods here
    }
    public class PancakeHouseMenu : Menu
    {
        List<MenuItem> menuItems;
        public PancakeHouseMenu()
        {
            menuItems = new List<MenuItem>();

            addItem("K&B's Pancake Breakfast",
                "Pancakes with scrambled eggs and toast",
                true,
                2.99);

            addItem("Regular Pancake Breakfast",
                "Pancakes with fried eggs, sausage",
                false,
                2.99);

            addItem("Blueberry Pancakes",
                "Pancakes made with fresh blueberries",
                true,
                3.49);

            addItem("Waffles",
                "Waffles with your choice of blueberries or strawberries",
                true,
                3.59);
        }
        public void addItem(String name, String description,
                            Boolean vegetarian, double price)
        {
            MenuItem menuItem = new MenuItem(name, description, vegetarian, price);
            menuItems.Add(menuItem);
        }
        public List<MenuItem> getMenuItems()
        {
            return menuItems;
        }
        public Iterator createIterator()
        {
            return new PancakeHouseMenuIterator(menuItems);
        }
        public override string ToString()
        {
            return "Objectville Pancake House Menu";
        }

        // other menu methods here
    }

    public class DinerMenuIterator : Iterator
    {
        MenuItem[] items;
        int position = 0;
        public DinerMenuIterator(MenuItem[] items)
        {
            this.items = items;
        }
        public MenuItem next()
        {
            MenuItem menuItem = items[position];
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
        List<MenuItem> items;
        int position = 0;
        public PancakeHouseMenuIterator(List<MenuItem> items)
        {
            this.items = items;
        }
        public MenuItem next()
        {
            MenuItem item = items[position];
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

    public class Waitress
    {
        List<Menu> menus = null;
        public Waitress(List<Menu> menus)
        {
            this.menus = menus;
        }

        public void printMenu()
        {
            Console.WriteLine(" ---  Menus  --- ");
            List<Menu>.Enumerator menuIterator = this.menus.GetEnumerator();
            while (menuIterator.MoveNext())
            {
                Menu currentMenu = menuIterator.Current;
                Console.WriteLine(currentMenu.ToString());
                this.printMenu(currentMenu.createIterator());
            }
        }
        public void printMenu(Iterator iterator)
        {
            while (iterator.hasNext())
            {
                MenuItem currentItem = iterator.next();
                Console.WriteLine(currentItem.ToString());
            }
        }
    }

    public class MenuTestDrive
    {
        public static void Test()
        {
            List<Menu> menus = new List<Menu>() { new DinerMenu(), new PancakeHouseMenu() };
            Waitress waitress = new Waitress(menus);
            waitress.printMenu();
        }
    }
}