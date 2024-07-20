using System.Diagnostics;
using System.Windows;

namespace DiceWorks
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        App() { }

        public static void ChangeTheme(Uri newUri)
        {
            ResourceDictionary theme = new() { Source = newUri };

            Current.Resources.Clear();
            Current.Resources.MergedDictionaries.Add(theme);
        }

        protected void AppStartup(object sender, StartupEventArgs e)
        {
            try
            {
                ChangeTheme(new Uri("pack://application:,,,/Themes/Light.xaml", UriKind.Absolute));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Process.GetCurrentProcess().Kill();
            }
        }
    }

}
