using PasswordsManager.Commands;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace DiceWorks.ViewModel
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public ICommand RollCommand { get; set; }
        public ICommand ClearCommand {  get; set; }

        public ICommand MinusOneCommand { get; set; }
        public ICommand MinusModOneCommand { get; set; }
        public ICommand PlusOneCommand {  get; set; }
        public ICommand PlusModOneCommand { get; set; }

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

        private int _D4Mod;
        public int D4Mod
        {
            get { return _D4Mod; }
            set { _D4Mod = value; OnPropertyChanged("D4Mod"); }
        }

        private int _D6Mod;
        public int D6Mod
        {
            get { return _D6Mod; }
            set { _D6Mod = value; OnPropertyChanged("D6Mod"); }
        }

        private int _D8Mod;
        public int D8Mod
        {
            get { return _D8Mod; }
            set { _D8Mod = value; OnPropertyChanged("D8Mod"); }
        }

        private int _D10Mod;
        public int D10Mod
        {
            get { return _D10Mod; }
            set { _D10Mod = value; OnPropertyChanged("D10Mod"); }
        }

        private int _D12Mod;
        public int D12Mod
        {
            get { return _D12Mod; }
            set { _D12Mod = value; OnPropertyChanged("D12Mod"); }
        }

        private int _D20Mod;
        public int D20Mod
        {
            get { return _D20Mod; }
            set { _D20Mod = value; OnPropertyChanged("D20Mod"); }
        }

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
            MinusModOneCommand = new RelayCommand(CallModMinusOne, CanShowWindow);
            PlusModOneCommand = new RelayCommand(CallModPlusOne, CanShowWindow);

            RollCommand = new RelayCommand(CallRoll, CanShowWindow);
            ClearCommand = new RelayCommand(CallClearAll, CanShowWindow);
        }

        public static int MinusOne(int variable, bool isMod=false)
        {
            variable--;
            if (variable < 0 && !isMod) { variable = 0;}

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

        public void CallModMinusOne(object obj)
        {
            int dice = int.Parse(obj.ToString());
            switch (dice)
            {
                case 4: D4Mod = MinusOne(D4Mod, true); break;
                case 6: D6Mod = MinusOne(D6Mod, true); break;
                case 8: D8Mod = MinusOne(D8Mod, true); break;
                case 10: D10Mod = MinusOne(D10Mod, true); break;
                case 12: D12Mod = MinusOne(D12Mod, true); break;
                case 20: D20Mod = MinusOne(D20Mod, true); break;

                default: break;
            }
        }

        public void CallModPlusOne(object obj)
        {
            int dice = int.Parse(obj.ToString());
            switch (dice)
            {
                case 4: D4Mod = PlusOne(D4Mod); break;
                case 6: D6Mod = PlusOne(D6Mod); break;
                case 8: D8Mod = PlusOne(D8Mod); break;
                case 10: D10Mod = PlusOne(D10Mod); break;
                case 12: D12Mod = PlusOne(D12Mod); break;
                case 20: D20Mod = PlusOne(D20Mod); break;

                default: break;
            }
        }

        public void CallClearAll(object obj)
        {
            D4Count = 0; D4Mod = 0;
            D6Count = 0; D6Mod = 0;
            D8Count = 0; D8Mod = 0;
            D10Count = 0; D10Mod = 0;
            D12Count = 0; D12Mod = 0;
            D20Count = 0; D20Mod = 0;
        }

        public static void CallRoll(object obj)
        {
            MessageBox.Show("kek");        
        }

        public static bool CanShowWindow(object obj) { return true; }
    }
}
