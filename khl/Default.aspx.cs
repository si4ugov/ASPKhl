using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace khl
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var cartBtn = Master.FindControl("cartBtn") as HtmlAnchor;
            var loginButton = Master.FindControl("loginButton") as HtmlAnchor;
            var registrationButton = Master.FindControl("registrationButton") as HtmlAnchor;
            var lkBtn = Master.FindControl("lkBtn") as HtmlAnchor;
            var tovBtn = Master.FindControl("tovBtn") as HtmlAnchor;

            if (Session["IsAuthenticated"] != null && (bool)Session["IsAuthenticated"])
            {
                // Пользователь авторизован
                loginButton.Visible = false;
                registrationButton.Visible = false;
                lkBtn.Visible = true;
                tovBtn.Visible = true;
                cartBtn.Visible = true;

            }
            else
            {
                // Пользователь не авторизован
                loginButton.Visible = true;
                registrationButton.Visible = true;
                lkBtn.Visible = false;
                tovBtn.Visible = false;
            }
        }

        public List<News> GetNews()
        {
            DB db = new DB();
            
            MySqlCommand command = new MySqlCommand("SELECT id, name, shortdesc, img, date FROM news", db.getConnection());

            db.openConnection();
            var reader = command.ExecuteReader();
            var newsList = new List<News>();

            while (reader.Read())
            {
                    var news = new News
                    {
                    id = reader.GetInt32(0),
                    name = reader.GetString(1),
                    shortdesc = reader.GetString(2),
                    img = reader.GetString(3),
                    date = reader.GetDateTime(4),
                    };
                    newsList.Add(news);
                        
            }
            reader.Close();
            db.closeConnection();

            return newsList;
        }
    }
}
