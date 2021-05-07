using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace BrookeEtCo4Service
{
    /// <summary>
    /// Summary description for GestionStockProduit4
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class GestionStockProduit4 : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getProducts()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                List<Produit> liste = Produit.getListeProduit();
                Context.Response.Write(js.Serialize(liste));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getProduct(int id)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                Produit pr = new Produit(id);
                Context.Response.Write(js.Serialize(pr));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void createProduct(String nom, int quantite, double prixUnitaire, int seuilQuantite, String emplacement, String image)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                Produit pr = new Produit(nom, quantite, prixUnitaire, seuilQuantite, emplacement, image);
                pr.enregistrer();
                Context.Response.Write(js.Serialize(pr));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void deleteProduct(int id)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                Produit pr = new Produit(id);
                pr.supprimer();
                Context.Response.Write(js.Serialize("Opération réussie"));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void updateProduct(int id, String nom, int quantite, double prixUnitaire, int seuilQuantite, String emplacement, String image)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                Produit pr = new Produit(id);
                pr.nom = nom;
                pr.quantite = quantite;
                pr.prixUnitaire = prixUnitaire;
                pr.seuilQuantite = seuilQuantite;
                pr.emplacement = emplacement;
                pr.image = image;
                pr.modifier();
                Context.Response.Write(js.Serialize(pr));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }
        }
        // Livres*****************************************************************************************************

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getLivres()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                List<Livre> liste = Livre.getListeLivre();
                Context.Response.Write(js.Serialize(liste));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }

        }
        ////
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getLivresInformatique()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                List<Livre> liste = Livre.getListeLivreInformatique();
                Context.Response.Write(js.Serialize(liste));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }

        }
        ////
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getLivresLitterature()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                List<Livre> liste = Livre.getListeLivreLitterature();
                Context.Response.Write(js.Serialize(liste));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }

        }
        ////
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getLivresGeographique()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                List<Livre> liste = Livre.getListeLivreGeographique();
                Context.Response.Write(js.Serialize(liste));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }

        }
        ////

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getLivre(int id)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                Livre li = new Livre(id);
                Context.Response.Write(js.Serialize(li));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }
        }



        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void createLivre(String nom, int quantite, double prixUnitaire,
            int seuilQuantite, String emplacement, String image, String isbn, String auteur, String categorie)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                Livre li = new Livre(nom, quantite, prixUnitaire, seuilQuantite, emplacement, image, isbn, auteur, categorie);
                li.enregistrer();
                Context.Response.Write(js.Serialize(li));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void deleteLivre(int id)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                Livre li = new Livre(id);
                li.supprimer();
                Context.Response.Write(js.Serialize("Opération réussie"));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void updateLivre(int id, String nom, int quantite, double prixUnitaire, int seuilQuantite, String emplacement, String image, String isbn, String auteur, String categorie)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                Livre li = new Livre(id);
                li.nom = nom;
                li.quantite = quantite;
                li.prixUnitaire = prixUnitaire;
                li.seuilQuantite = seuilQuantite;
                li.emplacement = emplacement;
                li.image = image;
                li.isbn = isbn;
                li.auteur = auteur;
                li.categorie = categorie;
                li.modifier();
                Context.Response.Write(js.Serialize(li));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }
        }

        // Films*****************************************************************************************************

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getFilms()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                List<Film> liste = Film.getListeFilm();
                Context.Response.Write(js.Serialize(liste));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getFilmsFiction()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                List<Film> liste = Film.getListeFilmFiction();
                Context.Response.Write(js.Serialize(liste));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getFilmsDrame()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                List<Film> liste = Film.getListeFilmDrame();
                Context.Response.Write(js.Serialize(liste));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getFilmsComedie()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                List<Film> liste = Film.getListeFilmComedie();
                Context.Response.Write(js.Serialize(liste));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getFilmsAction()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                List<Film> liste = Film.getListeFilmAction();
                Context.Response.Write(js.Serialize(liste));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getFilm(int id)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                Film fi = new Film(id);
                Context.Response.Write(js.Serialize(fi));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }
        }



        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void createFilm(String nom, int quantite, double prixUnitaire,
            int seuilQuantite, String emplacement, String image, String duree, String categorie)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                Film fi = new Film(nom, quantite, prixUnitaire, seuilQuantite, emplacement, image, duree, categorie);
                fi.enregistrer();
                Context.Response.Write(js.Serialize(fi));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void deleteFilm(int id)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                Film fi = new Film(id);
                fi.supprimer();
                Context.Response.Write(js.Serialize("Opération réussie"));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void updateFilm(int id, String nom, int quantite, double prixUnitaire, int seuilQuantite, String emplacement, String image, String duree, String categorie)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                Film fi = new Film(id);
                fi.nom = nom;
                fi.quantite = quantite;
                fi.prixUnitaire = prixUnitaire;
                fi.seuilQuantite = seuilQuantite;
                fi.emplacement = emplacement;
                fi.image = image;
                fi.duree = duree;               
                fi.categorie = categorie;
                fi.modifier();
                Context.Response.Write(js.Serialize(fi));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }
        }
        // Jeux*****************************************************************************************************
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getJeuxs()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                List<Jeux> liste = Jeux.getListeJeux();
                Context.Response.Write(js.Serialize(liste));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getJeuxPlaystation()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                List<Jeux> liste = Jeux.getListeJeuxPlaystation();
                Context.Response.Write(js.Serialize(liste));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getJeuxNintendo()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                List<Jeux> liste = Jeux.getListeJeuxNintendo();
                Context.Response.Write(js.Serialize(liste));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getJeuxXbox()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                List<Jeux> liste = Jeux.getListeJeuxXbox();
                Context.Response.Write(js.Serialize(liste));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getJeux(int id)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                Jeux je = new Jeux(id);
                Context.Response.Write(js.Serialize(je));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }
        }



        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void createJeux(String nom, int quantite, double prixUnitaire,
            int seuilQuantite, String emplacement, String image, String plateforme, String categorie)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                Jeux je = new Jeux(nom, quantite, prixUnitaire, seuilQuantite, emplacement, image, plateforme, categorie);
                je.enregistrer();
                Context.Response.Write(js.Serialize(je));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void deleteJeux(int id)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                Jeux je = new Jeux(id);
                je.supprimer();
                Context.Response.Write(js.Serialize("Opération réussie"));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void updateJeux(int id, String nom, int quantite, double prixUnitaire, int seuilQuantite, String emplacement, String image, String plateforme, String categorie)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                Jeux je = new Jeux(id);
                je.nom = nom;
                je.quantite = quantite;
                je.prixUnitaire = prixUnitaire;
                je.seuilQuantite = seuilQuantite;
                je.emplacement = emplacement;
                je.image = image;
                je.plateforme = plateforme;
                je.categorie = categorie;
                je.modifier();
                Context.Response.Write(js.Serialize(je));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }
        }

    }
}
