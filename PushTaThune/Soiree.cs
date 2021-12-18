using System;

namespace PushTaThune
{
    public class Soiree
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

        #region Constructeur
        public Soiree(string nom, string lieu, DateTime date)
        {
            this.nom = nom;
            this.lieu = lieu;
            this.date = date;
        }
        public Soiree(int id, string nom, string lieu, DateTime date)
            : this(nom, lieu, date)
        {
            this.ID = id;
        }
        #endregion
    }
}
