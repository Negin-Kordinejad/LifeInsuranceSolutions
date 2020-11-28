using LifeInsWebApp.Model;
using System;
using System.Web;

namespace LifeInsWebApp.InsuredAgentOrg.Login
{
    public partial class OrganLogin : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //SessionHelper.Dastgah.Refresh(7010028);6855Y6B7
            //Response.Redirect("~/InsuredAgentOrg/Default.aspx", false);
            SignInUser.Focus();
            SignInUser.Attributes.Add("OnKeyPress", "javascript:return CheckNumeric(event.keyCode, event.which);");
            ImgHyp.NavigateUrl = Request.Url.ToString().Contains("?") ? Request.Url.ToString().Replace("?I=1", "") : Request.Url.ToString();
            TextBox_number.Attributes.Add("OnKeyPress", "javascript:return CheckNumeric(event.keyCode, event.which);");
        }
        protected void btnCancle_Click(object sender, EventArgs e)
        {
            SessionHelper.Dastgah.Refresh(7010028);
            Response.Redirect("~/InsuredAgentOrg/Default.aspx", false);
            //  Response.Redirect("http://retirement.ir");
        }
        protected void SignInBt_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                string number_server_side = (string)Session[ADSSAntiBot.SESSION_CAPTCHA];
                TextBox_number.Text = Safety.SafeSql(TextBox_number.Text);
                number_server_side = Encryption.EncryptEngine.RawEncrypt(number_server_side, "AcS5Cf");
                if (number_server_side != Encryption.EncryptEngine.RawEncrypt(TextBox_number.Text, "AcS5Cf"))
                {
                    Label_invalid.Visible = true;
                    TextBox_number.Text = "";

                    return;
                }
                else
                {
                    SignInUser.Text = SignInUser.Text.Replace("'", "''");
                    SignInPass.Text = SignInPass.Text.Replace("'", "''").Trim();

                    //---------------------------  CHECK FOR EMPTY PASSWORD


                    if (SignInPass.Text.Length == 0)
                    {
                        lblMessage.Text = "Please enter your password";
                        TextBox_number.Text = "";
                        return;
                    }
                    else
                        lblMessage.Text = "";
                    //------------------------------------------------------

                    int tmp;
                    bool useridIsNumeric = int.TryParse(SignInUser.Text, out tmp);
                    if (useridIsNumeric && (SignInUser.Text.Length == 7 || SignInUser.Text.Length == 5 || SignInUser.Text.Length == 1))
                        SignInUser.Text = "0" + SignInUser.Text;

                    if (useridIsNumeric && SignInUser.Text.Length == 8) // check for devices
                    {
                        string xpass = DataAccessFactory.CreateOrganInsuredData()
                            .GetOrganLoginData(Convert.ToInt32(SignInUser.Text));

                        if (SignInUser.Text + SignInPass.Text != xpass)
                        {
                            lblMessage.Text = "Incorrect Username or password";
                            TextBox_number.Text = "";
                            return;
                        }

                        HttpContext.Current.Session.Clear();
                        SessionHelper.Karbar = 0;
                        SessionHelper.Dastgah.Refresh(int.Parse(SignInUser.Text));
                        Response.Redirect("~/InsuredAgentOrg/Default.aspx", false);
                        return;
                    }
                }
                if (SignInPass.Text.Length == 0)
                    return;
            }
        }
    }
}