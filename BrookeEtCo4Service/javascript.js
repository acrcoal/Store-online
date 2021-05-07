const TPS = 0.05;
const TVQ = 0.0975;

var dateExpiration = new Date();
dateExpiration.setTime(dateExpiration.getTime() + 5 * 3600 * 2000);
var currentIndex;
var livresinformatique;       //books
var livreslitterature;
var livresgeographique;
var filmfiction; //movies
var jeux; //games
var panier = new Array();

function setCookie(name, value, expires, path, domain, secure) {
    document.cookie = name + "=" + escape(value) +
        ((expires == undefined) ? "" : ("; expires=" + expires.toGMTString())) +
        ((path == undefined) ? "" : ("; path=" + path)) +
        ((domain == undefined) ? "" : ("; domain=" + domain)) +
        ((secure == true) ? ";secure" : "");
}
function getCookie(name) {
    if (document.cookie.length == 0) {
        return null;
    }
    var regCookies = new RegExp("(;)", "g");
    var cookies = document.cookie.split(regCookies);
    for (var i = 0; i < cookies.length; i++) {
        var regInfo = new RegExp("=", "g");
        var infos = cookies[i].split(regInfo);
        if (infos[0] == name) {
            return unescape(infos[1]);
        }
    }
}
function deleteCookie(name) {
    document.cookie = name + '=; expires=Sat, 01 Jan 2022 00:00:01 GMT;';
    window.location.href = "index.html";
}
var currentIndex;

function ajax(url) {
    var xhr;
    try {
        xhr = new ActiveXObject("Msxml2.XMLHTTP");
    }
    catch (e) {
        try {
            xhr = new ActiveXObject("Microsoft.XMLHTTP");
        }
        catch (e1) {
            try {
                xhr = new XMLHttpRequest();
            }
            catch (e2) {
                xhr = false;
            }
        }
    }
    xhr.open("POST", url, false);   
    xhr.send();

    var reponse = xhr.responseText;
    var objetJSON = JSON.parse(reponse);
    return objetJSON;
}

function getAllProducts() {
    var url = "http://localhost:56408/GestionStockProduit4.asmx/getProducts";
    products = ajax(url);
}

function getLivresInformatique() {
    var url = "http://localhost:56408/GestionStockProduit4.asmx/getLivresInformatique";               
    livresInformatique = ajax(url);
}

function getLivresLitterature() {
    var url = "http://localhost:56408/GestionStockProduit4.asmx/getLivresLitterature";
    livresLitterature = ajax(url);
}

function getLivresGeographique() {
    var url = "http://localhost:56408/GestionStockProduit4.asmx/getLivresGeographique";
    livresGeographique = ajax(url);
}

function main() {
    var valeurCookie = getCookie("user");
    if (valeurCookie == null) {
        document.getElementById("login").style.display = "grid";
    }
    else {
        load();
    }
}

function connect() {
    let user = document.getElementsByTagName("input")[0].value;
    let pass = document.getElementsByTagName("input")[1].value;
    if (user == "user" && pass == "password") {
        setCookie(user, pass, dateExpiration);
        load();
    }
    else {
        document.getElementById("exception").innerHTML = "Username or Password incorrect!";
    }
}

/*function load() {
    getAllProducts(); //  variable products est remplie
    carrousel();
    initializeMap();

    products.forEach(function (element, index) {
        var produit = document.createElement("div");  // creer la division pour detail produit <div>
        produit.setAttribute("class", "product");  // mettre class css 
        var image = document.createElement("img"); // creer un element image a partir de la division
        image.setAttribute("src", "./images/" + (element.Id) + ".jpg"); // affecter src à élément image
        image.addEventListener("click", function () { // ajouter evenement click qui appelle fonction detail avec ses parametres
            productDetail(index + 1);
        })
        var p = document.createElement("p");    // creer element texte <p>
        var t = document.createTextNode(element.Name);
        //var up = "<p>prix</p>"
        var p2 = document.createElement("p");
        var up = document.createTextNode("$ " + element.UnitPrice.toFixed(2));
        p.appendChild(t);
        p2.appendChild(up);
        var bouton = document.createElement("button"); // creer element bouton <button>
        bouton.innerHTML = "Ajouter au panier";
        bouton.addEventListener("click", function () {  // ajouter evenement click au bouton
            addItem((index + 1), 1)
        });
        // ajouter ces elements dans division detail produit
        produit.appendChild(image);
        produit.appendChild(p);
        produit.appendChild(p2);
        //produit.appendChild(up);
        produit.appendChild(bouton);

        document.getElementById("content").appendChild(produit); // ajouter la div produit sur la zone de la page principale
    });


    document.querySelector(".loginTitle").style.display = "none";
    document.getElementById("login").style.display = "none";
    document.getElementById("header").style.display = "grid";
    document.getElementById("carrousel").style.display = "grid";
    document.getElementById("content").style.display = "grid";
    document.getElementById("footer").style.display = "grid";
}*/

function livresInformatique() {
    getLivresInformatique();
    // alert("Books Loaded");
    carrousel();
    initializeMap();

    document.querySelectorAll('.product').forEach(el => el.remove()); // supprimer tous les elements existant

    livresinformatique.forEach(function (element, index) {
        var produit = document.createElement("div");  // creer la division pour detail produit <div>
        produit.setAttribute("class", "items");  // mettre class css //antes "product"
        var image = document.createElement("image"); // creer un element image a partir de la division
        image.setAttribute("src", (element.image)); // affecter src à élément image // image.setAttribute("src", "./images/" + (element.Id) + ".jpg");
        image.addEventListener("click", function () { // ajouter evenement click qui appelle fonction detail avec ses parametres
            productDetail(index + 1);
        })

        var p = document.createElement("p");    // creer element texte <p>
        var p2 = document.createElement("p"); // 1.creer element text pour prix
        var up = document.createTextNode("$ " + element.prix.toFixed(2)); //2.creer textNode pour prix unitaire //var up = document.createTextNode("$ " + element.UnitPrice.toFixed(2));
        var t = document.createTextNode(element.nom); //element.Name

        p2.appendChild(up); // 3.attacher enfant Prix Unitaire
        p.appendChild(t);
        var bouton = document.createElement("button"); // creer element bouton <button>
        bouton.innerHTML = "Ajouter au panier";
        bouton.addEventListener("click", function () {  // ajouter evenement click au bouton
            //alert("");
            addItem((index + 1), 1)

        });

        // ajouter ces elements dans division detail produit
        produit.appendChild(image);
        produit.appendChild(p);
        produit.appendChild(p2); // 4.append child text prixUnitaire
        produit.appendChild(bouton);


        document.getElementById("zoneContenuItems").appendChild(items); // ajouter la div produit sur la zone de la page principale // document.getElementById("content").appendChild(produit);
    });


    document.getElementById("menugauche").style.display = "none";
    document.getElementById("affichajePanier").style.display = "none";
    //document.getElementById("main").style.display = "none";
    document.getElementById("carrousel2").style.display = "none";
    document.getElementById("mapZone").style.display = "none";
    document.getElementById("zonepresentitems").style.display = "grid";
    document.getElementById("zoneDetailsLivre").style.display = "none";
    /*document.querySelector(".loginTitle").style.display = "none";
    document.getElementById("login").style.display = "none";
    document.getElementById("header").style.display = "grid";
    document.getElementById("carrousel").style.display = "grid";
    document.getElementById("content").style.display = "grid";
    document.getElementById("footer").style.display = "grid";*/

}

/*function loadMovies() {
    getMovies();
    // alert("Movies Loaded");
    carrousel();
    initializeMap();

    document.querySelectorAll('.product').forEach(el => el.remove()); // supprimer tous les elements existant
    //document.getElementById("content").removeAll();
    movies.forEach(function (element, index) {
        var produit = document.createElement("div");  // creer la division pour detail produit <div>
        produit.setAttribute("class", "product");  // mettre class css 
        var image = document.createElement("img"); // creer un element image a partir de la division
        image.setAttribute("src", "./images/" + (element.Id) + ".jpg"); // affecter src à élément image
        image.addEventListener("click", function () { // ajouter evenement click qui appelle fonction detail avec ses parametres
            productDetail(index + 1);
        })
        var p = document.createElement("p");    // creer element texte <p>
        var t = document.createTextNode(element.Name);
        var p2 = document.createElement("p"); // 1.creer element text pour prix
        var up = document.createTextNode("$ " + element.UnitPrice.toFixed(2)); //2.creer textNode pour prix unitaire
        p2.appendChild(up); // 3.attacher enfant Prix Unitaire
        p.appendChild(t);
        var bouton = document.createElement("button"); // creer element bouton <button>
        bouton.innerHTML = "Ajouter au panier";
        bouton.addEventListener("click", function () {  // ajouter evenement click au bouton
            addItem((index + 1), 1)
        });
        // ajouter ces elements dans division detail produit
        produit.appendChild(image);
        produit.appendChild(p);
        produit.appendChild(p2); // 4.append child text prixUnitaire
        produit.appendChild(bouton);

        document.getElementById("content").appendChild(produit); // ajouter la div produit sur la zone de la page principale
    });


    document.querySelector(".loginTitle").style.display = "none";
    document.getElementById("login").style.display = "none";
    document.getElementById("header").style.display = "grid";
    document.getElementById("carrousel").style.display = "grid";
    document.getElementById("content").style.display = "grid";
    document.getElementById("footer").style.display = "grid";
    //alert("end of function loadmovies");
}

function loadGames() {
    getGames();
    //alert("Games Loaded");
    carrousel();
    initializeMap();

    document.querySelectorAll('.product').forEach(el => el.remove()); // supprimer tous les elements existant

    games.forEach(function (element, index) {
        var produit = document.createElement("div");  // creer la division pour detail produit <div>
        produit.setAttribute("class", "product");  // mettre class css 
        var image = document.createElement("img"); // creer un element image a partir de la division
        image.setAttribute("src", "./images/" + (element.Id) + ".jpg"); // affecter src à élément image (element.Id)
        image.addEventListener("click", function () { // ajouter evenement click qui appelle fonction detail avec ses parametres
            productDetail(index + 1);
        })
        var p = document.createElement("p");    // creer element texte <p>
        var t = document.createTextNode(element.Name);
        var p2 = document.createElement("p"); // 1.creer element text pour prix
        var up = document.createTextNode("$ " + element.UnitPrice.toFixed(2)); //2.creer textNode pour prix unitaire
        p.appendChild(t);
        p2.appendChild(up); // 3.attacher enfant Prix Unitaire
        var bouton = document.createElement("button"); // creer element bouton <button>
        bouton.innerHTML = "Ajouter au panier";
        bouton.addEventListener("click", function () {  // ajouter evenement click au bouton
            addItem((index + 1), 1)
        });
        // ajouter ces elements dans division detail produit
        produit.appendChild(image);
        produit.appendChild(p);
        produit.appendChild(p2); // 4.append child text prixUnitaire
        produit.appendChild(bouton);

        document.getElementById("content").appendChild(produit); // ajouter la div produit sur la zone de la page principale
    });


    document.querySelector(".loginTitle").style.display = "none";
    document.getElementById("login").style.display = "none";
    document.getElementById("header").style.display = "grid";
    document.getElementById("carrousel").style.display = "grid";
    document.getElementById("content").style.display = "grid";
    document.getElementById("footer").style.display = "grid";
}*/


function carrousel() {
    var listeImage = ["image1.jpg", "image2.jpg", "image3.jpg", "image4.jpg"];
    var i = 1;
    setInterval(function () {
        document.getElementById("monImage").src = listeImage[i++]; //"./images/" + 
        if (i == 4) {
            i = 0;
        }
        //document.getElementById("msg").innerHTML = i;
    }, 5000);
}
function carrousel2() {
    var listeImage = ["image1.jpg", "image2.jpg", "image3.jpg", "image4.jpg"];
    var i = 1;
    setInterval(function () {
        document.getElementById("monImage").src = listeImage[i++];
        if (i == 4) {
            i = 0;
        }
        //document.getElementById("msg").innerHTML = i;
    }, 5000);
}
function main() {
    let user = document.getElementsByTagName("input")[0].value;
    let pass = document.getElementsByTagName("input")[1].value;
    if (user == "user" && pass == "password") {
        window.open("mainpage.html", "_self");
        sessionStorage.setItem("status", "logged");
    }
    else {
        document.getElementById("exception").innerHTML = "Username or Password incorrect!";
    }
}
function itemsList() {
    document.getElementById("menugauche").style.display = "none";
    document.getElementById("affichajePanier").style.display = "none";
    document.getElementById("main").style.display = "none";
    document.getElementById("carrousel2").style.display = "none";
    document.getElementById("mapZone").style.display = "none";
    document.getElementById("zonepresentitems").style.display = "grid";
    document.getElementById("zoneDetailsLivre").style.display = "none";
}
function mapDisplay() {
    document.getElementById("main").style.display = "none";
    document.getElementById("carrousel2").style.display = "none";
    document.getElementById("zonepresentitems").style.display = "none"
    document.getElementById("zoneDetailsLivre").style.display = "none";
    document.getElementById("affichajePanier").style.display = "none";
    document.getElementById("mapZone").style.display = "grid";
    document.getElementById("map").style.display = "grid";
    initializeMap();
}
var pos;
function initializeMap() {
    var directionsDisplay = new google.maps.DirectionsRenderer;
    var directionsService = new google.maps.DirectionsService;

    if (!navigator.geolocation) {
        alert("Votre navigateur n'est pas active pour ca")
    }
    var centreGoogleMap = new google.maps.LatLng(45.5387428, -73.8387033);
    var optionsGoogleMap = {
        zoom: 10,
        center: centreGoogleMap,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var maCarte = new google.maps.Map(document.getElementById("map"), optionsGoogleMap);

    // first store
    var marker1 = new google.maps.Marker({
        position: { lat: 45.508922, lng: -73.81990789999999 },
        map: maCarte,
        title: "Brooke et Co / store 1"
    })
    var commentaireGG = "<div><h1>Vous etes ici</h1>Votre adresse</div>";
    var fenetre1 = new google.maps.InfoWindow({
        content: commentaireGG
    });
    google.maps.event.addListener(marker1, "click", function () {
        fenetre1.open(maCarte, marker1);
    })
    // seconde store
    var marker2 = new google.maps.Marker({
        position: { lat: 45.5708744, lng: -73.791201 },
        map: maCarte,
        title: "Brooke et Co / store 2"
    })

    var commentaireGG = "<div>";
    commentaireGG += "<h1>Brooke et Co</h1>";
    commentaireGG += "Adresse: 3035, boulevard Le Carrefour,Laval,H7T 1C8";
    commentaireGG += "</div>";
    var fenetre2 = new google.maps.InfoWindow({
        content: commentaireGG
    });
    google.maps.event.addListener(marker2, "click", function () {
        fenetre2.open(maCarte, marker2);
    });

    var infoWindow = new google.maps.InfoWindow;
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            pos = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };
            infoWindow.setPosition(pos);
            infoWindow.setContent('Vous etes ici');
            infoWindow.open(maCarte);
            maCarte.setCenter(pos);
        }, function () {
            handleLocationError(true, infoWindow, maCarte.getCenter());
        });
    } else {
        // Browser doesn't support Geolocation
        handleLocationError(false, infoWindow, maCarte.getCenter());
    }

    var onChangeHandler = function () {
        calcualteAndDisplayRoute(directionsService, directionsDisplay);
    };
    document.getElementById("calculChemin").addEventListener("click", onChangeHandler);
}

function handleLocationError(browserHasGeolocation, infoWindow, pos) {
    infoWindow.setPosition(pos);
    infoWindow.setContent(browserHasGeolocation ?
        'Error: The Geolocation service failed.' :
        'Error: Your browser doesn\'t support geolocation.');
    infoWindow.open(macarte);
}

function calcualteAndDisplayRoute(directionsService, directionsDisplay) {
    directionsService.route({
        origin: { lat: 45.508922, lng: -73.81990789999999 },
        destination: { lat: 45.5708744, lng: -73.7540468 },
        travelMode: 'DRIVING'
    }, function (response, status) {
        if (status === 'OK') {
            directionsDisplay.setDirections(response);
        } else {
            window.alert('Directions request failed due to ' + status);
        }
    });
}
function DetailsLivre(index) {
    document.getElementById("zonepresentitems").style.display = "none";
    document.getElementById("zoneDetailsLivre").style.display = "block";
    document.getElementById("mapZone").style.display = "none";
    document.getElementById("affichajePanier").style.display = "none";
    document.getElementById("imageDetail").src = "image" + index + ".jpg";
    document.getElementById("description").innerHTML = livre[index - 1].description;
    document.getElementById("autor").innerHTML = livre[index - 1].autor;
    document.getElementById("prix").innerHTML = "Notre Prix:" + livre[index - 1].prix + " $";
    document.getElementById("details").innerHTML = livre[index - 1].details;

    currentIndex = index - 1;
}
function ajouterItem(index, quantite) {
    livre[index - 1].quantite += quantite;

    var idItemV = parseInt(document.getElementById("idItem").innerHTML);
    var itemCount = idItemV + 1;
    document.getElementById("idItem").innerHTML = itemCount;
    // alert("Vous venez d'ajouter un livre <<" + livre[index - 1].description + ">>");
}
function ajouterItems() {
    let indexSelected = document.getElementById("quantitePanier").value;
    let quantite = parseInt(document.getElementById("quantitePanier").value);
    livre[currentIndex].quantite += quantite;
    //alert("Vous venez d'ajouter " + quantite +  " livre(s) <<" + livre[currentIndex].description + ">>");
}
var livre = [
    {
        "image": "image1.jpg",
        "description": "Structured Programming with C++",
        "autor": "Kjell Bäckman",
        "prix": 29.32,
        "quantite": 0,
        "details": "Structured Programming with C++ is intended as course material for the course Structured Programming with C/C++ at university level."
    },
    {
        "image": "image2.jpg",
        "description": "An Introduction to Adobe Photoshop",
        "autor": "Steve Bark",
        "prix": 35.32,
        "quantite": 0,
        "details": "This is the first in a series of books on Adobe Photoshop. Together, they will give the reader a good foundation in some of the major features of this ground breaking and industry changing program."
    },
    {
        "image": "image3.jpg",
        "description": "Database Design and Implementation",
        "autor": "Howard Gould",
        "prix": 23.99,
        "quantite": 0,
        "details": "This book explains the essential relational database design modelling techniques and shows how SQL can be used to implement a database. There are numerous practical exercises with feedback."
    },
    {
        "image": "image4.jpg",
        "description": "Excel 2010 Introduction: Part I",
        "autor": "Stephen Moffat",
        "prix": 25.99,
        "quantite": 0,
        "details": "Excel 2010 is a powerful spreadsheet application that allows users to produce tables containing calculations and graphs."
    },
    {
        "image": "image5.jpg",
        "description": "Java Data Structures and Algorithms",
        "autor": "Christopher Fox",
        "prix": 20.79,
        "quantite": 0,
        "details": "Standard introduction to data structures and algorithms using the Java programming language covering stacks, queues, lists, trees, sets, maps, graphs, hashing, searching, and sorting."
    },
    {
        "image": "image6.jpg",
        "description": "Understanding Computer Simulation",
        "autor": "Roger McHaney",
        "prix": 19.69,
        "quantite": 0,
        "details": "This book describes computer simulation concepts then provides basic details about using discrete-event computer simulation for decision making."
    },
    {
        "image": "image7.jpg",
        "description": "Object Oriented Programming using C#",
        "autor": "Simon Kendal",
        "prix": 29.69,
        "quantite": 0,
        "details": "This book will explain the Object Oriented approach to programming and through the use of small exercises, for which feedback is provided, develop some practical skills as well."
    },
    {
        "image": "image8.jpg",
        "description": "Adobe Photoshop for Intermediate Users",
        "autor": "Steve Bark",
        "prix": 18.89,
        "quantite": 0,
        "details": "Improve your skills in Photoshop with this guide for intermediate users."
    },
    {
        "image": "image9.jpg",
        "description": "Excel 2016 Advanced",
        "autor": "Shelley Fishel",
        "prix": 23.56,
        "quantite": 0,
        "details": "This user guide will introduce you to some of Excel's more complex functionality. Specifically when analysing data."
    },
    {
        "image": "image10.jpg",
        "description": "Systems Analysis and Design",
        "autor": "Howard Gould",
        "prix": 23.56,
        "quantite": 0,
        "details": "This book concisely introduces systems analysis and design principles and techniques which are used for building information systems. Numerous practical exercises with feedback are included."
    },
    {
        "image": "image11.jpg",
        "description": "Introduction to E-Commerce",
        "autor": "Prof. Dr. Martin Kütz",
        "prix": 26.75,
        "quantite": 0,
        "details": "From technologies to processes, from B2C to B2B, from payment to security, the book investigates E-Commerce integratedly – for readers with an economic as well as with a computer science background. "
    },
    {
        "image": "image12.jpg",
        "description": "Java 1: Basic syntax and semantics",
        "autor": "Poul Klausen",
        "prix": 27.65,
        "quantite": 0,
        "details": "This book is the first in a series of books on software development in Java."
    },
    {
        "image": "image13.jpg",
        "description": "Object Oriented Programming using Java",
        "autor": "Simon Kendal",
        "prix": 23.33,
        "quantite": 0,
        "details": "This book will explain the Object Oriented approach to programming and through the use of small exercises, for which feedback is provided, develop some practical skills as well."
    },
    {
        "image": "image14.jpg",
        "description": "C# 1",
        "autor": "Poul Klausen",
        "prix": 21.72,
        "quantite": 0,
        "details": "The book is a practical basic introduction to programming and C# that introduces basic principles of object-oriented programming."
    },
    {
        "image": "image15.jpg",
        "description": "C Programming in Linux",
        "autor": "David Haskins",
        "prix": 24.43,
        "quantite": 0,
        "details": "Using a series of web development examples, this book 'C Programming in Linux' will give you an interesting glimpse into a powerful lower-level world."
    },
    {
        "image": "image16.jpg",
        "description": "Excel 2016 Introduction",
        "autor": "Stephen Moffat",
        "prix": 29.32,
        "quantite": 0,
        "details": "This manual should be used as a point of reference following attendance of the introductory level Excel 2016 training course."
    },
    {
        "image": "image17.jpg",
        "description": "Introduction to Web Services with Java",
        "autor": "Kiet T. Tran, PhD",
        "prix": 24.92,
        "quantite": 0,
        "details": "This book leads you through a journey of developing your first web service application to more complex multitier enterprise application."
    },
    {
        "image": "image18.jpg",
        "description": "Microsoft Office Excel 2007",
        "autor": "Torben Lage Frandsen",
        "prix": 30.89,
        "quantite": 0,
        "details": "Nothing is difficult once you have learned it. That applies to Microsoft Office Excel 2007 as well, and once you have learned it, you will be able to do things you never dreamed of!"
    },
    {
        "image": "image19.jpg",
        "description": "Philosophy of Artificial Intelligence",
        "autor": "David Cycleback",
        "prix": 26.74,
        "quantite": 0,
        "details": "This book is a concise introduction to key philosophical questions in artificial intelligence that have long been debated by many of the great minds in the field."
    },
    {
        "image": "image20.jpg",
        "description": "iWork - Numbers",
        "autor": "Mark Wood",
        "prix": 21.99,
        "quantite": 0,
        "details": "We all need to use productivity software for word processing, to reconcile budgets, or to make presentations."
    }

];
function commander() {
    document.getElementById("main").style.display = "none";
    document.getElementById("carrousel2").style.display = "none";
    document.getElementById("zonepresentitems").style.display = "none"
    document.getElementById("zoneDetailsLivre").style.display = "none";
    document.getElementById("affichajePanier").style.display = "none";
    document.getElementById("mapZone").style.display = "none";
    document.getElementById("affichajePanier").style.display = "flex";


    var sumOrder = 0;
    document.getElementById("contenuPanier").innerHTML = "";
    var j = 0;
    for (let i = 0; i < livre.length; i++) {
        if (livre[i].quantite != 0) {
            sumOrder += livre[i].quantite * livre[i].prix;
            let divItem = '<div class="itemAjoute"> <div class="itemImg"> <img class="imagePanier" src=""><button class="delete">Supprimer</button> </div><div class="itemContent"> <div class="titreLivre"></div> <div class="auteurLivre"></div><div></div></div><div class="quantitePanier"></div><div class="prixLivre"></div></div>';
            document.getElementById("contenuPanier").innerHTML += divItem;
            document.getElementsByClassName("delete")[j].setAttribute('id', i);
            document.getElementsByClassName("delete")[j].setAttribute('onclick', "deleteItem(this.id);");
            document.getElementsByClassName("imagePanier")[j].src = "image" + (i + 1) + ".jpg";
            document.getElementsByClassName("titreLivre")[j].innerHTML = livre[i].description;
            document.getElementsByClassName("auteurLivre")[j].innerHTML = livre[i].autor;
            document.getElementsByClassName("quantitePanier")[j].innerHTML = livre[i].quantite;
            document.getElementsByClassName("prixLivre")[j].innerHTML = livre[i].prix.toFixed(2) + " $";
            j++;
        }
    }
    document.getElementById("PrixTotal").innerHTML = sumOrder.toFixed(2) + " $" + '\n';
    document.getElementById("totalTVQ").innerHTML = (sumOrder * TVQ).toFixed(2) + " $" + '\n';
    document.getElementById("totalTPS").innerHTML = (sumOrder * TPS).toFixed(2) + " $" + '\n';
    document.getElementById("TotalPayer").innerHTML = ((sumOrder * TVQ) + (sumOrder * TPS) + sumOrder).toFixed(2) + " $";
}

function deleteItem(index) {
    livre[index].quantite = 0;
    //alert("Vous venez de supprimer l'article <<" + livre[index].description + ">>");
    commander();
}

