using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace tera56195 {
    class Program {
        static void Main(string[] args) {
            StringBuilder sb = new StringBuilder();
            sb.Append("Server=localhost;");
            sb.Append("Port=5432;");
            sb.Append("User Id=postgres;");
            sb.Append("Password=5151;");
            sb.Append("Database=test");

            string connString = sb.ToString();

            using(var con = new NpgsqlConnection(connString)) {
                con.Open();

                //データ登録
                var cmd = new NpgsqlCommand(@"insert into table01 values (6, 'testdata')", con);
                cmd.ExecuteNonQuery();

                //データ検索
                cmd = new NpgsqlCommand(@"select * from table01", con);
                var dataReader = cmd.ExecuteReader();
                while(dataReader.Read()) {
                    Console.WriteLine("{0},{1}", dataReader["id"], dataReader["name"]);
                }
                Console.Read();
            }
        }
    }
}
