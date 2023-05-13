using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace khl
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Проверяем правильность введенных данных
            if (IsValid)
            {
                var loginButton = Master.FindControl("loginButton") as HtmlAnchor;
                var registrationButton = Master.FindControl("registrationButton") as HtmlAnchor;
                // Здесь нужно проверить данные авторизации в базе данных или другом источнике
                string email = txtEmail.Text.Trim();
                string password = txtPassword.Text.Trim();

                bool isAuthenticated = CheckUserCredentials(email, password);

                if (isAuthenticated)
                {
                    // Сохраняем состояние авторизации в сессии
                    Session["IsAuthenticated"] = true;
                    Session["Email"] = email;

                    // Перенаправляем пользователя на страницу личного кабинета
                    Response.Redirect("/Account.aspx");
                    loginButton.Visible = false;
                    registrationButton.Visible = false;
                }
                if (email == "admin.admin@gmail.com")
                {
                    Session["Email"] = email;
                    Response.Redirect("/Admin.aspx");
                    loginButton.Visible = false;
                    registrationButton.Visible = false;
                }
                else
                {
                    // Отображаем сообщение об ошибке
                   //lblMessage.Text = "Неверный email или пароль";
                   //lblMessage.Visible = true;
                }
            }
        }

        private bool CheckUserCredentials(string email, string password)
        {
            DB db = new DB();

            MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE email=@Email", db.getConnection());
            command.Parameters.AddWithValue("@Email", email);
            db.openConnection();
            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                // Проверяем, совпадает ли пароль из базы данных с введенным паролем
                var passwordFromDb = reader["pass"].ToString();
                if (passwordFromDb == password)
                {
                    // Пользователь найден и введенные данные верны
                    return true;
                }
            }
            return false;
        }
    }

}