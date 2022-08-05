using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingLinq
{
    // les règles de création des méthodes d'extension sont  : 
    // la classe doit être static obligatoirement.
    // toutes les méthodes oivent être static
    // le premier paramètre de la méthode doit être du type à étendre
    // le premier paramètre doit avoir le mot clé this
    public static class ExtensionMethodes
    {
        public static bool IsEven(this int pNombre) => pNombre % 2 == 0;
        public static int CountWovels(this string pTexte) => 0;

        
    }
   
}
