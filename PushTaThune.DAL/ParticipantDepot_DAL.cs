using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PushTaThune.DAL
{
    public class ParticipantDepot_DAL : Depot_DAL<Participant_DAL>
    {
        public ParticipantDepot_DAL()
            : base()
        { }

        public override List<Participant_DAL> getAll()
        {
            createConnection();

            commande.CommandText = "SELECT id, nom, idSoiree FROM participants";
            var reader = commande.ExecuteReader();

            var listeParticipants = new List<Participant_DAL>();

            while (reader.Read())
            {
                var p = new Participant_DAL(reader.GetInt32(0),
                                                reader.GetString(1),
                                                reader.GetInt32(2));
                listeParticipants.Add(p);
            }

            closeConnection();

            return listeParticipants;
        }

        public override Participant_DAL getByID(int ID)
        {
            createConnection();

            commande.CommandText = "SELECT id, nom, idSoiree FROM participants WHERE id=@id";
            commande.Parameters.Add(new SqlParameter("@id", ID));
            var reader = commande.ExecuteReader();

            Participant_DAL p;
            if (reader.Read())
            {
                p = new Participant_DAL(reader.GetInt32(0),
                                                reader.GetString(1),
                                                reader.GetInt32(2));
            }
            else
                throw new Exception($"Pas de participants avec l'ID {ID}");

            closeConnection();

            return p;
        }

        public override Participant_DAL insert(Participant_DAL participant)
        {
            createConnection();

            commande.CommandText = "INSERT INTO participants(nom, idSoiree) VALUES (@nom, @idSoiree); select scope_identity()";

            commande.Parameters.Add(new SqlParameter("@nom", participant.getNom));
            commande.Parameters.Add(new SqlParameter("@idSoiree", participant.getIDSoiree));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            participant.idParticipant = ID;

            closeConnection();

            return participant;

        }

        public override Participant_DAL update(Participant_DAL participant)
        {
            createConnection();

            commande.CommandText = "UPDATE participants set nom=@nom, idSoiree=@idSoiree WHERE id=@ID";

            commande.Parameters.Add(new SqlParameter("@nom", participant.getNom));
            commande.Parameters.Add(new SqlParameter("@idSoiree", participant.getIDSoiree));
            commande.Parameters.Add(new SqlParameter("@ID", participant.getIDParticipant));

            var linesAffected = (int)commande.ExecuteNonQuery();

            if (linesAffected != 1)
            {
                throw new Exception($"Impossible de mettre à jour le participant d'ID : {participant.getIDParticipant}");
            }

            closeConnection();

            return participant;

        }



        public override void delete(Participant_DAL participant)
        {
            createConnection();

            commande.CommandText = "DELETE FROM participants WHERE id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", participant.getIDParticipant));

            var linesAffected = (int)commande.ExecuteNonQuery();

            if (linesAffected != 1)
            {
                throw new Exception($"Impossible de supprimer le participant d'ID : {participant.getIDParticipant}");
            }

            closeConnection();

        }

        public override void deleteByID(int ID)
        {
            createConnection();

            commande.CommandText = "DELETE FROM participants WHERE id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));

            var linesAffected = (int)commande.ExecuteNonQuery();

            if (linesAffected != 1)
            {
                throw new Exception($"Impossible de supprimer le participant d'ID : {ID}");
            }

            closeConnection();

        }
    }
}
