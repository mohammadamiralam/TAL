using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tal.Core.Interfaces.Repo;
using TAL.Web.Controllers;

namespace TAL.Tests.Integration
{
    [TestFixture]
    public class OccupationControllerTests
    {
        [Test]
        public void GetOccupations_WhenCalled_SholdGetOccupationLists()
        {
            var storage = new Mock<IOccupationRepository>();
            var controller = new OccupationController(storage.Object);

            controller.GetOccupations();

            storage.Verify(v => v.GetOccupations());
        }
    }
}
