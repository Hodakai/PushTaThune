using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PushTaThune.DAL
{
    public abstract class Depot_DAL<Type_DAL> : IDepot_DAL<Type_DAL>
    {
        public string connectionString { get; set; }
        protected SqlConnection connection;
        protected SqlCommand commande;

        public Depot_DAL()
        {
            var builder = new ConfigurationBuilder();
            var config = builder.AddJsonFile("appsettings.json", false, true).Build();
            connectionString = config.GetSection("ConnectionStrings:default").Value;
        }

        protected void createConnection()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            commande = new SqlCommand();
            commande.Connection = connection;
        }

        protected void closeConnection()
        {
            commande.Dispose();
            connection.Close();
            commande.Dispose();
        }

        #region Abstract methods
        public abstract void delete(Type_DAL item);

        public abstract List<Type_DAL> getAll();

        public abstract Type_DAL getByID(int ID);

        public abstract Type_DAL insert(Type_DAL item);

        public abstract Type_DAL update(Type_DAL item);

        public abstract void deleteByID(int ID);
        #endregion
    }
}
