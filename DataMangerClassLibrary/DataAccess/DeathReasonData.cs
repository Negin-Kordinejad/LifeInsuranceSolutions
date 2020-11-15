using Cspf.Model.Base;
using System.Configuration;
using System.Data;

namespace DataMangerClassLibrary.DataAccess
{
    public class DeathReasonData : IDeathReasonData
    {
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public DataSet GetAllDeathReaons()
        {
            DataSet ds = CspfDatabaseHelper.SelectInDataSetFromStoredProcedure(
         GetConnectionString("NewCnnStr"), 6000, "Death_Reason_Select", "Table");
            return ds;
        }
    }
}
