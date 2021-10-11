using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class SickManager : ISickService
    {
        ISickDal _sickDal;

        public SickManager(ISickDal sickDal)
        {
            _sickDal = sickDal;
        }

        [ValidationAspect(typeof(SickValidator))]
        public IResult Add(Sick sick)
        {
            _sickDal.Add(sick);
            return new SuccessResult(Messages.SickAdded);
        }

        public IDataResult<List<Sick>> GetAll()
        {
            return new SuccessDataResult<List<Sick>>(_sickDal.GetAll());
        }

        public IDataResult<List<Sick>> GetByCity(string city)
        {
            return new SuccessDataResult<List<Sick>>(_sickDal.GetAll(x=>x.Homeland==city));
        }
    }
}
