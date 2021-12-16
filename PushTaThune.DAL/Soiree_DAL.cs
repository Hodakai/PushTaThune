using System;
using System.Data.SqlClient;

namespace PushTaThune.DAL
{
    public class Soiree_DAL
    {
        public int ID;
        public string nom;
        public string lieu;
        public DateTime date;

        #region Getters / Setters

        public int getIDSoiree
        {
            get { return ID; }
            private set { ID = value; }
        }

        public string getNom
        {
            get { return nom; }
            private set { nom = value; }
        }

        public string getLieu
        {
            get { return lieu; }
            private set { lieu = value; }
        }

        public DateTime getDate
        {
            get { return date; }
            private set { date = value; }
        }

        #endregion

        #region Constructeurs

        public Soiree_DAL(string nom, string lieu, DateTime date) => (this.nom, this.lieu, this.date) = (nom, lieu, date);

        public Soiree_DAL(int id, string nom, string lieu, DateTime date) => (this.ID, this.nom, this.lieu, this.date) = (id, nom, lieu, date);

        #endregion

        #region Methodes

        internal void addParticipant(SqlConnection connection)
        {
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "INSERT INTO soiree(nom, lieu, date)"
                                       + " VALUES (@nom, @lieu, @date)";
                command.Parameters.Add(new SqlParameter("@nom", nom));
                command.Parameters.Add(new SqlParameter("@lieu", lieu));
                command.Parameters.Add(new SqlParameter("@date", date));

                command.ExecuteNonQuery();
            }
        }

        #endregion
    }
}
