using System;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;
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
            return Console.ReadLine().ToString();
        }

        /*private void Chargement()
        {
            bool sheesh = false;
            while (!sheesh)
            {
                Console.Clear();
                Console.WriteLine("############################################################################");
                Console.WriteLine();
                Console.WriteLine("                                Chargement");
                Console.WriteLine();
                Console.WriteLine("");
                Console.WriteLine();
                Console.WriteLine("############################################################################");
                Thread.Sleep(500);
                Console.Clear();
            }
        }*/

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

        private DateTime DateTimeParse()
        {
            List<int> dateNombres = new List<int>();
            Console.WriteLine("Très bien, mainntenant quand se passe cette soirée ? (format : jj/mm/aaaa)");
            string dateStr = Console.ReadLine();
            string[] nbrs = dateStr.Split('/');
            foreach (var nbr in nbrs)
            {
                try
                {
                    int result = Int32.Parse(nbr);
                    dateNombres.Add(result);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Ne peut pas parser : '{nbr}'");
                }
            }
            var dt = $"{dateNombres[0]}/{dateNombres[1]}/{dateNombres[2]}";
            DateTime dateSoiree;
            if (DateTime.TryParseExact(dt, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateSoiree))
            {
                Console.WriteLine($"La date est correcte !!!");
            }
            else
            {
                Console.WriteLine($"La date : {dt} n'est pas au format 'jj/mm/aaaa', veuillez reessayer...");
                Console.WriteLine();
                return DateTimeParse();
            }
            return dateSoiree;
        }

        public void MenuPrincipal ()
        {
            int keyInfo;
            Console.WriteLine("############################################################################");
            Console.WriteLine("                   //////// Welcome to PushTaThune ////////");
            Console.WriteLine();
            Console.WriteLine("                           Que voulez vous faire ?");
            Console.WriteLine();
            Console.WriteLine("1 - Afficher les soirées");
            Console.WriteLine("2 - Créer un participant");
            Console.WriteLine("3 - Calculer le remboursement de chacun pour une soirée");
            Console.WriteLine("4 - Quitter");
            Console.WriteLine();
            Console.WriteLine("############################################################################");
            keyInfo = RecupInputInt();
            if (keyInfo == 1)
            {
                Console.Clear();
                AffichageDesSoirées();
            }
            else if (keyInfo == 2)
            {
                //MenuAjout
            }
            else if (keyInfo == 3)
            {
                //MenuCalcul
            }
            else if (keyInfo == 4)
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

        private void AffichageDesSoirées()
        {
            Console.WriteLine("############################################################################");
            Console.WriteLine("                                Vos soirées");
            Console.WriteLine();
            SoireeDepot_DAL soireeDepot = new SoireeDepot_DAL();
            List<Soiree_DAL> soirees = soireeDepot.getAll();
            foreach (var soiree in soirees)
            {
                Console.WriteLine($"{soiree.getNom} le {soiree.getDate.ToString("d")}, où ? -> {soiree.getLieu}");
            }
            Console.WriteLine();
            Console.WriteLine("Que voulez-vous faire ?");
            Console.WriteLine();
            Console.WriteLine("1 - Ajouter une soirée");
            Console.WriteLine("2 - Voir les participants d'une soirée");
            Console.WriteLine("3 - Revenir au menu principal");
            Console.WriteLine();
            Console.WriteLine("############################################################################");
            int keyInfo = RecupInputInt();
            if (keyInfo == 1)
            {
                Console.Clear();
                MenuCréationSoirée();
                AffichageDesSoirées();
            }
            else if (keyInfo == 2)
            {
                Console.WriteLine();
                Console.WriteLine("Quelle soirée voulez vous choisir ? (Entrez le nom de la soirée)");
                string nomSoirée = Console.ReadLine();
                SoireeDepot_DAL soireeDepot1 = new SoireeDepot_DAL();
                List<Soiree_DAL> listeSoirées = soireeDepot1.getAll();
                Soiree_DAL zeSoiree = listeSoirées[0]; // Je donne en valeur par défaut la première soirée dans ma liste
                foreach (var item in listeSoirées)
                {
                    if (item.getNom == nomSoirée)
                    {
                        zeSoiree = item;
                    }
                }
                MenuAjoutParticipants(zeSoiree.getIDSoiree);
            }
            else if (keyInfo == 3)
            {
                Console.Clear();
                MenuPrincipal();
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

        private void MenuCréationSoirée()
        {
            Console.WriteLine("############################################################################");
            Console.WriteLine("                          Création d'une soirée");
            Console.WriteLine();
            Console.WriteLine("Comment s'appelle votre votre soirée ?");
            string nom = RecupInputString();
            Console.WriteLine();
            Console.WriteLine("Ou se déroule votre soirée ?");
            string lieu = RecupInputString();
            Console.WriteLine();
            DateTime dt = DateTimeParse();
            Console.WriteLine();
            Console.WriteLine($"La date est : {dt.Date.ToString("d")}");
            Console.WriteLine();
            Console.WriteLine($"Création de la soirée terminée !");
            Console.WriteLine($"Retour sur l'écran d'accueil...");
            Console.WriteLine();
            Console.WriteLine("############################################################################");
            Console.Clear();
            var soiree = new Soiree_DAL(nom, lieu, dt);
            var dps = new SoireeDepot_DAL();
            soiree = dps.insert(soiree);
        }

        private void MenuAjoutParticipants (int IDsoiree)
        {
            #region ETAPE 1

            int nbParticipants;
            SoireeDepot_DAL soireeDepot = new SoireeDepot_DAL();
            ParticipantDepot_DAL participantDepot = new ParticipantDepot_DAL();
            List<Participant_DAL> participants = participantDepot.getAll();
            List<Participant_DAL> participantsSoirée = new List<Participant_DAL>();
            foreach (var item in participants)
            {
                if (item.getIDSoiree == IDsoiree)
                {
                    participantsSoirée.Add(item);
                }
            }
            Soiree_DAL soirée = soireeDepot.getByID(IDsoiree);
            Console.Clear();
            Console.WriteLine("############################################################################");
            Console.WriteLine($"                Les participants de la soirée {soirée.getNom}");
            Console.WriteLine();
            Console.WriteLine($"Voici la liste des participants :");
            Console.WriteLine();
            foreach (var participant in participantsSoirée)
            {
                Console.WriteLine(participant.getNom);
            }
            Console.WriteLine();
            Console.WriteLine("Que voulez vous faire ?");
            Console.WriteLine();
            Console.WriteLine("1 - Ajouter un participant");
            Console.WriteLine("############################################################################");
            Thread.Sleep(2000);

            #endregion

            Console.Clear();

            #region ETAPE 2

            var montants = new List<Montant_DAL>();
            Console.WriteLine("############################################################################");
            Console.WriteLine("                      Etape 2 - Qui à donné combien ?");
            Console.WriteLine();
            for (int i = 0; i < participants.Count; i++)
            {
                Console.WriteLine($"Entrez le montant donné par {participants[i].getNom} : ");
                var argent = Console.ReadLine();
                //montants.Add(new Montant_DAL(argent, participants[i].getIDParticipant, idSoiree));
            }
            Console.WriteLine();
            Console.WriteLine("############################################################################");

            #endregion

            Console.Clear();

            #region ETAPE 3

            Console.WriteLine("############################################################################");
            Console.WriteLine("                      Etape 3 - Qui doit combien ?");
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
