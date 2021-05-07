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
    /// Summary description for GestionClient
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class GestionClient : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getClients()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                List<Client> liste = Client.getListeClient();
                Context.Response.Write(js.Serialize(liste));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getClient(String courriel)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                Client cl = new Client(courriel);
                Context.Response.Write(js.Serialize(cl));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void createClient(String nom, String prenom, String typeUser, String courriel, String pass)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                Client cl = new Client(nom, prenom, typeUser, courriel, pass);
                cl.enregistrer();
                Context.Response.Write(js.Serialize(cl));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void deleteClient(String courriel)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                Client cl = new Client(courriel);
                cl.supprimer();
                Context.Response.Write(js.Serialize("Opération réussie"));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void updateClient(String nom, String prenom, String typeUser, String courriel, String pass)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                Client cl = new Client(courriel);
                cl.nom = nom;
                cl.prenom = prenom;
                cl.typeUser = typeUser;
                cl.courriel = courriel;
                cl.pass = pass;
                cl.modifier();
                Context.Response.Write(js.Serialize(cl));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getLogin(String courriel, String pass)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                Client cl = Client.Login(courriel, pass);                
                Context.Response.Write(js.Serialize(cl));
            }
            catch (Exception ex)
            {
                Context.Response.Write(js.Serialize(ex.ToString()));
            }
        }
    }
}
