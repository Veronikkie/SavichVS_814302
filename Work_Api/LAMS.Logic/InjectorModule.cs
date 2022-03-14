using AutoMapper;
using AutoMapper.Execution;
using FluentValidation;
using LAMS.Logic.Common.Services.Admin;
using LAMS.Logic.Common.Services.UserForm;
using LAMS.Logic.Common.Services.Users;
using LAMS.Logic.Mappings.Admin;
using LAMS.Logic.Mappings.Users;
using LAMS.Logic.Mappings.Work;
using LAMS.Logic.Services.Admin;
using LAMS.Logic.Services.UserForm;
using LAMS.Logic.Services.Users;
using Ninject;
using Ninject.Modules;
using System.Reflection;

namespace LAMS.Logic
{
    public class InjectorModule : NinjectModule
    {
        public override void Load()
        {
            if (Kernel is null)
            {
                return;
            }

            BindValidators();
            BindMappers();

            BindLogsServices();
        }

        private void BindValidators()
        {
            AssemblyScanner
                .FindValidatorsInAssembly(Assembly.GetExecutingAssembly())
                .ForEach(result => Kernel.Bind(result.InterfaceType).To(result.ValidatorType).InTransientScope());
        }

        private void BindMappers()
        {

            Bind<IMapper>().ToMethod(ctx =>
                new Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<UserProfile>();
                })))
                .WhenInjectedExactlyInto<UserService>();

            Bind<IMapper>().ToMethod(ctx =>
                new Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<UserProfile>();
                })))
                .WhenInjectedExactlyInto<RegistrationService>();

            Bind<IMapper>().ToMethod(ctx =>
                new Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<PersonalInfoProfile>();
                    cfg.AddProfile<EducationProfile>();
                    cfg.AddProfile<LanguageProfile>();
                    cfg.AddProfile<ExperienceProfile>();
                    cfg.AddProfile<UserProgLangProfile>();
                    cfg.AddProfile<DocumentProfile>();
                    cfg.AddProfile<QuestionProfile>();
                })))
            .WhenInjectedExactlyInto<UserFormService>();

            Bind<IMapper>().ToMethod(ctx =>
           new Mapper(new MapperConfiguration(cfg =>
           {
               cfg.AddProfile<ProgLangProfile>();
           })))
       .WhenInjectedExactlyInto<AdminService>();
        }


        private void BindLogsServices()
        {

            Bind<IRegistrationService>().To<RegistrationService>();
            Bind<IUserFormService>().To<UserFormService>();
            Bind<IUserService>().To<UserService>();
            Bind<IAdminService>().To<AdminService>();
        }
    }
}
