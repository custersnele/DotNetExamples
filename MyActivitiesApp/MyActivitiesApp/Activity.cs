using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyActivitiesApp
{
    public class Activity
    {
        public TimeSpan Duration { get; set; }
        public ActivityType ActivityType { get; set; }

        public override string ToString()
        {
            return Duration + " " + ActivityType;
        }

        public int CalculateKCal(int weight)
        {
            return Convert.ToInt32(ActivityType.KCal * Duration.TotalHours * weight);
        }
    }
}
