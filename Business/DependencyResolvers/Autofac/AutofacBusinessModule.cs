using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DoctorManager>().As<IDoctorService>().SingleInstance();
            builder.RegisterType<EfDoctorDal>().As<IDoctorDal>().SingleInstance();

            builder.RegisterType<SickManager>().As<ISickService>().SingleInstance();
            builder.RegisterType<EfSickDal>().As<ISickDal>().SingleInstance();

            builder.RegisterType<AppointmentManager>().As<IAppointmentService>().SingleInstance();
            builder.RegisterType<EfAppointmentDal>().As<IAppointmentDal>().SingleInstance();

            builder.RegisterType<DepartmanManager>().As<IDepartmanService>().SingleInstance();
            builder.RegisterType<EfDepartmanDal>().As<IDepartmanDal>().SingleInstance();

            builder.RegisterType<PrescriptionManager>().As<IPrescriptionService>().SingleInstance();
            builder.RegisterType<EfPrescriptionDal>().As<IPrescriptionDal>().SingleInstance();
           
            
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
