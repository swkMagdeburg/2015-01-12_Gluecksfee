using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Gluecksfee.Core;
using Gluecksfee.Infrastructure;

namespace Gluecksfee.UI.Cmd
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var ermittleGewinner = new ErmittleGewinnerViewModel(new SpielerRepository());
            var rundenNummer = 0;

            while (ermittleGewinner.Gewinner == null)
            {
                rundenNummer += 1;
                Console.WriteLine("Runde {0}", rundenNummer);
                SpielerAusgeben(ermittleGewinner.Spieler);

                Console.WriteLine("Lose Spiele aus");
                Console.ReadKey();
                ermittleGewinner.LoseSpieleAus.Execute(null);
                SpieleAusgeben(ermittleGewinner.Spiele);

                Console.WriteLine("Simuliere Spiele");
                Console.ReadKey();
                ermittleGewinner.SimuliereSpiele.Execute(null);
                SpieleAusgeben(ermittleGewinner.Spiele);

                Console.WriteLine("Entferne Verlierer");
                Console.ReadKey();
                ermittleGewinner.EntferneVerlierer.Execute(null);
            }

            Console.WriteLine("Herzlichen Glückwunsch {0} {1}! Du hast gewonnen!", ermittleGewinner.Gewinner.Vorname, ermittleGewinner.Gewinner.Nachname);
            Console.ReadKey();
        }

        private static void SpielerAusgeben(IEnumerable<Spieler> spieler)
        {
            Console.WriteLine("Spieler:");
            spieler.ToList().ForEach(s => Console.WriteLine("\t{0} {1}", s.Vorname, s.Nachname));
        }

        private static void SpieleAusgeben(ObservableCollection<Spiel> spiele)
        {
            Console.WriteLine("Spiele:");
            spiele.ToList().ForEach(s =>
            {
                var defaultColor = Console.ForegroundColor;

                Console.ForegroundColor = s.Gewinner == s.HeimSpieler ? ConsoleColor.Green : ConsoleColor.White;
                Console.Write("\t{0} {1}", s.HeimSpieler.Vorname, s.HeimSpieler.Nachname);

                Console.SetCursorPosition(35, Console.CursorTop);
                Console.ForegroundColor = defaultColor;
                Console.Write("VS.");

                Console.ForegroundColor = s.Gewinner == s.GastSpieler ? ConsoleColor.Green : ConsoleColor.White;
                Console.WriteLine("\t{0} {1}", s.GastSpieler.Vorname, s.GastSpieler.Nachname);

                Console.ForegroundColor = defaultColor;
            });
        }
    }
}