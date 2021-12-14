using System;

namespace PushTaThune
{
    class Soiree
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

        #region Constructeur
        public Soiree(string lieu, DateTime date)
        {
            this.lieu = lieu;
            this.date = date;
        }
        public Soiree(int id, string lieu, DateTime date)
            : this(lieu, date)
        {
            this.ID = id;
        }
        #endregion
    }
}
