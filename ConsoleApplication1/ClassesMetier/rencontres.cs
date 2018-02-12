using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournois.ClassesMetier
{
    public class rencontres
    {
        // Variables

        public int idr { get; set; }
        public int joueur1 { get; set; }
        public int joueur2 { get; set; }
        public int vainqueur { get; set; }
        public int tables { get; set; }
        public int arbitre { get; set; }
        public int idp { get; set; }
        public string score { get; set; }

        // Constructeur

        public rencontres(rencontres r)
        {
            idr = r.idr;
            joueur1 = r.joueur1;
            joueur2 = r.joueur2;
            vainqueur = r.vainqueur;
            tables = r.tables;
            arbitre = r.arbitre;
            idp = r.idp;
            score = r.score;
        }

        public rencontres(int Idr, int Joueur1, int Joueur2, int Vainqueur, int Tables, int Arbitre, int Phase, string Score)
        {
            idr = Idr;
            //idtournois = Idtournois;
            joueur1 = Joueur1;
            joueur2 = Joueur2;
            vainqueur = Vainqueur;
            tables = Tables;
            arbitre = Arbitre;
            idp = Phase;
            score = Score;
        }

        public rencontres()
        {
        }

    }
}
