using System;

namespace BoostCommunicatorService
{
    public class TtfPart
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ExternalName { get; set; }
        public string Designation { get; set; }
        public string Comment { get; set; }
        public bool IsAssembly { get; set; }
        public string Beschaffungsart { get; set; }
        public string DisplayMenge { get; set; }
        public string Bestandseinheit { get; set; }


        //public TtfTiWebLink Design { get; set; }
        //public TtfTiWebLink Attribute { get; set; }
        //public TtfTiWebReference[] BendSolutions { get; set; }

        //public TtfBendSolution bsB03 { get; set; }
        //public TtfBendSolution bsB23 { get; set; }

        //public int NoOfBendSolutionsForB03 { get; set; }
        //public int NoOfBendSolutionsForB23 { get; set; }

        public string CreationType { get; set; }
        //public TtfTiWebLink Self { get; set; }
        public string CreationDate { get; set; }
        public string CreationAuthor { get; set; }
        public string DateOfLastChange { get; set; }
        public string AuthorOfLastChange { get; set; }







        public TtfPart()
        { }

        

        

        
    }
}
