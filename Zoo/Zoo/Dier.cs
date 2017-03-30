using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    class Dier:TransportFiche
    {
        public enum DierSoort { Aardvarken, Dikhoornschaap, Zebra, Leeuw};
        public DierSoort Soort { get; set; }

        public Dier(string soort)
        {
            if (soort == "aardvarken")
            {
                Soort = DierSoort.Aardvarken;
            } else if (soort == "zebra")
            {
                Soort = DierSoort.Zebra;
            } else
            {
                Soort = DierSoort.Leeuw;
            }
            
        }

        public override string getImageName()
        {
            return Soort.ToString().ToLower();
        }
    }
}
