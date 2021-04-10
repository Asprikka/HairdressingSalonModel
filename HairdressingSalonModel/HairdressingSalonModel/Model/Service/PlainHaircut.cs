using System;

namespace HairdressingSalonModel
{
    public class PlainHaircut : Service
    {
        public override int Price { get => 500; } 

        public PlainHaircut(IntegerRange customerServiceDeviationRange)
        {
            base.CustomerServiceDeviationRange = customerServiceDeviationRange;
            base.ServiceDuration = ServiceDurationInit(15, 30);
        }
    }
}
