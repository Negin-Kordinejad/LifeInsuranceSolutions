using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMangerClassLibrary.Models
{
    public class DepositModel
    {
        public long RowNumber { get; set; }
        public string FishDate { get; set; }
        public int Branch_Code { get; set; }
        public long FishNumber { get; set; }
        public long FishAmount { get; set; }
        public int Belong { get; set; }
    }
}
