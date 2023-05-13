using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace khl
{
    public partial class Tovars : Page
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
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                BindRepeater();
            }

        }

        private void BindRepeater()
        {
            DB db = new DB();

            MySqlCommand command = new MySqlCommand("SELECT id, name, price, shortdesc, img FROM tovar", db.getConnection());

            db.openConnection();
            var reader = command.ExecuteReader();
            var dataList = new List<Tovar>();

            while (reader.Read())
            {

                var data = new Tovar
                {
                    id = reader.GetInt32(0),
                    name = reader.GetString(1),
                    price = reader.GetInt32(2),
                    shortDesc = reader.GetString(3),
                    img = reader.GetString(4),
                };

                dataList.Add(data);
            }
            reader.Close();

            Repeater1.DataSource = dataList;
            Repeater1.DataBind();

            db.closeConnection();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Создаем объект класса Cart, чтобы получить доступ к методам для работы с корзиной
            Cart cart = new Cart();

            // Получаем id товара из атрибута CommandArgument кнопки
            int id = Convert.ToInt32((sender as Button).CommandArgument);

            // Получаем данные товара по его id из базы данных или другого источника данных
            Tovar tovar = GetTovarById(id);

            // Добавляем товар в корзину
            cart.AddItem(tovar.id);

            // Обновляем данные корзины на странице
            UpdateCartData();
        }

        protected void CategoryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int categoryId = Convert.ToInt32(CategoryDropDownList.SelectedValue);

            if (categoryId == 1)
            {
                // Загрузить все товары из базы данных
                DB db = new DB();

                MySqlCommand command = new MySqlCommand("SELECT * FROM tovar WHERE category=@Category", db.getConnection());
                command.Parameters.AddWithValue("@Category", "Билет");
                db.openConnection();
                var reader = command.ExecuteReader();
                var dataList = new List<Tovar>();

                while (reader.Read())
                {

                    var data = new Tovar
                    {
                        id = reader.GetInt32(0),
                        name = reader.GetString(1),
                        price = reader.GetInt32(2),
                        shortDesc = reader.GetString(3),
                        img = reader.GetString(4),
                    };

                    dataList.Add(data);
                }
                reader.Close();

                Repeater1.DataSource = dataList;
                Repeater1.DataBind();
                db.closeConnection();
            }
            if (categoryId == 2)
            {
                DB db = new DB();

                MySqlCommand command = new MySqlCommand("SELECT * FROM tovar WHERE category=@Category", db.getConnection());
                command.Parameters.AddWithValue("@Category", "Головной убор");
                db.openConnection();
                var reader = command.ExecuteReader();
                var dataList = new List<Tovar>();

                while (reader.Read())
                {

                    var data = new Tovar
                    {
                        id = reader.GetInt32(0),
                        name = reader.GetString(1),
                        price = reader.GetInt32(2),
                        shortDesc = reader.GetString(3),
                        img = reader.GetString(4),
                    };

                    dataList.Add(data);
                }
                reader.Close();

                Repeater1.DataSource = dataList;
                Repeater1.DataBind();
                db.closeConnection();
            }
            if(categoryId == 0)
            {
                BindRepeater();
            }
        }

        public static Tovar GetTovarById(int id)
        {
            DB db = new DB();

            Tovar tovar = null;
            string query = "SELECT * FROM tovar WHERE id=@id";
            MySqlCommand command = new MySqlCommand(query, db.getConnection());
            db.openConnection();
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                tovar = new Tovar
                {
                    id = reader.GetInt32(0),
                    name = reader.GetString(1),
                    price = reader.GetInt32(2),
                    shortDesc = reader.GetString(3),
                    img = reader.GetString(4),
                    category = reader.GetString(5)
                };
            }
            reader.Close();
            db.closeConnection();
            return tovar;
        }

        private void UpdateCartData()
        {
            // Создаем объект класса ShoppingCart, чтобы получить данные корзины
            Cart cart = new Cart();

            // Получаем количество товаров в корзине
            int itemCount = cart.GetItemCount();

            // Обновляем информацию о корзине на странице
            var cartBtn = Master.FindControl("cartBtn") as HtmlAnchor;
            cartBtn.InnerText = "Корзина (" + itemCount + ")";
        }


    }
}