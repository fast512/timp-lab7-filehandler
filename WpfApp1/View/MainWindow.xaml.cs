using System.Windows;
using WpfApp1.Models;
using WpfApp1.ViewModel;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(Teacher teacher)
        {
            InitializeComponent();
            DataContext = new MainViewModel(teacher);
        }
    }
}
