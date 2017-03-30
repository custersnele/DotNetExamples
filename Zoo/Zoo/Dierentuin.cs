using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static Zoo.Dier;

namespace Zoo
{
    class Dierentuin
    {
        private Dierenverblijf[] dierenverblijven;
        private TijdelijkDierenverblijf tijdelijkVerblijf;
        private IList<Dier> tijdelijkTransport = new List<Dier>();
        public const int MAX_DIERENVERBLIJVEN = 5;
        private int aantalDierenverblijven = 3;
        private int geld = 0;

        public Dierentuin(Canvas[] verblijfCanvas)
        {
            dierenverblijven = new Dierenverblijf[5];
            dierenverblijven[0] = new Dierenverblijf(5, 2, true, verblijfCanvas[0]);
            dierenverblijven[1] = new Dierenverblijf(4, 1, true, verblijfCanvas[1]);
            dierenverblijven[2] = new Dierenverblijf(6, 1, true, verblijfCanvas[2]);
            dierenverblijven[3] = new Dierenverblijf(5, 1, false, verblijfCanvas[3]);
            dierenverblijven[4] = new Dierenverblijf(5, 1, false, verblijfCanvas[4]);
            tijdelijkVerblijf = new TijdelijkDierenverblijf(); 
        }

        public void HandleTransportkooi(Transportkooi transportkooi)
        {
            while (!transportkooi.isLeeg())
            {
                TransportFiche fiche = transportkooi.neemFiche();
                if (fiche is Dier)
                {
                    Dier dierFiche = (Dier)fiche;
                    Dierenverblijf verblijf = FindDierenverblijf(dierFiche.Soort);
                    if (verblijf == null)
                    {
                        verblijf = FindLeegDierenverblijf();
                    }
                    if (verblijf == null)
                    {
                        tijdelijkTransport.Add(dierFiche);
                    } else
                    {
                        verblijf.VoegDierToe(dierFiche);
                    }
                } else if (fiche is Munt)
                {
                    geld++;
                } else if (fiche is Attractie)
                {
                    Dierenverblijf dierenverblijf = FindDierenverblijfVoorAttractie();
                    if (dierenverblijf != null)
                    {
                        dierenverblijf.VoegAttractieToe((Attractie)fiche);
                    }
                }
            }
           
        }

        private Dierenverblijf FindDierenverblijf(DierSoort soort)
        {
            for (int i =0; i< dierenverblijven.Length; i++)
            {
                if (dierenverblijven[i].DierSoort == soort && 
                    !dierenverblijven[i].IsVol())
                {
                    return dierenverblijven[i];
                }
            }
            return null;
        }

        private Dierenverblijf FindDierenverblijfVoorAttractie()
        {
            Dierenverblijf dierenverblijf = null;
            int aantalDieren = 0;
            for (int i = 0; i < dierenverblijven.Length; i++)
            {
                if (dierenverblijven[i].HeeftPlaatsVoorAttractie() &&
                    dierenverblijven[i].AantalDieren > aantalDieren)
                {
                    dierenverblijf = dierenverblijven[i];
                    aantalDieren = dierenverblijven[i].AantalDieren;
                }
            }
            return dierenverblijf;
        }

        private Dierenverblijf FindLeegDierenverblijf()
        {
            for (int i = 0; i < dierenverblijven.Length; i++)
            {
                if (dierenverblijven[i].IsLeeg() && dierenverblijven[i].IsOpen)
                {
                    return dierenverblijven[i];
                }
            }
            return null;
        }
    }
}
