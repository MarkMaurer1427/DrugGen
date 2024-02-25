namespace DrugGen.DrugValues
{
    public class Statement
    {
        public string Comment { set; get; }
        public string[] DrugClasses { set; get; }
        public string[] Indications { set; get; }


        public Statement(string comment, string[] drugClasses, string[] indications)
        {
            Comment = comment;
            DrugClasses = drugClasses;
            Indications = indications;
        }

        public Statement()
        {
            
        }

        public string[] GetIndications()
        {
            return Indications;
        }

        public string[] GetClasses()
        {
            return DrugClasses;
        }
    }
}
