using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using WpfProductsData.Repositories;

namespace WpfProductsTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    internal partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Views.Shell>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.GetContainer().RegisterType(typeof(IRepository<>), typeof(Repository<>));
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }

    }
}
