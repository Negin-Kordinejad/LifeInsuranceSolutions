using Encryption;
using LifeInsWebApp.Model;
using System;
using System.Configuration;
using System.Data;
using System.Web;

namespace LifeInsWebApp
{
    public static class SessionHelper
    {
       
        const string dastgahKey = "DastgahGharamat";
        //   private const string codeDastgahKey = "UnitCode";
        const string karbarKey = "Karbar";
        const string karbarTypeKey = "KarbarType";
        const string karbarPermisionKey = "karbarPermision";
        const string karbarStateKey = "karbarState";
        const string karbarNameKey = "KarbarName";
        const string ProvCodeKey = "ProvCode";

        public static Model.Dastgah Dastgah
        {
            get
            {
                if (HttpContext.Current.Session[dastgahKey] == null)
                    HttpContext.Current.Session[dastgahKey] = DataAccessFactory.CreateDastgah();
                return (Model.Dastgah)HttpContext.Current.Session[dastgahKey];
            }
            set { HttpContext.Current.Session[dastgahKey] = value; }
        }
        public static int KarbarState
        {
            get
            {
                int KarbarState = 0;
                int.TryParse(HttpContext.Current.Session[karbarStateKey] == null ? "0" : HttpContext.Current.Session[karbarStateKey].ToString(), out KarbarState);
                return KarbarState;
            }
            set
            {
                //if (Dastgah != 0)
                //    Dastgah = 0;
                HttpContext.Current.Session[karbarStateKey] = value;
            }
        }
        public static string KarbarName
        {
            get
            {
                return (HttpContext.Current.Session[karbarNameKey]) == null ? "" : HttpContext.Current.Session[karbarNameKey].ToString();

            }
        }
        public static int KarbarGroup
        {
            get
            {
                return convert(HttpContext.Current.Session[karbarPermisionKey]);
            }
            set
            {
                //if (Dastgah != 0)
                //    Dastgah = 0;
                HttpContext.Current.Session[karbarPermisionKey] = value;
            }
        }
        public static Int32 ProvCode
        {
            get
            {
                Int32 ProvCode = 0;
                Int32.TryParse(HttpContext.Current.Session[ProvCodeKey] == null ? "0" : HttpContext.Current.Session[ProvCodeKey].ToString(), out ProvCode);
                return ProvCode;
            }
        }
        public static string ServerName { get { return ConfigurationManager.AppSettings["ServerName"]; } }

        public static Int64 NationalCode
        {
            get
            {
                Int64 tmp;
                Int64.TryParse(HttpContext.Current.Session["NationalCode"] == null ? "0" : HttpContext.Current.Session["NationalCode"].ToString(), out tmp);
                return tmp;
            }
            set
            {
                HttpContext.Current.Session["NationalCode"] = value;
            }
        }
        public static int Serial
        {
            get
            {
                int tmp;
                int.TryParse(HttpContext.Current.Session["Serial"] == null ? "0" : HttpContext.Current.Session["Serial"].ToString(), out tmp);
                return tmp;
            }
            set
            {
                HttpContext.Current.Session["Serial"] = value;
            }
        }

        public static int MarhaleNo
        {
            get
            {
                int tmp;
                int.TryParse(HttpContext.Current.Session["MarhaleNo"] == null ? "0" : HttpContext.Current.Session["MarhaleNo"].ToString(), out tmp);
                return tmp;
            }
            set
            {
                HttpContext.Current.Session["MarhaleNo"] = value;
            }
        }

      
       

        public static void ClearSession(string propertyName)
        {
            HttpContext.Current.Session.Remove(propertyName);
        }

        public static void ClearAllSessions()
        {
            HttpContext.Current.Session.RemoveAll();
        }

        public static void LogoutDataEntry()
        {
            ClearAllSessions();
        }

        public static bool Login(string ac, string cdt)
        {
            LogoutDataEntry();

            ////////////////////////////////////////// For Real operation ////////////////////////////
            bool qsvalid = false;
            string dateTime;
            int sal, mah, rooz, saat, daghighe, sanieh;
            int dastgah;
            DateTime qsnow, now = DateTime.Now;

            try
            {
                dateTime = EncryptEngine.RawDecrypt(cdt, "BimeOmrWeb");
                int.TryParse(dateTime.Substring(0, 4), out sal);
                int.TryParse(dateTime.Substring(4, 2), out mah);
                int.TryParse(dateTime.Substring(6, 2), out rooz);
                int.TryParse(dateTime.Substring(8, 2), out saat);
                int.TryParse(dateTime.Substring(10, 2), out daghighe);
                int.TryParse(dateTime.Substring(12, 2), out sanieh);
                qsnow = new DateTime(sal, mah, rooz, saat, daghighe, sanieh);
                qsvalid = (now - qsnow).Days == 0 && (now - qsnow).Hours == 0 && (now - qsnow).Minutes <= 10;
                if (qsvalid)
                {
                    int.TryParse(EncryptEngine.RawDecrypt(ac, "BimeOmrWeb"), out dastgah);
                    //int.TryParse(EncryptEngine.RawDecrypt(ct, "BimeOmrWeb"), out shahr);
                    Dastgah.Refresh(dastgah);
                }
                else
                {
                    Dastgah.Refresh(-1);
                }
                qsvalid = qsvalid && Dastgah.IsValid;
            }
            catch (Exception exp)
            {
                DataAccessFactory.Log().LogException(exp,"","","666999");
                LogoutDataEntry();
                qsvalid = false;
            }
            return qsvalid;
            ////////////////////////////////////////// End Real operation ////////////////////////////

            ////////////////////////////////////////// For Test uncomment following lines ////////////
            //Dastgah.Refresh(1942, 10111);
            //return Dastgah.IsValid;
            ////////////////////////////////////////// End Test //////////////////////////////////////
        }

        
        public static int Karbar
        {
            get
            {
                int karbar = 0;
                int.TryParse(HttpContext.Current.Session[karbarKey] == null ? "0" : HttpContext.Current.Session[karbarKey].ToString(), out karbar);
                return karbar;
            }
            set
            {


                HttpContext.Current.Session[karbarTypeKey] = 0;
                HttpContext.Current.Session[karbarKey] = value;
                if (value > 0)
                {
                    getKarbarGroupAndProvCode();
                }
            }
        }
        private static void getKarbarGroupAndProvCode()
        {
            DataSet dsInfo = new DataSet();
            //    CspfDatabaseHelper.SelectInDataSetFromStoredProcedure(
            //    ConfigurationManager.ConnectionStrings["NewCnnStr"].ConnectionString, "KarbarSazmanGetInfo_S",
            //    new SqlParameter("@KarbarCode", Karbar)
            //);
            if (dsInfo.Tables.Count > 0 && dsInfo.Tables[0].Rows.Count > 0)
            {
                HttpContext.Current.Session[karbarNameKey] = dsInfo.Tables[0].Rows[0]["Name"];
                KarbarState = convert(dsInfo.Tables[0].Rows[0]["IsActive"]);
                KarbarGroup = convert(dsInfo.Tables[0].Rows[0]["UserGroup"]);

                if (dsInfo.Tables[0].Rows.Count > 1)
                    HttpContext.Current.Session[ProvCodeKey] = 0;


            }
            else
            {
                HttpContext.Current.Session[karbarPermisionKey] = -1;
                HttpContext.Current.Session[ProvCodeKey] = -1;
                HttpContext.Current.Session[karbarPermisionKey] = -1;
            }
        }
        private static int convert(object obj)
        {
            int result = 0;
            int.TryParse(obj == null || obj.GetType() == typeof(DBNull) ? "0" : obj.ToString() == "True" ? "1" : obj.ToString(), out result);
            return result;
        }
    }
}