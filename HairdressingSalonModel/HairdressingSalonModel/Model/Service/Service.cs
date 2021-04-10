using System;

namespace HairdressingSalonModel
{
    public class Service
    {
        public virtual int Price { get; }

        protected int serviceDuration;
        public int ServiceDuration { get; set; }

        protected IntegerRange CustomerServiceDeviationRange { get; set; }


        protected int ServiceDurationInit(int first, int last)
        {
            int value = new Random().Next(first, last);

            double rand = new Random().NextDouble();
            int deviationRange = Math.Abs(CustomerServiceDeviationRange.First) + CustomerServiceDeviationRange.Last;

            double deviationPercent = (CustomerServiceDeviationRange.First + rand * deviationRange) / 100;

            return (int)(value + value * deviationPercent);
        }
    }
}
