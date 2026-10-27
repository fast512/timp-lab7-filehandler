using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfApp1.Models;

namespace WpfApp1.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        // свойство (не поле!) — иначе {Binding Teacher.FullName} в окне не сработает
        public Teacher Teacher { get; }

        public MainViewModel(Teacher teacher)
        {
            Teacher = teacher;
        }
    }
}
