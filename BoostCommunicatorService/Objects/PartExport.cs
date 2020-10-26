using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BoostCommunicatorService
{
    public class PartExport
    {
        //Busalt Artikel Nr.
        private string _ItemNo;
        public string ItemNo { get => _ItemNo; }

        //Zähler für änderungen am Teil
        private int _Entry;
        public int Entry { get => _Entry; }

        //MessageType
        private enumMessageType _MessageType;
        public enumMessageType MessageType { get => _MessageType; }

        //Debitoren Artikel Nr.
        private string _PartNoExt;
        public string PartNoExt { get => _PartNoExt; }

        //Artikel Beschreibung
        private string _Description;
        public string Description { get => _Description; }

        //Notiz
        private string _Note;
        public string Note { get => _Note; }

        //Notiz2
        private string _Note2;
        public string Note2 { get => _Note2; }

        //Zeichnungs-Nr.
        private string _DrawingNo;
        public string DrawingNo { get => _DrawingNo; }
        
        //CAD-Filename
        private string _CadFileName;
        public string CadFileName { get => _CadFileName; }

        //CustomerNo
        private string _CustomerNo;
        public string CustomerNo { get => _CustomerNo; }

        //CustomerName
        private string _CustomerName;
        public string CustomerName { get => _CustomerName; }

        //Werkstoff
        private string _BasicMaterial;
        public string BasicMaterial { get => _BasicMaterial; }

        //Rohmaterial
        private string _RawMaterial;
        public string RawMaterial { get => _RawMaterial; }

        public TtfPart _ttf;
        private TtfPart ttf { get => _ttf; }


        public PartExport()
        { }

        public PartExport(navDS.PartExRow r)
        {
            _ItemNo = r.ItemNo;
            _Entry = r.Entry;
            
            Enum.TryParse<enumMessageType>(r.MessageType.ToString(), out _MessageType);

            _PartNoExt = r.PartNoExt;
            _Description = r.Description;
            _Note = r.Note;
            _Note2 = r.Note2;
            _DrawingNo = r.DrawingNo;
            _CadFileName = r.CadFilename;
            _CustomerNo = r.CustomerNo;
            _CustomerName = r.CustomerName;
            _BasicMaterial = r.BasicMaterial;
            _RawMaterial = r.RawMaterial;

            string url = $"Parts/" + _ItemNo + "/ByNameFilter" ;
            //"/ByNameFilter"
            string httpResult = TruTopsApiHelper.InitializeClient_GetAsync(url).Result;
            List<TtfPart> parts = JsonConvert.DeserializeObject<List<TtfPart>>(httpResult);
            //List<TtfPart> parts = JsonConvert.DeserializeObject<TtfPart>(httpResult);
            if (parts.Count == 1)
            { _ttf = parts.First(); }
            _Description = "fertig";

        }

        public bool ExportGeneralInfo()
        {
           if (_ttf != null)
           {
                ttfDS.ArtikelDataTable dt = new ttfDS.ArtikelDataTable();
                ttfDSTableAdapters.ArtikelTA ta = new ttfDSTableAdapters.ArtikelTA();
                ta.UpdateGeneralInfo(_PartNoExt, _Description, _DrawingNo," 2", _Note, _Note2, _ttf.Id, _ttf.Id);
                MessageBox.Show(_ttf.Id.ToString());
           }
           else
            {

            }

            return (true);
        }

        public bool ExportMaterial()
        {
            return (true);
        }

        public bool ExportGeo()
        {
            return (true);
        }

        public bool ExportCAD()
        {
            return (true);
        }

        public bool CreateBendSolutions()
        {
            return (true);
        }

        
    }
}
