using LifeInsWebApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LifeInsWebApp.InsuredAgentOrg.Login
{
    public partial class OrganForgetPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox_numberSendPass.Attributes.Add("OnKeyPress", "javascript:return CheckNumeric(event.keyCode, event.which);");

            ImgHypPass.NavigateUrl = (Request.Url.ToString().Contains("?") ? Request.Url.ToString() : Request.Url.ToString() + "?I=1");

            //for press sendpass after click in captcha textbx or TextBox_Email or txtuid
            TextBox_numberSendPass.Attributes.Add("onkeydown", "javascript:return SendOnEnter('" + Button_Send_Pass.ClientID + "', event)");
            TextBox_Email.Attributes.Add("onkeydown", "javascript:return SendOnEnter('" + Button_Send_Pass.ClientID + "', event)");
            txtUid.Attributes.Add("onkeydown", "javascript:return SendOnEnter('" + Button_Send_Pass.ClientID + "', event)");
            txtUid.Attributes.Add("OnKeyPress", "javascript:return CheckNumeric(event.keyCode, event.which);");
            ShowMessageSendMail();
        }
    
        protected void Button_Send_Pass_Click(object sender, EventArgs e)
        {

            MyError.Text = "";

            txtUid.Text = Safety.SafeSql(txtUid.Text);
            TextBox_Email.Text = Safety.SafeSql(TextBox_Email.Text);


            // check if there is code
            if (txtUid.Text.Length < 8)
            {
                xalert("Please enter Organcode");
                TextBox_numberSendPass.Text = "";
                return;
            }

            // check if there is email
            if (TextBox_Email.Text.Length == 0)
            {
                xalert("Please enter correct Email");
                TextBox_numberSendPass.Text = "";
                return;
            }

            // check if email is valid
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(TextBox_Email.Text);
            if (!match.Success)
            {
                xalert("Please enter correct Email");
                TextBox_numberSendPass.Text = TextBox_Email.Text = "";
                return;
            }

            //چک کردن کد امنیتی
            string number_server_side = (string)Session[ADSSAntiBot.SESSION_CAPTCHA];
            TextBox_numberSendPass.Text = Safety.SafeSql(TextBox_numberSendPass.Text);
            number_server_side = Encryption.EncryptEngine.RawEncrypt(number_server_side, "AcS5Cf");

            if (number_server_side != Encryption.EncryptEngine.RawEncrypt(TextBox_numberSendPass.Text, "AcS5Cf"))
            {

                TextBox_numberSendPass.Text = "";
                Label_invalidSendPass.Visible = true;
                return;
            }
            else
            {
                // check if there is exist same code and email and cheked

                string ret = DataAccessFactory.CreateOrganInsuredData().
                    GetOrganEmail(Convert.ToInt32(txtUid.Text)); 
                if (ret == "0")
                {
                    xalert("چنین دستگاهی با این آدرس پست الکترونیکی شناسایی نشد .");
                    TextBox_numberSendPass.Text = TextBox_Email.Text = "";
                    return;
                }
                else if (ret == "")
                {
                    xalert("پست الکترونیکی دستگاه در سامانه ثبت نگردیده است .");
                    TextBox_numberSendPass.Text = TextBox_Email.Text = "";
                    return;
                }
            }
        }

        protected void btnreturn_Click(object sender, EventArgs e)
        {
            SendPassPnl.Style["display"] = "none";

            txtUid.Text = "";
            TextBox_Email.Text = "";
            TextBox_numberSendPass.Text = "";
            Response.Redirect("http://www.retirement.ir/UnitLogin/Default.aspx");
        }
        protected void ShowMessageSendMail()
        {
            string strError = (Request.QueryString["x"] != null ? Request.QueryString["x"].ToString() : "");
            if (strError == "1")
            {
                divMessage.Visible = true;
                divMessage.InnerText = "The new Password is sent to your email address.";
                divMessage.Style["color"] = "green";

            }
            if (strError == "2")
            {
                divMessage.Visible = true;
                divMessage.InnerText = "Dear User,there is a problem in sending email,please try it again";
                divMessage.Style["color"] = "red";

            }

            if (strError == "3")
            {
                divMessage.Visible = true;
                divMessage.InnerText = "Dear user, your information is not verified by our departmant.";
                divMessage.Style["color"] = "red";

            }
        }
        protected void xalert(string s)
        {
            MyError.Text = "* " + s;
        }
    }
}