using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMangerClassLibrary.Models
{
    public class ContractModel
    {
        private int _contractType ;
        private string _contractDate ;
        private int _status ;
        private long _organinsuredcode ;
        private int _worker_num ;
        private int _worker_start;
        private int _worker_time;
        private long _worker_pay;
        private int _ourbaz_num ;
        private int _ourbaz_start;
        private int _ourbaz_time;
        private long _ourbaz_pay;
        private int _otherbaz_num;
        private int _otherbaz_start;
        private int _otherbaz_time;
        private long _otherbaz_pay;
        private int _timeoff_num ;
        private int _timeoff_start ;
        private int _timeoff_time ;
        private long _timeoff_pay ;
        private long _contract_prize ;
        private long _deposit_sum ;
        private int _contractYearMonth ;
        private int _wo_old ;
        private int _ou_old ;
        private int _ot_old ;
        private DataTable _depositItems ;
        public int ContractType { get; set; }
        public string ContractDate { get; set; }
        public int Status { get; set; }
        public long Organinsuredcode { get; set; }
        public int Worker_num { get; set; }
        public int Worker_start { get; set; }
        public int Worker_time { get; set; }
        public long Worker_pay { get; set; }
        public int Ourbaz_num { get; set; }
        public int Ourbaz_start { get; set; }
        public int Ourbaz_time { get; set; }
        public long Ourbaz_pay { get; set; }
        public int Otherbaz_num { get; set; }
        public int Otherbaz_start { get; set; }
        public int Otherbaz_time { get; set; }
        public long Otherbaz_pay { get; set; }
        public int Timeoff_num { get; set; }
        public int Timeoff_start { get; set; }
        public int Timeoff_time { get; set; }
        public long Timeoff_pay { get; set; }
        public long Contract_prize { get; set; }
        public long Deposit_sum { get; set; }
        public int ContractYearMonth { get; set; }
        public int Wo_old { get; set; }
        public int Ou_old { get; set; }
        public int Ot_old { get; set; }
        public DataTable DepositItems { get; set; }
  
    }
}
