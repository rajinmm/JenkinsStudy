using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace SampleSalesApp
{
    public partial class SalesReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = new DataSet();
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Report/SalesRpt.rdlc");
                String cs = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("SELECT Item,Qty,Rate,Total FROM Inventory.dbo.Sales", con);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    sda.Fill(ds);
                    ReportDataSource datasource = new ReportDataSource("DataSet1",  ds.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Clear();               
                    ReportViewer1.LocalReport.DataSources.Add(datasource); 
                  
                }
              
            }
        }
    }
}