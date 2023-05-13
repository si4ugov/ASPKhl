using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace khl
{
    public class News
    {
        public int id { get; set; }
        public string name { get; set; }
        public string shortdesc { get; set; }
        public string img { get; set; }
        public DateTime date { get; set; }

        public static void DeleteNews(int newsId)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM News WHERE Id=@newsId", conn);
                cmd.Parameters.AddWithValue("@newsId", newsId);
                cmd.ExecuteNonQuery();
            }
        }

    }
}