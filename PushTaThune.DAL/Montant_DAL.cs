using System.Data.SqlClient;

namespace PushTaThune.DAL
{
    public class Montant_DAL
    {
        public double montant;
        public int idParticipant;
        public int idSoiree;

        #region Getters / Setters

        public double getMontant
        {
            get { return montant; }
            private set { montant = value; }
        }

        public int getIDParticipant
        {
            get { return idParticipant; }
            private set { idParticipant = value; }
        }

        public int getIDSoiree
        {
            get { return idSoiree; }
            private set { idSoiree = value; }
        }

        #endregion

        #region Constructeur

        public Montant_DAL(double montant, int idParticipant, int idSoiree) => (this.montant, this.idParticipant, this.idSoiree) = (montant, idParticipant, idSoiree);

        #endregion

        #region Methodes

        internal void addMontant(SqlConnection connection)
        {
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "INSERT INTO montant(montant, idParticipant, idSoiree) VALUES (@montant, @idParticipant, @idSoiree)";
                command.Parameters.Add(new SqlParameter("@montant", montant));
                command.Parameters.Add(new SqlParameter("@idParticipant", idParticipant));
                command.Parameters.Add(new SqlParameter("@idSoiree", idSoiree));

                command.ExecuteNonQuery();
            }
        }

        #endregion
    }
}
