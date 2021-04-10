using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;

using Timer = System.Threading.Timer;

namespace HairdressingSalonModel
{
    public class SalonSimulator : INotifyPropertyChanged 
    {
        private readonly Form _owner;
        private readonly SimulationOptions simulationOptions;
        public readonly List<Hall> halls;
        private Timer simulationTimer;
        private SimulationState simulationState;
        private readonly List<string> loglist;

        #region Хардкод-параметры
        // All in minutes
        private const int MAX_HALL_COUNT = 3;
        private const int MAX_QUEUE_SIZE = 5;

        //All in percents
        private const int PLAIN_HAIRCUT_FREQUENCY = 70;
        private const int MODEL_HAIRCUT_FREQUENCY = 25;
        private const int HIGHLIGHTING_FREQUENCY = 5;

        private const int ONE_SERVICE_IN_ORDER = 75;
        private const int TWO_SERVICES_IN_ORDER = 20;
        private const int THREE_SERVICES_IN_ORDER = 5;

        private const double MONDAY_DISTRIBUTION = +41.7;
        private const double TUESDAY_DISTRIBUTION = -22.2;
        private const double WEDNESDAY_DISTRIBUTION = -34.1;
        private const double THURSDAY_DISTRIBUTION = -16.2;
        private const double FRIDAY_DISTRIBUTION = +33.8;
        private const double SATURDAY_DISTRIBUTION = +44.7;

        private const double DISTRIBUTION_09_12 = +6.1;
        private const double DISTRIBUTION_12_17 = -39.4;
        private const double DISTRIBUTION_17_21 = +36.3;
        #endregion

        #region Часы
        private DateTime currentSimulationTime;
        public DateTime CurrentSimulationTime
        {
            get => currentSimulationTime;
            set
            {
                currentSimulationTime = value;
                try { InvokePropertyChanged_Input(); } catch { }
            }
        }

        public void InvokePropertyChanged_Input()
        {
            DateTime dt = CurrentSimulationTime;
            CurrentSimulationTime_OutputFormat = string.Format("{0:d2}", dt.Day)
                + " : " + string.Format("{0:d2}", dt.Hour) + " : " + string.Format("{0:d2}", dt.Minute);
        }

        private string currentSimulationTime_OutputFormat;
        public string CurrentSimulationTime_OutputFormat
        {
            get => currentSimulationTime_OutputFormat;
            set
            {
                currentSimulationTime_OutputFormat = value;
                Action act = () => InvokePropertyChanged_OutputFormat(new PropertyChangedEventArgs("CurrentSimulationTime_OutputFormat"));
                try { _owner.Invoke(act); } catch { }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void InvokePropertyChanged_OutputFormat(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
        #endregion


        public SalonSimulator(Form owner, SimulationOptions simulationOptions)
        {
            _owner = owner;
            CurrentSimulationTime = new DateTime(1, 1, 1).AddHours(9);
            simulationState = SimulationState.Stopped;
            halls = new List<Hall>();
            loglist = new List<string>();

            this.simulationOptions = simulationOptions;

            for (int i = 0; i < MAX_HALL_COUNT; i++)
            {
                Hall hall = new Hall(_owner);
                for (int j = 0; j < this.simulationOptions.MasterCount[i]; j++)
                    hall.Masters.Add(new Master());

                halls.Add(hall);
            }
        }


        public void Run(ref bool firstStart)
        {
            if (firstStart)
            {
                simulationTimer = new Timer(
                    new TimerCallback(SimulateNextStepTimerCallback),
                    null, 0, (int)(1 / simulationOptions.SimulationSpeed * 1000)
                );

                firstStart = false;
            }

            simulationState = SimulationState.Running;
        }


        public void Stop()
        {
            simulationState = SimulationState.Stopped;
        }


        private void SimulateNextStepTimerCallback(object obj)
        {
            if (simulationState == SimulationState.Stopped)
                return;

            bool statement1, statement2, statement3, statement4;
            statement1 = CurrentSimulationTime.Hour < 9;
            statement2 = CurrentSimulationTime.DayOfWeek == DayOfWeek.Saturday && CurrentSimulationTime.Hour >= 17;
            statement3 = CurrentSimulationTime.DayOfWeek != DayOfWeek.Saturday && CurrentSimulationTime.Hour >= 21;
            statement4 = CurrentSimulationTime.DayOfWeek == DayOfWeek.Sunday;

            if (statement1 || statement3 || statement4)
            {
                CurrentSimulationTime = CurrentSimulationTime.AddMinutes(simulationOptions.TimeStep);
                return;
            }
            else if (statement2)
            {
                EndSimulation();
            }

            SimulateNextStep();

            CurrentSimulationTime = CurrentSimulationTime.AddMinutes(simulationOptions.TimeStep);
        }


        private void SimulateNextStep()
        {
            foreach (Hall hall in halls)
            {
                if (hall.Masters.Count == 0)
                    return;

                // Переменные, куда собираются новые статистические данные.
                // После этого они прибавятся или заменять текущие данные, которые выведены на экран
                int _servedClientsCount = 0, _currentQueueSize = 0, _currentAllMastersBusyness = 0, _totalProfit = 0;
                double _averageQueueSize = 0, _averageOneMasterBusyness = 0, _totalDowntime = 0;

                // Проверяем каждого мастера в текущем зале на занятость.
                // Если мастер простаивает без дела, он добавляется в список mastersWithoutWork.
                List<Master> mastersWithoutWork = new List<Master>();
                for (int i = 0; i < hall.Masters.Count; i++)
                {
                    Master master = hall.Masters[i];

                    if (master.CurrentService == null) // Если у мастера нету работы.
                    {
                        mastersWithoutWork.Add(master);

                        int masterDowntime = (CurrentSimulationTime != new DateTime(1, 1, 1).AddHours(9))
                            ? simulationOptions.TimeStep
                            : 0;

                        double aa = masterDowntime / 60f;
                        _totalDowntime += aa;
                        loglist.Add($"{aa} null\n");
                    }
                    else // Если у мастера есть работа, или же он закончил её только на этом шаге моделирования.
                    {
                        master.CurrentService.ServiceDuration -= simulationOptions.TimeStep; // В минутах

                        if (master.CurrentService.ServiceDuration <= 0) // Текущая услуга выполнена на этом шаге моделирования.
                        {
                            mastersWithoutWork.Add(master);

                            // Обновляем статистику после выполнения услуги
                            _servedClientsCount++;
                            var aa = Math.Abs(master.CurrentService.ServiceDuration / 60f); // В часах
                            _totalDowntime += aa;
                            loglist.Add($"{aa} fin\n");
                            _totalProfit += master.CurrentService.Price;
                            master.TotalWorkPrice += master.CurrentService.Price;
                            master.CurrentService = null;
                        }
                    }
                }

                // Обновляем очередь клиентов в текущем зале.
                // Обновление происходит посредством рандомного составления заказов
                // с учетом закономерностей распределения клиентов по дням недели и времени суток
                //double timerDependenceCoef = simulationOptions.TimeStep / (double)simulationOptions.TimeBetweenOrders;
                int ordersCount = -1;
                Random rnd = new Random();
                for (double sum = 0; sum <= simulationOptions.TimeStep; ordersCount++)
                {
                    double ds = 2 * simulationOptions.TimeBetweenOrders * rnd.NextDouble();
                    sum += ds;
                }

                int a = ordersCount;
                double b = GetWeeklyCoef();
                double c = GetDailyCoef();
                ordersCount = (int)Math.Round(a * b * c);

                for (int i = 0; i < ordersCount; i++)
                {
                    var randServicesCount = new Randomizer<int>();
                    randServicesCount.Set.Add(new KeyValuePair<int, int>(1, ONE_SERVICE_IN_ORDER));
                    randServicesCount.Set.Add(new KeyValuePair<int, int>(2, TWO_SERVICES_IN_ORDER));
                    randServicesCount.Set.Add(new KeyValuePair<int, int>(3, THREE_SERVICES_IN_ORDER));
                    int counter = randServicesCount.GetRandom();

                    var order = new Queue<Service>();

                    for (int j = 0; j < counter; j++)
                    {
                        var randServices = new Randomizer<Func<Service>>();
                        randServices.Set.Add(new KeyValuePair<Func<Service>, int>(
                            new Func<Service>(() => new PlainHaircut(simulationOptions.CustomerServiceDeviationRange)),
                            PLAIN_HAIRCUT_FREQUENCY
                        ));
                        randServices.Set.Add(new KeyValuePair<Func<Service>, int>(
                            new Func<Service>(() => new ModelHaircut(simulationOptions.CustomerServiceDeviationRange)),
                            MODEL_HAIRCUT_FREQUENCY
                        ));
                        randServices.Set.Add(new KeyValuePair<Func<Service>, int>(
                            new Func<Service>(() => new HighLighting(simulationOptions.CustomerServiceDeviationRange)),
                            HIGHLIGHTING_FREQUENCY
                        ));

                        Service service = randServices.GetRandom().Invoke();
                        order.Enqueue(service);
                    }

                    hall.OrderQueue.Enqueue(order);
                }

                // Каждому мастеру без работу пытаемся дать услугу на выполнение.
                // В первую очередь новая услуга на выполнение берётся с master.ServiceQueue (список услуг для одного клиента).
                // Если этот список пуст, то мастеру дается новый заказ с новым списком услуг, если в очереди в зал есть клиенты.
                // Если очередь в зал пуста, то мастер остается без дела, пока не придёт новый клиент
                foreach (Master master in mastersWithoutWork)
                {
                    if (master.ServiceQueue.Count != 0)
                        master.CurrentService = master.ServiceQueue.Dequeue();
                    else if (hall.OrderQueue.Count != 0)
                    {
                        master.ServiceQueue = hall.OrderQueue.Dequeue();
                        master.CurrentService = master.ServiceQueue.Dequeue();
                    }
                }

                // Очищаем лишних клиентов, если очередь получилась больше, чем ограничено программой
                if (hall.OrderQueue.Count > MAX_QUEUE_SIZE)
                {
                    var tempQueue = new Queue<Queue<Service>>();
                    for (int i = 0; i < MAX_QUEUE_SIZE; i++)
                        tempQueue.Enqueue(hall.OrderQueue.Dequeue());

                    hall.OrderQueue = new Queue<Queue<Service>>();
                    hall.OrderQueue = tempQueue;
                }

                // Обнуление клиентов под конец рабочего дня
                bool statement2, statement3;
                statement2 = (CurrentSimulationTime.DayOfWeek == DayOfWeek.Saturday) && (CurrentSimulationTime.AddMinutes(simulationOptions.TimeStep).Hour >= 17);
                statement3 = (CurrentSimulationTime.DayOfWeek != DayOfWeek.Saturday) && (CurrentSimulationTime.AddMinutes(simulationOptions.TimeStep).Hour >= 21);

                if (statement2 || statement3)
                {
                    foreach (Master master in hall.Masters)
                    {
                        master.CurrentService = null;
                        master.ServiceQueue = new Queue<Service>();
                    }

                    hall.OrderQueue = new Queue<Queue<Service>>();
                }

                // Собираем статистику по текущей занятости мастеров в зале
                foreach (Master master in hall.Masters)
                    if (master.CurrentService != null) _currentAllMastersBusyness++;

                // Вычисляем cредний процент занятости одного мастера
                double elapsedTime = hall.Masters.Count * ((CurrentSimulationTime.Ticks / 1E7f / 60f) + simulationOptions.TimeStep) / 60f;
                _averageOneMasterBusyness = (elapsedTime - hall.TotalDowntime) / elapsedTime * 100;

                // Собираем статистику по текущему размеру очереди в зале
                _currentQueueSize = hall.OrderQueue.Count();

                // Вычисляем cредний размер очереди в зале
                double elapsedStepsCount = (CurrentSimulationTime.Ticks / 1E7f / 60f + simulationOptions.TimeStep) / simulationOptions.TimeStep;
                _averageQueueSize = (hall.AverageQueueSize * (elapsedStepsCount - 1) + _currentQueueSize) / elapsedStepsCount;

                // Сохраняем результаты моделирования одного шага для одного зала
                hall.ServedClientsCount += _servedClientsCount;
                hall.CurrentQueueSize = _currentQueueSize;
                hall.AverageQueueSize = _averageQueueSize;
                hall.CurrentAllMastersBusyness = _currentAllMastersBusyness;
                hall.AverageOneMasterBusyness = _averageOneMasterBusyness;
                hall.TotalDowntime += _totalDowntime;
                hall.TotalProfit += _totalProfit;
            }
        }


        private double GetWeeklyCoef()
        {
            var dayOfWeek = CurrentSimulationTime.DayOfWeek;
            double result = 0;

            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    result = MONDAY_DISTRIBUTION;
                    break;

                case DayOfWeek.Tuesday:
                    result = TUESDAY_DISTRIBUTION;
                    break;

                case DayOfWeek.Wednesday:
                    result = WEDNESDAY_DISTRIBUTION;
                    break;

                case DayOfWeek.Thursday:
                    result = THURSDAY_DISTRIBUTION;
                    break;

                case DayOfWeek.Friday:
                    result = FRIDAY_DISTRIBUTION;
                    break;

                case DayOfWeek.Saturday:
                    result = SATURDAY_DISTRIBUTION;
                    break;
            }

            return (100 + result) / 100;
        }


        private double GetDailyCoef()
        {
            int time = CurrentSimulationTime.Hour;
            double result = 0;

            if (time >= 9 && time < 12) result = DISTRIBUTION_09_12;
            else if (time >= 12 && time < 17) result = DISTRIBUTION_12_17;
            else if (time >= 17 && time <= 21) result = DISTRIBUTION_17_21;

            return (100 + result) / 100;
        }
        

        private void EndSimulation()
        {
            var stats = new Queue<FinalStats>();
            foreach (Hall hall in halls)
            {
                stats.Enqueue(new FinalStats(
                    hall.ServedClientsCount,
                    hall.AverageQueueSize,
                    hall.AverageOneMasterBusyness,
                    hall.TotalDowntime,
                    hall.TotalProfit,
                    hall.Masters.Count
                ));
            }

            simulationTimer.Dispose();
            new FinalStatisticsForm(stats).ShowDialog();
            _owner.Invoke(new Action(() => _owner.Close()));
        }
    }
}
