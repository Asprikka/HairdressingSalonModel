using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace HairdressingSalonModel
{
    public class Hall : INotifyPropertyChanged
    {
        private readonly Form _owner;


        private int servedClientsCount;
        public int ServedClientsCount
        {
            get => servedClientsCount;
            set
            {
                servedClientsCount = value;
                void Act() => InvokePropertyChanged_Input(new PropertyChangedEventArgs("ServedClientsCount"));
                try { Act(); } catch { }
            }
        }

        private int currentQueueSize;
        public int CurrentQueueSize
        {
            get => currentQueueSize;
            set
            {
                currentQueueSize = value;
                void Act() => InvokePropertyChanged_Input(new PropertyChangedEventArgs("CurrentQueueSize"));
                try { Act(); } catch { }
            }
        }

        private double averageQueueSize;
        public double AverageQueueSize
        {
            get => averageQueueSize;
            set
            {
                averageQueueSize = value;
                void Act() => InvokePropertyChanged_Input(new PropertyChangedEventArgs("AverageQueueSize"));
                try { Act(); } catch { }
            }
        }

        private int currentAllMastersBusyness;
        public int CurrentAllMastersBusyness
        {
            get => currentAllMastersBusyness;
            set
            {
                currentAllMastersBusyness = value;
                void Act() => InvokePropertyChanged_Input(new PropertyChangedEventArgs("CurrentAllMastersBusyness"));
                try { Act(); } catch { }
            }
        }

        private double averageOneMasterBusyness;
        public double AverageOneMasterBusyness
        {
            get => averageOneMasterBusyness;
            set
            {
                averageOneMasterBusyness = value;
                void Act() => InvokePropertyChanged_Input(new PropertyChangedEventArgs("AverageOneMasterBusyness"));
                try { Act(); } catch { }
            }
        }

        private double totalDowntime;
        public double TotalDowntime
        {
            get => totalDowntime;
            set
            {
                totalDowntime = value;
                void Act() => InvokePropertyChanged_Input(new PropertyChangedEventArgs("TotalDowntime"));
                try { Act(); } catch { }
            }
        }

        private int totalProfit;
        public int TotalProfit
        {
            get => totalProfit;
            set
            {
                totalProfit = value;
                void Act() => InvokePropertyChanged_Input(new PropertyChangedEventArgs("TotalProfit"));
                try { Act(); } catch { }
            }
        }

        public int TotalOrdersCount { get; set; } = 0;

        public List<Master> Masters { get; set; } = new List<Master>();

        public Queue<Queue<Service>> OrderQueue { get; set; } = new Queue<Queue<Service>>();


        private string servedClientsCount_OutputFormat;
        public string ServedClientsCount_OutputFormat
        {
            get => servedClientsCount_OutputFormat;
            private set
            {
                servedClientsCount_OutputFormat = value;
                Action act = () => InvokePropertyChanged_OutputFormat(new PropertyChangedEventArgs("ServedClientsCount_OutputFormat"));
                try { _owner.Invoke(act); } catch { }
            }
        }

        private string currentQueueSize_OutputFormat;
        public string CurrentQueueSize_OutputFormat
        {
            get => currentQueueSize_OutputFormat;
            private set
            {
                currentQueueSize_OutputFormat = value;
                Action act = () => InvokePropertyChanged_OutputFormat(new PropertyChangedEventArgs("CurrentQueueSize_OutputFormat"));
                try { _owner.Invoke(act); } catch { }
            }
        }

        private string averageQueueSize_OutputFormat;
        public string AverageQueueSize_OutputFormat
        {
            get => averageQueueSize_OutputFormat;
            private set
            {
                averageQueueSize_OutputFormat = value;
                Action act = () => InvokePropertyChanged_OutputFormat(new PropertyChangedEventArgs("AverageQueueSize_OutputFormat"));
                try { _owner.Invoke(act); } catch { }
            }
        }

        private string currentAllMastersBusyness_OutputFormat;
        public string CurrentAllMastersBusyness_OutputFormat
        {
            get => currentAllMastersBusyness_OutputFormat;
            private set
            {
                currentAllMastersBusyness_OutputFormat = value;
                Action act = () => InvokePropertyChanged_OutputFormat(new PropertyChangedEventArgs("CurrentAllMastersBusyness_OutputFormat"));
                try { _owner.Invoke(act); } catch { }
            }
        }

        private string averageOneMasterBusyness_OutputFormat;
        public string AverageOneMasterBusyness_OutputFormat
        {
            get => averageOneMasterBusyness_OutputFormat;
            private set
            {
                averageOneMasterBusyness_OutputFormat = value;
                Action act = () => InvokePropertyChanged_OutputFormat(new PropertyChangedEventArgs("AverageOneMasterBusyness_OutputFormat"));
                try { _owner.Invoke(act); } catch { }
            }
        }

        private string totalDowntime_OutputFormat;
        public string TotalDowntime_OutputFormat
        {
            get => totalDowntime_OutputFormat;
            private set
            {
                totalDowntime_OutputFormat = value;
                Action act = () => InvokePropertyChanged_OutputFormat(new PropertyChangedEventArgs("TotalDowntime_OutputFormat"));
                try { _owner.Invoke(act); } catch { }
            }
        }

        private string totalProfit_OutputFormat;
        public string TotalProfit_OutputFormat
        {
            get => totalProfit_OutputFormat;
            private set
            {
                totalProfit_OutputFormat = value;
                Action act = () => InvokePropertyChanged_OutputFormat(new PropertyChangedEventArgs("TotalProfit_OutputFormat"));
                try { _owner.Invoke(act); } catch { }
            }
        }


        public void InvokePropertyChanged_Input(PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "ServedClientsCount":
                    Setter_ServedClientsCount_OutputFormat();
                    break;

                case "CurrentQueueSize":
                    Setter_CurrentQueueSize_OutputFormat();
                    break;

                case "AverageQueueSize":
                    Setter_AverageQueueSize_OutputFormat();
                    break;

                case "CurrentAllMastersBusyness":
                    Setter_CurrentAllMastersBusyness_OutputFormat();
                    break;

                case "AverageOneMasterBusyness":
                    Setter_AverageOneMasterBusyness_OutputFormat();
                    break;

                case "TotalDowntime":
                    Setter_TotalDowntime_OutputFormat();
                    break;

                case "TotalProfit":
                    Setter_TotalProfit_OutputFormat();
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void InvokePropertyChanged_OutputFormat(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }


        public Hall(Form owner)
        {
            _owner = owner;
        }

        
        private void Setter_ServedClientsCount_OutputFormat()
        {
            ServedClientsCount_OutputFormat = ServedClientsCount + " чел.";
        }

        private void Setter_CurrentQueueSize_OutputFormat()
        {
            CurrentQueueSize_OutputFormat = CurrentQueueSize + " из 5 чел.";
        }

        private void Setter_AverageQueueSize_OutputFormat()
        {
            AverageQueueSize_OutputFormat = string.Format("{0:f}", AverageQueueSize) + " чел.";
        }

        private void Setter_CurrentAllMastersBusyness_OutputFormat()
        {
            CurrentAllMastersBusyness_OutputFormat = $"{CurrentAllMastersBusyness} из {Masters.Count} чел.";
        }

        private void Setter_AverageOneMasterBusyness_OutputFormat()
        {
            AverageOneMasterBusyness_OutputFormat = string.Format("{0:f}", AverageOneMasterBusyness) + "%";
        }

        private void Setter_TotalDowntime_OutputFormat()
        {
            TotalDowntime_OutputFormat = string.Format("{0:f}", TotalDowntime) + " часов";
        }

        private void Setter_TotalProfit_OutputFormat()
        {
            TotalProfit_OutputFormat = TotalProfit + " руб.";
        }
    }
}
