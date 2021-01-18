using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TAL.Core.Services;
using TAL.Core.ViewModels;
using TAL.Infrastructure.Data;

namespace TAL.Tests.Services
{
    [TestFixture]
    public class MonthlyPremiumCalculatorTests
    {
        private UserDetails _userDetails;
        private MonthlyPremiumCalculator service;
        [SetUp]
        public void Setup()
        {
            

            
            service = new MonthlyPremiumCalculator(new RatingRepository());
        }

        [Test]
        public void Calculate_WhenCalled_ShouldReturnPremiumValue()
        {
            _userDetails = new UserDetails { Name = "a", Age = 36, SumInsured = 150000, Occupation = new Occupation() { RatingId = 1 } };
            var result = service.Calculate(_userDetails);

            Assert.AreEqual(result, (double)64800);
        }

        [Test]
        public void Calculate_WhenUserDetailsIsNull_WhenCalled_ShouldReturnArgumentException()
        {
            _userDetails = null;
            TestDelegate act = () => service.Calculate(_userDetails);
            Assert.Throws<ArgumentNullException>(act, "UserDetails class is null");
        }

        [Test]
        public void Calculate_WhenAgeIsNotValid_WhenCalled_ShouldReturnArgumentException()
        {
            _userDetails = new UserDetails { Name = "a", Age = 0, SumInsured = 150000, Occupation = new Occupation() { RatingId = 1 } };
            TestDelegate act = () => service.Calculate(_userDetails);
            Assert.Throws<ArgumentException>(act, "UserDetails class is null");
        }

        [Test]
        public void Calculate_WhenSumInsuredIsNotValid_WhenCalled_ShouldReturnArgumentException()
        {
            _userDetails = new UserDetails { Name = "a", Age = 36, SumInsured = 0, Occupation = new Occupation() { RatingId = 1 } };
            TestDelegate act = () => service.Calculate(_userDetails);
            Assert.Throws<ArgumentException>(act, "UserDetails class is null");
        }

        [Test]
        public void Calculate_WhenFactorIsNotValid_WhenCalled_ShouldReturnArgumentException()
        {
            _userDetails = new UserDetails { Name = "a", Age = 36, SumInsured = 150000, Occupation = null };
            TestDelegate act = () => service.Calculate(_userDetails);
            Assert.Throws<ArgumentNullException>(act, "UserDetails class is null");
        }
    }
}
