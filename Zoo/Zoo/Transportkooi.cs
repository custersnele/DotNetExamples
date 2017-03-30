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
    class Transportkooi
    {
        private const int maxFiches = 3;
        private TransportFiche[] fiches = new TransportFiche[maxFiches];
        private Image[] images = new Image[maxFiches];
        private int aantalFiches = 0;
        private Canvas canvas;

        public Transportkooi(Canvas canvas)
        {
            this.canvas = canvas;
            Initialiseer();
        }

        public void Initialiseer()
        {
            canvas.Children.Clear();
            aantalFiches = 0;
            fiches = new TransportFiche[maxFiches];
            images = new Image[maxFiches];
    }

        public Boolean isLeeg()
        {
            return aantalFiches == 0;
        }

        public Boolean isVol()
        {
            return aantalFiches == maxFiches;
        }

        public TransportFiche neemFiche()
        {
            TransportFiche fiche = fiches[aantalFiches - 1];
            fiches[aantalFiches - 1] = null;
            canvas.Children.Remove(images[aantalFiches - 1]);
            aantalFiches--;
            return fiche;
        }

        public void voegFicheToe(TransportFiche fiche)
        {
            fiches[aantalFiches] = fiche;
            aantalFiches++;
            Image dierImage = new Image
            {
                Width = canvas.Width / 3,
                Height = canvas.Height,
                Margin = new Thickness(canvas.Width / 3 * (aantalFiches - 1), 0, 0, 0),
                Source = new BitmapImage(new Uri(@"fiches\" + fiche.getImageName() + ".png" , UriKind.Relative)),
            };
            images[aantalFiches - 1] = dierImage;

            canvas.Children.Add(dierImage);
        }
    }
}
