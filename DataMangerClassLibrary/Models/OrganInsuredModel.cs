using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMangerClassLibrary.Models
{
    public class OrganInsuredModel
    {
        public int OrganInsuredCode { get; private set; }
        public string OrganInsuredName { get; private set; }
        public string AccountNumber { get; private set; }
        public byte Sepehr { get; private set; }
        public string BankName { get; private set; }
        public int Branch_Code { get; private set; }
        public string Branch_Name { get; private set; }
        public Int64 MaliNo { get; private set; }
        public Int64 Mobile { get; private set; }
        public string TelNo { get; private set; }

    }
}
