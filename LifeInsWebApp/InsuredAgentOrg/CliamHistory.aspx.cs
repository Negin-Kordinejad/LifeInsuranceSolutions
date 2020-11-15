using System;
using System.Web.UI.WebControls;
using System.Data;
using LifeInsWebApp.Model;

namespace LifeInsWebApp.InsuredAgentOrg
{
    public partial class CliamHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewGharamtList.Attributes.Add("onbound", "");
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        private void BindGrid()
        {
           // ClaimData data = new ClaimData();
            DataSet ds =DataAccessFactory.CreateClaimData().GetClaimRecords(SessionHelper.Dastgah.DastgahCode, 0);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                GridViewGharamtList.DataSource = ds;
                GridViewGharamtList.DataBind();
                GridViewGharamtList.UseAccessibleHeader = true;
                GridViewGharamtList.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewGharamtList.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void GridViewGharamtList_DataBound(object sender, EventArgs e)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            for (int i = 0; i < GridViewGharamtList.Columns.Count; i++)
            {
                TableHeaderCell cell = new TableHeaderCell();
                TextBox txtSearch = new TextBox();
                txtSearch.Attributes["placeholder"] = GridViewGharamtList.Columns[i].HeaderText;
                txtSearch.CssClass = "search_textbox";
                txtSearch.Width = 120;
                cell.Controls.Add(txtSearch);
                row.Controls.Add(cell);
                row.HorizontalAlign = HorizontalAlign.Left;
            }
            GridViewGharamtList.HeaderRow.Parent.Controls.AddAt(1, row);
        }
    }
}