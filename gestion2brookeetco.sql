-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 07, 2021 at 06:48 PM
-- Server version: 8.0.18
-- PHP Version: 7.4.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `gestion2brookeetco`
--

-- --------------------------------------------------------

--
-- Table structure for table `achat`
--

CREATE TABLE `achat` (
  `id` int(11) NOT NULL,
  `idProduit` int(11) DEFAULT NULL,
  `idFournisseur` int(11) DEFAULT NULL,
  `quantite` int(11) DEFAULT NULL,
  `prixUnitaire` decimal(10,2) DEFAULT NULL,
  `dateAchat` date DEFAULT NULL,
  `etat` varchar(20) DEFAULT NULL
) ;

-- --------------------------------------------------------

--
-- Table structure for table `client`
--

CREATE TABLE `client` (
  `id` int(11) NOT NULL,
  `nom` varchar(50) DEFAULT NULL,
  `prenom` varchar(50) DEFAULT NULL,
  `typeUser` varchar(20) DEFAULT NULL,
  `courriel` varchar(30) DEFAULT NULL,
  `pass` varchar(20) DEFAULT NULL
) ;

--
-- Dumping data for table `client`
--

INSERT INTO `client` (`id`, `nom`, `prenom`, `typeUser`, `courriel`, `pass`) VALUES
(2, 'Omar', 'Aguilar', 'Application', 'omar.aguilar@hotmail.com', 'oaguilar1'),
(3, 'Cindy', 'Aguilar', 'Application', 'cindy.aguilar@hotmail.com', 'caguilar'),
(5, 'Gabriel', 'Aguilar', 'Application', 'gabriel.aguilar@hotmail.com', 'gaguilar'),
(6, 'Ramirez', 'David', 'Application', 'david.ramirez@hotmail.com', 'dramirez'),
(10, 'Tulba', 'Claudiu', 'Application', 'claudiu.tulba@hotmail.com', 'ctulba1'),
(11, 'Fostine', 'Kerlyne', 'Application', 'k.f@hotmail.com', 'kf');

-- --------------------------------------------------------

--
-- Table structure for table `commande`
--

CREATE TABLE `commande` (
  `numero` varchar(20) NOT NULL,
  `dateCommande` date DEFAULT NULL,
  `dateLivraisonPrevue` date DEFAULT NULL,
  `etat` varchar(30) DEFAULT NULL,
  `idClient` int(11) DEFAULT NULL,
  `idVendeur` int(11) DEFAULT NULL
) ;

-- --------------------------------------------------------

--
-- Table structure for table `employe`
--

CREATE TABLE `employe` (
  `id` int(11) NOT NULL,
  `nom` varchar(30) DEFAULT NULL,
  `prenom` varchar(30) DEFAULT NULL,
  `poste` varchar(30) DEFAULT NULL,
  `userName` varchar(30) DEFAULT NULL,
  `password` varchar(30) DEFAULT NULL
) ;

-- --------------------------------------------------------

--
-- Table structure for table `film`
--

CREATE TABLE `film` (
  `idProduit` int(10) NOT NULL,
  `duree` varchar(20) DEFAULT NULL,
  `categorie` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `film`
--

INSERT INTO `film` (`idProduit`, `duree`, `categorie`) VALUES
(5, '1h 47m', 'Fiction'),
(6, '1h 56m', 'Fiction'),
(7, '1h 46m', 'Fiction'),
(8, '1h 54m', 'Fiction'),
(58, '2h 7m', 'Drame'),
(59, '2h 8m', 'Drame'),
(60, '2h 5m', 'Drame'),
(61, '3h 15m', 'Drame'),
(62, '3h 11m', 'Comedie'),
(63, '2h 05m', 'Comedie'),
(64, '1h 41m', 'Comedie'),
(65, '1h 55m', 'Action'),
(66, '1h 28m', 'Comedie'),
(67, '42h 42m', 'Action'),
(68, '1h 33m', 'Action'),
(69, '1h 42m', 'Action');

-- --------------------------------------------------------

--
-- Table structure for table `furnisseur`
--

CREATE TABLE `furnisseur` (
  `id` int(11) NOT NULL,
  `nom` varchar(50) DEFAULT NULL,
  `adresse` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `jeux`
--

CREATE TABLE `jeux` (
  `idProduit` int(10) NOT NULL,
  `plateforme` varchar(30) DEFAULT NULL,
  `categorie` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `jeux`
--

INSERT INTO `jeux` (`idProduit`, `plateforme`, `categorie`) VALUES
(9, 'PS4', 'Playstation'),
(10, 'PS4', 'Playstation'),
(11, 'PS5', 'Playstation'),
(12, 'PS5', 'Playstation'),
(70, 'Xbox Series X', 'Xbox'),
(71, 'Xbox One', 'Xbox'),
(72, 'Xbox One', 'Xbox'),
(73, 'Xbox One', 'Xbox'),
(74, 'Nintendo Switch', 'Nintendo'),
(75, 'Nintendo Switch', 'Nintendo'),
(76, 'Nintendo Switch', 'Nintendo'),
(77, 'Nintendo Switch', 'Nintendo');

-- --------------------------------------------------------

--
-- Table structure for table `lignecommande`
--

CREATE TABLE `lignecommande` (
  `id` int(11) NOT NULL,
  `numeroCommande` varchar(20) DEFAULT NULL,
  `idProduit` int(10) DEFAULT NULL,
  `quantite` int(11) DEFAULT NULL,
  `prixVente` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Stand-in structure for view `listeclient`
-- (See below for the actual view)
--
CREATE TABLE `listeclient` (
`courriel` varchar(30)
,`id` int(11)
,`nom` varchar(50)
,`pass` varchar(20)
,`prenom` varchar(50)
,`typeUser` varchar(20)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `listefilm`
-- (See below for the actual view)
--
CREATE TABLE `listefilm` (
`categorie` varchar(30)
,`duree` varchar(20)
,`emplacement` varchar(20)
,`idProduit` int(10)
,`image` varchar(20)
,`nom` varchar(50)
,`prixUnitaire` decimal(10,2)
,`quantite` int(11)
,`quantiteSeuil` int(11)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `listefilmaction`
-- (See below for the actual view)
--
CREATE TABLE `listefilmaction` (
`categorie` varchar(30)
,`duree` varchar(20)
,`emplacement` varchar(20)
,`idProduit` int(10)
,`image` varchar(20)
,`nom` varchar(50)
,`prixUnitaire` decimal(10,2)
,`quantite` int(11)
,`quantiteSeuil` int(11)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `listefilmcomedie`
-- (See below for the actual view)
--
CREATE TABLE `listefilmcomedie` (
`categorie` varchar(30)
,`duree` varchar(20)
,`emplacement` varchar(20)
,`idProduit` int(10)
,`image` varchar(20)
,`nom` varchar(50)
,`prixUnitaire` decimal(10,2)
,`quantite` int(11)
,`quantiteSeuil` int(11)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `listefilmdrame`
-- (See below for the actual view)
--
CREATE TABLE `listefilmdrame` (
`categorie` varchar(30)
,`duree` varchar(20)
,`emplacement` varchar(20)
,`idProduit` int(10)
,`image` varchar(20)
,`nom` varchar(50)
,`prixUnitaire` decimal(10,2)
,`quantite` int(11)
,`quantiteSeuil` int(11)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `listefilmfiction`
-- (See below for the actual view)
--
CREATE TABLE `listefilmfiction` (
`categorie` varchar(30)
,`duree` varchar(20)
,`emplacement` varchar(20)
,`idProduit` int(10)
,`image` varchar(20)
,`nom` varchar(50)
,`prixUnitaire` decimal(10,2)
,`quantite` int(11)
,`quantiteSeuil` int(11)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `listejeux`
-- (See below for the actual view)
--
CREATE TABLE `listejeux` (
`categorie` varchar(30)
,`emplacement` varchar(20)
,`idProduit` int(10)
,`image` varchar(20)
,`nom` varchar(50)
,`plateforme` varchar(30)
,`prixUnitaire` decimal(10,2)
,`quantite` int(11)
,`quantiteSeuil` int(11)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `listejeuxnintendo`
-- (See below for the actual view)
--
CREATE TABLE `listejeuxnintendo` (
`categorie` varchar(30)
,`emplacement` varchar(20)
,`idProduit` int(10)
,`image` varchar(20)
,`nom` varchar(50)
,`plateforme` varchar(30)
,`prixUnitaire` decimal(10,2)
,`quantite` int(11)
,`quantiteSeuil` int(11)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `listejeuxplaystation`
-- (See below for the actual view)
--
CREATE TABLE `listejeuxplaystation` (
`categorie` varchar(30)
,`emplacement` varchar(20)
,`idProduit` int(10)
,`image` varchar(20)
,`nom` varchar(50)
,`plateforme` varchar(30)
,`prixUnitaire` decimal(10,2)
,`quantite` int(11)
,`quantiteSeuil` int(11)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `listejeuxxbox`
-- (See below for the actual view)
--
CREATE TABLE `listejeuxxbox` (
`categorie` varchar(30)
,`emplacement` varchar(20)
,`idProduit` int(10)
,`image` varchar(20)
,`nom` varchar(50)
,`plateforme` varchar(30)
,`prixUnitaire` decimal(10,2)
,`quantite` int(11)
,`quantiteSeuil` int(11)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `listelivre`
-- (See below for the actual view)
--
CREATE TABLE `listelivre` (
`auteur` varchar(50)
,`categorie` varchar(30)
,`emplacement` varchar(20)
,`idProduit` int(10)
,`image` varchar(20)
,`isbn` varchar(20)
,`nom` varchar(50)
,`prixUnitaire` decimal(10,2)
,`quantite` int(11)
,`quantiteSeuil` int(11)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `listelivregeographique`
-- (See below for the actual view)
--
CREATE TABLE `listelivregeographique` (
`auteur` varchar(50)
,`categorie` varchar(30)
,`emplacement` varchar(20)
,`idProduit` int(10)
,`image` varchar(20)
,`isbn` varchar(20)
,`nom` varchar(50)
,`prixUnitaire` decimal(10,2)
,`quantite` int(11)
,`quantiteSeuil` int(11)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `listelivreinformatique`
-- (See below for the actual view)
--
CREATE TABLE `listelivreinformatique` (
`auteur` varchar(50)
,`categorie` varchar(30)
,`emplacement` varchar(20)
,`idProduit` int(10)
,`image` varchar(20)
,`isbn` varchar(20)
,`nom` varchar(50)
,`prixUnitaire` decimal(10,2)
,`quantite` int(11)
,`quantiteSeuil` int(11)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `listelivrelitterature`
-- (See below for the actual view)
--
CREATE TABLE `listelivrelitterature` (
`auteur` varchar(50)
,`categorie` varchar(30)
,`emplacement` varchar(20)
,`idProduit` int(10)
,`image` varchar(20)
,`isbn` varchar(20)
,`nom` varchar(50)
,`prixUnitaire` decimal(10,2)
,`quantite` int(11)
,`quantiteSeuil` int(11)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `listeproduit`
-- (See below for the actual view)
--
CREATE TABLE `listeproduit` (
`auteur` varchar(50)
,`categorie` varchar(30)
,`duree` varchar(20)
,`emplacement` varchar(20)
,`id` int(11)
,`image` varchar(20)
,`isbn` varchar(20)
,`nom` varchar(50)
,`plateforme` varchar(30)
,`prixUnitaire` decimal(10,2)
,`quantite` int(11)
,`quantiteSeuil` int(11)
);

-- --------------------------------------------------------

--
-- Table structure for table `livre`
--

CREATE TABLE `livre` (
  `idProduit` int(10) NOT NULL,
  `isbn` varchar(20) DEFAULT NULL,
  `auteur` varchar(50) DEFAULT NULL,
  `categorie` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `livre`
--

INSERT INTO `livre` (`idProduit`, `isbn`, `auteur`, `categorie`) VALUES
(1, '1119149223', 'Jon Duckett', 'Informatique'),
(2, '1484233867', 'Bauke Scholtz, Arjan Tijms', 'Informatique'),
(3, '1118823877', 'Stephen R. Davis', 'Informatique'),
(25, '1943872368', 'Joel Murach', 'Informatique'),
(26, '289772241X', 'Valérie Plante', 'Litterature'),
(51, '2761950054', 'GUILLAUME Dulude', 'Litterature'),
(52, '2897589191', 'Pierre-Yves Mcsween', 'Litterature'),
(53, '2896153004', 'Patrick Senécal', 'Litterature'),
(54, '9781772184709', 'Zebra', 'Geographique'),
(55, '9781772184815', 'Zebra', 'Geographique'),
(56, '1426215649', 'National Geographic', 'Geographique'),
(57, '9781772184884', 'Zebra', 'Geographique');

-- --------------------------------------------------------

--
-- Table structure for table `produit`
--

CREATE TABLE `produit` (
  `id` int(10) NOT NULL,
  `nom` varchar(50) DEFAULT NULL,
  `quantite` int(11) DEFAULT NULL,
  `prixUnitaire` decimal(10,2) DEFAULT NULL,
  `quantiteSeuil` int(11) DEFAULT NULL,
  `emplacement` varchar(20) DEFAULT NULL,
  `image` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `produit`
--

INSERT INTO `produit` (`id`, `nom`, `quantite`, `prixUnitaire`, `quantiteSeuil`, `emplacement`, `image`) VALUES
(1, 'PHP & MySQL: Server-side Web Development', 100, '54.00', 30, 'E4-1111-3333', 'image1.jpg'),
(2, 'The Definitive Guide To Jsf In Java Ee 8', 80, '53.33', 30, 'E4-3456-0596', 'image2.jpg'),
(3, 'Beginning Programming with C++ For Dummies', 70, '35.99', 30, 'E4-3456-0598', 'image3.jpg'),
(5, 'Terminator DVD', 100, '10.09', 30, 'F1-3456-9977', 'image13.jpeg'),
(6, 'Passengers DVD', 100, '11.02', 30, 'F4-3556-9876', 'image14.jpeg'),
(7, 'Ghost in the Shell Blu-ray + DVD', 100, '15.87', 30, 'F2-3476-0080', 'image15.jpeg'),
(8, 'Annihilation (DVD)', 108, '9.96', 38, 'E4-3456-8888', 'image16.jpeg'),
(9, 'DOOM Eternal pour (PS4)', 100, '29.96', 30, 'J1-3456-4488', 'image29.jpg'),
(10, 'MediEvil Remastered pour (PS4)', 100, '19.96', 30, 'J1-1436-0293', 'image30.jpg'),
(11, 'Immortals Fenyx Rising pour (PS5)', 100, '49.96', 30, 'J1-2333-0701', 'image31.jpg'),
(12, 'Assassins Creed Valhalla pour (PS5)', 100, '50.00', 30, 'J1-0101-7765', 'image32.jpg'),
(22, 'Test', 88, '33.00', 24, 'ejemple', 'livre5.jpg'),
(23, 'Test', 88, '33.00', 24, 'E4-3456-1111', 'livre1.jpg'),
(24, 'Test', 88, '33.00', 24, 'E4-3456-3333', 'livre1.jpg'),
(25, 'Murach s MySQL', 100, '70.64', 30, 'A4-2098-0596', 'image4.jpg'),
(26, 'Simone Simoneau', 40, '24.95', 30, 'L2-4545-6767', 'image5.jpg'),
(51, 'JE SUIS UN CHERCHEUR DOR', 60, '36.95', 30, 'L1-2987-3465', 'image6.jpg'),
(52, 'Liberté 45', 45, '24.95', 30, 'L3-5678-9876', 'image7.jpg'),
(53, 'ALISS ADAPTATION BD', 13, '49.95', 30, 'L5-5577-9621', 'image8.jpg'),
(54, 'Calendrier mural Canada 2021', 67, '14.99', 20, 'G1-1234-4321', 'image9.jpg'),
(55, 'Des plus beaux endroits sur terre 2021', 35, '14.99', 30, 'G3-3232-1211', 'image10.jpg'),
(56, 'Destinations Of A Lifetime', 45, '40.00', 30, 'G2-2987-7765', 'image11.jpg'),
(57, 'National Geographic Scotland', 65, '14.99', 30, 'G7-4444-8888', 'image12.jpg'),
(58, 'Basic Instinct', 100, '9.99', 30, 'F1-3452-9971', 'image17.jpg'),
(59, 'The accountant (DVD)', 100, '10.95', 30, 'F1-3433-9973', 'image18.jpeg'),
(60, 'Shooter (DVD)', 100, '9.96', 30, 'F2-5453-9775', 'image19.jpeg'),
(61, 'Titanic (DVD)', 100, '18.75', 30, 'F3-3245-9876', 'image20.jpeg'),
(62, 'Dumb and dumber (DVD)', 100, '12.05', 30, 'F4-6753-0987', 'image21.jpeg'),
(63, 'Mrs. Doubtfire (DVD)', 100, '10.46', 30, 'F4-3456-0001', 'image23.jpeg'),
(64, 'IRRESISTIBLE (BLU-RAY/​DVD/​DIGITAL)', 100, '24.99', 30, 'F4-3421-1223', 'image24.jpeg'),
(65, 'Lock up (DVD)', 100, '12.14', 30, 'F5-5544-0989', 'image25.jpeg'),
(66, 'Mr. Beans Holiday DVD', 100, '12.83', 30, 'F4-3131-9993', 'image22.jpeg'),
(67, 'BREAKING BAD-COMPLETE SERIES (DVD)', 100, '195.98', 30, 'F5-0980-7690', 'image26.jpeg'),
(68, 'Taken (DVD)', 100, '9.65', 30, 'F5-2000-0119', 'image27.jpeg'),
(69, 'John Wick (DVD)', 100, '15.36', 30, 'F5-8822-5577', 'image28.jpeg'),
(70, 'Gears Tactics (Xbox Series X)', 100, '39.96', 30, 'J2-3456-0001', ' image33.jpg'),
(71, 'Just Cause 4 - Xbox One', 100, '44.27', 30, 'J2-3456-0002', 'image34.jpeg'),
(72, 'NFS Heat pour (Xbox One)', 100, '29.96', 30, 'J2-3456-0003', 'image35.jpg'),
(73, 'Minecraft édition Xbox One', 100, '93.27', 30, 'J2-3456-0004', 'image36.jpg'),
(74, 'FIFA 21 pour (Nintendo Switch)', 100, '39.96', 30, 'J3-3456-0001', 'image37.jpg'),
(75, 'Trials of Mana pour (Nintendo Switch)', 100, '29.96', 30, 'J3-3456-0002', 'image38.jpg'),
(76, 'New Super Mario Bros U Deluxe Nintendo Switch', 100, '106.25', 30, 'J3-3456-0003', 'image39.jpeg'),
(77, 'Luigis Mansion 3 pour (Nintendo Switch)', 100, '79.96', 30, 'J3-3456-0004', 'image40.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `sortiestock`
--

CREATE TABLE `sortiestock` (
  `id` int(11) NOT NULL,
  `idStock` int(11) DEFAULT NULL,
  `typeSortie` varchar(30) DEFAULT NULL,
  `referenceTransaction` int(11) DEFAULT NULL,
  `quantite` int(11) DEFAULT NULL
) ;

-- --------------------------------------------------------

--
-- Table structure for table `stock`
--

CREATE TABLE `stock` (
  `id` int(11) NOT NULL,
  `idProduit` int(11) DEFAULT NULL,
  `idAchat` int(11) DEFAULT NULL,
  `dateReception` date DEFAULT NULL,
  `quantiteTotal` int(11) DEFAULT NULL,
  `quantiteRestant` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `typelivraison`
--

CREATE TABLE `typelivraison` (
  `id` int(2) NOT NULL,
  `description` varchar(30) DEFAULT NULL,
  `nbreJourLocal` int(11) DEFAULT NULL,
  `nbreJourOutreMer` int(11) DEFAULT NULL
) ;

-- --------------------------------------------------------

--
-- Structure for view `listeclient`
--
DROP TABLE IF EXISTS `listeclient`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `listeclient`  AS  select `client`.`id` AS `id`,`client`.`nom` AS `nom`,`client`.`prenom` AS `prenom`,`client`.`typeUser` AS `typeUser`,`client`.`courriel` AS `courriel`,`client`.`pass` AS `pass` from `client` ;

-- --------------------------------------------------------

--
-- Structure for view `listefilm`
--
DROP TABLE IF EXISTS `listefilm`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `listefilm`  AS  select `produit`.`id` AS `idProduit`,`produit`.`nom` AS `nom`,`produit`.`quantite` AS `quantite`,`produit`.`prixUnitaire` AS `prixUnitaire`,`produit`.`quantiteSeuil` AS `quantiteSeuil`,`produit`.`emplacement` AS `emplacement`,`produit`.`image` AS `image`,`film`.`duree` AS `duree`,`film`.`categorie` AS `categorie` from (`produit` join `film`) where (`produit`.`id` = `film`.`idProduit`) ;

-- --------------------------------------------------------

--
-- Structure for view `listefilmaction`
--
DROP TABLE IF EXISTS `listefilmaction`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `listefilmaction`  AS  select `produit`.`id` AS `idProduit`,`produit`.`nom` AS `nom`,`produit`.`quantite` AS `quantite`,`produit`.`prixUnitaire` AS `prixUnitaire`,`produit`.`quantiteSeuil` AS `quantiteSeuil`,`produit`.`emplacement` AS `emplacement`,`produit`.`image` AS `image`,`film`.`duree` AS `duree`,`film`.`categorie` AS `categorie` from (`produit` join `film`) where ((`produit`.`id` = `film`.`idProduit`) and (`film`.`categorie` = 'Action')) ;

-- --------------------------------------------------------

--
-- Structure for view `listefilmcomedie`
--
DROP TABLE IF EXISTS `listefilmcomedie`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `listefilmcomedie`  AS  select `produit`.`id` AS `idProduit`,`produit`.`nom` AS `nom`,`produit`.`quantite` AS `quantite`,`produit`.`prixUnitaire` AS `prixUnitaire`,`produit`.`quantiteSeuil` AS `quantiteSeuil`,`produit`.`emplacement` AS `emplacement`,`produit`.`image` AS `image`,`film`.`duree` AS `duree`,`film`.`categorie` AS `categorie` from (`produit` join `film`) where ((`produit`.`id` = `film`.`idProduit`) and (`film`.`categorie` = 'Comedie')) ;

-- --------------------------------------------------------

--
-- Structure for view `listefilmdrame`
--
DROP TABLE IF EXISTS `listefilmdrame`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `listefilmdrame`  AS  select `produit`.`id` AS `idProduit`,`produit`.`nom` AS `nom`,`produit`.`quantite` AS `quantite`,`produit`.`prixUnitaire` AS `prixUnitaire`,`produit`.`quantiteSeuil` AS `quantiteSeuil`,`produit`.`emplacement` AS `emplacement`,`produit`.`image` AS `image`,`film`.`duree` AS `duree`,`film`.`categorie` AS `categorie` from (`produit` join `film`) where ((`produit`.`id` = `film`.`idProduit`) and (`film`.`categorie` = 'Drame')) ;

-- --------------------------------------------------------

--
-- Structure for view `listefilmfiction`
--
DROP TABLE IF EXISTS `listefilmfiction`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `listefilmfiction`  AS  select `produit`.`id` AS `idProduit`,`produit`.`nom` AS `nom`,`produit`.`quantite` AS `quantite`,`produit`.`prixUnitaire` AS `prixUnitaire`,`produit`.`quantiteSeuil` AS `quantiteSeuil`,`produit`.`emplacement` AS `emplacement`,`produit`.`image` AS `image`,`film`.`duree` AS `duree`,`film`.`categorie` AS `categorie` from (`produit` join `film`) where ((`produit`.`id` = `film`.`idProduit`) and (`film`.`categorie` = 'Fiction')) ;

-- --------------------------------------------------------

--
-- Structure for view `listejeux`
--
DROP TABLE IF EXISTS `listejeux`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `listejeux`  AS  select `produit`.`id` AS `idProduit`,`produit`.`nom` AS `nom`,`produit`.`quantite` AS `quantite`,`produit`.`prixUnitaire` AS `prixUnitaire`,`produit`.`quantiteSeuil` AS `quantiteSeuil`,`produit`.`emplacement` AS `emplacement`,`produit`.`image` AS `image`,`jeux`.`plateforme` AS `plateforme`,`jeux`.`categorie` AS `categorie` from (`produit` join `jeux`) where (`produit`.`id` = `jeux`.`idProduit`) ;

-- --------------------------------------------------------

--
-- Structure for view `listejeuxnintendo`
--
DROP TABLE IF EXISTS `listejeuxnintendo`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `listejeuxnintendo`  AS  select `produit`.`id` AS `idProduit`,`produit`.`nom` AS `nom`,`produit`.`quantite` AS `quantite`,`produit`.`prixUnitaire` AS `prixUnitaire`,`produit`.`quantiteSeuil` AS `quantiteSeuil`,`produit`.`emplacement` AS `emplacement`,`produit`.`image` AS `image`,`jeux`.`plateforme` AS `plateforme`,`jeux`.`categorie` AS `categorie` from (`produit` join `jeux`) where ((`produit`.`id` = `jeux`.`idProduit`) and (`jeux`.`categorie` = 'Nintendo')) ;

-- --------------------------------------------------------

--
-- Structure for view `listejeuxplaystation`
--
DROP TABLE IF EXISTS `listejeuxplaystation`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `listejeuxplaystation`  AS  select `produit`.`id` AS `idProduit`,`produit`.`nom` AS `nom`,`produit`.`quantite` AS `quantite`,`produit`.`prixUnitaire` AS `prixUnitaire`,`produit`.`quantiteSeuil` AS `quantiteSeuil`,`produit`.`emplacement` AS `emplacement`,`produit`.`image` AS `image`,`jeux`.`plateforme` AS `plateforme`,`jeux`.`categorie` AS `categorie` from (`produit` join `jeux`) where ((`produit`.`id` = `jeux`.`idProduit`) and (`jeux`.`categorie` = 'Playstation')) ;

-- --------------------------------------------------------

--
-- Structure for view `listejeuxxbox`
--
DROP TABLE IF EXISTS `listejeuxxbox`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `listejeuxxbox`  AS  select `produit`.`id` AS `idProduit`,`produit`.`nom` AS `nom`,`produit`.`quantite` AS `quantite`,`produit`.`prixUnitaire` AS `prixUnitaire`,`produit`.`quantiteSeuil` AS `quantiteSeuil`,`produit`.`emplacement` AS `emplacement`,`produit`.`image` AS `image`,`jeux`.`plateforme` AS `plateforme`,`jeux`.`categorie` AS `categorie` from (`produit` join `jeux`) where ((`produit`.`id` = `jeux`.`idProduit`) and (`jeux`.`categorie` = 'Xbox')) ;

-- --------------------------------------------------------

--
-- Structure for view `listelivre`
--
DROP TABLE IF EXISTS `listelivre`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `listelivre`  AS  select `produit`.`id` AS `idProduit`,`produit`.`nom` AS `nom`,`produit`.`quantite` AS `quantite`,`produit`.`prixUnitaire` AS `prixUnitaire`,`produit`.`quantiteSeuil` AS `quantiteSeuil`,`produit`.`emplacement` AS `emplacement`,`produit`.`image` AS `image`,`livre`.`isbn` AS `isbn`,`livre`.`auteur` AS `auteur`,`livre`.`categorie` AS `categorie` from (`produit` join `livre`) where (`produit`.`id` = `livre`.`idProduit`) ;

-- --------------------------------------------------------

--
-- Structure for view `listelivregeographique`
--
DROP TABLE IF EXISTS `listelivregeographique`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `listelivregeographique`  AS  select `produit`.`id` AS `idProduit`,`produit`.`nom` AS `nom`,`produit`.`quantite` AS `quantite`,`produit`.`prixUnitaire` AS `prixUnitaire`,`produit`.`quantiteSeuil` AS `quantiteSeuil`,`produit`.`emplacement` AS `emplacement`,`produit`.`image` AS `image`,`livre`.`isbn` AS `isbn`,`livre`.`auteur` AS `auteur`,`livre`.`categorie` AS `categorie` from (`produit` join `livre`) where ((`produit`.`id` = `livre`.`idProduit`) and (`livre`.`categorie` = 'Geographique')) ;

-- --------------------------------------------------------

--
-- Structure for view `listelivreinformatique`
--
DROP TABLE IF EXISTS `listelivreinformatique`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `listelivreinformatique`  AS  select `produit`.`id` AS `idProduit`,`produit`.`nom` AS `nom`,`produit`.`quantite` AS `quantite`,`produit`.`prixUnitaire` AS `prixUnitaire`,`produit`.`quantiteSeuil` AS `quantiteSeuil`,`produit`.`emplacement` AS `emplacement`,`produit`.`image` AS `image`,`livre`.`isbn` AS `isbn`,`livre`.`auteur` AS `auteur`,`livre`.`categorie` AS `categorie` from (`produit` join `livre`) where ((`produit`.`id` = `livre`.`idProduit`) and (`livre`.`categorie` = 'Informatique')) ;

-- --------------------------------------------------------

--
-- Structure for view `listelivrelitterature`
--
DROP TABLE IF EXISTS `listelivrelitterature`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `listelivrelitterature`  AS  select `produit`.`id` AS `idProduit`,`produit`.`nom` AS `nom`,`produit`.`quantite` AS `quantite`,`produit`.`prixUnitaire` AS `prixUnitaire`,`produit`.`quantiteSeuil` AS `quantiteSeuil`,`produit`.`emplacement` AS `emplacement`,`produit`.`image` AS `image`,`livre`.`isbn` AS `isbn`,`livre`.`auteur` AS `auteur`,`livre`.`categorie` AS `categorie` from (`produit` join `livre`) where ((`produit`.`id` = `livre`.`idProduit`) and (`livre`.`categorie` = 'Litterature')) ;

-- --------------------------------------------------------

--
-- Structure for view `listeproduit`
--
DROP TABLE IF EXISTS `listeproduit`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `listeproduit`  AS  select `produit`.`id` AS `id`,`produit`.`nom` AS `nom`,`produit`.`quantite` AS `quantite`,`produit`.`prixUnitaire` AS `prixUnitaire`,`produit`.`quantiteSeuil` AS `quantiteSeuil`,`produit`.`emplacement` AS `emplacement`,`produit`.`image` AS `image`,`livre`.`isbn` AS `isbn`,`livre`.`auteur` AS `auteur`,'' AS `duree`,'' AS `plateforme`,`livre`.`categorie` AS `categorie` from (`livre` join `produit`) where (`produit`.`id` = `livre`.`idProduit`) union select `produit`.`id` AS `id`,`produit`.`nom` AS `nom`,`produit`.`quantite` AS `quantite`,`produit`.`prixUnitaire` AS `prixUnitaire`,`produit`.`quantiteSeuil` AS `quantiteSeuil`,`produit`.`emplacement` AS `emplacement`,`produit`.`image` AS `image`,'' AS `isbn`,'' AS `auteur`,`film`.`duree` AS `duree`,'' AS `plateforme`,`film`.`categorie` AS `categorie` from (`film` join `produit`) where (`produit`.`id` = `film`.`idProduit`) union select `produit`.`id` AS `id`,`produit`.`nom` AS `nom`,`produit`.`quantite` AS `quantite`,`produit`.`prixUnitaire` AS `prixUnitaire`,`produit`.`quantiteSeuil` AS `quantiteSeuil`,`produit`.`emplacement` AS `emplacement`,`produit`.`image` AS `image`,'' AS `isbn`,'' AS `auteur`,'' AS `duree`,`jeux`.`plateforme` AS `plateforme`,`jeux`.`categorie` AS `categorie` from (`jeux` join `produit`) where (`produit`.`id` = `jeux`.`idProduit`) ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `achat`
--
ALTER TABLE `achat`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `client`
--
ALTER TABLE `client`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `courriel` (`courriel`);

--
-- Indexes for table `commande`
--
ALTER TABLE `commande`
  ADD PRIMARY KEY (`numero`);

--
-- Indexes for table `employe`
--
ALTER TABLE `employe`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `userName` (`userName`);

--
-- Indexes for table `film`
--
ALTER TABLE `film`
  ADD PRIMARY KEY (`idProduit`);

--
-- Indexes for table `furnisseur`
--
ALTER TABLE `furnisseur`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `jeux`
--
ALTER TABLE `jeux`
  ADD PRIMARY KEY (`idProduit`);

--
-- Indexes for table `lignecommande`
--
ALTER TABLE `lignecommande`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `livre`
--
ALTER TABLE `livre`
  ADD PRIMARY KEY (`idProduit`);

--
-- Indexes for table `produit`
--
ALTER TABLE `produit`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `sortiestock`
--
ALTER TABLE `sortiestock`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stock`
--
ALTER TABLE `stock`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `typelivraison`
--
ALTER TABLE `typelivraison`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `achat`
--
ALTER TABLE `achat`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `client`
--
ALTER TABLE `client`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `employe`
--
ALTER TABLE `employe`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `furnisseur`
--
ALTER TABLE `furnisseur`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `lignecommande`
--
ALTER TABLE `lignecommande`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `produit`
--
ALTER TABLE `produit`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=78;

--
-- AUTO_INCREMENT for table `sortiestock`
--
ALTER TABLE `sortiestock`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `stock`
--
ALTER TABLE `stock`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `film`
--
ALTER TABLE `film`
  ADD CONSTRAINT `fk_produit_film` FOREIGN KEY (`idProduit`) REFERENCES `produit` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `jeux`
--
ALTER TABLE `jeux`
  ADD CONSTRAINT `fk_produit_jeux` FOREIGN KEY (`idProduit`) REFERENCES `produit` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `livre`
--
ALTER TABLE `livre`
  ADD CONSTRAINT `fk_produit_livre` FOREIGN KEY (`idProduit`) REFERENCES `produit` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
