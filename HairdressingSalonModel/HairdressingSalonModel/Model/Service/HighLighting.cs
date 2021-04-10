using System;

namespace HairdressingSalonModel
{
    public class HighLighting : Service
    {
        public override int Price { get => 3000; }

        public HighLighting(IntegerRange customerServiceDeviationRange)
        {
            base.CustomerServiceDeviationRange = customerServiceDeviationRange;
            base.ServiceDuration = ServiceDurationInit(60, 120);
        }
    }
}
