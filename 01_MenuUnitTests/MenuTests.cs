using System;
using System.Collections.Generic;
using System.Linq;
using _01_MenuRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_MenuUnitTests
{
    [TestClass]
    public class MenuItemTests
    {
        [TestMethod]
        public void TestEqualityComp()
        {
            List<string> ingredients = new List<string>() { "chicken", "butter", "cheese" };

            MenuItem item1 = new MenuItem();
            MenuItem item2 = new MenuItem(1, "Butter Chicken", "It is buttery chicken", ingredients, 7.85m);
            MenuItem item3 = new MenuItem(item2);
            bool listComp = (item2.IngredientList.SequenceEqual(item3.IngredientList));
            bool isEqual = (item2 == item3);
            Assert.AreEqual(true, listComp);
            Assert.AreEqual(true,isEqual);

        }
        [TestMethod]
        public void TestEqualsMethod()
        {
            List<string> ingredients = new List<string>() { "chicken", "butter", "cheese" };
            MenuItem item2 = new MenuItem(1, "Butter Chicken", "It is buttery chicken", ingredients, 7.85m);
            MenuItem item3 = new MenuItem(1, "Butter Chicken", "It is buttery chicken", ingredients, 7.85m);
            bool equal = item2.Equals(item3);
            Assert.AreEqual(true, equal);
        }
    }
    [TestClass]
    public class MenuRepoTests
    {
        List<string> _list1;
        List<string> _list2;
        List<string> _list3;
        MenuItem _item1;
        MenuItem _item2;
        MenuItem _item3;
        MenuItemRepo _repo;
        [TestInitialize]
        public void Arrange()
        {
            _list1 = new List<string>() { "chicken", "butter", "cheese" };
            _list2 = new List<string>() {  "pork", "bbq", "onions"  };
            _list3 = new List<string>() { "beef", "buns", "lettuce" };
            _item1 = new MenuItem(1, "Butter Chicken", "It is buttery chicken", _list1, 7.85m);
            _item2 = new MenuItem(2, "BBQ Pork", "It is bbq pork", _list2, 10.25m);
            _item3 = new MenuItem(3, "Hamburger", "It's a hamburger", _list3, 6.75m);
            _repo = new MenuItemRepo();
            _repo.AddMenuItem(_item1);
            _repo.AddMenuItem(_item2);
            _repo.AddMenuItem(_item3);

        }
        [TestMethod]
        public void TestAddMethod()
        {
            List<string> newIngredients = new List<string>() { "mac", "cheese", "butter" };
            MenuItem newMenuItem = new MenuItem(4, "mac and cheese", "it is cheesy noodles", newIngredients, 10.55m);
            MenuItem falseMenuItem = new MenuItem(_item1);
            Assert.IsTrue(_repo.AddMenuItem(newMenuItem));
            Assert.IsFalse(_repo.AddMenuItem(falseMenuItem));
            List<MenuItem> addList = new List<MenuItem>(_repo.GetMenuList());
            bool hasMenuItem = false;
            foreach (MenuItem item in addList) 
            { 
                if (item == newMenuItem)
                {
                    hasMenuItem = true;
                    break;
                }
            }
            Assert.IsTrue(hasMenuItem);

            
        }
        [TestMethod]
        public void TestReadMethod()
        {
            List<MenuItem> testList = new List<MenuItem>(_repo.GetMenuList());
            Assert.IsNotNull(testList);
            Assert.AreEqual(_item1, testList.ElementAt(0));
            Assert.AreEqual(_item2, testList.ElementAt(1));
            Assert.AreEqual(_item3, testList.ElementAt(2));


        }
        [TestMethod]
        public void TestDeleteMethod()
        {
            List<string> newIngredients = new List<string>() { "mac", "cheese", "butter" };
            MenuItem newMenuItem = new MenuItem(4, "mac and cheese", "it is cheesy noodles", newIngredients, 10.55m);
            bool falseDelete = _repo.RemoveMenuItem(newMenuItem);
            bool trueDelete = _repo.RemoveMenuItem(_item3);
            Assert.IsTrue(trueDelete);
            Assert.IsFalse(falseDelete);
            Assert.AreEqual(2, _repo.GetMenuList().Count);
        }
        [TestMethod]
        public void TestIsInMenu()
        {
            MenuItem testItem = new MenuItem();
            Assert.IsTrue(_repo.IsInMenu(_item1));
            Assert.IsFalse(_repo.IsInMenu(testItem));

        }
        [TestMethod]
        public void TestIsInMenu_String()
        {
            string name = "fake food";
            Assert.IsTrue(_repo.IsInMenu(_item1.Name));
            Assert.IsFalse(_repo.IsInMenu(name));
        }
        [TestMethod]
        public void TestIsInMenu_Int()
        {
            int menuNum = 147;
            Assert.IsTrue(_repo.IsInMenu(_item1.Number));
            Assert.IsFalse(_repo.IsInMenu(menuNum));
        }
        [TestMethod]
        public void TestGetFoodByName()
        {
            MenuItem testMenuItem = _repo.GetFoodByName(_item1.Name);
            Assert.AreEqual(_item1, testMenuItem);
        }
        [TestMethod]
        public void TestGetFoodByNumber()
        {
            MenuItem testMenuItem = _repo.GetFoodByNumber(_item1.Number);
            Assert.AreEqual(_item1, testMenuItem);
        }
    }
}
