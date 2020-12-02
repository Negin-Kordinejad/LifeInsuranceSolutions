
using DataMangerClassLibrary.DataAccess;
using System;
using System.Data;
using System.Web.UI;

namespace LifeInsWebApp.Model
{
    public class Dastgah
    {
        private readonly IOrganInsuredData _organInsuredData;

        //   [MachineCode],[MachineName],[AccountNumber] ,[Sepehr],[BankName] ,[Branch_Code],[Branch_Name],[MaliNo] ,[MobilNo],[TelNo]
        public int DastgahCode { get; private set; }
        public string DastgahName { get; private set; }
        public string AccountNumber { get; private set; }
        public byte Sepehr { get; private set; }
        public string BankName { get; private set; }
        public int Branch_Code { get; private set; }
        public string Branch_Name { get; private set; }
        public Int64 MaliNo { get; private set; }
        public Int64 Mobile { get; private set; }
        public string TelNo { get; private set; }

        public bool IsValid
        {
            get
            {
                return
                    DastgahCode > 0  //Mobile > 0 
                    && string.IsNullOrEmpty(DastgahName);
            }
        }

        public Dastgah(IOrganInsuredData OrganInsuredData)
        {
            DastgahCode = 0;
            DastgahName = "";
            Mobile = 0;
            _organInsuredData = OrganInsuredData;
        }
      
        public void Refresh(int dastgahCode)
        {
            DastgahCode = dastgahCode;
            DastgahName = "";
            Mobile = 0;
           // OrganInsuredData data = new OrganInsuredData();

            DataSet ds = _organInsuredData.GetOrganInsuredData(dastgahCode);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DastgahName = Convert.ToString((ds.Tables[0].Rows[0]["EMachineName"]));
                Mobile = Convert.ToInt64((ds.Tables[0].Rows[0]["MobilNo"]));
                AccountNumber = (ds.Tables[0].Rows[0]["AccountNumber"].ToString());
                BankName = (ds.Tables[0].Rows[0]["BankName"].ToString());
                Branch_Code = Convert.ToInt32((ds.Tables[0].Rows[0]["Branch_Code"]));
                Branch_Name = (ds.Tables[0].Rows[0]["Branch_Name"].ToString());
                MaliNo = Convert.ToInt64((ds.Tables[0].Rows[0]["MaliNo"]));
                TelNo = (ds.Tables[0].Rows[0]["TelNo"].ToString());

            }
        }

        public string GetString()
        {
            return
                "[DP=" + DastgahCode.ToString() +
                ", MO=" + Mobile.ToString() +
                ", ISV=" + IsValid.ToString() +
                               "]";
        }

        public bool Redirect(Page page)
        {
            if (!SessionHelper.Dastgah.IsValid)
            {
                SessionHelper.LogoutDataEntry();
                page.Response.Redirect("~/InsuredAgentOrg/Login/OrganLogin.aspx", false);
                return true;
            }
         

            return false;
        }
    }
}