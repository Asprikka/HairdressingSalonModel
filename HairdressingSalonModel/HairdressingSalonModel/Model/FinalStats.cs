namespace HairdressingSalonModel
{
    public struct FinalStats
    {
        public int ServedClientsCount { get; set; }
        public double AverageQueueSize { get; set; }
        public double AverageOneMasterBusyness { get; set; }
        public double TotalDowntime { get; set; }
        public int TotalProfit { get; set; }
        public int MastersCount { get; set; }

        public FinalStats
            (int servedClientsCount, double averageQueueSize, double averageOneMasterBusyness, double totalDowntime, int totalProfit, int mastersCount)
        {
            ServedClientsCount = servedClientsCount;
            AverageQueueSize = averageQueueSize;
            AverageOneMasterBusyness = averageOneMasterBusyness;
            TotalDowntime = totalDowntime;
            TotalProfit = totalProfit;
            MastersCount = mastersCount;
        }
    }
}
