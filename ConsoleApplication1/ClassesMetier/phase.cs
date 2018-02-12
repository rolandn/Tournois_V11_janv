using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.ClassesMetier
{
    public class phase
    {

        // Variables
        public int idp { get; set; }
        public string nomPhase { get; set; }

        // Constructeurs

        public phase(phase p)
        {
            idp = p.idp;
            nomPhase = p.nomPhase;
        }

        public phase(int Idp, string NomPhase)
        {
            idp = Idp;
            nomPhase = NomPhase;
        }

        public phase()
        {

        }
    }
}
