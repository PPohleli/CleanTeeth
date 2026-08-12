using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Enums;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleanTeeth.Tests.Domain.Entities
{
    [TestClass]
    public class AppointmentTests
    {
        // mock dependencies
        private Guid _patientId = Guid.NewGuid();
        private Guid _dentistId = Guid.NewGuid();
        private Guid _dentalOfficeId = Guid.NewGuid();
        private TimeInterval _interval = new TimeInterval(DateTime.UtcNow.AddHours(1), DateTime.UtcNow.AddHours(2));


        [TestMethod]
        public void Constructor_ValidAppointment_StatusScheduled()
        {
            // Act
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _interval);
            
            // Assert
            Assert.AreEqual(_patientId, appointment.PatientId);
            Assert.AreEqual(_dentistId, appointment.DentistId);
            Assert.AreEqual(_dentalOfficeId, appointment.DentalOfficeId);
            Assert.AreEqual(_interval, appointment.TimeInterval);
            Assert.AreEqual(AppointmentStatus.Scheduled, appointment.Status);
            Assert.AreNotEqual(Guid.Empty, appointment.Id);
        }

        [TestMethod]
        public void Constructor_StartTimeInThePast_Throws()
        {
            // Arrange
            var intervalInThePast = new TimeInterval(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow);

            // Act
            Action act = () => new Appointment(_patientId, _dentistId, _dentalOfficeId, intervalInThePast);

            // Assert
            Assert.ThrowsException<BusinessRuleException>(act);
        }

        [TestMethod]
        public void Cancel_CancellingAppointment_ChangesStatusToCancelled()
        {
            // Arrange
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _interval);

            // Act
            appointment.Cancel();

            // Assert
            Assert.AreEqual(AppointmentStatus.Cancelled, appointment.Status);
        }

        [TestMethod]
        public void Cancel_CancellingCancelledAppointment_Throws()
        {
            // Arrange
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _interval);
            appointment.Cancel();

            // Act
            Action act = () => appointment.Cancel();

            // Assert
            Assert.ThrowsException<BusinessRuleException>(act);
        }

        [TestMethod]
        public void Cancel_CancellingCompletedAppointment_Throw()
        {
            // Arrange
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _interval);
            appointment.Complete();

            // Act
            Action act = () => appointment.Cancel();

            // Assert
            Assert.ThrowsException<BusinessRuleException>(act);
        }

        [TestMethod]
        public void Complete_CompletingAppointment_ChangesStatusToCompleted()
        {
            // Arrange
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _interval);

            // Act
            appointment.Complete();

            // Assert
            Assert.AreEqual(AppointmentStatus.Completed, appointment.Status);
        }

        [TestMethod]
        public void Complete_CompletingCompletedAppointment_Throw()
        {
            // Arrange
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _interval);
            appointment.Complete();

            // Act
            Action act = () => appointment.Complete();

            // Assert
            Assert.ThrowsException<BusinessRuleException>(act);
        }

        [TestMethod]
        public void Complete_CompletingCancelledAppointment_Throw()
        {
            // Arrange
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _interval);
            appointment.Cancel();

            // Act
            Action act = () => appointment.Complete();

            // Assert
            Assert.ThrowsException<BusinessRuleException>(act);
        }
    }
}
