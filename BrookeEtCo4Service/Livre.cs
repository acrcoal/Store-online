using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace BrookeEtCo4Service
{
    public class Livre : Produit
    {
        public String isbn { get; set; }
        public String auteur { get; set; }
        public String categorie { get; set; }

        //Nouveau produit lors de l'enregistrement
        public Livre(String nom, int quantite, double prixUnitaire,
            int seuilQuantite, String emplacement, String image, String isbn, String auteur, String categorie) : base(nom,
                quantite, prixUnitaire, seuilQuantite, emplacement, image)
        {
            this.isbn = isbn;
            this.auteur = auteur;
            this.categorie = categorie;
        }

        public Livre(int id, String nom, int quantite, double prixUnitaire, int seuilQuantite, String emplacement, String image, String isbn, String auteur, String categorie) : base(id, nom,
                quantite, prixUnitaire, seuilQuantite, emplacement, image)
        {
            this.id = id;
            this.nom = nom;
            this.quantite = quantite;
            this.prixUnitaire = prixUnitaire;
            this.seuilQuantite = seuilQuantite;
            this.emplacement = emplacement;
            this.image = image;
            this.isbn = isbn;
            this.auteur = auteur;
            this.categorie = categorie;
        }

        //Recherche de produit par son id
        public Livre(int id) : base(id)
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
            String requete = "select * from listelivre where idProduit=" + id;
            MySqlCommand cmd = new MySqlCommand();

            //Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = requete;
            DbDataReader reader = cmd.ExecuteReader();
            List<Livre> listeLivre = new List<Livre>();
            while (reader.Read())
            {
                this.id = reader.GetInt32(0);
                this.nom = reader.GetString(1);
                this.quantite = reader.GetInt32(2);
                this.prixUnitaire = reader.GetDouble(3);
                this.seuilQuantite = reader.GetInt32(4);
                this.emplacement = reader.GetString(5);
                this.image = reader.GetString(6);
                this.isbn = reader.GetString(7);
                this.auteur = reader.GetString(8);
                this.categorie = reader.GetString(9);

            }
        }

        public static List<Livre> getListeLivre()
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
            String requete = "select * from listeLivre";
            MySqlCommand cmd = new MySqlCommand();

            //Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = requete;
            DbDataReader reader = cmd.ExecuteReader();
            List<Livre> listeLivre = new List<Livre>();
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
                String categorie = reader.GetString(9);
                Livre livre = new Livre(nom, quantite, prixUnitaire, seuilQuantite, emplacement, image, isbn, auteur, categorie);
                livre.id = id; //utilisation de setter de id
                listeLivre.Add(livre);
            }
            return listeLivre;
        }
        //
        public static List<Livre> getListeLivreInformatique()
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
            String requete = "select * from listelivreinformatique";
            MySqlCommand cmd = new MySqlCommand();

            //Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = requete;
            DbDataReader reader = cmd.ExecuteReader();
            List<Livre> listeLivreInformatique = new List<Livre>();
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
                String categorie = reader.GetString(9);
                Livre livre = new Livre(nom, quantite, prixUnitaire, seuilQuantite, emplacement, image, isbn, auteur, categorie);
                livre.id = id; //utilisation de setter de id
                listeLivreInformatique.Add(livre);
            }
            return listeLivreInformatique;
        }
        //
        public static List<Livre> getListeLivreLitterature()
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
            String requete = "select * from listelivrelitterature";
            MySqlCommand cmd = new MySqlCommand();

            //Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = requete;
            DbDataReader reader = cmd.ExecuteReader();
            List<Livre> listeLivreLitterature = new List<Livre>();
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
                String categorie = reader.GetString(9);
                Livre livre = new Livre(nom, quantite, prixUnitaire, seuilQuantite, emplacement, image, isbn, auteur, categorie);
                livre.id = id; //utilisation de setter de id
                listeLivreLitterature.Add(livre);
            }
            return listeLivreLitterature;
        }

        //
        public static List<Livre> getListeLivreGeographique()
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
            String requete = "select * from listelivregeographique";
            MySqlCommand cmd = new MySqlCommand();

            //Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = requete;
            DbDataReader reader = cmd.ExecuteReader();
            List<Livre> listeLivreGeographique = new List<Livre>();
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
                String categorie = reader.GetString(9);
                Livre livre = new Livre(nom, quantite, prixUnitaire, seuilQuantite, emplacement, image, isbn, auteur, categorie);
                livre.id = id; //utilisation de setter de id
                listeLivreGeographique.Add(livre);
            }
            return listeLivreGeographique;
        }

        //

        public override void enregistrer()
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
            base.enregistrer();

            String requete2 = "select max(id) from Produit";

            MySqlCommand cmd2 = new MySqlCommand();

            //Établissez la connexion de la commande.
            cmd2.Connection = conn;
            cmd2.CommandText = requete2;
            DbDataReader reader2 = cmd2.ExecuteReader();

            int id2 = 0;

            while (reader2.Read())
            {
                id2 = reader2.GetInt32(0);

            }
            reader2.Close();


            String requete = "insert into Livre values(" + id2 + ", '" + isbn + "', '" +
                 auteur + "', '" + categorie + "');";
            /*String requete = "insert into Livre values(" + id + ", '" + nom + "' , " + quantite + ", " + prixUnitaire + ", " + seuilQuantite + ", '" +
                emplacement + "', '" + image + "', '" + categorie + "');";*/

            MySqlCommand cmd = new MySqlCommand();

            //Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = requete;
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();

        }

        public override void modifier()
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
            base.modifier();
            String requete = "update livre set isbn='" + isbn + "', auteur='" + auteur + "', categorie='" + categorie + "' where idProduit=" + id;
            /*String requete = "update livre set nom='" + nom + "', quantite="
                + quantite + ", prixUnitaire=" + prixUnitaire + ", seuilQuantite=" + seuilQuantite + ", emplacement='"
                + emplacement + "', image='" + image + "', isbn='" + isbn + "', auteur='" + auteur + "', categorie='" + categorie + "' where id=" + id;*/
            MySqlCommand cmd = new MySqlCommand();

            // Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = requete;
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }

        public override void supprimer()
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
            base.supprimer();
            String requete = "delete from livre where idProduit=" + id;
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