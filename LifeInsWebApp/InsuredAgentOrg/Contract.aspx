<%@ Page Title=""  Language="C#" MasterPageFile="~/InsuredAgentOrg/MasterPage.Master" AutoEventWireup="true" CodeBehind="Contract.aspx.cs" Inherits="LifeInsWebApp.InsuredAgentOrg.Contract" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/Style/xdate.css" rel="stylesheet" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table table-responsive table-bordered" dir="ltr" style="background-color: #1fc8db; background-image: linear-gradient(141deg, #9fb8ad 0%, #1fc8db 51%, #2cb5e8 75%); opacity: 0.95">
        <tr style="font-size: 10pt">
            <td colspan="2" style="text-align: center">
                <img alt="" src="../../Content/Image/trans.gif" /></td>
            <td colspan="4">
                <strong><span style="font-size: 16pt;">Life Insurance And disability Cntract
               <br />
                    Employees And Retiremend </span></strong>
                <br />
            </td>
        </tr>
        <tr style="font-size: 10pt">
            <th>Date</th>
            <td>
                <asp:TextBox ID="ContractDate" runat="server" Width="100%" ReadOnly="True"></asp:TextBox>
            </td>
            <th>InsuranceType</th>
            <td>
                <asp:DropDownList ID="Insure_Type" runat="server" onchange="CalcSum()" Font-Names="Tahoma" Width="100%" Enabled="False">
                    <asp:ListItem Value="1" Selected="True">Base benfit life insurace : 58000000  Rialل</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 5%"></td>
            <td dir="ltr" style="width: 10%"></td>
        </tr>
    </table>
    <div style="text-align: center">
        <asp:TextBox ID="MsgBox" runat="server" ForeColor="Red" ReadOnly="True"
            Width="100%" Wrap="False" BorderStyle="None"></asp:TextBox>
    </div>
    <div>
        <table class="table table-responsive" border="1" style="font-size: 10pt;" dir="ltr">
            <tr>
                <td style="width: 100%; text-align: justify;">
                    <span style="color: #ff0066; font-size: 12pt;">Dear device: National code of retirees and employees
                            Who have died from 1397/01/01 until the conclusion of the initial contract, must be in
                            the list.
                             The primary electronics should be uploaded and no additional contract should be concluded for these people
                            Does not turn.&nbsp;
                            The device will be responsible for non-payment of life insurance capital.<br />
                        <br />
                        <span style="color: #000000">National registration of insured persons by employed, joint pensioner of the fund,
                            Joint retirees of other funds and unpaid leave, each &nbsp; in a plain text file (Notepad).
                            Each separate code is required in a row, including names.
                            Files containing the national code must be in English
                        </span>
                        <span style="color: #cc0000"><span style="color: #000000">Also, the file encoding must be ANSI, for consideration
                                Encoding your file in Notepad Save SA AS in & nbsp; Menu &nbsp; File & nbsp;
                                Selection
                                And see the Encoding box at the bottom of the page on the first option, ANSI
                                Be
                        </span>
                            <br />
                            <span style="color: #009900">Respected devices, make sure that the receipt number (ID 10)
                                    Enter a digit) because with the given changes in the system, register the ID
                                    Ten digits specific to the device
                                    Is required.
                                <br />
                                <span style="color: #000000">Dear users, please strictly refrain from the following actions
                                        Please.
                                    <br />
                                    1- Enter the national code of other people.
                                        <br />
                                    2- Entering the national code of retired people instead of employed people and vice versa.
                                    <br />
                                    3- Entering the national code of those covered by the law on services of physicians and paramedics (plan) instead of the national code of individuals
                                        Who are on unpaid leave. Failure to comply with the above, the responsibility for non-payment
                                        Life insurance compensation will be borne by the executive bodies.
                                        <br />
                                    <input id="Checkbox2" type="checkbox" onclick="yfun()" />
                                    &nbsp;I am confired all above.</span></span></span></span></td>
            </tr>
        </table>

        <asp:Label ID="SysErr" runat="server"></asp:Label>
        <table class="table table-responsive " id="PersonNumbers" dir="ltr">
            <tr>
                <td style="background-color: #c0c0c0">
                    <asp:Button ID="PrintThisForm" runat="server" Font-Names="Webdings" Text="Ê"
                        OnClientClick="return JavaPrintForm()" Width="40px" Height="40px" OnClick="PrintThisForm_Click" />
                </td>
                <td colspan="6" style="background-color: #c0c0c0">
                    <span style="font-size: 16pt; font-family: B Zar;">Table of calculation of insurance premium in proportion to the duration of insurance<br />
                        Start Insurance Date :
                        <asp:Label ID="txtStartDate" runat="server" Font-Names="Tahoma" Font-Size="Large"></asp:Label></span>

                </td>
            </tr>
            <tr>
                <td></td>
                <td>Uplouad National code files</td>
                <td>Number of people</td>
                <td>Duratin(mounth)</td>
                <td>Insured half(Rial)</td>
                <td>Agent Inserd(Rial)</td>
                <td>Total(Rial)</td>
            </tr>
            <tr style="font-size: 10pt">
                <td style="vertical-align: middle; text-align: center;">Employee</td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="200px" Enabled="false" /><br />
                    <asp:Label ID="Label_ERROR1" runat="server" ForeColor="Red"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtWorkerNum" runat="server" Width="100%" onkeyup="CalcSum()" Font-Names="Tahoma" OnKeyPress="return FilterNumric(event)"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtWorkerTime" runat="server" Width="100%" onkeyup="CalcSum()" Font-Names="Tahoma" OnKeyPress="return FilterNumric(event)" ReadOnly="True">12</asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtWorkerPay" runat="server" Font-Names="Tahoma" Width="100%" ReadOnly="True"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtDeviceWorkerPay" runat="server" Font-Names="Tahoma" Width="100%" ReadOnly="True"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtWorkerSumPay" runat="server" Font-Names="Tahoma" Width="100%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr style="font-size: 10pt">
                <td>Retied of Civil sevant</td>
                <td>
                    <asp:FileUpload ID="FileUpload2" runat="server" Width="200px" Enabled="False" /><br />
                    <asp:Label ID="Label_ERROR2" runat="server" ForeColor="Red"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtOurBazNum" runat="server" Width="100%" onkeyup="CalcSum()" Font-Names="Tahoma" OnKeyPress="return FilterNumric(event)"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtOurBazTime" runat="server" Width="100%" onkeyup="CalcSum()" Font-Names="Tahoma" OnKeyPress="return FilterNumric(event)" ReadOnly="True">12</asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtOurBazPay" runat="server" Font-Names="Tahoma" Width="100%" ReadOnly="True"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtDeviceOurBazPay" runat="server" Font-Names="Tahoma" Width="100%" ReadOnly="True"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtOurBazSumPay" runat="server" Font-Names="Tahoma" Width="100%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr style="font-size: 10pt">
                <td>Retied of Ther funds</td>
                <td>
                    <asp:FileUpload ID="FileUpload3" runat="server" Width="200px" Enabled="False" /><br />
                    <asp:Label ID="Label_ERROR3" runat="server" ForeColor="Red"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtOtherBazNum" runat="server" Font-Names="Tahoma" Width="100%" onkeyup="CalcSum()" OnKeyPress="return FilterNumric(event)"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtOtherBazTime" runat="server" Font-Names="Tahoma" Width="100%" onkeyup="CalcSum()" OnKeyPress="return FilterNumric(event)" ReadOnly="True">12</asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtOtherBazPay" runat="server" Font-Names="Tahoma" Width="100%" ReadOnly="True"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtDeviceOtherBazPay" runat="server" Font-Names="Tahoma" Width="100%" ReadOnly="True"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtOtherBazSumPay" runat="server" Font-Names="Tahoma" Width="100%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr style="font-size: 10pt">
                <td>Time off people</td>
                <td>
                    <asp:FileUpload ID="FileUpload4" runat="server" Width="200px" Enabled="False" /><br />
                    <asp:Label ID="Label_ERROR4" runat="server" ForeColor="Red"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtTimeOffNum" runat="server" Font-Names="Tahoma" onkeypress="return FilterNumric(event)"
                        onkeyup="CalcSum()" Width="100%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtTimeOffTime" runat="server" Font-Names="Tahoma" onkeypress="return FilterNumric(event)"
                        onkeyup="CalcSum()" Width="100%" ReadOnly="True"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtTimeOffPay" runat="server" Font-Names="Tahoma" Width="100%" ReadOnly="True"></asp:TextBox></td>
                <td></td>
                <td>
                    <asp:TextBox ID="txtTimeOffSumPay" runat="server" Font-Names="Tahoma" Width="100%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr style="font-size: 10pt">
                <td>Total cost</td>
                <td></td>
                <td>
                    <asp:TextBox ID="txtSumNum" runat="server" Font-Names="Tahoma" Width="100%" ReadOnly="True"></asp:TextBox></td>
                <td></td>
                <td>
                    <asp:TextBox ID="txtPersonSumPay" runat="server" Font-Names="Tahoma" Width="100%" ReadOnly="True"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtDeviceSumPay" runat="server" Font-Names="Tahoma" Width="100%" ReadOnly="True"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtMustPay" runat="server" Font-Names="Tahoma" Width="100%" ReadOnly="True"></asp:TextBox></td>
            </tr>
        </table>
        <div dir="ltr" class="container">
            <asp:GridView ID="GridView_Exist" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84"
                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2"
                Caption="MationalCodes exist in files" CaptionAlign="Right" ForeColor="Red" Width="100%">
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <Columns>
                    <asp:BoundField DataField="NationalCode" HeaderText="NatinalCode" ReadOnly="True" SortExpression="fld" />
                    <asp:BoundField DataField="xname" HeaderText="Organization" ReadOnly="True"
                        SortExpression="xname" />
                </Columns>
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
        </div>
        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label><br />
        <table class="table table-responsive table-borderless" style="width: 80%; font-size: 10pt;">
            <tr>
                <td>&nbsp; &nbsp;Please deposit the insurance premium as above to Sepehr account number 0100055555002 with
        Bank Saderat Iran Action and
        Deposit slip details <span style="color: #ff3333">after 48 hours from & nbsp; Deposit date
            Get the required premium </span>in the table below and get the necessary confirmation </td>
            </tr>
            <tr>
                <td>
                    <p class="MsoNormal" style="margin: 0pt">
                        <span>Note:
                            <?xml namespace="" ns="urn:schemas-microsoft-com:office:office" prefix="o" ?>
                            <o:p></o:p>
                        </span>
                    </p>
                    <p class="MsoNormal" style="margin: 0pt 36pt 0pt 0pt; text-indent: -18pt; mso-list: l0 level1 lfo1; tab-stops: list 36.0pt">
                        <span lang="FA">1-<span style="font-weight: normal; line-height: normal; font-style: normal; font-variant: normal">&nbsp; </span>
                        </span>
                        <span lang="FA">The above amount is only through bank branches
                            Export to be credited to the said account.
                        </span>
                    </p>
                    <p class="MsoNormal" style="margin: 0pt 36pt 0pt 0pt; text-indent: -18pt; mso-list: l0 level1 lfo1; tab-stops: list 36.0pt">
                        2-&nbsp;From paying and sending money transfers from other banks to the account
                                Avoid this seriuslely.
                    </p>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>&nbsp; &nbsp; &nbsp;&nbsp; Civil Servent Pension Fund<br />
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Departmant</strong></td>
            </tr>
        </table>


        <%--        <table id="FishListTab" border="1" style="width: 95%; background-color: #C0C0C0; font-size: 10pt; font-family: Tahoma;" dir="ltr" cellspacing="3">
            <tr>
                <td style="width: 12%; height: 25px; background-color: #C0C0C0;">
                    <asp:Button ID="ShowHideFishes" runat="server" Font-Names="Webdings" Text="r"
                        OnClientClick="return ShowHideFishList()"
                        Width="25px" Height="25px" Font-Size="Small" /></td>
                <td colspan="3" style="height: 30px; text-align: center">
                    <span style="font-size: 16pt; font-family: B Zar;">deposited receipts</span></td>
                <td style="width: 22%; height: 30px;"></td>
            </tr>
        </table>--%>
        <table class="table table-responsive table-borderless" id="FishListTab" border="1" style="width: 95%; background-color: #C0C0C0; font-size: 10pt; font-family: Tahoma;" dir="rtl" cellspacing="3">
            <tr>
                <td style="width: 12%; height: 25px; background-color: #C0C0C0;">
                    <asp:Button ID="ShowHideFishes" runat="server" Font-Names="Webdings" Text="r"
                        OnClientClick="return ShowHideFishList()"
                        Width="25px" Height="25px" Font-Size="Small" /></td>
                <td colspan="3" style="height: 30px; text-align: center">
                    <span style="font-size: 16pt; font-family: B Zar;">ليست فيش های واريز شده</span></td>
                <td style="width: 22%; height: 30px;"></td>
            </tr>
        </table>
        <table class="t" id="FishList" border="1" style="width: 95%; background-color: #dcdcdc; font-size: 10pt; font-family: Tahoma;" dir="rtl" cellspacing="3">
            <tr>
                <td style="width: 12%"></td>
                <td style="width: 22%"></td>
                <td style="width: 22%"></td>
                <td style="width: 22%"></td>
                <td style="width: 22%"></td>
            </tr>
            <tr>
                <td style="width: 12%">رديف</td>
                <td style="width: 22%">مبلغ فيش</td>
                <td style="width: 22%">شماره فيش</td>
                <td style="width: 22%">كد شعبه (بانك صادرات)</td>
                <td style="width: 22%">تاريخ فيش</td>
            </tr>
            <tr>
                <td style="width: 12%">جمع</td>
                <td style="width: 22%" id="FishSumPlace">
                    <asp:TextBox ID="txtFishSum" runat="server" Width="150px" BackColor="#E0E0E0"></asp:TextBox></td>
                <td style="width: 22%"></td>
                <td style="width: 22%"></td>
                <td style="width: 22%">
                    <asp:Button ID="AddNewFish" runat="server" Font-Names="Tahoma"
                        Font-Size="Small" OnClientClick="return JavaAddNewFish();"
                        Text="سطر جديد" />
                    <br />
                    <asp:Button ID="AddNewFish25" runat="server"
                        Font-Names="Tahoma" Font-Size="Small"
                        OnClientClick="return JavaAddNewFish50();"
                        Text="50 سطر جديد" /></td>
            </tr>
        </table>

        <%--        <table id="FishList" border="1" style="width: 95%; background-color: #dcdcdc; font-size: 10pt; font-family: Tahoma;" dir="rtl" cellspacing="3">
            <tr>
                <td style="width: 12%"></td>
                <td style="width: 22%"></td>
                <td style="width: 22%"></td>
                <td style="width: 22%"></td>
                <td style="width: 22%"></td>
            </tr>
            <tr>
                <td style="width: 12%">Row</td>
                <td style="width: 22%">Bill amount</td>
                <td style="width: 22%">Bill number</td>
                <td style="width: 22%">Branch code</td>
                <td style="width: 22%">Bill date</td>
            </tr>
            <tr>
                <td style="width: 12%">Total</td>
                <td style="width: 22%" id="FishSumPlace">
                    <asp:TextBox ID="txtFishSum" runat="server" Width="150px" BackColor="#E0E0E0"></asp:TextBox></td>
                <td style="width: 22%"></td>
                <td style="width: 22%"></td>
                <td style="width: 22%">
                    <asp:Button ID="AddNewFish" runat="server" Font-Names="Tahoma"
                        Font-Size="Small" OnClientClick="return JavaAddNewFish();" Text="New row" />
                    <br />
                    <asp:Button ID="AddNewFish25" runat="server"
                        Font-Names="Tahoma" Font-Size="Small"
                        OnClientClick="return JavaAddNewFish50();"
                        Text="50 new row" /></td>
            </tr>
        </table>--%>

        <table class="table table-responsive table-borderless" style="width: 95%" id="ButtonTable" dir="ltr">
            <tr>

                <td colspan="3" dir="ltr" style="height: 26px; text-align: left">Please collect the total premium amount <span style="color: #ff0066">only </span>via receipt
                    Deposit to Sepehri account number 0100055555002 with Bank Saderat Iran, Fatemi branch Branch code
                    763 (payable in all branches of Bank Saderat Iran) by mentioning the insurer ID code in the receipt
                    Bank, deposit <span style="color: #ff0066">and pay via satna, paya, check
                        Avoid interbank and ...
                        <br />
                        separately
                        <br />
                        &nbsp; The above content is approved &nbsp;
                        <input id="Checkbox1" type="checkbox" onclick="xfun()" /></span></td>
                <td style="width: 100px; height: 26px"></td>
                <td style="width: 100px; height: 26px"></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 26px;"></td>
                <td style="width: 100px; height: 26px;">
                    <asp:Button ID="SubmitBt" runat="server" Font-Names="Tahoma" OnClick="SubmitBt_Click" OnClientClick="return JavaSubmit()"
                        Text="Submit" Width="150px" /></td>
                <td style="width: 100px; height: 26px;"></td>
                <td style="width: 100px; text-align: center; height: 26px;">
                    <asp:Button ID="ReturnBt" runat="server" Font-Names="Tahoma"
                        Text="Abourt" Width="150px" OnClick="ReturnBt_Click" /></td>

                <td style="width: 100px; height: 26px;"></td>
            </tr>
        </table>
        <br />
        <br />
        <asp:TextBox ID="HiddenFishField" runat="server" Font-Size="XX-Small" Height="1px"
            Width="1px"></asp:TextBox><br />
        &nbsp;
        <br />
        <table class="table table-responsive table-borderless" style="visibility: hidden">
            <tr>
                <td style="width: 100px">وضعیت</td>
                <td style="width: 100px">عادی</td>
                <td style="width: 100px">تکمیلی</td>
            </tr>
            <tr>
                <td style="width: 100px">شاغل</td>
                <td style="width: 100px">
                    <asp:TextBox ID="Price_Normal_Worker" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:TextBox ID="Price_Takmili_Worker" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">بازنشسته ما</td>
                <td style="width: 100px">
                    <asp:TextBox ID="Price_Normal_OurBaz" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:TextBox ID="Price_Takmili_OurBaz" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">بازنشسته سایر</td>
                <td style="width: 100px">
                    <asp:TextBox ID="Price_Normal_OtherBaz" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:TextBox ID="Price_Takmili_OtherBaz" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">sood</td>
                <td style="width: 100px">
                    <asp:TextBox ID="TextBox_SOOD" runat="server" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 100px"></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:TextBox ID="txtWorkerNum_oldprice" runat="server" Font-Names="Tahoma" onkeypress="return FilterNumric(event)"
                        onkeyup="CalcSum()" Width="100%"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtOurBazNum_oldprice" runat="server" Font-Names="Tahoma" onkeypress="return FilterNumric(event)"
                        onkeyup="CalcSum()" Width="100%"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtTimeOffNum_oldprice" runat="server" Font-Names="Tahoma" onkeypress="return FilterNumric(event)"
                        onkeyup="CalcSum()" Width="100%" Enabled="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 18px"></td>
                <td style="width: 100px; height: 18px">
                    <asp:TextBox ID="txtOtherBazNum_oldprice" runat="server" Font-Names="Tahoma" onkeypress="return FilterNumric(event)"
                        onkeyup="CalcSum()" Width="100%"></asp:TextBox></td>
                <td style="width: 100px; height: 18px">
                    <asp:TextBox ID="txtSumNum_oldprice" runat="server" Font-Names="Tahoma" onkeypress="return FilterNumric(event)"
                        onkeyup="CalcSum()" Width="100%" Enabled="False"></asp:TextBox></td>
            </tr>
        </table>
    </div>

    <script src="../Content/Script/jquery-1.11.3.js" type="text/javascript"></script>
    <script src="../Content/Script/xutil.js" type="text/javascript"></script>
    <script src="../Content/Script/xdate.js" type="text/javascript"></script>

    <script lang="JavaScript" type="text/javascript">
        window.onload = InitPage;
        window.onkeydown = MyKeyHandler(event);

        function xfun() {
            document.getElementById("SubmitBt").disabled = false;
            document.getElementById("Checkbox1").disabled = true;
            return true;
        }
        function yfun() {
           
            if ($(document).ready($('#FileUpload1').length > 0)) {
               
                $('#FileUpload1').disabled = false;
                window.alert('ok3');
                document.getElementById('FileUpload2').disabled = false;
                document.getElementById("FileUpload3").disabled = false;
                document.getElementById("FileUpload4").disabled = false;
                document.getElementById("Checkbox2").disabled = true;
                window.alert('ok');
            }
            else {
                window.alert('Not');
            }

        }


        function fnBeforePaste() { event.returnValue = false; }
        function MyOnPast(fname) {
            var pdata = window.clipboardData.getData("Text")
            var xline = pdata.split("\n");

            var i = 0;


            for (i = 0; i < xline.length; i++)
                if (document.getElementById(fname + (i + 1)))
                    document.getElementById(fname + (i + 1)).value = xline[i];

            return false;
        }


        var FILD_SEPERATOR = "$";
        var RECORD_SEPERATOR = "#";

        var FishSum = 0;
        var ContractSum = 0;
        var FishRowNumber = 0;
        var BadFishFlag = false;
        var OutFishFlag = false;

        function JavaSubmit() {
            CalcSum();
            CalcFishSum();

            // check if there is no data missisng
            var Err_In_Worker_Line_Time = "لطفا تعداد ماه شاغلين را وارد نماييد";
            var Err_In_Worker_Line_Num = "لطفا تعداد شاغلين را وارد نماييد";

            var Err_In_OurBaz_Line_Time = "لطفا تعداد ماه بازنشستگان صندوق بازنشستگي را وارد نماييد";
            var Err_In_OurBaz_Line_Num = "لطفا تعداد بازنشستگان صندوق بازنشستگي را وارد نماييد";

            var Err_In_OtherBaz_Line_Time = "لطفا تعداد ماه بازنشستگان ساير صندوق ها را وارد نماييد";
            var Err_In_OtherBaz_Line_Num = "لطفا تعداد بازنشستگان صندوق بازنشستگي را وارد نماييد";

            var Err_In_TimeOff_Line_Num = "لطفا تعداد مرخصين را وارد نماييد";
            var Err_In_TimeOff_Line_Time = "لطفا تعداد ماه مرخصين را وارد نماييد";

            if (DlmVal(document.getElementById("txtWorkerNum").value) > 0 && DlmVal(document.getElementById("txtWorkerTime").value) == 0) { alert(Err_In_Worker_Line_Time); return false; }


            if (DlmVal(document.getElementById("txtOurBazNum").value) > 0 && DlmVal(document.getElementById("txtOurBazTime").value) == 0) { alert(Err_In_OurBaz_Line_Time); return false; }

            if (DlmVal(document.getElementById("txtOtherBazNum").value) > 0 && DlmVal(document.getElementById("txtOtherBazTime").value) == 0) { alert(Err_In_OtherBaz_Line_Time); return false; }


            if (ContractSum == 0) {
                alert("لطفا تعداد افراد را مشخص نماييد");
                return false;
            }

            if (ContractSum > FishSum) {
                alert("جمع مبلغ فيش ها كمتر از مبلغ قرار داد است");
                return false;
            }

            return SaveAllFishesOnHiddenField();


        }

        function SaveAllFishesOnHiddenField() {
            // create a list of fishes
            var i = 0;
            var idx = 1;
            var str = "";
            var err_str = "لطفا ليست فيش ها را به درستي كامل نماييد";



            document.getElementById("HiddenFishField").value = "";

            for (i = 0; i < FishRowNumber; i++) {
                // skip rows thst have no amount
                if (DlmVal(document.getElementById("FishAmount" + idx).value) == 0) continue;

                // if there is any record , add record seperator
                if (str.length) str += RECORD_SEPERATOR;

                if (document.getElementById("FishAmount" + idx).value == "" || document.getElementById("FishNumber" + idx).value == "" || document.getElementById("BankCode" + idx).value == "" || document.getElementById("FishDate" + idx).value == "") { alert(err_str); return false; }


                str += "bad" + FILD_SEPERATOR +
                    document.getElementById("FishAmount" + idx).value + FILD_SEPERATOR +
                    document.getElementById("FishNumber" + idx).value + FILD_SEPERATOR +
                    document.getElementById("BankCode" + idx).value + FILD_SEPERATOR +
                    document.getElementById("FishDate" + idx).value;

                idx++;
            }
            document.getElementById("HiddenFishField").value = str;

            return true;
        }
        function JavaPrintForm() {

            if (SaveAllFishesOnHiddenField() == false) return false;

            toggleBox("FishListTab", 0);
            toggleBox("FishList", 0);
            toggleBox("ButtonTable", 0);
            toggleBox("HiddenFishField", 0);

            window.print();

            toggleBox("FishListTab", 1);
            toggleBox("FishList", 1);
            toggleBox("ButtonTable", 1);
            toggleBox("HiddenFishField", 1);

            return true;
        }
        var FishListVisible = 0;
        function ShowHideFishList() {
            var icon = "";
            toggleBox("FishList", FishListVisible);
            if (FishListVisible == 1) { FishListVisible = 0; icon = "r"; } else { FishListVisible = 1; icon = "1"; }

            document.getElementById("ShowHideFishes").value = icon;

            return false;
        }



        function CalcFishSum() {
            var i = 0;
            var sum = 0;

            for (i = 0; i < FishRowNumber; i++)
                sum += DlmVal(document.getElementById("FishAmount" + (i + 1)).value);

            document.getElementById("txtFishSum").value = DelemitLongNumber(sum + "");

            FishSum = sum;
        }

        var FocusFieldName = "";
        var FocusFieldNumb = 0;

        function MyKeyHandler(e) {
            var code = 0;
            if (FocusFieldName == "") return true;

            if (window.event) code = e.keyCode; else code = e.which;

            if (code == 38 && FocusFieldNumb * 1 > 1) {
                FocusFieldNumb--;
                document.getElementById(FocusFieldName + FocusFieldNumb).focus();
            }

            if (code == 40 && FocusFieldNumb * 1 < FishRowNumber * 1) {
                FocusFieldNumb++;
                document.getElementById(FocusFieldName + FocusFieldNumb).focus();
            }

            return true;
        }

        function JavaAddNewFish50() {
            var i = 0;
            for (i = 0; i < 50; i++)JavaAddNewFish();
            return false;
        }

        function JavaAddNewFish() {

            var FishAmountPastCode = "";
            var FishNumberPastCode = "";
            var FishBankCodePastCode = "";
            var FishDatePastCode = "";

            if (FishRowNumber == 0) {
                var FishAmountPastCode = " onbeforepaste='fnBeforePaste()' onpaste='return MyOnPast(\"FishAmount\")' ";
                var FishNumberPastCode = " onbeforepaste='fnBeforePaste()' onpaste='return MyOnPast(\"FishNumber\")' ";
                var FishBankCodePastCode = " onbeforepaste='fnBeforePaste()' onpaste='return MyOnPast(\"BankCode\")' ";
                var FishDatePastCode = " onbeforepaste='fnBeforePaste()' onpaste='return MyOnPast(\"FishDate\")' ";
            }

            FishRowNumber++;

            var newRow = document.all("FishList").insertRow(FishRowNumber + 1);
            if (BadFishFlag) newRow.style.background = "#FF0000";
            if (OutFishFlag) newRow.style.background = "#0000FF";

            var oCell = newRow.insertCell();
            oCell.innerHTML = "" + FishRowNumber;


            oCell = newRow.insertCell();
            oCell.innerHTML = "<input type='text' onblur=\"FocusFieldName='';\" onfocus=\"FocusFieldName='FishAmount';FocusFieldNumb=" + FishRowNumber + ";\" onkeyup=\"CalcFishSum()\"  name='FishAmount" + FishRowNumber + "' " + FishAmountPastCode + ">";

            oCell = newRow.insertCell();
            oCell.innerHTML = "<input type='text' onblur=\"FocusFieldName='';\" onfocus=\"FocusFieldName='FishNumber';FocusFieldNumb=" + FishRowNumber + ";\" name='FishNumber" + FishRowNumber + "' " + FishNumberPastCode + ">";

            oCell = newRow.insertCell();
            oCell.innerHTML = "<input type='text' onblur=\"FocusFieldName='';\" onfocus=\"FocusFieldName='BankCode';FocusFieldNumb=" + FishRowNumber + ";\" name='BankCode" + FishRowNumber + "' " + FishBankCodePastCode + ">";

            oCell = newRow.insertCell();

            var s = "<dir=\"ltr\">";
            s += "<input type='button' value='...' name='FishDatePicker" + FishRowNumber + "'";
            s += " onclick=\"displayDatePicker('FishDate" + FishRowNumber + "');\">";
            oCell.innerHTML = s;
            oCell.dir = "ltr";
            oCell.innerHTML += "<input type='text'onblur=\"FocusFieldName='';\" onfocus=\"FocusFieldName='FishDate';FocusFieldNumb=" + FishRowNumber + ";\"  name='FishDate" + FishRowNumber + "' " + FishDatePastCode + ">";

            return false;

            oCell.innerHTML += "<input type='text' name='FishDate" + FishRowNumber + "'>";

            return false;
        }


        function InitPage() {

            var i = 0;
            var idx = 1;
            var fishmax = 0;
            var records;

            // check error message
            var msg = document.getElementById("MsgBox").value;

            document.getElementById("MsgBox").value = "";

            if (msg == "Fish_Not_Found") document.getElementById("MsgBox").value += "فيش هايي كه با رنگ قرمز مشخص شده اند ،در ليست بانك موجود نيستند";
            if (msg == "Fish_Is_Out_Of_Stat") document.getElementById("MsgBox").value += "فيش هايي كه با رنگ آبي مشخص شده اند ،مربوط به استان شما نيستند  / ";

            if (msg == "Err_In_Save_Try_Again") document.getElementById("MsgBox").value = "اشكال در ذخيره كردن قرارداد - دوباره سعي كنيد";
            if (msg == "")
                toggleBox("MsgTbl", 0);
            else {
                toggleBox("MsgTbl", 1);
                if (document.getElementById("MsgBox").value == "")
                    document.getElementById("MsgBox").value = msg;
            }


            var str = document.getElementById("HiddenFishField").value;

            if (str.length > 0) {
                records = str.split(RECORD_SEPERATOR);

                for (i = 0; i < records.length; i++) {
                    var flds = records[i].split(FILD_SEPERATOR);

                    BadFishFlag = OutFishFlag = false;

                    if (flds[0] == "bad") BadFishFlag = true;
                    else
                        if (flds[0] == "out") OutFishFlag = true;

                    JavaAddNewFish();
                    BadFishFlag = OutFishFlag = false;

                    document.getElementById("FishAmount" + idx).value = flds[1];
                    document.getElementById("FishNumber" + idx).value = flds[2];
                    document.getElementById("BankCode" + idx).value = flds[3];
                    document.getElementById("FishDate" + idx).value = flds[4];

                    //<td style="width: 12%; height: 25px; background-color: #C0C0C0;">
                    idx++;
                }

                if (records.length < 5)
                    for (i = 0; i < 5 - records.length; i++) JavaAddNewFish();


            }
            else
                for (i = 0; i < 5; i++)  JavaAddNewFish();


            BadFishFlag = false;
            /*
        var dt= new XDate();       
            
        var cdate=dt.getFullYear()+"/";
        if(dt.getMonth()<10) cdate+="0"; cdate+=dt.getMonth()+"/";
        if(dt.getDate()<10)  cdate+="0"; cdate+=dt.getDate()+"";
        document.getElementById("ContractDate").value=cdate;          
        */

            CalcSum();
            CalcFishSum();

        }
        function CalcSum() {

            //txtWorkerNum
            var x = 0;
            var str = 'مدت ماه وارده حداكثر می تواند دوازده ماه باشد !';


            if (form1.txtWorkerTime.value * 1 > 12) { alert(str); form1.txtWorkerTime.value = 12; }

            if (form1.txtOurBazTime.value * 1 > 12) { alert(str); form1.txtOurBazTime.value = 12; }
            if (form1.txtOtherBazTime.value * 1 > 12) { alert(str); form1.txtOtherBazTime.value = 12; }
            if (form1.txtTimeOffNum.value * 1 > 0)
                form1.txtTimeOffTime.value = DlmVal(form1.txtTimeOffNum.value) * 12;



            if (DlmVal(document.getElementById("txtWorkerNum_oldprice").value) == 0) document.getElementById("txtWorkerNum_oldprice").value = "0";
            if (DlmVal(document.getElementById("txtOurBazNum_oldprice").value) == 0) document.getElementById("txtOurBazNum_oldprice").value = "0";
            if (DlmVal(document.getElementById("txtOtherBazNum_oldprice").value) == 0) document.getElementById("txtOtherBazNum_oldprice").value = "0";

            if (1 * form1.txtWorkerNum_oldprice.value > form1.txtWorkerNum.value) form1.txtWorkerNum_oldprice.value = "0";
            if (1 * form1.txtOurBazNum_oldprice.value > form1.txtOurBazNum.value) form1.txtOurBazNum_oldprice.value = "0";
            if (1 * form1.txtOtherBazNum_oldprice.value > form1.txtOtherBazNum.value) form1.txtOtherBazNum_oldprice.value = "0";




            var xobj = form1.Insure_Type;
            var xtype = xobj.options[xobj.selectedIndex].value;


            var SOOD = form1.TextBox_SOOD.value * 1;
            SOOD = 0;



            //WORKER  WORKER WORKER WORKER WORKER WORKER        
            var Takmili_worker_person_price = 10000 + SOOD;     // not used
            var Takmili_worker_device_price = 6000;     // not used


            var Normal_worker_device_price = 17490;
            var Normal_worker_person_price = 0;

            if (xtype == 1) Normal_worker_person_price = 17490;

            // not used
            /*
            if(xtype==2) Normal_worker_person_price=25000;
            if(xtype==3) Normal_worker_person_price=65000;    
            */
            form1.txtWorkerNum_oldprice.value = form1.txtWorkerNum.value;

            var w_time = DlmVal(form1.txtWorkerTime.value);

            var w_new_num = DlmVal(form1.txtWorkerNum.value) - DlmVal(form1.txtWorkerNum_oldprice.value);
            var w_new_pay = w_new_num * w_time * Takmili_worker_person_price;

            var w_old_num = DlmVal(form1.txtWorkerNum_oldprice.value)
            var w_old_pay = w_old_num * w_time * Normal_worker_person_price;



            form1.txtWorkerPay.value = w_new_pay + w_old_pay;


            w_new_pay = w_new_num * w_time * Takmili_worker_device_price;
            w_old_pay = w_old_num * w_time * Normal_worker_device_price;


            form1.txtDeviceWorkerPay.value = w_new_pay + w_old_pay;
            form1.txtWorkerSumPay.value = DlmVal(form1.txtWorkerPay.value) + DlmVal(form1.txtDeviceWorkerPay.value);

            //WORKER  WORKER WORKER WORKER WORKER WORKER 
            // OUR BAZ  OUR BAZ  OUR BAZ  OUR BAZ  OUR BAZ  OUR BAZ     
            var Takmili_ourbaz_person_price = 8000 + SOOD;
            var Takmili_ourbaz_device_price = 6000;

            var Normal_ourbaz_device_price = 17490;
            var Normal_ourbaz_person_price = 0;

            if (xtype == 1) Normal_ourbaz_person_price = 17490 - 2500;
            /*
            if(xtype==2) Normal_ourbaz_person_price=25000-2500;
            if(xtype==3) Normal_ourbaz_person_price=65000-2500;    
            */

            form1.txtOurBazNum_oldprice.value = form1.txtOurBazNum.value;

            var ou_time = DlmVal(form1.txtOurBazTime.value);

            var ou_new_num = DlmVal(form1.txtOurBazNum.value) - DlmVal(form1.txtOurBazNum_oldprice.value);
            var ou_new_pay = ou_new_num * ou_time * Takmili_ourbaz_person_price;

            var ou_old_num = DlmVal(form1.txtOurBazNum_oldprice.value)
            var ou_old_pay = ou_old_num * ou_time * Normal_ourbaz_person_price;

            form1.txtOurBazPay.value = ou_new_pay + ou_old_pay;

            ou_new_pay = ou_new_num * ou_time * Takmili_ourbaz_device_price;
            ou_old_pay = ou_old_num * ou_time * Normal_ourbaz_device_price;

            form1.txtDeviceOurBazPay.value = ou_new_pay + ou_old_pay;

            form1.txtOurBazSumPay.value = DlmVal(form1.txtOurBazPay.value) + DlmVal(form1.txtDeviceOurBazPay.value);
            // OUR BAZ  OUR BAZ  OUR BAZ  OUR BAZ  OUR BAZ  OUR BAZ     


            // OTHER BAZ  OTHER BAZ  OTHER BAZ  OTHER BAZ  OTHER BAZ  OTHER BAZ 
            var Takmili_otherbaz_person_price = 10000 + SOOD;
            var Takmili_otherbaz_device_price = 6000;

            var Normal_otherbaz_device_price = 17490;
            var Normal_otherbaz_person_price = 0;

            if (xtype == 1) Normal_otherbaz_person_price = 17490;
            /*
            if(xtype==2) Normal_otherbaz_person_price=25000;
            if(xtype==3) Normal_otherbaz_person_price=65000;    
            */



            form1.txtOtherBazNum_oldprice.value = form1.txtOtherBazNum.value;

            var ot_time = DlmVal(form1.txtOtherBazTime.value);


            var ot_new_num = DlmVal(form1.txtOtherBazNum.value) - DlmVal(form1.txtOtherBazNum_oldprice.value);
            var ot_new_pay = ot_new_num * ot_time * Takmili_otherbaz_person_price;

            var ot_old_num = DlmVal(form1.txtOtherBazNum_oldprice.value)
            var ot_old_pay = ot_old_num * ot_time * Normal_otherbaz_person_price;


            form1.txtOtherBazPay.value = ot_new_pay + ot_old_pay;

            ot_new_pay = ot_new_num * ot_time * Takmili_otherbaz_device_price;
            ot_old_pay = ot_old_num * ot_time * Normal_otherbaz_device_price;

            form1.txtDeviceOtherBazPay.value = ot_new_pay + ot_old_pay;


            form1.txtOtherBazSumPay.value = 1 * form1.txtOtherBazPay.value + 1 * form1.txtDeviceOtherBazPay.value;

            // OTHER BAZ  OTHER BAZ  OTHER BAZ  OTHER BAZ  OTHER BAZ  OTHER BAZ 

            // TIME OFF TIME OFF TIME OFF TIME OFF TIME OFF TIME OFF TIME OFF 
            var Takmili_timeoff_person_price = 17490;

            if (xtype == 1) Takmili_timeoff_person_price += 17490;
            /*
            if(xtype==2) Takmili_timeoff_person_price+=25000;
            if(xtype==3) Takmili_timeoff_person_price+=65000;    */



            form1.txtTimeOffSumPay.value = form1.txtTimeOffPay.value = Takmili_timeoff_person_price * DlmVal(form1.txtTimeOffTime.value);
            // TIME OFF TIME OFF TIME OFF TIME OFF TIME OFF TIME OFF TIME OFF 


            form1.txtSumNum_oldprice.value = w_old_num + ou_old_num + ot_old_num;

            form1.txtSumNum.value = DlmVal(form1.txtWorkerNum.value) + DlmVal(form1.txtOurBazNum.value) + DlmVal(form1.txtOtherBazNum.value) + DlmVal(form1.txtTimeOffNum.value);

            form1.txtPersonSumPay.value = DlmVal(form1.txtWorkerPay.value) + DlmVal(form1.txtOurBazPay.value) + DlmVal(form1.txtOtherBazPay.value) + DlmVal(form1.txtTimeOffPay.value);
            form1.txtDeviceSumPay.value = DlmVal(form1.txtDeviceWorkerPay.value) + DlmVal(form1.txtDeviceOurBazPay.value) + DlmVal(form1.txtDeviceOtherBazPay.value);
            form1.txtMustPay.value = DlmVal(form1.txtWorkerSumPay.value) + DlmVal(form1.txtOurBazSumPay.value) + DlmVal(form1.txtOtherBazSumPay.value) + DlmVal(form1.txtTimeOffSumPay.value);

            //***************** delemiters        

            form1.txtWorkerPay.value = DelemitLongNumber(form1.txtWorkerPay.value);
            form1.txtDeviceWorkerPay.value = DelemitLongNumber(form1.txtDeviceWorkerPay.value);
            form1.txtWorkerSumPay.value = DelemitLongNumber(form1.txtWorkerSumPay.value);
            form1.txtOurBazPay.value = DelemitLongNumber(form1.txtOurBazPay.value);
            form1.txtDeviceOurBazPay.value = DelemitLongNumber(form1.txtDeviceOurBazPay.value);
            form1.txtOurBazSumPay.value = DelemitLongNumber(form1.txtOurBazSumPay.value);
            form1.txtDeviceOtherBazPay.value = DelemitLongNumber(form1.txtDeviceOtherBazPay.value);
            form1.txtOtherBazPay.value = DelemitLongNumber(form1.txtOtherBazPay.value);
            form1.txtOtherBazSumPay.value = DelemitLongNumber(form1.txtOtherBazSumPay.value);
            form1.txtSumNum.value = DelemitLongNumber(form1.txtSumNum.value);
            form1.txtPersonSumPay.value = DelemitLongNumber(form1.txtPersonSumPay.value);
            form1.txtDeviceSumPay.value = DelemitLongNumber(form1.txtDeviceSumPay.value);
            form1.txtTimeOffSumPay.value = form1.txtTimeOffPay.value = DelemitLongNumber(form1.txtTimeOffPay.value);
            form1.txtMustPay.value = DelemitLongNumber(form1.txtMustPay.value);
            ContractSum = DlmVal(form1.txtMustPay.value);
        }
        /*********************************************************************/
        /*********************************************************************/
        /*********************************************************************/
        var datePickerDivID = "datepicker";
        var iFrameDivID = "datepickeriframe";

        var dayArrayShort = new Array('شنبه', 'يكشنبه', 'دو شنبه', 'سه شنبه', 'چهار شنبه', 'پنج شنبه', 'جمعه');

        var dayArrayMed = new Array('شنبه', 'يكشنبه', 'دو شنبه', 'سه شنبه', 'چهار شنبه', 'پنج شنبه', 'جمعه');

        var dayArrayLong = new Array('شنبه', 'يكشنبه', 'دو شنبه', 'سه شنبه', 'چهار شنبه', 'پنج شنبه', 'جمعه');
        var monthArrayShort = new Array('فروردين', 'ارديبهشت', 'خرداد', 'تير', 'مرداد', 'شهريور', 'مهر', 'آبان', 'آذر', 'دي', 'بهمن', 'اسفند');
        var monthArrayMed = new Array('فروردين', 'ارديبهشت', 'خرداد', 'تير', 'مرداد', 'شهريور', 'مهر', 'آبان', 'آذر', 'دي', 'بهمن', 'اسفند');
        var monthArrayLong = new Array('فروردين', 'ارديبهشت', 'خرداد', 'تير', 'مرداد', 'شهريور', 'مهر', 'آبان', 'آذر', 'دي', 'بهمن', 'اسفند');

        var defaultDateSeparator = "/";        // common values would be "/" or "."
        var defaultDateFormat = "ymd"    // valid values are "mdy", "dmy", and "ymd"
        var dateSeparator = defaultDateSeparator;
        var dateFormat = defaultDateFormat;


        function displayDatePicker(dateFieldName, displayBelowThisObject) {

            var targetDateField = document.getElementsByName(dateFieldName).item(0);

            // if we weren't told what node to display the datepicker beneath, just display it
            // beneath the date field we're updating
            if (!displayBelowThisObject)
                displayBelowThisObject = targetDateField;


            dateSeparator = defaultDateSeparator;

            dateFormat = defaultDateFormat;

            var x = displayBelowThisObject.offsetLeft;
            var y = displayBelowThisObject.offsetTop + displayBelowThisObject.offsetHeight;

            var parent = displayBelowThisObject;
            while (parent.offsetParent) {
                parent = parent.offsetParent;
                x += parent.offsetLeft;
                y += parent.offsetTop;
            }

            drawDatePicker(targetDateField, x, y);
        }

        function drawDatePicker(targetDateField, x, y) {
            var dt = getFieldDate(targetDateField.value);

            if (!document.getElementById(datePickerDivID)) {
                var newNode = document.createElement("div");
                newNode.setAttribute("id", datePickerDivID);
                newNode.setAttribute("class", "dpDiv");
                newNode.setAttribute("style", "visibility: hidden;");
                document.body.appendChild(newNode);
            }

            var pickerDiv = document.getElementById(datePickerDivID);
            pickerDiv.style.position = "absolute";
            pickerDiv.style.left = x + "px";
            pickerDiv.style.top = y + "px";
            pickerDiv.style.visibility = (pickerDiv.style.visibility == "visible" ? "hidden" : "visible");
            pickerDiv.style.display = (pickerDiv.style.display == "block" ? "none" : "block");
            pickerDiv.style.zIndex = 10000;

            refreshDatePicker(targetDateField.name, dt.getFullYear(), dt.getMonth(), dt.getDate());
        }

        function refreshDatePicker(dateFieldName, year, month, day) {

            var thisDay = new XDate();
            if ((month >= 0) && (year > 0)) {
                thisDay = new XDate(year, month, 1);
            } else {
                day = thisDay.getDate();
                thisDay.setDate(1);
            }

            var crlf = "\r\n";
            var TABLE = "<table cols=7 dir='rtl' class='dpTable'>" + crlf;
            var xTABLE = "</table>" + crlf;
            var TR = "<tr class='dpTR'>";
            var TR_title = "<tr  class='dpTitleTR'>";
            var TR_days = "<tr class='dpDayTR'>";
            var TR_todaybutton = "<tr class='dpTodayButtonTR'>";
            var xTR = "</tr>" + crlf;
            var TD = "<td  class='dpTD' onMouseOut='this.className=\"dpTD\";' onMouseOver=' this.className=\"dpTDHover\";' ";    // leave this tag open, because we'll be adding an onClick event
            var TD_title = "<td colspan=5 class='dpTitleTD'>";
            var TD_buttons = "<td class='dpButtonTD'>";
            var TD_todaybutton = "<td colspan=7 class='dpTodayButtonTD'>";
            var TD_days = "<td nowrap class='dpDayTD'>";
            var TD_selected = "<td class='dpDayHighlightTD' onMouseOut='this.className=\"dpDayHighlightTD\";' onMouseOver='this.className=\"dpTDHover\";' ";    // leave this tag open, because we'll be adding an onClick event
            var xTD = "</td>" + crlf;
            var DIV_title = "<div class='dpTitleText'>";
            var DIV_selected = "<div class='dpDayHighlight'>";
            var xDIV = "</div>";

            var html = TABLE;

            html += TR_title;
            html += TD_buttons + getButtonCode(dateFieldName, thisDay, -1, "ماه قبل") + xTD;
            html += TD_title + DIV_title + monthArrayLong[thisDay.getMonth() - 1] + " " + thisDay.getFullYear() + xDIV + xTD;
            html += TD_buttons + getButtonCode(dateFieldName, thisDay, 1, "ماه بعد") + xTD;
            html += xTR;

            html += TR_days;
            for (i = 0; i < dayArrayShort.length; i++)
                html += TD_days + dayArrayShort[i] + xTD;
            html += xTR;

            html += TR;


            for (i = 0; i < thisDay.getDay(); i++)
                html += TD + "&nbsp;" + xTD;

            do {
                dayNum = thisDay.getDate();

                TD_onclick = " onclick=\"updateDateField('" + dateFieldName + "', '" + getDateString(thisDay) + "');\">";

                if (dayNum == day)
                    html += TD_selected + TD_onclick + DIV_selected + dayNum + xDIV + xTD;
                else
                    html += TD + TD_onclick + dayNum + xTD;

                if (thisDay.getDay() == 6)
                    html += xTR + TR;

                thisDay.setDate(thisDay.getDate() + 1);
            } while (thisDay.getDate() > 1)

            if (thisDay.getDay() > 0) {
                for (i = 6; i > thisDay.getDay(); i--)
                    html += TD + "&nbsp;" + xTD;
            }
            html += xTR;

            var today = new XDate();
            var todayString = "Today is " + dayArrayMed[today.getDay()] + ", " + monthArrayMed[today.getMonth() - 1] + " " + today.getDate();
            html += TR_todaybutton + TD_todaybutton;
            html += "<button style='width: 60' class='dpTodayButton' onClick='refreshDatePicker(\"" + dateFieldName + "\");'>روز جاري</button> ";
            html += "<button style='width: 60' class='dpTodayButton' onClick='updateDateField(\"" + dateFieldName + "\");'>خروج</button>";
            html += xTD + xTR;

            html += xTABLE;

            document.getElementById(datePickerDivID).innerHTML = html;
            adjustiFrame();
        }

        function getButtonCode(dateFieldName, dateVal, adjust, label) {
            var newMonth = dateVal.getMonth();
            var newYear = dateVal.getFullYear();
            if (newMonth + adjust > 12) { newMonth = 1; newYear++; }
            else
                if (newMonth + adjust <= 0) { newMonth = 12; newYear--; }
                else
                    newMonth += adjust

            return "<button class='dpButton' onClick='refreshDatePicker(\"" + dateFieldName + "\", " + newYear + ", " + newMonth + ");'>" + label + "</button>";
        }

        function getDateString(dateVal) {
            var dayString = "00" + dateVal.getDate();
            var monthString = "00" + (dateVal.getMonth());
            dayString = dayString.substring(dayString.length - 2);
            monthString = monthString.substring(monthString.length - 2);

            switch (dateFormat) {
                case "dmy":
                    return dayString + dateSeparator + monthString + dateSeparator + dateVal.getFullYear();
                case "ymd":
                    return dateVal.getFullYear() + dateSeparator + monthString + dateSeparator + dayString;
                case "mdy":
                default:
                    return monthString + dateSeparator + dayString + dateSeparator + dateVal.getFullYear();
            }
        }

        function getFieldDate(dateString) {
            var dateVal;
            var dArray;
            var d, m, y;

            try {
                dArray = splitDateString(dateString);
                if (dArray) {
                    d = parseInt(dArray[2], 10);
                    m = parseInt(dArray[1], 10);
                    y = parseInt(dArray[0], 10);
                    dateVal = new XDate(y, m, d);
                }
                else dateVal = new XDate();
            }
            catch (e) {
                dateVal = new XDate();
            }

            return dateVal;
        }

        function splitDateString(dateString) {
            var dArray;
            if (dateString.indexOf("/") >= 0)
                dArray = dateString.split("/");
            else if (dateString.indexOf(".") >= 0)
                dArray = dateString.split(".");
            else if (dateString.indexOf("-") >= 0)
                dArray = dateString.split("-");
            else if (dateString.indexOf("\\") >= 0)
                dArray = dateString.split("\\");
            else
                dArray = false;

            return dArray;
        }


        function datePickerClosed(dateField) {
            var dateObj = getFieldDate(dateField.value);
            var today = new XDate();
            today = new XDate(today.getFullYear(), today.getMonth(), today.getDate());

            if (dateField.name == "StartDate") {
                if (dateObj < today) {

                    alert("Please enter a date that is today or later");
                    dateField.value = "";
                    document.getElementById(datePickerDivID).style.visibility = "visible";
                    adjustiFrame();
                } else {

                    dateObj.setTime(dateObj.getTime() + (7 * 24 * 60 * 60 * 1000));
                    var endDateField = document.getElementsByName("EndDate").item(0);
                    endDateField.value = getDateString(dateObj);
                }
            }
        }

        function updateDateField(dateFieldName, dateString) {
            var targetDateField = document.getElementsByName(dateFieldName).item(0);
            if (dateString)
                targetDateField.value = dateString;

            var pickerDiv = document.getElementById(datePickerDivID);
            pickerDiv.style.visibility = "hidden";
            pickerDiv.style.display = "none";

            adjustiFrame();
            targetDateField.focus();

            if ((dateString) && (typeof (datePickerClosed) == "function"))
                datePickerClosed(targetDateField);
        }

        function adjustiFrame(pickerDiv, iFrameDiv) {
            var is_opera = (navigator.userAgent.toLowerCase().indexOf("opera") != -1);
            if (is_opera)
                return;
            try {
                if (!document.getElementById(iFrameDivID)) {
                    var newNode = document.createElement("iFrame");
                    newNode.setAttribute("id", iFrameDivID);
                    newNode.setAttribute("src", "javascript:false;");
                    newNode.setAttribute("scrolling", "no");
                    newNode.setAttribute("frameborder", "0");
                    document.body.appendChild(newNode);
                }

                if (!pickerDiv)
                    pickerDiv = document.getElementById(datePickerDivID);
                if (!iFrameDiv)
                    iFrameDiv = document.getElementById(iFrameDivID);

                try {
                    iFrameDiv.style.position = "absolute";
                    iFrameDiv.style.width = pickerDiv.offsetWidth;
                    iFrameDiv.style.height = pickerDiv.offsetHeight;
                    iFrameDiv.style.top = pickerDiv.style.top;
                    iFrameDiv.style.left = pickerDiv.style.left;
                    iFrameDiv.style.zIndex = pickerDiv.style.zIndex - 1;
                    iFrameDiv.style.visibility = pickerDiv.style.visibility;
                    iFrameDiv.style.display = pickerDiv.style.display;

                } catch (e) {
                }

            } catch (ee) {
            }
        }


    </script>
</asp:Content>
