using System;
using System.Linq;
using System.Windows.Forms;

namespace HairdressingSalonModel
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
        }

        private void ButtonSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                int hallCount;
                int[] masterCount;
                uint timeBetweenRequestsRange;
                IntegerRange customerServiceDeviationRange;
                int timeStep;
                double simulationSpeed;

                hallCount = int.Parse(textBoxHallCount.Text);

                masterCount = new int[3];
                var ls1 = textBoxMasterCount.Text.Split(new char[] { ' ' }).ToList();
                for (int i = 0; i < ls1.Count; i++)
                    masterCount[i] = int.Parse(ls1[i]);

                timeBetweenRequestsRange = uint.Parse(textBoxTimeBetweenOrders.Text);

                var ls3 = textBoxCustomerServiceDeviation.Text.Split(new char[] { ' ' }).ToList();
                customerServiceDeviationRange = new IntegerRange(int.Parse(ls3[0]), int.Parse(ls3[1]));

                timeStep = int.Parse(textBoxTimeStep.Text);

                simulationSpeed = double.Parse(textBoxSimulationSpeed.Text);

                //hallCount = 3;
                //masterCount = new int[] { 5, 3, 1 };
                //timeBetweenRequestsRange = 30;
                //customerServiceDeviationRange = new IntegerRange(-20, 20);
                //timeStep = 2;
                //simulationSpeed = 1000f;

                var simulationOptions = new SimulationOptions(
                    hallCount, masterCount, timeBetweenRequestsRange, customerServiceDeviationRange, timeStep, simulationSpeed
                );

                this.Hide();
                var mainSimulationForm = new MainSimulationForm(simulationOptions);
                mainSimulationForm.ShowDialog();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка!!!\nДанныe введены некорректно!");
            }
        }
    }
}
