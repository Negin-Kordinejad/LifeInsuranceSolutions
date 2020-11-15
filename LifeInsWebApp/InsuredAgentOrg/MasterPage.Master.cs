using System;


namespace LifeInsWebApp.InsuredAgentOrg
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //  lblDateValue.Text = DateTime.Now.ToString();

            //  lblSalMahJari.Text = SessionHelper.MahJariName + " " + SessionHelper.SalJari.ToString();
            if (SessionHelper.Dastgah.DastgahName != null)
            {
               
                btnSignOut.Visible = true;
                lblDastgahName.Text = SessionHelper.Dastgah.DastgahName;
                lblDastgahCode.Text = SessionHelper.Dastgah.DastgahCode.ToString();
                lblShomareHesab.Text = SessionHelper.Dastgah.AccountNumber;
                lblBankName.Text = SessionHelper.Dastgah.BankName;
                //lblShabeCode.Text = SessionHelper.Dastgah.Branch_Code.ToString();
                //lblShobe.Text = SessionHelper.Dastgah.Branch_Name;
                lblMaliNo.Text = SessionHelper.Dastgah.MaliNo.ToString();
                lblMobile.Text = SessionHelper.Dastgah.Mobile.ToString();
            }
            else
            {
               btnSignOut.Visible = false;
            }

        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            SessionHelper.Dastgah  = null;
            Response.Redirect("~/InsuredAgentOrg/Login/OrganLogin.aspx", false);
        }
    }
}