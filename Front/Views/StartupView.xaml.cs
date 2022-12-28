using Front.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System;
using System.Reactive.Linq;
using Front.Models;

namespace Front.Views
{
    public partial class StartupView : ReactiveWindow<MainViewModel>
    {
        public StartupView()
        {
            InitializeComponent();
            ViewModel = new MainViewModel();

            this.WhenActivated(d =>
            {
                this.Bind(
                        ViewModel,
                        viewModel => viewModel.Email,
                        view => view.EmailInputBox.Text
                    ).DisposeWith(d);

                this.Bind(
                        ViewModel,
                        viewModel => viewModel.Password,
                        view => view.PasswordInputBox.Text
                    ).DisposeWith(d);

                CloseButton
                    .Events().Click
                    .Subscribe(e => Close())
                    .DisposeWith(d);

                MinimazeButton
                    .Events().Click
                    .Subscribe(e => WindowState = WindowState.Minimized)
                    .DisposeWith(d);

                LoginButton
                    .Events()
                    .Click
                    .Subscribe(async e => await ViewModel.Login.Execute(this))
                    .DisposeWith(d);

                RegisterButton
                    .Events()
                    .Click
                    .Subscribe(async e => await ViewModel.Register.Execute(this))
                    .DisposeWith(d);
            });
        }
    }
}