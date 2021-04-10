using System;

namespace HairdressingSalonModel
{
    public class ModelHaircut : Service
    {
        public override int Price { get => 1500; }

        public ModelHaircut(IntegerRange customerServiceDeviationRange)
        {
            base.CustomerServiceDeviationRange = customerServiceDeviationRange;
            base.ServiceDuration = ServiceDurationInit(30, 60);
        }
    }
}
