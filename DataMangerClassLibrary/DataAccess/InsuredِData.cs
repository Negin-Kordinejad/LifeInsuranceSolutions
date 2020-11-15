using Cspf.Model.Base;
using System.Configuration;
using System.Data;

namespace DataMangerClassLibrary.DataAccess
{
    public class InsuredِData : IInsuredِData
    {
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        public DataSet GetInsuredData(long nationalcode, int unitcode)
        {
            DataSet ds = CspfDatabaseHelper.SelectInDataSetFromStoredProcedure(
                  GetConnectionString("NewCnnStr"), 6000, "SP_GetBimehInfo", "Table",
                 CspfDatabaseHelper.GetSqlParameter_BigInt("@Nationalcode", nationalcode),
                 CspfDatabaseHelper.GetSqlParameter_Int("@UnitCode", unitcode)
             );
            return ds;
        }
    }
}
