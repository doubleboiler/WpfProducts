using System.Windows;
using WpfProductsTest.ViewModel;

namespace WpfProductsTest.Views
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : Window
    {
        public Shell(ShellViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
