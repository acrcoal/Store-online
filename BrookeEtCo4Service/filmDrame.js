var listeProduit;
var panier = new Array();
const TAUX_TPS = 0.05;
const TAUX_TVQ = 0.09975;

function chargerZoneItem() {
	chargerPanier();

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
	xhr.open("POST", "http://localhost:56408/GestionStockProduit4.asmx/getFilmsDrame", false);
	xhr.send();


	var reponse = xhr.responseText;
	var objetJSON = JSON.parse(reponse);
	listeProduit = objetJSON;
	afficherListeProduits();

}




function afficherListeProduits() {
	listeProduit.forEach(function (item) {
		var nom = item.nom;
		var image = item.image;
		var prixUnitaire = item.prixUnitaire;
		var noeudDivItem = document.createElement("div");
		noeudDivItem.setAttribute("class", "item");

		var noeudImage = document.createElement("img");
		noeudImage.setAttribute("class", "imageItem");
		noeudImage.setAttribute("src", image);
		noeudDivItem.appendChild(noeudImage);
		noeudImage.addEventListener("click", function () {
			afficherDetail(item);
		});

		var noeudNom = document.createElement("div");
		noeudNom.setAttribute("class", "nom");
		noeudNom.appendChild(document.createTextNode(nom));
		noeudDivItem.appendChild(noeudNom);

		var noeudPrixUnitaire = document.createElement("div");
		noeudPrixUnitaire.setAttribute("class", "prix");
		noeudPrixUnitaire.appendChild(document.createTextNode(prixUnitaire));
		noeudDivItem.appendChild(noeudPrixUnitaire);

		var noeudBtnAjouter = document.createElement("div");
		noeudBtnAjouter.setAttribute("class", "ajouter");
		noeudBtnAjouter.appendChild(document.createTextNode("Ajouter"));
		noeudDivItem.appendChild(noeudBtnAjouter);
		noeudBtnAjouter.addEventListener("click", function () {
			var ligneCommande = { produit: item, quantite: "1" };
			ajouterItem(ligneCommande);
		});

		document.getElementById("zoneContenuItem").appendChild(noeudDivItem);
	});
}

function afficherDetail(unProduit) {
	var isbn = unProduit.isbn;
	var duree = unProduit.duree;
	var plateforme = unProduit.plateforme;
	document.querySelector("#zoneDetail").style.display = "block";
	document.querySelector("#uneImage").src = unProduit.image;
	document.querySelector("#uneNom").innerHTML = unProduit.nom;
	document.querySelector("#unPrixUnitaire").innerHTML = unProduit.prixUnitaire;
	document.querySelector("#unDetail").innerHTML = unProduit.duree;

	document.querySelector("#unAjout").addEventListener("click", function () {
		var qte = document.querySelector("#txtQuantite").value;
		var ligneCommande = { produit: unProduit, quantite: qte };
		ajouterItem(ligneCommande);
		document.querySelector("#zoneDetail").style.display = "none";
		document.querySelector("#txtQuantite").value = "1";
	});
}

function fermerDialogue() {
	document.querySelector("#zoneDetail").style.display = "none";
}

function ajouterItem(ligneCommande) {
	panier.push(ligneCommande);
	enregistrerPanier(); //ajoute le panier dans un cookie
	var quantite = ligneCommande.quantite;
	var nbItemPanier = parseInt(document.getElementById("idItem").innerHTML);
	nbItemPanier += parseInt(quantite);
	document.getElementById("idItem").innerHTML = nbItemPanier;
}

function enregistrerPanier() {
	if (typeof (localStorage) == "undefined") {
		alert("votre navigateur ne supporte pas les cookies");
		return;
	}
	localStorage.setItem("panier", JSON.stringify(panier));
}

function afficheFacture() {
	document.getElementById("zoneContenuItem").style.display = "none";
	document.getElementById("zoneContenuFacture").style.display = "block";
	document.getElementById("zoneContenuFacture").style.height = "85%";

	var sousTotal = 0;
	var noeudTBody = document.querySelector("#corpsTableau");
	panier.forEach(function (ligneCommande, index) {
		var nomDeProduit = ligneCommande.produit.nom;
		var quantite = ligneCommande.quantite;
		var prix = ligneCommande.produit.prixUnitaire;
		sousTotal += parseInt(quantite) * parseFloat(prix);

		var noeudTr = document.createElement("tr");
		var noeudTd1 = document.createElement("td");
		var contenuTd1 = document.createTextNode(nomDeProduit);
		noeudTd1.appendChild(contenuTd1);
		noeudTr.appendChild(noeudTd1);

		var noeudTd2 = document.createElement("td");
		var noeudTd21 = document.createElement("input");
		noeudTd21.setAttribute("type", "text");
		noeudTd21.setAttribute("value", quantite);
		noeudTd21.addEventListener("change", function () {
			var nouvelleQte = this.value;
			panier[index].quantite = nouvelleQte;
			enregistrerPanier();
			calculerFacture();
		});
		noeudTd2.appendChild(noeudTd21);
		noeudTr.appendChild(noeudTd2);

		var noeudTd3 = document.createElement("td");
		var contenuTd3 = document.createTextNode(prix);
		noeudTd3.appendChild(contenuTd3);
		noeudTr.appendChild(noeudTd3);

		noeudTBody.appendChild(noeudTr);
	});
	var totalTPS = sousTotal * TAUX_TPS;
	var totalTVQ = sousTotal * TAUX_TVQ;
	var total = sousTotal + totalTPS + totalTVQ;
	document.querySelector("#idSousTotal").innerHTML = sousTotal.toFixed(2) + " $";
	document.querySelector("#idTPS").innerHTML = totalTPS.toFixed(2) + " $";
	document.querySelector("#idTVQ").innerHTML = totalTVQ.toFixed(2) + " $";
	document.querySelector("#idTotal").innerHTML = total.toFixed(2) + " $";
}

function calculerFacture() {
	var sousTotal = 0;
	var totalQte = 0;
	panier.forEach(function (ligneCommande) {
		/*
		un petit rappel pour la ligneCommande
		ligneCommande = {produit : pr, quantite : qte};
		*/
		var quantite = ligneCommande.quantite;
		var prix = ligneCommande.produit.prixUnitaire;
		sousTotal += parseInt(quantite) * parseFloat(prix);
		totalQte += parseInt(quantite);
	});
	var totalTPS = sousTotal * TAUX_TPS;
	var totalTVQ = sousTotal * TAUX_TVQ;
	var total = sousTotal + totalTPS + totalTVQ;
	document.querySelector("#idSousTotal").innerHTML = sousTotal.toFixed(2) + " $";
	document.querySelector("#idTPS").innerHTML = totalTPS.toFixed(2) + " $";
	document.querySelector("#idTVQ").innerHTML = totalTVQ.toFixed(2) + " $";
	document.querySelector("#idTotal").innerHTML = total.toFixed(2) + " $";

	//Modification du panier
	document.getElementById("idItem").innerHTML = totalQte;
}

function chargerPanier() {
	if (typeof (localStorage) == "undefined") {
		alert("votre navegateur ne supporte pas les cookies");
		return;
	}
	if (!localStorage.panier) {
		return;
	}
	panier = JSON.parse(localStorage.getItem("panier"));
	var totalQte = 0;
	panier.forEach(function (ligneCommande) {
		var quantite = ligneCommande.quantite;

		totalQte += parseInt(quantite);
	});
	var nbItemPanier = parseInt(document.getElementById("idItem").innerHTML);
	nbItemPanier += totalQte;
	document.getElementById("idItem").innerHTML = nbItemPanier;
}