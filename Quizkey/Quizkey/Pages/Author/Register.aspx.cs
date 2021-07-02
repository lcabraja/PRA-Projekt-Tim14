using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quizkey
{
    public partial class Register : System.Web.UI.Page
    {
        protected void btSend_Click(object sender, EventArgs e)
        {
        }
        //if (txtKorisnickoIme.Text == "" || txtEmail.Text == "")
        //    lblErrorMessage.Text = "Please Fill Mandatory Fields";
        //else if (txtZaporka.Text != txtPonovljenazaporka.Text)
        //    lblErrorMessage.Text = "Password do not match";
        //else
        //{
        //    using (SqlConnection sqlCon = new SqlConnection(connectionString))
        //    {
        //        sqlCon.Open();
        //        SqlCommand sqlCmd = new SqlCommand("UserAddOrEdit", sqlCon);
        //        sqlCmd.CommandType = CommandType.StoredProcedure;
        //        sqlCmd.Parameters.AddWithValue("@IDAuthor", Convert.ToInt32(hfUserID.Value == "" ? "0" : hfUserID.Value));
        //        sqlCmd.Parameters.AddWithValue("@Username", txtKorisnickoime.Text.Trim());
        //        sqlCmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
        //        sqlCmd.Parameters.AddWithValue("@PasswordHash", txtZaporka.Text.Trim());
        //        sqlCmd.ExecuteNonQuery();
        //        Clear();
        //        lblSuccessMessage.Text = "Submitted Successfully";
        //    }
        //}
    }
}