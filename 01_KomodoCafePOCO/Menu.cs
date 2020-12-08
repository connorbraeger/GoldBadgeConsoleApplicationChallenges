using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafePOCO
{
    public class Menu
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string  Description{ get; set; }
        public List<string> IngredientList { get; set; }
        public decimal Price { get; set; }
        public Menu()
        {
            Number = 0;
            Name = "";
            Description = "";
            IngredientList = new List<string>();
            Price = 0;
        }
        public Menu(int num, string name, string description, List<string> ingredientList, decimal price)
        {
            Number = num;
            Name = name;
            Description = description;
            IngredientList = ingredientList;
            Price = price;
        }
        public Menu (Menu menu)// Copy Constructor
        {
            Number = menu.Number;
            Name = menu.Name;
            Description = menu.Description;
            IngredientList = menu.IngredientList;
            Price = menu.Price;
        }
    }
}
