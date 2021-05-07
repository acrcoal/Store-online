using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace BrookeEtCo4Service
{
    class Film : Produit
    {
        public String duree { get; set; }
        public String categorie { get; set; }

        public Film(String nom, int quantite, double prixUnitaire,
            int seuilQuantite, String emplacement, String image, String duree, String categorie) : base(nom,
                quantite, prixUnitaire, seuilQuantite, emplacement, image)
        {
            this.duree = duree;
            this.categorie = categorie;
        }

        public Film(int id, String nom, int quantite, double prixUnitaire, int seuilQuantite, String emplacement, String image, String duree, String categorie) : base(id, nom,
                 quantite, prixUnitaire, seuilQuantite, emplacement, image)
        {
            this.id = id;
            this.nom = nom;
            this.quantite = quantite;
            this.prixUnitaire = prixUnitaire;
            this.seuilQuantite = seuilQuantite;
            this.emplacement = emplacement;
            this.image = image;
            this.duree = duree;
            this.categorie = categorie;
        }

        //Recherche de produit par son id
        public Film(int id) : base(id)
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
            String requete = "select * from listeFilm where idProduit=" + id;
            MySqlCommand cmd = new MySqlCommand();

            //Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = requete;
            DbDataReader reader = cmd.ExecuteReader();
            List<Film> listeFilm = new List<Film>();
            while (reader.Read())
            {
                this.id = reader.GetInt32(0);
                this.nom = reader.GetString(1);
                this.quantite = reader.GetInt32(2);
                this.prixUnitaire = reader.GetDouble(3);
                this.seuilQuantite = reader.GetInt32(4);
                this.emplacement = reader.GetString(5);
                this.image = reader.GetString(6);
                this.duree = reader.GetString(7);
                this.categorie = reader.GetString(8);

            }
        }

        public static List<Film> getListeFilm()
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
            String requete = "select * from listeFilm";
            MySqlCommand cmd = new MySqlCommand();

            //Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = requete;
            DbDataReader reader = cmd.ExecuteReader();
            List<Film> listeFilm = new List<Film>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                String nom = reader.GetString(1);
                int quantite = reader.GetInt32(2);
                double prixUnitaire = reader.GetDouble(3);
                int seuilQuantite = reader.GetInt32(4);
                String emplacement = reader.GetString(5);
                String image = reader.GetString(6);
                String duree = reader.GetString(7);
                String categorie = reader.GetString(8);
                Film film = new Film(nom, quantite, prixUnitaire, seuilQuantite, emplacement, image, duree, categorie);
                film.id = id; //utilisation de setter de id
                listeFilm.Add(film);
            }
            return listeFilm;
        }

        public static List<Film> getListeFilmFiction()
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
            String requete = "select * from listefilmfiction";
            MySqlCommand cmd = new MySqlCommand();

            //Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = requete;
            DbDataReader reader = cmd.ExecuteReader();
            List<Film> listeFilmFiction = new List<Film>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                String nom = reader.GetString(1);
                int quantite = reader.GetInt32(2);
                double prixUnitaire = reader.GetDouble(3);
                int seuilQuantite = reader.GetInt32(4);
                String emplacement = reader.GetString(5);
                String image = reader.GetString(6);
                String duree = reader.GetString(7);
                String categorie = reader.GetString(8);
                Film film = new Film(nom, quantite, prixUnitaire, seuilQuantite, emplacement, image, duree, categorie);
                film.id = id; //utilisation de setter de id
                listeFilmFiction.Add(film);
            }
            return listeFilmFiction;
        }

        public static List<Film> getListeFilmDrame()
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
            String requete = "select * from listefilmdrame";
            MySqlCommand cmd = new MySqlCommand();

            //Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = requete;
            DbDataReader reader = cmd.ExecuteReader();
            List<Film> listeFilmDrame = new List<Film>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                String nom = reader.GetString(1);
                int quantite = reader.GetInt32(2);
                double prixUnitaire = reader.GetDouble(3);
                int seuilQuantite = reader.GetInt32(4);
                String emplacement = reader.GetString(5);
                String image = reader.GetString(6);
                String duree = reader.GetString(7);
                String categorie = reader.GetString(8);
                Film film = new Film(nom, quantite, prixUnitaire, seuilQuantite, emplacement, image, duree, categorie);
                film.id = id; //utilisation de setter de id
                listeFilmDrame.Add(film);
            }
            return listeFilmDrame;
        }

        public static List<Film> getListeFilmComedie()
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
            String requete = "select * from listefilmcomedie";
            MySqlCommand cmd = new MySqlCommand();

            //Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = requete;
            DbDataReader reader = cmd.ExecuteReader();
            List<Film> listeFilmComedie = new List<Film>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                String nom = reader.GetString(1);
                int quantite = reader.GetInt32(2);
                double prixUnitaire = reader.GetDouble(3);
                int seuilQuantite = reader.GetInt32(4);
                String emplacement = reader.GetString(5);
                String image = reader.GetString(6);
                String duree = reader.GetString(7);
                String categorie = reader.GetString(8);
                Film film = new Film(nom, quantite, prixUnitaire, seuilQuantite, emplacement, image, duree, categorie);
                film.id = id; //utilisation de setter de id
                listeFilmComedie.Add(film);
            }
            return listeFilmComedie;
        }

        public static List<Film> getListeFilmAction()
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
            String requete = "select * from listefilmaction";
            MySqlCommand cmd = new MySqlCommand();

            //Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = requete;
            DbDataReader reader = cmd.ExecuteReader();
            List<Film> listeFilmAction = new List<Film>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                String nom = reader.GetString(1);
                int quantite = reader.GetInt32(2);
                double prixUnitaire = reader.GetDouble(3);
                int seuilQuantite = reader.GetInt32(4);
                String emplacement = reader.GetString(5);
                String image = reader.GetString(6);
                String duree = reader.GetString(7);
                String categorie = reader.GetString(8);
                Film film = new Film(nom, quantite, prixUnitaire, seuilQuantite, emplacement, image, duree, categorie);
                film.id = id; //utilisation de setter de id
                listeFilmAction.Add(film);
            }
            return listeFilmAction;
        }

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


            String requete = "insert into Film values(" + id2 + ", '" + duree + "', '" +
                  categorie + "');";

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
            String requete = "update Film set duree='" + duree + "', categorie='" + categorie + "' where idProduit=" + id;
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
            String requete = "delete from film where idProduit=" + id;
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