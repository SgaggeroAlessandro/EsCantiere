using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCantiere
{
    public abstract class CMacchinari : IAssegnabile
    {
        public string Targa { get; protected set; }
        public string Modello { get; protected set; }

        public int AnnoProduzione {  get; protected set; }
        public float VolumeSerbatoio {  get; protected set; }
        public bool Stato {  get; protected set; }
        public int Cantiere {  get; protected set; }

        public CMacchinari(string Targa, string Modello, int AnnoProduzione, float VolumeSerbatoio, bool Stato, int Cantiere)
        {
            this.Targa = Targa;
            this.Modello = Modello;
            this.AnnoProduzione = AnnoProduzione;
            this.VolumeSerbatoio = VolumeSerbatoio;
            this.Stato = Stato;
            this.Cantiere = Cantiere;
        }

        public abstract string Descrizione();

        public void AssegnaCantiere(int cantiere)
        {
            Cantiere = cantiere;
            Stato = false;
        }

        public void LiberaCantiere()
        {
            Stato = true;
            Cantiere = 0;
        }
    }
}
