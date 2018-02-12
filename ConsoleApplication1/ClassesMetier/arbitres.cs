using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournois.ClassesMetier
{
    public class arbitres
    {
        // Variables //
        public int ida { get; set; }
        public string nom { get; set; }
        public string prenom {get; set; }
        public int experience { get; set; }

        // Constructeurs //
        public arbitres()
        { }

        public arbitres(arbitres a)
        {
            ida = a.ida;
            nom = a.nom;
            prenom = a.prenom;
            experience = a.experience;
        }

        public arbitres(int Ida, string Nom, string Prenom, int Experience)
        {
            ida = Ida;
            nom = Nom;
            prenom = Prenom;
            experience = Experience; 
        }

    }


}
