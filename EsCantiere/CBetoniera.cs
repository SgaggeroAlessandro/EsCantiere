using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCantiere
{
    public class CBetoniera : CMacchinari
    {
        private int capacitamassima;
        private int quantitaattuale;

        protected int CapacitaMassima
        {
            get => capacitamassima;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("La capacità massima deve essere positiva");
                capacitamassima = value;
            }
        }

        public int QuantitaAttuale
        {
            get => quantitaattuale;
            set
            {
                if (value < 0)
                    throw new ArgumentException("La quantità attuale può partire al massimo da 0");
                quantitaattuale = value;
            }
        }
        public CBetoniera(string Targa, string Modello, int AnnoProduzione, float VolumeSerbatoio, bool Stato, int Cantiere, int CapacitaMassima) : base(Targa, Modello, AnnoProduzione, VolumeSerbatoio, Stato, Cantiere)
        {
            this.CapacitaMassima = CapacitaMassima;
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
            return $"Targa della betoniera: {Targa} - Modello: {Modello} - Anno di produzione: {AnnoProduzione} - Volume del serbatoio: {VolumeSerbatoio} - Stato: {statoVeicolo} - Numero di cantiere: {Cantiere} - Capacità Massima: {CapacitaMassima} - Quantità attuale: {QuantitaAttuale}";
        }


        public int CaricaCemento(int quantita)
        {
            if(QuantitaAttuale + quantita > CapacitaMassima)
            {
                QuantitaAttuale = CapacitaMassima;
            }
            else
            {
                QuantitaAttuale += quantita;
            }


            return QuantitaAttuale;
        }

        public int VersaCemento(int quantita)
        {

            if(quantita > QuantitaAttuale)
            {
                QuantitaAttuale = 0;
            }
            else
            {

                QuantitaAttuale -= quantita;
            }
            

            return QuantitaAttuale;
        }


    }
}
