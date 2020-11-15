using Cspf.Model.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace BimeOmr.Web.Model
{
    public class Zihesab
    {
        public Int64 SelectedRecordOid { get; set; }
        public int SelectedRecordSal { get; set; }
        public int SelectedRecordMah { get; set; }

        public Int64 MahJariOid { get; private set; }
        public int DastgahPardakhtCode { get; private set; }
        public int ShahrPardakhtCode { get; private set; }
        public string DastgahPardakhtName { get; private set; }
        public string ShahrPardakhtName { get; private set; }
        public Int64 Mobile { get; private set; }
        public int NumTaaholOlad { get; private set; }
        public int NumSayer { get; private set; }
        public bool IsClosed { get; set; }
        public int Ostan { get; set; }
        public string OstanWebAddress { get; set; }
        public bool TaaholOladDetailIsReceived { get; set; }
        public int TedadBazneshastZende { get; set; }
        public bool NazarsanjiDone { get; set; }
        public string Name { get; set; }
        public string Famil { get; set; }

        public bool IsValid
        {
            get
            {
                return
                    DastgahPardakhtCode > 0 && ShahrPardakhtCode > 0 &&
                    //Mobile > 0 &&
                    !string.IsNullOrEmpty(DastgahPardakhtName) &&
                    !string.IsNullOrEmpty(ShahrPardakhtName);
            }
        }

        public Zihesab()
        {
            DastgahPardakhtCode = 0;
            DastgahPardakhtName = "";
            ShahrPardakhtCode = 0;
            ShahrPardakhtName = "";
            Mobile = 0;
            NumTaaholOlad = 0;
            NumSayer = 0;
            IsClosed = true;
            TaaholOladDetailIsReceived = false;
            NazarsanjiDone = false;
        }

        public void Refresh(int dastgahPardakhtCode, int shahrPardakhtCode)
        {
            DastgahPardakhtCode = dastgahPardakhtCode;
            DastgahPardakhtName = "";
            ShahrPardakhtCode = shahrPardakhtCode;
            ShahrPardakhtName = "";
            Mobile = 0;
            NumTaaholOlad = 0;
            NumSayer = 0;
            IsClosed = true;
            TaaholOladDetailIsReceived = false;
            NazarsanjiDone = false;

            DataSet ds = CspfDatabaseHelper.SelectInDataSetFromStoredProcedure(
                SessionHelper.ConnectionString, 6000, "SGetZihesabInfo", "Table",
                CspfDatabaseHelper.GetSqlParameter_Int("DastgahPardakhtCode", dastgahPardakhtCode),
                CspfDatabaseHelper.GetSqlParameter_Int("ShahrPardakhtCode", shahrPardakhtCode)
            );
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
               
                MahJariOid = Convert.ToInt64((ds.Tables[0].Rows[0]["OidVaziatZihesab"]));
                DastgahPardakhtName = Convert.ToString((ds.Tables[0].Rows[0]["DastgahPardakhtName"]));
                ShahrPardakhtName = Convert.ToString((ds.Tables[0].Rows[0]["ShahrPardakhtName"]));
                Mobile = Convert.ToInt64((ds.Tables[0].Rows[0]["Mobile"]));
                NumTaaholOlad = Convert.ToInt32((ds.Tables[0].Rows[0]["NumTaaholOlad"]));
                NumSayer = Convert.ToInt32((ds.Tables[0].Rows[0]["NumSayer"]));
                IsClosed = Convert.ToBoolean((ds.Tables[0].Rows[0]["IsClosed"]));
                Ostan = Convert.ToInt32((ds.Tables[0].Rows[0]["Ostan"]));
                OstanWebAddress = Convert.ToString((ds.Tables[0].Rows[0]["OstanWebAddress"]));
                TaaholOladDetailIsReceived = Convert.ToBoolean((ds.Tables[0].Rows[0]["TaaholOladDetailIsReceived"]));
                TedadBazneshastZende = Convert.ToInt32((ds.Tables[0].Rows[0]["TedadBazneshastZende"]));
                NazarsanjiDone = Convert.ToBoolean((ds.Tables[0].Rows[0]["NazarsanjiDone"]));
                Name = Convert.ToString((ds.Tables[0].Rows[0]["Name"]));
                Famil = Convert.ToString((ds.Tables[0].Rows[0]["Famil"]));
            }
        }

        public string GetString()
        {
            return
                "[DP=" + DastgahPardakhtCode.ToString() +
                ", SP=" + ShahrPardakhtCode.ToString() +
                ", MO=" + Mobile.ToString() +
                ", ISC=" + IsClosed.ToString() +
                ", ISV=" + IsValid.ToString() +
                ", NSD=" + (NazarsanjiDone ? "1" : "0") +
                "]";
        }

        public bool Redirect(Page page)
        {
            if (!SessionHelper.Zihesab.IsValid)
            {
                SessionHelper.LogoutDataEntry();
                page.Response.Redirect("http://cspf.ir/UnitLogin/Default.aspx", false);
                return true;
            }
            if (!SessionHelper.Zihesab.NazarsanjiDone)
            {
                page.Response.Redirect("~/Nazarsanji.aspx", false);
                return true;
            }
            return false;
        }
    }
}