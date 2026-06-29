using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Applications;
using DVLD.WinForms.Features.Applications.AddLocalDrivingLicenseApplication;
using DVLD.WinForms.Features.Applications.Detail;
using DVLD.WinForms.Features.Auth;
using DVLD.WinForms.Features.Dashboard;
using DVLD.WinForms.Features.Persons;
using DVLD.WinForms.Features.Persons.SelectPerson;
using DVLD.WinForms.Features.Test_Appointments;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.WinForms.Common
{
    public static class DependencyContainer
    {
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<AppSession>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddHttpClient<IApiClient,ApiClient>();

            services.AddTransient<IAuthService,AuthService>();
            services.AddTransient<IApplicationsService,ApplicationsService>();
            services.AddTransient<IPesronService, PersonService>();
            services.AddTransient<ITestAppointmentsService, TestAppointmentsService>();

            services.AddTransient<LoginPresenter>();
            services.AddTransient<ApplicationsPresenter>();

            services.AddTransient<LoginForm>();
            services.AddTransient<AdminDashboardForm>();

            services.AddTransient<AdminDashboardPresenter>();

            services.AddTransient<IApplicationsView,ApplicationsControl>();

            services.AddTransient<IApplicationDetailView,ApplicationDetailControl>();
            services.AddTransient<ApplicationDetailPresenter>();

            services.AddTransient<ISelectPersonView,SelectPersonControl>();
            services.AddTransient<SelectPersonPresenter>();

            services.AddTransient<INewLocalDrivingLicenseView, NewLocalDrivingLicenseControl>(); 
            services.AddTransient<NewLocalDrivingLicensePresenter>();

            services.AddTransient<IListTestAppointmentsView,ListTestAppointmentsControl>();
            services.AddTransient<ListTestAppointmentsPresenter>();
 
            return services.BuildServiceProvider();
        }
    }
}
