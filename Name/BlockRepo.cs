using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Core.Tokens;

namespace DrugGen.Name
{
    public class BlockRepo
    {
        public LetterBlock[] blocks;
        public BlockRepo(LetterBlock[] blocks)
        {
            this.blocks = blocks;
        }

        public BlockRepo()
        {
            
        }

        public int GetBlockCount() { return blocks.Length; }
    }
}
