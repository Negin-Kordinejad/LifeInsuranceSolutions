using Cspf.Model.Base;
using System.Configuration;
using System.Data;


namespace DataMangerClassLibrary.DataAccess
{
    public class DisableTypesData : IDisableTypesData
    {
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        public DataSet GetAllDisableTypes()
        {
            DataSet ds = CspfDatabaseHelper.SelectInDataSetFromStoredProcedure(
              GetConnectionString("NewCnnStr"), 6000, "Disable_Types_Select", "Table");
            return ds;
        }
    }
}
