<%@ Page Title="" Language="C#" MasterPageFile="~/InsuredAgentOrg/Login/GeneralMaster.Master" AutoEventWireup="true" CodeBehind="OrganForgetPass.aspx.cs" Inherits="LifeInsWebApp.InsuredAgentOrg.Login.OrganForgetPass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div align="center">
    <table width="510px" border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse;" id="SendPassPnl" runat="server" dir="ltr">
           <tr>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td style=" height: 472px; width: 510px">
                    <div>
                        <div  dir="ltr" width="100%">
                            <table style="width: 90%;">
                                <tr>
                                    <td colspan="2" style="text-align: justify; font-size: 9pt;">
                                        <asp:Label ID="Label6" runat="server" Text="Please enter the ID and e-mail  of the Organization that is already registered in the system. "></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height: 2px;">
                                    <td colspan="2">
                                        <asp:Label ID="MyError" runat="server" Font-Names="Tahoma" ForeColor="#960000"></asp:Label>
                                        <div style="width: 100%; color: Green; text-align: center; height: 15px; font-size: 9pt; font-family: Tahoma;"
                                            runat="server" id="divMessage"
                                            visible="false">
                                            New password has sent to your email.
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="Id Code"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUid" runat="server" CssClass="clstxtl" MaxLength="8" TabIndex="6" ValidationGroup="SendPass"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RFvUId" runat="server" SetFocusOnError="true" Display="Dynamic"
                                            ErrorMessage="*" ControlToValidate="txtUid" ValidationGroup="SendPass"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2"></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" Font-Size="10pt" runat="server" Text="Email"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox_Email" CssClass="clstxtl" runat="server" Width="178px" TabIndex="7" ValidationGroup="SendPass"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RfVtxtEmail" runat="server" SetFocusOnError="true"
                                            Display="Dynamic" ErrorMessage=" * " ControlToValidate="TextBox_Email"
                                            ValidationGroup="SendPass"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox_Email"
                                            Display="Dynamic" ErrorMessage="The Email is incurrect." SetFocusOnError="True"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="SendPass"></asp:RegularExpressionValidator>

                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 97px"></td>
                                    <td style="width: 260px">
                                        <table width="100" border="0">
                                            <tr>
                                                <td style="width: 262px">
                                                    <table width="100" style="height: 30px; border-collapse: collapse;" border="1" cellpadding="0"
                                                        cellspacing="0">
                                                        <tr>
                                                            <td style="height: 33px;">
                                                                <asp:Image ID="imgCaptchaSendPass" ImageUrl="~/Model/CSPFCaptcha.ashx" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 18px;">
                                                    <asp:HyperLink ID="ImgHypPass" runat="server">
                                                        <asp:Image ID="Image1" ImageUrl="~/Content/Image/refresh.png" runat="server" AlternateText="Try again!" />
                                                    </asp:HyperLink>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 97px"></td>
                                    <td style="width: 260px">Enter the digits above.
                                            <br />
                                        <div style="height: 7px;"></div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="Enter The Security Code &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
                                            ValidationGroup="SendPass" Display="Dynamic" ControlToValidate="TextBox_numberSendPass"
                                            Width="175px"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox_numberSendPass"
                                            ValidationGroup="SendPass" Display="Dynamic" ErrorMessage="The security code is 5 digit &nbsp;&nbsp;&nbsp;&nbsp; "
                                            ValidationExpression="\d{5}" Width="175px"></asp:RegularExpressionValidator>
                                        <asp:Label ID="Label_invalidSendPass" EnableViewState="false" runat="server" Text="The Security code is incurrent"
                                            Visible="false" ForeColor="red"></asp:Label>
                                        <asp:TextBox ID="TextBox_numberSendPass" runat="server" CssClass="clstxtl" EnableViewState="False"
                                            TabIndex="8" MaxLength="5"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 5px"></td>
                                </tr>
                                <tr>
                                    <td>

                                        <asp:Button ID="Button_Send_Pass" runat="server"
                                            ValidationGroup="SendPass" OnClick="Button_Send_Pass_Click" Text="Sen password to your email"
                                            CssClass="clsbt" Width="110px" TabIndex="9" />&nbsp;
                                    </td>
                                    <td>
                                        <asp:Button ID="btnreturn" runat="server" Text="Ignore" CssClass="clsbt"
                                            TabIndex="10" Width="70px" OnClick="btnreturn_Click" />

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 2px"></td>
                                </tr>

                            </table>
                        </div>

                    </div>

                </td>
            </tr>

        </table>
       </div>
</asp:Content>
