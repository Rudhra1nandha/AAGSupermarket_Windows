using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using Guna.UI2.WinForms;

namespace AAG_SuperMarket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel_login_1.Visible = true;
            panel_register.Visible = false;
            panel_forgot_pwd.Visible = false;
            two_step_verification.Visible = false;
            panel7.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                if (Admin_user.Checked == false)
                {
                    SqlConnection con = new SqlConnection("Data Source = VENKAT\\SQLEXPRESS01; Integrated Security = true; Initial Catalog = aag_supermarket");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_login", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p1 = new SqlParameter("@email", SqlDbType.VarChar);
                    cmd.Parameters.Add(p1).Value = txt_email.Text;
                    SqlParameter p2 = new SqlParameter("@password", SqlDbType.VarChar);
                    cmd.Parameters.Add(p2).Value = txt_pwd.Text;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = ds.Tables[0].Rows.Count;
                    if (i > 0)
                    {
                        MessageBox.Show("Login sucessfull");
                        Customer_detail sd = new Customer_detail();
                        sd.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("no user found");
                    }
                    con.Close();
                }
                else
                {
                    if (txt_email.Text == "admin@gmail.com" && txt_pwd.Text == "Admin")
                    {
                        Dashboard db = new Dashboard();
                        db.Show();
                        panel_login_1.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("No Admin ID Found");
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void logo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_uname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_showpassword.Checked == true)
            {
                txt_pwd.PasswordChar = '\0';

            }
            else
            {
                txt_pwd.PasswordChar = '●';
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel_register.Visible = true;
            panel_login_1.Visible = false;
            panel_forgot_pwd.Visible = false;
            two_step_verification.Visible = false;
            panel7.Visible = false;
        }

        private void txt_pwd_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel_register.Visible = false;
            panel_login_1.Visible = true;
            panel_forgot_pwd.Visible = false;
            panel7.Visible = false;
            two_step_verification.Visible = false;

        }

        private void panel_register_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkbox_pwd_register.Checked == true)
            {
                register_pwd.PasswordChar = '\0';

            }
            else
            {
                register_pwd.PasswordChar = '●';
            }
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel_forgot_pwd.Visible = true;
            panel_login_1.Visible = false;
            panel_register.Visible = false;
            two_step_verification.Visible = false;
            panel7.Visible = false;
        }
        private void linkLabel7_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel_forgot_pwd.Visible = false;
            panel_login_1.Visible = true;
            panel_register.Visible = false;
            two_step_verification.Visible = false;
            panel7.Visible = false;
        }

        string randomcode;
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            panel_forgot_pwd.Visible = false;
            panel_login_1.Visible = false;
            panel_register.Visible = false;
            panel7.Visible = false;


            SqlConnection con = new SqlConnection("Data Source = VENKAT\\SQLEXPRESS01; Integrated Security = true; Initial Catalog = aag_supermarket");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_valied_email", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@email", SqlDbType.VarChar);
            cmd.Parameters.Add(p1).Value = txt_email_fpwd.Text;
 
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int i = ds.Tables[0].Rows.Count;
            if (i > 0)
            {
                // for a email otp validation
                string from, to, password, messagebody;
                Random random = new Random();
                randomcode = (random.Next(999999)).ToString();
                to = (txt_email_fpwd.Text).ToString();
                from = "nandhagopall2000@gmail.com";
                password = "wtgh vwbj zght bvyz";
                messagebody = "your OTP verification code : " + randomcode;
                MailMessage message = new MailMessage();
                message.To.Add(to);
                message.From = new MailAddress(from);
                message.Subject = "OTP verification";
                message.Body = messagebody;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, password);
                try
                {
                    smtp.Send(message);
                    MessageBox.Show("OTP Sented");
                    two_step_verification.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                panel_forgot_pwd.Visible = true;
                MessageBox.Show("please enter the registerd email address");
            }
            con.Close();
        }
        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel_forgot_pwd.Visible = false;
            panel_login_1.Visible = true;
            panel_register.Visible = false;
            two_step_verification.Visible = false;
            panel7.Visible = false;
        }
        private static Regex email_validation()
        {
            string pattern = "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$";

            return new Regex(pattern, RegexOptions.IgnoreCase);
        }
        static Regex validate_emailaddress = email_validation();



        private void btn_register_Click(object sender, EventArgs e)
        {
            if (checkbox_terms_register.Checked = true)
            {
                try
                {
                    if (register_name.Text != "" && register_email.Text != "" && register_pwd.Text != "")
                    {
                        if (validate_emailaddress.IsMatch(register_email.Text) != true)
                        {
                            MessageBox.Show("Invalid Email Address!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            register_email.Focus();
                            return;
                        }
                        else
                        {
                            SqlConnection con = new SqlConnection("Data Source= VENKAT\\SQLEXPRESS01; Integrated Security = true; Initial Catalog = aag_supermarket");
                            con.Open();
                            SqlCommand cmd = new SqlCommand("sp_register", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            SqlParameter p1 = new SqlParameter("@name", SqlDbType.VarChar);
                            cmd.Parameters.Add(p1).Value = register_name.Text;
                            SqlParameter p2 = new SqlParameter("@email", SqlDbType.VarChar);
                            cmd.Parameters.Add(p2).Value = register_email.Text;
                            SqlParameter p3 = new SqlParameter("@password", SqlDbType.VarChar);
                            cmd.Parameters.Add(p3).Value = register_pwd.Text;
                            int i = cmd.ExecuteNonQuery();
                            if (i > 0)
                            {
                                MessageBox.Show("Registered success");
                            }
                            else
                            {
                                MessageBox.Show("unable to process a request");
                            }
                            con.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("please enter the necessary credentials");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else 
            {
                MessageBox.Show("Please read the terms and conditions");           
            }



            
        }

        private void btn_verification_Click(object sender, EventArgs e)
        {
            int verification_code = Convert.ToInt32(verification_1.Text + verification_2.Text + verification_3.Text + verification_4.Text +
                verification_5.Text + verification_6.Text);
            if (randomcode == (verification_code).ToString())
            {
                MessageBox.Show("Verified Successfully");
                panel7.Visible = true;
                two_step_verification.Visible = false;
                verification_1.Text = "";
                verification_2.Text = "";
                verification_3.Text = "";
                verification_4.Text = "";
                verification_5.Text = "";
                verification_6.Text = "";
            }
            else
            {
                MessageBox.Show("Invalid");
                verification_1.Text = "";
                verification_2.Text = "";
                verification_3.Text = "";
                verification_4.Text = "";
                verification_5.Text = "";
                verification_6.Text = "";
            }


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_pwd_update.Text == txt_cpwd_update.Text)
                {
                    SqlConnection con = new SqlConnection("Data Source= VENKAT\\SQLEXPRESS01; Integrated Security = true; Initial Catalog = aag_supermarket");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_pwd_update", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p2 = new SqlParameter("@email", SqlDbType.VarChar);
                    cmd.Parameters.Add(p2).Value = txt_email_fpwd.Text;
                    SqlParameter p3 = new SqlParameter("@password", SqlDbType.VarChar);
                    cmd.Parameters.Add(p3).Value = txt_pwd_update.Text;
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("password updated successfully");
                        this.Close();
                        panel_login_1.Show();

                    }
                    else
                    {
                        MessageBox.Show("unable to process a request");
                    }
                    con.Close();

                }
                else
                {
                    MessageBox.Show("password and confirm password are miss-matched");
                }
            } 
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void qwerty_TextChanged(object sender, EventArgs e)
        {

        }

        private void linklabel_resentit_verification_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source =VENKAT\\SQLEXPRESS01; Integrated Security = true; Initial Catalog = aag_supermarket");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_valied_email", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@email", SqlDbType.VarChar);
            cmd.Parameters.Add(p1).Value = txt_email_fpwd.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int i = ds.Tables[0].Rows.Count;
            if (i > 0)
            {
                // for a email otp validation
                string from, to, password, messagebody;
                Random random = new Random();
                randomcode = (random.Next(999999)).ToString();
                to = (txt_email_fpwd.Text).ToString();
                from = "nandhagopall2000@gmail.com";
                password = "wtgh vwbj zght bvyz";
                messagebody = "your OTP verification code : " + randomcode;
                MailMessage message = new MailMessage();
                message.To.Add(to);
                message.From = new MailAddress(from);
                message.Subject = "OTP verification";
                message.Body = messagebody;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, password);
                try
                {
                    smtp.Send(message);
                    MessageBox.Show("OTP Sented");
                    two_step_verification.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                panel_forgot_pwd.Visible = true;
                MessageBox.Show("please enter the registerd email address");
            }
            con.Close();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel7.Hide();
            panel_login_1.Visible = true;
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Admin_user_Click(object sender, EventArgs e)
        {
        }

        private void logo_register_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    
}
