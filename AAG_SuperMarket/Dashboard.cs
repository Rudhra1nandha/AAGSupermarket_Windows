using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AAG_SuperMarket
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            panel_stock_title.Visible = false;
            panel_purchase_title.Visible = false;
            panel_customer_title.Visible = false;
            panel_feedback_title.Visible = false;
            btn_getin1.Visible = false;
        }

        private void moon_sun_Click(object sender, EventArgs e)
        {
            //if (moon_sun.Checked == true)
            //{
            //    BackColor = Color.Red;
            //}
            //else 
            //{
            //    BackColor = Color.Gray;

            //}
            if (moon_sun.Checked == false)
            {
                BackColor = Color.White;
                ForeColor = Color.Black;
                Dashboard_search.FillColor = Color.White;
                Dashboard_search.PlaceholderForeColor = Color.Gray;
                data_customer.RowsDefaultCellStyle.ForeColor = Color.Black;
                data_customer.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
                data_sale_bill.RowsDefaultCellStyle.ForeColor = Color.Black;
                data_sale_bill.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
                total_sales_data.RowsDefaultCellStyle.ForeColor = Color.Black;
                total_sales_data.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
                dashboard_datagridview.RowsDefaultCellStyle.BackColor = Color.White;
                dashboard_datagridview.RowsDefaultCellStyle.SelectionBackColor = Color.White;
                label9.ForeColor = Color.White;
                label23.ForeColor = Color.White;

            }
            else 
            {
                BackColor = Color.Gray;
               ForeColor = Color.White;
                Dashboard_search.FillColor = Color.White;
                Dashboard_search.PlaceholderForeColor = Color.LightGray;
                data_customer.RowsDefaultCellStyle.ForeColor = Color.White;
                data_customer.RowsDefaultCellStyle.SelectionForeColor = Color.White;
                data_sale_bill.RowsDefaultCellStyle.ForeColor = Color.White;
                data_sale_bill.RowsDefaultCellStyle.SelectionForeColor = Color.White;
                total_sales_data.RowsDefaultCellStyle.ForeColor = Color.White;
                total_sales_data.RowsDefaultCellStyle.SelectionForeColor = Color.White;
                dashboard_datagridview.RowsDefaultCellStyle.BackColor  = Color.LightGray;
                dashboard_datagridview.RowsDefaultCellStyle.SelectionBackColor = Color.LightGray;
                label9.ForeColor = Color.Black;
                label23.ForeColor = Color.Black;
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            panel_stock_title.Visible = false;
            panel_purchase_title.Visible = false;
            panel_customer_title.Visible = true;
            panel_feedback_title.Visible = false;
            btn_getin1.Visible = true;

            SqlConnection con = new SqlConnection("Data Source= VENKAT\\SQLEXPRESS01; Integrated Security = true; Initial Catalog = aag_supermarket");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_customer_details_refresh", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dashboard_datagridview.DataSource = ds.Tables[0];
            con.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            panel_stock_title.Visible = true;
            panel_purchase_title.Visible = false;
            panel_customer_title.Visible = false;
            panel_feedback_title.Visible = false;
            btn_getin1.Visible = true;

            try
            {
                SqlConnection con = new SqlConnection("Data Source= VENKAT\\SQLEXPRESS01; Integrated Security = true; Initial Catalog = aag_supermarket");
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_refresh", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dashboard_datagridview.DataSource = ds.Tables[0];
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("please enter the valied details");

            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            panel_stock_title.Visible = false;
            panel_purchase_title.Visible = true;
            panel_customer_title.Visible = false;
            panel_feedback_title.Visible = false;
            btn_getin1.Visible = true;

            SqlConnection con = new SqlConnection("Data Source=VENKAT\\SQLEXPRESS01; Integrated Security = true; Initial Catalog = aag_supermarket");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_purchase_history_fetch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dashboard_datagridview.DataSource = ds.Tables[0];
            con.Close();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            panel_stock_title.Visible = false;
            panel_purchase_title.Visible = false;
            panel_customer_title.Visible = false;
            panel_feedback_title.Visible = true;
            btn_getin1.Visible = true;

            SqlConnection con = new SqlConnection("Data Source= VENKAT\\SQLEXPRESS01; Integrated Security = true; Initial Catalog = aag_supermarket");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_feedback_fetch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dashboard_datagridview.DataSource = ds.Tables[0];
            con.Close();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=VENKAT\\SQLEXPRESS01; Integrated Security = true; Initial Catalog = aag_supermarket");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_dashboard_values_noofcustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            data_customer.DataSource = ds.Tables[0];


            SqlCommand cmd2 = new SqlCommand("sp_purchase_id_count", con);
            cmd2.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            data_sale_bill.DataSource = ds2.Tables[0];
    

            SqlCommand cmd3 = new SqlCommand("sp_purchase_cost", con);
            cmd3.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            total_sales_data.DataSource = ds3.Tables[0];
            con.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (btn_stock.Checked == true)
            {
                Stock_details sd = new Stock_details();
                sd.Show();
            }
            else if (btn_customer.Checked == true)
            {
                Customer_detail cd = new Customer_detail();
                cd.Show();
            }
            else if (btn_purchase.Checked == true)
            {
                Purchase_history ph = new Purchase_history();
                ph.Show();
            }
            else if (btn_feedback.Checked == true)
            {
                feedpack fp = new feedpack();
                fp.Show();
            }
            else
            {
                MessageBox.Show("Contact the Admin");
            }
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    
}
