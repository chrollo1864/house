-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 21, 2025 at 02:17 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `backup`
--

-- --------------------------------------------------------

--
-- Table structure for table `houses`
--

CREATE TABLE `houses` (
  `Id` int(11) NOT NULL,
  `Address` longtext NOT NULL,
  `Bedrooms` int(11) NOT NULL,
  `Price` decimal(10,2) NOT NULL,
  `IsAvailable` tinyint(1) NOT NULL,
  `Title` longtext NOT NULL,
  `Description` longtext NOT NULL,
  `ImageUrl` longtext NOT NULL,
  `LocationId` int(11) NOT NULL DEFAULT 0,
  `PropertyTypeId` int(11) NOT NULL DEFAULT 0,
  `Size` decimal(10,2) NOT NULL DEFAULT 0.00,
  `RegisteredDate` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  `IsFeatured` tinyint(1) NOT NULL DEFAULT 0,
  `CreatedAt` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `houses`
--

INSERT INTO `houses` (`Id`, `Address`, `Bedrooms`, `Price`, `IsAvailable`, `Title`, `Description`, `ImageUrl`, `LocationId`, `PropertyTypeId`, `Size`, `RegisteredDate`, `IsFeatured`, `CreatedAt`) VALUES
(16, '123 Maple Street Lane, Brgy Makati ', 3, 655900.00, 1, 'Cozy Small House', 'This home offers a warm and inviting atmosphere, perfect for simple living.\r\n\r\nBedrooms: 3, Bathroom: 2, Sq. Ft: 1908, Floor: 2\r\nLocation: Manila, Luzon Philippines', '/uploads/houses/ccf4a451-f04c-455b-a5c7-1079880cbdec_SFH M L.png', 1, 1, 1908.00, '2025-04-19 12:02:22.410872', 1, '0001-01-01 00:00:00.000000'),
(17, '143 Lantern Ridge Street, Brgy Amihan', 2, 455900.00, 1, 'Minimalist House', 'This home is designed with clean lines, open spaces, and a neutral colour palette, good for a family looking for a calm and warmth in they\'re living.\r\n\r\nBedrooms: 2, Bathrooms: 2, Sq. Ft: 1064, Floors: 1\r\nLocation: Quezon City, Luzon Philippines', '/uploads/houses/9a477bad-3f6b-4525-a011-b44a6afaf56c_SFH QC L.png', 2, 1, 1064.00, '2025-04-19 12:38:31.266407', 1, '0001-01-01 00:00:00.000000'),
(18, '502 Willow Street, Brgy Basak San Nicholas', 3, 554500.00, 1, 'Whimsy House', 'This home blends with a design of a cottage charm, think whitewashed walls, minimalist textures which is the look for simplicity.\r\n\r\nBedrooms: 3, Bathrooms: 2, Sq, Ft: 1250, Floor: 1\r\nLocation: Cebu City, Visayas Philippines', '/uploads/houses/6eb9f611-9e78-4b3d-80b8-ddff999e3e70_SFH CC V.png', 3, 1, 1250.00, '2025-04-19 12:50:34.661037', 1, '0001-01-01 00:00:00.000000'),
(19, '310 Pebble Lane Street, Brgy Barake, Aborlan', 3, 479900.00, 1, 'Tiny Sanctuary House', 'This home is built for families who are looking for clean aesthetic, and neat design with a peaceful place to live in.\r\n\r\nBedrooms: 3, Bathroom: 2, Sq. Ft: 1300, Floor: 1\r\nLocation: Palawan, Luzon Philippines', '/uploads/houses/dea8a1a5-cac5-4190-80cf-04d404b8bbee_SFH P L.png', 4, 1, 1300.00, '2025-04-19 13:15:09.338904', 1, '0001-01-01 00:00:00.000000'),
(20, '659 Sunbeam Avenue Street, Brgy Balabag', 3, 695600.00, 1, 'Gable Shack House', 'This home may be compact but full of character, it uses big windows to bring in light and warmth, turning this tiny spot into a cozy living home.\r\n\r\nBedrooms: 3, Bathrooms: 2, Sq. Ft: 1480, Floor: 1\r\nLocation: Boracay, Visayas Philippines', '/uploads/houses/c178ae88-096e-4c04-a5a0-548fdc831eb9_SFH BR V.png', 5, 1, 1480.00, '2025-04-19 13:26:13.061823', 1, '0001-01-01 00:00:00.000000'),
(21, '433 Magnolia Street, Brgy West Poblacion, Alburguergue', 2, 465700.00, 1, 'Tiny Frame House', 'This minimalist home features a boxy, modern soft exterior, with neutral tones and clean-living spaces, perfect for a small family\r\n\r\nBedrooms: 2, Bathrooms: 2, Sq. Ft: 1284, Floor: 1\r\nLocation: Bohol, Visayas Philippines', '/uploads/houses/96058b7b-d2f8-4953-9e11-bac2b6640cfb_SFH BH V.png', 6, 1, 1284.00, '2025-04-19 13:31:17.711898', 1, '0001-01-01 00:00:00.000000'),
(22, '863 Pine Way Street, Brgy West Tondo ', 2, 17500.00, 1, 'Nova Flats Apartment', 'This high-rise apartment is a studio wall-to-wall windows and a private balcony, it is a perfect living for those that are looking for minimalist layout. Each flat is available for rent\r\n\r\nBedrooms: 2, Bathrooms: 1, Sq. Ft: 953, Stories: 4\r\nLocation: Manila, Luzon Philippines', '/uploads/houses/fab7bb38-a2e5-40e9-ae9f-a3109298b557_A M L.png', 1, 2, 953.00, '2025-04-19 13:45:23.941590', 1, '0001-01-01 00:00:00.000000'),
(23, '121 Clover Hill Street, Brgy Damayan', 2, 17500.00, 1, 'Solace Flats Apartment', 'This apartment offers a sleek, compact living space with your own private balcony for more minimalist style. Each flat is available for rent\r\n\r\nBedrooms: 2, Bathrooms: 1, Sq. Ft: 900, Stories: 3\r\nLocation: Quezon City, Luzon Philippines\r\n', '/uploads/houses/ba59a71b-5327-46a0-8d8f-6aa7f5bfb299_A QC L.png', 2, 2, 900.00, '2025-04-19 14:21:05.310657', 1, '0001-01-01 00:00:00.000000'),
(24, '583 Misty Brook Street, Brgy South Bulacao', 3, 22500.00, 1, 'Modera Place Apartment', 'This apartment is designed like a house, it is built for families and even students. Each flat is available for rent.\r\n\r\nBedrooms: 3, Bathrooms: 3, Sq. Ft: 3595, Stories: 3\r\nLocation: Cebu City, Visayas Philippines', '/uploads/houses/400136bd-eb70-451c-87ca-f2a8c59d8611_A CC V.png', 3, 2, 3595.00, '2025-04-19 16:07:05.699277', 1, '0001-01-01 00:00:00.000000'),
(25, '703 Oakshade Court Street, Brgy Mabini Aborlan', 3, 34500.00, 1, 'Luna Heights Beach Style Apartment', 'This apartment that is designed like a modern beach style home is available for those who wants to live in a bit of luxury, the whole apartment is available for rent.\r\n\r\nBedrooms: 3, Bathrooms: 3, Sq. Ft: 3812\r\nLocation: Palawan, Luzon Philippines', '/uploads/houses/648d3751-69e9-4969-825a-597df60db791_A P L.png', 4, 2, 3812.00, '2025-04-19 16:14:13.783758', 1, '0001-01-01 00:00:00.000000'),
(26, '836 Bluebird Moon Street, Brgy Yapak Malay', 4, 30000.00, 1, 'Urban Nook Apartments', 'This urban apartment is modern and heart of the city with its homely shape but architecturally industrial, it is for families looking for a home in the suburbs. The whole place is available for rent.\r\n\r\nBedrooms: 4, Bathrooms: 3, Sq. Ft: 2197, Stories: 3\r\nLocation: Boracay, Visayas Philippines', '/uploads/houses/390847cd-ec7f-4976-a927-9de20c913ed1_A BR V.png', 5, 2, 2197.00, '2025-04-19 16:23:57.257607', 1, '0001-01-01 00:00:00.000000'),
(27, '926 Meadow Birch Street, Brgy La Hacienda Alicia', 3, 25000.00, 1, 'Minimalist House Apartment', 'This apartment is design like a home for those who wants to live in a classic house. The whole place is available for rent.\r\n\r\nBedrooms: 3, Bathrooms: 3, Sq. Ft: 1701, Stories: 3\r\nLocation: Bohol, Visayas Philippines', '/uploads/houses/6954f170-a729-483c-bef0-15d2019cb6e7_A BH V.png', 6, 2, 1701.00, '2025-04-19 17:21:18.182209', 1, '0001-01-01 00:00:00.000000'),
(28, '202 Glenmoor Avenue Street, Brgy Muntinlupa', 2, 98700.00, 1, 'Cobblestone Row Townhouse', 'This luxurious modern housing is designed for living in high-end taste with it\'s matte and sleek features perfect for families. This is available for rent.\r\n\r\nBedrooms: 2, Bathrooms: 2, Sq. Ft: 1674, Stories: 3\r\nLocation: Manila, Luzon Philippines', '/uploads/houses/99dbca5c-d261-4d5f-830b-e6c4ae38d687_TH M L.png', 1, 3, 1674.00, '2025-04-20 11:49:28.623928', 1, '0001-01-01 00:00:00.000000'),
(29, '927 Eastfield View Street, Brgy Salvacion La Loma', 2, 102500.00, 1, 'Sterling Villa Townhouses', 'This town housing in the suburban community is a luxury with a fresh modern design, having your own private garage and spacious floors.\r\n\r\nBedrooms: 2, Bathrooms: 2, Sq. Ft: 1809, Stories: 3 \r\nLocation: Quezon City, Luzon Philippines', '/uploads/houses/8ea4b0ac-9cf0-4a09-8ab3-53746d8359ab_TH QC L.png', 2, 3, 1809.00, '2025-04-20 11:57:24.270808', 1, '0001-01-01 00:00:00.000000'),
(30, '392 Alder Stone Street, Brgy Lorega San Miguel ', 2, 98500.00, 1, 'Industrial Luxe Townhouse', 'This industrial housing is perfect for those who wants a high-end designed with open build windows at the front for building a business or having a bold charm. It is available for rent\r\n\r\nBedrooms: 2, Bathrooms: 2, Sq. Ft: 1650, Stories: 3\r\nLocation: Cebu City, Visayas Philippines', '/uploads/houses/2b14a3e6-1c33-46c3-bee0-b72fe64cb9ea_TH CC V.png', 3, 3, 1650.00, '2025-04-20 12:05:49.329744', 1, '0001-01-01 00:00:00.000000'),
(31, '628 Bellmont Residence Street, Brgy Pangobilian Brooke\'s Point', 3, 105200.00, 1, 'Luxe Bellmont Townhouse', 'This residential townhouse is designed for those who are looking for community housing with own garage and privacy, built for families. This is available for rent.\r\n\r\nBedrooms: 3, Bathrooms: 2, Sq. Ft: 1780, Stories: 2\r\nLocation: Palawan, Luzon Philippines', '/uploads/houses/2c12e7ea-d9f4-4645-803a-4778b0a1f5f9_TH P L.png', 4, 3, 1780.00, '2025-04-20 12:46:34.860063', 1, '0001-01-01 00:00:00.000000'),
(32, '194 Parkview Road Street, Brgy Manoc-Manoc', 2, 95300.00, 1, 'Parkview Townhouse', 'This housing designed for contemporary living is one way to make yourself feel at home with its nature and own garage. This is available for rent.\r\n\r\nBedrooms: 2, Bathrooms: 2, Sq. Ft: 1630, Stories: 2\r\nLocation: Boracay, Visayas Philippines', '/uploads/houses/59f7bfe3-fc1c-47d1-8458-8ccc84158090_TH BR V.png', 5, 3, 1630.00, '2025-04-20 13:17:44.752140', 1, '0001-01-01 00:00:00.000000'),
(33, '482 Highland Avenue Street, Brgy Antequera', 2, 55000.00, 1, 'Highland Avenue Townhouse', 'This housing is built like a modern apartment but with modern white sheek designed for families or students. This is available for rent.\r\n\r\nBedrooms: 2, Bathrooms: 1, Sq. Ft: 1205, Floor: 1', '/uploads/houses/e793aebb-7403-49af-be44-bdc0eee2ffcd_TH BH V.png', 6, 3, 1205.00, '2025-04-20 13:28:01.462130', 1, '0001-01-01 00:00:00.000000'),
(34, '238 Camellia Street, Brgy Valenzuela', 3, 37500.00, 1, 'Camellia Way Condo', 'This modern condo community is offering a house designed condos perfect for those who are looking to experience comfort and stylish living. This place is available for shared rent.\r\n\r\nBedrooms: 3, Bathrooms: 2, Sq. Ft: 1969, Stories: 3\r\nLocation: Manila, Luzon Philippines', '/uploads/houses/5c039975-0116-4d5c-a868-dd0a4181cc9f_C M L.png', 1, 4, 1969.00, '2025-04-20 18:46:06.489613', 1, '0001-01-01 00:00:00.000000'),
(35, '593 Meadowbrook Lane Street, Brgy Immaculate Conception Cubao', 4, 42000.00, 1, 'Grand Meadow Condo', 'This resident housing is a modern comfort designed for effortless living, perfect space looking for luxury and style even having your own garage. This is available for rent\r\n\r\nBedrooms: 4, Bathrooms: 3, Sq. Ft: 2897, Stories 3\r\nLocation: Quezon City, Luzon Philippines ', '/uploads/houses/55cd6c06-5840-423f-8fc2-c073e29e70b5_C QC L.png', 2, 4, 2897.00, '2025-04-20 20:12:00.686470', 1, '0001-01-01 00:00:00.000000'),
(36, '866 Brookline North Street, Brgy Zapatera North', 4, 42500.00, 1, 'Brookline North Residence Condo', 'This residential housing is built for a community which is charming and warm exterior for upscale living. This is available for rent\r\n\r\nBedrooms: 4, Bathrooms: 3, Sq. Ft: 2897, Stories: 3\r\nLocation: Cebu City, Visayas Philippines', '/uploads/houses/b8f44710-aa4d-4cda-9746-00b0745f9fea_C CC V.png', 3, 4, 2897.00, '2025-04-20 20:40:20.215176', 1, '0001-01-01 00:00:00.000000'),
(37, '885 Sunset Building Street, Brgy New Barbacan Roxas', 3, 49000.00, 1, 'Sunset Building Condo', 'This housing is a contemporary comfort which chich white marbles and matte finish for elegance look. This place is available for rent.\r\n\r\nBedrooms: 3, Bathrooms: 2, Sq. Ft: 1384, Stories: 3\r\nLocation: Palawan, Luzon Philippines', '/uploads/houses/da31b0cd-a817-468e-a03c-8c50dfb34416_C P L.png', 4, 4, 1384.00, '2025-04-21 09:54:03.691306', 1, '0001-01-01 00:00:00.000000'),
(38, '934 Olive Street, Brgy Yapak Aklan', 2, 45000.00, 1, 'Emberline Residence Condo', 'This housing with warm exterior and homely luxury is perfect for those who have families with even having a basement. This place is available for rent.\r\n\r\nBedrooms: 2, Bathrooms: 2, Sq. Ft: 1222, Floors: 3\r\nLocation: Boracay, Visayas Philippines', '/uploads/houses/ec028ecf-28d8-4a85-b6c3-9185e52b8da3_C BR V.png', 5, 4, 1222.00, '2025-04-21 09:59:11.110699', 1, '0001-01-01 00:00:00.000000'),
(39, '231 Windy Hill Street, Brgy Alejawan Duero', 4, 50000.00, 1, 'Lumina Residence Condo', 'This housing is a blend of classic and comfort, it is perfect for families or students who wants to share spaces. The place is available for rent\r\n\r\nBedrooms: 4, Bathrooms: 3, Sq. Ft: 2543, Stories: 3\r\nLocation: Bohol, Visayas Philippines', '/uploads/houses/faab83f2-7a4d-46d6-96b2-2648013dac41_C BH V.png', 6, 4, 2543.00, '2025-04-21 10:04:47.341716', 1, '0001-01-01 00:00:00.000000'),
(40, '731 Riverstone Avenue Street, Brgy Bel-Air Makati', 4, 67836288.00, 1, 'Bella Vista Estate Villa', 'This villa is a classic architecture with hilltop views and marble finishes. \r\n\r\nBedroom: 4, Bathrooms: 5, Sq. Ft: 5564\r\nLocation: Manila, Luzon Philippines', '/uploads/houses/657dd42f-cec3-4857-81fc-ac80d5700632_VL M L.png', 1, 5, 5564.00, '2025-04-21 10:43:27.992059', 1, '0001-01-01 00:00:00.000000'),
(41, '283 Winding Brook Lane Street, Brgy Sacred Heart Scout Area', 4, 56436768.00, 1, 'Winding Brook Villa', 'This villa is designed with rustic charm meets timeless beauty in this modern contemporary inspired place.\r\n\r\nBedrooms: 4, Bathrooms: 5, Sq. Ft: 4629, Floors: 2\r\nLocation: Quezon City, Luzon Philippines', '/uploads/houses/a1932dad-4c7c-4866-a2d4-821889f3131d_VL QC L.png', 2, 5, 4629.00, '2025-04-21 10:56:43.425225', 1, '0001-01-01 00:00:00.000000'),
(42, '199 Pine Hollow Street, Brgy Ermita North', 4, 87951136.00, 1, 'Pinestone VIlla', 'This villa is designed like colonial greek architecture, for those who wants to live in a craftsman art of construction.\r\n\r\nBedrooms: 4, Bathrooms: 5, Sq. Ft: 3933, Floors: 3\r\nLocation: Cebu City, Visayas Philippines', '/uploads/houses/601d716f-3f52-4fd8-b03f-a19511ad231c_VL CC V.png', 3, 5, 3933.00, '2025-04-21 11:04:00.157073', 1, '0001-01-01 00:00:00.000000'),
(43, '946 Elm Tranquilla Street, Brgy New Canipo San Vicente', 4, 50401728.00, 1, 'Tranquila Villa', 'This villa is sweeping hill place, with marble finishes and a classic architecture for luxury living.\r\n\r\nBedrooms: 4, Bathrooms: 5, Sq. Ft: 4134, Floors: 2\r\nLocation: Palawan, Luzon Philippines', '/uploads/houses/561d5c2a-6ad7-47a0-a6b5-20a3bcfd9ef5_VL P L.png', 4, 5, 4134.00, '2025-04-21 11:08:51.825317', 1, '0001-01-01 00:00:00.000000'),
(44, '763 Birchbend Street, Brgy Balabag Aklan', 5, 95941658.00, 1, 'Solara Birchbend Villa', 'This villa is designed with rounded entry and Corinthian columns that sets the bar high for any homes as the front is detailed for luxury.\r\n\r\nBedrooms: 5, Bathrooms: 5, Sq. Ft: 5503, Floors: 2\r\nLocation: Boracay, Visayas Philippines', '/uploads/houses/af5242ab-118d-4573-b7bf-89492829b8a7_VL BR V.png', 5, 5, 5503.00, '2025-04-21 11:17:16.130592', 1, '0001-01-01 00:00:00.000000'),
(45, '663 Casa Avenue Street, Brgy Malijao Dimiao', 5, 56839104.00, 1, 'Casa Del Mar Villa', 'This villa is a beautiful modern contemporary home, the design balances luxury with functional living.\r\n\r\nBedrooms: 5, Bathrooms: 6, Sq. Ft: 4662, Floors: 2\r\nLocation: Bohol, Visayas Philippines', '/uploads/houses/6ba11e34-666f-48d9-80d5-549238910ba1_VL BH V.png', 6, 5, 4662.00, '2025-04-21 11:21:26.632542', 1, '0001-01-01 00:00:00.000000'),
(46, '347 Pairie Lane Street, Brgy San Lorenzo', 5, 48230000.00, 1, 'Noirwood Modern House', 'This modern housing is designed sleek and matte charm this has its own garage and open windows.\r\n\r\nBedrooms: 5, Bathrooms: 5, Sq. Ft: 4823, Floors: 2\r\nLocation: Manila, Luzon Philippines', '/uploads/houses/238a03a7-3970-432e-ae4f-cd992f3be423_MH M L.png', 1, 6, 4823.00, '2025-04-21 11:44:23.263845', 1, '0001-01-01 00:00:00.000000'),
(47, '474 Horizon Haus Street, Brgy San Isidro Galas ', 3, 27490000.00, 1, 'Horizon Haus Modern House', 'This modern house is design with unique angles and architectural boldness, having its own garage.\r\n\r\nBedrooms: 3, Bathrooms: 2, Sq. Ft: 2749, Floors: 1\r\nLocation: Quezon City, Luzon Philippines', '/uploads/houses/dace0e26-400b-4b9d-a997-45ac59535ceb_MH QC L.png', 2, 6, 2749.00, '2025-04-21 11:51:08.268379', 1, '0001-01-01 00:00:00.000000'),
(48, '798 Havenwood Street, Brgy San Roque ', 4, 34610000.00, 1, 'Havenwood Modern House', 'This modern housing is beautiful 2 story contemporary style house, with it\'s modern architectural design having its own garage.\r\n\r\nBedrooms: 4, Bathrooms: 4, Sq. Ft: 3461, Floors: 2\r\nLocation: Cebu City, Visayas Philippines', '/uploads/houses/5afe18df-f9b4-4f7e-a17a-79e0b4a40dfc_MH CC V.png', 3, 6, 3461.00, '2025-04-21 12:02:08.348585', 1, '0001-01-01 00:00:00.000000'),
(49, '634 Sunflower Road Street, Brgy Barangonan Linapacan', 4, 41065000.00, 1, 'Amoura Modern House', 'This modern housing is a luxury contemporary style house having its modern white matte brick and wood look, with its own garage\r\n\r\nBedrooms: 4, Bathrooms: 3, Sq. Ft: 4106, Floors: 2\r\nLocation: Palawan, Luzon Philippines', '/uploads/houses/d5f2a09f-650f-415b-9f53-39a5e235bbac_MH P L.png', 4, 6, 4106.00, '2025-04-21 12:05:33.787124', 1, '0001-01-01 00:00:00.000000'),
(50, '382 Harbor Road Street, Brgy Manoc-Manoc Aklan', 3, 28153800.00, 1, 'Serene Modern House', 'This modern housing, is an intricate design that is architecturally unique with its slanted one side roof and sleek balcony with the garage\r\n\r\nBedrooms: 3, Bathrooms: 2, Sq. Ft: 1853, Floors: 2\r\nLocation: Boracay, Visayas Philippines', '/uploads/houses/9e3ef89e-2b54-427b-af88-691cfec31d44_MH BR V.png', 5, 6, 1853.00, '2025-04-21 12:10:48.497129', 1, '0001-01-01 00:00:00.000000'),
(51, '537 Coral Pearl Street, Brgy Tupas Antequera', 4, 78360300.00, 1, 'Coral Pearl Modern House', 'This modern housing is spacious contemporary style with its own garage and a box but modern design\r\n\r\nBedrooms: 4, Bathrooms: 3, Sq. Ft: 3008, Floors: 2\r\nLocation: Bohol, Visayas Philippines', '/uploads/houses/7d79729c-5c4a-45ed-abb1-6ebd15e7b80b_MH BH V.png', 6, 6, 3008.00, '2025-04-21 12:13:58.070430', 1, '0001-01-01 00:00:00.000000');

-- --------------------------------------------------------

--
-- Table structure for table `loans`
--

CREATE TABLE `loans` (
  `Id` int(11) NOT NULL,
  `HouseId` int(11) NOT NULL,
  `UserId` int(11) NOT NULL,
  `Amount` decimal(65,30) NOT NULL,
  `InterestRate` double NOT NULL,
  `TermMonths` int(11) NOT NULL,
  `ApplicationDate` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  `Status` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `locations`
--

CREATE TABLE `locations` (
  `Id` int(11) NOT NULL,
  `Name` longtext NOT NULL,
  `State` longtext NOT NULL,
  `Country` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `locations`
--

INSERT INTO `locations` (`Id`, `Name`, `State`, `Country`) VALUES
(1, 'Manila', 'Luzon', 'PH'),
(2, 'Quezon City', 'Luzon', 'PH'),
(3, 'Cebu City', 'Visayas', 'PH'),
(4, 'Palawan', 'Luzon', 'PH'),
(5, 'Boracay', 'Visayas', 'PH'),
(6, 'Bohol', 'Visayas', 'PH');

-- --------------------------------------------------------

--
-- Table structure for table `propertytypes`
--

CREATE TABLE `propertytypes` (
  `Id` int(11) NOT NULL,
  `Name` longtext NOT NULL,
  `Description` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `propertytypes`
--

INSERT INTO `propertytypes` (`Id`, `Name`, `Description`) VALUES
(1, 'Single Family Home', 'Traditional detached house for one family'),
(2, 'Apartment', 'Unit in a multi-unit building'),
(3, 'Townhouse', 'Multi-floor home sharing walls with adjacent units'),
(4, 'Condo', 'Individually owned unit in a larger building or community'),
(5, 'Villa', 'Luxury detached house with garden'),
(6, 'Modern House', 'Luxury architectural home for minimalist living');

-- --------------------------------------------------------

--
-- Table structure for table `sitesettings`
--

CREATE TABLE `sitesettings` (
  `Id` int(11) NOT NULL,
  `Key` longtext NOT NULL,
  `Value` longtext NOT NULL,
  `Description` longtext NOT NULL,
  `LastUpdated` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `Id` int(11) NOT NULL,
  `Name` longtext NOT NULL,
  `Email` longtext NOT NULL,
  `ProfileImage` varchar(255) DEFAULT NULL,
  `Role` longtext NOT NULL,
  `Address` longtext NOT NULL,
  `LastLoginDate` datetime(6) DEFAULT NULL,
  `PasswordHash` longtext NOT NULL,
  `PhoneNumber` longtext NOT NULL,
  `RegisteredDate` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`Id`, `Name`, `Email`, `ProfileImage`, `Role`, `Address`, `LastLoginDate`, `PasswordHash`, `PhoneNumber`, `RegisteredDate`) VALUES
(1, 'Admin', 'admin@house.com', '/uploads/profiles/default-profile.png', 'Admin', 'Admin Address', NULL, '$2y$10$YNCd1LDUNf8xPoef.iL/hu31VWzABa5RQGIcGGNKGzfB/zW7YqSvq', '1234567890', '2025-04-08 11:07:28.000000'),
(2, 'chrollo', 'asta@gmail.com', '/uploads/profiles/cbeb011d-41f0-485a-b5fe-615dcbbf6687_1351628.png', 'User', 'sdsds', NULL, '$2a$11$hKl2EeDjY2LT4fxT.BQNseNbnHTzppzrGSRyiFyK6Msos5Ua68n4.', '1234567890', '2025-04-08 11:24:26.350558'),
(3, 'admin', 'admin@gmail.com', '/uploads/profiles/d1ffdfb9-1184-49fd-bdf7-1ffec1ae18dc_uia.jpeg', 'Admin', 'uiauia', NULL, '$2a$11$D49p0dFpQ7CiET5ArVlwXum4EXL/g6Zy2YwoHMlnO7OjcIP8xZW56', '12345678911', '2025-04-10 10:53:47.505072');

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20250329152121_InitialCreate', '8.0.13'),
('20250330073132_AddTitleToHouse', '8.0.13'),
('20250330073304_AddTitleToHouses', '8.0.13'),
('20250401081334_UpdateUserModel', '8.0.13'),
('20250406145516_UpdateModelsAndAddDynamicContent', '8.0.13'),
('20250406154055_AddRegisteredDateToHouses', '8.0.13'),
('20250408103925_AddIsFeaturedToHouses', '8.0.13'),
('20250409025020_sample', '8.0.13'),
('20250409082140_AddMissingHouseProperties', '8.0.13'),
('20250409124128_UpdateSizePrecision', '8.0.13'),
('20250410002129_AddCreatedAtToProperties', '8.0.13'),
('20250410043029_UpdatePriceAndSizePrecision', '8.0.13');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `houses`
--
ALTER TABLE `houses`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Houses_LocationId` (`LocationId`),
  ADD KEY `IX_Houses_PropertyTypeId` (`PropertyTypeId`);

--
-- Indexes for table `loans`
--
ALTER TABLE `loans`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Loans_HouseId` (`HouseId`),
  ADD KEY `IX_Loans_UserId` (`UserId`);

--
-- Indexes for table `locations`
--
ALTER TABLE `locations`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `propertytypes`
--
ALTER TABLE `propertytypes`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `sitesettings`
--
ALTER TABLE `sitesettings`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `houses`
--
ALTER TABLE `houses`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=52;

--
-- AUTO_INCREMENT for table `loans`
--
ALTER TABLE `loans`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `locations`
--
ALTER TABLE `locations`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `propertytypes`
--
ALTER TABLE `propertytypes`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `sitesettings`
--
ALTER TABLE `sitesettings`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `houses`
--
ALTER TABLE `houses`
  ADD CONSTRAINT `FK_Houses_Locations_LocationId` FOREIGN KEY (`LocationId`) REFERENCES `locations` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Houses_PropertyTypes_PropertyTypeId` FOREIGN KEY (`PropertyTypeId`) REFERENCES `propertytypes` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `loans`
--
ALTER TABLE `loans`
  ADD CONSTRAINT `FK_Loans_Houses_HouseId` FOREIGN KEY (`HouseId`) REFERENCES `houses` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Loans_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
