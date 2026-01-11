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
    public class DentistTests
    {
        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Constructor_NullName_Throws()
        {
            // Arrange
            string name = null!;
            var email = new Email("phiwe@example.com");
            // Act
            new Dentist(name, email);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Constructor_NullEmail_Throws()
        {
            // Arrange
            string name = "Dr. Phiwe";
            Email email = null!;
            // Act
            new Dentist(name, email);
        }

        [TestMethod]
        public void Constructor_ValidDentist_NoException()
        {
            // Arrange
            string name = "Dr. Phiwe";
            var email = new Email("phiwe@example.com");
            // Act
            new Dentist(name, email);
        }
    }
}
