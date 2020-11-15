<%@ Page Title="" Language="C#" MasterPageFile="~/InsuredAgentOrg/Login/GeneralMaster.Master" AutoEventWireup="true" CodeBehind="OrganLogin.aspx.cs" Inherits="LifeInsWebApp.InsuredAgentOrg.Login.OrganLogin" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script lang="javascript" type="text/javascript">
        function CheckNumeric($char, $mozChar) {
            if ($mozChar != null) { // Look for a Mozilla-compatible browser
                if (($mozChar >= 48 && $mozChar <= 57) || $mozChar == 0 || $char == 8 || $mozChar == 13) $RetVal = true;
                else {
                    $RetVal = false;
                    //alert('لطفا عدد وارد نماييد');
                }
            }
            else { // Must be an IE-compatible Browser
                if (($char >= 48 && $char <= 57) || $char == 13) $RetVal = true;
                else {
                    $RetVal = false;
                    //alert('لطفا عدد وارد نماييد');
                }
            }
            return $RetVal;
        }

        ////////////////////////////////////////////
        function Check($char, $mozChar) {


            var key;
            if (window.event)
                key = window.event.keyCode;
            alert(key);
            debugger;
            // window.event.keyCode=' !"#$%&#1548;&#1711;)(×+&#1608;-./0123456789:&#1603;,=.&#1567;@&#1616;&#1584;}&#1609;&#1615;&#1610;&#1604;&#1575;÷&#1600;&#1548;/&#8217;&#1583;×&#1563;&#1614;&#1569;&#1613;&#1601;&#8216;{&#1611;&#1618;&#1573;~&#1580;&#1688;&#1670;^_&#1662;&#1588;&#1584;&#1586;&#1610;&#1579;&#1576;&#1604;&#1575;&#1607;&#1578;&#1606;&#1605;&#1574;&#1583;&#1582;&#1581;&#1590;&#1602;&#1587;&#1601;&#1593;&#1585;&#1589;&#1591;&#1594;&#1592;<|>&#1617;'.charCod();
            alert("---");//+window.event.keyCode);
            if (key.substring(window.event.keyCode) > 0)
                alert("::::" + key.substring(window.event.keyCode));
            //if (key>31)
            //  if (key<128)
            //  {
            //    if (window.event)
            //      window.event.keyCode=' !"#$%&#1548;&#1711;)(×+&#1608;-./0123456789:&#1603;,=.&#1567;@&#1616;&#1584;}&#1609;&#1615;&#1610;&#1604;&#1575;÷&#1600;&#1548;/&#8217;&#1583;×&#1563;&#1614;&#1569;&#1613;&#1601;&#8216;{&#1611;&#1618;&#1573;~&#1580;&#1688;&#1670;^_&#1662;&#1588;&#1584;&#1586;&#1610;&#1579;&#1576;&#1604;&#1575;&#1607;&#1578;&#1606;&#1605;&#1574;&#1583;&#1582;&#1581;&#1590;&#1602;&#1587;&#1601;&#1593;&#1585;&#1589;&#1591;&#1594;&#1592;<|>&#1617;'.charCodeAt(key-32);



        }
        function startTime() {
            var today = new Date()
            var h = today.getHours()
            var m = today.getMinutes()
            var s = today.getSeconds()
            // add a zero in front of numbers < 10
            m = checkTime(m)
            s = checkTime(s)
            document.getElementById('txt').innerHTML = h + ":" + m + ":" + s
            t = setTimeout('startTime()', 500)
        }
        function checkTime(i) {
            if (i < 10) { i = "0" + i }
            return i
        }
        /////////////////Sedighi
        function hyplnkForgetPass_Click() {
            var PrefixNameCtrl = "ctl00_ContentPlaceHolder1_";
            if (document.getElementById("SendPassPnl").style.display == "none") {
                document.getElementById("SendPassPnl").style.display = "";
                document.getElementById("tblLogin").style.display = "none";
                document.form1['txtUid'].focus();
                //document.all('txtUid').focus();
                //document.getElementById("tblSendPassDes").style.display = "none";



            } else if (document.getElementById("SendPassPnl").style.display == "") {
                document.getElementById("SendPassPnl").style.display = "none";
                document.getElementById("tblLogin").style.display = "";
                document.form1['SignInUser'].focus();
                //document.all('SignInUser').focus();
                //document.getElementById("tblSendPassDes").style.display = "";

            }
        }
        //        function  btnreturn_Click()
        //        {
        //         document.getElementById("SendPassPnl").style.display = "none";
        //         document.getElementById("tblLogin").style.display = "";
        //         //document.getElementById("tblSendPassDes").style.display = "";
        //        }

        function SendOnEnter(id, evt) {
            var keyCode = document.all ? evt.keyCode : evt.which ? evt.which :
                evt.keyCode ? evt.keyCode : evt.charcode;
            if (keyCode == 13) { document.getElementById(id).click(); return false; }
            return true;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" row container-fluid">
        <div class="col-3 "></div>
        <div class=" col-6 align-items-center  ">
            <div class="card   bg-light ">
                <div class="card-header bg-dark text-white">
                    <label id="Label2">Login to the system</label>
                </div>
                <div class="card-body container   m-0">
                    <div class="card-title m-0">
                        <asp:Label ID="lblMessage" runat="server" Font-Names="Tahoma" ForeColor="#960000"></asp:Label>
                    </div>
                    <div class="form-horizontal m-0 p-0">
                        <div class="form-group">
                            <span style="font-size: 10pt">&nbsp;Organ Id </span>
                            <asp:TextBox ID="SignInUser" runat="server" ValidationGroup="Login"
                                Class=" form-control-sm border-secondary" MaxLength="20" TabIndex="1"></asp:TextBox>
                            <asp:RequiredFieldValidator CssClass="text-danger" ValidationGroup="Login" ID="rfvUserName" runat="server"
                                ControlToValidate="SignInUser" SetFocusOnError="true" Display="Dynamic" ErrorMessage="The Username is Required !"></asp:RequiredFieldValidator>
                        </div>
                        <div class=" form-group">
                            <span style="font-size: 10pt">&nbsp;Password</span>
                            <asp:TextBox ID="SignInPass" runat="server" Class="form-control-sm" TextMode="Password"
                                MaxLength="30" TabIndex="2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPass" CssClass="text-danger" runat="server" ErrorMessage="The Password field is Required !" ControlToValidate="SignInPass" ValidationGroup="Login"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:CheckBox ID="SignInRemember" runat="server" />
                            <asp:Label ID="Label3" runat="server" CssClass="control-label" Text="Remember me ?"></asp:Label>
                        </div>
                    </div>
                    <ul class="list-group list-group-flush m-0">
                        <li class="list-group-item">
                            <asp:HyperLink ID="ImgHyp" runat="server">
                                <asp:Image ID="Image2" ImageUrl="../../Content/Image/refresh.png" runat="server" AlternateText="Try again" />
                            </asp:HyperLink>
                            <asp:Image ID="ImageCaptcha" ImageUrl="~/Model/CSPFCaptcha.ashx" runat="server" />
                        </li>
                        <li class="list-group-item">
                            <label for="TextBox_number">Please enter security code:</label>
                            <asp:TextBox ID="TextBox_number" runat="server" CssClass="clstxtl" EnableViewState="False"
                                TabIndex="3" MaxLength="5"></asp:TextBox>
                            <asp:Label ID="Label_invalid" EnableViewState="false" runat="server" Text="It is incorrect security code"
                                Visible="false" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="rfvCaptcha" runat="server" Text="Please Enter the Securitycode"
                                ValidationGroup="Login" Display="Dynamic" ControlToValidate="TextBox_number"
                                Width="175px"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator CssClass="text-danger" ID="revCaptcha" runat="server" ControlToValidate="TextBox_number"
                                ValidationGroup="Login" Display="Dynamic" ErrorMessage="It is incorrect"
                                ValidationExpression="\d{5}" Width="109px"></asp:RegularExpressionValidator>
                        </li>
                    </ul>
                        <asp:Button ID="SignInBt" runat="server" Text="Sign in" CssClass="clsbt" ValidationGroup="Login"
                            OnClick="SignInBt_Click" TabIndex="4" Width="60px" />
                        &nbsp;<asp:Button ID="btnCancle" runat="server" Text="Ignore" CssClass="clsbt" OnClick="btnCancle_Click"
                            TabIndex="5" Width="60px" />
                      <a class="btn-link" href="SignUp.aspx">Sign Up</a>
                </div>
                <div class="card-footer text-muted mt-0">
                    <asp:Label ID="Label1" runat="server" Font-Names="Tahoma" Font-Size="9pt">
                                              forgot your password? </asp:Label>
                    <a id="hyplnkForgetPass" class="hypNavy" style="cursor: pointer;" onclick="javascript:hyplnkForgetPass_Click();">
                    click Here. </a>
                </div>
            </div>
        </div>
        <div class="col-3"></div>
    </div>

</asp:Content>
