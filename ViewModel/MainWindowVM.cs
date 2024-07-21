using PasswordsManager.Commands;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace DiceWorks.ViewModel
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public ICommand RollCommand { get; set; }
        
        public ICommand MinusOneCommand { get; set; }
        public ICommand PlusOneCommand {  get; set; }

        private int _D4Count;
        public int D4Count
        {
            get { return _D4Count; }
            set { _D4Count = value; OnPropertyChanged("D4Count"); }
        }

        private int _D6Count;
        public int D6Count
        {
            get { return _D6Count; }
            set { _D6Count = value; OnPropertyChanged("D6Count"); }
        }

        private int _D8Count;
        public int D8Count
        {
            get { return _D8Count; }
            set { _D8Count = value; OnPropertyChanged("D8Count"); }
        }

        private int _D10Count;
        public int D10Count
        {
            get { return _D10Count; }
            set { _D10Count = value; OnPropertyChanged("D10Count"); }
        }

        private int _D12Count;
        public int D12Count
        {
            get { return _D12Count; }
            set { _D12Count = value; OnPropertyChanged("D12Count"); }
        }

        private int _D20Count;
        public int D20Count
        {
            get { return _D20Count; }
            set { _D20Count = value; OnPropertyChanged("D20Count"); }
        }

        public int D4Mod {  get; set; }
        public int D6Mod {  get; set; }
        public int D8Mod {  get; set; }
        public int D10Mod {  get; set; }
        public int D12Mod {  get; set; }
        public int D20Mod {  get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainWindowVM()
        {
            D4Count = 0; D4Mod = 0;
            D6Count = 0; D6Mod = 0;
            D8Count = 0; D8Mod = 0;
            D10Count = 0; D10Mod = 0;
            D12Count = 0; D12Mod = 0;
            D20Count = 0; D20Mod = 0;

            MinusOneCommand = new RelayCommand(CallMinusOne, CanShowWindow);
            PlusOneCommand = new RelayCommand(CallPlusOne, CanShowWindow);
            
            RollCommand = new RelayCommand(CallRoll, CanShowWindow);
        }

        public static int MinusOne(int variable)
        {
            variable--;
            if (variable < 0) { variable = 0;}

            return variable;
        }

        public static int PlusOne(int variable)
        {
            variable++;
            if (variable > 999) { variable = 999; }

            return variable;
        }

        public void CallMinusOne(object obj)
        {
            int dice = int.Parse(obj.ToString());
            switch (dice)
            {
                case 4: D4Count = MinusOne(D4Count); break;
                case 6: D6Count = MinusOne(D6Count); break;
                case 8: D8Count = MinusOne(D8Count); break;
                case 10: D10Count = MinusOne(D10Count); break;
                case 12: D12Count = MinusOne(D12Count); break;
                case 20: D20Count = MinusOne(D20Count); break;

                default: break;
            }
        }

        public void CallPlusOne(object obj)
        {
            int dice = int.Parse(obj.ToString());
            switch (dice)
            {
                case 4: D4Count = PlusOne(D4Count); break;
                case 6: D6Count = PlusOne(D6Count); break;
                case 8: D8Count = PlusOne(D8Count); break;
                case 10: D10Count = PlusOne(D10Count); break;
                case 12: D12Count = PlusOne(D12Count); break;
                case 20: D20Count = PlusOne(D20Count); break;

                default: break;
            }
        }

        public static void CallRoll(object obj) { }
        public static bool CanShowWindow(object obj) { return true; }
    }
}
