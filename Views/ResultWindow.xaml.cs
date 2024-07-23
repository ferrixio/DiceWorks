using DiceWorks.ViewModel;
using System.Windows;

namespace DiceWorks.Views
{
    /// <summary>
    /// Logica di interazione per ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        public ResultWindow(String? text)
        {
            InitializeComponent();
            ResultWindowVM resVM = new(text);
            DataContext = resVM;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }
    }
}
