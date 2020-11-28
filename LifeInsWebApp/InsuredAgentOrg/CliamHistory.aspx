<%@ Page Title=""  Language="C#" MasterPageFile="~/InsuredAgentOrg/MasterPage.Master" AutoEventWireup="true" CodeBehind="CliamHistory.aspx.cs" Inherits="LifeInsWebApp.InsuredAgentOrg.CliamHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<style type="text/css">
        /*body {
            font-family: B Lotus;
            font-size: 10pt;
            margin: 0;
        }*/

        .t {
            border: 1px solid #ccc;
        }

            table.t th {
                background-color: #F7F7F7;
                color: #333;
                font-weight: bold;
            }

            table.t th, table.t td {
                padding: 5px;
                border-color: #ccc;
            }
    </style>--%>
    <script type="text/javascript" src="Content/Script/quicksearch.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row ml-1 mr-0">
      <%--  <table id="example" class="display" style="width: 100%">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Position</th>
                    <th>Office</th>
                    <th>Age</th>
                    <th>Start date</th>
                    <th>Salary</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Tiger Nixon</td>
                    <td>System Architect</td>
                    <td>Edinburgh</td>
                    <td>61</td>
                    <td>2011/04/25</td>
                    <td>$320,800</td>
                </tr>
                <tr>
                    <td>Garrett Winters</td>
                    <td>Accountant</td>
                    <td>Tokyo</td>
                    <td>63</td>
                    <td>2011/07/25</td>
                    <td>$170,750</td>
                </tr>
                <tr>
                    <td>Ashton Cox</td>
                    <td>Junior Technical Author</td>
                    <td>San Francisco</td>
                    <td>66</td>
                    <td>2009/01/12</td>
                    <td>$86,000</td>
                </tr>
            </tbody>
        </table>--%>

        <asp:GridView ID="GridViewGharamtList" runat="server" AutoGenerateColumns="false" AllowPaging="true"
            OnPageIndexChanging="OnPageIndexChanging" PageSize="10"
            GridLines="Both" Font-Size="Small" CssClass=" table-responsive  border-0 table-striped table-hover table-primary  " OnDataBound="GridViewGharamtList_DataBound">
            <Columns>
                <asp:BoundField ItemStyle-Width="150px" DataField="nationalcode" HeaderText="Nationalcode" />
                <asp:BoundField ItemStyle-Width="150px" DataField="Name" HeaderText="Name" />
                <asp:BoundField ItemStyle-Width="150px" DataField="family" HeaderText="Last Name" />
                <asp:BoundField ItemStyle-Width="150px" DataField="AccsidentDate" HeaderText="Date Of Death" />
                <asp:BoundField ItemStyle-Width="150px" DataField="GharamatValue" HeaderText="Benefit" DataFormatString="{0:#,###}" />
                <asp:BoundField ItemStyle-Width="150px" DataField="RegDate" HeaderText="Claim date" />
                <asp:BoundField ItemStyle-Width="150px" DataField="Tozihat" HeaderText="Status" />
            </Columns>
        </asp:GridView>

    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#GridViewGharamtList').DataTable();
        });
        $(function () {
            $('.search_textbox').each(function (i) {
                $(this).quicksearch("[id*=GridViewGharamtList] tr:not(:has(th))", {
                    'testQuery': function (query, txt, row) {
                        return $(row).children(":eq(" + i + ")").text().toLowerCase().indexOf(query[0].toLowerCase()) != -1;
                    }
                });
            });
        });

    </script>
</asp:Content>
