using DVLD.WinForms.Common;
using DVLD.WinForms.Features.Auth;
using DVLD.WinForms.Features.Dashboard;
using DVLD.WinForms.Properties;
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

            // Upgrade user settings across version updates if needed
            try
            {
                if (Settings.Default.UpgradeRequired)
                {
                    Settings.Default.Upgrade();
                    Settings.Default.UpgradeRequired = false;
                    Settings.Default.Save();
                }
            }
            catch
            {
                // Suppress settings upgrade exceptions
            }

            var serviceProvider = DependencyContainer.ConfigureServices();
            var startForm = serviceProvider.GetRequiredService<LoginForm>();
            Application.Run(startForm);
        }
    }
}
