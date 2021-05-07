using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace BrookeEtCo4Service
{
    class Jeux : Produit
    {
        public string plateforme { get; set; }
        public string categorie { get; set; }

        public Jeux(String nom, int quantite, double prixUnitaire,
            int seuilQuantite, String emplacement, String image,
            String plateforme, String categorie) : base(nom, quantite, prixUnitaire,
                seuilQuantite, emplacement, image)
        {
            this.plateforme = plateforme;
            this.categorie = categorie;
        }

        public Jeux(int id, String nom, int quantite, double prixUnitaire, int seuilQuantite, String emplacement, String image, String plateforme, String categorie) : base(id, nom,
                quantite, prixUnitaire, seuilQuantite, emplacement, image)
        {
            this.id = id;
            this.nom = nom;
            this.quantite = quantite;
            this.prixUnitaire = prixUnitaire;
            this.seuilQuantite = seuilQuantite;
            this.emplacement = emplacement;
            this.image = image;
            this.plateforme = plateforme;
            this.categorie = categorie;
        }

        //Recherche de produit par son id
        public Jeux(int id) : base(id)
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
            String requete = "select * from listeJeux where idProduit=" + id;
            MySqlCommand cmd = new MySqlCommand();

            //Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = requete;
            DbDataReader reader = cmd.ExecuteReader();
            List<Jeux> listeJeux = new List<Jeux>();
            while (reader.Read())
            {
                this.id = reader.GetInt32(0);
                this.nom = reader.GetString(1);
                this.quantite = reader.GetInt32(2);
                this.prixUnitaire = reader.GetDouble(3);
                this.seuilQuantite = reader.GetInt32(4);
                this.emplacement = reader.GetString(5);
                this.image = reader.GetString(6);
                this.plateforme = reader.GetString(7);
                this.categorie = reader.GetString(8);

            }
        }

        public static List<Jeux> getListeJeux()
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
            String requete = "select * from listeJeux";
            MySqlCommand cmd = new MySqlCommand();

            //Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = requete;
            DbDataReader reader = cmd.ExecuteReader();
            List<Jeux> listeJeux = new List<Jeux>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                String nom = reader.GetString(1);
                int quantite = reader.GetInt32(2);
                double prixUnitaire = reader.GetDouble(3);
                int seuilQuantite = reader.GetInt32(4);
                String emplacement = reader.GetString(5);
                String image = reader.GetString(6);
                String plateforme = reader.GetString(7);
                String categorie = reader.GetString(8);
                Jeux jeux = new Jeux(nom, quantite, prixUnitaire, seuilQuantite, emplacement, image, plateforme, categorie);
                jeux.id = id; //utilisation de setter de id
                listeJeux.Add(jeux);
            }
            return listeJeux;
        }

        public static List<Jeux> getListeJeuxPlaystation()
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
            String requete = "select * from listejeuxplaystation";
            MySqlCommand cmd = new MySqlCommand();

            //Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = requete;
            DbDataReader reader = cmd.ExecuteReader();
            List<Jeux> listeJeuxPlaystation = new List<Jeux>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                String nom = reader.GetString(1);
                int quantite = reader.GetInt32(2);
                double prixUnitaire = reader.GetDouble(3);
                int seuilQuantite = reader.GetInt32(4);
                String emplacement = reader.GetString(5);
                String image = reader.GetString(6);
                String plateforme = reader.GetString(7);
                String categorie = reader.GetString(8);
                Jeux jeux = new Jeux(nom, quantite, prixUnitaire, seuilQuantite, emplacement, image, plateforme, categorie);
                jeux.id = id; //utilisation de setter de id
                listeJeuxPlaystation.Add(jeux);
            }
            return listeJeuxPlaystation;
        }

        public static List<Jeux> getListeJeuxNintendo()
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
            String requete = "select * from listejeuxnintendo";
            MySqlCommand cmd = new MySqlCommand();

            //Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = requete;
            DbDataReader reader = cmd.ExecuteReader();
            List<Jeux> listeJeuxNintendo = new List<Jeux>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                String nom = reader.GetString(1);
                int quantite = reader.GetInt32(2);
                double prixUnitaire = reader.GetDouble(3);
                int seuilQuantite = reader.GetInt32(4);
                String emplacement = reader.GetString(5);
                String image = reader.GetString(6);
                String plateforme = reader.GetString(7);
                String categorie = reader.GetString(8);
                Jeux jeux = new Jeux(nom, quantite, prixUnitaire, seuilQuantite, emplacement, image, plateforme, categorie);
                jeux.id = id; //utilisation de setter de id
                listeJeuxNintendo.Add(jeux);
            }
            return listeJeuxNintendo;
        }

        public static List<Jeux> getListeJeuxXbox()
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
            String requete = "select * from listejeuxxbox";
            MySqlCommand cmd = new MySqlCommand();

            //Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = requete;
            DbDataReader reader = cmd.ExecuteReader();
            List<Jeux> listeJeuxXbox = new List<Jeux>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                String nom = reader.GetString(1);
                int quantite = reader.GetInt32(2);
                double prixUnitaire = reader.GetDouble(3);
                int seuilQuantite = reader.GetInt32(4);
                String emplacement = reader.GetString(5);
                String image = reader.GetString(6);
                String plateforme = reader.GetString(7);
                String categorie = reader.GetString(8);
                Jeux jeux = new Jeux(nom, quantite, prixUnitaire, seuilQuantite, emplacement, image, plateforme, categorie);
                jeux.id = id; //utilisation de setter de id
                listeJeuxXbox.Add(jeux);
            }
            return listeJeuxXbox;
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


            String requete = "insert into Jeux values(" + id2 + ", '" + plateforme + "', '" +
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
            String requete = "update jeux set plateforme='" + plateforme + "', categorie='" + categorie + "' where idProduit=" + id;
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
            String requete = "delete from jeux where idProduit=" + id;
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