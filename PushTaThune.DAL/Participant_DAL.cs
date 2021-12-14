using System.Data.SqlClient;

namespace PushTaThune.DAL
{
    public class Participant_DAL
    {
        public int idParticipant;
        public string nom;
        public int idSoiree;

        #region Getters / Setters

        public int getIDParticipant
        {
            get { return idParticipant; }
            private set { idParticipant = value; }
        }

        public string getNom
        {
            get { return nom; }
            private set { nom = value; }
        }

        public int getIDSoiree
        {
            get { return idSoiree; }
            private set { idSoiree = value; }
        }

        #endregion

        #region Constructeurs

        public Participant_DAL(string name, int idSoiree) => (this.name, this.idSoiree) = (name, idSoiree);

        public Participant_DAL(int id, string name, int idSoiree) => (this.idParticipant, this.name, this.idSoiree) = (id, name, idSoiree);

        #endregion

        #region Methodes

        internal void addParticipant(SqlConnection connection)
        {
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "INSERT INTO participant(nom, idSoiree)"
                                       + " VALUES (@nom, @idSoiree)";
                command.Parameters.Add(new SqlParameter("@nom", nom));
                command.Parameters.Add(new SqlParameter("@idSoiree", idSoiree));

                command.ExecuteNonQuery();
            }
        }

        #endregion
    }
}
