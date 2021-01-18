using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TAL.Infrastructure.Data;

namespace TAL.Tests.Repository
{
    [TestFixture]
    public class OccupationRepositoryTests
    {
        private OccupationRepository service;
        [SetUp]
        public void Setup()
        {
            service = new OccupationRepository();
        }

        [Test]
        [TestCase(1, "Cleaner")]
        [TestCase(2, "Doctor")]
        public void GetOccupation_WhenCalledById_ShouldReturnOccupationObj(int occupationId, string expectedOccupationNameValue)
        {

            var result = service.GetOccupation(occupationId);

            Assert.AreEqual(result.Name, expectedOccupationNameValue);
        }

        [Test]
        public void GetOccupations_WhenCalled_ShouldReturnOccupationListObj()
        {

            var result = service.GetOccupations().ToList();

            Assert.AreEqual(result.Count, 6);
        }
    }
}
