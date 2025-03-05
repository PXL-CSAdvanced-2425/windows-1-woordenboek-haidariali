using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowWoordenboek.Properties
{
    
    static class Wachtwoorden
    {
        public static List<string> Engels = new List<string>();
        public static List<string> Nederlands = new List<string>();

        // Methode om termen toe te voegen
        public static void VoegEngelsTermenToe(string engels)
        {
            Engels.Add(engels);
           
        }
        public static void VoegNederaldsWoordToe(string nederlands)
        {
            Nederlands.Add(nederlands);
        }



    }
}
