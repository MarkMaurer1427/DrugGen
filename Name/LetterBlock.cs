using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugGen.Name
{
    public class LetterBlock
    {
        public string Name { get; set; }
        public bool StartName { get; set; }

        public LetterBlock(string letters, bool start)
        {
            this.Name = letters;
            this.StartName = start;
        }

        public LetterBlock()
        {
            
        }
    }
}
