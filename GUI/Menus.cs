using System;
using System.Threading;

namespace GUI
{
    public class Menus
    {
        public void MenuPrincipal ()
        {
            ConsoleKeyInfo sheesh;
            Console.WriteLine("############################################################################");
            Console.WriteLine("                         / Welcome to PushTaThune /");
            Console.WriteLine();
            Console.WriteLine("                           Que voulez vous faire ?");
            Console.WriteLine();
            Console.WriteLine("1 - Calculer le remboursement d'une soirée");
            Console.WriteLine("2 - Quitter");
            Console.WriteLine();
            Console.WriteLine("############################################################################");
            sheesh = Console.ReadKey();
            if (sheesh.Key == ConsoleKey.D1)
            {
                Console.Clear();
                // TODO Mettre une fonction call dans une autre biblio de classe qui permet de gérer ce qui ce passe après
                Console.WriteLine("Vous avez choisi l'option 1 !");
            }
            else if (sheesh.Key == ConsoleKey.D2)
            {
                Console.Clear();
                Console.WriteLine("Merci d'avoir utilisé PushTaThune !");
                Console.WriteLine("A bientôt <3");
            }
            else
            {
                Console.Clear();
                Console.Write("Veuillez rentrer une option valide, réessayez");
                Console.Write(".");
                Thread.Sleep(750);
                Console.Write(".");
                Thread.Sleep(750);
                Console.Write(".");
                Thread.Sleep(750);
                Console.Clear();
                MenuPrincipal();
            }
        }
    }
}
