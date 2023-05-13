using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace khl
{
   
    public class Tovar
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string img { get; set; }
        public string shortDesc { get; set; }
        // public string longDesc { get; set; }
         public string category { get; set; }
        //  public bool isFavorite { get; set; }
        //  public bool available { get; set; }
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
                };
            }
            reader.Close();
            db.closeConnection();

            return tovar;
        }
    }

}