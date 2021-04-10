using System;

namespace HairdressingSalonModel
{
    public class SimulationOptions
    {
        private int hallCount;
        public int HallCount
        {
            get => hallCount;
            set
            {
                if (value > 0 && value <= 3)
                    hallCount = value;
                else
                    throw new NotImplementedException();
            }
        }

        private int[] masterCount;
        public int[] MasterCount
        {
            get => masterCount;
            set
            {
                int sum = 0;
                for (int i = 0; i < hallCount; i++)
                    sum += value[i];

                if (sum == 0) throw new NotImplementedException();

                for (int i = 0; i < hallCount; i++)
                    if (value[i] > 5) throw new NotImplementedException();

                for (int i = hallCount; i < value.Length; i++)
                    if (value[i] != 0) throw new NotImplementedException();

                masterCount = value;
            }
        }

        public uint TimeBetweenOrders { get; set; }

        private IntegerRange customerServiceDeviationRange;
        public IntegerRange CustomerServiceDeviationRange
        {
            get => customerServiceDeviationRange;
            set
            {
                if (value.First <= value.Last)
                    customerServiceDeviationRange = value;
                else
                    throw new NotImplementedException();
            }
        }

        private int timeStep;
        public int TimeStep
        {
            get => timeStep;
            set
            {
                if (value >= 1 && value <= 15)
                    timeStep = value;
                else
                    throw new NotImplementedException();
            }
        }

        private double simulationSpeed;
        public double SimulationSpeed
        {
            get => simulationSpeed;
            set
            {
                if (value >= 0.1 && value <= 1000)
                    simulationSpeed = value;
                else
                    throw new NotImplementedException();
            }
        }


        public SimulationOptions
            (int hallCount, int[] masterCount, uint timeBetweenRequestsRange, 
            IntegerRange customerServiceDeviationRange, int timeStep, double simulationSpeed)
        {
            HallCount = hallCount;
            MasterCount = masterCount;
            TimeBetweenOrders = timeBetweenRequestsRange;
            CustomerServiceDeviationRange = customerServiceDeviationRange;
            TimeStep = timeStep;
            SimulationSpeed = simulationSpeed;
        }
    }
}
