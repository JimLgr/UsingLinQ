using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingLinq
{
    internal class Students
    {
        // syntaxe propriétés auto implemented
        public string firstName { get; set;}
        public int age { get;  set; }

        public override string ToString()
        {
            return $"Student : Firstname = {this.firstName} Age = {this.age}";
        }
    }
 
}
 