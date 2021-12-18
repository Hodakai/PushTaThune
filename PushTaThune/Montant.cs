using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushTaThune
{
    public class Montant
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
        public Montant(double montant, int idParticipant, int idSoiree)
        {
            this.montant = montant;
            this.idParticipant = idParticipant;
            this.idSoiree = idSoiree;
        }
        #endregion
    }
}
