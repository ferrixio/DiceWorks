using System.Windows;
using System.Windows.Input;

namespace DiceWorks.ViewModel
{
    public class MainWindowVM
    {
        public ICommand RollCommand { get; set; }

        public int d4Count { get; set; }
        public int d4Mod {  get; set; }

        public MainWindowVM()
        {
            d4Count = 0;
            d4Mod = 0;
        }
    }
}
