using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Tests.Domain.Entities
{
    [TestClass]
    public class DentalOfficeTests
    {
        [TestMethod]
        public void Constructor_NullName_Throws()
        {
            // Arrange
            string name = null!;

            // Act
            Action act = () => new DentalOffice(name);

            // Assert
            Assert.ThrowsException<BusinessRuleException>(act);
        }
    }
}
