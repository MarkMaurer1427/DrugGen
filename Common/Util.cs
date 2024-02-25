using DrugGen.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using DrugGen.Name;

namespace DrugGen.Common
{
    public static class Util
    {
        static char[] vowels = { 'a','e','i','o','u' };

        public static bool StartWithVowel(string input)
        {
            if (input == "") { return false; }
            char firstLetter = input[0];
            return vowels.Contains(firstLetter); 
        }

        public static int GetRandom(int max)
        {
            Random rand = new Random();
            return rand.Next(max);
        }

        public static string Serialize(Object o)
        {
            var serializer = new YamlDotNet.Serialization.Serializer();
            var yaml = serializer.Serialize(o);
            return yaml;
        }

        public static DrugClassRepo ImportDrugClasses()
        {
            var deserializer = new DeserializerBuilder().Build();
            string fileName = "DrugClasses.yaml";
            string yaml = File.ReadAllText(fileName);
            DrugClassRepo repo = deserializer.Deserialize<DrugClassRepo>(yaml);
            return repo;
        }

        public static StatementRepo ImportDrugStatements()
        {
            var deserializer = new DeserializerBuilder().Build();
            string fileName = "DrugStatements.yaml";
            string yaml = File.ReadAllText(fileName);
            StatementRepo repo = deserializer.Deserialize<StatementRepo>(yaml);
            return repo;
        }

        public static BlockRepo ImportBlockRepo(string fileName)
        {
            var deserializer = new DeserializerBuilder().Build();
            string yaml = File.ReadAllText(fileName);
            BlockRepo repo = deserializer.Deserialize<BlockRepo>(yaml);
            return repo;
        }

        public static void ExportStatementRepo(StatementRepo repo)
        {
            var yaml = Serialize(repo);
            string fileName = "DrugStatements.yaml";
            File.WriteAllText(fileName, yaml);
        }

        public static void ExportDrugClasses(DrugClassRepo repo)
        {
            var yaml = Serialize(repo);
            string fileName = "DrugClasses.yaml";
            File.WriteAllText(fileName,yaml);
        }

        public static void ExportBlockRepo(BlockRepo repo, string fileName)
        {
            var yaml = Serialize(repo);
            File.WriteAllText(fileName, yaml);
        }
    }
}
