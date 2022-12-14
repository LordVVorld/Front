using Front.Models;
using Front.Views;
using Newtonsoft.Json;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive;
using System.Threading.Tasks;
using System.Windows;
using static Front.Models.StartupModel;

namespace Front.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        [Reactive] public string? Email { get; set; } = null;
        [Reactive] public string? Password { get; set; } = null;
        public User? user = new User();

        public MainViewModel()
        {
            Login = ReactiveCommand.Create<StartupView, Task>(async view =>
            {
                if (!IsValidEmail(Email))
                {
                    MessageBox.Show("Некорректно введён Email", "Внимание!");
                    return;
                }

                if (!IsValidPassword(Password))
                {
                    MessageBox.Show("Пароль не удовлетворяет требованиям", "Внимание!");
                    return;
                }

                var loginModel = new LoginModel()
                { 
                    Email = Email!, 
                    Password = Password! 
                };

                var response = new HttpResponseMessage();

                try
                {
                    response = await httpClient
                        .PostAsJsonAsync("api/Users/login", loginModel)
                        .ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Внимание!");
                    return;
                }

                var result = await response.Content.ReadAsStringAsync();

                user = JsonConvert.DeserializeObject<User>(result)!;

                SetAccessToken(user.AccessToken);

                new MainAppView(user)
                { WindowStartupLocation = WindowStartupLocation.CenterScreen }.Show();

                view.Close();
            });
            Login.ThrownExceptions.Subscribe(e => MessageBox.Show(e.Message));

            Register = ReactiveCommand.Create<StartupView,Task>(async view =>
            {
                if (!IsValidEmail(Email))
                {
                    MessageBox.Show("Некорректно введён Email", "Внимание!");
                    return;
                }

                if (!IsValidPassword(Password))
                {
                    MessageBox.Show("Пароль не удовлетворяет требованиям", "Внимание!");
                    return;
                }

                var loginModel = new LoginModel()
                {
                    Email = Email!,
                    Password = Password!
                };

                var response = new HttpResponseMessage();

                try
                {
                    response = await httpClient
                        .PostAsJsonAsync("api/Users/login", loginModel)
                        .ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Внимание!");
                    return;
                }

                var result = await response.Content.ReadAsStringAsync();

                user = JsonConvert.DeserializeObject<User>(result)!;

                SetAccessToken(user.AccessToken);

                new MainAppView(user)
                { WindowStartupLocation = WindowStartupLocation.CenterScreen }.Show();

                view.Close();
            });
            Register.ThrownExceptions.Subscribe(e => MessageBox.Show(e.Message));
        }

        public ReactiveCommand<StartupView, Task> Login { get; private set; }
        public ReactiveCommand<StartupView, Task> Register { get; private set; }
    }
}
