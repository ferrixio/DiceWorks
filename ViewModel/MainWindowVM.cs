using DiceWorks.Views;
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

        public ICommand TossCoinCommand { get; set; }
        public ICommand HundredCommand { get; set; }
        public ICommand AdvCommand { get; set; }
        public ICommand DisCommand { get; set; }

        public ICommand ArbitraryCommand { get; set; }

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

        private int _AdvCount;
        public int AdvCount
        {
            get { return _AdvCount; }
            set { _AdvCount = value; OnPropertyChanged("AdvCount"); }
        }

        private int _AdvMod;
        public int AdvMod
        {
            get { return _AdvMod; }
            set { _AdvMod = value; OnPropertyChanged("AdvMod"); }
        }

        private int _DisCount;
        public int DisCount
        {
            get { return _DisCount; }
            set { _DisCount = value; OnPropertyChanged("DisCount"); }
        }

        private int _DisMod;
        public int DisMod
        {
            get { return _DisMod; }
            set { _DisMod = value; OnPropertyChanged("DisMod"); }
        }

        private int _ArbCount;
        public int ArbCount
        {
            get { return _ArbCount; }
            set { _ArbCount = value; OnPropertyChanged("ArbCount"); }
        }

        private int _ArbDie;
        public int ArbDie
        {
            get { return _ArbDie; }
            set { _ArbDie = value; OnPropertyChanged("ArbDie"); }
        }

        private int _ArbMod;
        public int ArbMod
        {
            get { return _ArbMod; }
            set { _ArbMod = value; OnPropertyChanged("ArbMod"); }
        }

        public List<string> DiceList { get; set; }
        public int SelDiceListAdv { get; set; }
        public int SelDiceListDis { get; set; }

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
            AdvCount = 2; AdvMod = 0;
            DisCount = 2; DisMod = 0;
            ArbCount = 1; ArbDie = 3; ArbMod = 0;

            DiceList = ["d4", "d6", "d8", "d10", "d12", "d20"];
            SelDiceListAdv = 5;
            SelDiceListDis = 5;

            MinusOneCommand = new RelayCommand(CallMinusOne, CanShowWindow);
            PlusOneCommand = new RelayCommand(CallPlusOne, CanShowWindow);
            MinusModOneCommand = new RelayCommand(CallModMinusOne, CanShowWindow);
            PlusModOneCommand = new RelayCommand(CallModPlusOne, CanShowWindow);

            TossCoinCommand = new RelayCommand(CallToss, CanShowWindow);
            HundredCommand = new RelayCommand(CallHundred, CanShowWindow);
            AdvCommand = new RelayCommand(CallAdvantage, CanShowWindow);
            DisCommand = new RelayCommand(CallDisadvantage, CanShowWindow);

            ArbitraryCommand = new RelayCommand(CallArbRoll, CanShowWindow);

            RollCommand = new RelayCommand(CallRoll, CanShowWindow);
            ClearCommand = new RelayCommand(CallClearAll, CanShowWindow);
        }

        /// <summary>
        /// Function that handles the toss coin request
        /// </summary>
        /// <param name="obj"></param>
        public void CallToss(object obj)
        {
            Random luck = new(Guid.NewGuid().GetHashCode()); // rng

            int res = luck.Next(1, 258);
            string str = "What a luck: Tie!";

            if (res >= 1 && res <= 128) str = "Head";
            else if (res >= 129 && res <= 256) str = "Tail";

            Show(obj, str);
        }

        /// <summary>
        /// Rolls 1d100
        /// </summary>
        /// <param name="obj"></param>
        public void CallHundred(object obj)
        {
            Random luck = new(Guid.NewGuid().GetHashCode()); // rng
            Show(obj, String.Format("{0}", luck.Next(1, 101)));
        }

        /// <summary>
        /// Function for advantage rolls
        /// </summary>
        /// <param name="obj"></param>
        public void CallAdvantage(object obj)
        {
            if (AdvCount < 2) AdvCount = 2;

            int[] seq = new int[AdvCount];
            Random luck = new(Guid.NewGuid().GetHashCode()); // rng

            for (int i = 0; i < AdvCount; i++)
            {
                seq[i] = luck.Next(1, Combo2Int(DiceList[SelDiceListAdv])+1);
            }

            Show(obj, String.Format("Advantage roll:\n\n{0}{1}{2} = {3} -> {4}\n",
                AdvCount, DiceList[SelDiceListAdv], Mod2SgnInt(AdvMod), List2Str(seq), seq.Max() + AdvMod));
        }

        /// <summary>
        /// Function for disadvantage rolls
        /// </summary>
        /// <param name="obj"></param>
        public void CallDisadvantage(object obj)
        {
            if (DisCount < 2) DisCount = 2;

            int[] seq = new int[DisCount];
            Random luck = new(Guid.NewGuid().GetHashCode()); // rng

            for (int i = 0; i < DisCount; i++)
            {
                seq[i] = luck.Next(1, Combo2Int(DiceList[SelDiceListDis]) + 1);
            }

            Show(obj, String.Format("Disadvantage roll:\n\n{0}{1}{2} = {3} -> {4}\n",
                DisCount, DiceList[SelDiceListDis], Mod2SgnInt(DisMod), List2Str(seq), seq.Min() + DisMod));
        }

        /// <summary>
        /// Function for rolls with arbitrary die
        /// </summary>
        /// <param name="obj"></param>
        public void CallArbRoll(object obj)
        {
            if (ArbDie > 1)
            {
                int[] seq = new int[ArbCount];
                Random luck = new(Guid.NewGuid().GetHashCode()); // rng

                for (int i = 0; i < ArbCount; i++)
                {
                    seq[i] = luck.Next(1, ArbDie + 1);
                }

                Show(obj, String.Format("{0}d{1}{2} = {3} -> {4}", ArbCount, ArbDie, Mod2SgnInt(ArbMod), List2Str(seq), seq.Sum() + ArbMod));
            }
        }

        /// <summary>
        /// Reduce the variable by one. Set to zero if a counter becomes negative
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="isMod"></param>
        /// <returns></returns>
        public static int MinusOne(int variable, bool isMod=false)
        {
            variable--;
            if (variable < 0 && !isMod) { variable = 0;}

            return variable;
        }

        /// <summary>
        /// Add one to the selected variable. Max value 999
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        public static int PlusOne(int variable)
        {
            variable++;
            if (variable > 999) { variable = 999; }

            return variable;
        }

        /// <summary>
        /// Function to reduce dice counters by one
        /// </summary>
        /// <param name="obj"></param>
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

        /// <summary>
        /// Function to add one to die counters
        /// </summary>
        /// <param name="obj"></param>
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

        /// <summary>
        /// Function to reduce dice modifiers by one
        /// </summary>
        /// <param name="obj"></param>
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

        /// <summary>
        /// Function to add one to dice modifiers
        /// </summary>
        /// <param name="obj"></param>
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

        /// <summary>
        /// Function to reset all variables
        /// </summary>
        /// <param name="obj"></param>
        public void CallClearAll(object obj)
        {
            D4Count = 0; D4Mod = 0;
            D6Count = 0; D6Mod = 0;
            D8Count = 0; D8Mod = 0;
            D10Count = 0; D10Mod = 0;
            D12Count = 0; D12Mod = 0;
            D20Count = 0; D20Mod = 0;
            AdvCount = 2; AdvMod = 0;
            DisCount = 2; DisMod = 0;
            ArbCount = 1; ArbDie = 3; ArbMod = 0;
        }

        /// <summary>
        /// Function to roll dice and show results
        /// </summary>
        /// <param name="obj"></param>
        public void CallRoll(object obj)
        {
            int[] r4, r6, r8, r10, r12, r20;
            string str = String.Empty;
            int CollectiveSum = 0;

            if (D4Count > 0)
            {
                r4 = RollSequence(D4Count, 4);
                CollectiveSum += r4.Sum() + D4Mod;
                str += String.Format("{0}d4{1} = {2} -> {3}\n", D4Count, Mod2SgnInt(D4Mod), List2Str(r4), r4.Sum()+D4Mod);
            }

            if (D6Count > 0)
            {
                r6 = RollSequence(D6Count, 6);
                CollectiveSum += r6.Sum() + D6Mod;
                str += String.Format("{0}d6{1} = {2} -> {3}\n", D6Count, Mod2SgnInt(D6Mod), List2Str(r6), r6.Sum() + D6Mod);
            }

            if (D8Count > 0)
            {
                r8 = RollSequence(D8Count, 8);
                CollectiveSum += r8.Sum() + D8Mod;
                str += String.Format("{0}d8{1} = {2} -> {3}\n", D8Count, Mod2SgnInt(D8Mod), List2Str(r8), r8.Sum() + D8Mod);
            }

            if (D10Count > 0)
            {
                r10 = RollSequence(D10Count, 10);
                CollectiveSum += r10.Sum() + D10Mod;
                str += String.Format("{0}d10{1} = {2} -> {3}\n", D10Count, Mod2SgnInt(D10Mod), List2Str(r10), r10.Sum() + D10Mod);
            }

            if (D12Count > 0)
            {
                r12 = RollSequence(D12Count, 12);
                CollectiveSum += r12.Sum() + D12Mod;
                str += String.Format("{0}d12{1} = {2} -> {3}\n", D12Count, Mod2SgnInt(D12Mod), List2Str(r12), r12.Sum() + D12Mod);
            }

            if (D20Count > 0)
            {
                r20 = RollSequence(D20Count, 20);
                CollectiveSum += r20.Sum() + D20Mod;
                str += String.Format("{0}d20{1} = {2} -> {3}\n", D20Count, Mod2SgnInt(D20Mod), List2Str(r20), r20.Sum() + D20Mod);
            }

            if (!String.IsNullOrEmpty(str))
            {
                str += String.Concat(Enumerable.Repeat("-", 20)) + "\n" + String.Format("Collective result = {0}", CollectiveSum);
                Show(obj, str);
            }
        }

        /// <summary>
        /// Function that converts the modifier in a str representing its signed integer
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public string Mod2SgnInt(int mod)
        {
            if (mod >= 0)
            {
                return String.Format("+{0}", mod);
            }

            return String.Format("{0}", mod);
        }

        /// <summary>
        /// Function that emulates "print(list)" of python
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public string List2Str(int[] array)
        {
            return "["+String.Join(", ", array)+"]";
        }

        /// <summary>
        /// Function that return the associated dice with respect to the combobox
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static int Combo2Int(string word)
        {
            int die = word switch
            {
                "d4" => 4,
                "d6" => 6,
                "d8" => 8,
                "d10" => 10,
                "d12" => 12,
                "d20" => 20,
                _ => 0,
            };
            return die;
        }

        /// <summary>
        /// Function that evaluates the rolled sequence of dice
        /// </summary>
        /// <param name="number"></param>
        /// <param name="diceSize"></param>
        /// <returns></returns>
        public static int[] RollSequence(int number, int diceSize)
        {
            int[] results = new int[number];
            Random luck = new(Guid.NewGuid().GetHashCode()); // rng

            for (int i = 0; i < number; i++)
            {
                results[i] = luck.Next(1, diceSize + 1);
            }

            return results;

        }

        /// <summary>
        /// Function that shows the result window
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="message"></param>
        public void Show(object obj, string message)
        {
            ResultWindow resWin = new(message)
            {
                Owner = obj as Window,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            resWin.ShowDialog();
        }

        public static bool CanShowWindow(object obj) { return true; }
    }
}
