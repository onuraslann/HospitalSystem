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
using System.Linq;
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

        [SecuredOperation("admin,editor")]
        [ValidationAspect(typeof(SickValidator))]
        [CacheRemoveAspect("ISickService.Get")]
        public IResult Add(Sick sick)
        {
            IResult result = BusinessRules.Run(CheckIfTcExist(sick.Tc), CheckIfTelephoneNoExist(sick.Phone));
            if (result != null)
            {
                return result;
            }
            _sickDal.Add(sick);
            return new SuccessResult(Messages.SickAdded);
        }

        [CacheAspect]
        public IDataResult<List<Sick>> GetAll()
        {
            return new SuccessDataResult<List<Sick>>(_sickDal.GetAll());
        }

        public IDataResult<List<Sick>> GetByCity(string city)
        {
            return new SuccessDataResult<List<Sick>>(_sickDal.GetAll(x=>x.Homeland==city));
        }
    
    private IResult CheckIfTcExist(string tcno)
        {
            var result = _sickDal.GetAll(x => x.Tc == tcno).Any();
            if (result)
            {
                return new ErrorResult(Messages.CheckIfTcExist);
            }
            return new SuccessResult();
        }
        private IResult CheckIfTelephoneNoExist(string telephone)
        {
            var result = _sickDal.GetAll(x => x.Phone==telephone).Any();
            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
