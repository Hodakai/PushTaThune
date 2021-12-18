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
                Console.Clear();
                MenuAjoutParticipant();
            }
            else if (keyInfo == 3)
            {
                MenuCalcul();
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

        private void MenuAjoutParticipant()
        {
            Console.WriteLine("############################################################################");
            Console.WriteLine("                      Enregistrement des participants");
            Console.WriteLine();
            ParticipantDepot_DAL participantDepot = new ParticipantDepot_DAL();
            SoireeDepot_DAL soireeDepot = new SoireeDepot_DAL();
            List<Soiree_DAL> soirées = soireeDepot.getAll();
            List<Participant_DAL> participants = participantDepot.getAll();
            Soiree_DAL soiree = soirées[1]; // Ici j'assigne la première valeur par défault sinon le compileur est pas content (╯°□°）╯︵ ┻━┻
            foreach (var participant in participants)
            {
                if (participant.getIDSoiree != 0)
                {
                    foreach (var item in soirées)
                    {
                        if (item.getIDSoiree == participant.getIDSoiree)
                        {
                            soiree = item;
                        }
                    }
                    Console.WriteLine($"{participant.getNom} -> Participe à la soirée {soiree.getNom} ヾ(⌐■_■)ノ♪");
                }
                else
                    Console.WriteLine($"{participant.getNom} -> Ne participe à aucune soirée ಥ_ಥ");
            }
            Console.WriteLine();
            Console.WriteLine("Que voulez-vous faire ?");
            Console.WriteLine();
            Console.WriteLine("1 - Ajouter un participant dans la liste");
            Console.WriteLine("2 - Supprimer un participant dans la liste");
            Console.WriteLine("3 - Revenir au menu principal");
            Console.WriteLine();
            Console.WriteLine("############################################################################");
            int keyInfo = RecupInputInt();
            if (keyInfo == 1)
            {
                Console.Clear();
                MenuCréationParticipant();
            }
            else if (keyInfo == 2)
            {
                Console.Clear();
                MenuSuppressionParticipant();
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
                MenuAjoutParticipant();
            }
        }

        private void MenuSuppressionParticipant()
        {
            Console.WriteLine("############################################################################");
            Console.WriteLine($"                       Suppression d'un participant");
            Console.WriteLine();
            ParticipantDepot_DAL participantDepot = new ParticipantDepot_DAL();
            SoireeDepot_DAL soireeDepot = new SoireeDepot_DAL();
            List<Soiree_DAL> soirées = soireeDepot.getAll();
            List<Participant_DAL> participants = participantDepot.getAll();
            Soiree_DAL soiree = soirées[1];
            foreach (var participant_ in participants)
            {
                if (participant_.getIDSoiree != 0)
                {
                    foreach (var item in soirées)
                    {
                        if (item.getIDSoiree == participant_.getIDSoiree)
                        {
                            soiree = item;
                        }
                    }
                    Console.WriteLine($"{participant_.getNom} -> Participe à la soirée {soiree.getNom} !");
                }
                else
                    Console.WriteLine($"{participant_.getNom} -> Ne participe à aucune soirée :'(");
            }
            Console.WriteLine($"Entrez le nom du participant à supprimer : ");
            string participant = RecupInputString();
            foreach (var item in participants)
            {
                if (item.getNom == participant)
                {
                    participantDepot.delete(item);
                    break;
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Participant {participant} supprimé de la liste avec succès !");
            Console.WriteLine("Retour sur la page d'afffichage des participants...");
            Console.WriteLine();
            Console.WriteLine("############################################################################");
            Thread.Sleep(2000);
            MenuAjoutParticipant();
        }

        private void MenuCréationParticipant()
        {
            ParticipantDepot_DAL participantDepot = new ParticipantDepot_DAL();
            Console.WriteLine("############################################################################");
            Console.WriteLine($"                       Création d'un participant");
            Console.WriteLine();
            Console.WriteLine($"Entrez le nom du nouveau participant : ");
            string participant = RecupInputString();
            participantDepot.insert(new Participant_DAL(participant, 0));
            Console.WriteLine();
            Console.WriteLine($"Participant {participant} ajouté à la liste avec succès !");
            Console.WriteLine("Retour sur la page d'afffichage des participants...");
            Console.WriteLine();
            Console.WriteLine("############################################################################");
            Thread.Sleep(2000);
            Console.Clear();
            MenuAjoutParticipant();
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
            Console.WriteLine("2 - Supprimer une soirée");
            Console.WriteLine("3 - Voir les participants d'une soirée");
            Console.WriteLine("4 - Revenir au menu principal");
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
                Console.Clear();
                MenuSuppressionSoirée();
                AffichageDesSoirées();
            }
            else if (keyInfo == 3)
            {
                Console.WriteLine();
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
                Console.Clear();
                MenuAjoutParticipantsSoirée(zeSoiree.getIDSoiree);
            }
            else if (keyInfo == 4)
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

        private void MenuSuppressionSoirée()
        {
            Console.WriteLine("############################################################################");
            Console.WriteLine("Voici vos soirées : ");
            Console.WriteLine();
            SoireeDepot_DAL soireeDepot = new SoireeDepot_DAL();
            List<Soiree_DAL> soirees = soireeDepot.getAll();
            foreach (var soiree in soirees)
            {
                Console.WriteLine($"{soiree.getNom} le {soiree.getDate.ToString("d")}, où ? -> {soiree.getLieu}");
            }
            Console.WriteLine();
            Console.WriteLine("Quelle soirée voulez vous supprimer ? (entrez le nom de la soirée)");
            string soiréeChoisie = RecupInputString();
            bool choixCorrect = false;
            foreach (var soiree in soirees)
            {
                if (soiree.getNom == soiréeChoisie)
                {
                    soireeDepot.delete(soiree);
                    choixCorrect = true;
                    break;
                }
            }
            Console.WriteLine();
            if (choixCorrect)
                Console.WriteLine("La soirée à été supprimée avec succès !");
            else
            {
                Console.WriteLine("Veuillez reesayer avec un nom de soirée parmi la liste présentée...");
                Thread.Sleep(2000);
                MenuSuppressionSoirée();
            }
            Console.WriteLine();
            Console.WriteLine("############################################################################");
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
            Console.WriteLine($"Retour sur l'écran d'affichage des soirées...");
            Console.WriteLine();
            Console.WriteLine("############################################################################");
            Console.Clear();
            var soiree = new Soiree_DAL(nom, lieu, dt);
            var dps = new SoireeDepot_DAL();
            soiree = dps.insert(soiree);
            Thread.Sleep(2000);
        }

        private void MenuAjoutParticipantsSoirée(int IDsoiree)
        {

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
            Console.WriteLine("2 - Supprimer un participant");
            Console.WriteLine("3 - Revenir à la liste des soirées");
            Console.WriteLine();
            Console.WriteLine("############################################################################");
            var keyInfo = RecupInputInt();
            if (keyInfo == 1)
            {
                Console.Clear();
                MenuAjoutPartcipantsDansSoiréeAvecBDD(soirée);
            }
            else if (keyInfo == 2)
            {
                Console.Clear();
                MenuSupressionDeParticipantDeSoirée(soirée);
            }
            else if (keyInfo == 3)
            {
                Console.Clear();
                AffichageDesSoirées();
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
                MenuAjoutParticipantsSoirée(IDsoiree);
            }

        }
        private void MenuAjoutPartcipantsDansSoiréeAvecBDD(Soiree_DAL soirée)
        {
            var depotParticipants = new ParticipantDepot_DAL();
            var participants = new List<Participant_DAL>();
            participants = depotParticipants.getAll();
            Console.WriteLine("############################################################################");
            Console.WriteLine($"            Ajout d'un participant à la soirée : {soirée.getNom}");
            Console.WriteLine();
            Console.WriteLine("Voici la liste de participants possibles :");
            Console.WriteLine();
            foreach (var participant in participants)
            {
                Console.WriteLine(participant.getNom);
            }
            Console.WriteLine();
            Console.WriteLine("Ecrivez le nom du participant que vous voulez ajouter à la soirée");
            Console.WriteLine();
            Console.WriteLine("############################################################################");
            string participantChoisi = RecupInputString();
            bool choixCorrect = false;
            foreach (var participant in participants)
            {
                if (participantChoisi == participant.getNom)
                {
                    Participant_DAL newParticipant = new Participant_DAL(participant.getNom, soirée.getIDSoiree);
                    newParticipant.idParticipant = participant.getIDParticipant;
                    depotParticipants.update(newParticipant);
                    choixCorrect = true;
                    break;
                }
            }
            if (choixCorrect)
                Console.WriteLine("Action effectuée avec succès !");
            else
            {
                Console.WriteLine("Veuillez rentrer une participant faisant partie de la liste, reessayez");
                Thread.Sleep(2000);
                MenuAjoutPartcipantsDansSoiréeAvecBDD(soirée);
            }
            Console.WriteLine($"Retour à la liste des participants de la soirée {soirée.getNom}...");
            Thread.Sleep(2000);
            MenuAjoutParticipantsSoirée(soirée.getIDSoiree);
        }

        private void MenuSupressionDeParticipantDeSoirée(Soiree_DAL soirée)
        {
            var depotParticipants = new ParticipantDepot_DAL();
            var participants = new List<Participant_DAL>();
            participants = depotParticipants.getAll();
            Console.WriteLine("############################################################################");
            Console.WriteLine($"        Suppression d'un participant à la soirée : {soirée.getNom}");
            Console.WriteLine();
            Console.WriteLine("Voici la liste de participants de la soirée :");
            Console.WriteLine();
            foreach (var participant in participants)
            {
                if (participant.getIDSoiree == soirée.getIDSoiree)
                {
                    Console.WriteLine(participant.getNom);
                }
            }
            Console.WriteLine();
            Console.WriteLine("Ecrivez le nom du participant que vous voulez supprimer de la soirée");
            string participantChoisi = RecupInputString();
            bool choixCorrect = false;
            foreach (var participant in participants)
            {
                if (participantChoisi == participant.getNom)
                {
                    Participant_DAL newParticipant = new Participant_DAL(participant.getNom, 0);
                    depotParticipants.update(newParticipant);
                    choixCorrect = true;
                    break;
                }
            }
            if (choixCorrect)
                Console.WriteLine("Action effectuée avec succès !");
            else
            {
                Console.WriteLine("Veuillez rentrer une participant faisant partie de la liste, reessayez");
                Thread.Sleep(2000);
                MenuSupressionDeParticipantDeSoirée(soirée);
            }
            Console.WriteLine($"Retour à la liste des participants de la soirée {soirée.getNom}...");
            Thread.Sleep(2000);
            MenuAjoutParticipantsSoirée(soirée.getIDSoiree);
        }

        private void MenuCalcul()
        {
            
            Console.WriteLine("############################################################################");
            Console.WriteLine("                     Calcul du remboursement de chacun");
            Console.WriteLine();
            Console.WriteLine("Voici la liste des soirées crées : ");
            SoireeDepot_DAL soireeDepot = new SoireeDepot_DAL();
            List<Soiree_DAL> soirees = soireeDepot.getAll();
            foreach (var soiree in soirees)
            {
                Console.WriteLine($"{soiree.getNom} le {soiree.getDate.ToString("d")}");
            }
            Console.WriteLine();
            Console.WriteLine("Inscrivez le nom de la soirée dont vous voulez voir le résultat : ");
            string soireeChoisieStr = RecupInputString();
            Console.WriteLine();
            Console.WriteLine("############################################################################");
            Soiree_DAL soireeChoisie = soirees[1];
            bool choixCorrect = false;
            foreach (var soiree in soirees)
            {
                if (soiree.getNom == soireeChoisieStr)
                {
                    soireeChoisie = soiree;
                    choixCorrect = true;
                    break;
                }
            }
            if (choixCorrect)
                AffichageCalcul(soireeChoisie);
            else
            {
                Console.WriteLine();
                Console.WriteLine($"La soirée choisie {soireeChoisieStr} ne fait pas partie de la liste, veuillez reessayer...");
                Thread.Sleep(2000);
                MenuCalcul();
            }
        }

        private void AffichageCalcul(Soiree_DAL soiree)
        {
            MontantDepot_DAL montantDepot = new MontantDepot_DAL();
            ParticipantDepot_DAL participantDepot = new ParticipantDepot_DAL();
            List<Participant_DAL> participantsAll = participantDepot.getAll();
            List<Participant_DAL> participants = new List<Participant_DAL>();
            foreach (var item in participantsAll)
            {
                if (item.idSoiree == soiree.getIDSoiree)
                {
                    participants.Add(item);
                }
            }
            Console.WriteLine("############################################################################");
            Console.WriteLine($"Entrez le montant donné par les participants de la soirée {soiree.getNom}");
            Console.WriteLine();
            foreach (var participant in participants)
            {
                Console.WriteLine($"Le montant donné par {participant.getNom} : ");
                double montantDonne = double.Parse(Console.ReadLine());
                Montant_DAL montant = new Montant_DAL(montantDonne, participant.getIDParticipant, soiree.getIDSoiree);
                montantDepot.insert(montant); //PROBLEME ICI
            }
            Console.WriteLine();
            Console.WriteLine("Tous les montants ont été rentrés !");
            Console.WriteLine();
            ChargementCalcul();
            Console.WriteLine("############################################################################");
            Console.WriteLine($"          Voila les résultats pour la soirée : {soiree.getNom} !");
            Calcul(soiree);
            Console.WriteLine();
            Console.WriteLine("############################################################################");
        }

        private void ChargementCalcul()
        {
            Console.Clear();
            Console.WriteLine("############################################################################");
            Console.WriteLine();
            Console.WriteLine("                             Calcul en cours");
            Console.WriteLine();
            Console.Write("[");
            for (int i = 0; i < 75; i++)
            {
                Console.Write("/");
                Thread.Sleep(10);
            }
            Console.Write("]");
            Thread.Sleep(2000);
            Console.Clear();
        }

        private void Calcul(Soiree_DAL soiree)
        {
            MontantDepot_DAL montantDepot = new MontantDepot_DAL();
            ParticipantDepot_DAL participantDepot = new ParticipantDepot_DAL();
            List<Participant_DAL> participantsAll = participantDepot.getAll();
            List<Participant_DAL> participants = new List<Participant_DAL>();
            foreach (var item in participantsAll)
            {
                if (item.idSoiree == soiree.getIDSoiree)
                {
                    participants.Add(item);
                }
            }
            List<Montant_DAL> montantsAll = montantDepot.getAll();
            List<Montant_DAL> montants = new List<Montant_DAL>();
            double moyenneMontants = 0;
            foreach (var item in montantsAll)
            {
                if (item.getIDSoiree == soiree.getIDSoiree)
                {
                    montants.Add(item);
                    moyenneMontants += item.getMontant;
                }
            }
            moyenneMontants = moyenneMontants / montants.Count;
            List<Montant_DAL> montantsParticipantsDonnent = new List<Montant_DAL>();
            List<Montant_DAL> montantsParticipantsRecoivent = new List<Montant_DAL>();
            foreach (var item in montants)
            {
                if (item.getMontant <= moyenneMontants)
                    montantsParticipantsDonnent.Add(item);
                else
                    montantsParticipantsRecoivent.Add(item);
            }
            bool argentAdonner = false;
            bool skip = false;
            double argentDonne = 0;
            List<Montant_DAL> participantsDejaDonne = new List<Montant_DAL>();
            foreach (var participantR in montantsParticipantsRecoivent)
            {
                foreach (var participantD in montantsParticipantsDonnent)
                 {
                        foreach (var item in participantsDejaDonne)
                        {
                            if (item.getIDSoiree == participantD.getIDSoiree && item.getIDParticipant == participantD.getIDParticipant)
                                skip = true;
                            else
                                skip = false;
                        }
                        if (!argentAdonner && !skip)
                        {
                            argentDonne = moyenneMontants - participantD.getMontant;
                        }
                        if (participantR.getMontant - argentDonne > moyenneMontants && !skip)
                        {
                            Console.WriteLine($"{participantDepot.getByID(participantR.getIDParticipant).getNom} reçoit {argentDonne} E de {participantDepot.getByID(participantD.getIDParticipant).getNom}");
                            argentAdonner = false;
                            participantsDejaDonne.Add(participantD);
                        }
                        else if (participantR.getMontant - argentDonne < moyenneMontants && !skip)
                        {
                            Console.WriteLine($"{participantDepot.getByID(participantR.getIDParticipant).getNom} reçoit {participantR.getMontant - moyenneMontants} E de {participantDepot.getByID(participantD.getIDParticipant).getNom}");
                            argentDonne -= participantR.getMontant - moyenneMontants;
                            argentAdonner = true;
                            break;
                        }
                        else if (!skip)
                        {
                            Console.WriteLine($"{participantDepot.getByID(participantR.getIDParticipant).getNom} reçoit {argentDonne} E de {participantDepot.getByID(participantD.getIDParticipant).getNom}");
                            argentAdonner = false;
                            participantsDejaDonne.Add(participantD);
                            break;
                        }
                 }
            }
        }
    }
}
