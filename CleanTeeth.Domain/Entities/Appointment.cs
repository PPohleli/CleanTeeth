using CleanTeeth.Domain.Enums;
using CleanTeeth.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Domain.Entities
{
    public class Appointment
    {
        public Guid Id { get; private set; }
        public Guid PatientId { get; private set; }
        public Guid DentistId { get; private set; }
        public Guid DentalOfficeId { get; private set; }

        public AppointmentStatus Status { get; private set; }

        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public Patient? Patient { get; private set; }
        public Dentist? Dentist { get; private set; }
        public DentalOffice? DentalOffice { get; private set; }

        public Appointment(Guid patientId, Guid dentistId, Guid dentalOfficeId, DateTime startTime, DateTime endTime)
        {
            if (startTime > endTime)
            {
                throw new BusinessRuleException("Start time cannot be  after the end time of the appointment.");
            }

            if (startTime < DateTime.UtcNow)
            {
                throw new BusinessRuleException("Start time cannot be in the past.");
            }

            PatientId = patientId;
            DentistId = dentistId; 
            DentalOfficeId = dentalOfficeId;
            StartTime = startTime;
            EndTime = endTime;
            Status = AppointmentStatus.Scheduled;
            Id = Guid.CreateVersion7();
        }

        public void Cancel()
        {
            if (Status != AppointmentStatus.Scheduled)
            {
                throw new BusinessRuleException("Only scheduled appointments is can be canceled.");
            }
            Status = AppointmentStatus.Canceled;
        }

        public void Complete()
        {
            if (Status != AppointmentStatus.Scheduled)
            {
                throw new BusinessRuleException("Only scheduled appointments is can be completed.");
            }
            Status = AppointmentStatus.Completed;
        }
    }
}
