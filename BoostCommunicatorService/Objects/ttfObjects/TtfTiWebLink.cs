using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostCommunicatorService
{
    public class TtfTiWebLink
    {
        private long _ID;
        public long ID { get => _ID; }

        private long _ItemID;
        public long ItemID { get => _ItemID; }

        private string _Name;
        public string Name { get => _Name; }

        private int _Status;
        public int Status { get => _Status; }

        private int _UpToDate;
        public int UpToDate { get => _UpToDate; }

        private int _ManuallyChanged;
        public int ManuallyChanged { get => _ManuallyChanged; }

        private DateTime _CreationTime;
        public DateTime CreationTime { get => _CreationTime; }

        private string _CreatedBy;
        public string CreatedBy { get => _CreatedBy; }

        private long _AplzID;
        public long AplzID { get => _AplzID; }

        private long _ToolListID;
        public long ToolListID { get => _ToolListID; }

        private int _BendTechnology;
        public int BendTechnology { get => _BendTechnology; }

        public TtfTiWebLink()
        {

        }
    }
}
