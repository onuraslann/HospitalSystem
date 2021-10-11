using Core.Utilities.Result;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAppointmentService
    {
        IDataResult<List<Appointment>> GetAll();
        IDataResult<List<Appointment>> GetByDoctor(int doctorid);
        IDataResult<List<AppointmentDtoDetails>> GetByDto();

        IResult Add(Appointment appointment);
        IResult Delete(Appointment appointment);
    }
}
