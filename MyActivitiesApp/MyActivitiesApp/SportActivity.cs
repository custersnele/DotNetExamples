using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyActivitiesApp
{
    class SportActivity:Activity
    {
        public int AveragHeartRate { get; set; }

        public override string ToString()
        {
            return base.ToString() + " \u2764 " + AveragHeartRate;
        }
    }
}
