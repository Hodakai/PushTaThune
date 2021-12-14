using System;
using System.Collections.Generic;
using System.Threading;
using PushTaThune;
using PushTaThune.DAL;

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
                var soiree = new Soiree_DAL
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

        private void MenuCalcul (int IDsoiree)
        {
            #region ETAPE 1

            int nbParticipants;
            List<Participant_DAL> participants = new List<Participant_DAL>();
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
                var p = new Participant_DAL(Console.ReadLine().ToString(), IDsoiree);
                participants.Add(p);
                Console.WriteLine("Utilisateur : " + participants[i].getNom + " rentré avec succès !");
            }
            Console.WriteLine("Tous les utilisateurs ont été rentrés !");
            Console.WriteLine("############################################################################");
            Thread.Sleep(2000);

            #endregion

            Console.Clear();

            #region ETAPE 2

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

            #endregion
        }
    }
}
