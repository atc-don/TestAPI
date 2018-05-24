using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;
using Ninject.Modules;

using BasicAPI.Entities;
using BasicAPI.Managers.Implementation;
using BasicAPI.Managers.Interfaces;
using BasicAPI.Repositories.Implementation;
using BasicAPI.Repositories.Interfaces;

namespace BasicAPI.App_Start
{
    public class DependencyRegistrar : NinjectModule
    {
        private readonly ConfigurationSettingsEntity _configurationSettings;

        /// <summary>
        /// Constructs a new instance of the DependencyRegistrar class
        /// </summary>
        /// <param name="configurationSettings">Configuration settings needed for creating instances</param>
        public DependencyRegistrar(ConfigurationSettingsEntity configurationSettings)
        {
            if (configurationSettings == null)
            {
                throw new ArgumentNullException("configurationSettings");
            }

            _configurationSettings = configurationSettings;
        }

        /// <summary>
        /// Binds interfaces to their implementations with any constructor arguments needed
        /// </summary>
        public override void Load()
        {
            var automapperConfig = new MapperConfiguration(cfg => { cfg.AddProfile<AutoMapperProfile>(); });
            automapperConfig.AssertConfigurationIsValid();
            var mapper = automapperConfig.CreateMapper();

            Bind<IMapper>().ToConstant(mapper).InSingletonScope();
            Bind<IUserManager>().To<UserManager>().InTransientScope();
            Bind<IUserRepository>().To<UserRepository>().InTransientScope();
            Bind<IStudentManager>().To<StudentManager>().InTransientScope();
            Bind<IStudentRepository>().To<StudentRepository>().InTransientScope();
        }
    }
}