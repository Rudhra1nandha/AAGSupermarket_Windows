using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Common;

namespace AAG_SuperMarket
{
    public partial class Purchase_history : Form
    {
        public Purchase_history()
        {
            InitializeComponent();
        }

        private void Purchase_history_Load(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
  
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_nav_home_Click(object sender, EventArgs e)
        {
            Customer_detail sd = new Customer_detail();
            this.Hide();
            sd.Show();
        }

        private void data_Purchase_detatils_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void purchase_add_btn_Click(object sender, EventArgs e)
        {
            if (txt_purchase_id.Text != "" && txt_combo_supplier.Text != "" && txt_customer_name.Text != "" && txt_tCost.Text != "")
            {
                SqlConnection con = new SqlConnection("Data Source= VENKAT\\SQLEXPRESS01; Integrated Security = true; Initial Catalog = aag_supermarket");
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_purchase_history", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = new SqlParameter("@purchase_id", SqlDbType.VarChar);
                cmd.Parameters.Add(p1).Value = txt_purchase_id.Text;
                SqlParameter p2 = new SqlParameter("@supplier", SqlDbType.VarChar);
                cmd.Parameters.Add(p2).Value = txt_combo_supplier.Text;
                SqlParameter p3 = new SqlParameter("@customer_name", SqlDbType.VarChar);
                cmd.Parameters.Add(p3).Value = txt_customer_name.Text;
                SqlParameter p4 = new SqlParameter("@from_date", SqlDbType.DateTime);
                cmd.Parameters.Add(p4).Value = date_fromDte.Value.ToString();
                SqlParameter p5 = new SqlParameter("@to_date", SqlDbType.DateTime);
                cmd.Parameters.Add(p5).Value = date_toDate.Value.ToString();
                SqlParameter p6 = new SqlParameter("@total_cost", SqlDbType.VarChar);
                cmd.Parameters.Add(p6).Value = txt_tCost.Text;

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("sucessfully inserted");
                }
                else
                {
                    MessageBox.Show("unable to finish the request");
                }
                con.Close();

            }
            else
            {
                MessageBox.Show("error occured , please inserted necessary details");
            }
        }


        private void btn_reset_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source= VENKAT\\SQLEXPRESS01; Integrated Security = true; Initial Catalog = aag_supermarket");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_purchase_history_fetch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            fetch_new_item.DataSource = ds.Tables[0];
            con.Close(); 
        }

        private void purchase_delete_btn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source= VENKAT\\SQLEXPRESS01; Integrated Security = true; Initial Catalog = aag_supermarket");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_purchase_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@purchase_id",SqlDbType.VarChar);
            cmd.Parameters.Add(p1).Value = txt_purchase_id.Text;
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("history cleared inserted");
            }
            else
            {
                MessageBox.Show("unable to finish the request");
            }
            con.Close();
        }

        private void data_Purchase_detatils_DoubleClick_1(object sender, EventArgs e)
        {
            txt_purchase_id.Text = fetch_new_item.SelectedRows[0].Cells[1].Value.ToString();
            txt_combo_supplier.Text = fetch_new_item.SelectedRows[0].Cells[2].Value.ToString();
            txt_customer_name.Text = fetch_new_item.SelectedRows[0].Cells[3].Value.ToString();
            txt_tCost.Text = fetch_new_item.SelectedRows[0].Cells[6].Value.ToString();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            feedpack fp = new feedpack();
            fp.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_purchase_nav_Click(object sender, EventArgs e)
        {
            Stock_details sd = new Stock_details();
            sd.Show();
            this.Hide();
        }

        private void menu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
