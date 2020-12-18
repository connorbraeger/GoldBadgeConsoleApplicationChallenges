using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_MenuRepo;

namespace _01_MenuUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> ingredients = new List<string>() { "chicken", "butter", "cheese" };

            MenuItem item1 = new MenuItem();
            MenuItem item2 = new MenuItem(1, "Butter Chicken", "It is buttery chicken", ingredients, 7.85m);
            MenuItem item3 = new MenuItem(item2);
            MenuUi main = new MenuUi();
            main.Run();
        }
    }
    class MenuUi
    {
        private MenuItemRepo _menuRepo = new MenuItemRepo();
       
        public void  Run()
        {
            SeedMenu();
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add New Item to Menu\n" +
                    "2. View Menu\n" +
                    "3. Delete Item From Menu\n" +
                    "4. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddNewItem();
                        break;
                    case "2":
                        ViewMenu();
                        break;
                    case "3":
                        DeleteItem();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
            }
        }
        public void AddNewItem()
        {
            Console.Clear();
            bool keepRunning = true;
            while (keepRunning)
            {
                bool isValid = false;
                while (!isValid)
                {
                    Console.WriteLine("Please enter name of menu item: ");
                    string itemName = Console.ReadLine().ToLower();
                    if (_menuRepo.IsInMenu(itemName))
                    {
                        Console.WriteLine("This name already exists in the menu.");
                    }
                    else
                    {
                        isValid = true;
                        bool isValidMenuNum = false;
                        while (!isValidMenuNum)
                        {
                            Console.WriteLine("Please enter item number");
                            int itemNum;
                            bool isInt = GetNumberInput(out itemNum);
                            if (isInt)
                            {

                                bool isAlreadyAssigned = _menuRepo.IsInMenu(itemNum);
                                if (isAlreadyAssigned)
                                {
                                    Console.WriteLine("Number already Assigned. Please choose a different number");
                                }
                                else
                                {
                                    isValidMenuNum = true;
                                    decimal price;
                                    bool isValidMenuPrice = false;
                                    while (!isValidMenuPrice)
                                    {
                                        Console.WriteLine("Please enter a price.");
                                        bool isDec = GetNumberInput(out price);
                                        if (isDec)
                                        {
                                            isValidMenuPrice = true;
                                            char[] separator = { ',' };
                                            Console.WriteLine("Please enter a description for the menu item");
                                            string description = Console.ReadLine();
                                            Console.WriteLine("Please enter ingredients seperated by commas");
                                            string ingredients = Console.ReadLine().ToLower().Trim();
                                            string[] ingredientsArray = ingredients.Split(separator);
                                            List<string> ingredientsList = new List<string>(ingredientsArray);
                                            MenuItem newItem = new MenuItem(itemNum, itemName, description, ingredientsList, price);
                                            _menuRepo.AddMenuItem(newItem);
                                            keepRunning = false;
                                        }
                                        else
                                        {
                                            keepRunning = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public void ViewMenu()
        {
            Console.Clear();
            List<MenuItem> sortedList = SortMenu(); 
            foreach(var menuItem in sortedList)
            {
                string allIngredients = String.Join("||", menuItem.IngredientList);
               
                Console.WriteLine($"Item #{menuItem.Number}: {menuItem.Name} \n" +
                    $"Price: ${menuItem.Price} \n" +
                    $"Description: {menuItem.Description}\n" +
                    $"Ingredients: {allIngredients}");
                
                
                
                    
            }
            Console.ReadKey();
        }
        public void DeleteItem()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Please enter the number item to be deleted: ");
                int menuNum;
                if (GetNumberInput(out menuNum))
                {
                    if (!_menuRepo.IsInMenu(menuNum))
                    {
                        Console.WriteLine("Please enter a valid number");
                    }
                    else
                    {
                        MenuItem delMenuItem = _menuRepo.GetFoodByNumber(menuNum);
                        _menuRepo.RemoveMenuItem(delMenuItem);
                        Console.WriteLine("Menu item deleted");
                        keepRunning = false;
                    }
                }
            }
        }
        public bool GetNumberInput(out int i)//takes an int parameter, returns true if int assigned, returns false otherwise. Sets int to zero if no value assigned.
        {
            string input;
            bool isInt = false;
            while (!isInt)
            {
                input = Console.ReadLine();
                isInt = int.TryParse(input, out i);
                if (isInt)
                {
                    return true;
                }
                else if (input.ToLower() == "exit")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Please input a number or type exit to cancel.");
                }

            }
            i = 0;
            return false;
        }
        public bool GetNumberInput(out decimal i)//takes an int parameter, returns true if int assigned, returns false otherwise. Sets int to zero if no value assigned.
        {
            string input;
            bool isDecimal = false;
            while (!isDecimal)
            {
                input = Console.ReadLine();
                isDecimal = decimal.TryParse(input, out i);
                if (isDecimal)
                {
                    return true;
                }
                else if (input.ToLower() == "exit")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Please input a number or type exit to cancel.");
                }

            }
            i = 0;
            return false;
        }
        public void SeedMenu()
        {
            List<string> ingredients1 = new List<string>() { "chicken", "butter", "cheese" };
            List<string> ingredients2 = new List<string>() { "pork", "bbq", "onions" };
            List<string> ingredients3 = new List<string>() { "beef", "buns", "lettuce" };


            MenuItem item1 = new MenuItem(1, "Butter Chicken", "It is buttery chicken", ingredients1, 7.85m);
            MenuItem item2 = new MenuItem(2, "BBQ Pork", "It is bbq pork", ingredients2, 10.25m);
            MenuItem item3 = new MenuItem(3, "Hamburger", "It's a hamburger", ingredients3, 6.75m);
            _menuRepo.AddMenuItem(item1);
            _menuRepo.AddMenuItem(item2);
            _menuRepo.AddMenuItem(item3);

        }
        public List<MenuItem> SortMenu()
        {
            List<MenuItem> sortedList = new List<MenuItem>(_menuRepo.GetMenuList());
            return sortedList.OrderBy(i => i.Number).ToList();

        }
    }
}
