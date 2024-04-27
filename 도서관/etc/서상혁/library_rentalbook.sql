-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: library
-- ------------------------------------------------------
-- Server version	8.0.36

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `rentalbook`
--

DROP TABLE IF EXISTS `rentalbook`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rentalbook` (
  `id` int NOT NULL,
  `title` varchar(30) NOT NULL,
  `writer` varchar(30) NOT NULL,
  `publisher` varchar(30) NOT NULL,
  `count` int NOT NULL,
  `price` varchar(10) NOT NULL,
  `releasedate` varchar(20) NOT NULL,
  `isbn` varchar(30) NOT NULL,
  `info` varchar(30) NOT NULL,
  `rentaltime` varchar(20) NOT NULL,
  `returntime` varchar(20) NOT NULL,
  `userid` varchar(8) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rentalbook`
--

LOCK TABLES `rentalbook` WRITE;
/*!40000 ALTER TABLE `rentalbook` DISABLE KEYS */;
INSERT INTO `rentalbook` VALUES (3,'불변의 법칙','하유철','서삼독',4,'22500','2000-09-08','567567a 5675675675675','자기계발','2023-12-25 10:10:10','2024-01-01 10:10:10','11111111'),(4,'일류의 조건','다카시','필름',4,'18000','2024-03-01','654321a 3210987654321','자기계발','2024-04-27 16:36:59','2024-05-04 16:36:59','12345678');
/*!40000 ALTER TABLE `rentalbook` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-04-27 22:11:38
