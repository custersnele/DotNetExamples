using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zoo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dierentuin zooSpeler1;
        private Dierentuin zooSpeler2;
        private Transportkooi[] transportkooien = new Transportkooi[3];
        private Stapel stapel;
        private Spel spel;

        public MainWindow()
        {
            InitializeComponent();
            spel = new Spel();
            zooSpeler1 = new Dierentuin(new Canvas[] { speler1vb1, speler1vb2, speler1vb3, speler1vb4, speler1vb5 });
            zooSpeler2 = new Dierentuin(new Canvas[] { speler2vb1, speler2vb2, speler2vb3, speler2vb4, speler2vb5 });
            transportkooien[0] = new Transportkooi(transportkooi1);
            transportkooien[1] = new Transportkooi(transportkooi2);
            transportkooien[2] = new Transportkooi(transportkooi3);
            stapel = new Stapel(stapelCanvas);
            textBlock_speler1.Background = new SolidColorBrush(Colors.Yellow);


        }

        private void addTK1_Click(object sender, RoutedEventArgs e)
        {
            voegFicheToeAanTransportkooi(0);
        }

        private void voegFicheToeAanTransportkooi(int nummerTransportkooi)
        {
            disableAddButtons();
            transportkooien[nummerTransportkooi].voegFicheToe(stapel.neemKaartVanStapel());
            wisselSpeler();
        }

        private void wisselSpeler()
        {
            spel.WisselSpeler();
            if (spel.HuidigeSpeler == 1)
            {
                textBlock_speler1.Background = new SolidColorBrush(Colors.Yellow);
                textBlock_speler2.Background = new SolidColorBrush(Colors.White);
            } else
            {
                textBlock_speler1.Background = new SolidColorBrush(Colors.White);
                textBlock_speler2.Background = new SolidColorBrush(Colors.Yellow);
            }
            enableTakeButtons();
        }

        private Dierentuin getDierentuinHuidigeSpeler()
        {
            if (spel.HuidigeSpeler == 1)
            {
                return zooSpeler1;
            } else
            {
                return zooSpeler2;
            }
        }

        private void addTK2_Click(object sender, RoutedEventArgs e)
        {
            voegFicheToeAanTransportkooi(1);
            
        }

        private void addTK3_Click(object sender, RoutedEventArgs e)
        {
            voegFicheToeAanTransportkooi(2);
            
        }



        private void stapel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            stapel.draaiKaartOm();
            disableTakeButtons();
            enableAddButtons();
        }

        private void takeTransportkooi_Click(object sender, RoutedEventArgs e)
        {
            string buttonContent = ((Button)sender).Name.ToString();
            int transportkooiNummer = Convert.ToInt32(buttonContent.Substring(buttonContent.Length - 1));
            NeemTransportkooi(transportkooiNummer);
        }

        private void NeemTransportkooi(int transporkooiNummer)
        {
            spel.NeemTransportkooi();
            getDierentuinHuidigeSpeler().HandleTransportkooi(transportkooien[transporkooiNummer - 1]);
            if (spel.IsRondeVoorbij())
            {
                initTransportkooien();
                spel.StartVolgendeRonde();
            } else
            {
                wisselSpeler();
            }
        }

        private void initTransportkooien()
        {
            for (int i=0; i< transportkooien.Length; i++)
            {
                transportkooien[i].Initialiseer();
            }
        }

        private void disableTakeButtons()
        {
            takeTK1.IsEnabled = false;
            takeTK2.IsEnabled = false;
            takeTK3.IsEnabled = false;
        }

        private void enableTakeButtons()
        {
            takeTK1.IsEnabled = !transportkooien[0].isLeeg();
            takeTK2.IsEnabled = !transportkooien[1].isLeeg();
            takeTK3.IsEnabled = !transportkooien[2].isLeeg();
        }

        private void enableAddButtons()
        {
            
           addTK1.IsEnabled = !transportkooien[0].isVol();
           addTK2.IsEnabled = !transportkooien[1].isVol();
           addTK3.IsEnabled = !transportkooien[2].isVol();
          
        }

        private void disableAddButtons()
        {

            addTK1.IsEnabled = false;
            addTK2.IsEnabled = false;
            addTK3.IsEnabled = false;

        }
    }
}
