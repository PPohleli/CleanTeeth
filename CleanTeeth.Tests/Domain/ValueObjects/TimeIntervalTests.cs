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
        [ExpectedException(typeof(BusinessRuleException))]
        public void Constructor_StartisAfterEnd_Throws()
        {
            // Arrange
            DateTime start = DateTime.UtcNow;
            DateTime end = DateTime.UtcNow.AddDays(-1);

            // Act
            new TimeInterval(start, end);
        }

        [TestMethod]
        public void Constructor_ValidTimeInterval_NoException()
        {
            // Arrange
            DateTime start = DateTime.UtcNow;
            DateTime end = DateTime.UtcNow.AddHours(1);

            // Act
            new TimeInterval(start, end);
        }
    }
}
