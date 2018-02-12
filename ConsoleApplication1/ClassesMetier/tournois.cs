using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournois.ClassesMetier
{
    class tournois
    {

       

            // Variables
            public int idtou { get; set; }

            // Constructeurs

            public tournois(tournois t)
            {
                idtou = t.idtou;
            }

            public tournois(int Idtou)
            {
                idtou = Idtou;
            }

            public tournois()
            {

            }
        
    }
}
