using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushTaThune
{
    class Participant
    {
        int idParticipant;
        string nom;
        int idSoiree;

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

        #region Constructeur
        public Participant(string nom, int idSoiree)
        {
            this.nom = nom;
            this.idSoiree = idSoiree;
        }
        public Participant(int id, string nom, int idSoiree)
            :this(nom,idSoiree)
        {
            this.idParticipant = id;
        }
        #endregion
    }
}
