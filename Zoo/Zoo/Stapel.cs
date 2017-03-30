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
    class Stapel
    {
        private TransportFiche huidigeFiche;
        private TransportFiche[] fiches = new TransportFiche[68];
        private Random random = new Random();
        private int aantalFiches;
        private Canvas stapelCanvas;
        private Image huidigeFicheImage;

        public TransportFiche HuidigeFiche
        {
            get
            {
                return huidigeFiche;
            }
        }

        public TransportFiche neemKaartVanStapel()
        {
            TransportFiche result = huidigeFiche;
            huidigeFiche = null;
            huidigeFicheImage.Source = null;
            return result;
        }

        public Stapel(Canvas stapelCanvas)
        {
            this.stapelCanvas = stapelCanvas;
            voegDierenToe("aardvarken", ref aantalFiches);
            voegDierenToe("dikhoornschaap", ref aantalFiches);
            voegDierenToe("zebra", ref aantalFiches);
            voegDierenToe("leeuw", ref aantalFiches);
            for (int i = 0; i < 12; i++)
            {
                fiches[aantalFiches++] = new Munt();
            }
            for (int i= 0; i < 3; i++)
            {
                fiches[aantalFiches++] = new Pannenkoekenhuisje();
                fiches[aantalFiches++] = new Shop();
                fiches[aantalFiches++] = new Speeltuin();
                fiches[aantalFiches++] = new Snackbar();

            }
            huidigeFicheImage = new Image
            {
                Width = stapelCanvas.Width / 2,
                Height = stapelCanvas.Height,
                Margin = new Thickness(stapelCanvas.Width / 2, 0, 0, 0),
                //Source = new BitmapImage(new Uri(@"fiches\" + huidigeFiche.getImageName() + ".png", UriKind.Relative)),
            };

            stapelCanvas.Children.Add(huidigeFicheImage);
        }

        public void draaiKaartOm()
        {
            if (huidigeFiche == null)
            {
                int index = random.Next(aantalFiches);
                huidigeFiche = fiches[index];
                fiches[index] = fiches[aantalFiches - 1];
                aantalFiches--;
                huidigeFicheImage.Source = new BitmapImage(new Uri(@"fiches\" + huidigeFiche.getImageName() + ".png", UriKind.Relative));
            }
        }

        private void voegDierenToe(string type, ref int aantalFiches)
        {
            for (int i = 0; i < 7; i++)
            {
                fiches[aantalFiches++] = new Dier(type);
            }
            fiches[aantalFiches++] = new VruchtbaarDier(type, VruchtbaarDier.Geslacht.Female);
            fiches[aantalFiches++] = new VruchtbaarDier(type, VruchtbaarDier.Geslacht.Female);
            fiches[aantalFiches++] = new VruchtbaarDier(type, VruchtbaarDier.Geslacht.Male);
            fiches[aantalFiches++] = new VruchtbaarDier(type, VruchtbaarDier.Geslacht.Male);
        }

    }
}
