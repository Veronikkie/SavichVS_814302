using AutoMapper;
using LAMS.DataAccess.Common.Models.Users;
using LAMS.DataAccess.Common.Repositories.Admin;
using LAMS.DataAccess.Common.Repositories.UserForm;
using LAMS.DataAccess.Common.Repositories.Users;
using LAMS.DataAccess.Contexts;
using LAMS.DataAccess.Repositories.Admin;
using LAMS.DataAccess.Repositories.UserForm;
using LAMS.DataAccess.Repositories.Users;
using Ninject.Modules;

namespace LAMS.DataAccess
{
    public class InjectorModule : NinjectModule
    {
        public override void Load()
        {
            if (Kernel is null)
            {
                return;
            }

            Bind<DocContext>().ToSelf().InTransientScope();

            BindRepositories();
        }

        private void BindRepositories() { 

            Bind<IUserRepository>().To<UserRepository>();            
            Bind<IUserFormRepository>().To<UserFormRepository>();            
            Bind<IAdminRepository>().To<AdminRepository>();            
        }
    }
}
