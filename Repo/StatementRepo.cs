using DrugGen.Common;
using DrugGen.DrugValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugGen.Repo
{
    public class StatementRepo
    {
        public Statement[] Statements { get; set; }

        public StatementRepo(Statement[] repo) => this.Statements = repo;

        public StatementRepo()
        {
            
        }

        public Statement GetStatement(string[] indications, string drugClass)
        {
            while (true)
            {
                Statement s = Statements[Util.GetRandom(Statements.Length)];
                string[] sIndications = s.GetIndications();
                string[] sClasses = s.GetClasses();

                bool indicationMatch= false;
                foreach (string indication in indications)
                {
                    if (sIndications.Contains(indication)) { indicationMatch= true; break; }
                }

                if (sIndications.Contains("Any") && sClasses.Contains("Any")) { return s; }
                if (indicationMatch || sClasses.Contains(drugClass)) { return s; }
            }
        }

    }
}
