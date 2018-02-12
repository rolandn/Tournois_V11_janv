using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournois.coucheAccesDB
{
    public class ExceptionAccesDB : Exception
    {
        private string Details { get; set; }

        public ExceptionAccesDB(string cause, string details) : base(cause)
        {
            Details = details;
        }
    }
}
