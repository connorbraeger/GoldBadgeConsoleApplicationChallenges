using System;
using System.Collections.Generic;
using _03_BadgeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_BadgeUnitTests
{
    [TestClass]
    public class BadgeRepoTests
    {
        private List<string> _list1;
        private List<string> _list2;
        private List<string> _list3;
        private List<string> _list4;
        private Badge _badge1;
        private Badge _badge2;
        private Badge _badge3;
        private Badge _badge4;
        private BadgeRepo _repo;

        [TestInitialize]
        public void Arrange()
        {
            _list1 = new List<string>() { "room_a", "room_b", "room_c" };
            _list2 = new List<string>() { "room_d", "room_e", "room_f" };
            _list3 = new List<string>() { "room_g", "room_h", "room_i" };
            _list4 = new List<string>() { "room_j", "room_k", "room_l" };
            _badge1 = new Badge(1, _list1);
            _badge2 = new Badge(2, _list1);
            _badge3 = new Badge(3, _list1);
            _badge4 = new Badge(4, _list1);
            _repo = new BadgeRepo();
            _repo.AddBadge(_badge1);
            _repo.AddBadge(_badge2);
            _repo.AddBadge(_badge3);
            _repo.AddBadge(_badge4);


        }



        [TestMethod]
        public void TestConstructor()
        {
            BadgeRepo testRepo;
            BadgeRepo nullTest = null;
            testRepo = new BadgeRepo();
            Assert.IsNotNull(testRepo);
            Assert.IsNull(nullTest);
        }
        [TestMethod]
        public void TestAddMethod()
        {
            List<string> addList = new List<string>() { "room_x", "room_y", "room_z" };
            Badge addBadgeTrue = new Badge(5, addList);
            Badge addBadgeFalse = new Badge(1, addList);
            Assert.IsTrue(_repo.AddBadge(addBadgeTrue));
            Assert.IsFalse(_repo.AddBadge(addBadgeFalse));
            Dictionary<int, Badge> addDict = new Dictionary<int, Badge>(_repo.GetBadgeDictionary());
            bool hasBadge = false;
            foreach (Badge item in addDict.Values)
            {
                if (item == addBadgeTrue)
                {
                    hasBadge = true;
                    break;
                }
            }
            Assert.IsTrue(hasBadge);
        }
        [TestMethod]
        public void TestReadMethod()
        {
            Dictionary<int, Badge> testDictionary = new Dictionary<int, Badge>(_repo.GetBadgeDictionary());
            Assert.IsNotNull(testDictionary);
            Assert.AreEqual(_badge1, testDictionary[1]);
            Assert.AreEqual(_badge2, testDictionary[2]);
            Assert.AreEqual(_badge3, testDictionary[3]);
            Assert.AreEqual(_badge4, testDictionary[4]);

        }
        [TestMethod]
        public void TestUpdateMethod()
        {
            List<string> addList = new List<string>() { "room_x", "room_y", "room_z" };
            Badge newBadge = new Badge(5, addList);
            _badge1.RoomList.Add("room_d");
            _badge2.RoomList = new List<string>(addList);
            bool trueUpdate1 = _repo.UpdateBadge(_badge1);
            bool trueUpdate2 = _repo.UpdateBadge(_badge2);
            bool falseUpdate = _repo.UpdateBadge(newBadge);
            Assert.IsTrue(_repo.GetBadgeDictionary()[_badge1.BadgeID].RoomList.Contains("room_d"));
            Assert.IsTrue(_repo.GetBadgeDictionary()[_badge2.BadgeID].RoomList.Contains("room_x"));

            Assert.IsTrue(trueUpdate1);
            Assert.IsTrue(trueUpdate2);
            Assert.IsFalse(falseUpdate);

        }
        [TestMethod]
        public void TestDeleteMethod()
        {
            List<string> addList = new List<string>() { "room_x", "room_y", "room_z" };
            Badge newBadge = new Badge(5, addList);
            bool falseDelete = _repo.deleteBadge(newBadge);
            bool trueDelete = _repo.deleteBadge(_badge1);
            Assert.IsTrue(trueDelete);
            Assert.IsFalse(falseDelete);
        }
        

        
    }
}


