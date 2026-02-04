-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2026. Feb 03. 09:14
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

CREATE DATABASE `stayly`
  DEFAULT CHARACTER SET utf8
  COLLATE utf8_hungarian_ci;

USE `stayly`;


-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szallas`
--

CREATE TABLE `szallas` (
  `ID` int(11) NOT NULL,
  `hostName` varchar(50) DEFAULT NULL,
  `popertyName` varchar(50) DEFAULT NULL,
  `location` varchar(50) DEFAULT NULL,
  `price` decimal(10,2) DEFAULT NULL,
  `rating` decimal(3,2) DEFAULT NULL,
  `checkInTime` varchar(50) DEFAULT NULL,
  `checkOutTime` varchar(50) DEFAULT NULL,
  `elerhetoseg` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `szallas`
--

INSERT INTO `szallas` (`ID`, `hostName`, `popertyName`, `location`, `price`, `rating`, `checkInTime`, `checkOutTime`, `elerhetoseg`) VALUES
(3, 'Garik Giaomozzo', 'Bernier, O\'Connell and Kovacek', 'São Tomé', 1097.17, 2.37, '7:47 PM', '6:49 AM', 1),
(5, 'Leigh Casassa', 'Jacobs, Rohan and Heller', 'Clermont-Ferrand', 748.48, 1.50, '10:17 AM', '12:59 PM', 1),
(7, 'Otha Lehenmann', 'Considine-Jerde', 'Naranjos', 409.51, 1.08, '5:30 AM', '12:59 AM', 1),
(9, 'Rodi Drinnan', 'Daniel-Ernser', 'Qingkenpao', 1132.33, 4.76, '6:45 PM', '11:12 PM', 0),
(10, 'Gwenni Soigoux', 'Murray-Spencer', 'Jubung', 61.42, 2.25, '12:54 AM', '5:18 AM', 1),
(12, 'Marigold Nelane', 'Volkman, Balistreri and Hirthe', 'Argayash', 732.57, 3.68, '2:17 PM', '5:00 PM', 1),
(13, 'Murry Larwell', 'McClure, Little and Macejkovic', 'Brooklyn', 1387.28, 3.23, '12:00 AM', '1:44 AM', 0),
(15, 'Rubi Records', 'Hayes-Schoen', 'Íasmos', 877.82, 2.48, '10:16 AM', '3:56 AM', 0),
(16, 'Hillary Ottam', 'Harris, Roberts and Greenfelder', 'Galitsy', 879.03, 3.40, '1:17 AM', '12:26 PM', 0),
(17, 'Gussi Borth', 'Boehm, Maggio and Cruickshank', 'Ilinden', 813.82, 3.52, '11:45 AM', '12:55 AM', 0),
(21, 'Lindy Barham', 'Ledner, Ritchie and Shanahan', 'Konobeyevo', 513.62, 3.77, '7:53 AM', '7:38 PM', 1),
(23, 'Aubrette Studdert', 'Lebsack-Haley', 'Kalmar', 563.21, 1.51, '6:37 PM', '11:41 PM', 0),
(24, 'Antonius Montrose', 'Streich-Spencer', 'Till', 87.27, 2.37, '9:54 PM', '2:27 PM', 0),
(26, 'Georgeanne Heazel', 'Witting, Swift and Gulgowski', 'Ketanggi', 602.89, 4.26, '2:31 PM', '1:57 AM', 1),
(32, 'Obie Divall', 'Yundt Group', 'Xinye', 589.70, 3.33, '12:32 PM', '4:34 PM', 1),
(33, 'Mariellen Teresi', 'Rohan, Howe and Schmeler', 'Cimanggu', 483.43, 1.83, '6:41 AM', '6:56 PM', 0),
(35, 'Selma Bedo', 'Dickinson, Legros and Kerluke', 'Guruafin', 1058.73, 2.27, '7:10 AM', '12:08 PM', 1),
(39, 'Leone Headey', 'Wilkinson, Bernhard and Boehm', 'Oravais', 1481.58, 3.36, '6:22 AM', '2:26 AM', 1),
(41, 'Kenton Hews', 'Gusikowski, Kshlerin and Monahan', 'Zhenghu', 504.60, 3.62, '1:51 AM', '4:39 AM', 1),
(42, 'Gui Migheli', 'Cartwright, Howe and Franecki', 'Badulla', 1433.17, 3.87, '3:54 PM', '12:57 AM', 0),
(43, 'Shaw Pappi', 'Rath, Schultz and Smitham', 'Thị Trấn Phú Mỹ', 527.91, 4.70, '1:24 PM', '5:35 AM', 0),
(48, 'Twyla Brinded', 'Goodwin LLC', 'Patos', 1159.58, 2.04, '10:11 AM', '1:43 PM', 1),
(49, 'Christal Mearns', 'Veum-Dach', 'Bulihan', 306.18, 2.52, '8:51 PM', '3:15 AM', 1),
(54, 'Calypso Brauns', 'Bechtelar-Bosco', 'Ust’ye', 642.57, 4.21, '7:45 AM', '12:31 PM', 1),
(55, 'Avery Kennham', 'Fadel LLC', 'Kawengan', 299.69, 2.55, '6:31 PM', '12:24 AM', 0),
(56, 'Wesley Clist', 'Green LLC', 'Bošovice', 1101.17, 2.54, '6:02 AM', '9:19 PM', 1),
(60, 'Mercy Berrick', 'Nader LLC', 'Pom Prap Sattru Phai', 1463.62, 2.98, '11:06 PM', '5:30 AM', 0),
(63, 'Titos Rizzi', 'Hoeger Group', 'Siedlce', 1032.86, 1.80, '1:44 AM', '1:40 AM', 1),
(65, 'Zeb Cottey', 'Bogisich Group', 'San Francisco', 1100.06, 1.88, '4:23 PM', '2:18 AM', 1),
(66, 'Darren Capin', 'Heathcote and Sons', 'Champigny-sur-Marne', 225.59, 2.21, '5:46 PM', '5:42 PM', 1),
(70, 'Mayne Kenrat', 'Donnelly, Langworth and Senger', 'Heredia', 663.81, 3.92, '7:09 PM', '1:29 AM', 1),
(72, 'Gusta Killik', 'Gerlach-Walker', 'Dār Kulayb', 1093.75, 1.41, '6:29 AM', '6:33 AM', 1),
(73, 'Courtney Muckle', 'McKenzie, Conn and Johns', 'Svirsk', 547.19, 2.98, '5:12 AM', '2:48 PM', 0),
(77, 'Giuseppe Crennell', 'Schmeler Inc', 'Ipoti', 682.76, 4.29, '1:23 PM', '9:43 PM', 0),
(80, 'Currie Witherop', 'Balistreri, Champlin and Fahey', 'Seidu', 820.08, 2.43, '7:15 AM', '6:28 PM', 0),
(81, 'Kerwin Tytler', 'Dietrich, Jenkins and Gulgowski', 'Pavlogradka', 432.77, 2.43, '5:09 PM', '2:08 PM', 0),
(82, 'Kamilah Schukert', 'Runolfsdottir-Mertz', 'Lamawan', 350.68, 3.91, '1:18 PM', '10:32 AM', 1),
(89, 'Elden Flanders', 'Lebsack and Sons', 'Makiwalo', 94.48, 4.54, '8:17 AM', '7:57 PM', 1),
(90, 'Kiri Ledger', 'Predovic LLC', 'Sanjō', 789.72, 3.12, '3:33 PM', '11:26 AM', 1),
(91, 'Berta Jahncke', 'Huel Inc', 'Solok', 715.05, 3.88, '10:58 AM', '12:55 PM', 0),
(93, 'Dewain Ollie', 'Russel and Sons', 'Dongchong', 1471.03, 4.18, '6:42 AM', '4:38 PM', 0),
(96, 'Auberta Standall', 'Auer-Reilly', 'Tuojiang', 924.74, 4.15, '12:53 PM', '10:31 AM', 1),
(99, 'Marlie Kells', 'Streich LLC', 'Gayam', 1048.81, 1.73, '8:10 PM', '9:15 AM', 0),
(300, 'Tammy O\'Bruen', 'Beer-Hickle', 'Granville', 199.19, 1.34, '12:31 AM', '5:13 AM', 1),
(301, 'Duna Panzió', 'Duna Wellness Hotel', 'Kalocsa', 9999.99, 8.70, '14:00', '10:00', 1),
(302, 'Gemenc Szálló', 'Gemenc Hotel', 'Baja', 9999.99, 8.50, '15:00', '11:00', 1),
(303, 'Palatinus Grand Hotel', 'Hotel Palatinus City Center', 'Pécs', 9999.99, 9.00, '14:00', '10:00', 1),
(304, 'Szent János Hotel', 'Szent János Hotel', 'Mohács', 9999.99, 8.80, '15:00', '11:00', 1),
(305, 'Art Hotel Szeged', 'Art Hotel Szeged', 'Szeged', 9999.99, 9.30, '14:00', '11:00', 1),
(306, 'Hotel Kalocsa', 'Hotel Kalocsa', 'Kalocsa', 9999.99, 8.20, '13:00', '10:00', 1),
(307, 'Malom Club Panzió', 'Malom Club Panzió', 'Baja', 9999.99, 8.40, '14:00', '10:00', 1),
(308, 'Hotel Laterum', 'Laterum Conference & Wellness Hotel', 'Pécs', 9999.99, 8.60, '14:00', '10:00', 1),
(309, 'Hotel Selyemgyár', 'Selyemgyár Fogadó', 'Mohács', 9999.99, 8.10, '15:00', '10:00', 1),
(310, 'Tisza Corner Hotel', 'Tisza Corner Hotel', 'Szeged', 9999.99, 8.00, '14:00', '10:00', 1),
(311, 'Duna Panzió', 'Duna Wellness Hotel', 'Kalocsa', 18900.00, 8.70, '14:00', '10:00', 1),
(312, 'Gemenc Szálló', 'Gemenc Hotel', 'Baja', 17500.00, 8.50, '15:00', '11:00', 1),
(313, 'Palatinus Grand Hotel', 'Hotel Palatinus City Center', 'Pécs', 24500.00, 9.00, '14:00', '10:00', 1),
(314, 'Szent János Hotel', 'Szent János Hotel', 'Mohács', 19800.00, 8.80, '15:00', '11:00', 1),
(315, 'Art Hotel Szeged', 'Art Hotel Szeged', 'Szeged', 26900.00, 9.30, '14:00', '11:00', 1),
(316, 'Hotel Kalocsa', 'Hotel Kalocsa', 'Kalocsa', 15900.00, 8.20, '13:00', '10:00', 1),
(317, 'Malom Club Panzió', 'Malom Club Panzió', 'Baja', 14200.00, 8.40, '14:00', '10:00', 1),
(318, 'Hotel Laterum', 'Laterum Conference & Wellness Hotel', 'Pécs', 18900.00, 8.60, '14:00', '10:00', 1),
(319, 'Hotel Selyemgyár', 'Selyemgyár Fogadó', 'Mohács', 16400.00, 8.10, '15:00', '10:00', 1),
(320, 'Tisza Corner Hotel', 'Tisza Corner Hotel', 'Szeged', 15200.00, 8.00, '14:00', '10:00', 1),
(321, 'Laci Szállás', 'Laci birtoka', 'Pécs', 10000.00, 6.00, '12:00', '11:00', 1),
(323, 'Laci', 'Lacika ágya', 'Pécs', 10000.00, 2.00, '12:00', '10:00', 0),
(324, 'ha', 'haaha', 'baja', 1500.00, 5.00, '12:00', '13:01', 1),
(325, 'f', 'f', 'f', 150.00, 5.00, '14:22', '15:52', 1),
(327, 's', 's', 's', 2.00, 4.00, '14:00', '15:00', 1),
(328, 'martin', 'resorr', 'hajós', 1500.00, 4.00, '12:00', '19:00', 1);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `szallas`
--
ALTER TABLE `szallas`
  ADD PRIMARY KEY (`ID`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `szallas`
--
ALTER TABLE `szallas`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=329;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
