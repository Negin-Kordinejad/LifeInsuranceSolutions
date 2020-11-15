using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for xSession
/// </summary>
 public class xSession
{
    public string path, uid, utiter, uaccess;
    public int iuid;
    public int xstate;
    public string state_prefix;
    private static string STD_Header = "[PGS:]";
    private static string exit_page;
    public xSession(string p_uid, string p_utiter, string p_uaccess, int state_idx,string p_exit_path)
    {
        xstate = state_idx;

        if (xstate > 9) state_prefix = xstate.ToString();
        else state_prefix = "0" + xstate.ToString();

        exit_page = p_exit_path;

        uid = p_uid; utiter = p_utiter; uaccess = p_uaccess;        
        iuid = Convert.ToInt32(uid);
    }
    public string exitpage() { return exit_page; } //page is the name of caller
    public static string errpage() { return "~/Default.aspx"; } //page is the name of caller
    public void pushpage(string page) //page is the name of caller
    {
        path += STD_Header + page;        
    }
    public string lastpage() // return last page
    {
        int idx = path.LastIndexOf(STD_Header );
        if (idx < 0) return null;
        return path.Substring(idx + STD_Header.Length);
    }
    public string firstpage() // return last page
    {
        int fidx = path.LastIndexOf(STD_Header); if (fidx < 0) return null;

        int nidx = path.LastIndexOf(STD_Header, STD_Header.Length);

        if (nidx == fidx) return path.Substring(STD_Header.Length);

        return path.Substring(STD_Header.Length, nidx - STD_Header.Length);
    }
    public string poppage() // return and delete last page
    {
        
        int idx = path.LastIndexOf(STD_Header );
        if (idx < 0) return null;
        string last = path.Substring(idx+STD_Header.Length  );

        path=path.Substring(idx );
        return last ;
    }
    //public bool SessionExpired() { return (Session["UserId"] == null); }
    public string GetUserId() { return uid; }
    public int    GetUserIdInt() { return iuid; }
    public string GetStatePrefix() { return state_prefix; }
    public int   GetStateCode() { return xstate; }
    public string GetUserTiter() { return utiter; }
    public bool UserIsState() { return (xstate>0); }
    public bool UserIsSazPart() { return (xstate==0); }
    public bool UserIsAdmin() { return (iuid == 100); }
    public bool UserIsReadOnly() { if (UserIsAdmin()) return false; return (uaccess.IndexOf("[readonly]") >= 0); }
    public bool UserPermission(string s)
    { if (UserIsAdmin()) return true; return (uaccess.IndexOf(s) >= 0); }
}
