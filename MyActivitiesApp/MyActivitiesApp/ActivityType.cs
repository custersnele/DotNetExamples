using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyActivitiesApp
{
    public class ActivityType
    {
        public string Name { get; }
        public double KCal { get; }
        public bool IsSport { get; set; }

        public ActivityType(string name, double kCal, bool isSport)
        {
            Name = name;
            KCal = kCal;
            IsSport = isSport;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
