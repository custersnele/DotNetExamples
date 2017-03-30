using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Zoo
{
    class Dierenverblijf
    {
        private Dier[] dieren;
        private int aantalDieren;
        private Attractie[] attracties;
        private int aantalAttracties;
        private bool open;

        public bool IsOpen
        {
            get { return open; }
        }

        private Canvas verblijfCanvas;

        public Dierenverblijf(int aantalDieren, int aantalAttracties, bool open, Canvas verblijfCanvas)
        {
            dieren = new Dier[aantalDieren];
            attracties = new Attractie[aantalAttracties];
            this.open = open;
            this.verblijfCanvas = verblijfCanvas;
        }

        public int AantalDieren
        {
            get { return dieren.Length; }
        }


        public bool IsLeeg()
        {
            return aantalDieren == 0;
        }

        public bool IsVol()
        {
            return aantalDieren == dieren.Length;
        }

        public bool HeeftPlaatsVoorAttractie()
        {
            return aantalAttracties < attracties.Length;
        }
        
        public void VoegDierToe(Dier dier)
        {
            if (DierSoort == null || dier.Soort == DierSoort)
            {
                dieren[aantalDieren] = dier;
                aantalDieren++;
                int hoogte = (int)verblijfCanvas.Height / (dieren.Length + attracties.Length);
                Image dierImage = new Image
                {
                    Width = verblijfCanvas.Width,
                    Height = hoogte,
                    Margin = new Thickness(0, hoogte * (aantalDieren + aantalAttracties - 1), 0, 0),
                    Source = new BitmapImage(new Uri(@"fiches\" + dier.getImageName() + ".png", UriKind.Relative)),
                };

                verblijfCanvas.Children.Add(dierImage);
            }
        }


        public void VoegAttractieToe(Attractie attractie)
        {
                attracties[aantalAttracties] = attractie;
                aantalAttracties++;
                int hoogte = (int)verblijfCanvas.Height / (dieren.Length + attracties.Length);
                Image attractieImage = new Image
                {
                    Width = verblijfCanvas.Width,
                    Height = hoogte,
                    Margin = new Thickness(0, hoogte * (aantalDieren + aantalAttracties - 1), 0, 0),
                    Source = new BitmapImage(new Uri(@"fiches\" + attractie.getImageName() + ".png", UriKind.Relative)),
                };

                verblijfCanvas.Children.Add(attractieImage);
        }


        public Dier.DierSoort? DierSoort
        {
            get
            {
                if (dieren[0] == null)
                {
                    return null;
                }
                return dieren[0].Soort;
            }
        }

        public void Koop()
        {
            if (!IsOpen)
            {
                open = true;
            }
        }
    }
}
