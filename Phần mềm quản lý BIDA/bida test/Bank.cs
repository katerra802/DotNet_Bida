using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bida_test
{
    public class Datum
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string bin { get; set; }
        public string shortName { get; set; }
        public string logo { get; set; }
        public int transferSupported { get; set; }
        public int lookupSupported { get; set; }
        public string short_name { get; set; }
        public int support { get; set; }
        public int isTransfer { get; set; }
        public string swift_code { get; set; }
    }

    public class Bank
    {
        public string code { get; set; }
        public string desc { get; set; }
        public Datum data { get; set; }

        public Bank()
        {
            data = new Datum();
            data.id = 43;
            data.name = "Ngân hàng TMCP Ngoại Thương Việt Nam";
            data.code = "VCB";
            data.bin = "970436";
            data.shortName = "Vietcombank";
            data.logo = "https://api.vietqr.io/img/VCB.png";
            data.transferSupported = 1;
            data.lookupSupported =  1;
            data.short_name = "Vietcombank";
            data.support = 3;
            data.isTransfer = 1;
            data.swift_code = "BFTVVNVX";
        }
    }

}
