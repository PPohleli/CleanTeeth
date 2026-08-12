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
    public class PatientTests
    {
        [TestMethod]
        public void Constructor_InvalidPatientNullName_Throws()
        {
            // Arrange
            string name = null!;
            var email = new Email("testP@gmail.com");

            // Act
            Action act = () => new Patient(name, email);

            // Assert
            Assert.ThrowsException<BusinessRuleException>(act);
        }

        [TestMethod]
        public void Constructor_InvalidPatientNullEmail_Throws()
        {
            // Arrange
            string name = "TestP TestingP";
            Email email = null!;

            // Act
            Action act = () => new Patient(name, email);

            // Assert
            Assert.ThrowsException<BusinessRuleException>(act);
        }

        [TestMethod]
        public void Constructor_ValidPatient()
        {
            // Arrange
            string name = "TestP TestingP";
            var email = new Email("testP@gmail.com");

            // Act
            var result = new Patient(name, email);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
