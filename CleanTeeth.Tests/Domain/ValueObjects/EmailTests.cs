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
    public class EmailTests
    {
        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Constructor_NullEmail_Throws()
        {
            new Email(null!);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Constructor_EmailWithoutAtSign_Throws()
        {
            new Email("Phiwe.com");
        }

        [TestMethod]
        public void Constructor_ValidEmail_NoException()
        {
            // Arrange
            var validEmail = "Phiwe@example.com";
            // Act
            new Email(validEmail);
        }
    }
}
