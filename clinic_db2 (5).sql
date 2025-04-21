-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 21, 2025 at 02:58 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.1.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `clinic_db2`
--

-- --------------------------------------------------------

--
-- Table structure for table `diagnoses`
--

CREATE TABLE `diagnoses` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `diagnoses`
--

INSERT INTO `diagnoses` (`id`, `name`, `created_at`, `updated_at`) VALUES
(1, '', '0000-00-00 00:00:00', '2025-04-13 14:38:35'),
(2, 'Cao huyết áp', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(3, 'Tiểu đường type 2', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(4, 'Viêm phế quản', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(5, 'Rối loạn tiêu hóa', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(6, 'Đau dạ dày', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(7, 'Cảm cúm thông thường', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(8, 'Viêm da cơ địa', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(9, 'Thoái hóa khớp gối', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(10, 'Suy nhược cơ thể', '0000-00-00 00:00:00', '0000-00-00 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `doctor_notes`
--

CREATE TABLE `doctor_notes` (
  `id` int(11) NOT NULL,
  `content` varchar(255) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `doctor_notes`
--

INSERT INTO `doctor_notes` (`id`, `content`, `created_at`, `updated_at`) VALUES
(1, '', '0000-00-00 00:00:00', '2025-04-13 14:37:57'),
(2, 'Theo dõi huyết áp hàng ngày, tái khám sau 1 tháng.', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(3, 'Kiểm soát đường huyết, ăn kiêng, tập thể dục.', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(4, 'Giữ ấm cơ thể, tránh khói bụi, tái khám nếu ho kéo dài.', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(5, 'Ăn chín uống sôi, tránh đồ ăn khó tiêu.', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(6, 'Uống thuốc đúng giờ, kiêng chua cay, tái khám sau 2 tuần.', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(7, 'Vệ sinh mũi họng, nghỉ ngơi tại nhà.', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(8, 'Giữ vệ sinh da, tránh tiếp xúc dị nguyên, bôi thuốc theo chỉ định.', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(10, 'Bổ sung dinh dưỡng, nghỉ ngơi hợp lý, tránh căng thẳng.', '0000-00-00 00:00:00', '0000-00-00 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `examinations`
--

CREATE TABLE `examinations` (
  `id` bigint(20) NOT NULL,
  `patient_id` bigint(20) NOT NULL,
  `reason` varchar(100) DEFAULT NULL,
  `diagnosis_id` int(11) NOT NULL,
  `doctor_note_id` int(11) NOT NULL,
  `note` varchar(255) DEFAULT NULL,
  `pulse` int(11) DEFAULT NULL,
  `blood_pressure` varchar(10) DEFAULT NULL,
  `respiratory_rate` int(11) DEFAULT NULL,
  `weight` float DEFAULT NULL,
  `height` float DEFAULT NULL,
  `temperature` float DEFAULT NULL,
  `type` enum('chỉ định','toa thuốc') NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `examinations`
--

INSERT INTO `examinations` (`id`, `patient_id`, `reason`, `diagnosis_id`, `doctor_note_id`, `note`, `pulse`, `blood_pressure`, `respiratory_rate`, `weight`, `height`, `temperature`, `type`, `created_at`, `updated_at`) VALUES
(120, 76, 'Lý do khám', 6, 1, '', 0, '', 0, 0, 0, 0, 'chỉ định', '2025-04-14 07:56:41', '2025-04-14 07:56:41'),
(121, 74, 'Lý do khám', 1, 1, '', 0, '', 0, 0, 0, 0, 'chỉ định', '2025-04-14 08:29:43', '2025-04-14 08:29:43'),
(122, 75, 'Lý do khám', 1, 1, '', 0, '', 0, 0, 0, 0, 'chỉ định', '2025-04-14 09:43:24', '2025-04-14 09:43:24'),
(123, 80, 'Lý do khám', 8, 1, '', 12, '12124', 12, 12412, 43, 12, 'chỉ định', '2025-04-14 11:42:33', '2025-04-14 11:42:33'),
(124, 78, 'Lý do khám', 8, 1, '', 12, '12124', 12, 12412, 43, 12, 'chỉ định', '2025-04-14 11:44:45', '2025-04-14 11:44:45'),
(125, 75, 'Lý do khám', 1, 1, '', 0, '', 0, 0, 0, 0, 'chỉ định', '2025-04-14 11:47:37', '2025-04-14 11:47:37');

-- --------------------------------------------------------

--
-- Table structure for table `examination_medications`
--

CREATE TABLE `examination_medications` (
  `id` bigint(20) NOT NULL,
  `examination_id` bigint(20) NOT NULL,
  `medication_id` bigint(20) DEFAULT NULL,
  `unit` varchar(10) NOT NULL,
  `dosage` varchar(10) NOT NULL,
  `route` varchar(10) NOT NULL,
  `times` varchar(10) NOT NULL,
  `note` varchar(30) DEFAULT NULL,
  `quantity` int(11) NOT NULL,
  `price` varchar(10) NOT NULL,
  `created_at` timestamp NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `examination_results`
--

CREATE TABLE `examination_results` (
  `id` bigint(20) NOT NULL,
  `examination_service_id` bigint(20) NOT NULL,
  `template_id` bigint(20) DEFAULT NULL,
  `result` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
  `final_result` varchar(50) DEFAULT NULL,
  `file_path` longtext DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `examination_results`
--

INSERT INTO `examination_results` (`id`, `examination_service_id`, `template_id`, `result`, `final_result`, `file_path`, `created_at`, `updated_at`) VALUES
(46, 138, 4, 'Nhịp tim: [Giá trị] lần/phút\nTrục điện tim: [Mô tả]\nSóng P, QRS, T: [Mô tả]123123', '123', NULL, '2025-04-14 08:10:26', '2025-04-14 08:10:45'),
(47, 139, 10, 'Kích thước: [Giá trị]\nCấu trúc: [Mô tả]\nNhân giáp (nếu có): [Mô tả]', '213213', 'D:\\HocTap\\QLPK\\QuanLyPhongKham\\images\\1ca60e8b-0601-4a35-97b8-727495f16249.jpg,D:\\HocTap\\QLPK\\QuanLyPhongKham\\images\\5b56fa62-8f94-40da-beb1-a86511c6a60b.jpg,D:\\HocTap\\QLPK\\QuanLyPhongKham\\images\\48df0953-9849-4647-bcc6-04bf36895661.jpg,D:\\HocTap\\QLPK\\Qua', '2025-04-14 09:32:45', '2025-04-14 09:42:48'),
(48, 139, 10, 'Kích thước: [Giá trị]\nCấu trúc: [Mô tả]\nNhân giáp (nếu có): [Mô tả]', '213213', 'D:\\HocTap\\QLPK\\QuanLyPhongKham\\images\\1ca60e8b-0601-4a35-97b8-727495f16249.jpg,D:\\HocTap\\QLPK\\QuanLyPhongKham\\images\\5b56fa62-8f94-40da-beb1-a86511c6a60b.jpg,D:\\HocTap\\QLPK\\QuanLyPhongKham\\images\\48df0953-9849-4647-bcc6-04bf36895661.jpg,D:\\HocTap\\QLPK\\Qua', '2025-04-14 09:42:38', '2025-04-14 09:42:48'),
(49, 140, 10, 'Kích thước: [Giá trị]\nCấu trúc: [Mô tả]\nNhân giáp (nếu có): [Mô tả]213123123', '213213123123123123123123123123123123', 'D:\\HocTap\\QLPK\\QuanLyPhongKham\\images\\dbde263c-6d04-459e-82df-4365fd479857.jpg,D:\\HocTap\\QLPK\\QuanLyPhongKham\\images\\f52d0f68-9203-4646-bff0-c2f2ab32ab15.jpg,D:\\HocTap\\QLPK\\QuanLyPhongKham\\images\\ac588b57-c375-4f1b-bf7f-933bb97c868e.jpg,D:\\HocTap\\QLPK\\QuanLyPhongKham\\images\\5018fec3-2c61-4573-8d60-78041e8f4319.jpg', '2025-04-14 09:43:43', '2025-04-14 11:49:48'),
(50, 141, 15, 'Xương sống lưng:\nGiữa Lưng:1\nKhớp Lưng:', '3123123', NULL, '2025-04-14 11:43:53', '2025-04-14 11:45:15'),
(51, 143, 28, '[{\"name\":\"Xét nghiệm nước tiểu\",\"results\":[{\"test_name\":\"pH\",\"result\":\"6.0\",\"unit\":\"\",\"normal_range\":\"4.5 – 8.0\"},{\"test_name\":\"Protein\",\"result\":\"123\",\"unit\":\"\",\"normal_range\":\"Negative\"},{\"test_name\":\"Glucose\",\"result\":\"123\",\"unit\":\"\",\"normal_range\":\"Negative\"},{\"test_name\":\"Bạch cầu\",\"result\":\"123\",\"unit\":\"\",\"normal_range\":\"Negative\"}]},{\"name\":\"Xét nghiệm vi khuẩn\",\"results\":[{\"test_name\":\"Nitrite\",\"result\":\"123\",\"unit\":\"\",\"normal_range\":\"Negative\"},{\"test_name\":\"Leukocyte esterase\",\"result\":\"123\",\"unit\":\"\",\"normal_range\":\"Negative\"}]}]', '123123123123ㅁㄴㄻㄴㄹ', NULL, '2025-04-14 11:47:01', '2025-04-14 11:47:01'),
(52, 147, 29, '[{\"name\":\"Xét nghiệm viêm gan B\",\"results\":[{\"test_name\":\"HBsAg\",\"result\":\"123\",\"unit\":\"\",\"normal_range\":\"Negative\"},{\"test_name\":\"Anti-HBs\",\"result\":\"123\",\"unit\":\"\",\"normal_range\":\"Positive\"},{\"test_name\":\"Anti-HBc\",\"result\":\"123\",\"unit\":\"\",\"normal_range\":\"Negative\"}]},{\"name\":\"Xét nghiệm viêm gan C\",\"results\":[{\"test_name\":\"Anti-HCV\",\"result\":\"123\",\"unit\":\"\",\"normal_range\":\"Negative\"},{\"test_name\":\"HCV RNA\",\"result\":\"123\",\"unit\":\"\",\"normal_range\":\"Negative\"}]}]', '', NULL, '2025-04-14 11:48:08', '2025-04-14 11:53:32'),
(53, 145, 3, '23123123123', '', NULL, '2025-04-14 11:53:16', '2025-04-14 11:53:16');

-- --------------------------------------------------------

--
-- Table structure for table `examination_services`
--

CREATE TABLE `examination_services` (
  `id` bigint(20) NOT NULL,
  `examination_id` bigint(20) NOT NULL,
  `service_id` bigint(20) NOT NULL,
  `price` int(11) DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `examination_services`
--

INSERT INTO `examination_services` (`id`, `examination_id`, `service_id`, `price`, `created_at`, `updated_at`) VALUES
(138, 120, 4, 80000, '2025-04-14 07:56:41', '2025-04-14 07:56:41'),
(139, 121, 3, 200000, '2025-04-14 08:29:43', '2025-04-14 08:29:43'),
(140, 122, 3, 200000, '2025-04-14 09:43:24', '2025-04-14 09:43:24'),
(141, 123, 2, 150000, '2025-04-14 11:42:33', '2025-04-14 11:42:33'),
(142, 123, 3, 200000, '2025-04-14 11:42:33', '2025-04-14 11:42:33'),
(143, 123, 1, 100000, '2025-04-14 11:42:33', '2025-04-14 11:42:33'),
(144, 123, 4, 80000, '2025-04-14 11:42:33', '2025-04-14 11:42:33'),
(145, 124, 2, 150000, '2025-04-14 11:44:45', '2025-04-14 11:44:45'),
(146, 124, 3, 200000, '2025-04-14 11:44:45', '2025-04-14 11:44:45'),
(147, 124, 1, 100000, '2025-04-14 11:44:45', '2025-04-14 11:44:45'),
(148, 124, 4, 80000, '2025-04-14 11:44:45', '2025-04-14 11:44:45'),
(149, 125, 4, 80000, '2025-04-14 11:47:37', '2025-04-14 11:47:37');

-- --------------------------------------------------------

--
-- Table structure for table `medications`
--

CREATE TABLE `medications` (
  `id` bigint(20) NOT NULL,
  `name` varchar(255) NOT NULL,
  `unit` varchar(50) DEFAULT NULL,
  `dosage` varchar(255) DEFAULT NULL,
  `route` varchar(50) DEFAULT NULL,
  `times_per_day` int(11) NOT NULL DEFAULT 1,
  `note` text DEFAULT NULL,
  `price` int(255) DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `medications`
--

INSERT INTO `medications` (`id`, `name`, `unit`, `dosage`, `route`, `times_per_day`, `note`, `price`, `created_at`, `updated_at`) VALUES
(4, 'Omeprazol 20mg', 'Viên', '20mg', 'Uống', 1, 'Trước ăn sáng 30 phút', 4000, '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(5, 'Berberin 100mg', 'Viên', '100mg', 'Uống', 3, 'Sau ăn', 500, '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(6, 'Salbutamol 2mg', 'Viên', '2mg', 'Uống', 2, 'Khi khó thở', 1500, '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(7, 'Metformin 500mg', 'Viên', '500mg', 'Uống', 2, 'Sau ăn', 2500, '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(8, 'Amlodipin 5mg', 'Viên', '5mg', 'Uống', 1, 'Buổi sáng', 3500, '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(9, 'Vitamin C 500mg', 'Viên sủi', '500mg', 'Uống', 1, 'Sau ăn sáng', 1000, '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(10, 'Cetirizin 10mg', 'Viên', '10mg', 'Uống', 1, 'Buổi tối', 1800, '0000-00-00 00:00:00', '0000-00-00 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `patients`
--

CREATE TABLE `patients` (
  `id` bigint(20) NOT NULL,
  `name` varchar(255) NOT NULL,
  `date_of_birth` date DEFAULT NULL,
  `gender` enum('Nam','Nữ','Khác') DEFAULT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `address` text DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `patients`
--

INSERT INTO `patients` (`id`, `name`, `date_of_birth`, `gender`, `phone`, `address`, `created_at`, `updated_at`) VALUES
(72, '김민준 (Kim Min-jun)', '1989-03-12', '', '0101234567', 'Seoul, South Korea', '2025-04-14 07:55:50', '2025-04-14 07:55:50'),
(74, '박지후 (Park Ji-hoo)', '1985-11-03', '', '0103456789', 'Incheon, South Korea', '2025-04-14 07:55:50', '2025-04-14 07:55:50'),
(75, '최예린 (Choi Ye-rin)', '1991-06-17', '', '0104567890', 'Daegu, South Korea', '2025-04-14 07:55:50', '2025-04-14 07:55:50'),
(76, '정하준 (Jung Ha-jun)', '1987-02-28', '', '0105678901', 'Daejeon, South Korea', '2025-04-14 07:55:50', '2025-04-14 07:55:50'),
(77, '김민준 (Kim Min-jun)', '1989-03-12', 'Nữ', '0101234567', 'Seoul, South Korea', '2025-04-14 11:23:58', '2025-04-14 11:23:58'),
(78, 'ㅜㅎㄴㅇ라ㅓㅏㄴㅇㄹ', '1989-03-12', 'Nam', '0101234567', 'Seoul, South Korea', '2025-04-14 11:24:09', '2025-04-14 11:24:09'),
(79, '', '2025-04-14', 'Nam', '', '', '2025-04-14 11:34:00', '2025-04-14 11:34:00'),
(80, 'Nguyễn Văn A', '1981-01-14', 'Nam', '01212314545', 'VL', '2025-04-14 11:40:26', '2025-04-14 11:40:26');

-- --------------------------------------------------------

--
-- Table structure for table `services`
--

CREATE TABLE `services` (
  `id` bigint(20) NOT NULL,
  `name` varchar(255) NOT NULL,
  `type` enum('X-quang','Điện tim','Xét nghiệm','Siêu âm') NOT NULL,
  `content` mediumtext DEFAULT NULL,
  `price` int(200) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `services`
--

INSERT INTO `services` (`id`, `name`, `type`, `content`, `price`, `created_at`, `updated_at`) VALUES
(1, 'Xét nghiệm công thức máu', 'Xét nghiệm', 'Phân tích các thành phần tế bào máu', 100000, '2025-01-10 02:00:00', '2025-04-04 13:26:16'),
(2, 'Chụp X-quang phổi thẳng', 'X-quang', 'Hình ảnh X-quang lồng ngực', 150000, '2025-01-11 03:00:00', '2025-04-04 13:26:20'),
(3, 'Siêu âm ổ bụng tổng quát', 'Siêu âm', 'Kiểm tra các tạng trong ổ bụng', 200000, '2025-01-12 04:00:00', '2025-04-04 13:26:24'),
(4, 'Đo điện tâm đồ (ECG)', 'Điện tim', 'Ghi lại hoạt động điện của tim', 80000, '2025-01-13 07:00:00', '2025-04-04 13:26:31'),
(5, 'Xét nghiệm đường huyết mao mạch', 'Xét nghiệm', 'Kiểm tra nhanh đường huyết', 30000, '2025-01-14 08:00:00', '2025-04-04 13:26:39'),
(6, 'Nội soi tai mũi họng', 'Xét nghiệm', 'Quan sát bên trong tai, mũi, họng', 250000, '2025-01-15 09:00:00', '2025-04-04 13:26:44'),
(7, 'Đo huyết áp', 'Xét nghiệm', 'Kiểm tra huyết áp động mạch', 20000, '2025-01-16 01:00:00', '2025-04-04 13:26:49'),
(11, 'Chụp X Quang Xương Sườn', 'X-quang', 'Chụp X Quang máy XCan', 1000000, '2025-04-04 13:25:27', '2025-04-04 13:27:10');

-- --------------------------------------------------------

--
-- Table structure for table `templates`
--

CREATE TABLE `templates` (
  `id` bigint(20) NOT NULL,
  `name` varchar(255) NOT NULL,
  `type` varchar(25) NOT NULL,
  `template_content` longtext NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `templates`
--

INSERT INTO `templates` (`id`, `name`, `type`, `template_content`, `created_at`, `updated_at`) VALUES
(1, 'Mẫu kết quả Công thức máu', 'Xét nghiệm', 'Hồng cầu: [Giá trị] (Đơn vị)\nBạch cầu: [Giá trị] (Đơn vị)\nTiểu cầu: [Giá trị] (Đơn vị)', '2025-01-05 07:00:00', '2025-04-13 13:13:14'),
(3, 'Mẫu kết quả Siêu âm bụng', 'X-quang', 'Gan: [Mô tả]\nMật: [Mô tả]\nTụy: [Mô tả]\nLách: [Mô tả]\nThận: [Mô tả]', '2025-01-07 09:00:00', '2025-04-13 13:45:12'),
(4, 'Mẫu kết quả Điện tâm đồ', 'Điện tim', 'Nhịp tim: [Giá trị] lần/phút\nTrục điện tim: [Mô tả]\nSóng P, QRS, T: [Mô tả]', '2025-01-08 10:00:00', '2025-04-13 13:13:37'),
(5, 'Mẫu kết quả Đường huyết', 'Xét nghiệm', 'Đường huyết mao mạch: [Giá trị] mmol/L', '2025-01-09 11:00:00', '2025-04-13 13:14:02'),
(6, 'Mẫu kết quả Nội soi T-M-H', 'Siêu âm', 'Tai: [Mô tả]\nMũi: [Mô tả]\nHọng: [Mô tả]', '2025-01-10 12:00:00', '2025-04-13 13:14:21'),
(9, 'Mẫu Kết quả Xét nghiệm Nước tiểu', 'Xét nghiệm', 'Màu sắc: [Giá trị]\nĐộ pH: [Giá trị]\nTỷ trọng: [Giá trị]\nProtein: [Giá trị]\nGlucose: [Giá trị]', '2025-01-13 03:00:00', '2025-04-13 13:14:43'),
(10, 'Mẫu Kết quả Siêu âm tuyến giáp', 'Siêu âm', 'Kích thước: [Giá trị]\nCấu trúc: [Mô tả]\nNhân giáp (nếu có): [Mô tả]', '2025-01-14 04:00:00', '2025-04-13 13:14:47'),
(15, 'Mẫu X - quang lưng', 'X-quang', 'Xương sống lưng:\nGiữa Lưng:1\nKhớp Lưng:', '2025-04-13 13:34:05', '2025-04-13 13:41:33'),
(16, 'Xương Lưng', 'X-quang', 'Xương lưng:\r\nXương lưng\r\nxương lưng', '2025-04-13 13:34:47', '2025-04-13 13:34:47'),
(17, 'test xquang', 'X-quang', 'Test: àkj\r\nskdjf:sfkjs', '2025-04-13 13:42:09', '2025-04-13 13:42:09'),
(25, 'Xét nghiệm tổng quát', 'Xét nghiệm', '[\r\n        {\r\n            \"name\": \"Xét nghiệm máu tổng quát\",\r\n            \"results\": [\r\n                {\"test_name\": \"Bạch cầu (WBC)\", \"result\": \"7.5\", \"unit\": \"10^9/L\", \"normal_range\": \"4.0 – 10.0\"},\r\n                {\"test_name\": \"Hồng cầu (RBC)\", \"result\": \"4.8\", \"unit\": \"10^12/L\", \"normal_range\": \"4.2 – 5.4\"},\r\n                {\"test_name\": \"Hemoglobin (Hb)\", \"result\": \"13.5\", \"unit\": \"g/dL\", \"normal_range\": \"13.0 – 17.0\"},\r\n                {\"test_name\": \"Hematocrit (Hct)\", \"result\": \"40\", \"unit\": \"%\", \"normal_range\": \"37 – 47\"}\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"Xét nghiệm sinh hóa\",\r\n            \"results\": [\r\n                {\"test_name\": \"Glucose\", \"result\": \"5.5\", \"unit\": \"mmol/L\", \"normal_range\": \"3.9 – 6.4\"},\r\n                {\"test_name\": \"Creatinine\", \"result\": \"90\", \"unit\": \"µmol/L\", \"normal_range\": \"62 – 120\"},\r\n                {\"test_name\": \"Ure\", \"result\": \"5.0\", \"unit\": \"mmol/L\", \"normal_range\": \"2.5 – 7.5\"}\r\n            ]\r\n        }\r\n    ]', '2025-04-13 13:57:41', '2025-04-13 13:57:41'),
(26, 'Xét nghiệm chức năng thận', 'Xét nghiệm', '[\r\n        {\r\n            \"name\": \"Xét nghiệm chức năng thận\",\r\n            \"results\": [\r\n                {\"test_name\": \"BUN\", \"result\": \"6.5\", \"unit\": \"mmol/L\", \"normal_range\": \"2.5 – 7.1\"},\r\n                {\"test_name\": \"Creatinine\", \"result\": \"88\", \"unit\": \"µmol/L\", \"normal_range\": \"62 – 120\"},\r\n                {\"test_name\": \"Ure\", \"result\": \"5.2\", \"unit\": \"mmol/L\", \"normal_range\": \"2.5 – 7.5\"},\r\n                {\"test_name\": \"Cystatin C\", \"result\": \"0.95\", \"unit\": \"mg/L\", \"normal_range\": \"0.53 – 0.95\"}\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"Xét nghiệm chức năng gan\",\r\n            \"results\": [\r\n                {\"test_name\": \"ALT (GPT)\", \"result\": \"35\", \"unit\": \"U/L\", \"normal_range\": \"7 – 56\"},\r\n                {\"test_name\": \"AST (GOT)\", \"result\": \"30\", \"unit\": \"U/L\", \"normal_range\": \"5 – 40\"},\r\n                {\"test_name\": \"Bilirubin tổng hợp\", \"result\": \"1.0\", \"unit\": \"mg/dL\", \"normal_range\": \"0.1 – 1.2\"}\r\n            ]\r\n        }\r\n    ]', '2025-04-13 13:57:41', '2025-04-13 13:57:41'),
(27, 'Xét nghiệm hormon tuyến giáp', 'Xét nghiệm', '[\r\n        {\r\n            \"name\": \"Xét nghiệm tuyến giáp\",\r\n            \"results\": [\r\n                {\"test_name\": \"TSH\", \"result\": \"2.5\", \"unit\": \"µIU/mL\", \"normal_range\": \"0.4 – 4.0\"},\r\n                {\"test_name\": \"FT4\", \"result\": \"1.2\", \"unit\": \"ng/dL\", \"normal_range\": \"0.8 – 1.8\"},\r\n                {\"test_name\": \"FT3\", \"result\": \"3.1\", \"unit\": \"pg/mL\", \"normal_range\": \"2.3 – 4.2\"}\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"Xét nghiệm tuyến cận giáp\",\r\n            \"results\": [\r\n                {\"test_name\": \"PTH\", \"result\": \"45\", \"unit\": \"pg/mL\", \"normal_range\": \"15 – 65\"}\r\n            ]\r\n        }\r\n    ]', '2025-04-13 13:57:41', '2025-04-13 13:57:41'),
(28, 'Xét nghiệm nước tiểu', 'Xét nghiệm', '[\r\n        {\r\n            \"name\": \"Xét nghiệm nước tiểu\",\r\n            \"results\": [\r\n                {\"test_name\": \"pH\", \"result\": \"6.0\", \"unit\": \"\", \"normal_range\": \"4.5 – 8.0\"},\r\n                {\"test_name\": \"Protein\", \"result\": \"Negative\", \"unit\": \"\", \"normal_range\": \"Negative\"},\r\n                {\"test_name\": \"Glucose\", \"result\": \"Negative\", \"unit\": \"\", \"normal_range\": \"Negative\"},\r\n                {\"test_name\": \"Bạch cầu\", \"result\": \"Negative\", \"unit\": \"\", \"normal_range\": \"Negative\"}\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"Xét nghiệm vi khuẩn\",\r\n            \"results\": [\r\n                {\"test_name\": \"Nitrite\", \"result\": \"Negative\", \"unit\": \"\", \"normal_range\": \"Negative\"},\r\n                {\"test_name\": \"Leukocyte esterase\", \"result\": \"Negative\", \"unit\": \"\", \"normal_range\": \"Negative\"}\r\n            ]\r\n        }\r\n    ]', '2025-04-13 13:57:41', '2025-04-13 13:57:41'),
(29, 'Xét nghiệm viêm gan', 'Xét nghiệm', '[\r\n        {\r\n            \"name\": \"Xét nghiệm viêm gan B\",\r\n            \"results\": [\r\n                {\"test_name\": \"HBsAg\", \"result\": \"Negative\", \"unit\": \"\", \"normal_range\": \"Negative\"},\r\n                {\"test_name\": \"Anti-HBs\", \"result\": \"Positive\", \"unit\": \"\", \"normal_range\": \"Positive\"},\r\n                {\"test_name\": \"Anti-HBc\", \"result\": \"Negative\", \"unit\": \"\", \"normal_range\": \"Negative\"}\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"Xét nghiệm viêm gan C\",\r\n            \"results\": [\r\n                {\"test_name\": \"Anti-HCV\", \"result\": \"Negative\", \"unit\": \"\", \"normal_range\": \"Negative\"},\r\n                {\"test_name\": \"HCV RNA\", \"result\": \"Negative\", \"unit\": \"\", \"normal_range\": \"Negative\"}\r\n            ]\r\n        }\r\n    ]', '2025-04-13 13:57:41', '2025-04-13 13:57:41');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `diagnoses`
--
ALTER TABLE `diagnoses`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `doctor_notes`
--
ALTER TABLE `doctor_notes`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `examinations`
--
ALTER TABLE `examinations`
  ADD PRIMARY KEY (`id`),
  ADD KEY `patient_id` (`patient_id`),
  ADD KEY `examinations_ibfk_2` (`diagnosis_id`),
  ADD KEY `examinations_ibfk_3` (`doctor_note_id`);

--
-- Indexes for table `examination_medications`
--
ALTER TABLE `examination_medications`
  ADD PRIMARY KEY (`id`),
  ADD KEY `examination_id` (`examination_id`),
  ADD KEY `medication_id` (`medication_id`);

--
-- Indexes for table `examination_results`
--
ALTER TABLE `examination_results`
  ADD PRIMARY KEY (`id`),
  ADD KEY `examination_service_id` (`examination_service_id`),
  ADD KEY `template_id` (`template_id`);

--
-- Indexes for table `examination_services`
--
ALTER TABLE `examination_services`
  ADD PRIMARY KEY (`id`),
  ADD KEY `examination_id` (`examination_id`),
  ADD KEY `service_id` (`service_id`);

--
-- Indexes for table `medications`
--
ALTER TABLE `medications`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `patients`
--
ALTER TABLE `patients`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `services`
--
ALTER TABLE `services`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unique_service_name` (`name`);

--
-- Indexes for table `templates`
--
ALTER TABLE `templates`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `diagnoses`
--
ALTER TABLE `diagnoses`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=124;

--
-- AUTO_INCREMENT for table `doctor_notes`
--
ALTER TABLE `doctor_notes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `examinations`
--
ALTER TABLE `examinations`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=126;

--
-- AUTO_INCREMENT for table `examination_medications`
--
ALTER TABLE `examination_medications`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=58;

--
-- AUTO_INCREMENT for table `examination_results`
--
ALTER TABLE `examination_results`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=54;

--
-- AUTO_INCREMENT for table `examination_services`
--
ALTER TABLE `examination_services`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=150;

--
-- AUTO_INCREMENT for table `medications`
--
ALTER TABLE `medications`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `patients`
--
ALTER TABLE `patients`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=81;

--
-- AUTO_INCREMENT for table `services`
--
ALTER TABLE `services`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `templates`
--
ALTER TABLE `templates`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=30;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `examinations`
--
ALTER TABLE `examinations`
  ADD CONSTRAINT `examinations_ibfk_1` FOREIGN KEY (`patient_id`) REFERENCES `patients` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `examinations_ibfk_2` FOREIGN KEY (`diagnosis_id`) REFERENCES `diagnoses` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `examinations_ibfk_3` FOREIGN KEY (`doctor_note_id`) REFERENCES `doctor_notes` (`id`);

--
-- Constraints for table `examination_medications`
--
ALTER TABLE `examination_medications`
  ADD CONSTRAINT `examination_medications_ibfk_1` FOREIGN KEY (`examination_id`) REFERENCES `examinations` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `examination_medications_ibfk_2` FOREIGN KEY (`medication_id`) REFERENCES `medications` (`id`) ON DELETE CASCADE;

--
-- Constraints for table `examination_results`
--
ALTER TABLE `examination_results`
  ADD CONSTRAINT `examination_results_ibfk_1` FOREIGN KEY (`examination_service_id`) REFERENCES `examination_services` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `examination_results_ibfk_2` FOREIGN KEY (`template_id`) REFERENCES `templates` (`id`) ON DELETE SET NULL;

--
-- Constraints for table `examination_services`
--
ALTER TABLE `examination_services`
  ADD CONSTRAINT `examination_services_ibfk_1` FOREIGN KEY (`examination_id`) REFERENCES `examinations` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `examination_services_ibfk_2` FOREIGN KEY (`service_id`) REFERENCES `services` (`id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
