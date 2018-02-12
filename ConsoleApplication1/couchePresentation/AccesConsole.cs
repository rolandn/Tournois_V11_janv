using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournois.couchePresentation
{
    static public class AccesConsole
    {

        static public void CreerEcran(string s)
        {
            Console.Clear();
            Console.WriteLine(s);
            Console.WriteLine(new String('-', s.Length) + "\n");
        }

        static public string SaisirChaine(string s)
        {
            Console.Write(s);
            return Console.In.ReadLine();
        }

        static public int Saisirint(string s)
        {
            Console.Write(s);
            return Convert.ToInt32(Console.In.ReadLine());
        }

        static public double SaisirDouble(string s)
        {
            Console.Write(s);
            return Convert.ToDouble(Console.In.ReadLine());
        }

        static public void Attendre()
        {
            Console.Write("\nPresser une touche pour continuer ");
            Console.ReadKey();
            Console.WriteLine("\n");
        }
    }
}
