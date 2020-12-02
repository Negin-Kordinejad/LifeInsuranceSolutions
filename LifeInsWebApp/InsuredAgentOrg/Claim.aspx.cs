using System;
using System.Data;
using System.Web.UI.WebControls;
using LifeInsWebApp.Model;
using LifeInsWebApp.Helper;
using DataMangerClassLibrary.Models;

namespace LifeInsWebApp.InsuredAgentOrg
{

    //This for DevOps
    public partial class Claim : System.Web.UI.Page
    {
        private ILogger _logger = DataAccessFactory.Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtNationalCode.Focus();
            RdbChangeReason.Attributes.Add("onchange", "return  selectValue();");
            txtNationalCode.Attributes.Add("onkeypress", "return fnAllowOnlyDigits();");
            txtHadeseDate.Attributes.Add("maxlength", "10");
            txtHadeseDate.Attributes.Add("onkeydown ", "return IsNumeric(this);");
            txtHadeseDate.Attributes.Add("onkeyup", "return ValidateDateFormat(this);");
            if (!IsPostBack)
            {
                DataSet ds = DataAccessFactory.CreateDeathReasonData().GetAllDeathReaons();

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DrdHadeseReason.DataSource = ds;
                    DrdHadeseReason.DataBind();
                }
                DrdNaghType.Items.Add("Desease");
                DrdNaghType.Items.Add("Accssident");
                //DisableTypesData data1 = new DisableTypesData(); 
                //data1.GetAllDisableTypes();
                DataSet ds1 = DataAccessFactory.CreateDisableTypeData().GetAllDisableTypes();
                if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                {
                    ListNaghsType.DataSource = ds1;
                    ListNaghsType.DataBind();
                }
            }
        }
        protected void btnSearchNationalCode_Click(object sender, EventArgs e)
        {
            lblkhata1.Text = "";
            RdbChangeReason.SelectedIndex = 0;
            txtHadeseDate.Text = "";
            //   txtMobile.Text = "";
            lblShowMablagh.Text = "";
            SessionHelper.ClearSession("FinalMablagh");
            SessionHelper.ClearSession("OriginalMablagh");
            hidImage.Dispose();
            hidImage2.Dispose();
            foreach (ListItem item in ListNaghsType.Items)
            {
                if (item.Selected)
                {
                    ListNaghsType.SelectedItem.Selected = false;
                }
            }

            if (txtNationalCode.Text.Trim().Length > 0)
            {
                lblkhata1.Text = "";
                //InsuredِData data = new InsuredِData();
                DataSet ds = DataAccessFactory.CreateInsuredData().GetInsuredData(Convert.ToInt64(txtNationalCode.Text), SessionHelper.Dastgah.DastgahCode);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Columns.Count > 0 && ds.Tables[0].Columns[0].ColumnName == "KHATA")
                    {
                        lblkhata1.Text = ds.Tables[0].Rows[0]["KHATA"].ToString().Trim();
                        DivPersonInfo.Visible = false;
                        DivInfoPart1.Visible = false;
                    }
                    else if (ds.Tables[0].Columns.Count > 0)
                    {
                        lblName.Text = Convert.ToString((ds.Tables[0].Rows[0]["Name"]));
                        lblFamily.Text = Convert.ToString((ds.Tables[0].Rows[0]["Family"]));
                        lblBirthdate.Text = Convert.ToString((ds.Tables[0].Rows[0]["birthdate"]));
                        lblDafterKol.Text = Convert.ToString((ds.Tables[0].Rows[0]["Daftar_No"]));
                        lblContractDate.Text = Convert.ToString((ds.Tables[0].Rows[0]["cdate"]));
                        lblJobKind.Text = Convert.ToString((ds.Tables[0].Rows[0]["PersonBimeType_Desc"]));
                        DivPersonInfo.Visible = true;
                        DivInfoPart1.Visible = true;
                    }
                }
                else
                {
                    DivPersonInfo.Visible = false;
                    DivInfoPart1.Visible = false;
                }
            }
        }
        private void DoGharamtShow()
        {
            if (txtNationalCode.Text.Trim().Length > 0 && txtHadeseDate.Text.Trim().Length > 0)
            {
                // ClaimData data = new ClaimData();
                CLaimBenefitModel model = new CLaimBenefitModel
                {
                    NationalCode = Convert.ToInt64(txtNationalCode.Text),
                    Unitcode = SessionHelper.Dastgah.DastgahCode,
                    Year = Convert.ToInt32(txtHadeseDate.Text.Substring(0, 4)),
                    Death_Date = Convert.ToString(txtHadeseDate.Text)
                };
                DataSet ds = DataAccessFactory.CreateClaimData().GetBaseBenefit(model);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    int Reason = Convert.ToInt16(RdbChangeReason.SelectedItem.Value);
                    if (Reason == 1)
                    {
                        var P = Convert.ToInt32(ds.Tables[0].Rows[0]["MABLAGH"]);
                        lblShowMablagh.Text = P.ToString("C");
                        Session["FinalMablagh"] = Convert.ToInt32(ds.Tables[0].Rows[0]["MABLAGH"]);
                    }
                    else
                    {
                        int MSum = 0;
                        foreach (ListItem item in ListNaghsType.Items)
                        {
                            if (item.Selected)
                            {
                                MSum = Convert.ToInt32(item.Text.Substring(item.Text.IndexOf("%"), item.Text.IndexOf(")") - item.Text.IndexOf("%")).Replace(")", "").Replace("%", "")) + MSum;
                            }
                        }
                        if (MSum > 100) MSum = 100;
                        var P1 = Convert.ToInt64(ds.Tables[0].Rows[0]["MABLAGH"]);
                        var p2 = (P1 * MSum) / 100;
                        Session["FinalMablagh"] = (int)p2;
                        lblShowMablagh.Text = ((int)(p2)).ToString("C");
                        //"#,##0"

                    }
                    lblKhataShow.Text = Convert.ToString(ds.Tables[0].Rows[0]["khata"]);
                    Session["OriginalMablagh"] = Convert.ToInt32(ds.Tables[0].Rows[0]["MABLAGH"]);
                    Session["Formid"] = Convert.ToInt32(ds.Tables[0].Rows[0]["FormId"]);
                }
            }
        }
        private string SaveGharamat()
        {
            string SaveResault = "";
            int Death_Reason_Id = 0;
            string DeathReson = "";
            string DisableReason = "";
            int Disable_Reason_Id = 0;
            int naqsozvitems = 0;
            Int16 GharamatType;
            SessionHelper.NationalCode = Convert.ToInt64(txtNationalCode.Text);
            if (hidImage.Value.Trim() == "" || !hidImage.Value.StartsWith("data:image/"))
                return "The pricture of Identity cart  has problem";
            if (hidImage2.Value.Trim() == "" || !hidImage2.Value.StartsWith("data:image/"))
                return "The picture of medical evidence  has problem";
            if (Session["FinalMablagh"] == null || Session["OriginalMablagh"] == null)
                if (Session["FormId"] == null)
                    return "There is a problem in your contract";
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("nationalcode", typeof(long)),
                                                    new DataColumn("serial", typeof(Byte)),
                                                    new DataColumn("DisableType_Code", typeof(int))});
            int Reason = Convert.ToInt16(RdbChangeReason.SelectedItem.Value);
            if (Reason == 1)
            {
                Death_Reason_Id = Convert.ToInt32(DrdHadeseReason.SelectedItem.Value); ;
                DeathReson = Convert.ToString(DrdHadeseReason.SelectedItem.Text.Trim());
                DisableReason = "";
                Disable_Reason_Id = 0;
                naqsozvitems = 0;
                GharamatType = 1;
            }
            else
            {
                Death_Reason_Id = 0;
                DeathReson = "";
                DisableReason = Convert.ToString(DrdNaghType.SelectedItem.Text.Trim());
                Disable_Reason_Id = DrdNaghType.SelectedItem.Text.Trim() == "Desease" ? 1 : 2;

                int MSum = 0;
                foreach (ListItem item in ListNaghsType.Items)
                {
                    if (item.Selected)
                    {
                        MSum++;
                    }
                }
                naqsozvitems = MSum;
                GharamatType = 2;
                GetSelectedDisItems(dt);
            }
            try
            {

                var bytes = Convert.FromBase64String(hidImage.Value.Substring(hidImage.Value.IndexOf(",") + 1));
                var bytes2 = Convert.FromBase64String(hidImage2.Value.Substring(hidImage2.Value.IndexOf(",") + 1));
                if (Convert.ToInt32(Session["FinalMablagh"]) > 0 && Convert.ToInt32(Session["OriginalMablagh"]) > 0)
                {
                    DataMangerClassLibrary.Models.ClaimModel model = new DataMangerClassLibrary.Models.ClaimModel
                    {
                        NationalCode = SessionHelper.NationalCode,
                        UnitCode = SessionHelper.Dastgah.DastgahCode,
                        AccsidentDate = Convert.ToString(txtHadeseDate.Text.Replace("/", "").Trim()),
                        Death_Reason_Id = Death_Reason_Id,
                        Elatefot = DeathReson,
                        Elatenaqseozv = DisableReason,
                        Disable_Reason_Id = Disable_Reason_Id,
                        NaqsozvItems = naqsozvitems,
                        GharamatValue = Convert.ToInt32(Session["FinalMablagh"]),
                        OriginalGharamatValue = Convert.ToInt32(Session["OriginalMablagh"]),
                        AccountNo = SessionHelper.Dastgah.AccountNumber,
                        BankName = SessionHelper.Dastgah.BankName,
                        BankCode = SessionHelper.Dastgah.Branch_Code,
                        RegUserId = SessionHelper.Dastgah.DastgahCode,
                        FormId = Convert.ToInt32(Session["FormId"]),
                        KartemeliImage = bytes,
                        GavahifotImage = bytes2,
                        GharamatType = GharamatType,
                        DisableTable = dt,
                        Mobiles = Convert.ToString(txtMobile.Text)
                    };
                    // ClaimData savedata = new ClaimData();
                    SaveResault = DataAccessFactory.CreateClaimData().SubmitClaim(model);
                }
                else
                {
                    SaveResault = "There is a problem in benefit calculation";
                }
            }
            catch (Exception SaveError)
            {
                _logger.LogException(SaveError, txtNationalCode.Text, "1");
                SaveResault = "There is a problem in submiting";
                if(Trace.IsEnabled){
                    Trace.Warn(SaveError.Message);
                }
            }
            return SaveResault;
        }
        private void GetSelectedDisItems(DataTable dt)
        {
            foreach (ListItem item in ListNaghsType.Items)
            {
                if (item.Selected)
                {
                    Int32 DisableType_Code = Convert.ToInt32(item.Value);
                    dt.Rows.Add(SessionHelper.NationalCode, 0, DisableType_Code);
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            RegxDate.Validate();
            lblKhataShow.Text = SaveGharamat();
        }
        protected void btnGharamatGet_Click(object sender, EventArgs e)
        {
            DoGharamtShow();
        }
    }
}