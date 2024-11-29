using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AAG_SuperMarket
{
    public partial class Stock_details : Form
    {
        public Stock_details()
        {
            InitializeComponent();
        }

        private void left_side_bar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btn_new_item_Click_1(object sender, EventArgs e)
        {
            panel_refresh_1.Visible = true;
            panel_update_1.Visible = false;
            panel_del_1.Visible = false;
        }

        private void btn_update_item_Click(object sender, EventArgs e)
        {
            panel_refresh_1.Visible = false;
            panel_update_1.Visible = true;
            panel_del_1.Visible = false;
        }

        private void btn_delete_item_Click(object sender, EventArgs e)
        {
            panel_refresh_1.Visible = false;
            panel_update_1.Visible = false;
            panel_del_1.Visible = true;
        }

        private void category_SelectedIndexChanged(object sender, EventArgs e)
        {

            //.ToString() = 0;

        }

        private void Stock_details_Load(object sender, EventArgs e)
        {
            panel_refresh_1.Visible = true;
            panel_update_1.Visible = false;
            panel_del_1.Visible = false;
        }

        private void txt_quantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_exp_date_TextChanged(object sender, EventArgs e)
        {

        }

        private void exp_date_cal_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dummy_TextChanged(object sender, EventArgs e)
        {


        }

        private void add_product_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_supplier.Text != "" && txt_product_id.Text != "" && txt_product_name.Text != "" && txt_price.Text != "" &&
                    txt_quantity.Text != "" && txt_category.Text != "")
                {
                    SqlConnection con = new SqlConnection("Data Source= VENKAT\\SQLEXPRESS01; Integrated Security = true; Initial Catalog = aag_supermarket");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_add_item", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p1 = new SqlParameter("@supplier1", SqlDbType.VarChar);
                    cmd.Parameters.Add(p1).Value = txt_supplier.Text;
                    SqlParameter p2 = new SqlParameter("@product_id1", SqlDbType.VarChar);
                    cmd.Parameters.Add(p2).Value = txt_product_id.Text;
                    SqlParameter p3 = new SqlParameter("@product_name1", SqlDbType.VarChar);
                    cmd.Parameters.Add(p3).Value = txt_product_name.Text;
                    SqlParameter p4 = new SqlParameter("@price1", SqlDbType.Float);
                    cmd.Parameters.Add(p4).Value = Convert.ToInt32(txt_price.Text);
                    SqlParameter p5 = new SqlParameter("@Quantity1", SqlDbType.Float);
                    cmd.Parameters.Add(p5).Value = Convert.ToInt32(txt_quantity.Text);
                    SqlParameter p6 = new SqlParameter("@exp_date", SqlDbType.DateTime);
                    cmd.Parameters.Add(p6).Value = exp_date_cal.Value.ToString();
                    SqlParameter p7 = new SqlParameter("@category", SqlDbType.VarChar);
                    cmd.Parameters.Add(p7).Value = Convert.ToInt32(txt_category.SelectedItem.ToString());
                    SqlParameter p8 = new SqlParameter("@Description1", SqlDbType.VarChar);
                    cmd.Parameters.Add(p8).Value = txt_description.Text;

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("new item added");
                    }
                    else
                    {
                        MessageBox.Show("unable to add a product");
                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Enter the necessary details");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("please enter the valied details");
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source= VENKAT\\SQLEXPRESS01; Integrated Security = true; Initial Catalog = aag_supermarket");
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_refresh", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                fetch_new_item.DataSource = ds.Tables[0];
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("please enter the valied details");

            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source= VENKAT\\SQLEXPRESS01; Integrated Security = true; Initial Catalog = aag_supermarket");
                con.Open();
                SqlCommand cmd = new SqlCommand("Sp_search", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = new SqlParameter("@product_id", SqlDbType.VarChar);
                cmd.Parameters.Add(p1).Value = txt_search.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                fetch_new_item.DataSource = ds.Tables[0];
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("please enter the valied details");
            }
        }

        private void fetch_new_item_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                    SqlConnection con = new SqlConnection("Data Source= VENKAT\\SQLEXPRESS01; Integrated Security = true; Initial Catalog = aag_supermarket");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_update", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p1 = new SqlParameter("@supplier1", SqlDbType.VarChar);
                    cmd.Parameters.Add(p1).Value = txt_supplier.Text;
                    SqlParameter p2 = new SqlParameter("@product_id1", SqlDbType.VarChar);
                    cmd.Parameters.Add(p2).Value = txt_product_id.Text;
                    SqlParameter p3 = new SqlParameter("@product_name1", SqlDbType.VarChar);
                    cmd.Parameters.Add(p3).Value = txt_product_name.Text;
                    SqlParameter p4 = new SqlParameter("@price1", SqlDbType.Float);
                    cmd.Parameters.Add(p4).Value = Convert.ToInt32(txt_price.Text);
                    SqlParameter p5 = new SqlParameter("@Quantity1", SqlDbType.Float);
                    cmd.Parameters.Add(p5).Value = Convert.ToInt32(txt_quantity.Text);
                    SqlParameter p6 = new SqlParameter("@exp_date", SqlDbType.DateTime);
                    cmd.Parameters.Add(p6).Value = exp_date_cal.Value.ToString();
                    SqlParameter p7 = new SqlParameter("@category", SqlDbType.VarChar);
                    cmd.Parameters.Add(p7).Value = Convert.ToInt32(txt_category.SelectedItem.ToString());
                    SqlParameter p8 = new SqlParameter("@Description1", SqlDbType.VarChar);
                    cmd.Parameters.Add(p8).Value = txt_description.Text;

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("product updaated sucessfully");
                    }
                    else
                    {
                        MessageBox.Show("unable to update a product");
                    }
                    con.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }  

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("are u sure want to delete the product?", "confirm msg", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (check == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection("Data Source= VENKAT\\SQLEXPRESS01; Integrated Security = true; Initial Catalog = aag_supermarket");
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = new SqlParameter("@product_id1", SqlDbType.VarChar);
                cmd.Parameters.Add(p1).Value = txt_search.Text;
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("sucess");
                }
                else
                {
                    MessageBox.Show("unable to finish the request");
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Product not deleted");
            }
        }
        private void fetch_new_item_DoubleClick(object sender, EventArgs e)
        {
            txt_supplier.Text = fetch_new_item.SelectedRows[0].Cells[1].Value.ToString();
            txt_product_id.Text = fetch_new_item.SelectedRows[0].Cells[2].Value.ToString();
            txt_product_name.Text = fetch_new_item.SelectedRows[0].Cells[3].Value.ToString();
            txt_price.Text = fetch_new_item.SelectedRows[0].Cells[4].Value.ToString();
            txt_quantity.Text = fetch_new_item.SelectedRows[0].Cells[5].Value.ToString();
            //exp_date_cal.Text = fetch_new_item.SelectedRows[0].Cells[5].Value.ToString();
            txt_category.Text = fetch_new_item.SelectedRows[0].Cells[7].Value.ToString();
            txt_description.Text = fetch_new_item.SelectedRows[0].Cells[8].Value.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Customer_detail cs = new Customer_detail();
            this.Hide();
            cs.Show();
        }

        private void add_item_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Purchase_history ph = new Purchase_history();
            ph.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            feedpack fp = new feedpack();
            fp.Show();
        }

        private void panel_update_1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}