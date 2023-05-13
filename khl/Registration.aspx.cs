using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace khl
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Открыть соединение с базой данных
            DB db = new DB();
            {
                db.openConnection();

                // Создать команду для вставки данных нового пользователя в таблицу Users
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `users` (`FirstName`, `LastName`, `Email`, `Pass`) VALUES (@FirstName, @LastName, @Email, @Password)", db.getConnection());

                // Добавить параметры для команды
                cmd.Parameters.Add("@FirstName", MySqlDbType.VarChar).Value = txtFirstName.Text;
                cmd.Parameters.Add("@LastName", MySqlDbType.VarChar).Value = txtLastName.Text;
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = txtEmail.Text;
                cmd.Parameters.Add("@Password", MySqlDbType.VarChar).Value = txtPassword.Text;

                // Выполнить команду
                cmd.ExecuteNonQuery();

                // Закрыть соединение
                db.closeConnection();

                // Очистить поля формы
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtEmail.Text = "";
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";

                // Перенаправить пользователя на страницу успешной регистрации
                Response.Redirect("RegistrationSuccess.aspx");
            }
        }
    }
}
