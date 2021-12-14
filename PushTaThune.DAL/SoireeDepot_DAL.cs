using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PushTaThune.DAL
{
    class SoireeDepot_DAL : Depot_DAL<Soiree_DAL>
    {
        public SoireeDepot_DAL()
            : base()
        { }

        public override List<Soiree_DAL> getAll()
        {
            createConnection();

            commande.CommandText = "SELECT id, lieu, date FROM soiree";
            var reader = commande.ExecuteReader();

            var listeSoirees = new List<Soiree_DAL>();

            while (reader.Read())
            {
                var s = new Soiree_DAL(reader.GetInt32(0),
                                                reader.GetString(1),
                                                reader.GetDateTime(2));
                listeSoirees.Add(s);
            }

            closeConnection();

            return listeSoirees;
        }

        public override Soiree_DAL getByID(int ID)
        {
            createConnection();

            commande.CommandText = "SELECT id, lieu, date FROM soiree WHERE id=@id";
            commande.Parameters.Add(new SqlParameter("@id", ID));
            var reader = commande.ExecuteReader();

            Soiree_DAL s;
            if (reader.Read())
            {
                s = new Soiree_DAL(reader.GetInt32(0),
                                                reader.GetString(1),
                                                reader.GetDateTime(2));
            }
            else
                throw new Exception($"Pas de soirées avec l'ID {ID}");

            closeConnection();

            return s;
        }

        public override Soiree_DAL insert(Soiree_DAL soiree)
        {
            createConnection();

            commande.CommandText = "INSERT INTO soiree(lieu, date) VALUES (@lieu, @date); select scope_identity()";

            commande.Parameters.Add(new SqlParameter("@lieu", soiree.getLieu));
            commande.Parameters.Add(new SqlParameter("@date", soiree.getDate));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            soiree.ID = ID;

            closeConnection();

            return soiree;
        }

        public override Soiree_DAL update(Soiree_DAL soiree)
        {
            createConnection();

            commande.CommandText = "UPDATE soiree set lieu=@lieu, date=@date WHERE id=@ID";

            commande.Parameters.Add(new SqlParameter("@lieu", soiree.getLieu));
            commande.Parameters.Add(new SqlParameter("@date", soiree.getDate));
            commande.Parameters.Add(new SqlParameter("@ID", soiree.getIDSoiree));

            var linesAffected = (int)commande.ExecuteNonQuery();

            if (linesAffected != 1)
            {
                throw new Exception($"Impossible de mettre à jour la soirée d'ID : {soiree.getIDSoiree}");
            }

            closeConnection();

            return soiree;

        }

        public override void delete(Soiree_DAL soiree)
        {
            createConnection();

            commande.CommandText = "DELETE * FROM soiree WHERE id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", soiree.getIDSoiree));

            var linesAffected = (int)commande.ExecuteNonQuery();

            if (linesAffected != 1)
            {
                throw new Exception($"Impossible de supprimer la soirée d'ID : {soiree.getIDSoiree}");
            }

            closeConnection();

        }

        public override void deleteByID(int ID)
        {
            createConnection();

            commande.CommandText = "DELETE FROM soiree WHERE id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));

            var linesAffected = (int)commande.ExecuteNonQuery();

            if (linesAffected != 1)
            {
                throw new Exception($"Impossible de supprimer la soiree d'ID : {ID}");
            }

            closeConnection();

        }
    }
}
