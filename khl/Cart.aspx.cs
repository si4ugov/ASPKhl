using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace khl
{
    public partial class Cart : Page
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
                List<Item> cartItems = (List<Item>)Session["CartItems"];
                if (cartItems != null)
                {
                    CartGridView.DataSource = cartItems;
                    CartGridView.DataBind();
                    UpdateTotal();
                }
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
            
        }
        protected void RemoveButton_Click(object sender, EventArgs e)
        {
            List<Item> cartItems = (List<Item>)Session["CartItems"];
            Button removeButton = (Button)sender;
            string itemName = removeButton.CommandArgument;
            cartItems.RemoveAll(i => i.ItemName == itemName);
            Session["CartItems"] = cartItems;
            CartGridView.DataSource = cartItems;
            CartGridView.DataBind();
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            List<Item> cartItems = (List<Item>)Session["CartItems"];
            if (cartItems != null)
            {
                decimal total = cartItems.Sum(i => i.ItemPrice);
                TotalLabel.Text = "Total: $" + total;
            }
        }

        public Dictionary<int, int> Items { get; private set; } = new Dictionary<int, int>();

        public void AddItem(int itemId)
        {
            if (Items.ContainsKey(itemId))
            {
                // Увеличиваем количество товара в корзине на 1
                Items[itemId]++;
            }
            else
            {
                // Добавляем товар в корзину со значением количества 1
                Items.Add(itemId, 1);
            }
        }

        public void RemoveItem(int itemId)
        {
            if (Items.ContainsKey(itemId))
            {
                if (Items[itemId] > 1)
                {
                    // Уменьшаем количество товара в корзине на 1
                    Items[itemId]--;
                }
                else
                {
                    // Удаляем товар из корзины
                    Items.Remove(itemId);
                }
            }
        }

        public void Clear()
        {
            // Очищаем корзину
            Items.Clear();
        }

        public int GetItemCount()
        {
            // Считаем количество товаров в корзине
            int count = 0;
            foreach (var item in Items)
            {
                count += item.Value;
            }
            return count;
        }
    }

    public class Item
    {
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
    }



}
