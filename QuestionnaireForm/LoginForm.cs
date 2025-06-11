using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;
using DotNetEnv;
using System.Data;

namespace QuestionnaireForm
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        // Centralized message display
        private void ShowMessage(string msg, bool error = true)
        {
            message_label.Text = msg;
            message_label.ForeColor = error ? Color.DarkRed : Color.DarkGreen;
        }

        // Hash password
        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));
            return sBuilder.ToString();
        }

        // Database connection initialization
        private DBConnection InitDbConnection()
        {
            string envPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".env");
            if (!File.Exists(envPath))
            {
                ShowMessage($"Le fichier .env est introuvable à l'emplacement : {envPath}");
                return null;
            }
            DotNetEnv.Env.Load(envPath);
            try
            {
                if (Environment.GetEnvironmentVariable("USE_ALT_DB") == "False")
                {
                    return new DBConnection
                    {

                        Server = Environment.GetEnvironmentVariable("DB_HOST") ?? throw new InvalidOperationException("DB_HOST n'existe pas"),
                        DatabaseName = Environment.GetEnvironmentVariable("DB_NAME") ?? throw new InvalidOperationException("DB_NAME n'existe pas"),
                        UserName = Environment.GetEnvironmentVariable("DB_USER") ?? throw new InvalidOperationException("DB_USER n'existe pas"),
                        Password = Crypto.Decrypt(Environment.GetEnvironmentVariable("DB_PASSWORD") ?? throw new InvalidOperationException("DB_PASSWORD n'existe pas"))
                    };
                } else
                {
                    return new DBConnection
                    {
                        Server = Environment.GetEnvironmentVariable("ALT_DB_HOST") ?? throw new InvalidOperationException("ALT_DB_HOST n'existe pas"),
                        DatabaseName = Environment.GetEnvironmentVariable("ALT_DB_NAME") ?? throw new InvalidOperationException("ALT_DB_NAME n'existe pas"),
                        UserName = Environment.GetEnvironmentVariable("ALT_DB_USER") ?? throw new InvalidOperationException("ALT_DB_USER n'existe pas"),
                        Password = Crypto.Decrypt(Environment.GetEnvironmentVariable("ALT_DB_PASSWORD") ?? throw new InvalidOperationException("ALT_DB_PASSWORD n'existe pas"))
                    };
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Erreur de configuration: {ex.Message}");
                return null;
            }
        }

        // Login logic
        private void button_signin_Click(object sender, EventArgs e)
        {
            string username = txtbox_username.Text.Trim();
            string password = txtbox_password.Text.Trim();
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ShowMessage("Veuillez remplir tous les champs");
                return;
            }
            var db = InitDbConnection();
            if (db == null || !db.IsConnect())
            {
                ShowMessage("Erreur de connexion à la base de données.");
                db?.Close();
                return;
            }
            try
            {
                using var sha256Hash = SHA256.Create();
                var cmd = new MySqlCommand(
                    "SELECT id, username, role FROM users WHERE username = @username AND password = @password",
                    db.Connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", GetHash(sha256Hash, password));
                using var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string role = reader["role"].ToString();
                    int id = int.Parse(reader["id"].ToString());
                    string username_db = reader["username"].ToString();
                    if (role == "0")
                    {
                        ShowMessage("Les utilisateurs standard ne peuvent pas accéder à l'interface administrateur.");
                    }
                    else if (role == "1")
                    {
                        ShowMessage("Connexion réussie !", false);
                        reader.Close();
                        listeQuestionnaireForm f = new listeQuestionnaireForm(db, username_db, id);
                        f.Show();
                        this.Hide();
                    }
                }
                else
                {
                    ShowMessage("Nom d'utilisateur ou mot de passe incorrect.");
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Erreur: {ex.Message}");
            }
            finally
            {
                db.Close();
            }
        }

        // Registration logic
        private void button_signup_Click(object sender, EventArgs e)
        {
            string username = txtbox_username.Text.Trim();
            string password = txtbox_password.Text.Trim();
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ShowMessage("Veuillez remplir tous les champs pour l'inscription.");
                return;
            }
            var db = InitDbConnection();
            if (db == null || !db.IsConnect())
            {
                ShowMessage("Erreur de connexion à la base de données.");
                db?.Close();
                return;
            }
            try
            {
                // Vérifier si l'utilisateur existe déjà
                var checkCmd = new MySqlCommand("SELECT id FROM users WHERE username = @username", db.Connection);
                checkCmd.Parameters.AddWithValue("@username", username);
                bool userExists = false;
                using (var reader = checkCmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        userExists = true;
                    }
                } // Reader is closed here
                if (userExists)
                {
                    ShowMessage("Cet utilisateur existe déjà.");
                    return;
                }
                // Inscription
                using var sha256Hash = SHA256.Create();
                var insertCmd = new MySqlCommand(
                    "INSERT INTO users (username, password, role, email, groupe_id) VALUES (@username, @password, @role, @email, @groupe_id)",
                    db.Connection);
                insertCmd.Parameters.AddWithValue("@username", username);
                insertCmd.Parameters.AddWithValue("@password", GetHash(sha256Hash, password));
                insertCmd.Parameters.AddWithValue("@role", 0);
                insertCmd.Parameters.AddWithValue("@email", "");
                insertCmd.Parameters.AddWithValue("@groupe_id", 0);
                insertCmd.ExecuteNonQuery();
                ShowMessage("Utilisateur inscrit avec succès !", false);
            }
            catch (Exception ex)
            {
                ShowMessage($"Erreur lors de l'inscription: {ex.Message}");
            }
            finally
            {
                db.Close();
            }
        }
    }
}
