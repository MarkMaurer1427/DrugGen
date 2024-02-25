using DrugGen.Common;
using DrugGen.DrugValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugGen.Repo
{
    public class DrugClassRepo
    {
        public DrugClass[] ClassRepo { set; get; }

        public DrugClassRepo()
        {
           
        }

        public DrugClass GetDrugClass()
        {
            return ClassRepo[Util.GetRandom(ClassRepo.Length)];
        }
    }
}
