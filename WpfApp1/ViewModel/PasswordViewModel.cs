using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfApp1.ViewModel
{
    public partial class PasswordViewModel : ObservableObject

    {
        private Dictionary<string, string> _logins = new Dictionary<string, string>() { ["vas"] = "11111", ["vas32"] = "12345" };
        public event Action? PasswordAccepted;



        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginingCommand))]
        [NotifyCanExecuteChangedFor(nameof(ClearInputCommand))]
        private string _login = "";

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginingCommand))]
        [NotifyCanExecuteChangedFor(nameof(ClearInputCommand))]
        private string _password = "";

        [ObservableProperty]
        private string _statusMessage = "";



        [RelayCommand(CanExecute = nameof(CanLogin))]
        private void Logining() { if (_logins.TryGetValue(Login, out var storedPassword) && storedPassword == _password) { StatusMessage = "Login successful!"; PasswordAccepted?.Invoke(); } else { StatusMessage = "Invalid login or password."; } }

        private bool CanLogin() => !string.IsNullOrWhiteSpace(Login) && !string.IsNullOrWhiteSpace(_password);

        [RelayCommand(CanExecute = nameof(CanLogin))]
        private void ClearInput() { Login = ""; Password = ""; StatusMessage = ""; }





    }
}