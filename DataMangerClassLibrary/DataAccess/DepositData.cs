
using Cspf.Model.Base;
using DataMangerClassLibrary.Helper;
using System.Configuration;
using System.Data;


namespace DataMangerClassLibrary.DataAccess
{
    public class DepositData : IDepositData
    {
        
        public DataSet CheckDepositValues(DataTable dt)
        {
            DataSet ds = CspfDatabaseHelper.SelectInDataSetFromStoredProcedure(
                 AccessHelper.ConnectionString, 6000, "SP_CheckDepositValues", "Table",
                   CspfDatabaseHelper.GetSqlParameter_Table("@DepositValuesTable", dt, "FishValueTable"));
            return ds;
        }
    }
}
