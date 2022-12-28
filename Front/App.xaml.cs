global using Front.Models.DataModels;
global using static Front.App;
using Front.Views;
using ReactiveUI;
using Splat;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Windows;

namespace Front
{
    public partial class App : Application
    {
        public static readonly HttpClient httpClient = new()
            { BaseAddress = new System.Uri("https://localhost:7202/") };

        public App()
        {
            Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetCallingAssembly());
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            new StartupView
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            }.Show();
        }

        public static void SetAccessToken(string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
