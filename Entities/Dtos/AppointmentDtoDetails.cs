using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
   public  class AppointmentDtoDetails:IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FirsstName { get; set; }
        public string LasstName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Tc { get; set; }
        public string Phone { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
