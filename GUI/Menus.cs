using System;
using System.Collections.Generic;
using System.Threading;
using PushTaThune;
using PushTaThune.DAL;

namespace GUI
{
    public class Menus
    {
        private int RecupInputInt()
        {
            return int.Parse(Console.ReadKey().KeyChar.ToString());
        }

        private string RecupInputString()
        {
            return Console.ReadKey().KeyChar.ToString();
        }

        private DateTime EntreeDateConsole()
        {
            DateTime userDateTime;
            while (!DateTime.TryParse(Console.ReadLine(), out userDateTime)) {
                Console.WriteLine("Vous avez rentré une date invalide, reessayez...");
                EntreeDateConsole();
            }
            Console.WriteLine("Vous avez rentré la date : " + userDateTime);
            return userDateTime;
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
            keyInfo = RecupInputInt();
            if (keyInfo == 1)
            {
                Console.Clear();
                Thread.Sleep(1000);
                int IDsoiree = MenuIntermediaire();
                MenuCalcul(IDsoiree);
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

        private int MenuIntermediaire()
        {
            Console.WriteLine("############################################################################");
            Console.WriteLine("Création d'une soirée");
            Console.WriteLine();
            Console.WriteLine("Ou se déroule votre soirée ?");
            string lieu = RecupInputString();
            Console.WriteLine();
            Console.WriteLine("Très bien, mainntenant quand se passe cette soirée ? (format : jj/mm/aaaa)");
            DateTime dt = EntreeDateConsole();
            Console.WriteLine();
            Console.WriteLine("############################################################################");
            var soiree = new Soiree_DAL(lieu, dt);
            var dps = new SoireeDepot_DAL();
            soiree = dps.insert(soiree);
            return soiree.getIDSoiree;
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
            nbParticipants = RecupInputInt();
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
