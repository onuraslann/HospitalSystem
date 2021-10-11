using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Prescription:IEntity
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string DoctorStatment { get; set; }
        public DateTime PrescriptionsDate { get; set; }
    }
}
