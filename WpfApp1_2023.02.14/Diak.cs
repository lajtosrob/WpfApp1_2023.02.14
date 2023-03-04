using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1_2023._02._14
{
    public class Diak
    {
        //rejtett attribútumok (adatok)
        private string neve;
        private int magassag;
        private bool neme; // true - férfi, false - nő
        private List<double> sulyMeresek = new List<double>();

        //tulajdonságok (properties)
        public string Neve { get => neve; }
        public int Magassag { get => magassag; }
        public string Neme { get => neme ? "Férfi" : "Nő"; }

        //Metódusok
        public double MagassagInchben()
        {
            return magassag / 2.54;
        }

        public void SulyMeres(double mertSuly)
        {
            sulyMeresek.Add(mertSuly);
        }

        public int MeresekSzama()
        {
            return sulyMeresek.Count;
        }

        //Konstruktorok
        public Diak(string neve, bool neme)
        {
            this.neve = neve;
            this.neme = neme;
        }

        public Diak(string neve, bool neme, int magassag)
        {
            this.neve = neve;
            this.neme = neme;
            this.magassag = magassag;
        }

    }
}
