using System;
using System.Collections.Generic;
using System.Threading;
using PushTaThune;

namespace GUI
{
    public class Menus
    {
        public void MenuPrincipal ()
        {
            ConsoleKeyInfo keyInfo;
            Console.WriteLine("############################################################################");
            Console.WriteLine("                         / Welcome to PushTaThune /");
            Console.WriteLine();
            Console.WriteLine("                           Que voulez vous faire ?");
            Console.WriteLine();
            Console.WriteLine("1 - Calculer le remboursement d'une soirée");
            Console.WriteLine("2 - Quitter");
            Console.WriteLine();
            Console.WriteLine("############################################################################");
            keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.D1)
            {
                Console.Clear();
                MenuCalcul();
            }
            else if (keyInfo.Key == ConsoleKey.D2)
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
        private void MenuCalcul ()
        {
            int nbParticipants;
            List<string> participants = new List<string>();
            Console.WriteLine("############################################################################");
            Console.WriteLine("                         Etape 1 - Les participants");
            Console.WriteLine();
            Console.WriteLine("Combien de participants font partie du calcul : ");
            nbParticipants = int.Parse(Console.ReadKey().KeyChar.ToString());
            Console.WriteLine();
            Console.WriteLine("Très bien, maintenant comment s'appellent ils ?");
            for (int i = 0; i < nbParticipants; i++)
            {
                Console.WriteLine();
                participants.Add(Console.ReadLine().ToString());
                Console.WriteLine("Utilisateur : " + participants[i] + " rentré avec succès !");
            }
            Console.WriteLine("Tous les utilisateurs ont été rentrés !");
            Console.WriteLine("############################################################################");
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("############################################################################");
            Console.WriteLine("                      Etape 2 - Qui à donné combien ?");
            // TODO Faire le menu pour demander qui à donné combien d'argent
            Console.WriteLine();
            for (int i = 0; i < participants.Count; i++)
            {
                Console.WriteLine("Entrez");
            }
            Console.WriteLine();
            Console.WriteLine("############################################################################");
        }
    }
}
