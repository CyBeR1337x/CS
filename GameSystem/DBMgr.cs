using System.Data.SqlClient;
using System.Collections.Generic;
namespace GameSystem {
    class DBMgr {
        SqlConnection conn;
        string str = @"Data Source=localhost;Initial Catalog=nodedb;User ID=sa;Password=123; MultipleActiveResultSets=true"; //Update This
        private const string tableName = "games";
        
        public DBMgr() {
            try {
                conn = new SqlConnection(str);
                conn.Open();
                System.Console.WriteLine("Connected!");
            } catch (SqlException e) {
                System.Console.WriteLine(e.ToString());
            }
        }

        public List<Game> SelectQuery() { 
            SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM games", conn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<Game> ls = new List<Game>();
            for (int i = 0; reader.Read(); i++) ls.Add(new Game(reader.GetInt32(0), reader.GetString(1)));
            sqlCommand.Cancel();
            return ls;
        }

        public int InsertQuery(int id, string name) {
            SqlCommand sqlCommand = new SqlCommand($"INSERT INTO {tableName} VALUES('{id}', '{name}')", conn);
            int rows =  sqlCommand.ExecuteNonQuery();
            sqlCommand.Cancel();
            return rows;
        }

        public int DeleteQuery(int id) {
            SqlCommand sqlCommand = new SqlCommand($"DELETE FROM {tableName} WHERE id = {id}", conn);
            int rows = sqlCommand.ExecuteNonQuery();
            sqlCommand.Cancel();
            return rows;
        }

        public void Close() => conn.Close();
    }
}
