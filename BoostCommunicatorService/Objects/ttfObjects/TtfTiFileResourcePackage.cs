using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostCommunicatorService
{
    public class TtfTiFileResourcePackage
    {

        public TtfTiFileResourcePackage[] Children { get; set; }
        public string Id { get; set; }
        public string FilePath { get; set; }
        public string Type { get; set; }
        public int Length { get; set; }
        public string DateOfLastChange { get; set; }
        public string Checksum { get; set; }
        public TtfTiWebLink Data { get; set; }
        public string DataContent { get; set; }
        public TtfTiWebLink Self { get; set; }



        public TtfTiFileResourcePackage()
        {

        }
    }
}
