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
}
