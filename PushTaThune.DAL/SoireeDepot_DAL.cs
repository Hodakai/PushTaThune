using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PushTaThune.DAL
{
    public class SoireeDepot_DAL : Depot_DAL<Soiree_DAL>
    {
        public SoireeDepot_DAL()
            : base()
        { }

        public override List<Soiree_DAL> getAll()
        {
            createConnection();

            commande.CommandText = "SELECT id, nom, lieu, date FROM soirees";
            var reader = commande.ExecuteReader();

            var listeSoirees = new List<Soiree_DAL>();

            while (reader.Read())
            {
                var s = new Soiree_DAL(reader.GetInt32(0),
                                       reader.GetString(1),
                                       reader.GetString(2),
                                       reader.GetDateTime(3));
                listeSoirees.Add(s);
            }

            closeConnection();

            return listeSoirees;
        }

        public override Soiree_DAL getByID(int ID)
        {
            createConnection();

            commande.CommandText = "SELECT id, nom, lieu, date FROM soirees WHERE id=@id";
            commande.Parameters.Add(new SqlParameter("@id", ID));
            var reader = commande.ExecuteReader();

            Soiree_DAL s;
            if (reader.Read())
            {
                s = new Soiree_DAL(reader.GetInt32(0),
                                       reader.GetString(1),
                                       reader.GetString(2),
                                       reader.GetDateTime(3));
            }
            else
                throw new Exception($"Pas de soirées avec l'ID {ID}");

            closeConnection();

            return s;
        }

        public override Soiree_DAL insert(Soiree_DAL soiree)
        {
            createConnection();

            commande.CommandText = "INSERT INTO soirees(nom, lieu, date) VALUES (@nom, @lieu, @date); select scope_identity()";

            commande.Parameters.Add(new SqlParameter("@nom", soiree.getNom));
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

            commande.CommandText = "UPDATE soirees set lieu=@lieu, date=@date WHERE id=@ID";

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

            commande.CommandText = "DELETE FROM soirees WHERE id=@ID";
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

            commande.CommandText = "DELETE FROM soirees WHERE id=@ID";
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
