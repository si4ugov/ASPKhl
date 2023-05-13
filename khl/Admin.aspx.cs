using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace khl
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsAuthenticated"] = true;
            var cartBtn = Master.FindControl("cartBtn") as HtmlAnchor;
            var loginButton = Master.FindControl("loginButton") as HtmlAnchor;
            var registrationButton = Master.FindControl("registrationButton") as HtmlAnchor;
            var lkBtn = Master.FindControl("lkBtn") as HtmlAnchor;
            var tovBtn = Master.FindControl("tovBtn") as HtmlAnchor;
            var admBtn = Master.FindControl("admBtn") as HtmlAnchor;
            admBtn.Visible = true;
            loginButton.Visible = false;
            registrationButton.Visible = false;
            lkBtn.Visible = false;
            tovBtn.Visible = true;
            cartBtn.Visible = true;
        }

        protected void btnDeleteUser_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtDeleteId.Text);
            DB db = new DB();


            db.openConnection();
                string query = "DELETE FROM Users WHERE Id = @Id";
                using (MySqlCommand command = new MySqlCommand(query, db.getConnection()))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    int result = command.ExecuteNonQuery();
                    if (result == 1)
                    {
                        lblDeleteMessage.Visible = true;
                        lblDeleteMessage.Text = "Пользователь успешно удален.";
                    }
                    else
                    {
                        lblDeleteMessage.Visible = true;
                        lblDeleteMessage.Text = "Ошибка при удалении пользователя.";
                    }
                }
            
        }

        protected void btnAddNews_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string content = txtContent.Text;
            DateTime date = calDate.SelectedDate;

            if (title != "" && content != "" && date != null)
            {
                // Получаем путь к директории, где будут храниться изображения новостей
                string path = Server.MapPath("/img/");

                // Получаем имя файла и путь к нему на сервере
                string fileName = Path.GetFileName(fileUpload.PostedFile.FileName);
                string filePath = Path.Combine(path, fileName);

                // Сохраняем файл на сервере
                fileUpload.PostedFile.SaveAs(filePath);

                // Добавляем новость в базу данных
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("INSERT INTO news (name, shortdesc, img, date) VALUES (@title, @content, @image, @date)", db.getConnection());
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@content", content);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@image", "img/" + fileName);

                db.openConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Новость успешно добавлена";
                    lblMessage.CssClass = "alert alert-success";
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Ошибка при добавлении новости";
                    lblMessage.CssClass = "alert alert-danger";
                }

                db.closeConnection();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Заполните все поля";
                lblMessage.CssClass = "text-danger";
            }
        }
    }
}