using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.IO;
using System.Text;
using WpfApp1.Models;

namespace WpfApp1.ViewModel
{
    public partial class PasswordViewModel : ObservableObject

    {
        private readonly string _datafolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        private readonly Encoding _enc = new UTF8Encoding(false);







        //private Dictionary<string, string> _logins = new Dictionary<string, string>() { ["vas"] = "11111", ["vas32"] = "12345" };
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
        private void Logining()
        {
            //if (_logins.TryGetValue(Login, out var storedPassword) && storedPassword == _password) { StatusMessage = "Login successful!"; PasswordAccepted?.Invoke(); } else { StatusMessage = "Invalid login or password."; }
            string teachersPath = Path.Combine(_datafolder, "teachers.txt");
            if (!File.Exists(teachersPath)) { StatusMessage = "файл данных не найден."; }
            Teacher? found = null;
            using (StreamReader reader = new StreamReader(teachersPath, _enc))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)

                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    string[] parts = line.Split(";");
                    if (parts.Length < 4) { continue; }
                    var t = new Teacher()
                    {
                        Login = parts[0].Trim(),
                        Password = parts[1].Trim(),
                        FullName = parts[2].Trim(),
                        Department = parts[3].Trim()

                    };

                    if (string.Equals(t.Login, Login, StringComparison.OrdinalIgnoreCase)
                            && string.Equals(t.Password, Password, StringComparison.CurrentCulture))
                        { found = t; break; }

                }
            }


            if (found != null) { StatusMessage = "Login successful!"; PasswordAccepted?.Invoke(); }
            else { StatusMessage = "Invalid login or password."; }




        }

        private bool CanLogin() => !string.IsNullOrWhiteSpace(Login) && !string.IsNullOrWhiteSpace(_password);

        [RelayCommand(CanExecute = nameof(CanLogin))]
        private void ClearInput() { Login = ""; Password = ""; StatusMessage = ""; }


    }
}