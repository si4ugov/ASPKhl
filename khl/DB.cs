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
        public class DB : System.Web.UI.Page
        {
            static string connectionString = ("server=localhost;port=3306;username=root;password=root;database=shopkhl");
            MySqlConnection connection = new MySqlConnection(connectionString);
        
                public void openConnection()
                {
                    if (connection.State == System.Data.ConnectionState.Closed)
                        connection.Open();
                }

                public void closeConnection()
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }

                public MySqlConnection getConnection()
                {
                    return connection;
                }
        
        }
    }