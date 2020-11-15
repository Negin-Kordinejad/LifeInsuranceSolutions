using Cspf.Model.Base;
using System.Configuration;
using System.Data;


namespace DataMangerClassLibrary.DataAccess
{
    public class OrganInsuredData : IOrganInsuredData
    {
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public DataSet GetOrganInsuredData(int organinsuredcode)
        {
            DataSet ds = CspfDatabaseHelper.SelectInDataSetFromStoredProcedure(
                GetConnectionString("NewCnnStr"), 6000, "SP_GetDastgahInfo", "Table",
                 CspfDatabaseHelper.GetSqlParameter_Int("@DastgahCode", organinsuredcode));
            return ds;

        }

        public string GetOrganLoginData(int organinsuredcode)
        {
            string result = "";
            DataSet ds = CspfDatabaseHelper.SelectInDataSetFromStoredProcedure(
                GetConnectionString("NewCnnStr"), 6000, "SP_GetOrganLoginInfo", "Table",
                 CspfDatabaseHelper.GetSqlParameter_Int("@DastgahCode", organinsuredcode));
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                result = ds.Tables[0].Rows[0][0].ToString();
            }
            return result;
        }

        public string GetOrganEmail(int organinsuredcode)
        {
            string result = "";
            DataSet ds = CspfDatabaseHelper.SelectInDataSetFromStoredProcedure(
                GetConnectionString("NewCnnStr"), 6000, "SP_GetOrganEmailInfo", "Table",
                 CspfDatabaseHelper.GetSqlParameter_Int("@DastgahCode", organinsuredcode));
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                result = ds.Tables[0].Rows[0][0].ToString();
            }
            return result;
        }

    }
}