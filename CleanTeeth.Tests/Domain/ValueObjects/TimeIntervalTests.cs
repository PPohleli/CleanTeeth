using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Tests.Domain.ValueObjects
{
    [TestClass]
    public class TimeIntervalTests
    {

        [TestMethod]
        public void Construstor_StartIsAfterEnd_Throws()
        {
            //Arrange
            var start = DateTime.UtcNow.AddDays(1);
            var end = DateTime.UtcNow;

            //Act
            Action act = delegate
            {
                new TimeInterval(start, end);
            };

            //Assert
            Assert.ThrowsException<BusinessRuleException>(act);

        }

        [TestMethod]
        public void Construstor_ValidTimeInterval_Throws()
        {
            //Arrange
            var start = DateTime.UtcNow;
            var end = DateTime.UtcNow.AddDays(5);

            //Act
            var result = new TimeInterval(start, end);

            //Assert
            Assert.IsNotNull(result);

        }
    }
}
