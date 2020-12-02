
using System.Data;
using DataMangerClassLibrary.Models;
using System.Data.SqlClient;
using System.Configuration;
using DataMangerClassLibrary.Helper;
using Cspf.Model.Base;

namespace DataMangerClassLibrary.DataAccess
{
    public class ClaimData : IClaimData
    {
      
        public DataSet GetBaseBenefit(CLaimBenefitModel model)
        {
            DataSet ds = CspfDatabaseHelper.SelectInDataSetFromStoredProcedure(
              AccessHelper.ConnectionString, 6000, "SP_GetMablagh_Original", "Table",
                      CspfDatabaseHelper.GetSqlParameter_BigInt("@Nationalcode", model.NationalCode),
                       CspfDatabaseHelper.GetSqlParameter_Int("@UnitCode", model.Unitcode),
                       CspfDatabaseHelper.GetSqlParameter_Int("@Year", model.Year),
                         CspfDatabaseHelper.GetSqlParameter_VarChar("@DEATH_DATE", model.Death_Date));
            return ds;
        }
        public string SubmitClaim(ClaimModel model)
        {
            string result = "";
            DataSet ds = CspfDatabaseHelper.SelectInDataSetFromStoredProcedure(
               AccessHelper.ConnectionString, "SP_SAVE_Gharamat",
                       CspfDatabaseHelper.GetSqlParameter_BigInt("@Nationalcode", model.NationalCode),
                       CspfDatabaseHelper.GetSqlParameter_Int("@Unit_Code", model.UnitCode),
                       CspfDatabaseHelper.GetSqlParameter_VarChar("@AccsidentDate", model.AccsidentDate),
                       CspfDatabaseHelper.GetSqlParameter_Int("@Death_Reason_Id", model.Death_Reason_Id),
                       CspfDatabaseHelper.GetSqlParameter_VarChar("@elatefot", model.Elatefot),
                       CspfDatabaseHelper.GetSqlParameter_VarChar("@elatenaqseozv", model.Elatenaqseozv),
                       CspfDatabaseHelper.GetSqlParameter_Int("@Disable_Reason_Id", model.Disable_Reason_Id),
                       CspfDatabaseHelper.GetSqlParameter_Int("@naqsozvitems", model.NaqsozvItems),
                       CspfDatabaseHelper.GetSqlParameter_Int("@GharamatValue", model.GharamatValue),
                       CspfDatabaseHelper.GetSqlParameter_Int("@OriginalGharamatValue", model.OriginalGharamatValue),
                       CspfDatabaseHelper.GetSqlParameter_VarChar("@AccountNo", model.AccountNo),
                       CspfDatabaseHelper.GetSqlParameter_VarChar("@BankName", model.BankName),
                       CspfDatabaseHelper.GetSqlParameter_Int("@BankCode", model.BankCode),
                       CspfDatabaseHelper.GetSqlParameter_VarChar("@RegDate", model.RegDate),
                       CspfDatabaseHelper.GetSqlParameter_Int("@RegUserId", model.RegUserId),
                       CspfDatabaseHelper.GetSqlParameter_Int("@FormId", model.FormId),
                       new SqlParameter("@KartemeliImage", SqlDbType.VarBinary, 1000000) { Value = model.KartemeliImage },
                       new SqlParameter("@GavahifotImage", SqlDbType.VarBinary, 1000000) { Value = model.GavahifotImage },
                       CspfDatabaseHelper.GetSqlParameter_TinyInt("@GharamatType", model.GharamatType),
                       CspfDatabaseHelper.GetSqlParameter_Table("@DisableTable", model.DisableTable, "GharamatDisableType"),
                       CspfDatabaseHelper.GetSqlParameter_VarChar("@Mobiles", model.Mobiles));

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                result = ds.Tables[0].Rows[0][0].ToString();
            }
            return result;
        }
        public DataSet GetClaimRecords(int organinsuredcode, int year)
        {
            DataSet ds = CspfDatabaseHelper.SelectInDataSetFromStoredProcedure(
                AccessHelper.ConnectionString, 6000, "SP_GetGharamatList_ForUnit", "Table",
                   CspfDatabaseHelper.GetSqlParameter_Int("@UnitCode", organinsuredcode),
                    CspfDatabaseHelper.GetSqlParameter_Int("@Year", year));
            return ds;
        }
    }
}
