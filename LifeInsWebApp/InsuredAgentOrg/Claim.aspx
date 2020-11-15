<%@ Page Title="" Language="C#" MasterPageFile="~/InsuredAgentOrg/MasterPage.Master" AutoEventWireup="true" CodeBehind="Claim.aspx.cs" Inherits="LifeInsWebApp.InsuredAgentOrg.Claim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/SimpleCropper/css/jquery.Jcrop.css" rel="stylesheet" />
    <link href="../Content/SimpleCropper/css/style-example.css" rel="stylesheet" />
    <link href="../Content/SimpleCropper/css/style.css" rel="stylesheet" />


    <script lang="JavaScript" type="text/javascript">
        if (!String.prototype.startsWith) {
            Object.defineProperty(String.prototype, 'startsWith', {
                value: function (search, pos) {
                    pos = !pos || pos < 0 ? 0 : +pos;
                    return this.substring(pos, pos + search.length) === search;
                }
            });
        }

        var isShift = false;
        var seperator = "/";
        function fnAllowOnlyDigits() {
            if ((window.event.keyCode >= 48) && (window.event.keyCode <= 57)) {
                return true;
            }
            else {
                return false
            }

        };
        function ValidateDateFormat(input) {
            var dateString = input.value;
            if (window.event.keyCode == 16) {
                isShift = false;
            }
            var regex = /(13)(8[6-9]|9[0-9])[/](0[1-9]|1[0-2])[/](0[1-9]|1[1-9]|2[0-9]|3[0-1])\$/;
            //Check whether valid dd/MM/yyyy Date Format.
            if (regex.test(dateString) || dateString.length == 0) {
                ShowHideError(input, "none");
            } else {
                ShowHideError(input, "block");
            }
        };
        function IsNumeric(input) {
            if (window.event.keyCode == 16) {
                isShift = true;
            }
            //Allow only Numeric Keys.
            if (((window.event.keyCode >= 48 && window.event.keyCode <= 57) || window.event.keyCode == 8 || window.event.keyCode <= 37 || window.event.keyCode <= 39 || (window.event.keyCode >= 96 && window.event.keyCode <= 105)) && isShift == false) {
                if ((input.value.length == 4 || input.value.length == 7) && window.event.keyCode != 8) {
                    input.value += seperator;
                }

                return true;
            }
            else {
                return false;
            }
        };
        function ShowHideError(textbox, display) {
            var row = textbox.parentNode.parentNode;
            var errorMsg = row.getElementsByTagName("span")[0];
            if (errorMsg != null) {
                errorMsg.style.display = display;

            }
        };

        $(document).ready(function () {
            $('.cropme').simpleCropper();

            if ($("#hidImage").val().startsWith("data:image/")) {
                $("#tmpImage").attr("src", $("#hidImage").val());
            }
            if ($("#hidImage2").val().startsWith("data:image/")) {
                $("#tmpImage2").attr("src", $("#hidImage2").val());
            }

        });

        function copyToHiddenField() {

            $("#hidImage").val($(".cropme").children("img").attr("src"));
            $("#hidImage2").val($(".cropme").children("img").attr("src"));
        }


        function ShowImageDiv() {
            $('[id*=DivInfoPart3]').show();
        }
        $(document).ready(function selectValue() {

            var rbl = document.getElementById("<%=RdbChangeReason.ClientID %>");
            var radio = rbl.getElementsByTagName("INPUT");

            for (var i = 0; i < radio.length; i++) {
                radio[i].onchange = function () {
                    var radio = this;
                    if (radio.value == 1) {
                        ChangeSelect(1);
                    }
                    else {
                        ChangeSelect(2);
                    }
                };
            }
        });
        function ChangeSelect(ch) {
            if (ch == 1) {

                $('#<%= DrdHadeseReason.ClientID %>').attr('disabled', false); // shows dropdown

                $('#<%= DrdNaghType.ClientID %>').attr('disabled', true);
                $('#ListNaghsType').attr('disabled', true);
            }
            else {

                $('#<%= DrdHadeseReason.ClientID %>').attr('disabled', true); // shows dropdown
                $('#<%= DrdNaghType.ClientID %>').attr('disabled', false);
                $('#ListNaghsType').attr('disabled', false);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row mr-0 ml-1 mb-5" style="font-size:small">
        <div class="col-12">
            <nav class="navbar navbar-expand-lg  mb-4">
                <div>
                    <div class="form-inline mr-auto">
                        <label id="lb1ln" for="txtNationalCode">NationalCode</label>
                        <asp:TextBox ID="txtNationalCode" class="form-control " runat="server" placeholder="Nationalcode" AutoCompleteType="Disabled" aria-label="Search" />
                        <asp:Button ID="btnSearchNationalCode" class=" form-control btn btn-secondary btn-sm " runat="server" Text="Search" OnClick="btnSearchNationalCode_Click" ValidationGroup="ErrorMeli" OnClientClick="ShowImageDiv()" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidtxtNationalcode" runat="server" ErrorMessage="Please input Nationalcode." ControlToValidate="txtNationalCode" ValidationGroup="ErrorMeli" EnableClientScript="true" Display="Dynamic" SetFocusOnError="true" CssClass="text-danger"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revNationalCode" runat="server" ErrorMessage="Nationalcode is incurrect." ControlToValidate="txtNationalCode" Display="Dynamic" ValidationExpression="\d{8,10}" ValidationGroup="ErrorMeli" CssClass="text-danger"></asp:RegularExpressionValidator>
                        <asp:Label ID="lblkhata1" runat="server" CssClass="text-danger"></asp:Label>
                    </div>

                </div>
            </nav>
            <div id="DivPersonInfo" runat="server" visible="true" class="bg-light mr-0">
                <table dir="ltr" class="table table-responsive-sm  table-centralised table-bordered " style="background-color: #1fc8db; background-image: linear-gradient(141deg, #9fb8ad 0%, #1fc8db 51%, #2cb5e8 75%); opacity: 0.95">
                    <tr>
                        <th>
                            <asp:Label ID="LBL11" runat="server" Width="100%" Text="Name:"> </asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="lblName" runat="server" Width="100%"> </asp:Label>
                        </td>
                        <th>
                            <asp:Label ID="LBL2" runat="server" Width="100%" Text="Family:"> </asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="lblFamily" runat="server" Width="100%"> </asp:Label>
                        </td>
                        <th>
                            <asp:Label ID="lbl1Bith" runat="server" Width="100%" Text="Date Of Birth:"> </asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="lblBirthdate" runat="server" Width="100%"> </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="lbl1JobKind" runat="server" Width="100%" Text="Occupation Status:"> </asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="lblJobKind" runat="server" Width="100%"> </asp:Label>
                        </td>
                        <th>
                            <asp:Label ID="lbl1Daftar" runat="server" Width="100%" Text="Daftarkol Number:"> </asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="lblDafterKol" runat="server" Width="100%"> </asp:Label>
                        </td>
                        <th>
                            <asp:Label ID="lbl1ConDat" runat="server" Width="100%" Text="Date Of Contract:"> </asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="lblContractDate" runat="server" Width="100%"> </asp:Label>
                        </td>
                    </tr>
                </table>
            </div> 
            <div id="DivInfoPart1" runat="server" visible="true" class="bg-light mr-0 pr-4 pl-2">
                <div class="form-group">
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label for="txtHadeseDate" class="col-form-label">Date Of Death Or Diasability</label>
                            <asp:TextBox class="form-control" ID="txtHadeseDate" Width="100%" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please input a date." ControlToValidate="txtHadeseDate" Display="Dynamic" ValidationGroup="Errorsubmit" CssClass="text-danger"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegxDate" runat="server" ValidationExpression="(13|14)\d\d[/](0[1-9]|1[012])[/](0[1-9]|[1|2][0-9]|3[01])" ControlToValidate="txtHadeseDate" ErrorMessage="Date is incorrect." Display="Dynamic" ValidationGroup="Errorsubmit" CssClass="text-danger"></asp:RegularExpressionValidator>
                            <span class="error sr-only" style="color: tomato;">Date is invalid. yyyy/mm/dd </span>
                        </div>
                        <div class="form-group col-md-6">
                            <label for="txtMobile" class="col-form-label">MobileNO</label>
                            <asp:TextBox class="form-control" ID="txtMobile" Width="100%" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCellPhone" runat="server" ErrorMessage="Please input a mobile Number." ControlToValidate="txtMobile" Display="Dynamic" ValidationGroup="Errorsubmit" CssClass="text-danger"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revCellPhone" runat="server" ErrorMessage="Mobile number is incurrect" ControlToValidate="txtMobile" ValidationExpression="09\d{9}" Display="Dynamic" ValidationGroup="Errorsubmit" CssClass="text-danger"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-2  col-sm-auto mb-sm-1">
                            <div class="form-check">
                                <asp:RadioButtonList ID="RdbChangeReason" runat="server" class="form-check-input"
                                    onchange="return selectValue();" RepeatDirection="Vertical">
                                    <asp:ListItem Value="1" Selected="True" Text="Death">                                    
                                    </asp:ListItem>
                                    <asp:ListItem Value="2" Text="Disability"></asp:ListItem>
                                </asp:RadioButtonList>

                            </div>
                        </div>
                        <div class="form-group col-md-3 col-sm-auto">
                            <label for="DrdHadeseReason" class="col-form-label">Death reason</label>
                            <asp:DropDownList class="form-control  dropdown  custom-select" ID="DrdHadeseReason" runat="server" with="100%" Font-Size="Small"
                                DataTextField="Death_Reason_Desc" DataValueField="Death_Reason_Id">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-2 col-sm-auto">
                            <label for="DrdNaghType" class="col-form-label">Disability reason</label>
                            <asp:DropDownList class="custom-select form-control dropdown" ID="DrdNaghType" runat="server" disabled="true" Font-Size="Small">
                                <asp:ListItem>Select one</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group col-md-5 flex-md-row">
                            <label for="ListNaghsType" class="col-form-label">Disability Details</label> 
                            <asp:ListBox ID="ListNaghsType" runat="server" Class="custom-select form-control dropdown " disabled="true" ClientIDMode="Static"  Font-Size="Small"
                                SelectionMode="Multiple" DataTextField="Paypercent" DataValueField="DisableType_Code"></asp:ListBox>
                        </div>
                    </div>
             

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="form-row">
                            <div class="form-group col-md-3">
                                <asp:Button ID="btnGharamatGet" CssClass="btn-info form-control" Text="Calculate the Benefit" runat="server" OnClick="btnGharamatGet_Click" ValidationGroup="Errorsubmit" />
                            </div>
                            <div class="form-group col-md-3">
                                <asp:Label ID="lblShowMablagh" runat="server" Text="$0.00" CssClass="text-center   text-info form-control"></asp:Label>
                            </div>
                            <div class="form-group col-md-aoto">
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="lblKhataShow" runat="server" CssClass=" text-danger"></asp:Label>
                            </div>
                            <div class="form-group col-aoto">
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:HiddenField ID="hidImage" runat="server" ClientIDMode="Static" Value="" />
                <asp:HiddenField ID="hidImage2" runat="server" ClientIDMode="Static" Value="" />
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="lblKartMeliTasvir" class="col-form-label">Picture of Insered's NationalCart</label>
                        <div class="cropme" id="lblKartMeliTasvir" style="width: 350px; height: 200px; border: 1px dashed #b16464;">
                            <img id="tmpImage" src="">
                        </div>
                    </div>
                    <div class="form-group col-md-6">
                        <label for="lblGovahiTasvir" class="col-form-label">Picture of insured's medical ducument</label>
                        <div class="cropme" id="lblGovahiTasvir" style="width: 350px; height: 200px; border: 1px dashed #b16464;">
                            <img id="tmpImage2" src="">
                        </div>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <asp:Button ID="btnSubmit" CssClass="btn  btn-group border-bottom btn-lg bg-warning" runat="server" Text="Submit" OnClick="btnSubmit_Click" OnClientClick="copyToHiddenField();" ValidationGroup="Errorsubmit" />
                    </div>
                    <div class="form-group col-aoto">
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>

    <script type="text/javascript" src="../Content/Script/jquery-1.11.3.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js1"></script>
    <script type="text/javascript" src="../Content/Script/bootstrap.min.js"></script>
    <script src="../Content/SimpleCropper/scripts/jquery-1.10.2.min.js"></script>
    <script src="../Content/SimpleCropper/scripts/jquery.Jcrop.js"></script>
    <script src="../Content/SimpleCropper/scripts/jquery.SimpleCropper.js"></script>





</asp:Content>
