-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 11 Gru 2019, 17:20
-- Wersja serwera: 10.1.37-MariaDB
-- Wersja PHP: 7.3.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `quack`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `koszyk`
--

CREATE TABLE `koszyk` (
  `id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `count` int(11) NOT NULL,
  `size` varchar(10) COLLATE utf8_polish_ci NOT NULL,
  `color` varchar(20) COLLATE utf8_polish_ci NOT NULL,
  `is_ordered` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `koszyk`
--

INSERT INTO `koszyk` (`id`, `user_id`, `product_id`, `count`, `size`, `color`, `is_ordered`) VALUES
(1, 2, 13, 3, 'S', 'pink', 1),
(2, 6, 13, 1, 'XL', 'black', 0),
(3, 6, 14, 1, 'XXL', 'blue', 0),
(4, 2, 13, 2, 'M', 'cadetblue', 1),
(5, 2, 14, 5, 'L', 'green', 1),
(6, 2, 13, 1, 'XL', 'brown', 1),
(8, 2, 14, 1, 'M', 'Cadetblue', 1),
(9, 2, 13, 1, 'S', 'Cornflowerblue', 1),
(10, 7, 13, 1, 'L', 'Cornflowerblue', 0),
(11, 2, 18, 2, 'XXL', 'Brown', 1),
(12, 2, 17, 1, 'M', 'Cadetblue', 1),
(13, 4, 16, 1, 'L', 'Cadetblue', 1),
(14, 4, 14, 3, 'L', 'Pink', 2),
(15, 4, 14, 1, 'S', 'Cadetblue', 2),
(19, 4, 16, 1, 'S', 'Cadetblue', 0);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `produkty`
--

CREATE TABLE `produkty` (
  `id` int(11) NOT NULL,
  `nazwa` varchar(100) COLLATE utf8_polish_ci NOT NULL,
  `kategoria` varchar(100) COLLATE utf8_polish_ci NOT NULL,
  `opis` varchar(10000) COLLATE utf8_polish_ci NOT NULL,
  `zdjecia` varchar(500) COLLATE utf8_polish_ci NOT NULL,
  `cena` varchar(10) COLLATE utf8_polish_ci NOT NULL,
  `kolory` varchar(300) COLLATE utf8_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `produkty`
--

INSERT INTO `produkty` (`id`, `nazwa`, `kategoria`, `opis`, `zdjecia`, `cena`, `kolory`) VALUES
(14, 'Test', 'Testowe', 'test', 'patronus_cat.jpg,patronus_sloth.jpg', '18.59', 'Pink,Blue,Cadetblue'),
(15, 'Placeholder', 'Testowe', 'placeholder', 'penguin_game.jpg', '29.99', 'Green,Blue,Brown,Moccasin'),
(16, 'Disappointed but not surprised', 'Zwierzęta', 'Kotek', 'diss1.jpg,diss2.png,diss3.jpg,diss4.png', '39.99', 'Black,Green,Cadetblue,Brown,Cornflowerblue'),
(17, 'Call me unicorn', 'Zwierzęta', 'Jednorożec!', 'uni1.jpg,uni2.png,uni3.jpg,uni4.png', '49.99', 'Black,Pink,Blue,Cadetblue,Moccasin,Cornflowerblue'),
(18, 'Fat Life', 'Zwierzęta', 'Chomik', 'fat1.png,fat2.png,fat3.jpg,fat4.jpg', '29.99', 'Black,Green,Brown,Moccasin'),
(19, 'Falling Fox', 'Zwierzęta', 'Lis', 'fox1.png,fox2.png,fox3.jpg,fox4.png', '59.99', 'Black,Green,Blue,Cadetblue,Moccasin,Cornflowerblue');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `uzytkownicy`
--

CREATE TABLE `uzytkownicy` (
  `id` int(11) NOT NULL,
  `login` varchar(100) COLLATE utf8_polish_ci NOT NULL,
  `password_hash` varchar(48) COLLATE utf8_polish_ci NOT NULL,
  `isAdmin` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `uzytkownicy`
--

INSERT INTO `uzytkownicy` (`id`, `login`, `password_hash`, `isAdmin`) VALUES
(2, 'admin', 'CDLa28Vj0yUtHp+2FJl3ESXvBR3jUBqZ62Ts6qL5VaO133dE', 1),
(3, 'test', 'BKYTeEoC1/1HAMxUsynUzUOspfCNyfbTqW2u44/J6nXZPOk4', 0),
(4, 'filip', 'vEMpNpeUMyJnP+CtWTBRjhQSKXP3Bjp4ZVNdFXCno/qIo14P', 0),
(6, 'testtest', 'S9048KG9Sqcq6LlMpKxkScMT7FScfy4+j56JbVCargXZ0/TW', 0);

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `koszyk`
--
ALTER TABLE `koszyk`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `produkty`
--
ALTER TABLE `produkty`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `uzytkownicy`
--
ALTER TABLE `uzytkownicy`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT dla tabeli `koszyk`
--
ALTER TABLE `koszyk`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT dla tabeli `produkty`
--
ALTER TABLE `produkty`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT dla tabeli `uzytkownicy`
--
ALTER TABLE `uzytkownicy`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
