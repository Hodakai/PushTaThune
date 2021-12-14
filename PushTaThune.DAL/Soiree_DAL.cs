using System;
using System.Data.SqlClient;

namespace PushTaThune.DAL
{
    public class Soiree_DAL
    {
        public int ID;
        public string lieu;
        public DateTime date;

        #region Getters / Setters

        public int getIDSoiree
        {
            get { return ID; }
            private set { ID = value; }
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

        public Soiree_DAL(string lieu, DateTime date) => (this.lieu, this.date) = (lieu, date);

        public Soiree_DAL(int id, string lieu, DateTime date) => (this.ID, this.lieu, this.date) = (id, lieu, date);

        #endregion

        #region Methodes

        internal void addParticipant(SqlConnection connection)
        {
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "INSERT INTO soiree(lieu, date)"
                                       + " VALUES (@lieu, @date)";
                command.Parameters.Add(new SqlParameter("@lieu", lieu));
                command.Parameters.Add(new SqlParameter("@date", date));

                command.ExecuteNonQuery();
            }
        }

        #endregion
    }
}
