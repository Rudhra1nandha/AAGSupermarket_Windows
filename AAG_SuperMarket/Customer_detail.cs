using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AAG_SuperMarket
{
    public partial class Customer_detail : Form
    {
        public Customer_detail()
        {
            InitializeComponent();
        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source= VENKAT\\SQLEXPRESS01; Integrated Security = true; Initial Catalog = aag_supermarket");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_customer_details_refresh", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            data_customer_details.DataSource = ds.Tables[0];
            con.Close();

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Customer_detail_Load(object sender, EventArgs e)
        {
            Panel_delete_cu.Visible = false;
            Panel_edit_cu.Visible = false;
        }

        private void btn_add_customer_Click(object sender, EventArgs e)
        {
                if (txt_customer_id.Text != "" && txt_customer_name.Text != "" && txt_customer_dob.Text != "" && txt_customer_gender.Text!= "" &&
                    txt_customer_contact.Text != "" && txt_customer_address.Text != "" && txt_customer_points.Text != "" && 
                    txt_membership_states.Text != "" && txt_reg_date.Text != "")
                {
                    SqlConnection con = new SqlConnection("Data Source=VENKAT\\SQLEXPRESS01; Integrated Security = true; Initial Catalog = aag_supermarket");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_add_customer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p1 = new SqlParameter("@Customer_ID", SqlDbType.VarChar);
                    cmd.Parameters.Add(p1).Value = txt_customer_id.Text;
                    SqlParameter p2 = new SqlParameter("@Customer_Name", SqlDbType.VarChar);
                    cmd.Parameters.Add(p2).Value = txt_customer_name.Text;
                    SqlParameter p3 = new SqlParameter("@DOB", SqlDbType.DateTime);
                    cmd.Parameters.Add(p3).Value = txt_customer_dob.Value.ToString();
                    SqlParameter p4 = new SqlParameter("@Gender", SqlDbType.VarChar);
                    cmd.Parameters.Add(p4).Value = txt_customer_gender.Text;
                    SqlParameter p5 = new SqlParameter("@Contact", SqlDbType.VarChar);
                    cmd.Parameters.Add(p5).Value = txt_customer_contact.Text;
                    SqlParameter p6 = new SqlParameter("@Address", SqlDbType.VarChar);
                    cmd.Parameters.Add(p6).Value = txt_customer_address.Text;
                    SqlParameter p7 = new SqlParameter("@Loyalty_Points", SqlDbType.Int);
                    cmd.Parameters.Add(p7).Value = Convert.ToInt32(txt_customer_points.Text);
                    SqlParameter p8 = new SqlParameter("@Membership_States", SqlDbType.VarChar);
                    cmd.Parameters.Add(p8).Value = txt_membership_states.Text;
                    SqlParameter p9 = new SqlParameter("@Reg_Date", SqlDbType.DateTime);
                    cmd.Parameters.Add(p9).Value = txt_reg_date.Value.ToString();

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Customer details added sucessfully");
                    txt_customer_id.Text = "";
                    txt_customer_name.Text = ""; txt_customer_dob.Text = ""; txt_customer_gender.Text = "";
                    txt_customer_contact.Text = ""; txt_customer_address.Text = ""; txt_customer_points.Text = "";
                    txt_membership_states.Text = ""; txt_reg_date.Text = "";
                }
                    else
                    {
                        MessageBox.Show("unable to add a new customer");
                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Enter the necessary details");
                }

            
        }

        private void panel_customer_Paint(object sender, PaintEventArgs e)
        {
            search_customer_catagory.PlaceholderText = txt_Search_category.SelectedItem.ToString();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (search_customer_catagory.Text != "")
                {
                    if (txt_Search_category.SelectedIndex == 0)
                    {
                        SqlConnection con = new SqlConnection("Data Source= VENKAT\\SQLEXPRESS01; Integrated Security = true; Initial Catalog = aag_supermarket");
                        con.Open();
                        SqlCommand cmd = new SqlCommand("sp_customer_search_category", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter p1 = new SqlParameter("@Customer_Name", SqlDbType.VarChar);
                        cmd.Parameters.Add(p1).Value = search_customer_catagory.Text;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        data_customer_details.DataSource = ds.Tables[0];
                        con.Close();
                    }
                    else if (txt_Search_category.SelectedIndex == 1)
                    {
                        SqlConnection con = new SqlConnection("Data Source= VENKAT\\SQLEXPRESS01; Integrated Security = true; Initial Catalog = aag_supermarket");
                        con.Open();
                        SqlCommand cmd = new SqlCommand("sp_customer_search_category_Id", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter p1 = new SqlParameter("@Customer_Id", SqlDbType.VarChar);
                        cmd.Parameters.Add(p1).Value = search_customer_catagory.Text;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        data_customer_details.DataSource = ds.Tables[0];
                        con.Close();
                    }
                    else if (txt_Search_category.SelectedIndex == 2)
                    {
                        SqlConnection con = new SqlConnection("Data Source= VENKAT\\SQLEXPRESS01; Integrated Security = true; Initial Catalog = aag_supermarket");
                        con.Open();
                        SqlCommand cmd = new SqlCommand("sp_customer_search_category_states", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter p1 = new SqlParameter("@Customer_States", SqlDbType.VarChar);
                        cmd.Parameters.Add(p1).Value = search_customer_catagory.Text;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        data_customer_details.DataSource = ds.Tables[0];
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("not found");
                    }
                }
                else
                {
                    MessageBox.Show("Enter Valied details to search !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("please enter the valied details");
            }
        }

        private void search_customer_catagory_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (txt_customer_id.Text != "" && txt_customer_name.Text != "" && txt_customer_dob.Text != "" && txt_customer_gender.Text != "" &&
    txt_customer_contact.Text != "" && txt_customer_address.Text != "" && txt_customer_points.Text != "" &&
    txt_membership_states.Text != "" && txt_reg_date.Text != "")
            {

                SqlConnection con = new SqlConnection("Data Source= VENKAT\\SQLEXPRESS01; Integrated Security = true; Initial Catalog = aag_supermarket");
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Edit_customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = new SqlParameter("@Customer_ID", SqlDbType.VarChar);
                cmd.Parameters.Add(p1).Value = txt_customer_id.Text;
                SqlParameter p2 = new SqlParameter("@Customer_Name", SqlDbType.VarChar);
                cmd.Parameters.Add(p2).Value = txt_customer_name.Text;
                SqlParameter p3 = new SqlParameter("@DOB", SqlDbType.DateTime);
                cmd.Parameters.Add(p3).Value = txt_customer_dob.Value.ToString();
                SqlParameter p4 = new SqlParameter("@Gender", SqlDbType.VarChar);
                cmd.Parameters.Add(p4).Value = txt_customer_gender.Text;
                SqlParameter p5 = new SqlParameter("@Contact", SqlDbType.VarChar);
                cmd.Parameters.Add(p5).Value = txt_customer_contact.Text;
                SqlParameter p6 = new SqlParameter("@Address", SqlDbType.VarChar);
                cmd.Parameters.Add(p6).Value = txt_customer_address.Text;
                SqlParameter p7 = new SqlParameter("@Loyalty_Points", SqlDbType.Int);
                cmd.Parameters.Add(p7).Value = Convert.ToInt32(txt_customer_points.Text);
                SqlParameter p8 = new SqlParameter("@Membership_States", SqlDbType.VarChar);
                cmd.Parameters.Add(p8).Value = txt_membership_states.Text;
                SqlParameter p9 = new SqlParameter("@Reg_Date", SqlDbType.DateTime);
                cmd.Parameters.Add(p9).Value = txt_reg_date.Value.ToString();

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Customer details  updated sucessfully");
                    txt_customer_id.Text = "";
                    txt_customer_name.Text = ""; txt_customer_dob.Text = ""; txt_customer_gender.Text = "";
                    txt_customer_contact.Text = ""; txt_customer_address.Text = ""; txt_customer_points.Text = "";
                    txt_membership_states.Text = ""; txt_reg_date.Text = "";
                }
                else
                {
                    MessageBox.Show("unable to update a  customer detail");
                }
                con.Close();
            }
            else { MessageBox.Show("please provide the entire details correctly!"); }



        }

        private void data_customer_details_DoubleClick(object sender, EventArgs e)
        {
            txt_customer_id.Text = data_customer_details.SelectedRows[0].Cells[1].Value.ToString();
            txt_customer_name.Text = data_customer_details.SelectedRows[0].Cells[2].Value.ToString();
            //txt_product_name.Text = data_customer_details.SelectedRows[0].Cells[3].Value.ToString();
            txt_customer_gender.Text = data_customer_details.SelectedRows[0].Cells[4].Value.ToString();
            txt_customer_contact.Text = data_customer_details.SelectedRows[0].Cells[5].Value.ToString();
            txt_customer_address.Text = data_customer_details.SelectedRows[0].Cells[6].Value.ToString();
            txt_customer_points.Text = data_customer_details.SelectedRows[0].Cells[7].Value.ToString();
            txt_membership_states.Text = data_customer_details.SelectedRows[0].Cells[8].Value.ToString();
            //txt_reg_date.Value = data_customer_details.SelectedRows[0].Cells[9].Value.ToString();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("are u sure want to delete the customer detail?", "confirm msg", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (check == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection("Data Source= VENKAT\\SQLEXPRESS01; Integrated Security = true; Initial Catalog = aag_supermarket");
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_delete_customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = new SqlParameter("@customer_id", SqlDbType.VarChar);
                cmd.Parameters.Add(p1).Value = txt_customer_id.Text;
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("customer detail erased completly");
                    txt_customer_id.Text = "";
                    txt_customer_name.Text = ""; txt_customer_dob.Text = ""; txt_customer_gender.Text = "";
                    txt_customer_contact.Text = ""; txt_customer_address.Text = ""; txt_customer_points.Text = "";
                    txt_membership_states.Text = ""; txt_reg_date.Text = "";
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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Panel_delete_cu.Visible = false;
            Panel_edit_cu.Visible = false;
            panel_add_cu.Visible = true;

            txt_customer_id.Text = "";
            txt_customer_name.Text = ""; txt_customer_dob.Text = ""; txt_customer_gender.Text = "";
            txt_customer_contact.Text = ""; txt_customer_address.Text = ""; txt_customer_points.Text = "";
            txt_membership_states.Text = ""; txt_reg_date.Text = "";
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Panel_delete_cu.Visible = false;
            Panel_edit_cu.Visible = true;
            panel_add_cu.Visible = false;
            txt_customer_id.Text = "";
            txt_customer_name.Text = ""; txt_customer_dob.Text = ""; txt_customer_gender.Text = "";
            txt_customer_contact.Text = ""; txt_customer_address.Text = ""; txt_customer_points.Text = "";
            txt_membership_states.Text = ""; txt_reg_date.Text = "";
        }

        private void Panel_delete_cu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Panel_delete_cu.Visible = true;
            Panel_edit_cu.Visible = false;
            panel_add_cu.Visible = false;
            txt_customer_id.Text = "";
            txt_customer_name.Text = ""; txt_customer_dob.Text = ""; txt_customer_gender.Text = "";
            txt_customer_contact.Text = ""; txt_customer_address.Text = ""; txt_customer_points.Text = "";
            txt_membership_states.Text = ""; txt_reg_date.Text = "";
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void Panel_edit_cu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button6_Click_1(object sender, EventArgs e)
        {
            Purchase_history ph = new Purchase_history();
            ph.Show();
            this.Hide();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Stock_details sd = new Stock_details();
            sd.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            feedpack fp = new feedpack();
            fp.Show();
        }

        private void panel_customer_content_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
