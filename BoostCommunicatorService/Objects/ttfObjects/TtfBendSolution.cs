using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostCommunicatorService
{
    public class TtfBendSolution
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public int ManualChanged { get; set; }
        public BendWorkPlace Workplace { get; set; }
        public bool IsReadOnly { get; set; }
        public string LastCalculationTimeStamp { get; set; }
        public int Revision { get; set; }
        public int BasedOnDesignRevision { get; set; }
        public int CompatibleWithDesignRevision { get; set; }
        public string ToolListName { get; set; }
        public string UnfoldingChanged { get; set; }
        public string BendTechnology { get; set; }
        public string BendProgrammingType { get; set; }
        public TtfTiFileResourcePackage[] Problems { get; set; }
        public TtfTiFileResourcePackage[] FileResourcePackages { get; set; }
        public TtfTiWebLink Part { get; set; }
        public bool NcInvalid { get; set; }
        public string AuthorOfLastChange { get; set; }
        public string DateOfLastChange { get; set; }

        public string CreationDate { get; set; }
        public string CreationAuthor { get; set; }
        public TtfTiWebLink Self { get; set; }


        public TtfBendSolution()
        {

        }
    }
}
