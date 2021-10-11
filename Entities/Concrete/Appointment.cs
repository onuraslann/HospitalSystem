using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Appointment:IEntity
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int SickId { get; set; }
        public int DoctorId { get; set; }
    }
}
