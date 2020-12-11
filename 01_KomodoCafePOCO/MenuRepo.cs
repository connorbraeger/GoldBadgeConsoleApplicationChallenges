using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_MenuRepo
{
    public class MenuItemRepo
    {
        private List<MenuItem> _menu = new List<MenuItem>();
        public bool AddMenuItem(MenuItem newItem)
        {
            bool added = false;
            if (IsInMenu(newItem)) 
            {
                return added;
            }
            else
            {
                _menu.Add(newItem);
                added = true;
                return added;
            }
        }
        public List<MenuItem> GetMenuList()
        {
            return _menu;
        }
        public bool RemoveMenuItem(MenuItem menuItem)
        {
            return _menu.Remove(menuItem);
        }
        public bool IsInMenu(MenuItem checkItem)
        {
            bool isInMenu = false;
            foreach (var item in _menu)
            {
                if(item ==checkItem)
                {
                    return !isInMenu;
                }
            }return isInMenu;
        }
        public MenuItem GetFoodByName(string name)
        {
           
            foreach (var item in _menu)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }
        public MenuItem GetFoodByNumber(int num)
        {

            foreach (var item in _menu)
            {
                if (item.Number == num)
                {
                    return item;
                }
            }
            return null;
        }
        public bool IsInMenu(string name)
        {
            bool isInMenu = false;
            foreach (var item in _menu)
            {
                if (item.Name == name)
                {
                    return !isInMenu;
                }
            }
            return isInMenu;
        }
        public bool IsInMenu(int number)
        {
            bool isInMenu = false;
            foreach (var item in _menu)
            {
                if (item.Number == number)
                {
                    return !isInMenu;
                }
            }
            return isInMenu;
        }
    }
}
