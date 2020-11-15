using Cspf.Model.Base;
using System.Configuration;
using System.Data;


namespace DataMangerClassLibrary.DataAccess
{
    public class DepositData : IDepositData
    {
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        public DataSet CheckDepositValues(DataTable dt)
        {
            DataSet ds = CspfDatabaseHelper.SelectInDataSetFromStoredProcedure(
                GetConnectionString("NewCnnStr"), 6000, "SP_CheckDepositValues", "Table",
                   CspfDatabaseHelper.GetSqlParameter_Table("@DepositValuesTable", dt, "FishValueTable"));
            return ds;
        }
    }
}
