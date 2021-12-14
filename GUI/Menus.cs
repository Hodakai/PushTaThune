using System;
using System.Collections.Generic;
using System.Threading;
using PushTaThune;

namespace GUI
{
    public class Menus
    {
        private int RecupInput()
        {
            return int.Parse(Console.ReadKey().KeyChar.ToString());
        }

        public void MenuPrincipal ()
        {
            int keyInfo;
            Console.WriteLine("############################################################################");
            Console.WriteLine("                         / Welcome to PushTaThune /");
            Console.WriteLine();
            Console.WriteLine("                           Que voulez vous faire ?");
            Console.WriteLine();
            Console.WriteLine("1 - Calculer le remboursement d'une soirée");
            Console.WriteLine("2 - Quitter");
            Console.WriteLine();
            Console.WriteLine("############################################################################");
            keyInfo = RecupInput();
            if (keyInfo == 1)
            {
                Console.Clear();
                MenuCalcul();
            }
            else if (keyInfo == 2)
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
            nbParticipants = RecupInput();
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
