using System;
using _02_ClaimsRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace _02_ClaimsUnitTesting
{
    [TestClass]
    public class ClaimsTests
    {

        private Claims _claim1;
       
        [TestInitialize]
        public void Arrange()
        {
            Claims.NextClaim = 1;
            _claim1 = new Claims(TypeOfClaim.Car, "rear ending", 15000, new DateTime(2020, 01, 01), new DateTime(2020, 1, 30));
           

        }

        [TestMethod]
        public void TestEmptyClaimsConstructor()
        {
            Claims claim = new Claims();
            Assert.AreEqual(2, claim.ClaimNumber);
            Assert.IsTrue(claim.IsValid);
            Assert.AreEqual("Information needed.", claim.Description);
            Assert.AreEqual(claim.DateOfIncident.Date, claim.DateOfClaim.Date);
        }
        [TestMethod]
        public void TestNonEmptyClaimsConstructor()
        {

            Assert.IsTrue(_claim1.IsValid);
            Assert.AreEqual(1, _claim1.ClaimNumber);

        }
    }
    [TestClass]
    public class ClaimsRepoTests
    {

        private Claims _claim1;
        private Claims _claim2;
        private Claims _claim3;
        private Claims _claim4;
        private ClaimsRepo _claimsRepo;
        [TestInitialize]
        public void Arrange()
        {
            Claims.NextClaim = 1;
            _claim1 = new Claims(TypeOfClaim.Car, "rear ending", 15000, new DateTime(2020, 01, 01), new DateTime(2020, 1, 30));
            _claim2 = new Claims(TypeOfClaim.Home, "The Floods man, The floods", 170000, new DateTime(2020, 02, 02), new DateTime(2020, 5, 30));
            _claim3 = new Claims(TypeOfClaim.Theft, "Election stolen", 80000000, new DateTime(2020, 11, 04), new DateTime(2020, 12, 12));
            _claim4 = new Claims(TypeOfClaim.Car, "Small Scratch", 149.35m, new DateTime(2020, 05, 07), new DateTime(2020, 05, 15));
            _claimsRepo = new ClaimsRepo();
            _claimsRepo.AddClaim(_claim1);

        }
        [TestMethod]
        public void TestAddMethod()
        {

            Assert.IsTrue(_claimsRepo.AddClaim(_claim2));
            Assert.IsFalse(_claimsRepo.AddClaim(_claim1));
            Assert.AreEqual(2, _claimsRepo.GetClaimsQueue().Count);
            Assert.IsTrue(_claimsRepo.GetClaimsQueue().Contains(_claim2));
        }
        [TestMethod]
        public void TestReadMethod()
        {
            Queue<Claims> testQueue = _claimsRepo.GetClaimsQueue();
            Assert.AreEqual(_claimsRepo.GetClaimsQueue(), testQueue);
            Assert.IsNotNull(testQueue);
            Assert.AreEqual(_claim1, testQueue.Peek());
        }
        [TestMethod]
        public void TestDeleteMethod()
        {

            _claimsRepo.RemoveClaim();
            Assert.AreEqual(0, _claimsRepo.GetClaimsQueue().Count);
            Assert.IsFalse(_claimsRepo.GetClaimsQueue().Contains(_claim1));
        }
        
    }
}

