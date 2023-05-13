using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace khl
{
    public partial class Team : System.Web.UI.Page
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

                // Заполняем информацию о пользователе на странице
                var email = Session["Email"].ToString();
                // lblEmail.Text = email;
            }
            else
            {
                // Пользователь не авторизован
                loginButton.Visible = true;
                registrationButton.Visible = true;
                lkBtn.Visible = false;
                tovBtn.Visible = false;
                cartBtn.Visible = false;
            }
        }
    }
}