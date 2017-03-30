using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Zoo
{
    class Spel
    {
        private int ronde;
        private bool[] transportkooiGenomen = new bool[2];
        private int huidigeSpeler;
        private TextBlock instructieBlock;

        public Spel(TextBlock instructieBlock)
        {
            this.instructieBlock = instructieBlock;
            ronde = 1;
            InitSpelers();
            huidigeSpeler = 1;
        }

        public void Start()
        {
            instructieBlock.Text += "Ronde 1\n";
            instructieBlock.Text += "Speler1: draai een fiche om en plaats ze in een transportkooi.";
        }

        public int HuidigeSpeler
        {
            get
            {
                return huidigeSpeler;

            }
        }

        private void InitSpelers()
        {
            
        }

        public void StartVolgendeRonde()
        {
            ronde++;
            transportkooiGenomen[0] = false;
            transportkooiGenomen[1] = false;
            instructieBlock.Text = "Ronde " + ronde;
            instructieBlock.Text += "Speler " + huidigeSpeler + " : draai een fiche om en plaats ze in een transportkooi.";
            instructieBlock.Text += "\nOF kies een transportkooi.";
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
            instructieBlock.Text = "Speler " + huidigeSpeler + " : draai een fiche om en plaats ze in een transportkooi.";
            instructieBlock.Text += "\nOF kies een transportkooi.";
        }

    }
}
