using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairdressingSalonModel
{
    public class Master
    {
        public Service CurrentService { get; set; } = null;
        public Queue<Service> ServiceQueue { get; set; } = new Queue<Service>();
        public int TotalWorkPrice { get; set; } = 0;
    }
}
