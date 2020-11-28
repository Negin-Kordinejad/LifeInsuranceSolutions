using Cspf.Model.Base;
using DataMangerClassLibrary.Helper;
using System.Configuration;
using System.Data;

namespace DataMangerClassLibrary.DataAccess
{
    public class DeathReasonData : IDeathReasonData
    {
        public DataSet GetAllDeathReaons()
        {
            DataSet ds = CspfDatabaseHelper.SelectInDataSetFromStoredProcedure(
          AccessHelper.ConnectionString, 6000, "Death_Reason_Select", "Table");
            return ds;
        }
    }
}
