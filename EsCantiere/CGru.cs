using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCantiere
{
    public class CGru : CMacchinari
    {
        private int portatamassima;
        private int altezzalavoro;

        protected int PortataMassima
        {
            get => portatamassima;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("La portata massima deve essere maggiore di 0");
                portatamassima = value;
            }
        }

        public int AltezzaLavoro
        {
            get => altezzalavoro;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("L'altezza di lavoro deve essere maggiore di 0");
                altezzalavoro = value;
            }
        }

        public CGru(string Targa, string Modello, int AnnoProduzione, float VolumeSerbatoio, bool Stato, int Cantiere, int PortataMassima, int AltezzaLavoro) : base(Targa, Modello, AnnoProduzione, VolumeSerbatoio, Stato, Cantiere)
        {
            this.PortataMassima = PortataMassima;
            this.AltezzaLavoro = AltezzaLavoro;
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

            return $"Targa della gru: {Targa} - Modello: {Modello} - Anno di produzione: {AnnoProduzione} - Volume del serbatoio: {VolumeSerbatoio} - Stato: {statoVeicolo} - Numero di cantiere: {Cantiere} - Portata massima della gru: {PortataMassima} - Altezza di lavoro: {AltezzaLavoro}";
        }

        public int AumentaAltezza()
        {
             AltezzaLavoro++;
            return AltezzaLavoro;
        }

        public int DiminuisciAltezza()
        {
            if (AltezzaLavoro >= 2)
            {
                AltezzaLavoro--;
            }
            return AltezzaLavoro;
            
        }
    }

    }

