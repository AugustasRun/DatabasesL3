-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 2021 m. Geg 12 d. 10:47
-- Server version: 10.4.17-MariaDB
-- PHP Version: 8.0.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_lab1`
--

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `aušintuvai`
--

CREATE TABLE `aušintuvai` (
  `Pavadinimas` varchar(40) NOT NULL,
  `Paskirtis` varchar(10) NOT NULL,
  `Gamintojas` varchar(40) NOT NULL,
  `Ventiliatoriaus_dydis` varchar(10) NOT NULL,
  `Max_apsukos` varchar(30) NOT NULL,
  `id_Aušintuvai` int(11) NOT NULL,
  `fk_CPUid_CPU` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sukurta duomenų kopija lentelei `aušintuvai`
--

INSERT INTO `aušintuvai` (`Pavadinimas`, `Paskirtis`, `Gamintojas`, `Ventiliatoriaus_dydis`, `Max_apsukos`, `id_Aušintuvai`, `fk_CPUid_CPU`) VALUES
('TEST1', 'TEST1', 'TEST1', 'TEST1', 'TEST1', 2, 10),
('TEST1', 'TEST1', 'TEST1', 'TEST1', 'TEST1', 3, 10),
('TEST1', 'TEST1', 'TEST1', 'TEST1', 'TEST1', 4, 10),
('TEST1', 'TEST1', 'TEST1', 'TEST1', 'TEST1', 5, 10),
('TEST2', 'TEST2', 'TEST2', 'TEST2', 'TEST2', 56, 32323),
('TEST2', 'TEST2', 'TEST2', 'TEST2', 'TEST2', 345, 32323),
('TEST2', 'TEST2', 'TEST2', 'TEST2', 'TEST2', 734, 32323),
('TEST2', 'TEST2', 'TEST2', 'TEST2', 'TEST2', 2345, 32323),
('DP-MCH2-GMX200T', 'CPU', 'Aerocool', '120MM', '1700rpm', 1035774, 85161482),
('MLW-D12M-A18PC-R2', 'CPU', 'Noctua', '90MM', '1900RPM', 4665451, 60298025),
('DP-H12RF-GL120RGB', 'CPU', 'Zalman', '120MM', '2000RPM', 12391328, 64090129),
(' CL-P039-AL12BL-A', 'CPU', 'Gembird', '120MM', '1700rpm', 22331223, 70686180),
('SPC144', 'CPU', 'Fractal Design', '120MM', '1790rpm', 35967902, 51103346),
('DP-MCH4-GMX400V2-BL', 'CPU', 'Be quiet', '90MM', '2500rpm', 38862470, 15162536),
('R-AS500-BKNLMN-G', 'CPU', 'ThermalTake', '100MM', '2100RPM', 40929000, 49497253),
('HURACAN-RGB-X120', 'CPU', 'Asus', '90MM', '2000rpm', 42776959, 78020098),
('CL-W285-PL12SW-A', 'CASE FAN', 'Antec', '120MM', '1700RPM', 51797376, 10497912),
('CW-9060028-WW', 'CPU', 'Silverstone', '100MM', '1700RPM', 53032849, 24521250),
('XC029', 'CPU', 'Corsair', '80MM', '1050rpm', 55864228, 27264510),
('MAP-D6PN-218PC-R1', 'CASE FAN', 'Asus', '120MM', '1500RPM', 57739175, 27622290),
('DP-MCH3-GMX300RD', 'CPU', 'Artic cooling', '100MM', '1750rpm', 62065883, 87644057),
('DP-MCH3-GMX300', 'CPU', 'Antec', '92MM', '1800rpm', 64189048, 8197767),
('XC041', 'CPU', 'Cooler master', '80MM', '2050rpm', 67099012, 88792177),
('CPU-HURACAN-RGB-X500', 'CPU', 'Xilence', '120MM', '2050RPM', 67915825, 97405288),
('BXTS13A', 'CPU', 'Deepcool', '80MM', '1750rpm', 89747414, 50743218),
('CNPS17X', 'CPU', 'NZXT', '100MM', '1800RPM', 91655423, 6921915),
('ACFRE00055A', 'CASE FAN', 'Aerocool', '120MM', '1800RPM', 91938011, 10820787),
('CNPS16X WHITE', 'CPU', 'MSI', '90MM', '1950RPM', 98452210, 10497912);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `cpu`
--

CREATE TABLE `cpu` (
  `Pavadinimas` varchar(40) NOT NULL,
  `Daznis` varchar(10) NOT NULL,
  `Vatai_suvartojimas` varchar(10) NOT NULL,
  `Pagreitintas_dažnis` varchar(10) DEFAULT NULL,
  `Gamintojas` int(11) NOT NULL,
  `id_CPU` int(11) NOT NULL,
  `fk_Motinine_Ploksteid_Motinine_Plokste` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sukurta duomenų kopija lentelei `cpu`
--

INSERT INTO `cpu` (`Pavadinimas`, `Daznis`, `Vatai_suvartojimas`, `Pagreitintas_dažnis`, `Gamintojas`, `id_CPU`, `fk_Motinine_Ploksteid_Motinine_Plokste`) VALUES
('TEST1', 'TEST1', 'TEST1', 'TEST1', 1, 10, 1990624),
('TEST2', 'TEST2', 'TEST2', 'TEST2', 1, 32323, 1990624),
('i9-10850K', '3.6GHZ', '125W', '5.1GHZ', 1, 6921915, 93601350),
('Celeron G5920', '3.5ghz', '58W', NULL, 1, 8197767, 19157584),
('Ryzen 5 3600', '3.2GHZ', '65W', '4.2GHZ', 2, 10497912, 87509980),
('Ryzen 7 3700X', '4.4GHZ', '65W', NULL, 2, 10820787, 70971105),
('I3-10300', '3.7GHZ', '65W', '4.4GHZ', 1, 15162536, 70485788),
('i9-9900KF', '3.6GHZ', '95W', '5GHZ', 1, 24521250, 6021611),
('I5-10500', '3.1GHZ', '65W', '4.5GHZ', 1, 27264510, 70347076),
('Ryzen 7 3800X', '4.5GHZ', '105Watts', NULL, 2, 27622290, 53130968),
('I7-10700F', '2.9GHZ', '65W', '4.8GHZ', 1, 49497253, 6021611),
('I5-10600', '3.3GHZ', '65W', '4.8GHZ', 1, 50743218, 2961312),
('I5-10600KF', '4.1GHZ', '125W', '4.8GHZ', 1, 51103346, 2583054),
('RYZEN 5 2600', '3.4GHZ', '65W', '3.9GHZ', 2, 60298025, 41487551),
('Ryzen 5 3600', '3.2GHZ', '65W', '4.2GHZ', 2, 61655674, 87509980),
('i7-9700KF', '3.60GHZ', '95W', '4.9GHZ', 1, 64090129, 82414299),
('i7-9700KF', '3.6GHZ', '95W', '4.9GHZ', 1, 70686180, 53130968),
('Core I7-10700F', '2.9GHZ', '65W', '4.8GHZ', 1, 78020098, 2583054),
('Celeron G1620T', '2.4ghz', '35W', NULL, 1, 85161482, 1106805894),
('Core i7-10700', '2.9GHZ', '65W', '4.8GHZ', 1, 87644057, 79031394),
('I5-9600KF', '3.7GHZ', '95W', '4.6GHZ', 1, 88792177, 79031394),
('i7-9700KF', '3.60GHZ', '95W', '4.9GHZ', 1, 97405288, 79031394);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `cpu_gamintojai`
--

CREATE TABLE `cpu_gamintojai` (
  `id_CPU_gamintojai` int(11) NOT NULL,
  `name` char(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sukurta duomenų kopija lentelei `cpu_gamintojai`
--

INSERT INTO `cpu_gamintojai` (`id_CPU_gamintojai`, `name`) VALUES
(1, 'Intel'),
(2, 'AMD');

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `gpu`
--

CREATE TABLE `gpu` (
  `Pavadinimas` varchar(40) NOT NULL,
  `Atminties_tipas` varchar(10) NOT NULL,
  `Atminties_greitis` varchar(10) NOT NULL,
  `Vaizdo_perdavimo_lizdai` varchar(255) NOT NULL,
  `Branduoliu_skaicius` int(11) NOT NULL,
  `Energijos_suvartojimas` varchar(10) NOT NULL,
  `Gamintojas` int(11) NOT NULL,
  `id_GPU` int(11) NOT NULL,
  `fk_Motinine_Ploksteid_Motinine_Plokste` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sukurta duomenų kopija lentelei `gpu`
--

INSERT INTO `gpu` (`Pavadinimas`, `Atminties_tipas`, `Atminties_greitis`, `Vaizdo_perdavimo_lizdai`, `Branduoliu_skaicius`, `Energijos_suvartojimas`, `Gamintojas`, `id_GPU`, `fk_Motinine_Ploksteid_Motinine_Plokste`) VALUES
('GTX 980', '4GB DDR5', '1216MHZ', '2xHDMI, DVI, DP', 2048, '165W', 1, 1171922, 82414299),
('GTX 1070', '8GB GDDR5', '1683MHZ', '2xHDMI, 1xDVI, 1xDP', 1920, '120W', 1, 1962238, 41487551),
('Radeon R7 370', '4GB DDR5', '975MHZ', '2xHDMI, DP, DVI', 1024, '190W', 2, 6353668, 1990624),
('RTX 3070', '8GB DDR6', '1730MHZ', 'HDMI, 3xDP', 5888, '220W', 1, 24140271, 70485788),
('RTX 2080 Ti', '11GB DDR6', '1500MHZ', 'HDMI, 3xDP', 4352, '260W', 1, 25539887, 2961312),
('GTX 1060', '6GB GDDR5', '1709MHZ', '4xHDMI', 1280, '150W', 1, 26419275, 1106805894),
('RTX 3090', '24GB DDR6', '1700MHZ', 'HDMI, 3xDP', 10496, '350W', 1, 27836931, 87509980),
('GT710', 'GDDR5', '954MHZ', 'DVI, HDMI, DP', 70, '10W', 1, 30499316, 11453509),
('RTX 2080', '8GB DDR6', '1710MHZ', 'HDMI, 3xDP', 2944, '225W', 1, 32911610, 93601350),
('GTX 780 Ti', '3GB DDR5', '928MHZ', '2xHDMI, 2xDVI', 2880, '250W', 1, 35974239, 6318312),
('GTX 1080', '8GB GDDR5', '1733MHZ', '2xHDMI, 2xDP', 2560, '100W', 1, 39563787, 12877617),
('Radeon R9 380', '4GB DDR5', '970MHZ', '2xHDMI, DP, DVI', 1792, '190W', 2, 42285085, 70971105),
('RTX 2070', '8GB DDR6', '1620MHZ', 'HDMI, 3xDP', 2304, '185W', 1, 47077577, 53130968),
('GTX 980 TI', '6GB DDR5', '1075MHZ', '4xHDMI', 2816, '250W', 1, 49998882, 6021611),
('RTX 3080', '10GB DDR6', '1710MHZ', 'HDMI, 3xDP', 8704, '320W', 1, 52457601, 19157584),
('Radeon R9 390x', '8GB DDR5', '1050MHZ', 'HDMI, 2xDP, DVI', 2816, '275W', 2, 54784841, 79031394),
('Radeon R7 360', '2GB DDR5', '1050MHZ', 'HDMI, DP, 2xDVI', 768, '100W', 2, 67195601, 87894087),
('Radeon R9 390', '8GB DDR5', '1000MHZ', 'HDMI, 2xDP, DVI', 2560, '275W', 2, 69722159, 42398770),
('Titan X', '12GB DDR5', '1075MHZ', '4xHDMI', 3072, '250W', 1, 85002943, 2583054),
('Radeon RX 6900', '16GB DDR6', '2285MHZ', '2xHDMI, 2xDp', 3000, '300W', 2, 96153086, 70347076);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `informacijos_saugykla`
--

CREATE TABLE `informacijos_saugykla` (
  `Pavadinimas` varchar(40) NOT NULL,
  `Tipas` varchar(10) NOT NULL,
  `Irasymo_greitis` varchar(10) NOT NULL,
  `Nuskaitymo_greitis` varchar(10) NOT NULL,
  `Talpa` varchar(10) NOT NULL,
  `id_Informacijos_Saugykla` int(11) NOT NULL,
  `fk_Motinine_Ploksteid_Motinine_Plokste` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sukurta duomenų kopija lentelei `informacijos_saugykla`
--

INSERT INTO `informacijos_saugykla` (`Pavadinimas`, `Tipas`, `Irasymo_greitis`, `Nuskaitymo_greitis`, `Talpa`, `id_Informacijos_Saugykla`, `fk_Motinine_Ploksteid_Motinine_Plokste`) VALUES
('SAMSUNG SSD 870 EVO ', 'SSD', '630MB/s', '630MB/s', '2TB', 1150804, 11453509),
(' WD Mobile Black 1TB', 'HDD', '60MB/s', '20MB/s', '1TB', 5008531, 70485788),
('DAHUA DHI-SSD-C800A', 'SSD', '450MB/s', '450MB/s', '240GB', 7904329, 87509980),
('SEAGATE Surveillance Skyhawk', 'HDD', '45MB/s', '45MB/s', '500GB', 17201974, 42398770),
(' Samsung SSD 860 PRO', 'SSD', '700MB/s', '630MB/s', '2TB', 28312700, 79031394),
('Silicon Power SSD Slim S55 ', 'SSD', '600MB/s', '400MB/s', '240GB', 28955172, 12877617),
('HDD Toshiba L200 ', 'HDD', '52MB/s', '50MB/s', '500GB', 32985356, 41487551),
('WD Blue 3.5\'\'', 'HDD', '60MB/s', '40MB/s', '500GB', 38789664, 2961312),
('SEAGATE Barracuda 5400', 'HDD', '45MB/s', '45MB/s', '2TB', 39957603, 53130968),
('Adata Ultimate SU750', 'SSD', '400MB/s', '600MB/s', '480GB', 50653286, 70485788),
('WD Blue 2TB', 'HDD', '55MB/s', '53MB/s', '1TB', 54757748, 93601350),
('WD Blue SSD SN550', 'SSD', '500MB/s', '450MB/s', '1TB', 60399688, 2961312),
('Samsung SSD 860 EVO', 'SSD', '570MB/s', '300MB/s', '1TB', 61736013, 93601350),
('SEAGATE Barracuda Pro', 'HDD', '70MB/s', '70MB/s', '1TB', 63267540, 2583054),
(' Silicon Power SSD Slim S56', 'SSD', '450MB/s', '300MB/s', '480GB', 72540787, 19157584),
('KINGSTON KC2500', 'SSD', '500MB/s', '500MB/s', '120GB', 74025025, 1106805894),
(' SEAGATE NAS IronWolf', 'HDD', '50MB/s', '50MB/s', '250GB', 85007214, 2961312),
('Toshiba Video Streaming V300', 'HDD', '80MB/s', '30MB/s', '2TB', 85135952, 19157584),
(' TOSHIBA Enterprise HDD', 'HDD', '90MB/s', '90MB/s', '2TB', 91662232, 87509980),
('Kingston SSD A400', 'SSD', '550MB/s', '600MB/s', '120GB', 92882750, 41487551);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `korpusas`
--

CREATE TABLE `korpusas` (
  `Pavadinimas` varchar(40) NOT NULL,
  `Dydis` varchar(10) NOT NULL,
  `Ausintuvai` int(11) DEFAULT NULL,
  `USB_lizdai` varchar(10) NOT NULL,
  `id_Korpusas` int(11) NOT NULL,
  `fk_Motinine_Ploksteid_Motinine_Plokste` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sukurta duomenų kopija lentelei `korpusas`
--

INSERT INTO `korpusas` (`Pavadinimas`, `Dydis`, `Ausintuvai`, `USB_lizdai`, `id_Korpusas`, `fk_Motinine_Ploksteid_Motinine_Plokste`) VALUES
('MSI Case MAG VAMPIRIC 010M', 'ATX', 1, '2', 12346321, 87894087),
(' DEEPCOOL DP-CCATX-TSRBFBK', 'ATX', 1, '2', 18482473, 2961312),
(' AEROCOOL AEROPGSSCAR', 'ATX', NULL, '4', 22303821, 1990624),
('Deepcool Quadstellar', 'ETAX', 4, '2', 24857352, 42398770),
(' AEROCOOL AEROPGSCYLONMINI', 'ATX', NULL, '3', 35966796, 42398770),
('THERMALTAKE Versa J23', 'ATX', 1, '2', 38698695, 42398770),
('DEEPCOOL DP-ATX-MATREX', 'EATX', NULL, '4', 39002258, 1990624),
('GOLDEN TIGER Raptor F-150', 'ATX', 1, '3', 39027072, 93601350),
(' AEROCOOL PGS MENACE', 'ATX', 1, '2', 45455277, 6021611),
(' Chassis IT-3303', 'ATX', 1, '3', 54086317, 70485788),
('AEROCOOL AEROPGSBOLT', 'ATX', NULL, '3', 64631812, 1990624),
(' AEROCOOL AEROPGSSTREAK', 'ATX', NULL, '3', 73326066, 93601350),
(' Deepcool Smarter', 'MicroATX', NULL, '2', 75604098, 12877617),
(' CORSAIR Carbide Series 100R', 'MidATX', NULL, '2', 77448736, 70971105),
('DEEPCOOL DP-ATX-ERLKBK', 'EATX', 1, '3', 82697348, 70971105),
('NATEC NPC-0855', 'ATX', NULL, '2', 83261011, 1106805894),
(' CHIEFTEC HT-01B', 'MicroATX', NULL, '2', 87012213, 19157584),
(' IBOX VESTA S30', 'ATX', NULL, '2', 87175809, 41487551),
('GOLDEN TIGER Baltimore 530', 'ATX', NULL, '4', 97195228, 87509980),
('iBOX PASSION V4', 'miniATX', 3, '2', 98030010, 6318312);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `maitinimo_blokas`
--

CREATE TABLE `maitinimo_blokas` (
  `Pavadinimas` varchar(40) NOT NULL,
  `Maksimali_galia` varchar(10) NOT NULL,
  `Energijos_effektybumo_reitingas` varchar(10) NOT NULL,
  `Ausintuvo_dydis` varchar(10) NOT NULL,
  `Jungikliai` varchar(30) NOT NULL,
  `id_Maitinimo_blokas` int(11) NOT NULL,
  `fk_Motinine_Ploksteid_Motinine_Plokste` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sukurta duomenų kopija lentelei `maitinimo_blokas`
--

INSERT INTO `maitinimo_blokas` (`Pavadinimas`, `Maksimali_galia`, `Energijos_effektybumo_reitingas`, `Ausintuvo_dydis`, `Jungikliai`, `id_Maitinimo_blokas`, `fk_Motinine_Ploksteid_Motinine_Plokste`) VALUES
('Deepcool DE600', '650W', 'Gold', '120MM', 'Modular', 1170777, 12877617),
('INTER-TECH Argus RGB', '500W', 'Bronze', '120MM', 'Modular', 2682712, 19157584),
('PSU HEXA+ PRO', '650W', 'Silver', '100MM', 'Non-Modular', 2860518, 70485788),
('Chieftec GPS-500A8', '500W', 'Bronze', '120MM', 'Modular', 5267750, 53130968),
('Chieftec Smart GPS-700A8', '750W', 'Platinum', '100MM', 'Non-Modular', 5314218, 2583054),
('Deepcool', '600W', 'Bronze', '120MM', 'Modular', 20257448, 93601350),
('THERMALTAKE Smart RGB', '650W', 'Gold', '100MM', 'Non-Modular', 21122030, 19157584),
('AeroCool LUX', '500W', 'Platinum', '100MM', 'Non-Modular', 22177745, 87894087),
('Supremo FM2 Gold', '750W', 'Bronze', '80MM', 'Non-Modular', 26609562, 70485788),
('Gigabyte GP-P750GM', '750W', 'Bronze', '80MM', 'Non-Modular', 30605838, 87894087),
('AEROCOOL PGS VX-750plus ', '750W', 'Bronze', '120MM', 'Modular', 50035795, 53130968),
('SILENTIUMPC Vero L3 Bronze', '750W', 'Silver', '120MM', 'Modular', 55215662, 87509980),
('Cooler Master MPE', '500W', 'Silver', '80MM', 'Non-Modular', 64999878, 11453509),
('Fortron PSU HEXA+ PRO', '600W', 'Gold', '120MM', 'Non-Modular', 70146828, 12877617),
('AeroCool VX-550', '500W', 'Bronze', '120MM', 'Modular', 73283628, 82414299),
('Chieftec ATX PROTON', '500W', 'Gold', '100MM', 'Modular', 75109631, 2583054),
('Gigabyte P650B', '750W', 'Gold', '120MM', 'Modular', 76293078, 53130968),
('IBOX AURORA', '600W', 'Gold', '120MM', 'Non-Modular', 76411541, 87509980),
('Deepcool DP-230EU-DN650', '650W', 'Bronze', '120MM', 'Modular', 91941150, 87894087),
('XILENCE', '500W', 'Gold', '80MM', 'Non-Modular', 98438099, 1990624);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `monitorius`
--

CREATE TABLE `monitorius` (
  `Pavadinimas` varchar(40) NOT NULL,
  `Dydis` varchar(40) NOT NULL,
  `Rezoliucija` varchar(40) NOT NULL,
  `Atsinaujinimu_skaicius` int(11) NOT NULL,
  `Tipas` varchar(20) NOT NULL,
  `Jungtys` varchar(255) NOT NULL,
  `id_Monitorius` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sukurta duomenų kopija lentelei `monitorius`
--

INSERT INTO `monitorius` (`Pavadinimas`, `Dydis`, `Rezoliucija`, `Atsinaujinimu_skaicius`, `Tipas`, `Jungtys`, `id_Monitorius`) VALUES
('Gaming Monitor GL2480E', '23.8 coliu', '3840x2160', 360, 'OLED', 'HDMI, DP, USB Type-C', 4070364),
('Monitor IIyama TF1734MC-B6X', '19 coliu', '1920x1080', 144, 'IPS', '15-pin D-Sub, DVI-D (su HDCP)', 10434984),
('Fujitsu B19-7 ', '17.3 coliu', '1920x1080', 144, 'LED', 'HDMI cable, USB cable', 13977126),
('LENOVO|Lenovo C22-25', '20 coliu', '1920x1080', 60, 'IPS', 'HDMI, DisplayPort', 16213463),
('DELL E2020H', '19.5 coliu', '1600x900', 60, 'LED', 'D-Sub mini 15 pin x 1, DVI-D 24 pin x 1 (with HDCP), DisplayPort x 1 (with HDCP)', 22311239),
('Asus ROG Strix XG17AHPE', '18.5 coliu', '1920x1080', 144, 'LED', 'VGA, DVI', 24573741),
('Monitorius NEC MultiSync ', '17 coliu', '1440x900', 60, 'LCD', 'HDMI, DVI-D, VGA, DisplayPort', 25113808),
('Asus VS197DE', '19 coliu', '1440x900', 60, 'LED', '15-pin D-Sub, DVI-D (su HDCP), DisplayPort', 33237920),
('Asus VB199TL LED', '17 coliu', '1280x1024', 240, 'LED IR IPS', 'HDMI, VGA, DISPLAYPORT,', 41961761),
('AOC e2260Pq', '24 coliu', '2560x1440', 60, 'LED IR IPS', '2xHDMI 1xDisplayPort', 46277990),
(' HP EliteDisplay E190i', '18.9 coliu', '1366x768', 50, 'OLED', '1 x 3,5 mm minijack, 1 x 15-pin D-Sub, 1 x HDMI, 1 x DisplayPort', 47789612),
(' DELL P1917S LED', '19 coliu', '1366x768', 50, 'LED', '15-pin D-Sub, DVI-D (su HDCP)', 51065168),
('AOC 24B2XDM', '24 coliu', '1920x1200', 175, 'CRT', 'HDMI (+ HDCP), DisplayPort', 51271558),
(' PHILIPS 172B9TL/00 B-Line', '18 coliu', '1280x1024', 240, 'LED', 'HDMI, VGA, DISPLAYPORT,', 55195934),
('iiyama B2482HS-B5', '24 coliu', '2560x1440', 144, 'LCD', '15-pin D-Sub, DisplayPort, HDMI', 61143177),
('AOC E2270SWN', '21.5 coliu', '2560x1440', 120, 'OLED', 'D-Sub mini 15 pin x 1, DVI-D 24 pin x 1 (with HDCP), DisplayPort x 1 (with HDCP)', 62620941),
('Elo Touch Solutions 1990L', '18 coliu', '1920x1080', 60, 'IPS', 'DisplayPort, HDMI, D-Sub,', 65947491),
('VIEWSONIC VX2476-SMH', '27 coliu', '3840x2160', 75, 'IPS', '15-pin D-Sub, DVI-D (su HDCP), DisplayPort, HDMI (+ HDCP)', 67148259),
('iiyama G-Master G2530H', '27 coliu', '1920x1200', 240, 'LED', '15-pin D-Sub, 2 x HDMI', 76830390),
('LG 22MK600M', '23.8 coliu', '2560x1440', 144, 'LED', 'HDMI, DisplayPort', 86207147);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `motinine_plokste`
--

CREATE TABLE `motinine_plokste` (
  `Pavadinimas` varchar(40) NOT NULL,
  `Dydis` varchar(10) NOT NULL,
  `CPU_tipas` varchar(10) NOT NULL,
  `USB_Ivestys` int(11) NOT NULL,
  `Ram_lizdai` int(11) NOT NULL,
  `PCIe_lizdai` int(11) NOT NULL,
  `M2_NVEM_lizdai` int(11) DEFAULT NULL,
  `id_Motinine_Plokste` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sukurta duomenų kopija lentelei `motinine_plokste`
--

INSERT INTO `motinine_plokste` (`Pavadinimas`, `Dydis`, `CPU_tipas`, `USB_Ivestys`, `Ram_lizdai`, `PCIe_lizdai`, `M2_NVEM_lizdai`, `id_Motinine_Plokste`) VALUES
('Gigabyte B450M Gaming AMD ', 'MicroATX', 'AMD', 6, 2, 1, 1, 1990624),
('Gigabyte Intel Z390 Express', 'ATX', 'AMD', 4, 4, 3, 1, 2583054),
('Asus Prime Z490-P Intel', 'ATX', 'Intel', 6, 4, 2, 3, 2961312),
('GIGABYTE Z490 Gaming', 'ATX', 'Intel', 6, 4, 2, 3, 6021611),
('MSI B450 Gaming PRO', 'ATX', 'AMD', 4, 4, 2, 3, 6318312),
('Asus TUF B450', 'MicroATX', 'AMD', 8, 4, 2, 1, 11453509),
('ASROCK B550 Phatom Gaming 4', 'ATX', 'AMD', 6, 4, 2, NULL, 12877617),
('Asus Intel H410 Express', 'MicroATX', 'Intel', 4, 2, 1, NULL, 19157584),
('AMD A320', 'MicroATX', 'AMD', 6, 2, 2, NULL, 41487551),
('Gigabyte AMD B450', 'MicroATX', 'AMD', 8, 4, 2, 1, 42398770),
('Asus ROG STRIX B460', 'ATX', 'Intel', 6, 4, 2, 0, 53130968),
('MSI B450 TOMAHAWK MAX II', 'ATX', 'AMD', 4, 4, 1, NULL, 70347076),
('Asus ORG STRIX B450-I Gaming', 'Mini-ITX', 'Intel', 6, 2, 1, NULL, 70485788),
('Gigabyte AMD B550', 'ATX', 'AMD', 4, 4, 4, NULL, 70971105),
('Asus Tuf Gaming B550M-plus', 'MicroATX', 'AMD', 6, 4, 2, 2, 79031394),
('H310M', 'MicroATX', 'Intel', 6, 2, 1, NULL, 82414299),
('Asus AMD B550', 'ATX', 'AMD', 4, 4, 2, 3, 87509980),
('Gigabyte B550', 'ATX', 'AMD', 6, 4, 2, 1, 87894087),
('ASUS ROG B460-G', 'ATX', 'Intel', 6, 4, 2, 1, 93601350),
('A320M-DVS', 'MicroATX', 'AMD', 6, 2, 1, NULL, 1106805894);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `ram`
--

CREATE TABLE `ram` (
  `Pavadinimas` varchar(40) NOT NULL,
  `Talpa` varchar(10) NOT NULL,
  `Atminties_Tipas` varchar(10) NOT NULL,
  `Ram_greitis` varchar(10) NOT NULL,
  `Dydis` varchar(10) NOT NULL,
  `Papildomi_atributai` varchar(255) DEFAULT NULL,
  `id_RAM` int(11) NOT NULL,
  `fk_Motinine_Ploksteid_Motinine_Plokste` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sukurta duomenų kopija lentelei `ram`
--

INSERT INTO `ram` (`Pavadinimas`, `Talpa`, `Atminties_Tipas`, `Ram_greitis`, `Dydis`, `Papildomi_atributai`, `id_RAM`, `fk_Motinine_Ploksteid_Motinine_Plokste`) VALUES
('ads', 'das', 'das', 'das', 'asd', 'd', 2, 1990624),
('dfg', 'sdrfg', 'dfg', 'dfg', 'dfg', 'dfg', 3, 82414299),
('F4-3200C14D-16GVR', '4GB', 'DDR3', '1333MHZ', 'DIMM', NULL, 3394185, 41487551),
('TTCCD432G3200HC22DC01', '16GB', 'DDR3', '1866MHZ', 'DIMM', 'HEATSINK', 6363376, 87509980),
('TED432G3200C2201', '32GB', 'DDR4', '2400MHZ', 'DIMM', NULL, 8517111, 19157584),
('KINGSTON 4GB DDR3L', '4GB', 'DDR3', '1600MHZ', 'DIMM', 'RGB,', 11543714, 70485788),
('G.Skill Ripjaws', '4GB', 'DDR3', '1600MHZ', 'DIMM', NULL, 12713439, 1106805894),
('F4-3800C18D-16GTZN', '16GB', 'DDR4', '2666MHZ', 'DIMM', 'HEATSINK', 19373916, 70485788),
('MEMORY DIMM 8GB', '8GB', 'DDR4', '2133MHZ', 'DIMM', 'RGB, HEATSINK', 29380606, 70347076),
('GOODRAM IRDM X', '16GB', 'DDR4', '3000MHZ', 'DIMM', 'HEATSINK', 30000378, 42398770),
('G.Skill Aegis DDR4', '8GB', 'DDR4', '2400MHZ', 'DIMM', 'HEATSINK', 32413779, 11453509),
('DDR3 Corsair', '4GB', 'DDR3', '1333MHZ', 'DIMM', NULL, 32424821, 41487551),
('TF10D416G3200HC16CD', '8GB', 'DDR3', '1600MHZ', 'DIMM', NULL, 36159338, 12877617),
('G.Skill Aegis', '16GB', 'DDR4', '2666MHZ', 'DIMM', NULL, 39965602, 79031394),
('F4-3600C16D-16GTZNC', '4GB', 'DDR3', '3200Mhz', 'DIMM', 'HEATSINK', 41801427, 11453509),
('G.SKILL DDR3', '4GB', 'DDR3', '1600MHZ', 'SODIMM', 'RGB, Heatsink', 45386891, 12877617),
('F4-3200C16D-16GTRG', '8GB', 'DDR4', '3000MHZ', 'DIMM', NULL, 45779680, 2961312),
('TF10D416G3600HC18JDC01', '32GB', 'DDR4', '2133MHZ', 'DIMM', NULL, 48874471, 19157584),
('Team Group DDR4', '8GB', 'DDR4', '2666MHZ', 'DIMM', 'RGB, HEATSINK', 50319118, 70971105),
(' SILICON POWER DDR4', '4GB', 'DDR3', '2666MHZ', 'SODIMM', NULL, 56818715, 53130968),
('Team Group DDR3', '8GB', 'DDR3', '1600MHZ', 'DIMM', NULL, 62300171, 42398770),
('F4-3200C14D-16GTZ', '2GB', 'DDR3', '800Mhz', 'DIMM', 'HEATSINK, RGB', 65914352, 79031394),
('DDR3 Kingston', '4GB', 'DDR3', '1600MHZ', 'DIMM', NULL, 70333217, 87509980),
('Corsair Vengeance LPX', '16GB', 'DDR4', '3200MHZ', 'DIMM', NULL, 71606085, 11453509),
('G.Skill Ripjaws', '4GB', 'DDR3', '1333MHZ', 'DIMM', 'HEATSINK', 71631414, 19157584),
('F4-3000C14D-16GTZR', '2GB', 'DDR2', '1066MHZ', 'DIMM', 'HEATSINK', 71899022, 1106805894),
('Silicon Power DDR4', '8GB', 'DDR4', '2400MHZ', 'DIMM', NULL, 74676615, 87509980),
('G.Skill DDR4', '8GB', 'DDR4', '3200MHZ', 'DIMM', NULL, 81667945, 79031394),
('Team Group DDR3', '8GB', 'DDR3', '1333MHZ', 'DIMM', NULL, 84247184, 70971105),
('DDR3 Patriot', '8GB', 'DDR3', '1600MHZ', 'DIMM', NULL, 89929023, 11453509),
('Lexar Desktop Memory', '16GB', 'DDR4', '2400MHZ', 'DIMM', NULL, 94106742, 19157584),
('Kingston HyperX FURY', '16GB', 'DDR4', '2666MHZ', 'DIMM', NULL, 95198596, 87509980);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `rodo_vaizda`
--

CREATE TABLE `rodo_vaizda` (
  `fk_Monitoriusid_Monitorius` int(11) NOT NULL,
  `fk_GPUid_GPU` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sukurta duomenų kopija lentelei `rodo_vaizda`
--

INSERT INTO `rodo_vaizda` (`fk_Monitoriusid_Monitorius`, `fk_GPUid_GPU`) VALUES
(4070364, 39563787),
(10434984, 67195601),
(13977126, 32911610),
(16213463, 52457601),
(22311239, 27836931),
(24573741, 24140271),
(25113808, 67195601),
(33237920, 26419275),
(41961761, 25539887),
(46277990, 1962238),
(47789612, 42285085),
(51065168, 27836931),
(51271558, 1171922),
(55195934, 85002943),
(61143177, 47077577),
(62620941, 6353668),
(65947491, 32911610),
(67148259, 85002943),
(76830390, 47077577),
(86207147, 52457601);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `vaizdo_ploksciu_gamintojai`
--

CREATE TABLE `vaizdo_ploksciu_gamintojai` (
  `id_Vaizdo_ploksciu_gamintojai` int(11) NOT NULL,
  `name` char(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sukurta duomenų kopija lentelei `vaizdo_ploksciu_gamintojai`
--

INSERT INTO `vaizdo_ploksciu_gamintojai` (`id_Vaizdo_ploksciu_gamintojai`, `name`) VALUES
(1, 'Nvidia'),
(2, 'AMD');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `aušintuvai`
--
ALTER TABLE `aušintuvai`
  ADD PRIMARY KEY (`id_Aušintuvai`),
  ADD KEY `ausina` (`fk_CPUid_CPU`);

--
-- Indexes for table `cpu`
--
ALTER TABLE `cpu`
  ADD PRIMARY KEY (`id_CPU`),
  ADD KEY `Gamintojas` (`Gamintojas`),
  ADD KEY `atlieka_skaiciavimus` (`fk_Motinine_Ploksteid_Motinine_Plokste`);

--
-- Indexes for table `cpu_gamintojai`
--
ALTER TABLE `cpu_gamintojai`
  ADD PRIMARY KEY (`id_CPU_gamintojai`);

--
-- Indexes for table `gpu`
--
ALTER TABLE `gpu`
  ADD PRIMARY KEY (`id_GPU`),
  ADD KEY `Gamintojas` (`Gamintojas`),
  ADD KEY `generuoja_vaizda` (`fk_Motinine_Ploksteid_Motinine_Plokste`);

--
-- Indexes for table `informacijos_saugykla`
--
ALTER TABLE `informacijos_saugykla`
  ADD PRIMARY KEY (`id_Informacijos_Saugykla`),
  ADD KEY `kaupia_informacija` (`fk_Motinine_Ploksteid_Motinine_Plokste`);

--
-- Indexes for table `korpusas`
--
ALTER TABLE `korpusas`
  ADD PRIMARY KEY (`id_Korpusas`),
  ADD KEY `laiko_viska` (`fk_Motinine_Ploksteid_Motinine_Plokste`);

--
-- Indexes for table `maitinimo_blokas`
--
ALTER TABLE `maitinimo_blokas`
  ADD PRIMARY KEY (`id_Maitinimo_blokas`),
  ADD KEY `teikia_energija` (`fk_Motinine_Ploksteid_Motinine_Plokste`);

--
-- Indexes for table `monitorius`
--
ALTER TABLE `monitorius`
  ADD PRIMARY KEY (`id_Monitorius`);

--
-- Indexes for table `motinine_plokste`
--
ALTER TABLE `motinine_plokste`
  ADD PRIMARY KEY (`id_Motinine_Plokste`);

--
-- Indexes for table `ram`
--
ALTER TABLE `ram`
  ADD PRIMARY KEY (`id_RAM`),
  ADD KEY `prisijungia` (`fk_Motinine_Ploksteid_Motinine_Plokste`);

--
-- Indexes for table `rodo_vaizda`
--
ALTER TABLE `rodo_vaizda`
  ADD PRIMARY KEY (`fk_Monitoriusid_Monitorius`,`fk_GPUid_GPU`);

--
-- Indexes for table `vaizdo_ploksciu_gamintojai`
--
ALTER TABLE `vaizdo_ploksciu_gamintojai`
  ADD PRIMARY KEY (`id_Vaizdo_ploksciu_gamintojai`);

--
-- Apribojimai eksportuotom lentelėm
--

--
-- Apribojimai lentelei `aušintuvai`
--
ALTER TABLE `aušintuvai`
  ADD CONSTRAINT `ausina` FOREIGN KEY (`fk_CPUid_CPU`) REFERENCES `cpu` (`id_CPU`);

--
-- Apribojimai lentelei `cpu`
--
ALTER TABLE `cpu`
  ADD CONSTRAINT `atlieka_skaiciavimus` FOREIGN KEY (`fk_Motinine_Ploksteid_Motinine_Plokste`) REFERENCES `motinine_plokste` (`id_Motinine_Plokste`),
  ADD CONSTRAINT `cpu_ibfk_1` FOREIGN KEY (`Gamintojas`) REFERENCES `cpu_gamintojai` (`id_CPU_gamintojai`);

--
-- Apribojimai lentelei `gpu`
--
ALTER TABLE `gpu`
  ADD CONSTRAINT `generuoja_vaizda` FOREIGN KEY (`fk_Motinine_Ploksteid_Motinine_Plokste`) REFERENCES `motinine_plokste` (`id_Motinine_Plokste`),
  ADD CONSTRAINT `gpu_ibfk_1` FOREIGN KEY (`Gamintojas`) REFERENCES `vaizdo_ploksciu_gamintojai` (`id_Vaizdo_ploksciu_gamintojai`);

--
-- Apribojimai lentelei `informacijos_saugykla`
--
ALTER TABLE `informacijos_saugykla`
  ADD CONSTRAINT `kaupia_informacija` FOREIGN KEY (`fk_Motinine_Ploksteid_Motinine_Plokste`) REFERENCES `motinine_plokste` (`id_Motinine_Plokste`);

--
-- Apribojimai lentelei `korpusas`
--
ALTER TABLE `korpusas`
  ADD CONSTRAINT `laiko_viska` FOREIGN KEY (`fk_Motinine_Ploksteid_Motinine_Plokste`) REFERENCES `motinine_plokste` (`id_Motinine_Plokste`);

--
-- Apribojimai lentelei `maitinimo_blokas`
--
ALTER TABLE `maitinimo_blokas`
  ADD CONSTRAINT `teikia_energija` FOREIGN KEY (`fk_Motinine_Ploksteid_Motinine_Plokste`) REFERENCES `motinine_plokste` (`id_Motinine_Plokste`);

--
-- Apribojimai lentelei `ram`
--
ALTER TABLE `ram`
  ADD CONSTRAINT `prisijungia` FOREIGN KEY (`fk_Motinine_Ploksteid_Motinine_Plokste`) REFERENCES `motinine_plokste` (`id_Motinine_Plokste`);

--
-- Apribojimai lentelei `rodo_vaizda`
--
ALTER TABLE `rodo_vaizda`
  ADD CONSTRAINT `rodo_vaizda` FOREIGN KEY (`fk_Monitoriusid_Monitorius`) REFERENCES `monitorius` (`id_Monitorius`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
