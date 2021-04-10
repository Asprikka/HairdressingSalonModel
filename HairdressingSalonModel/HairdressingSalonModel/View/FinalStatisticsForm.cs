using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HairdressingSalonModel
{
    public partial class FinalStatisticsForm : Form
    {
        public FinalStatisticsForm(Queue<FinalStats> stats)
        {
            InitializeComponent();

            FinalStats stats1, stats2, stats3;
            stats1 = stats.Dequeue();
            stats2 = stats.Dequeue();
            stats3 = stats.Dequeue();
            
            // The all salon
            labelServedClientsCount.Text = stats1.ServedClientsCount + stats2.ServedClientsCount + stats3.ServedClientsCount + " чел.";
            labelAverageQueueSize.Text = string.Format("{0:f}", (stats1.MastersCount * stats1.AverageQueueSize + stats2.MastersCount * stats2.AverageQueueSize + stats2.MastersCount * stats3.AverageQueueSize) / (double)(stats1.MastersCount + stats2.MastersCount + stats3.MastersCount)) + " чел.";
            labelAverageOneMasterBusyness.Text = string.Format("{0:f}", (stats1.MastersCount * stats1.AverageOneMasterBusyness + stats2.MastersCount * stats2.AverageOneMasterBusyness + stats3.MastersCount * stats3.AverageOneMasterBusyness) / (double)(stats1.MastersCount + stats2.MastersCount + stats3.MastersCount)) + "%";
            labelTotalDowntime.Text = string.Format("{0:f}", stats1.TotalDowntime + stats2.TotalDowntime + stats3.TotalDowntime) + " часов";

            double a = 0.4 * (stats1.TotalProfit + stats2.TotalProfit + stats3.TotalProfit) / (double)(stats1.MastersCount + stats2.MastersCount + stats3.MastersCount);
            double b = (a > 7000) ? a : 7000;
            labelAverageSalary.Text = string.Format("{0:f}", b) + " руб./нед.";

            labelTotalProfit.Text = stats1.TotalProfit + stats2.TotalProfit + stats3.TotalProfit + " руб.";


            // Hall 1
            labelServedClientsCount1.Text = stats1.ServedClientsCount + " чел.";
            labelAverageQueueSize1.Text = string.Format("{0:f}", stats1.AverageQueueSize) + " чел.";
            labelAverageOneMasterBusyness1.Text = string.Format("{0:f}", stats1.AverageOneMasterBusyness) + "%";
            labelTotalDowntime1.Text = string.Format("{0:f}", stats1.TotalDowntime) + " часов";
            labelTotalProfit1.Text = stats1.TotalProfit + " руб.";

            // Hall 2
            labelServedClientsCount2.Text = stats2.ServedClientsCount + " чел.";
            labelAverageQueueSize2.Text = string.Format("{0:f}", stats2.AverageQueueSize) + " чел.";
            labelAverageOneMasterBusyness2.Text = string.Format("{0:f}", stats2.AverageOneMasterBusyness) + "%";
            labelTotalDowntime2.Text = string.Format("{0:f}", stats2.TotalDowntime) + " часов";
            labelTotalProfit2.Text = stats2.TotalProfit + " руб.";

            // Hall 3
            labelServedClientsCount3.Text = stats3.ServedClientsCount + " чел.";
            labelAverageQueueSize3.Text = string.Format("{0:f}", stats3.AverageQueueSize) + " чел.";
            labelAverageOneMasterBusyness3.Text = string.Format("{0:f}", stats3.AverageOneMasterBusyness) + "%";
            labelTotalDowntime3.Text = string.Format("{0:f}", stats3.TotalDowntime) + " часов";
            labelTotalProfit3.Text = stats3.TotalProfit + " руб.";
        }

        private void ButtonExit_Click(object sender, EventArgs e) => this.Close();
    }
}
