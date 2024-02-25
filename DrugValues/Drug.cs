using DrugGen.Common;
using DrugGen.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DrugGen.DrugValues
{
    public class Drug
    {
        public string Name { set; get; }
        DrugClass drugClass { set; get; }
        Statement statement { set; get; }



        public Drug(string Name, DrugClass drugClass, StatementRepo repo)
        {
            this.Name = Name;
            this.drugClass = drugClass;
            this.statement = repo.GetStatement(drugClass.Indications, drugClass.Name);
        }

        

        public void PrintDrug()
        {

            string indications="";
            string countTerm = (drugClass.Indications.Length > 1) ? "s are" : " is";
            for(int i = 0;i<drugClass.Indications.Length;i++)
            {
                
                if (i != 0)
                {
                    if (drugClass.Indications.Length == 2) { indications = indications + " and "; }
                    else
                    {
                        int andPoint = drugClass.Indications.Length - 1;
                        indications = indications + ", ";
                        if (i == andPoint){indications = indications + "and ";}
                    }
                    

                }
                indications = indications + drugClass.Indications[i].ToString();
            }

            Console.WriteLine($"Drug name: {Name}");
            Console.WriteLine($"It is {drugClass.Indef} {drugClass.Name}.");
            Console.WriteLine($"Its indication{countTerm} {indications}.");
            Console.WriteLine();
            Console.WriteLine(statement.Comment);

        }


    }
}
