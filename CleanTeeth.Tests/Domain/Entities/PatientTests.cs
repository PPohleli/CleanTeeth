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
        [ExpectedException(typeof(BusinessRuleException))]
        public void Constructor_NullName_Throws()
        {
            // Arrange
            string name = null!;
            var email = new Email("patient@example.com");
            // Act
            new Patient(name, email);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Constructor_NullEmail_Throws()
        {
            // Arrange
            string name = "Mr Patient";
            Email email= null!;
            // Act
            new Patient(name, email);
        }

        [TestMethod]
        public void Constructor_ValidPatient_NoException()
        {
            // Arrange
            string name = "Mr Patient";
            var email = new Email("patient@example.com");
            // Act
            new Patient(name, email);
        }
    }
}
