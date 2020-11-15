using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMangerClassLibrary.Models
{
    public class CLaimBenefitModel
    {
        public long NationalCode { get; set; }
        public int Unitcode { get; set; }
        public int Year { get; set; }
        public string Death_Date { get; set; }
    }
}
