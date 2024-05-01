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
-- Table structure for table `log`
--

DROP TABLE IF EXISTS `log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `log` (
  `number` int NOT NULL AUTO_INCREMENT,
  `time` varchar(45) DEFAULT NULL,
  `user` varchar(45) DEFAULT NULL,
  `info` varchar(45) DEFAULT NULL,
  `play` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`number`)
) ENGINE=InnoDB AUTO_INCREMENT=154 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `log`
--

LOCK TABLES `log` WRITE;
/*!40000 ALTER TABLE `log` DISABLE KEYS */;
INSERT INTO `log` VALUES (130,'2024-05-02 06:14:49','Manager','로그 전체 삭제',' '),(131,'2024-05-02 06:14:52','Manager','로그 내역 조회',' '),(132,'2024-05-02 06:15:30','Manager','LogIn',' '),(133,'2024-05-02 06:15:32','Manager','요청 도서 내역 조회',' '),(134,'2024-05-02 06:15:36','Manager','요청 도서 내역 조회',' '),(135,'2024-05-02 06:18:09','Manager','LogIn',' '),(136,'2024-05-02 06:18:12','Manager','요청 도서 내역 조회',' '),(137,'2024-05-02 06:18:30','12345678','LogIn',' '),(138,'2024-05-02 06:18:37','12345678','네이버 도서 검색',' '),(139,'2024-05-02 06:18:41','12345678','요청 도서 내역 조회',' '),(140,'2024-05-02 06:18:53','Manager','LogIn',' '),(141,'2024-05-02 06:18:55','Manager','요청 도서 내역 조회',' '),(142,'2024-05-02 06:27:04','Manager','LogIn',' '),(143,'2024-05-02 06:27:09','Manager','요청 도서 내역 조회',' '),(144,'2024-05-02 06:27:16','12345678','LogIn',' '),(145,'2024-05-02 06:27:23','12345678','네이버 도서 검색',' '),(146,'2024-05-02 06:27:57','12345678','네이버 도서 검색',' '),(147,'2024-05-02 06:28:54','12345678','네이버 도서 검색',' '),(148,'2024-05-02 06:29:49','12345678','LogIn',' '),(149,'2024-05-02 06:29:54','12345678','네이버 도서 검색',' '),(150,'2024-05-02 06:29:57','12345678','요청 도서 내역 조회',' '),(151,'2024-05-02 06:30:04','Manager','LogIn',' '),(152,'2024-05-02 06:30:06','Manager','요청 도서 내역 조회',' '),(153,'2024-05-02 06:30:09','Manager','요청 도서 내역 조회',' ');
/*!40000 ALTER TABLE `log` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-05-02  6:32:17
