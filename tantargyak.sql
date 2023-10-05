-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2023. Okt 05. 10:21
-- Kiszolgáló verziója: 10.4.28-MariaDB
-- PHP verzió: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `tantargyak`
--
CREATE DATABASE IF NOT EXISTS `tantargyak` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `tantargyak`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ertekelesek`
--
-- Létrehozva: 2023. Okt 05. 08:03
-- Utolsó frissítés: 2023. Okt 05. 08:20
--

CREATE TABLE `ertekelesek` (
  `azon` varchar(50) NOT NULL,
  `jegy` int(1) NOT NULL,
  `leiras` varchar(100) NOT NULL,
  `letrejott` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `ertekelesek`
--

INSERT INTO `ertekelesek` (`azon`, `jegy`, `leiras`, `letrejott`) VALUES
('3a83d72d-c73c-4fd8-b254-497eb1a86680', 1, 'Fizika', '2023-10-05 10:12:22'),
('4991931d-91f6-4a0b-8e08-5a4a6385ae3f', 5, 'Történelem', '2023-10-05 10:05:51'),
('4dfeb815-de8b-4a5b-9faf-a272d92aa1d9', 3, 'Földrajz', '2023-10-05 10:05:10'),
('589ee4da-46f1-4a00-9057-ebdc85d06417', 5, 'Testnevelés', '2023-10-05 10:05:58'),
('9dcb43f9-087c-4ffa-80bd-7e50ed488eae', 4, 'Irodalom', '2023-10-05 10:05:31'),
('d38befa4-bd84-40eb-b77d-8c7fbad4fc8d', 2, 'Matematika', '2023-10-05 10:04:59'),
('dbc5d4e1-11cf-4626-a4a6-bdb772209ca6', 4, 'Informatika', '2023-10-05 10:05:25'),
('f6599488-9c83-4a4d-b944-c7843e25f3eb', 3, 'Nyelvtan', '2023-10-05 10:05:40');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `ertekelesek`
--
ALTER TABLE `ertekelesek`
  ADD PRIMARY KEY (`azon`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
