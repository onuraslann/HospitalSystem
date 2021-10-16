using Business.Abstract;
using Business.BusinessAspects;
using Business.Constants;
using Core.Aspects.Performance;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PrescriptionManager : IPrescriptionService
    {
        IPrescriptionDal _prescriptionDal;

        public PrescriptionManager(IPrescriptionDal prescriptionDal)
        {
            _prescriptionDal = prescriptionDal;
        }
        [SecuredOperation("admin,editor")]
        public IResult Add(Prescription prescription)
        {
            prescription.PrescriptionsDate = DateTime.Now;
            _prescriptionDal.Add(prescription);
            return new SuccessResult(Messages.Prescription);
        }

        public IResult Delete(Prescription prescription)
        {
            _prescriptionDal.Delete(prescription);
            return new SuccessResult();
        }
        [PerformanceAspect(interval: 1)]
        public IDataResult<List<Prescription>> GetAll()
        {
            return new SuccessDataResult<List<Prescription>>(_prescriptionDal.GetAll());
        }
    }
}
