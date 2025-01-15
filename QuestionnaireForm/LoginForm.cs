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

        // From https://learn.microsoft.com/fr-fr/dotnet/api/system.security.cryptography.hashalgorithm.computehash?view=net-8.0
        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        private static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
        {
            // Hash the input.
            var hashOfInput = GetHash(hashAlgorithm, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0;
        }

        private void RegisterUser(DBConnection db, string username, string password)
        {
            if (db != null)
            {
                if  (db.IsConnect())
                {
                    Console.WriteLine("Connected to database");
                    MySqlCommand connectionRequest = new MySqlCommand(
                        "SELECT id, username, role FROM users WHERE username = @username",
                        db.Connection
                    );

                    connectionRequest.Parameters.AddWithValue("@username", username);

                    MySqlDataReader reader = connectionRequest.ExecuteReader();

                    if (!reader.HasRows) // Vérifie s'il y a des résultats
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine("Cet utilisateur existe déjà.");
                            MessageBox.Show("Cet utilisateur existe déjà.");
                        }
                        else
                        {
                            reader.Close();
                            MySqlCommand insertRequest = new MySqlCommand("INSERT INTO users (username, password, role) VALUES (@username, @password, @role)",db.Connection);

                            using (SHA256 sha256Hash = SHA256.Create())
                            {
                                insertRequest.Parameters.AddWithValue("@username", username);
                                insertRequest.Parameters.AddWithValue("@password", GetHash(sha256Hash, password));
                                insertRequest.Parameters.AddWithValue("@role", 0);
                            }

                            insertRequest.ExecuteNonQuery();
                            Console.WriteLine("Utilisateur inscrit avec succès.");
                            MessageBox.Show("Utilisateur inscrit avec succès.");
                        }
                    } else
                    {
                        Console.WriteLine("Cet utilisateur existe déjà.");
                        MessageBox.Show("Cet utilisateur existe déjà.");
                    }
                }
                else
                {
                    MessageBox.Show("Erreur de connexion à la base de données.");
                }
            } else
            {
                MessageBox.Show("Erreur de connexion à la base de données.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtbox_username.Text;
            string password = txtbox_password.Text;
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Veuillez remplir tous les champs");
                MessageBox.Show("Veuillez remplir tous les champs");
            }
            else
            {
                Env.Load();
                DBConnection db = new DBConnection
                {
                    Server = Environment.GetEnvironmentVariable("DB_HOST") ?? throw new InvalidOperationException("DB_HOST n'existe pas"),
                    DatabaseName = Environment.GetEnvironmentVariable("DB_NAME") ?? throw new InvalidOperationException("DB_NAME n'existe pas"),
                    UserName = Environment.GetEnvironmentVariable("DB_USER") ?? throw new InvalidOperationException("DB_USER n'existe pas"),
                    Password = Crypto.Decrypt(Environment.GetEnvironmentVariable("DB_PASSWORD") ?? throw new InvalidOperationException("DB_PASSWORD n'existe pas"))
                };

                if (db.IsConnect())
                {
                    Console.WriteLine("Connected to database");
                    MySqlCommand connectionRequest = new MySqlCommand(
                        "SELECT id, username, role FROM users WHERE username = @username AND password = @password",
                        db.Connection
                    );
                    using (SHA256 sha256Hash = SHA256.Create())
                    {
                        connectionRequest.Parameters.AddWithValue("@username", username);
                        connectionRequest.Parameters.AddWithValue("@password", GetHash(sha256Hash, password));
                    }

                    MySqlDataReader reader = connectionRequest.ExecuteReader();

                    if (reader.HasRows) // Vérifie s'il y a des résultats
                    {
                        string role = "";
                        int id = 0;
                        while (reader.Read())
                        {
                            role = reader["role"].ToString();
                            id = int.Parse(reader["id"].ToString());
                            Console.WriteLine($"ID: {reader["id"]}");
                            Console.WriteLine($"Username: {reader["username"]}");
                            Console.WriteLine($"Role: {reader["role"]}");
                            
                        }
                        reader.Close();
                        if (role == "0")
                        {
                            Console.WriteLine("Affichage Interface Réponse");
                        }
                        else if (role == "1")
                        {
                            Console.WriteLine("Affichage Interface Administrateur");
                            this.Hide();
                            listeQuestionnaireForm listeQuestionnaireForm = new listeQuestionnaireForm(db, username, id);
                            listeQuestionnaireForm.Show();
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Aucun utilisateur trouvé avec ces informations.");
                        var result = MessageBox.Show(
                            "Nom d'utilisateur ou mot de passe incorrect. Voulez-vous vous inscrire si vous n'avez pas de compte ?",
                            "Inscription",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (result == DialogResult.Yes)
                        {
                            Console.WriteLine("Inscription de l'utilisateur...");
                            reader.Close();
                            RegisterUser(db, username, password);
                        }
                        else
                        {
                            MessageBox.Show("Vous avez choisi de ne pas vous inscrire.");
                        }
                    }

                    reader.Close(); // Toujours fermer le lecteur après utilisation
                    db.Close();
                }
                else
                {
                    db.Close();
                    Console.WriteLine("Impossible de se connecter à la base de données.");
                    MessageBox.Show("Erreur de connexion à la base de données.");
                }
            }
        }
    }
}
