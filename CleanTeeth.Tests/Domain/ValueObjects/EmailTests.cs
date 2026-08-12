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
        public void Constructor_NullEmail_Throws()
        {
            // Arrange
            string email = null!;

            // Act
            Action act = () => new Email(email);

            // Assert
            Assert.ThrowsException<BusinessRuleException>(act);
        }

        [TestMethod]
        public void Constructor_EmailWithoutAt_Throws()
        {
            // Arrange
            string email = "test.com";

            // Act
            Action act = () => new Email(email);

            // Assert
            Assert.ThrowsException<BusinessRuleException>(act);
        }

        [TestMethod]
        public void Constructor_ValidEmail_CreatesEmail()
        { 
            // Arrange
            string email = "test.testing@gmail.com"; 
            
            //Act
            var result = new Email(email); 
            
            // Assert
            Assert.IsNotNull(result); }
        }
}
