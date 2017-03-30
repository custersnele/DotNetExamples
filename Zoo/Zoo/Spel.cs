using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    class Spel
    {
        private int ronde;
        private bool[] transportkooiGenomen = new bool[2];
        private int huidigeSpeler;


        public int HuidigeSpeler
        {
            get
            {
                return huidigeSpeler;

            }
        }

        public Spel()
        {
            ronde = 1;
            InitSpelers();
            huidigeSpeler = 1;
        }

        private void InitSpelers()
        {
            
        }

        public void StartVolgendeRonde()
        {
            ronde++;
            transportkooiGenomen[0] = false;
            transportkooiGenomen[1] = false;
        }

        public bool IsRondeVoorbij()
        {
            return transportkooiGenomen[0] && transportkooiGenomen[1];
        }

        public void NeemTransportkooi()
        {
           transportkooiGenomen[HuidigeSpeler-1] = true;
        }

        public void WisselSpeler()
        {
            if (huidigeSpeler == 1 && !transportkooiGenomen[1])
            {
                huidigeSpeler = 2;
            }
            else if (huidigeSpeler == 2 && !transportkooiGenomen[0])
            { 
                    huidigeSpeler = 1;
               
            }
        }

    }
}
