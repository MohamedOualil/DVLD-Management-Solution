using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Auth;
using Microsoft.Extensions.DependencyInjection;
namespace DVLD.WinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();
            var serviceProvider = DependencyContainer.ConfigureServices();
            var startForm = serviceProvider.GetRequiredService<LoginForm>();
            Application.Run(startForm);
        }
    }
}