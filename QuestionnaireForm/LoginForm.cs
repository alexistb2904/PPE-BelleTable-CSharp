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
            SetupResponsiveDesign();
        }

        private void SetupResponsiveDesign()
        {
            // Configuration minimale de la fenêtre
            this.MinimumSize = new Size(400, 300);

            // Création d'un layout principal
            TableLayoutPanel mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 4,
                ColumnCount = 2,
                Padding = new Padding(20),
                RowStyles = {
                new RowStyle(SizeType.Percent, 25F),
                new RowStyle(SizeType.Percent, 25F),
                new RowStyle(SizeType.Percent, 25F),
                new RowStyle(SizeType.Percent, 25F)
            }
            };

            // Ajout des labels et des zones de texte
            Label usernameLabel = new Label { Text = "Nom d'utilisateur:", Anchor = AnchorStyles.Left | AnchorStyles.Right };
            Label passwordLabel = new Label { Text = "Mot de passe:", Anchor = AnchorStyles.Left | AnchorStyles.Right };

            txtbox_username.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtbox_password.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            Button loginButton = new Button
            {
                Text = "Se connecter",
                Dock = DockStyle.Fill,
                Margin = new Padding(40, 10, 40, 10)
            };
            loginButton.Click += button1_Click;

            // Ajout des contrôles au layout
            mainLayout.Controls.Add(usernameLabel, 0, 0);
            mainLayout.Controls.Add(txtbox_username, 1, 0);
            mainLayout.Controls.Add(passwordLabel, 0, 1);
            mainLayout.Controls.Add(txtbox_password, 1, 1);
            mainLayout.Controls.Add(loginButton, 0, 3);
            mainLayout.SetColumnSpan(loginButton, 2);

            // Ajout du layout au formulaire
            this.Controls.Clear();
            this.Controls.Add(mainLayout);
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

        private void RegisterUser(DBConnection db, string username, string password, string email = "")
        {
            if (db != null)
            {
                if (db.IsConnect())
                {
                    Console.WriteLine("Connected to database");
                    MySqlCommand connectionRequest = new MySqlCommand(
                        "SELECT id FROM users WHERE username = @username",
                        db.Connection
                    );

                    connectionRequest.Parameters.AddWithValue("@username", username);

                    using (MySqlDataReader reader = connectionRequest.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            Console.WriteLine("Cet utilisateur existe déjà.");
                            MessageBox.Show("Cet utilisateur existe déjà.");
                            reader.Close();
                            return;
                        }
                        reader.Close();
                    }

                    MySqlCommand insertRequest = new MySqlCommand(
                        "INSERT INTO users (username, password, role, email, groupe_id) VALUES (@username, @password, @role, @email, @groupe_id)",
                        db.Connection);

                    using (SHA256 sha256Hash = SHA256.Create())
                    {
                        insertRequest.Parameters.AddWithValue("@username", username);
                        insertRequest.Parameters.AddWithValue("@password", GetHash(sha256Hash, password));
                        insertRequest.Parameters.AddWithValue("@role", 0);
                        insertRequest.Parameters.AddWithValue("@email", email);
                        insertRequest.Parameters.AddWithValue("@groupe_id", 0);
                    }

                    insertRequest.ExecuteNonQuery();
                    Console.WriteLine("Utilisateur inscrit avec succès.");
                    MessageBox.Show("Utilisateur inscrit avec succès.");
                }
                else
                {
                    MessageBox.Show("Erreur de connexion à la base de données.");
                }
            }
            else
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

                    if (reader.HasRows)
                    {
                        string role = "";
                        int id = 0;
                        string username_db = "";
                        while (reader.Read())
                        {
                            role = reader["role"].ToString();
                            id = int.Parse(reader["id"].ToString());
                            username_db = reader["username"].ToString();
                            Console.WriteLine($"ID: {reader["id"]}");
                            Console.WriteLine($"Username: {reader["username"]}");
                            Console.WriteLine($"Role: {reader["role"]}");
                        }
                        reader.Close();

                        // Interface pour utilisateur standard (étudiant)
                        if (role == "0")
                        {
                            MessageBox.Show("Les utilisateurs standard ne peuvent pas accéder à l'interface administrateur. Demandez à un administrateur de changer votre rôle.");
                        }
                        // Interface pour administrateur (professeur)
                        else if (role == "1")
                        {
                            Console.WriteLine("Affichage Interface Administrateur");
                            listeQuestionnaireForm listeQuestionnaireForm = new listeQuestionnaireForm(db, username_db, id);
                            listeQuestionnaireForm.Show();
                            this.Hide();
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
