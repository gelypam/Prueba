using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PruebaWcf.wcfCine;

namespace PruebaWcf
{
    class Program
    {
        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.prueba();            
        }

        public void prueba()
        {
            wcfCine.IService wcf = new wcfCine.ServiceClient();

            Cartelera cartel = wcf.GetCarteleraNP();

            Console.WriteLine("cosa esa fea: " + cartel.Complejo);
            Console.ReadKey();
        }
    }
}
