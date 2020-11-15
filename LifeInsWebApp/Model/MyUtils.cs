using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;

/// <summary>
/// Summary description for MyUtils
/// </summary>
/// 


public class nlist
{
    public string[] list;
    public int count;
    public string err;
    public int org_cnt;


    public nlist() { freemem(); }

    ~nlist() { freemem(); }

    public void freemem() { list = null; count = org_cnt = 0; err = ""; }

    public void xset(string xstr)
    {

        char[] splitor ={ '\n' };
        list = xstr.Replace("\r", "").Replace(" ", "").Split(splitor);
        for (count = 0; count < list.Length; count++)
            if (list[count].Length < 5) break;

        err = "";
        for (int i = 0; i < count; i++)
            if (xtest(list[i]) == false)
            {
                int xline = i + 1;
                if (err.Length > 0) err += ",";
                err += xline.ToString();
            }

    }


    public void xset(Stream xstream, int must_cnt)
    {
        StreamReader stream = new StreamReader(xstream);
        xset(stream.ReadToEnd());


        org_cnt = must_cnt;
    }


    public void xset(Stream xstream, string must_cnt)
    {
        StreamReader stream = new StreamReader(xstream);
        xset(stream.ReadToEnd());

        if (must_cnt == "") org_cnt = 0;
        else org_cnt = Convert.ToInt32(must_cnt);
    }


    public bool xtest(string str)
    {
        bool ret = false;
        if (str == "0000000000" || str == "1111111111" || str == "2222222222" || str == "3333333333" || str == "4444444444" || str == "5555555555" || str == "6666666666" || str == "7777777777" || str == "8888888888" || str == "9999999999" || str == "123456789") return ret;
        

        int len = str.Length;
        int xmul = 10;
        int xsum = 0;
        int rem = 0;

        if (len < 5 || len > 10) return ret;

        xmul -= 10 - len;

        for (int i = 0; i < len - 1; i++, xmul--)
            xsum += (int)(str[i] - '0') * xmul;

        int t = (int)(str[len - 1] - '0');


        rem = xsum % 11;


        ret = (((rem < 2) && (t == rem)) || ((rem >= 2) && ((11 - rem) == t)));
        return ret;
    }

};



public class MyUtils
{
	public MyUtils()
	{
		//
		// TODO: Add constructor logic here
		//
	}




    public static string FixMyDate(string dstr)
    {
        string ys, ms, ds;
        string ret;
        int y, m, d;
        int first_slash, last_slah;

        ret = "";

        first_slash = dstr.IndexOf('/');

        if (first_slash == -1) return ret;

        last_slah = dstr.LastIndexOf('/');

        if (last_slah == -1 || last_slah == first_slash || last_slah == first_slash + 1) return ret;

        ys = dstr.Substring(0, first_slash);
        ms = dstr.Substring(first_slash + 1, last_slah - first_slash - 1);
        ds = dstr.Substring(last_slah + 1);

        y = Convert.ToInt32(ys);
        m = Convert.ToInt32(ms);
        d = Convert.ToInt32(ds);

        if (y < 1200 || y > 1500 || m < 1 || m > 12) return ret;
        if (d < 1 || d > 31) return ret;
        if (d == 31 && m > 6) return ret;
        if (d == 30 && m == 12) return ret;

        if (ms.Length == 1) ms = ms.Insert(0, "0");
        if (ds.Length == 1) ds = ds.Insert(0, "0");
        ret = ys + ms + ds;

        return ret;

    }

    public static int persian_jdn(int iYear, int iMonth, int iDay)
    {
        int PERSIAN_EPOCH = 1948321;
        int epbase = 0;
        int epyear = 0;
        int mdays = 0;
        int ret = 0;

        if (iYear >= 0)
            epbase = iYear - 474;
        else
            epbase = iYear - 473;

        epyear = 474 + (epbase % 2820);

        if (iMonth <= 7)
            mdays = (iMonth - 1) * 31;
        else
            mdays = (iMonth - 1) * 30 + 6;

        ret = iDay + mdays + (((epyear * 682) - 110) / 2816) + (epyear - 1) * 365 + (epbase / 2820) * 1029983 + (PERSIAN_EPOCH - 1);

        return ret;

    }


    public static string Reverse(string strValue)
    {
        if (strValue.Length == 1) return strValue;
        else
            return Reverse(strValue.Substring(1)) + strValue.Substring(0, 1);

    }

    public static string DelemitLongNumber(string str)
    {
        string ans = "";
        int idx = 0;

        if (str.Length == 0) return "";

        for (int k = str.Length - 1; k >= 0; k--)
        {
            idx++;
            ans += str[k];
            if ((idx % 3) == 0 && k > 0) ans += ",";
        }
        return Reverse(ans);

    }


    public static int MyDifDate(string d1, string d2) // return in day
    {


        string[] date1 = d1.Split('/');
        string[] date2 = d2.Split('/');




        int id1 = persian_jdn(Int32.Parse(date1[0]), Int32.Parse(date1[1]), Int32.Parse(date1[2]));
        int id2 = persian_jdn(Int32.Parse(date2[0]), Int32.Parse(date2[1]), Int32.Parse(date2[2]));
        return id2 - id1;

    }

    public static string FD2SD(string d)
    {
        if (d.Length == 0) return "";

        return d.Substring(0, 4) + "/" + d.Substring(4, 2) + "/" + d.Substring(6, 2);
    }

    public static string MyReverseDate(string d)
    {
        if (d.Length == 0) return "";
        
        return d.Substring(8, 2)+ "/" +d.Substring(5, 2) + "/"+d.Substring(0, 4);        
        
    }


    public static string MyExecuteScalar(string sql)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NewCnnStr"].ConnectionString);
        connection.Open();
        SqlCommand command = connection.CreateCommand();
        int row_afected;
        string retcode;

        command.CommandText = sql;
        command.CommandTimeout = 1000;
            

        retcode=command.ExecuteScalar ().ToString ();
                                                  

        connection.Close();
        connection = null;
        
        return retcode;
    }


    public static int MyRunSqlNonQueryAndReturnValue(string sql)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NewCnnStr"].ConnectionString);
        connection.Open();
        SqlCommand command = connection.CreateCommand();
        int row_afected;
        string retcode;

        command.CommandText = sql;
        command.CommandTimeout = 1000;
                    
        
        row_afected = command.ExecuteNonQuery();
                                  

        connection.Close();
        connection = null;



        return row_afected;
    }


    public static string MyRunSqlAndReturnValue(string sql)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NewCnnStr"].ConnectionString);
        connection.Open();
        SqlCommand command = connection.CreateCommand();
        SqlDataReader myReader;
        string ret_val = "0";

        myReader = null;


        command.CommandText = sql;
        command.CommandTimeout = 1000;

        myReader = command.ExecuteReader();        

        if (myReader.Read()) ret_val = (myReader[0].ToString());

        myReader.Close(); myReader = null;


        connection.Close();
        connection = null;

        return ret_val;

    }


    public static string SqlScaler(string sql)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NewCnnStr"].ConnectionString);
        connection.Open();
        SqlCommand command = connection.CreateCommand();
                        
        command.CommandText = sql;
        command.CommandTimeout = 1000;

        string ret = command.ExecuteScalar().ToString ();

                
        connection.Close();
        connection = null;

        return ret;

    }


    public static string GetShamsiDate()
    {
        PersianCalendar p = new PersianCalendar();
        string y = p.GetYear(DateTime.Now).ToString("0000");
        string m = p.GetMonth(DateTime.Now).ToString("00");
        string d = p.GetDayOfMonth(DateTime.Now).ToString("00");

        return y + "/" + m + "/" + d;        
    }

    public static string MyXml(string node, string attrib)
    {
        // make sure names are ok
        node = node.ToLower(); attrib = attrib.ToLower();

        

        if (node.Length == 0) return "";

        int start = node.IndexOf(attrib + "=");
        
        if (start < 0) return "";

        start += attrib.Length + 2;
        int endstr = node.IndexOf("\"", start);

        if (endstr < 0) // error
            return null;

        return node.Substring(start, endstr - start);
    }




}
