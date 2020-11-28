using Cspf.Model.Base;
using DataMangerClassLibrary.Helper;
using System.Configuration;
using System.Data;

namespace DataMangerClassLibrary.DataAccess
{
    public class InsuredِData : IInsuredِData
    {
    
        public DataSet GetInsuredData(long nationalcode, int unitcode)
        {
            DataSet ds = CspfDatabaseHelper.SelectInDataSetFromStoredProcedure(
                   AccessHelper.ConnectionString, 6000, "SP_GetBimehInfo", "Table",
                 CspfDatabaseHelper.GetSqlParameter_BigInt("@Nationalcode", nationalcode),
                 CspfDatabaseHelper.GetSqlParameter_Int("@UnitCode", unitcode)
             );
            return ds;
        }
    }
}
