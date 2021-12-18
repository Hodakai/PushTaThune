using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PushTaThune.DAL
{
    public class MontantDepot_DAL : Depot_DAL<Montant_DAL>
    {
        public MontantDepot_DAL()
            : base()
        { }

        public override List<Montant_DAL> getAll()
        {
            createConnection();

            commande.CommandText = "SELECT montant, idParticipant, idSoiree FROM montants";
            var reader = commande.ExecuteReader();

            var listeMontants = new List<Montant_DAL>();

            while (reader.Read())
            {
                var m = new Montant_DAL(reader.GetDouble(0),
                                                reader.GetInt32(1),
                                                reader.GetInt32(2));
                listeMontants.Add(m);
            }

            closeConnection();

            return listeMontants;
        }

        public override Montant_DAL getByID(int ID)
        {
            createConnection();

            commande.CommandText = "SELECT montant, idParticipant, idSoiree FROM montants WHERE CONCAT(idParticipant, idSoiree)=@id";
            commande.Parameters.Add(new SqlParameter("@id", ID));
            var reader = commande.ExecuteReader();

            Montant_DAL m;
            if (reader.Read())
            {
                m = new Montant_DAL(reader.GetDouble(0),
                                                reader.GetInt32(1),
                                                reader.GetInt32(2));
            }
            else
                throw new Exception($"Pas de montant avec l'ID : {ID}");

            closeConnection();

            return m;
        }

        public override Montant_DAL insert(Montant_DAL montant)
        {
            createConnection();

            commande.CommandText = "INSERT INTO montants(montant, idParticipant, idSoiree) VALUES (@montant, @idParticipant, @idSoiree);";

            commande.Parameters.Add(new SqlParameter("@montant", montant.montant));
            commande.Parameters.Add(new SqlParameter("@idParticipant", montant.idParticipant));
            commande.Parameters.Add(new SqlParameter("@idSoiree", montant.idSoiree));

            commande.ExecuteNonQuery();

            closeConnection();

            return montant;
        }

        public override Montant_DAL update(Montant_DAL montant)
        {
            createConnection();

            commande.CommandText = "UPDATE montants set montant=@montant, idParticipant=@idParticipant, idSoiree=@idSoiree WHERE idParticipant=@idParticipant AND idSoiree=@idSoiree";

            commande.Parameters.Add(new SqlParameter("@montant", montant.montant));
            commande.Parameters.Add(new SqlParameter("@idParticipant", montant.idParticipant));
            commande.Parameters.Add(new SqlParameter("@idSoiree", montant.idSoiree));

            var linesAffected = (int)commande.ExecuteNonQuery();

            if (linesAffected != 1)
            {
                throw new Exception($"Impossible de mettre à jour le montant d'ID : {montant.getIDParticipant}{montant.getIDSoiree}");
            }

            closeConnection();

            return montant;
        }



        public override void delete(Montant_DAL montant)
        {
            createConnection();

            commande.CommandText = "DELETE FROM montants WHERE idParticipant=@idParticipant AND idSoiree=@idSoiree";
            commande.Parameters.Add(new SqlParameter("@idParticipant", montant.idParticipant));
            commande.Parameters.Add(new SqlParameter("@idSoiree", montant.idSoiree));

            var linesAffected = (int)commande.ExecuteNonQuery();

            if (linesAffected != 1)
            {
                throw new Exception($"Impossible de supprimer le montant d'ID : {montant.getIDParticipant}");
            }

            closeConnection();

        }

        public override void deleteByID(int ID)
        {
            createConnection();

            commande.CommandText = "DELETE FROM montants WHERE CONCAT(idParticipant, idSoiree)=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));

            var linesAffected = (int)commande.ExecuteNonQuery();

            if (linesAffected != 1)
            {
                throw new Exception($"Impossible de supprimer le montant d'ID : {ID}");
            }

            closeConnection();

        }
    }
}
