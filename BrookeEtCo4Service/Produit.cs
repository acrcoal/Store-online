using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace BrookeEtCo4Service
{
    public class Produit
    {
        public int id { get; set; }
        public String nom { get; set; }
        public int quantite { get; set; }
        public double prixUnitaire { get; set; }
        public int seuilQuantite { get; set; }
        public String emplacement { get; set; }
        public String image { get; set; }

        //Nouveau produit lors de l'enregistrement

        public Produit(String nom, int quantite, double prixUnitaire, int seuilQuantite, String emplacement, String image)
        {
            this.nom = nom;
            this.quantite = quantite;
            this.prixUnitaire = prixUnitaire;
            this.seuilQuantite = seuilQuantite;
            this.emplacement = emplacement;
            this.image = image;
        }

        //Recherche de produit par son id
        public Produit(int id)
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
            String requete = "select * from produit where id=" + id;
            MySqlCommand cmd = new MySqlCommand();

            //Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = requete;
            DbDataReader reader = cmd.ExecuteReader();
            List<Produit> listeProduit = new List<Produit>();
            while (reader.Read())
            {
                this.id = reader.GetInt32(0);
                this.nom = reader.GetString(1);
                this.quantite = reader.GetInt32(2);
                this.prixUnitaire = reader.GetDouble(3);
                this.seuilQuantite = reader.GetInt32(4);
                this.emplacement = reader.GetString(5);
                this.image = reader.GetString(6);
            }
        }

        public Produit(int id, String nom, int quantite, double prixUnitaire, int seuilQuantite, String emplacement, String image)
        {
            this.id = id;
            this.nom = nom;
            this.quantite = quantite;
            this.prixUnitaire = prixUnitaire;
            this.seuilQuantite = seuilQuantite;
            this.emplacement = emplacement;
            this.image = image;
        }

        public static List<Produit> getListeProduit()
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
            String requete = "select * from listeProduit";
            MySqlCommand cmd = new MySqlCommand();

            //Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = requete;
            DbDataReader reader = cmd.ExecuteReader();
            List<Produit> listeProduit = new List<Produit>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                String nom = reader.GetString(1);
                int quantite = reader.GetInt32(2);
                double prixUnitaire = reader.GetDouble(3);
                int seuilQuantite = reader.GetInt32(4);
                String emplacement = reader.GetString(5);
                String image = reader.GetString(6);
                String isbn = reader.GetString(7);
                String auteur = reader.GetString(8);
                String duree = reader.GetString(9);
                String plateforme = reader.GetString(10);
                String categorie = reader.GetString(11);
                if (!duree.Equals(""))
                {
                    Film film = new Film(nom, quantite, prixUnitaire, seuilQuantite, emplacement, image, duree, categorie);
                    film.id = id; //Utilisation de setter de id
                    listeProduit.Add(film);
                }
                else if (!plateforme.Equals(""))
                {
                    Jeux jeux = new Jeux(nom, quantite, prixUnitaire, seuilQuantite, emplacement, image, plateforme, categorie);
                    jeux.id = id; //Utilisation de setter de id
                    listeProduit.Add(jeux);
                }
                else if (!isbn.Equals("") && !auteur.Equals(""))
                {
                    Livre livre = new Livre(nom, quantite, prixUnitaire, seuilQuantite, emplacement, image, isbn, auteur, categorie);
                    livre.id = id; //utilisation de setter de id
                    listeProduit.Add(livre);
                }                


            }
            return listeProduit;
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
            String requete = "insert into produit values(null, '" + nom + "', " + quantite +
                ", " + prixUnitaire + ", " + seuilQuantite + ", '" + emplacement + "', '" + image + "');";
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
            String requete = "update produit set nom='" + nom + "', quantite="
                + quantite + ", prixUnitaire=" + prixUnitaire + ", quantiteSeuil=" + seuilQuantite + ", emplacement='"
                + emplacement + "', emplacement='" + emplacement + "', image='" + image + "' where id=" + id;
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
            String requete = "delete from Produit where id=" + id;
            MySqlCommand cmd = new MySqlCommand();

            // Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = requete;
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
    }
}