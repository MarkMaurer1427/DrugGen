using DrugGen.Common;
using DrugGen.DrugValues;
using DrugGen.Name;
using DrugGen.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DrugGen
{
    public class DrugGenerator
    {
        DrugClassRepo classRepo = Util.ImportDrugClasses();
        StatementRepo statementRepo = Util.ImportDrugStatements();
        BlockRepo vowelRepo = Util.ImportBlockRepo("Vowels.yaml");
        BlockRepo consonantRepo = Util.ImportBlockRepo("Consonants.yaml");


        public Drug GenerateDrug()
        {
            DrugClass drugClass = classRepo.GetDrugClass();
            string drugName = GetDrugName(drugClass.Endings, drugClass.NeedsVowelPrefix);
            Drug drug = new Drug(drugName,drugClass,statementRepo);
            return drug;
        }

        //Name Generation

        public string GetDrugName(string[] endings, bool vowelBeforeEnding)
        {
            int syllables = Util.GetRandom(3)+1;
            string last = "";
            string? ender = null;
            StringBuilder drugBuilder = new StringBuilder();
            for (int i = 0; i < syllables; i++)
            {
                if (i == 0) { };
                string syllable = GetSyllable(drugBuilder.ToString());
                last = EndingLetter(drugBuilder.ToString());
                drugBuilder.Append(syllable);
            }
            bool endsWithVowel = Util.StartWithVowel(last);
            ender = SetEndString(endsWithVowel, vowelBeforeEnding);
            switch (ender)
            {
                case "consonant":
                    {
                        string lastconsonant = GetSyllable(drugBuilder.ToString(), "consonant");
                        drugBuilder.Append(lastconsonant);
                        break;
                    }
                case "vowel":
                    {
                        string lastvowel = GetSyllable(drugBuilder.ToString(), "vowel");
                        drugBuilder.Append(lastvowel);
                        break;
                    }
                case "nil":
                    { break; }
            }
            drugBuilder.Append(endings[Util.GetRandom(endings.Length)]);
            string output = drugBuilder.ToString();
            output = Regex.Replace(output, "^[a-z]", c => c.Value.ToUpper());
            return output;
        }

        public string SetEndString(bool endsWithVowel, bool needsEndingVowel)
        {
            if (endsWithVowel && needsEndingVowel) { return "nil"; }
            if (!endsWithVowel && !needsEndingVowel) { return "nil"; }
            if (endsWithVowel && !needsEndingVowel) { return "consonant"; }
            if (!endsWithVowel && needsEndingVowel) { return "vowel"; }
            return "nil";
        }


        //Name Generation - Syllables
        public string GetSyllable(string current, string end = "nil")
        {
            //Here, + is a vowel and - is a consonant.
            string[] syllableBank = { "+-", "-+" };

            bool firstSyllable;
            int seed=0;
            if (string.IsNullOrEmpty(current))
            {
                firstSyllable = true;
                seed = Util.GetRandom(2);
            }
            else
            {
                firstSyllable = false;
                string last = EndingLetter(current);
                seed = Util.StartWithVowel(last)? 1: 0;
            }
            
            string template = syllableBank[seed];

            string consonant = "";
            bool haveConsonant = false;
            while (haveConsonant == false)
            {
                LetterBlock consonantBlock = consonantRepo.blocks[Util.GetRandom(consonantRepo.blocks.Length)];
                if (firstSyllable == false)
                {
                    consonant = consonantBlock.Name;
                    haveConsonant = true;
                }
                else
                {
                    if (consonantBlock.StartName == true)
                    {
                        consonant=consonantBlock.Name;
                        haveConsonant = true;
                    }
                }
            }

            bool haveVowel = false;
            string vowel="";
            while (haveVowel == false)
            {
                LetterBlock vowelBlock = vowelRepo.blocks[Util.GetRandom(vowelRepo.blocks.Length)];
                if (firstSyllable == false)
                {
                    vowel = vowelBlock.Name;
                    haveVowel = true;
                }
                else
                {
                    if (vowelBlock.StartName == true)
                    {
                        vowel = vowelBlock.Name;
                        haveVowel = true;
                    }
                }

            }

            string output;

            switch (end)
            {
                case "nil":
                    {
                        output = template.Replace("+", vowel);
                        output = output.Replace("-", consonant);
                        break;
                    }
                case "consonant":
                    {
                        output = consonantRepo.blocks[Util.GetRandom(consonantRepo.blocks.Length)].Name;
                        break;
                    }
                case "vowel":
                    {
                        output = vowelRepo.blocks[Util.GetRandom(vowelRepo.blocks.Length)].Name;
                        break;
                    }
                default: { output = ""; break; }
            }

            return output;

        }

        public string EndingLetter(string input)
        {
            if (string.IsNullOrEmpty(input)) { return  input; }
            return input.Substring(input.Length - 1);
        }


        public void ExportAll()
        {
            Util.ExportStatementRepo(statementRepo);
            Util.ExportDrugClasses(classRepo);
            Util.ExportBlockRepo(vowelRepo, "Vowels.yaml");
            Util.ExportBlockRepo(consonantRepo,"Consonants.yaml");
        }



    }
}
