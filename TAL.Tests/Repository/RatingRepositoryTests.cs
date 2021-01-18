using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TAL.Core.ViewModels;
using TAL.Infrastructure.Data;

namespace TAL.Tests.Repository
{

    [TestFixture]
    public class RatingRepositoryTests
    {
        
        private RatingRepository service;
        [SetUp]
        public void Setup()
        {
            service = new RatingRepository();
        }

        [Test]
        [TestCase(1,1.00)]
        [TestCase(2,1.25)]
        public void GetRating_WhenCalledById_ShouldReturnRatingObj(int ratingId, double expectedFactorValue)
        {
            
            var result = service.GetRating(ratingId);

            Assert.AreEqual(result.Factor, expectedFactorValue);
        }

        [Test]
        public void GetRatings_WhenCalled_ShouldReturnRatingListObj()
        {

            var result = service.GetRatings().ToList();

            Assert.AreEqual(result.Count, 4);
        }
    }
}
