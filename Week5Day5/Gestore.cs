using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5Day5
{
    class Gestore
    {
        //Repository database
         static ImpegniAdoRepository impegnoRepository = new ImpegniAdoRepository();
       
        //Repository lista statica
     //   static ImpegniListRepository impegnoRepository = new ImpegniListRepository();

        // Visualizza
        internal static void VisualizzaImpegni()
        {
            List<Impegno> agenda = impegnoRepository.Fetch();

            foreach (var impegno in agenda)
            {
                impegno.PrintInfo();
                Console.WriteLine();
            }
          
        }

        // Modifica

        internal static void ModificaImpegno()
        {
            Impegno impegno = SceltaImpegno(); 

         

                Console.WriteLine("Nel seguito digita 'si' per la modifica altrimenti digita 'no'");
                Console.WriteLine("");

                if (impegno.Id == null)
                {
                    impegnoRepository.Delete(impegno);
                }

                bool continuare = true;
                string risposta;
                do
                {
                    Console.WriteLine("Vuoi modificare il titolo? ");
                    risposta = Console.ReadLine();
                    if (risposta == "si" || risposta == "no")
                        continuare = false;
                } while (continuare);
                if (risposta == "si")
                {
                    impegno.Titolo = InsertTitolo();
                }

                do
                {
                    Console.WriteLine("Vuoi modificare la descrizione?");
                    risposta = Console.ReadLine();
                    if (risposta == "si" || risposta == "no")
                        continuare = false;
                } while (continuare);
                if (risposta == "si")
                {
                    impegno.Descrizione = InsertDescrizione();
                }

                do
                {
                    Console.WriteLine("Vuoi modificare la data di scadenza?");
                    risposta = Console.ReadLine();
                    if (risposta == "si" || risposta == "no")
                        continuare = false;
                } while (continuare);
                if (risposta == "si")
                {
                    impegno.DataDiScadenza = InsertDataDiScadenza();
                }

                do
                {
                    Console.WriteLine("Vuoi modificare l'importanza?");
                    risposta = Console.ReadLine();
                    if (risposta == "si" || risposta == "no")
                        continuare = false;
                } while (continuare);
                if (risposta == "si")
                {
                    impegno.Importanza = InsertImportanza();
                }
            if (impegno.Eseguito == false)
            {
                do
                {
                    Console.WriteLine("Hai eseguito l'impegno?");
                    risposta = Console.ReadLine();
                    if (risposta == "si" || risposta == "no")
                        continuare = false;
                } while (continuare);
                if (risposta == "si")
                {
                    impegno.Eseguito = true;
                }
            }

                impegnoRepository.Update(impegno);
          
        }

        internal static Impegno SceltaImpegno()
        {
            List<Impegno> agenda = impegnoRepository.Fetch();
            int i = 1;
            foreach (var imp in agenda)
            {
                Console.WriteLine($"Premi {i} per selezionare l'impegno:");
                imp.PrintInfo();
                Console.WriteLine("");
                i++;
            }

            int impegnoScelto;
            do
            {
                Console.WriteLine("Quale impegno?");

            } while (!int.TryParse(Console.ReadLine(), out impegnoScelto) || impegnoScelto <= 0 || impegnoScelto > agenda.Count);

            Impegno impegno = agenda.ElementAt(impegnoScelto - 1);

            Console.WriteLine("Hai selezionato.");
            impegno.PrintInfo();
            Console.WriteLine("");
            return impegno;
        }
        internal static void InsertEseguito()
        {
            List<Impegno> agenda = impegnoRepository.Fetch();
            int i = 1;
            int controllo = 0;
            foreach (var imp in agenda)
            {
                if (imp.Eseguito == false)
                {
                    Console.WriteLine($"Premi {i} per selezionare l'impegno:");
                    imp.PrintInfo();
                    Console.WriteLine("");
                     i++;
                    controllo = 1;
                }
            }
            if (controllo != 0)
            {
                int impegnoScelto;
                do
                {
                    Console.WriteLine("Quale impegno?");

                } while (!int.TryParse(Console.ReadLine(), out impegnoScelto) || impegnoScelto <= 0 || impegnoScelto > agenda.Count);

                Impegno impegno = agenda.ElementAt(impegnoScelto - 1);

                Console.WriteLine("Hai selezionato.");
                impegno.PrintInfo();
                Console.WriteLine("");
                impegno.Eseguito = true;
                impegnoRepository.Update(impegno);
            }
        
        }

        private static Livello InsertImportanza()
        {
            int importanza = 0;
            do
            {
                Console.WriteLine("Inserisci il livello di importanza dell'impegno.");
                foreach (var livello in Enum.GetValues(typeof(Livello)))
                {
                    Console.WriteLine($"Premi {(int)livello} per {(Livello)livello}");
                }

            } while (!int.TryParse(Console.ReadLine(), out importanza) || importanza < 0 || importanza > 2);
            return (Livello)importanza;
        }

        private static DateTime InsertDataDiScadenza()
        {
            Console.WriteLine("Inserisci una data di scadenza successiva ad oggi.");
            DateTime data;
            while (!DateTime.TryParse(Console.ReadLine(), out data) || data < DateTime.Today)
            {
                Console.WriteLine("Inserisci una data valida.");
            }
            return data;
        }

        private static string InsertDescrizione()
        {
            string descrizione = String.Empty;
            do
            {
                Console.WriteLine("Inserisci descrizione.");
                descrizione = Console.ReadLine();

            } while (String.IsNullOrEmpty(descrizione));
            return descrizione;
        }

        private static string InsertTitolo()
        {
            string titolo = String.Empty;
            do
            {
                Console.WriteLine("Inserisci titolo.");
                titolo = Console.ReadLine();

            } while (String.IsNullOrEmpty(titolo));
            return titolo;
        }

        //Elimina
        internal static void EliminaImpegno()
        {
            Impegno impegno = SceltaImpegno();
            impegnoRepository.Delete(impegno);
        }

        //Inserisci

        internal static void InserisciImpegno()
        {
           
            Impegno impegno = new Impegno();
            impegno.Titolo = InsertTitolo();
            impegno.Descrizione = InsertDescrizione();
            impegno.DataDiScadenza = InsertDataDiScadenza();
            impegno.Importanza = InsertImportanza();
            impegno.Eseguito = false;
            impegnoRepository.Insert(impegno);
        }

        internal static void MostraImpegniPerData()
        {
            DateTime data = InsertDataDiScadenza();
            List<Impegno> agenda = impegnoRepository.GetImpegniPerData(data);
            foreach (var impegno in agenda)
                impegno.PrintInfo();
        }

        internal static void MostraImpegniPerImportanza()
        {
            Livello importanza = InsertImportanza();
            List<Impegno> agenda = impegnoRepository.GetImpegniImportanza(importanza);
            foreach (var impegno in agenda)
                impegno.PrintInfo();
        }

        internal static void MostraImpegniEseguiti()
        {

            List<Impegno> agenda = impegnoRepository.GetEseguiti();
            foreach (var impegno in agenda)
                impegno.PrintInfo();
        }


    }

}
