using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;

namespace AAG_SuperMarket
{
    public partial class feedpack : Form
    {
        public feedpack()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void feedpack_Load(object sender, EventArgs e)
        {
        }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {            
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private static Regex email_validation()
        {
            string pattern = "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$";

            return new Regex(pattern, RegexOptions.IgnoreCase);
        }
        static Regex validate_emailaddress = email_validation();

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (r_emoji_1.Checked == true)
            {
                rating_feedback.Text = "1";
            }
            if (r_emoji_2.Checked == true)
            {
                rating_feedback.Text = "2";
            }
            if (r_emoji_3.Checked == true)
            {
                rating_feedback.Text = "3";
            }
            if (r_emoji_4.Checked == true)
            {
                rating_feedback.Text = "4";
            }
            if (r_emoji_5.Checked == true)
            {
                rating_feedback.Text = "5";
            }

            if (feedback_rating_txt_name.Text !="" && feedback_rating_txt_email.Text != "" && rating_feedback.Text !="" && feedback_rating_txt_review.Text !="")
            {
                if (validate_emailaddress.IsMatch(feedback_rating_txt_email.Text) != true)
                {
                    MessageBox.Show("Invalid Email Address!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    feedback_rating_txt_email.Focus();
                    return;
                }
                else
                {

                    SqlConnection con = new SqlConnection("Data Source = VENKAT\\SQLEXPRESS01; Integrated Security = true; Initial Catalog = aag_supermarket");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_feedback", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p1 = new SqlParameter("@name", SqlDbType.VarChar);
                    cmd.Parameters.Add(p1).Value = feedback_rating_txt_name.Text;
                    SqlParameter p2 = new SqlParameter("@email", SqlDbType.VarChar);
                    cmd.Parameters.Add(p2).Value = feedback_rating_txt_email.Text;
                    SqlParameter p3 = new SqlParameter("@rating", SqlDbType.VarChar);
                    cmd.Parameters.Add(p3).Value = rating_feedback.Text;
                    SqlParameter p4 = new SqlParameter("@feedback", SqlDbType.VarChar);
                    cmd.Parameters.Add(p4).Value = feedback_rating_txt_review.Text;

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        string from, to, password, messagebody;
                        Random random = new Random();
                        to = "nandhagopal0143@gmail.com";
                        from = "nandhagopall2000@gmail.com";
                        password = "wtgh vwbj zght bvyz";
                        messagebody = "the Customer '"+ feedback_rating_txt_name.Text+"', gives a feedback. "+"the customer gave us a '"+
                            rating_feedback.Text +" Star' rating. the review is '"+ feedback_rating_txt_review.Text+"'";
                        MailMessage message = new MailMessage();
                        message.To.Add(to);
                        message.From = new MailAddress(from);
                        message.Subject = "Site Feedback";
                        message.Body = messagebody;
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                        smtp.EnableSsl = true;
                        smtp.Port = 587;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Credentials = new NetworkCredential(from, password);
                        smtp.Send(message);
                        MessageBox.Show("feedback Submited Sucessfully, Thank you for the valuable feedback.");
                    }
                    else
                    {
                        MessageBox.Show("unable to Process a request");
                    }
                }
            }
            else 
            {
                MessageBox.Show("Please enter the Necessary Details");
            }



        }
    }
}
