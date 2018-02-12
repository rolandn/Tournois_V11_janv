using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournois.ClassesMetier
{
    public class joueurs
    {
        // Variables
        public int idj { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public int classement { get; set; }

        // Constructeurs
        public joueurs(joueurs j)
        {
            idj = j.idj;
            nom = j.nom;
            prenom = j.prenom;
            classement = j.classement;
        }

        public joueurs(int Idj, string Nom, string Prenom, int Classement)
        {
            idj = Idj;
            nom = Nom;
            prenom = Prenom;
            classement = Classement;
        }

        public joueurs()
        {
        }
    }
}
