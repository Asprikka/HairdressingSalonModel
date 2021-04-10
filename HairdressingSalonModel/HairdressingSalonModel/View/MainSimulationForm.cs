using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HairdressingSalonModel
{
    public partial class MainSimulationForm : Form
    {
        private bool firstStart = true;
        private SimulationState simulationState = SimulationState.Stopped;
        private readonly SalonSimulator salonSimulator;


        public MainSimulationForm(SimulationOptions simulationOptions)
        {
            InitializeComponent();

            salonSimulator = new SalonSimulator(this, simulationOptions);
            InitializeBindings();
        }


        private void InitializeBindings()
        {
            Hall h1 = salonSimulator.halls[0], 
                 h2 = salonSimulator.halls[1], 
                 h3 = salonSimulator.halls[2];

            // Clock
            labelElapsedTimeClock.DataBindings.Add("Text", salonSimulator, "CurrentSimulationTime_OutputFormat");

            // Hall 1
            labelServedClientsCount1.DataBindings.Add("Text", h1, "ServedClientsCount_OutputFormat");
            labelCurrentQueueSize1.DataBindings.Add("Text", h1, "CurrentQueueSize_OutputFormat");
            labelAverageQueueSize1.DataBindings.Add("Text", h1, "AverageQueueSize_OutputFormat");

            labelCurrentAllMastersBusyness1.DataBindings.Add("Text", h1, "CurrentAllMastersBusyness_OutputFormat");
            labelAverageOneMasterBusyness1.DataBindings.Add("Text", h1, "AverageOneMasterBusyness_OutputFormat");
            labelTotalDowntime1.DataBindings.Add("Text", h1, "TotalDowntime_OutputFormat");
            labelTotalProfit1.DataBindings.Add("Text", h1, "TotalProfit_OutputFormat");

            // Hall 2
            labelServedClientsCount2.DataBindings.Add("Text", h2, "ServedClientsCount_OutputFormat");
            labelCurrentQueueSize2.DataBindings.Add("Text", h2, "CurrentQueueSize_OutputFormat");
            labelAverageQueueSize2.DataBindings.Add("Text", h2, "AverageQueueSize_OutputFormat");

            labelCurrentAllMastersBusyness2.DataBindings.Add("Text", h2, "CurrentAllMastersBusyness_OutputFormat");
            labelAverageOneMasterBusyness2.DataBindings.Add("Text", h2, "AverageOneMasterBusyness_OutputFormat");
            labelTotalDowntime2.DataBindings.Add("Text", h2, "TotalDowntime_OutputFormat");
            labelTotalProfit2.DataBindings.Add("Text", h2, "TotalProfit_OutputFormat");

            // Hall 3
            labelServedClientsCount3.DataBindings.Add("Text", h3, "ServedClientsCount_OutputFormat");
            labelCurrentQueueSize3.DataBindings.Add("Text", h3, "CurrentQueueSize_OutputFormat");
            labelAverageQueueSize3.DataBindings.Add("Text", h3, "AverageQueueSize_OutputFormat");

            labelCurrentAllMastersBusyness3.DataBindings.Add("Text", h3, "CurrentAllMastersBusyness_OutputFormat");
            labelAverageOneMasterBusyness3.DataBindings.Add("Text", h3, "AverageOneMasterBusyness_OutputFormat");
            labelTotalDowntime3.DataBindings.Add("Text", h3, "TotalDowntime_OutputFormat");
            labelTotalProfit3.DataBindings.Add("Text", h3, "TotalProfit_OutputFormat");
        }


        private void ButtonStopRun_Click(object sender, EventArgs e)
        {
            if (simulationState == SimulationState.Stopped)
            {
                salonSimulator.Run(ref firstStart);
                ButtonStopRun.Text = "ОСТАНОВИТЬ";
                ButtonStopRun.BackColor = Color.FromArgb(255, 128, 128);
                simulationState = SimulationState.Running;
            }
            else
            {
                salonSimulator.Stop();
                ButtonStopRun.Text = "ПРОДОЛЖИТЬ";
                ButtonStopRun.BackColor = Color.OliveDrab;
                simulationState = SimulationState.Stopped;
            }
        }        
    }


    enum SimulationState
    {
        Stopped,
        Running
    }
}
