using DVLD.WinForms.Features.Auth;
using Microsoft.Extensions.DependencyInjection;
using DVLD.WinForms.Common;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD.WinForms.Features.Dashboard;
using DVLD.WinForms.Features.Applications;

namespace DVLD.WinForms.Common
{
    public static class DependencyContainer
    {
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<AppSession>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddHttpClient<ApiClient>();

            services.AddTransient<IAuthService,AuthService>();

            services.AddTransient<LoginPresenter>();

            services.AddTransient<LoginForm>();
            services.AddTransient<AdminDashboardForm>();

            services.AddTransient<AdminDashboardPresenter>();

            services.AddTransient<ApplicationsControl>();
 
            return services.BuildServiceProvider();
        }
    }
}
