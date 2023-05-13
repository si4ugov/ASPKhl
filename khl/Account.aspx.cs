using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace khl
{
    public partial class Account : System.Web.UI.Page
    {
        DB db = new DB();
        public string firstName;
        public string lastName;

        protected void Page_Load(object sender, EventArgs e)
        {
            var cartBtn = Master.FindControl("cartBtn") as HtmlAnchor;
            var loginButton = Master.FindControl("loginButton") as HtmlAnchor;
            var registrationButton = Master.FindControl("registrationButton") as HtmlAnchor;
            var lkBtn = Master.FindControl("lkBtn") as HtmlAnchor;
            var tovBtn = Master.FindControl("tovBtn") as HtmlAnchor;
            //var lblWelcomeMessage = Master.FindControl("lblWelcomeMessage") as HtmlAnchor;

            if (Session["IsAuthenticated"] != null && (bool)Session["IsAuthenticated"])
            {
                // Пользователь авторизован
                loginButton.Visible = false;
                registrationButton.Visible = false;
                lkBtn.Visible = true;
                tovBtn.Visible = true;
                cartBtn.Visible = true;

                // Заполняем информацию о пользователе на странице
                string email = Session["Email"].ToString();

                MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE email=@Email", db.getConnection());
                command.Parameters.AddWithValue("@Email", email);
                db.openConnection();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Выводим информацию о пользователе на страницу
                    firstName = reader.GetString(1);
                    lastName = reader.GetString(2);
                }

                reader.Close();
                db.closeConnection();

            }
            else
            {
                // Пользователь не авторизован
                loginButton.Visible = true;
                registrationButton.Visible = true;
                lkBtn.Visible = false;
                tovBtn.Visible = false;
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session["IsAuthenticated"] = false;
            Session["Email"] = null;
            Response.Redirect("~/Default.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string phone = txtPhone.Text;

            // Обновляем информацию о пользователе в базе данных
            string email = Session["Email"].ToString();
            MySqlCommand command = new MySqlCommand("UPDATE Users SET FirstName=@FirstName, LastName=@LastName, Phone=@Phone WHERE Email=@Email", db.getConnection());
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@Phone", phone);
            command.Parameters.AddWithValue("@Email", email);
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();
        }
    }
}
