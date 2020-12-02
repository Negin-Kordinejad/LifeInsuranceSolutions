//using Cspf.Model.Base;

using DataMangerClassLibrary.Models;
using LifeInsWebApp.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LifeInsWebApp.InsuredAgentOrg
{
    public partial class Contract : System.Web.UI.Page
    {
        protected const char FILD_SEPERATOR = '$';
        protected const char RECORD_SEPERATOR = '#';
        protected const string ERR_MISS_FILE = "لطفا فایل را انتخاب کنید";
        protected const string ERR_CONT_NOEQ = "مغایرت با تعداد فایل - موجود در فایل : ";

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ContractYear"] = "98";
            Session.Timeout = 2 * 60;
           
            if (Page.IsPostBack == false)
                LoadContract();


        }

        protected void LoadContract()
        {
            txtStartDate.Text = "01/" + Session["ContractYear"].ToString();
            MsgBox.Text = "";
            HiddenFishField.Text = "";

            PersianCalendar p = new PersianCalendar();
            ContractDate.Text = p.GetYear(DateTime.Now).ToString("0000") + "/" + p.GetMonth(DateTime.Now).ToString("00") + "/" + p.GetDayOfMonth(DateTime.Now).ToString("00");
           // ContractData data = new ContractData();
            DataSet ds =DataAccessFactory.CreateContractData().GetContractInit(SessionHelper.Dastgah.DastgahCode);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtWorkerNum.Text = ds.Tables[0].Rows[0]["worker_num"].ToString();
                txtWorkerTime.Text = ds.Tables[0].Rows[0]["worker_time"].ToString();
                txtOurBazNum.Text = ds.Tables[0].Rows[0]["ourbaz_num"].ToString();
                txtOurBazTime.Text = ds.Tables[0].Rows[0]["ourbaz_time"].ToString();
                txtOtherBazNum.Text = ds.Tables[0].Rows[0]["otherbaz_num"].ToString();
                txtOtherBazTime.Text = ds.Tables[0].Rows[0]["otherbaz_time"].ToString();
                txtOtherBazNum.Text = ds.Tables[0].Rows[0]["timeoff_num"].ToString();
                txtOtherBazTime.Text = ds.Tables[0].Rows[0]["timeoff_time"].ToString();
            }

            //TextBox_SOOD.Text = "0";
         //   var xr = CheckCalculations();
        }
        protected void SaveContract(bool PreContract)
        {
            if (Session["MachineCode"] == null)
            {
                Response.Redirect(Session["CallerPage"].ToString());
                return;
            }
            string mcode = Session["MachineCode"].ToString();
            if (mcode.Length != 8)
            {
                Response.Redirect(Session["CallerPage"].ToString());
                return;
            }

            if (CheckCalculations() == false)
            {

                SysErr.Text = "CheckCalculations";
                return;
            }
            Label_ERROR1.Text = Label_ERROR2.Text = Label_ERROR3.Text = Label_ERROR4.Text = "";
            if (txtWorkerNum.Text == "") txtWorkerNum.Text = "0";
            if (txtOurBazNum.Text == "") txtOurBazNum.Text = "0";
            if (txtOtherBazNum.Text == "") txtOtherBazNum.Text = "0";
            if (txtTimeOffNum.Text == "") txtTimeOffTime.Text = txtTimeOffNum.Text = "0";

            string xsal = "1398";
            string xworkers = "";
            string xourbazs = "";
            string xothrbaz = "";
            string xtimeoff = "";


            if (FileUpload1.PostedFile != null && FileUpload1.FileName != "")
                FileUpload1.PostedFile.SaveAs((xworkers = Path.GetTempFileName()));
            if (FileUpload2.PostedFile != null && FileUpload2.FileName != "")
                FileUpload2.PostedFile.SaveAs((xourbazs = Path.GetTempFileName()));
            if (FileUpload3.PostedFile != null && FileUpload3.FileName != "")
                FileUpload3.PostedFile.SaveAs((xothrbaz = Path.GetTempFileName()));
            if (FileUpload4.PostedFile != null && FileUpload4.FileName != "")
                FileUpload4.PostedFile.SaveAs((xtimeoff = Path.GetTempFileName()));


            SqlCommand cmd = new SqlCommand(
                "TestNationalCodes",
                new SqlConnection(ConfigurationManager.ConnectionStrings["NewCnnStr"].ConnectionString)
            );
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 900;

            SqlParameter param = new SqlParameter("@Sal", xsal);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);


            param = new SqlParameter("@MachineCode", mcode);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FileNameEmp", xworkers);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            param = new SqlParameter("@FileNameBazOwn", xourbazs);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            param = new SqlParameter("@FileNameBazOther", xothrbaz);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            param = new SqlParameter("@FileNameEmpMorkh", xtimeoff);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@NumEmp", 0);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);
            param = new SqlParameter("@NumBazOwn", 0);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);
            param = new SqlParameter("@NumBazOther", 0);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);
            param = new SqlParameter("@NumEmpMorkh", 0);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            try
            {
                sda.Fill(ds);
                GridView_Exist.DataSource = ds;
                GridView_Exist.DataMember = ds.Tables[0].TableName;
                GridView_Exist.DataBind();
            }
            catch (Exception ex)
            {
                SysErr.Text = ex.Message;
                Label1.Text = "خطا در فایل کدهای ملی";
                return;
            }
            if (ds.Tables[0].Rows.Count > 0) return;

            if (getValue(cmd.Parameters["@NumEmp"].Value) != txtWorkerNum.Text)
            {
                Label_ERROR1.Text = ERR_CONT_NOEQ + getValue(cmd.Parameters["@NumEmp"].Value);
            }
            if (getValue(cmd.Parameters["@NumBazOwn"].Value) != txtOurBazNum.Text)
            {
                Label_ERROR2.Text = ERR_CONT_NOEQ + getValue(cmd.Parameters["@NumBazOwn"].Value);
            }

            if (getValue(cmd.Parameters["@NumBazOther"].Value) != txtOtherBazNum.Text)
            {
                Label_ERROR3.Text = ERR_CONT_NOEQ + getValue(cmd.Parameters["@NumBazOther"].Value);
            }
            if (getValue(cmd.Parameters["@NumEmpMorkh"].Value) != txtTimeOffNum.Text)
            {
                Label_ERROR4.Text = ERR_CONT_NOEQ + getValue(cmd.Parameters["@NumEmpMorkh"].Value);
            }

            if (Label_ERROR1.Text.Length > 0 || Label_ERROR2.Text.Length > 0 || Label_ERROR3.Text.Length > 0 || Label_ERROR4.Text.Length > 0)
            {
                return;
            }

            SysErr.Text = "main";


            if (xworkers.Length > 0) File.Delete(xworkers);
            if (xourbazs.Length > 0) File.Delete(xourbazs);
            if (xothrbaz.Length > 0) File.Delete(xothrbaz);
            if (xtimeoff.Length > 0) File.Delete(xtimeoff);
            if (txtTimeOffNum.Text.Length == 0) txtTimeOffNum.Text = "0";
            if (txtTimeOffTime.Text.Length == 0) txtTimeOffTime.Text = "0";


            bool SavedSuccess = false;
            Int64 IntFishSum = 0;
            DataSet depositDs = new DataSet();
            string[] fishes;

            MsgBox.Text = "";



            if (HiddenFishField.Text.Length > 0) // now decode fishrows 
            {
                fishes = HiddenFishField.Text.Split(new char[] { RECORD_SEPERATOR });
                DataSet FishesDataSet = new DataSet();
                for (int i = 0; i < (fishes.Length); ++i)
                {
                    string[] dataf = fishes[i].Split(new char[] { FILD_SEPERATOR });
                    FishesDataSet.Tables[0].Rows.Add(dataf);
                }

              //  DepositData data = new DepositData();
                depositDs =DataAccessFactory.CreateDepositData().CheckDepositValues(FishesDataSet.Tables[0]);

                if (depositDs != null && depositDs.Tables.Count > 0 && depositDs.Tables[0].Rows.Count > 0)
                {
                    var result = depositDs.Tables[0].AsEnumerable()
                              .Where(myRow => myRow.Field<string>("depositStatus") == "bad");
                    if (result.ToList().Count > 0)
                    {
                        HiddenFishField.Text = "";
                        SysErr.Text = "Err in fish";
                        MsgBox.Text = "Fish_Not_Found";
                        return;
                    }
                }
            }
            if (CheckCalculations() == false)
            {
                SavedSuccess = false;
                SysErr.Text = "CheckCalculations";
                return;
            }

            int status = PreContract ? 0 : 1;

            PersianCalendar p = new PersianCalendar();
            string cdate = p.GetYear(DateTime.Now).ToString("0000") + "/" + p.GetMonth(DateTime.Now).ToString("00") + "/" + p.GetDayOfMonth(DateTime.Now).ToString("00");
            string unitcode = mcode;
            string fish_sum = IntFishSum.ToString();

            if (fish_sum.Length == 0) fish_sum = "0";
            Int64 contract_prize = Convert.ToInt64(txtMustPay.Text);
            // prevent unproper fish stat & prevent to insert additional fishes        
            if (contract_prize > IntFishSum || (contract_prize == 0 && IntFishSum > 0))
            {
                SavedSuccess = false;
                SysErr.Text = "error:overprize";
                return;
            }

            int StartTime = Convert.ToInt32(Session["ContractYear"].ToString() + "01");
            string wo_old = txtWorkerNum_oldprice.Text; if (wo_old.Length == 0) wo_old = "0";
            string ou_old = txtOurBazNum_oldprice.Text; if (ou_old.Length == 0) ou_old = "0";
            string ot_old = txtOtherBazNum_oldprice.Text; if (ot_old.Length == 0) ot_old = "0";
            int xtype = Convert.ToInt32(Insure_Type.SelectedValue);

            ContractModel model = new ContractModel
            {
                ContractType = xtype,
                Status = status,
                ContractDate = cdate,
                Organinsuredcode = (int)Session["MachineCode"],
                Worker_num = Convert.ToInt32(txtWorkerNum.Text),
                Worker_start = StartTime,
                Worker_time = Convert.ToInt32(txtWorkerTime.Text),
                Worker_pay = Convert.ToInt64(txtWorkerSumPay.Text),
                Ourbaz_num = Convert.ToInt32(txtOurBazNum.Text),
                Ourbaz_start = StartTime,
                Ourbaz_time = Convert.ToInt32(txtOurBazTime.Text),
                Ourbaz_pay = Convert.ToInt64(txtOurBazSumPay.Text),
                Otherbaz_num = Convert.ToInt32(txtOtherBazNum.Text),
                Otherbaz_start = StartTime,
                Otherbaz_time = Convert.ToInt32(txtOtherBazTime.Text),
                Otherbaz_pay = Convert.ToInt64(txtOtherBazSumPay.Text),
                Timeoff_num = Convert.ToInt32(txtTimeOffNum.Text),
                Timeoff_start = StartTime,
                Timeoff_time = Convert.ToInt32(txtTimeOffTime.Text),
                Timeoff_pay = Convert.ToInt64(txtTimeOffPay.Text),
                Contract_prize = Convert.ToInt64(txtMustPay.Text),
                Deposit_sum = Convert.ToInt64(fish_sum),
                ContractYearMonth = StartTime,
                Wo_old = Convert.ToInt32(wo_old),
                Ou_old = Convert.ToInt32(ou_old),
                Ot_old = Convert.ToInt32(ot_old),
                DepositItems = depositDs.Tables[0]
            };
            try
            {
               // ContractData cData = new ContractData();
                string FormIdds =DataAccessFactory.CreateContractData().SubmitContract(model);
                SavedSuccess = true;
                Session["ContractFormId"] = FormIdds;
            }
            catch (Exception ex)
            {
                SysErr.Text = "SYSERR:" + ex.ToString();
                SavedSuccess = false;
            }

            if (SavedSuccess == false)
            {
                if (MsgBox.Text.Length == 0)
                    MsgBox.Text = "Err_In_Save_Try_Again";
            }
            if (PreContract == false)
                Response.Redirect("~/Insurance/ContractPrint97.aspx");
        }
        protected bool CheckCalculations()
        {
            Int64 mustpay;
          
            if (txtTimeOffNum.Text.Length == 0)
                txtTimeOffTime.Text = txtTimeOffNum.Text = "0";
            else
            {
                int xx = (Convert.ToInt32(txtTimeOffNum.Text) * 12);
                txtTimeOffTime.Text = xx.ToString();
            }



            txtTimeOffTime.Text = txtTimeOffTime.Text.Replace(",", "");
            if (txtTimeOffTime.Text.Length == 0)
                txtTimeOffTime.Text = "0";


            Int64 WorkerTime = Convert.ToInt64(txtWorkerTime.Text); if (WorkerTime > 12 || WorkerTime < 0) return false;
            Int64 OurBazTime = Convert.ToInt64(txtOurBazTime.Text); if (OurBazTime > 12 || OurBazTime < 0) return false;
            Int64 OtherBazTime = Convert.ToInt64(txtOtherBazTime.Text); if (OtherBazTime > 12 || OtherBazTime < 0) return false;



            Int64 TimeOffTime = Convert.ToInt64(txtTimeOffTime.Text); if (TimeOffTime < 0) return false;

            Int64 WorkerNum = Convert.ToInt64(txtWorkerNum.Text);
            Int64 WorkerNum_old = Convert.ToInt64(txtWorkerNum_oldprice.Text);
            Int64 OurBazNum = Convert.ToInt64(txtOurBazNum.Text);
            Int64 OurBazNum_old = Convert.ToInt64(txtOurBazNum_oldprice.Text);
            Int64 OtherBazNum = Convert.ToInt64(txtOtherBazNum.Text);
            Int64 OtherBazNum_old = Convert.ToInt64(txtOtherBazNum_oldprice.Text);
            Int64 TimeOffNum = Convert.ToInt64(txtTimeOffNum.Text);

            MsgBox.Text = "";

            
            

            if (WorkerNum == 0) WorkerTime = 0;
            if (OurBazNum == 0) OurBazTime = 0;
            if (OtherBazNum == 0) OtherBazTime = 0;
            if (TimeOffNum == 0) TimeOffTime = 0;


            if ((WorkerTime != 0 && WorkerNum == 0) || (WorkerTime == 0 && WorkerNum != 0)) return false;
            if ((OurBazTime != 0 && OurBazNum == 0) || (OurBazTime == 0 && OurBazNum != 0)) return false;
            if ((OtherBazTime != 0 && OtherBazNum == 0) || (OtherBazTime == 0 && OtherBazNum != 0)) return false;
            if ((TimeOffTime != 0 && TimeOffNum == 0) || (TimeOffTime == 0 && TimeOffNum != 0)) return false;

            if (WorkerTime == 0 && WorkerNum == 0 && OurBazTime == 0 && OurBazNum == 0 && OtherBazTime == 0 && OtherBazNum == 0 && TimeOffTime == 0 && TimeOffNum == 0) return false;


            if (TextBox_SOOD.Text == "") TextBox_SOOD.Text = "0";
            int SOOD = Convert.ToInt32(TextBox_SOOD.Text);
            SOOD = 0;

            int xtype = Convert.ToInt32(Insure_Type.SelectedValue);

            //////////////////////////////////// workers
            int Takmili_worker_person_price = 10000 + SOOD;
            int Takmili_worker_device_price = 6000;

            int Normal_worker_device_price = 17490;
            int Normal_worker_person_price = 0;

            switch (xtype)
            {
                case 1: Normal_worker_person_price = 17490; break;
                case 2: Normal_worker_person_price = 17490; break;
                case 3: Normal_worker_person_price = 17490; break;
                default:
                    MsgBox.Text = "system error";
                    return false;
            }



            txtWorkerNum_oldprice.Text = txtWorkerNum.Text;

            int w_time = Convert.ToInt32(txtWorkerTime.Text);

            Int64 w_new_num = WorkerNum - Convert.ToInt64(txtWorkerNum_oldprice.Text);
            Int64 w_new_pay = w_new_num * WorkerTime * Takmili_worker_person_price;

            Int64 w_old_num = Convert.ToInt64(txtWorkerNum_oldprice.Text);
            Int64 w_old_pay = w_old_num * w_time * Normal_worker_person_price;


            txtWorkerPay.Text = ((Int64)(w_new_pay + w_old_pay)).ToString();

            w_new_pay = w_new_num * w_time * Takmili_worker_device_price;
            w_old_pay = w_old_num * w_time * Normal_worker_device_price;



            txtDeviceWorkerPay.Text = ((Int64)(w_new_pay + w_old_pay)).ToString();
            txtWorkerSumPay.Text = ((Int64)(Convert.ToInt64(txtWorkerPay.Text) + Convert.ToInt64(txtDeviceWorkerPay.Text))).ToString();

            Int64 WorkerSumPay = Convert.ToInt64(txtWorkerSumPay.Text);
            ////////////////////////////////////


            //////////////////////////////////// ourbaz
            int Takmili_ourbaz_person_price = 8000 + SOOD;
            int Takmili_ourbaz_device_price = 6000;

            int Normal_ourbaz_device_price = 17490;
            int Normal_ourbaz_person_price = 0;


            switch (xtype)
            {
                case 1: Normal_ourbaz_person_price = 17490 - 2500; break;
                case 2: Normal_ourbaz_person_price = 17490 - 2500; break;
                case 3: Normal_ourbaz_person_price = 17490 - 2500; break;
                default:
                    MsgBox.Text = "system error";
                    return false;
            }


            txtOurBazNum_oldprice.Text = txtOurBazNum.Text;

            Int64 ou_time = Convert.ToInt64(txtOurBazTime.Text);

            Int64 ou_new_num = Convert.ToInt64(txtOurBazNum.Text) - Convert.ToInt64(txtOurBazNum_oldprice.Text);
            Int64 ou_new_pay = ou_new_num * ou_time * Takmili_ourbaz_person_price;

            Int64 ou_old_num = Convert.ToInt64(txtOurBazNum_oldprice.Text);
            Int64 ou_old_pay = ou_old_num * ou_time * Normal_ourbaz_person_price;

            txtOurBazPay.Text = ((Int64)(ou_new_pay + ou_old_pay)).ToString();

            ou_new_pay = ou_new_num * ou_time * Takmili_ourbaz_device_price;
            ou_old_pay = ou_old_num * ou_time * Normal_ourbaz_device_price;

            txtDeviceOurBazPay.Text = ((Int64)(ou_new_pay + ou_old_pay)).ToString();

            txtOurBazSumPay.Text = ((Int64)(Convert.ToInt64(txtOurBazPay.Text) + Convert.ToInt64(txtDeviceOurBazPay.Text))).ToString();
            Int64 OurBazSumPay = Convert.ToInt64(txtOurBazSumPay.Text);

            ////////////////////////////////////

            //////////////////////////////////// otherbaz
            int Takmili_otherbaz_person_price = 10000 + SOOD;
            int Takmili_otherbaz_device_price = 6000;

            int Normal_otherbaz_device_price = 17490;
            int Normal_otherbaz_person_price = 0;



            switch (xtype)
            {
                case 1: Normal_otherbaz_person_price = 17490; break;
                case 2: Normal_otherbaz_person_price = 17490; break;
                case 3: Normal_otherbaz_person_price = 17490; break;
                default:
                    MsgBox.Text = "system error";
                    return false;
            }


            txtOtherBazNum_oldprice.Text = txtOtherBazNum.Text;

            Int64 ot_time = Convert.ToInt64(txtOtherBazTime.Text);


            Int64 ot_new_num = Convert.ToInt64(txtOtherBazNum.Text) - Convert.ToInt64(txtOtherBazNum_oldprice.Text);
            Int64 ot_new_pay = ot_new_num * ot_time * Takmili_otherbaz_person_price;

            Int64 ot_old_num = Convert.ToInt64(txtOtherBazNum_oldprice.Text);
            Int64 ot_old_pay = ot_old_num * ot_time * Normal_otherbaz_person_price;


            txtOtherBazPay.Text = ((Int64)(ot_new_pay + ot_old_pay)).ToString();

            ot_new_pay = ot_new_num * ot_time * Takmili_otherbaz_device_price;
            ot_old_pay = ot_old_num * ot_time * Normal_otherbaz_device_price;


            txtDeviceOtherBazPay.Text = ((Int64)(ot_new_pay + ot_old_pay)).ToString();
            Int64 OtherBazSumPay = Convert.ToInt64(txtOtherBazPay.Text) + Convert.ToInt64(txtDeviceOtherBazPay.Text);
            txtOtherBazSumPay.Text = OtherBazSumPay.ToString();
            Convert.ToInt64(txtOtherBazSumPay.Text);



            ////////////////////////////////////


            //////////////////////////////////// timeoff
            int Takmili_timeoff_person_price = 17490;

            switch (xtype)
            {
                case 1: Takmili_timeoff_person_price += 17490; break;
                case 2: Takmili_timeoff_person_price += 17490; break;
                case 3: Takmili_timeoff_person_price += 17490; break;
                default:
                    MsgBox.Text = "system error";
                    return false;
            }


            Int64 TimeOffSumPay = Takmili_timeoff_person_price * Convert.ToInt64(txtTimeOffTime.Text);
            txtTimeOffSumPay.Text = txtTimeOffPay.Text = TimeOffSumPay.ToString();
            ////////////////////////////////////

            mustpay = WorkerSumPay + OurBazSumPay + OtherBazSumPay + TimeOffSumPay;


            txtMustPay.Text = mustpay.ToString();

            return true;
        }
        //protected bool NationalList(nlist[] mylist)
        //{
        //    Label_ERROR1.Text = Label_ERROR2.Text = Label_ERROR3.Text = Label_ERROR4.Text = "";

        //    if (txtWorkerNum.Text == "") txtWorkerNum.Text = "0";
        //    if (txtOurBazNum.Text == "") txtOurBazNum.Text = "0";
        //    if (txtOtherBazNum.Text == "") txtOtherBazNum.Text = "0";
        //    if (txtTimeOffNum.Text == "") txtTimeOffNum.Text = "0";

        //    if (FileUpload1.PostedFile != null && FileUpload1.FileName != "")
        //        mylist[0].xset(FileUpload1.PostedFile.InputStream, Convert.ToInt32(txtWorkerNum.Text));
        //    else
        //        if (Convert.ToInt32(txtWorkerNum.Text) > 0)
        //    {
        //        Label_ERROR1.Text = ERR_MISS_FILE;
        //        return false;
        //    }


        //    if (FileUpload2.PostedFile != null && FileUpload2.FileName != "")
        //        mylist[1].xset(FileUpload2.PostedFile.InputStream, Convert.ToInt32(txtOurBazNum.Text));
        //    else
        //        if (Convert.ToInt32(txtOurBazNum.Text) > 0)
        //    {
        //        Label_ERROR2.Text = ERR_MISS_FILE;
        //        return false;
        //    }

        //    if (FileUpload3.PostedFile != null && FileUpload3.FileName != "")
        //        mylist[2].xset(FileUpload3.PostedFile.InputStream, Convert.ToInt32(txtOtherBazNum.Text));
        //    else
        //        if (Convert.ToInt32(txtOtherBazNum.Text) > 0)
        //    {
        //        Label_ERROR3.Text = ERR_MISS_FILE;
        //        return false;
        //    }


        //    if (FileUpload4.PostedFile != null && FileUpload4.FileName != "")
        //        mylist[3].xset(FileUpload4.PostedFile.InputStream, Convert.ToInt32(txtTimeOffNum.Text));
        //    else
        //        if (Convert.ToInt32(txtTimeOffNum.Text) > 0)
        //    {
        //        Label_ERROR4.Text = ERR_MISS_FILE;
        //        return false;
        //    }

        //    if (Label_ERROR1.Text.Length == 0)
        //    {
        //        if (mylist[0].err.Length > 0)
        //            Label_ERROR1.Text = "سطر خطا:" + mylist[0].err;
        //        else
        //            if (Convert.ToInt32(txtWorkerNum.Text) != mylist[0].count)
        //            Label_ERROR1.Text = ERR_CONT_NOEQ + mylist[0].count.ToString();
        //    }



        //    if (Label_ERROR2.Text.Length == 0)
        //    {
        //        if (mylist[1].err.Length > 0)
        //            Label_ERROR2.Text = "سطر خطا:" + mylist[1].err;
        //        else
        //            if (Convert.ToInt32(txtOurBazNum.Text) != mylist[1].count)
        //            Label_ERROR2.Text = ERR_CONT_NOEQ + mylist[1].count.ToString();
        //    }



        //    if (Label_ERROR3.Text.Length == 0)
        //    {
        //        if (mylist[2].err.Length > 0)
        //            Label_ERROR3.Text = "سطر خطا:" + mylist[2].err;
        //        else
        //            if (Convert.ToInt32(txtOtherBazNum.Text) != mylist[2].count)
        //            Label_ERROR3.Text = ERR_CONT_NOEQ + mylist[2].count.ToString();
        //    }


        //    if (Label_ERROR4.Text.Length == 0)
        //    {
        //        if (mylist[3].err.Length > 0)
        //            Label_ERROR4.Text = "سطر خطا:" + mylist[3].err;
        //        else
        //            if (Convert.ToInt32(txtTimeOffNum.Text) != mylist[3].count)
        //            Label_ERROR4.Text = ERR_CONT_NOEQ + mylist[3].count.ToString();
        //    }

        //    if (Label_ERROR1.Text.Length == 0 && Label_ERROR2.Text.Length == 0
        //        && Label_ERROR3.Text.Length == 0 && Label_ERROR4.Text.Length == 0)
        //        return true;
        //    else return false;

        //}
        private string getValue(object val)
        {
            return Convert.ToInt32(val).ToString();
        }

        private string FishFix10(string s)
        {
            if (s.Length == 9) return "0" + s;
            else return s;
        }

        protected void SubmitBt_Click(object sender, EventArgs e)
        {
            SaveContract(false);
        }

        protected void PrintThisForm_Click(object sender, EventArgs e)
        {
            SaveContract(true);
        }

        protected void ReturnBt_Click(object sender, EventArgs e)
        {
            Response.Redirect(Session["CallerPage"].ToString());

        }

    }
}