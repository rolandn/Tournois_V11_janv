using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournois.ClassesMetier
{
    public class tables
    {

        // Variables
        public int idt { get; set; }
        public int position { get; set; }

        // Constructeurs

        public tables(tables t)
        {
            idt = t.idt;
            position = t.position;
        }

        public tables(int Idt, int Position)
        {
            idt = Idt;
            position = Position;
        }

        public tables()
        {

        }
    }
}
