using Cspf.Model.Base;
using DataMangerClassLibrary.Helper;
using System.Configuration;
using System.Data;


namespace DataMangerClassLibrary.DataAccess
{
    public class DisableTypesData : IDisableTypesData
    {
      
        public DataSet GetAllDisableTypes()
        {
            DataSet ds = CspfDatabaseHelper.SelectInDataSetFromStoredProcedure(
               AccessHelper.ConnectionString, 6000, "Disable_Types_Select", "Table");
            return ds;
        }
    }
}
