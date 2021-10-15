using Business.Abstract;
using Business.BusinessAspects;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Caching;
using Core.Aspects.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class DoctorManager : IDoctorService
    {
        IDoctorDal _doctorDal;

        public DoctorManager(IDoctorDal doctorDal)
        {
            _doctorDal = doctorDal;
        }
        [SecuredOperation("admin,editor")]
        [ValidationAspect(typeof(DoctorValidator))]
        public IResult Add(Doctor doctor)
        {

            IResult result = BusinessRules.Run(CheckIfDepartmanCount(doctor.DepartmanId));
            if (result != null)
            {
                return result;
            }
            _doctorDal.Add(doctor);
            return new SuccessResult(Messages.DoctorAdded);
        }

        [CacheAspect]
        public IDataResult<List<Doctor>> GetAll()
        {
            return new SuccessDataResult<List<Doctor>>(_doctorDal.GetAll());
        }
        private IResult CheckIfDepartmanCount(int departmanId)
        {
            var result = _doctorDal.GetAll(x => x.DepartmanId == departmanId).Count;
            if (result > 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
