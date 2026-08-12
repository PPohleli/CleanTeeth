using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CleanTeeth.Tests.Domain.Entities
{
    [TestClass]
    public class DentistTests
    {
        [TestMethod]
        public void Constructor_InvalidDentistNullName_Throws()
        {
            // Arrange
            string name = null!;
            var email = new Email("testD@gmail.com");

            // Act
            Action act = () => new Dentist(name, email);

            // Assert
            Assert.ThrowsException<BusinessRuleException>(act);
        }

        [TestMethod]
        public void Constructor_InvalidDentistNullEmail_Throws()
        {
            // Arrange
            string name = "TestD TestingD";
            Email email = null!;

            // Act
            Action act = () => new Dentist(name, email);

            // Assert
            Assert.ThrowsException<BusinessRuleException>(act);
        }

        [TestMethod]
        public void Constructor_ValidDentist()
        {
            // Arrange
            string name = "TestD TestingD";
            var email = new Email("testD@gmail.com");

            // Act
            var result = new Dentist(name, email);

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
