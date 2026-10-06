using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCantiere
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<CMacchinari> Macchinari = new List<CMacchinari>();
            int scelta;
            do
            {
                do
                {
                    Console.WriteLine("Scrivi il numero relativo alla funzione che si vuole chiamare:");
                    Console.WriteLine("\t1. Visualizzare tutti i macchinari presenti nel parcheggio\n" +
                        "\t2. Visualizzare la descrizione completa di ogni macchinario\n" +
                        "\t3. Assegnare un macchinario a un cantiere\n" +
                        "\t4. Liberare un macchinario da un cantiere\n" +
                        "\t5. Utilizzare le operazioni specifiche del macchinario\n" +
                        "\t6. Inserire un nuovo macchinario\n" +
                        "\t7. Fine del programma\n");
                    Console.Write("Numero: ");
                } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 7);

                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("E' stato scelto di visualizzare tutti i macchinari presenti nel parcheggio");
                        VisualizzaParcheggio(Macchinari);
                        break;
                    case 2:
                        Console.WriteLine("E' stato scelto di visualizzare la descrizione completa di ogni singolo macchinario");
                        VisualizzaMacchinari(Macchinari);
                        break;
                    case 3:
                        Console.WriteLine("E' stato scelto di assegnare un macchinario ad un cantiere");
                        AssegnaMacchinario(Macchinari);
                        break;
                    case 4:
                        Console.WriteLine("E' stato scelto di liberare un macchinario da un cantiere");
                        LiberaMacchinario(Macchinari);
                        break;
                    case 5:
                        Console.WriteLine("E' stato scelto di utilizzare le operazioni specifiche del macchinario");
                        OperazioniSpecifiche(Macchinari);
                        break;
                    case 6:
                        Console.WriteLine("E' stato scelto di aggiungere un nuovo macchinario");
                        AggiungiMacchinario(Macchinari);
                        break;
                    case 7:
                        Console.WriteLine("E' stato scelto di terminare il programma");
                        break;
                }

            } while (scelta != 7);



        }


        public static void VisualizzaParcheggio(List<CMacchinari> macchinari)
        {
            Console.WriteLine("Macchinari presenti nel parcheggio:");
            if (macchinari.Count == 0)
            {
                Console.WriteLine("Nessun macchinario presente nel parcheggio");
            }
            foreach (CMacchinari m in macchinari)
            {
                if (m.Stato == true)
                {
                    Console.WriteLine(m.Descrizione());
                }

            }
        }

        public static void VisualizzaMacchinari(List<CMacchinari> macchinari)
        {
            if (macchinari.Count == 0)
            {
                Console.WriteLine("Nessun macchinario presente");
            }
            foreach (CMacchinari m in macchinari)
            {
                Console.WriteLine(m.Descrizione());
            }
        }

        public static void AssegnaMacchinario(List<CMacchinari> macchinari)
        {
            Console.WriteLine("\n");

            Console.WriteLine("Se vuoi assegnare ad un altro cantiere un macchinario già in uso, prima devi liberarlo");

            Console.WriteLine("\n");
            List<CMacchinari> macchinariDisponibili = new List<CMacchinari>();
            if (macchinari.Count == 0)
            {
                Console.WriteLine("Nessun macchinario presente, quindi non ci sono macchinari da assegnare ad un cantiere");
                return;
            }
            foreach (CMacchinari m in macchinari)
            {
                if (m.Stato == true)
                {
                    macchinariDisponibili.Add(m);
                }
            }

            if (macchinariDisponibili.Count == 0)
            {
                Console.WriteLine("Non ci sono macchinari disponibili in questo momento");
                return;
            }

            Console.WriteLine("Scegli il macchinario da assegnare");
            for (int i = 0; i < macchinariDisponibili.Count; i++)
            {
                Console.WriteLine($"\t{i + 1}. Targa: {macchinariDisponibili[i].Targa} - Modello: {macchinariDisponibili[i].Modello}");
            }


            int sceltaMezzo;
            do
            {
                Console.WriteLine("Inserisci il numero del macchinario");
            } while (!int.TryParse(Console.ReadLine(), out sceltaMezzo) || sceltaMezzo < 1 || sceltaMezzo > macchinariDisponibili.Count);

            CMacchinari macchinario = macchinariDisponibili[sceltaMezzo - 1];

            int numeroCantiere;
            do
            {
                Console.WriteLine("Inserisci il numero del cantiere");
            } while (!int.TryParse(Console.ReadLine(), out numeroCantiere) || numeroCantiere <= 0);

            macchinario.AssegnaCantiere(numeroCantiere);
            Console.WriteLine($"Il macchinario è stato assegnato al cantiere numero: {numeroCantiere}");


        }

        public static void LiberaMacchinario(List<CMacchinari> macchinari)
        {
            List<CMacchinari> macchinariOccupati = new List<CMacchinari>();
            if (macchinari.Count == 0)
            {
                Console.WriteLine("Nessun macchinario presente, quindi non ci sono macchinari da liberare da un cantiere");
                return;
            }
            foreach (CMacchinari m in macchinari)
            {
                if (m.Stato == false)
                {
                    macchinariOccupati.Add(m);
                }
            }

            if (macchinariOccupati.Count == 0)
            {
                Console.WriteLine("Non ci sono macchinari occupati in questo momento");
                return;
            }

            Console.WriteLine("Scegli il macchinario da liberare");
            for (int i = 0; i < macchinariOccupati.Count; i++)
            {
                Console.WriteLine($"\t{i + 1}. Targa: {macchinariOccupati[i].Targa} - Modello: {macchinariOccupati[i].Modello}");
            }


            int sceltaMezzo;
            do
            {
                Console.WriteLine("Inserisci il numero del macchinario");
            } while (!int.TryParse(Console.ReadLine(), out sceltaMezzo) || sceltaMezzo < 1 || sceltaMezzo > macchinariOccupati.Count);

            CMacchinari macchinario = macchinariOccupati[sceltaMezzo - 1];



            macchinario.LiberaCantiere();
            Console.WriteLine("Il macchinario è stato liberato con successo");
        }

        public static void AggiungiMacchinario(List<CMacchinari> macchinari)
        {
            int tipoMacchinario;
            do
            {
                Console.WriteLine("Scrivi il numero corrispondente al tipo di macchinario che si vuole aggiungere al parcheggio\n" +
                    "\t1. Ruspa\n" +
                    "\t2. Gru\n" +
                    "\t3. Betoniera");
            } while (!int.TryParse(Console.ReadLine(), out tipoMacchinario) || tipoMacchinario < 1 || tipoMacchinario > 3);

            string targa;
            do
            {
                Console.WriteLine("Scrivi il numero di targa del veicolo");
                targa = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(targa));
            string modello;
            do
            {
                Console.WriteLine("Scrivi il modello del veicolo");
                modello = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(modello));

            int annoProduzione;
            do
            {
                Console.WriteLine("Scrivi l'anno in cui è stato prodotto il veicolo");

            } while (!int.TryParse(Console.ReadLine(), out annoProduzione) || annoProduzione > DateTime.Now.Year);

            float VolumeSerbatoio;
            do
            {
                Console.WriteLine("Scrivi il volume del serbatoio del veicolo");
            } while (!float.TryParse(Console.ReadLine(), out VolumeSerbatoio) || VolumeSerbatoio <= 0);

            string statoString;
            do
            {
                Console.WriteLine("E' libero il macchinario? (Sì/No)");
                statoString = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(statoString) || (statoString.ToLower() != "sì" && statoString.ToLower() != "si" && statoString.ToLower() != "no"));

            bool stato = false;
            if (statoString.ToLower() == "no")
            {
                stato = false;
            }
            else
            {
                stato = true;
            }
            int Cantiere;
            do
            {
                Console.WriteLine("Scrivi il numero del cantiere del macchinario");
            } while (!int.TryParse(Console.ReadLine(), out Cantiere) || Cantiere <= 0);
            if (tipoMacchinario == 1)
            {
                int dimensioneBenna;
                do
                {
                    Console.WriteLine("Scrivi la dimensione della benna della ruspa, puoi scegliere tra:" +
                        "300 \t 500 \t 700 \t 1000 \t 1500 \t 2000");
                } while (!int.TryParse(Console.ReadLine(), out dimensioneBenna) || (dimensioneBenna != 300 && dimensioneBenna != 500 && dimensioneBenna != 700 && dimensioneBenna != 1000 && dimensioneBenna != 1500 && dimensioneBenna != 2000));

                CRuspa ruspa = new CRuspa(targa, modello, annoProduzione, VolumeSerbatoio, stato, Cantiere, dimensioneBenna);
                Console.WriteLine(ruspa.Descrizione());
                macchinari.Add(ruspa);
            }
            else if (tipoMacchinario == 2)
            {
                int portataMassima;
                do
                {
                    Console.WriteLine("Scrivi la portata massima della gru");
                } while (!int.TryParse(Console.ReadLine(), out portataMassima) || portataMassima <= 0);

                int altezzaLavoro;
                do
                {
                    Console.WriteLine("Scrivi l'altezza di lavoro della gru");
                } while (!int.TryParse(Console.ReadLine(), out altezzaLavoro) || altezzaLavoro <= 0);
                CGru gru = new CGru(targa, modello, annoProduzione, VolumeSerbatoio, stato, Cantiere, portataMassima, altezzaLavoro);
                macchinari.Add(gru);
                Console.WriteLine("Gru aggiunta con successo");
                Console.WriteLine(gru.Descrizione());
            }
            else
            {
                int capacitàMassima;
                do
                {
                    Console.WriteLine("Inserisci la capacità massima della betoniera");
                } while (!int.TryParse(Console.ReadLine(), out capacitàMassima) || capacitàMassima <= 0);

                CBetoniera betoniera = new CBetoniera(targa, modello, annoProduzione, VolumeSerbatoio, stato, Cantiere, capacitàMassima);
                macchinari.Add(betoniera);
                Console.WriteLine("Betoniera aggiunta con successo");
                Console.WriteLine(betoniera.Descrizione());
            }
        }

        public static void OperazioniSpecifiche(List<CMacchinari> macchinari)
        {
            if (macchinari.Count == 0)
            {
                Console.WriteLine("Non ci sono macchinari al momento, aggiungine uno per poter iniziare a fare le operazioni specifiche");
                return;
            }
            Console.WriteLine("Scegli il macchinario da assegnare");
            for (int i = 0; i < macchinari.Count; i++)
            {
                Console.WriteLine($"\t{i + 1}. Targa: {macchinari[i].Targa} - Modello: {macchinari[i].Modello}");
            }


            int sceltaMezzo;
            do
            {
                Console.WriteLine("Inserisci il numero del macchinario");
            } while (!int.TryParse(Console.ReadLine(), out sceltaMezzo) || sceltaMezzo < 1 || sceltaMezzo > macchinari.Count);

            CMacchinari macchinario = macchinari[sceltaMezzo - 1];

            if (macchinario is CRuspa ruspa)
            {
                Console.WriteLine("Dimensioni disponibili della benna: \n \t 300 \t 500 \t 700 \t 1000 \t 1500 \t 2000");
                int nuovaBenna;
                do
                {
                    Console.WriteLine("Inserisci la nuova dimensione della benna");
                } while (!int.TryParse(Console.ReadLine(), out nuovaBenna) || (nuovaBenna != 300 && nuovaBenna != 500 && nuovaBenna != 700 && nuovaBenna != 1000 && nuovaBenna != 1500 && nuovaBenna != 2000));


                ruspa.CambiaBenna(nuovaBenna);
                Console.WriteLine($"Benna cambiata, dimensione della nuova benna: {nuovaBenna}");
            }
            else if (macchinario is CGru gru)
            {
                Console.WriteLine("Operazioni specifiche per la gru:");
                Console.WriteLine("\t1. Aumenta altezza di un metro\n" +
                    "\t2. Diminuisci l'altezza di un metro\n" +
                    "\t3.Visualizza altezza attuale");

                int scelta;
                do
                {
                    Console.WriteLine("Scrivi il numero corrispondente alla funzione che si vuole svolgere");
                } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 3);

                switch (scelta)
                {
                    case 1:
                        gru.AumentaAltezza();
                        Console.WriteLine($"Altezza attuale: {gru.AltezzaLavoro}");
                        break;
                    case 2:
                        gru.DiminuisciAltezza();
                        Console.WriteLine($"Altezza attuale: {gru.AltezzaLavoro}");
                        break;
                    case 3:
                        Console.WriteLine($"Altezza attuale: {gru.AltezzaLavoro}");
                        break;

                }
            }
            else if (macchinario is CBetoniera betoniera)
            {
                Console.WriteLine("Operazioni disponibili per la betoniera");
                Console.WriteLine("\t1. Carica cemento\n" +
                    "\t2. Versa cemento\n" +
                    "\t3. Visualizza quantità attuale");

                int scelta;
                do
                {
                    Console.WriteLine("Inserisci il numero relativo alla funzione da svolgere");
                } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 3);

                switch (scelta)
                {
                    case 1:
                        int quantità;
                        do
                        {
                            Console.WriteLine("Inserisci la quantità di cemento da caricare");
                        } while (!int.TryParse(Console.ReadLine(), out quantità) || quantità <= 0);

                        betoniera.CaricaCemento(quantità);
                        Console.WriteLine($"Nuova quantità: {betoniera.QuantitaAttuale}");
                        break;
                    case 2:
                        int quantitàVersare;
                        do
                        {
                            Console.WriteLine("Inserisci la quantità di cemento da versare");
                        } while (!int.TryParse(Console.ReadLine(), out quantitàVersare) || quantitàVersare <= 0);

                        betoniera.VersaCemento(quantitàVersare);
                        Console.WriteLine($"Nuova quantità: {betoniera.QuantitaAttuale}");
                        break;
                    case 3:
                        Console.WriteLine($"Quantità attuale: {betoniera.QuantitaAttuale}");
                        break;
                }
            }
        }





    }
}
