using Cspf.Model.Base;
using DataMangerClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace DataMangerClassLibrary.DataAccess
{
    public class ContractData : IContractData
    {
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        public DataSet GetContractInit(int organinsuredcode)
        {
            DataSet ds = CspfDatabaseHelper.SelectInDataSetFromStoredProcedure(
                GetConnectionString("NewCnnStr"), 6000, "Contract_Init_Get", "Table",
                   CspfDatabaseHelper.GetSqlParameter_Int("@UnitCode", organinsuredcode));
            return ds;
        }
        public string SubmitContract(ContractModel model)
        {
            string result = "";
            DataSet ds = CspfDatabaseHelper.SelectInDataSetFromStoredProcedure(
               GetConnectionString("NewCnnStr"), "Sp_Save_Contract",
                    CspfDatabaseHelper.GetSqlParameter_Int("@status", model.Status),
                    CspfDatabaseHelper.GetSqlParameter_Int("@unitcode", model.Organinsuredcode),
                    CspfDatabaseHelper.GetSqlParameter_VarChar("@contractdate", model.ContractDate),
                    CspfDatabaseHelper.GetSqlParameter_Int("@worker_num", model.Worker_num),
                    CspfDatabaseHelper.GetSqlParameter_Int("@worker_start", model.Worker_start),
                    CspfDatabaseHelper.GetSqlParameter_Int("@worker_time", model.Worker_time),
                    CspfDatabaseHelper.GetSqlParameter_BigInt("@worker_pay", model.Worker_pay),
                    CspfDatabaseHelper.GetSqlParameter_Int("@ourbaz_start", model.Ourbaz_start),
                    CspfDatabaseHelper.GetSqlParameter_Int("@ourbaz_time", model.Ourbaz_time),
                    CspfDatabaseHelper.GetSqlParameter_Int("@ourbaz_num", model.Ourbaz_num),
                    CspfDatabaseHelper.GetSqlParameter_BigInt("@ourbaz_pay", model.Ourbaz_pay),
                    CspfDatabaseHelper.GetSqlParameter_Int("@otherbaz_num", model.Otherbaz_num),
                    CspfDatabaseHelper.GetSqlParameter_Int("@otherbaz_start", model.Otherbaz_start),
                    CspfDatabaseHelper.GetSqlParameter_Int("@otherbaz_time", model.Otherbaz_time),
                    CspfDatabaseHelper.GetSqlParameter_BigInt("@otherbaz_pay", model.Otherbaz_pay),
                    CspfDatabaseHelper.GetSqlParameter_Int("@timeoff_num", model.Timeoff_start),
                    CspfDatabaseHelper.GetSqlParameter_Int("@timeoff_start", model.Timeoff_start),
                    CspfDatabaseHelper.GetSqlParameter_Int("@timeoff_time", model.Timeoff_time),
                    CspfDatabaseHelper.GetSqlParameter_BigInt("@timeoff_pay", model.Timeoff_pay),
                    CspfDatabaseHelper.GetSqlParameter_BigInt("@contract_prize", model.Contract_prize),
                    CspfDatabaseHelper.GetSqlParameter_BigInt("@Deposit_sum", model.Deposit_sum),
                    CspfDatabaseHelper.GetSqlParameter_Int("@cym", model.ContractYearMonth),
                    CspfDatabaseHelper.GetSqlParameter_Int("@wo_old", model.Wo_old),
                    CspfDatabaseHelper.GetSqlParameter_Int("@ou_old", model.Ou_old),
                    CspfDatabaseHelper.GetSqlParameter_Int("@ot_old", model.Ot_old)
                        );

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                result = ds.Tables[0].Rows[0][0].ToString();
            }
            return result;
        }


    }
}
