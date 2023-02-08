using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleSalesApp
{
    public partial class _Default : Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clear();
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[6] { new DataColumn("Id"),new DataColumn("Slno"), new DataColumn("Name"), new DataColumn("Qty"), new DataColumn("Rate"), new DataColumn("Total") });
                this.BindGrid();

            }
        }
        protected void BindGrid()
        {
            String cs = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT  ID as Id,ROW_NUMBER() OVER(ORDER BY Item) AS Slno, Item as Name, Qty, Rate, Total FROM Inventory.dbo.Sales", con);
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
        }

        private void Clear()
        {
            txtName.Text = "";
            txtQty.Text = "" ;
            txtRate.Text = "";
            ViewState["SalesId"] = "";
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
        
            //if(txtName.Text == "" ||  txtQty.Text == "" || txtRate.Text == "") 
            //{
               
            // }
            //else
            //{
                String cs = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {

                    if (ViewState["SalesId"].ToString() != "")
                    {
                        SqlCommand cmd = new SqlCommand("EditSales", con);
                        cmd.Parameters.AddWithValue("@SalesID", SqlDbType.Int).Value = ViewState["SalesId"];
                        cmd.Parameters.AddWithValue("@Item", SqlDbType.VarChar).Value = txtName.Text.ToString();
                        cmd.Parameters.AddWithValue("@Qty", SqlDbType.Decimal).Value = txtQty.Text;
                        cmd.Parameters.AddWithValue("@Rate", SqlDbType.Decimal).Value = txtRate.Text;
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("SaveSales", con);
                        cmd.Parameters.AddWithValue("@Item", SqlDbType.VarChar).Value = txtName.Text.ToString();
                        cmd.Parameters.AddWithValue("@Qty", SqlDbType.Decimal).Value = txtQty.Text;
                        cmd.Parameters.AddWithValue("@Rate", SqlDbType.Decimal).Value = txtRate.Text;

                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                Clear();
                this.BindGrid();
            //}
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.RowIndex); 
            GridViewRow row = GridView1.Rows[rowIndex];
            int Id = Convert.ToInt32(row.Cells[1].Text);
            String cs = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("DeleteSales", con);
                cmd.Parameters.AddWithValue("@SalesID", SqlDbType.Int).Value = Id;               
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            this.BindGrid();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           
                int rowIndex = Convert.ToInt32(e.RowIndex);
                GridViewRow row = GridView1.Rows[rowIndex];
                ViewState["SalesId"] = Convert.ToInt32(row.Cells[1].Text);
                txtName.Text = row.Cells[2].Text;
                txtQty.Text = row.Cells[3].Text;
                txtRate.Text = row.Cells[4].Text;
               


        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SalesReport.aspx");
        }


    }
}