using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace BrookeEtCo4Service
{
    public class Client
    {
        public int id { get; set; }
        public String nom { get; set; }
        public String prenom { get; set; }
        public String typeUser { get; set; }
        public String courriel { get; set; }
        public String pass { get; set; }
        

        //Nouveau produit lors de l'enregistrement

        public Client(String nom, String prenom, String typeUser, String courriel, String pass)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.typeUser = typeUser;
            this.courriel = courriel;
            this.pass = pass;           
        }

        //Recherche de produit par son id
        public Client(String courriel)
        {
            string host = "localhost";
            int port = 3306;
            string database = "gestion2BrookeEtCo";
            string username = "root";
            string password = "Toscane2000**";
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            String requete = "select * from client where courriel='" + courriel + "'";
            MySqlCommand cmd = new MySqlCommand();

            //Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = requete;
            DbDataReader reader = cmd.ExecuteReader();
            List<Client> listeClient = new List<Client>();
            while (reader.Read())
            {
                this.id = reader.GetInt32(0);
                this.nom = reader.GetString(1);
                this.prenom = reader.GetString(2);
                this.typeUser = reader.GetString(3);
                this.courriel = reader.GetString(4);
                this.pass = reader.GetString(5);               
            }
        }

        public Client(int id, String nom, String prenom, String typeUser, String courriel, String pass)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.typeUser = typeUser;
            this.courriel = courriel;
            this.pass = pass;            
        }

        public static List<Client> getListeClient()
        {
            string host = "localhost";
            int port = 3306;
            string database = "gestion2BrookeEtCo";
            string username = "root";
            string password = "Toscane2000**";
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            String requete = "select * from listeclient";
            MySqlCommand cmd = new MySqlCommand();

            //Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = requete;
            DbDataReader reader = cmd.ExecuteReader();
            List<Client> listeClient = new List<Client>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                String nom = reader.GetString(1);
                String prenom = reader.GetString(2);
                String typeUser = reader.GetString(3);
                String courriel = reader.GetString(4);
                String pass = reader.GetString(5);
                Client client = new Client(nom, prenom, typeUser, courriel, pass);
                client.id = id;
                listeClient.Add(client);

            }
            return listeClient;
        }
        public virtual void enregistrer()
        {
            string host = "localhost";
            int port = 3306;
            string database = "gestion2BrookeEtCo";
            string username = "root";
            string password = "Toscane2000**";
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            String requete = "insert into client values(null, '" + nom + "', '" + prenom +
                "', '" + typeUser + "', '" + courriel + "', '" + pass + "');";
            MySqlCommand cmd = new MySqlCommand();

            //Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = requete;
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }

        public virtual void modifier()
        {
            string host = "localhost";
            int port = 3306;
            string database = "gestion2BrookeEtCo";
            string username = "root";
            string password = "Toscane2000**";
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            String requete = "update client set nom='" + nom + "', prenom='"
                + prenom + "', typeUser='" + typeUser + "', courriel='" + courriel + "', pass='"
                + pass + "' where courriel='" + courriel + "'";
            MySqlCommand cmd = new MySqlCommand();

            // Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = requete;
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }

        public virtual void supprimer()
        {
            string host = "localhost";
            int port = 3306;
            string database = "gestion2BrookeEtCo";
            string username = "root";
            string password = "Toscane2000**";
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            String requete = "delete from client where courriel='" + courriel + "'";
            MySqlCommand cmd = new MySqlCommand();

            // Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = requete;
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }

        public static Client Login(String courriel, String pass)
        {
            Client client = null;
            string host = "localhost";
            int port = 3306;
            string database = "gestion2BrookeEtCo";
            string username = "root";
            string password = "Toscane2000**";
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            String requete = "Select * from client where courriel='" +
            courriel + "' and pass='" + pass + "'";
            MySqlCommand cmd = new MySqlCommand();

            //Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = requete;
            DbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                String nom = reader.GetString(1);
                String prenom = reader.GetString(2);
                String typeUser = reader.GetString(3);
                courriel = reader.GetString(4);
                pass = reader.GetString(5);

                client = new Client(nom, prenom, typeUser, courriel, pass);
                client.id = id;                
    
            }
            return client;
        }
    }
}