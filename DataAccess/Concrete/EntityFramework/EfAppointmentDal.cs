using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAppointmentDal : EntityRepositoryBase<Appointment, HospitalContext>, IAppointmentDal
    {
        public List<AppointmentDtoDetails> GetByDto()
        {
            using (HospitalContext context = new HospitalContext())
            {
                var result = from doctor in context.Doctors
                             join appointments in context.Appointments
on doctor.Id equals appointments.DoctorId
                             join sick in context.Sicks
                             on appointments.SickId equals sick.Id
                             select new AppointmentDtoDetails
                             {
                                 FirstName = doctor.FirstName,
                                 LastName = doctor.LastName,
                                 FirsstName = sick.FirstName,
                                 LasstName = sick.LastName,
                                 Tc = sick.Tc,
                                 DateOfBirth = sick.DateOfBirth,
                                 Phone = sick.Phone,
                                 AppointmentDate = appointments.AppointmentDate

                             };
                return result.ToList();

            }
        }
    }
}
