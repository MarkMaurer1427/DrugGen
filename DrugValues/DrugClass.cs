using DrugGen.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugGen.DrugValues
{
    public class DrugClass
    {
        public string Name { set; get; }

        public string[] Endings { set; get; }

        public string[] Indications { set; get; }

        public string Indef { set; get; }

        public bool NeedsVowelPrefix { set; get; }

        public DrugClass()
        {
            
        }

    }
}
