using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Administration;
using DVLD.WinForms.Features.Administration.AuditLogs;
using DVLD.WinForms.Features.Administration.ServiceFees;
using DVLD.WinForms.Features.Administration.Users;
using DVLD.WinForms.Features.Applications;
using DVLD.WinForms.Features.Applications.AddLocalDrivingLicenseApplication;
using DVLD.WinForms.Features.Applications.DetainedLicenses;
using DVLD.WinForms.Features.Applications.Detail;
using DVLD.WinForms.Features.Applications.InternationalLicenses;
using DVLD.WinForms.Features.Applications.IssueDrivingLicence;
using DVLD.WinForms.Features.Applications.LocalApplications;
using DVLD.WinForms.Features.Auth;
using DVLD.WinForms.Features.Drivers;
using DVLD.WinForms.Features.Licenses;
using DVLD.WinForms.Features.Licenses.DetainRelease;
using DVLD.WinForms.Features.Licenses.InternationalPermit;
using DVLD.WinForms.Features.Licenses.LicenseDetails;
using DVLD.WinForms.Features.Licenses.LicenseHistory;
using DVLD.WinForms.Features.Licenses.RenewLicense;
using DVLD.WinForms.Features.Licenses.ReplaceLicense;
using DVLD.WinForms.Features.Dashboard;
using DVLD.WinForms.Features.Persons;
using DVLD.WinForms.Features.Persons.ManagePeople;
using DVLD.WinForms.Features.Persons.SelectPerson;
using DVLD.WinForms.Features.Settings;
using DVLD.WinForms.Features.Tests;
using DVLD.WinForms.Features.Tests.ScheduleTest;
using DVLD.WinForms.Features.Tests.RecordTestResult;
using DVLD.WinForms.Features.Tests.Appointments;
using DVLD.WinForms.Features.Tests.Appointments.ManageTestAppointments;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

            services.AddHttpClient("AuthClient", client =>
            {
                client.BaseAddress = new Uri(ApiClient.BaseUrl);
            });

            services.AddSingleton<IRefreshTokenService>(sp =>
            {
                var session = sp.GetRequiredService<AppSession>();
                var factory = sp.GetRequiredService<IHttpClientFactory>();
                var httpClient = factory.CreateClient("AuthClient");
                return new RefreshTokenService(session, httpClient);
            });

            services.AddHttpClient<IApiClient, ApiClient>();

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IRememberMeService, RememberMeService>();
            services.AddTransient<IApplicationsService, ApplicationsService>();
            services.AddTransient<ILicensesService, LicensesService>();
            services.AddTransient<IPesronService, PersonService>();
            services.AddTransient<ITestAppointmentsService, TestAppointmentsService>();
            services.AddTransient<ITestService, TestService>();
            services.AddTransient<IDriversService, DriversService>();
            services.AddTransient<IAdministrationService, AdministrationService>();

            services.AddTransient<LoginPresenter>();
            services.AddScoped<ApplicationsPresenter>();
            services.AddScoped<LocalApplicationsPresenter>();
            services.AddScoped<InternationalLicensesPresenter>();
            services.AddScoped<DetainedLicensesPresenter>();

            services.AddTransient<LoginForm>();
            services.AddTransient<AdminDashboardForm>();

            services.AddTransient<AdminDashboardPresenter>();

            services.AddScoped<IApplicationsView, ApplicationsControl>();
            services.AddScoped<ILocalApplicationsTabView>(sp => sp.GetRequiredService<IApplicationsView>().LocalApplicationsView);
            services.AddScoped<IInternationalLicensesTabView>(sp => sp.GetRequiredService<IApplicationsView>().InternationalLicensesView);
            services.AddScoped<IDetainedLicensesTabView>(sp => sp.GetRequiredService<IApplicationsView>().DetainedLicensesView);

            services.AddTransient<IApplicationDetailView, ApplicationDetailControl>();
            services.AddTransient<ApplicationDetailPresenter>();
            services.AddTransient<IIssueDrivingLicenceView, IssueDrivingLicenceControl>();
            services.AddTransient<IssueDrivingLicencePresenter>();

            services.AddTransient<ISelectPersonView, SelectPersonControl>();
            services.AddTransient<SelectPersonPresenter>();

            services.AddTransient<INewLocalDrivingLicenseView, NewLocalDrivingLicenseControl>();
            services.AddTransient<NewLocalDrivingLicensePresenter>();

            services.AddTransient<IListTestAppointmentsView, ListTestAppointmentsControl>();
            services.AddTransient<ListTestAppointmentsPresenter>();
            services.AddTransient<IManageTestAppointmentsView, ManageTestAppointmentsControl>();
            services.AddTransient<ManageTestAppointmentsPresenter>();

            services.AddTransient<IScheduleTestView, ScheduleTestControl>();
            services.AddTransient<ScheduleTestPresenter>();
            services.AddTransient<IRecordTestResultView, RecordTestResultControl>();
            services.AddTransient<RecordTestResultPresenter>();

            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<ISettingsView, SettingsControl>();
            services.AddTransient<SettingsPresenter>();

            services.AddTransient<IDashboardView, DashboardControl>();
            services.AddTransient<DashboardPresenter>();

            services.AddTransient<IRenewLicenseView, RenewLicenseControl>();
            services.AddTransient<RenewLicensePresenter>();
            services.AddTransient<IReplaceLicenseView, ReplaceLicenseControl>();
            services.AddTransient<ReplaceLicensePresenter>();
            services.AddTransient<IDetainReleaseLicenseView, DetainReleaseLicenseControl>();
            services.AddTransient<DetainReleaseLicensePresenter>();
            services.AddTransient<IInternationalPermitView, InternationalPermitControl>();
            services.AddTransient<InternationalPermitPresenter>();
            services.AddTransient<ILicenseHistoryView, LicenseHistoryControl>();
            services.AddTransient<LicenseHistoryPresenter>();

            services.AddTransient<IPeopleView, PeopleControl>();
            services.AddTransient<PeoplePresenter>();
            services.AddTransient<PersonEditorForm>();

            services.AddTransient<IDriversView, DriversControl>();
            services.AddTransient<DriversPresenter>();

            services.AddTransient<IUsersView, UsersControl>();
            services.AddTransient<UsersPresenter>();
            services.AddTransient<UserEditorForm>();
            services.AddTransient<IServiceFeesView, ServiceFeesControl>();
            services.AddTransient<ServiceFeesPresenter>();
            services.AddTransient<IAuditLogsView, AuditLogsControl>();
            services.AddTransient<AuditLogsPresenter>();

            services.AddTransient<PersonCardForm>();
            services.AddTransient<LicenseCardForm>();

            return services.BuildServiceProvider();
        }
    }
}
