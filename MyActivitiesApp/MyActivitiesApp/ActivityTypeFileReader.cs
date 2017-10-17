using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyActivitiesApp
{
    class ActivityTypeFileReader
    {
        public static List<ActivityType> Read(string fileName)
        {
            List<ActivityType> activityTypeList = new List<ActivityType>();
            StreamReader reader = null;
            try
            {
       
                reader = File.OpenText(fileName);
                string line = reader.ReadLine();

                while (line != null)
                {
                    var item = ParseActivityType(line);
                    if (item != null)
                    {
                        activityTypeList.Add(item);
                    }

                    line = reader.ReadLine();
                }
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return activityTypeList;
        }

        private static ActivityType ParseActivityType(string line)
        {
            var parts = line.Split(new[] { ';' });
            if (parts.Length < 2) return null;
            if (parts[0].StartsWith("SPORT:"))
            {
                return new ActivityType(parts[0].Substring(6), Convert.ToDouble(parts[1]), true);
            } else
            {
                return new ActivityType(parts[0], Convert.ToDouble(parts[1]), false);
            }
        }

    }
}