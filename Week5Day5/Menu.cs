using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5Day5
{
    class Menu
    {
        internal static void Start()
        {
            bool continuare = true;

            do
            {
                Console.WriteLine("Premi 1 per visualizzare tutti gli impegni.");
                Console.WriteLine("Premi 2 per modificare un impegno.");
                Console.WriteLine("Premi 3 per eliminare un impegno.");
                Console.WriteLine("Premi 4 per inserire un nuovo impegno.");
                Console.WriteLine("Premi 5 per visualizzare gli impegni per data maggiore o uguale alla data inserita dall'utente.");
                Console.WriteLine("Premi 6 per visualizzare gli impegni per il livello di importanza inserito dall'utente.");
                Console.WriteLine("Premi 7 per visualizzare gli impegni portati a termine.");
                Console.WriteLine("Premi 8 per portare a termine un impegno.");
                Console.WriteLine("Premi 0 per uscire");
                Console.WriteLine();
                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        //Visualizza tutti gli impegni
                        Gestore.VisualizzaImpegni();
                        break;
                    case "2":
                        //Modifica impegni
                        Gestore.ModificaImpegno();                        
                        break;
                    case "3":
                        //Elimina impegni
                        Gestore.EliminaImpegno();
                        break;
                    case "4":
                        //Inserisci impegni
                        Gestore.InserisciImpegno();
                        break;
                    case "5":
                        //Visualizza impegni per data
                        Gestore.MostraImpegniPerData();
                        break;
                    case "6":
                        Gestore.MostraImpegniPerImportanza();
                        break;
                    case "7":
                        Gestore.MostraImpegniEseguiti();
                        break;
                    case "8":
                        Gestore.InsertEseguito();
                        break;
                    case "0":
                        Console.WriteLine("Ciao alla prossima");
                        continuare = false;
                        break;
                    default:
                  
                        break;
                }
            } while (continuare);
        }
    }
}
