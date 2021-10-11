using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AppointmentManager : IAppointmentService
    {
        IAppointmentDal _appointmentDal;
public AppointmentManager(IAppointmentDal appointmentDal)
        {
            _appointmentDal = appointmentDal;
        }

        public IResult Add(Appointment appointment)
        {
            appointment.AppointmentDate = DateTime.Now;
            _appointmentDal.Add(appointment);
            return new SuccessResult(Messages.AppointmentAdded);
        }

        public IResult Delete(Appointment appointment)
        {
            _appointmentDal.Delete(appointment);
            return new SuccessResult(Messages.AppointmentDeleted);
        }

        public IDataResult<List<Appointment>> GetAll()
        {
            return new SuccessDataResult<List<Appointment>>(_appointmentDal.GetAll());
        }

        public IDataResult<List<Appointment>> GetByDoctor(int doctorid)
        {
            return new SuccessDataResult<List<Appointment>>(_appointmentDal.GetAll(x=>x.DoctorId==doctorid));
        }

        public IDataResult<List<AppointmentDtoDetails>> GetByDto()
        {
            return new SuccessDataResult<List<AppointmentDtoDetails>>(_appointmentDal.GetByDto());
        }
    }
}
