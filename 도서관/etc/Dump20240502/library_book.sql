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
-- Table structure for table `book`
--

DROP TABLE IF EXISTS `book`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `book` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` text,
  `writer` varchar(30) NOT NULL,
  `publisher` varchar(30) NOT NULL,
  `count` int NOT NULL,
  `price` varchar(10) NOT NULL,
  `releasedate` varchar(20) NOT NULL,
  `isbn` varchar(30) NOT NULL,
  `info` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `book`
--

LOCK TABLES `book` WRITE;
/*!40000 ALTER TABLE `book` DISABLE KEYS */;
INSERT INTO `book` VALUES (1,'패밀리 레스토랑 가자.','야머','출판사',0,'1000','2024-05-02','1234567890123','소설'),(2,'나는 읽고 쓰고 버린다.','손웅정','난다',4,'40000','2024-04-01','1111111111111','성공학'),(3,'불변의 법칙','하유철','서삼독',3,'22500','2000-09-08','2222222222222','자기계발'),(5,'명탐정 코난 104','아오야마 고쇼','콘티북',1,'9000','2024-01-21','4444444444444','추리'),(7,'뽀로로','김작가','동화나라',0,'20000','2024-04-28','5555555555555','동화'),(9,'a (A Novel)','Andy Warhol','Penguin Books Ltd (UK)',1,'17940','20221103','9780241586402',''),(10,'완전 모던 C++프로그래밍','김상진','그린',1,'29700','20240318','9788957273647','C++는 객체지향 프로그래밍을 지원하도록 C 언어를 확장한 고급 프로그래밍 언어이다. 이 책은 최신 표준인 C++20의 새 기능을 포함하여 C++의 모든 것을 빠짐없이 다루고 있다. 언어의 문법만 설명하지 않고 다양한 예제를 통해 올바른 사용법을 이해할 수 있도록 구성하였으며, 관련 프로그래밍 팁도 제시하고 있다. 객체 나중 방식으로 서술하고 있지만 객체지향에 대해서도 객체지향 설계의 가장 중요한 원리인 SOLID를 포함하여 기초 개념부터 심화 내용까지 충분히 자세히 설명하고 있다. 또 일부 객체지향 설계 패턴도 관련 장에서 소개하고 있다. 전문 C++ 개발자가 꼭 알아야 하는 이동 개념, 완벽 포워딩, template 범용 프로그래밍, 메타 프로그래밍, 스마트 포인터 등도 설명하고 있다.'),(11,'Java의 정석 (최신 Java 8.0 포함)','남궁성','도우출판',1,'27000','20160127','9788994492032','자바의 기초부터 실전활용까지 모두 담다!\n\n자바의 기초부터 객제지향개념을 넘어 실전활용까지 수록한『Java의 정석』. 저자의 오랜 실무경험과 강의한 내용으로 구성되어 자바를 처음 배우는 초보자들의 궁금한 점을 빠짐없이 담고 있다. 더불어 기존의 경력자들을 위해 자바 최신기능인 람다와 스트림과 그 밖의 자바의 최신버젼 JAVA8의 새로운 기능까지 자세하게 설명하고 있다.'),(15,'처음 만나는 통계와 데이터분석: R과 Python 활용 (R과 Python 활용, 제2판)','윤정연','한국금융연수원',1,'18900','20240401','9788928781959','통계와 데이터분석은 금융권 업무와 동떨어져 있고, 극소수의 사람만 알면 되는 그다지 쓸모없는 지식인 것처럼 여겨지던 때가 있었습니다. 그러나 지금은 데이터의 시대이고 빅데이터 분석과 활용이 화두가 될 정도로 상황이 많이 바뀌었습니다. 여기저기에서 통계와 데이터분석을 배우지 않으면 남들보다 뒤처질 것처럼 얘기하다 보니 왠지 꼭 배워야만 할 것 같은 분위기가 형성된 것 같습니다. 이러한 분위기 속에서 통계를 분석 도구로 사용하고 이를 가르치는 입장에서 보면, 너무 급하게 암기식으로 배우거나 현란한 공식에 매몰되어 흥미를 잃고, 실제 데이터를 접했을 때 전혀 적용하지 못하거나 잘못 적용하는 상황을 자주 목격하게 되었습니다.');
/*!40000 ALTER TABLE `book` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-05-02  6:32:18
