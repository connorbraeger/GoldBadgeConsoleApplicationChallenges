using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_MenuRepo
{
    public class MenuItem
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> IngredientList { get; set; }
        public decimal Price { get; set; }
        public MenuItem()
        {
            Number = 0;
            Name = "";
            Description = "";
            IngredientList = new List<string>();
            Price = 0;
        }
        public MenuItem(int num, string name, string description, List<string> ingredientList, decimal price)
        {
            Number = num;
            Name = name;
            Description = description;
            IngredientList = new List<string>(ingredientList);
            Price = price;
        }
        public MenuItem(MenuItem menuItem)// Copy Constructor
        {
            Number = menuItem.Number;
            Name = menuItem.Name;
            Description = menuItem.Description;
            IngredientList = new List<string>(menuItem.IngredientList);
            Price = menuItem.Price;
        }
        public static bool operator ==(MenuItem lhs, MenuItem rhs)
        {
            bool isEqual = false;
            if ((lhs.Name != rhs.Name) || (lhs.Number != rhs.Number) || (lhs.Price != rhs.Price) || !(lhs.IngredientList.SequenceEqual(rhs.IngredientList)))
            {
                return isEqual;
            }
            else
            {
                return !isEqual;
            }

        }
        public static bool operator !=(MenuItem lhs, MenuItem rhs)
        {
            return (!(lhs == rhs));
        }
        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                MenuItem menuItem = (MenuItem)obj;
                return (this == menuItem);
            }

        }
        public override int GetHashCode()
        {
            int hashCode = (int)Price * Number * Name.Length * Description.Length * IngredientList.Count;
            return hashCode;
        }
    }       
}
