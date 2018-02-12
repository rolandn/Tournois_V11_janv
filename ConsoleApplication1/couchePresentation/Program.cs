using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournois.couchePresentation
{
    class Program
    {

        //---------------------------------------------
        // Méthode lancée au démarrage de l'application
        //---------------------------------------------

        static void Main(string[] args)
        {
            Presentation application = new Presentation();
            application.MenuPrincipal();
        }
    }
}
