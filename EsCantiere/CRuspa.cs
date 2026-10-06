using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCantiere
{
    public class CRuspa : CMacchinari
    {
        private int dimensionebenna;
        protected int DimensioneBenna
        {
            get => dimensionebenna;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Inserisci un valore valido per la dimensione della benna");
                dimensionebenna = value;
            }
        }

        public CRuspa(string Targa, string Modello, int AnnoProduzione, float VolumeSerbatoio, bool Stato, int Cantiere, int DimensioneBenna) : base(Targa, Modello, AnnoProduzione, VolumeSerbatoio, Stato, Cantiere)
        {
            this.DimensioneBenna = DimensioneBenna;
        }

        public override string Descrizione()
        {
            string statoVeicolo = "";
            if (Stato == true)
            {
                statoVeicolo = "Libero";
            }
            else
            {
                statoVeicolo = "Occupato";
            }
            return $"Targa della ruspa: {Targa} - Modello: {Modello} - Anno di produzione: {AnnoProduzione} - Volume del serbatoio: {VolumeSerbatoio} - Stato: {statoVeicolo} - Numero di cantiere: {Cantiere} - Dimensione della benna: {DimensioneBenna}";
        }

        public string CambiaBenna(int nuovaBenna)
        {
            string testo = "";
            
            if (DimensioneBenna == nuovaBenna)
            {
                testo = "La vecchia dimensione della benna è uguale a quella nuova, non viene modificato alcun valore";
            }
            else
            {
                DimensioneBenna = nuovaBenna;
                testo += $"Benna cambiata con successo \n Nuova dimensione della benna: {nuovaBenna}";
            }
        
            return testo;
        }
    }
}