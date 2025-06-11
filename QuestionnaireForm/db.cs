using System;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace QuestionnaireForm
{
    public class DBConnection
    {

        public DBConnection()
        {
        }
         
        public string Server { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public MySqlConnection Connection { get; set; }

        private static DBConnection _instance = null;
        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }

        public bool IsConnect()
        {
            try
            {
                if (Connection == null || Connection.State != System.Data.ConnectionState.Open)
                {
                    if (String.IsNullOrEmpty(DatabaseName))
                        return false;
                    string server = Server;
                    string port = null;
                    if (Server != null && Server.Contains(":"))
                    {
                        var parts = Server.Split(':');
                        server = parts[0];
                        port = parts.Length > 1 ? parts[1] : null;
                    }
                    string connstring;
                    if (!string.IsNullOrEmpty(port))
                    {
                        connstring = string.Format("Server={0};Port={1};database={2};UID={3};password={4}", server, port, DatabaseName, UserName, Password);
                    }
                    else
                    {
                        connstring = string.Format("Server={0};database={1};UID={2};password={3}", server, DatabaseName, UserName, Password);
                    }
                    Connection = new MySqlConnection(connstring);
                    Connection.Open();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public void Close()
        {
            Connection.Close();
        }
    }
}