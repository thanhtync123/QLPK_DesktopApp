-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th5 28, 2025 lúc 04:47 PM
-- Phiên bản máy phục vụ: 10.4.32-MariaDB
-- Phiên bản PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `clinic_db2`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `diagnoses`
--

CREATE TABLE `diagnoses` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `diagnoses`
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
(10, 'Suy nhược cơ thể', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(126, '1', '2025-05-23 15:11:54', '2025-05-23 15:11:54');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `doctor_notes`
--

CREATE TABLE `doctor_notes` (
  `id` int(11) NOT NULL,
  `content` varchar(255) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `doctor_notes`
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
-- Cấu trúc bảng cho bảng `examinations`
--

CREATE TABLE `examinations` (
  `id` bigint(20) NOT NULL,
  `patient_id` bigint(20) NOT NULL,
  `reason` varchar(100) DEFAULT NULL,
  `diagnosis_id` int(11) NOT NULL,
  `doctor_note_id` int(11) NOT NULL,
  `note` varchar(255) DEFAULT NULL,
  `pulse` varchar(50) DEFAULT NULL,
  `blood_pressure` varchar(50) DEFAULT NULL,
  `respiratory_rate` varchar(50) DEFAULT NULL,
  `weight` varchar(50) DEFAULT NULL,
  `height` varchar(50) DEFAULT NULL,
  `temperature` varchar(50) DEFAULT NULL,
  `type` enum('chỉ định','toa thuốc') NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `examinations`
--

INSERT INTO `examinations` (`id`, `patient_id`, `reason`, `diagnosis_id`, `doctor_note_id`, `note`, `pulse`, `blood_pressure`, `respiratory_rate`, `weight`, `height`, `temperature`, `type`, `created_at`, `updated_at`) VALUES
(172, 86, 'Chẩn đoán phụ', 7, 10, '1', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'toa thuốc', '2025-05-24 12:55:37', '2025-05-24 12:55:37'),
(173, 86, '1', 7, 10, '1', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-24 12:56:03', '2025-05-24 12:56:03'),
(174, 86, '', 1, 1, '', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-24 12:58:28', '2025-05-24 12:58:28'),
(175, 86, '', 1, 1, '', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-24 12:59:09', '2025-05-24 12:59:09'),
(176, 86, '', 1, 1, '', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-24 13:06:02', '2025-05-24 13:06:02'),
(177, 86, '', 1, 1, '', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-24 13:07:37', '2025-05-24 13:07:37'),
(178, 86, '', 1, 1, '', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-24 13:08:35', '2025-05-24 13:08:35'),
(179, 86, '', 1, 1, '', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-24 13:08:55', '2025-05-24 13:08:55'),
(180, 88, '', 1, 1, '', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-24 13:32:16', '2025-05-24 13:32:16'),
(181, 86, '', 1, 1, '', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-24 13:37:11', '2025-05-24 13:37:11'),
(182, 88, '', 1, 1, '', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-24 13:40:11', '2025-05-24 13:40:11'),
(183, 85, '123', 7, 4, '123', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-25 03:20:21', '2025-05-25 03:20:21'),
(184, 85, '123', 7, 8, '123', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-25 03:33:24', '2025-05-25 03:33:24'),
(185, 85, '1', 2, 10, '1', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-25 03:34:58', '2025-05-25 03:34:58'),
(186, 85, '', 1, 1, '', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-25 04:01:51', '2025-05-25 04:01:51'),
(187, 85, 'Chẩn đoán phụ', 1, 1, '', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'toa thuốc', '2025-05-25 14:11:45', '2025-05-25 14:11:45'),
(188, 85, 'Chẩn đoán phụ', 1, 1, '', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'toa thuốc', '2025-05-25 14:51:16', '2025-05-25 14:51:16'),
(189, 97, '123123', 7, 5, '123123', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-26 09:02:55', '2025-05-26 09:02:55'),
(190, 96, '123123', 126, 10, '213123123213123213', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-26 10:10:25', '2025-05-26 10:10:25'),
(191, 88, '', 2, 4, '', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-26 15:48:26', '2025-05-26 15:48:26'),
(192, 85, 'Chẩn đoán phụ', 7, 4, '123', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'toa thuốc', '2025-05-27 01:43:05', '2025-05-27 01:43:05'),
(193, 93, '123', 7, 4, '123', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-27 01:43:41', '2025-05-27 01:43:41'),
(194, 92, '', 1, 1, '', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-27 01:55:49', '2025-05-27 01:55:49'),
(195, 88, '', 1, 1, '', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-27 02:00:05', '2025-05-27 02:00:05'),
(196, 92, '213', 2, 8, '123123', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-27 02:25:48', '2025-05-27 02:25:48'),
(197, 92, '213', 2, 8, '123123', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-27 02:25:56', '2025-05-27 02:25:56'),
(198, 85, '213', 2, 8, '123123', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-27 02:26:24', '2025-05-27 02:26:24'),
(199, 95, '', 1, 1, '', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-27 02:52:56', '2025-05-27 02:52:56'),
(200, 94, '', 1, 1, '', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-27 02:53:03', '2025-05-27 02:53:03'),
(201, 94, '', 1, 1, '', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-27 02:55:13', '2025-05-27 02:55:13'),
(202, 94, '', 1, 1, '', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-27 02:55:33', '2025-05-27 02:55:33'),
(203, 96, '231', 7, 10, '123123123', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-28 12:18:52', '2025-05-28 12:18:52'),
(204, 96, '', 7, 10, '', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-28 12:32:28', '2025-05-28 12:32:28'),
(205, 85, '', 7, 4, '', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-28 12:37:54', '2025-05-28 12:37:54'),
(206, 96, '1321', 2, 10, '1231212312312312123123123', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-28 12:39:02', '2025-05-28 12:39:02'),
(207, 96, '213', 9, 10, '12', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-28 12:51:39', '2025-05-28 12:51:39'),
(208, 96, '21231', 2, 4, '123213', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-28 12:53:19', '2025-05-28 12:53:19'),
(209, 96, '', 1, 1, '', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-28 13:09:47', '2025-05-28 13:09:47'),
(210, 97, '', 2, 10, '', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-28 13:47:35', '2025-05-28 13:47:35'),
(211, 94, '', 1, 1, '', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-28 14:02:07', '2025-05-28 14:02:07'),
(212, 94, '', 1, 1, '', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-28 14:30:21', '2025-05-28 14:30:21'),
(213, 94, '', 7, 10, '', '     Lần / phút', '         mmHg', '         Lần/phút', '            kg', '             cm', '        °C', 'chỉ định', '2025-05-28 14:35:04', '2025-05-28 14:35:04');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `examination_medications`
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

--
-- Đang đổ dữ liệu cho bảng `examination_medications`
--

INSERT INTO `examination_medications` (`id`, `examination_id`, `medication_id`, `unit`, `dosage`, `route`, `times`, `note`, `quantity`, `price`, `created_at`, `updated_at`) VALUES
(101, 187, 10, 'Viên', '10mg', 'Uống', '1', 'Buổi tối', 1, '1800', '2025-05-25 14:11:45', '2025-05-25 14:11:45'),
(102, 187, 10, 'Viên', '10mg', 'Uống', '1', 'Buổi tối', 1, '1800', '2025-05-25 14:11:45', '2025-05-25 14:11:45'),
(103, 188, 5, 'Viên', '100mg', 'Uống', '3', 'Sau ăn', 1, '500', '2025-05-25 14:51:16', '2025-05-25 14:51:16'),
(104, 188, 5, 'Viên', '100mg', 'Uống', '3', 'Sau ăn', 1, '500', '2025-05-25 14:51:16', '2025-05-25 14:51:16'),
(105, 188, 5, 'Viên', '100mg', 'Uống', '3', 'Sau ăn', 1, '500', '2025-05-25 14:51:16', '2025-05-25 14:51:16'),
(106, 188, 5, 'Viên', '100mg', 'Uống', '3', 'Sau ăn', 1, '500', '2025-05-25 14:51:16', '2025-05-25 14:51:16');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `examination_results`
--

CREATE TABLE `examination_results` (
  `id` bigint(20) NOT NULL,
  `examination_service_id` bigint(20) NOT NULL,
  `template_id` bigint(20) DEFAULT NULL,
  `result` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
  `final_result` varchar(255) DEFAULT NULL,
  `file_path` longtext DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `examination_results`
--

INSERT INTO `examination_results` (`id`, `examination_service_id`, `template_id`, `result`, `final_result`, `file_path`, `created_at`, `updated_at`) VALUES
(86, 204, 60, '- Gan: Phản âm đồng nhất, bờ gan đều, kích thước không lớn.\r\n\r\n- Mật: Túi mật không sỏi, thành không dày, đường mật trong ngoài gan không dãn.\r\n\r\n- Tụy: Phản âm đồng nhất, kích thước không lớn.\r\n\r\n- Lách: Phản âm đồng nhất, kích thước không lớn. \r\n\r\n- Thận phải: Không sỏi, không ứ nước, phân biệt vỏ tuỷ rõ.\r\n\r\n- Thận trái: Không sỏi, không ứ nước, phân biệt vỏ tuỷ rõ.\r\n\r\n- Bàng quang: Không sỏi, thành không dày.\r\n\r\n- Tử cung: Trung gian, DAP mm, nội mạc mỏng, cấu trúc đồng nhất.\r\n\r\n- Hai phần phụ:  \r\n         + P: Chưa ghi nhận bất thường.\r\n\r\n        + T: Chưa ghi nhận bất thường.\r\n- Dịch ở bụng, dịch màng phổi: Không có.\r\n\r\n- Ghi nhận khác: Không.', '123123', '', '2025-05-24 13:09:37', '2025-05-24 13:09:37'),
(87, 204, 60, '- Gan: Phản âm đồng nhất, bờ gan đều, kích thước không lớn.\r\n\r\n- Mật: Túi mật không sỏi, thành không dày, đường mật trong ngoài gan không dãn.\r\n\r\n- Tụy: Phản âm đồng nhất, kích thước không lớn.\r\n\r\n- Lách: Phản âm đồng nhất, kích thước không lớn. \r\n\r\n- Thận phải: Không sỏi, không ứ nước, phân biệt vỏ tuỷ rõ.\r\n\r\n- Thận trái: Không sỏi, không ứ nước, phân biệt vỏ tuỷ rõ.\r\n\r\n- Bàng quang: Không sỏi, thành không dày.\r\n\r\n- Tử cung: Trung gian, DAP mm, nội mạc mỏng, cấu trúc đồng nhất.\r\n\r\n- Hai phần phụ:  \r\n         + P: Chưa ghi nhận bất thường.\r\n\r\n        + T: Chưa ghi nhận bất thường.\r\n- Dịch ở bụng, dịch màng phổi: Không có.\r\n\r\n- Ghi nhận khác: Không.', '123123', '', '2025-05-24 13:19:50', '2025-05-24 13:20:33'),
(88, 204, 60, '- Gan: Phản âm đồng nhất, bờ gan đều, kích thước không lớn.\r\n\r\n- Mật: Túi mật không sỏi, thành không dày, đường mật trong ngoài gan không dãn.\r\n\r\n- Tụy: Phản âm đồng nhất, kích thước không lớn.\r\n\r\n- Lách: Phản âm đồng nhất, kích thước không lớn. \r\n\r\n- Thận phải: Không sỏi, không ứ nước, phân biệt vỏ tuỷ rõ.\r\n\r\n- Thận trái: Không sỏi, không ứ nước, phân biệt vỏ tuỷ rõ.\r\n\r\n- Bàng quang: Không sỏi, thành không dày.\r\n\r\n- Tử cung: Trung gian, DAP mm, nội mạc mỏng, cấu trúc đồng nhất.\r\n\r\n- Hai phần phụ:  \r\n         + P: Chưa ghi nhận bất thường.\r\n\r\n        + T: Chưa ghi nhận bất thường.\r\n- Dịch ở bụng, dịch màng phổi: Không có.\r\n\r\n- Ghi nhận khác: Không.', '123123', '', '2025-05-24 13:20:07', '2025-05-24 13:20:33'),
(89, 206, 57, '1/ Số thai : 01    \r\n     + Ngôi thai: Đầu. \r\n     + Tim thai (+): lần/phút, đều rõ                        \r\n2/ Nhau - dây rốn:\r\n      +  Vị trí : Bám mặt trước thân tử cung. \r\n      + Nhóm:   I                 \r\n      + Độ trưởng thành:    3                                    \r\n3/ Nước ối:  AFI#  cm                  \r\n4/Chỉ số sinh học :\r\n\r\n              + ĐK lưỡng đỉnh (BPD): mm\r\n              + Chiều dài xương đùi: FL: mm\r\n              + Chu vi bụng (AC): mm        \r\n5/ Ước lượng cân nặng: # g             \r\n6/ Ước lượng tuổi thai: # tuần     \r\n7/Dự sanh (dương lịch): (theo dự sanh 3 tháng đầu)                                          \r\n8/Cơ quan khác:', '', 'f838d09e-4c45-458f-9955-0e5ecfb1c6df.jpg,41c7319d-9e1a-45ff-aa44-d7862bf66ab0.jpg', '2025-05-24 13:32:40', '2025-05-24 13:42:18'),
(90, 207, 54, '', '', 'images/ef363136-ce29-42c9-98b7-78985634431e.jpg', '2025-05-24 13:37:24', '2025-05-24 13:37:24'),
(91, 209, 57, '1/ Số thai : 01    \r\n     + Ngôi thai: Đầu. \r\n     + Tim thai (+): lần/phút, đều rõ                        \r\n2/ Nhau - dây rốn:\r\n      +  Vị trí : Bám mặt trước thân tử cung. \r\n      + Nhóm:   I                 \r\n      + Độ trưởng thành:    3                                    \r\n3/ Nước ối:  AFI#  cm                  \r\n4/Chỉ số sinh học :\r\n\r\n              + ĐK lưỡng đỉnh (BPD): mm\r\n              + Chiều dài xương đùi: FL: mm\r\n              + Chu vi bụng (AC): mm        \r\n5/ Ước lượng cân nặng: # g             \r\n6/ Ước lượng tuổi thai: # tuần     \r\n7/Dự sanh (dương lịch): (theo dự sanh 3 tháng đầu)                                          \r\n8/Cơ quan khác:', '11', '76db8d49-cf0a-4853-80ab-a5483af8514b.jpg,9693ae8d-72c6-4997-bcd9-fd43cf00b03a.jpg,eaf52b99-1051-48da-8aec-a298e44037ae.jpg', '2025-05-24 13:40:40', '2025-05-24 13:49:13'),
(92, 209, 57, '1/ Số thai : 01    \r\n     + Ngôi thai: Đầu. \r\n     + Tim thai (+): lần/phút, đều rõ                        \r\n2/ Nhau - dây rốn:\r\n      +  Vị trí : Bám mặt trước thân tử cung. \r\n      + Nhóm:   I                 \r\n      + Độ trưởng thành:    3                                    \r\n3/ Nước ối:  AFI#  cm                  \r\n4/Chỉ số sinh học :\r\n\r\n              + ĐK lưỡng đỉnh (BPD): mm\r\n              + Chiều dài xương đùi: FL: mm\r\n              + Chu vi bụng (AC): mm        \r\n5/ Ước lượng cân nặng: # g             \r\n6/ Ước lượng tuổi thai: # tuần     \r\n7/Dự sanh (dương lịch): (theo dự sanh 3 tháng đầu)                                          \r\n8/Cơ quan khác:', '11', '76db8d49-cf0a-4853-80ab-a5483af8514b.jpg,9693ae8d-72c6-4997-bcd9-fd43cf00b03a.jpg,eaf52b99-1051-48da-8aec-a298e44037ae.jpg', '2025-05-24 13:40:54', '2025-05-24 13:49:13'),
(93, 210, 33, '- Các đường cong sinh lý: Trong giới hạn bình thường.\r\n\r\n- Các đốt sống thắt lưng: Không ghi nhận hình ảnh bất thường.\r\n\r\n- Gian đốt sống: Trong giới hạn bình thường.\r\n\r\n- Lỗ liên hợp : Hạn chế khảo sát.\r\n\r\n- Các bộ phận khác: Chưa phát hiện bất thường.', '123', NULL, '2025-05-25 03:20:50', '2025-05-25 03:20:50'),
(94, 212, 66, '■ Vent.          rate                                        bpm\r\n\r\n■ PR              int.                                          ms\r\n\r\n■ QRS            dur.                                        ms\r\n\r\n■ QT / QTc     int.                                          ms\r\n\r\n■ P / QRS / T  axis                                         o\r\n\r\n■ RV5 / SV1   amp.                                       mV\r\n\r\n■ RV5+SV1     amp.                                       mV', '123', NULL, '2025-05-25 03:35:30', '2025-05-25 03:35:30'),
(95, 213, 58, '- Thùy phải: Kích thước không to, cấu trúc đồng nhất, không tăng sinh mạch máu.\r\n\r\n   + Đường kính ngang:  mm\r\n\r\n   + Đường kính dọc:  mm\r\n\r\n   + Bề dày:  mm\r\n   + Tổn thương khu trú: Chưa ghi nhận.\r\n\r\n - Thùy trái: Kích thước không to, cấu trúc đồng nhất, không tăng sinh mạch máu.\r\n\r\n   + Đường kính ngang:  mm\r\n\r\n   + Đường kính dọc:  mm\r\n\r\n   + Bề dày:  mm.\r\n   + Tổn thương khu trú: Chưa ghi nhận.\r\n\r\n- Eo giáp:  mm\r\n\r\n- Hạch cổ: Không phát hiện hạch bất thường.\r\n- Hạch góc hàm: Không phát hiện hạch bất thường.\r\n\r\n- Ghi nhận khác: Không có.', '12312312312312123123', '6398112d-9039-40e3-bac2-6e0b08f40211.jpg,3f25e3bb-c86d-473f-9206-02ec8b18df11.jpg', '2025-05-25 04:02:09', '2025-05-25 07:43:04'),
(96, 210, 37, '- Cấu trúc xương trụ: Chưa ghi nhận tổn thương.\r\n\r\n\r\n\r\n- Cấu trúc xương quay: Chưa ghi nhận tổn thương.\r\n\r\n\r\n\r\n- Khớp khủyu: Chưa ghi nhận tổn thương.\r\n\r\n\r\n\r\n - Khớp cổ tay: Chưa ghi nhận tổn thương.', '', NULL, '2025-05-26 01:01:11', '2025-05-26 01:01:11'),
(97, 214, 35, '- Cấu trúc xương cánh tay: Chưa ghi nhận bất thường\r\n\r\n- Khớp vai: Chưa ghi nhận bất thường\r\n\r\n- Khớp khủyu: Chưa ghi nhận bất thường', '', NULL, '2025-05-26 15:46:37', '2025-05-26 15:46:37'),
(98, 222, 34, '- Đầu trên  xương cánh tay: Chưa phát hiện bất thường.\r\n\r\n- Mỏm cùng đòn: Chưa phát hiện bất thường.\r\n\r\n- Xương bả vai: Chưa phát hiện bất thường.\r\n\r\n- Xương đòn: Chưa phát hiện bất thường.', '', NULL, '2025-05-27 01:52:52', '2025-05-27 01:52:52'),
(99, 223, 36, '- Cấu trúc đầu dưới xương cánh tay: Chưa ghi nhận tổn thương.\r\n\r\n\r\n\r\n- Cấu trúc đầu trên xương trụ: Chưa ghi nhận tổn thương.\r\n\r\n\r\n\r\n- Cấu trúc đầu trên xương quay: Chưa ghi nhận tổn thương.', '', NULL, '2025-05-27 03:12:10', '2025-05-27 03:12:30'),
(100, 244, 55, '* Tử cung: Trung gian, DAP = mm, lòng tử cung có 01 túi thai, bờ đều căng tròn, bên trong có yolksac, có phôi.\r\n\r\n*Tim thai (+)  lần/phút.\r\n\r\n* GS: mm\r\n \r\n* CRL:  mm\r\n\r\n* Buồng trứng phải: chưa ghi nhận bất thường.\r\n\r\n* Buồng trứng trái: chưa ghi nhận bất thường.\r\n\r\n* Túi cùng: không dịch \r\n\r\n* Ngày dự sanh (dương lịch):', 'MỘT TÚI THAI TRONG LÒNG TỬ CUNG, TUỔI THAI KHOẢNG  TUẦN.', '68493bd9-9532-42b6-ba1c-0839b9953c42.jpg,2f984a89-a08f-4eaa-bd5f-2ba067d906e4.jpg', '2025-05-27 09:38:28', '2025-05-27 09:39:11'),
(101, 245, 55, '', '', 'images/90306ef6-6153-4395-8e4d-582562151823.jpg,images/926c9074-b537-47f3-864a-d77812e4f30c.jpg', '2025-05-27 09:38:40', '2025-05-27 09:38:40'),
(102, 244, 55, '* Tử cung: Trung gian, DAP = mm, lòng tử cung có 01 túi thai, bờ đều căng tròn, bên trong có yolksac, có phôi.\r\n\r\n*Tim thai (+)  lần/phút.\r\n\r\n* GS: mm\r\n \r\n* CRL:  mm\r\n\r\n* Buồng trứng phải: chưa ghi nhận bất thường.\r\n\r\n* Buồng trứng trái: chưa ghi nhận bất thường.\r\n\r\n* Túi cùng: không dịch \r\n\r\n* Ngày dự sanh (dương lịch):', 'MỘT TÚI THAI TRONG LÒNG TỬ CUNG, TUỔI THAI KHOẢNG  TUẦN.', '68493bd9-9532-42b6-ba1c-0839b9953c42.jpg,2f984a89-a08f-4eaa-bd5f-2ba067d906e4.jpg', '2025-05-27 09:38:52', '2025-05-27 09:39:11'),
(111, 272, 70, '[{\"name\":\"1\",\"results\":[{\"test_name\":\"1\",\"result\":\"1\",\"unit\":\"1\",\"normal_range\":\"123123123\"}]},{\"name\":\"2\",\"results\":[{\"test_name\":\"2\",\"result\":\"2\",\"unit\":\"2\",\"normal_range\":\"1231231\"}]}]', '123123123123213', NULL, '2025-05-28 14:05:18', '2025-05-28 14:05:18'),
(112, 273, 70, '[{\"name\":\"12\",\"results\":[{\"test_name\":\"2\",\"result\":\"1\",\"unit\":\"1\",\"normal_range\":\"1\"}]},{\"name\":\"2\",\"results\":[{\"test_name\":\"2\",\"result\":\"2\",\"unit\":\"2\",\"normal_range\":\"2\"}]}]', '123', NULL, '2025-05-28 14:06:40', '2025-05-28 14:06:40'),
(113, 274, 70, '[{\"name\":\"9\",\"results\":[{\"test_name\":\"9\",\"result\":\"9\",\"unit\":\"9\",\"normal_range\":\"9\"},{\"test_name\":\"9\",\"result\":\"9\",\"unit\":\"9\",\"normal_range\":\"9\"}]}]', 'cans213123123213123', NULL, '2025-05-28 14:07:11', '2025-05-28 14:07:41'),
(114, 268, 69, '[{\"name\":\"Xét nghiệm viêm gan B\",\"results\":[{\"test_name\":\"HBsAg\",\"result\":\"Negative\",\"unit\":\"123\",\"normal_range\":\"Negative\"},{\"test_name\":\"Anti-HBs\",\"result\":\"Positive\",\"unit\":\"123\",\"normal_range\":\"Positive\"},{\"test_name\":\"Anti-HBc\",\"result\":\"Negative\",\"unit\":\"123\",\"normal_range\":\"Negative\"}]},{\"name\":\"Xét nghiệm viêm gan C\",\"results\":[{\"test_name\":\"Anti-HCV\",\"result\":\"Negative\",\"unit\":\"123\",\"normal_range\":\"Negative\"},{\"test_name\":\"HCV RNA\",\"result\":\"Negative\",\"unit\":\"123\",\"normal_range\":\"Negative\"}]},{\"name\":\"Xét nghiệm đường huyết\",\"results\":[{\"test_name\":\"Glucose (FPG)\",\"result\":\"95\",\"unit\":\"mg/dL\",\"normal_range\":\"70-100\"},{\"test_name\":\"HbA1c\",\"result\":\"5.2\",\"unit\":\"%\",\"normal_range\":\"<5.7\"}]},{\"name\":\"Xét nghiệm mỡ máu\",\"results\":[{\"test_name\":\"Cholesterol toàn phần\",\"result\":\"180\",\"unit\":\"mg/dL\",\"normal_range\":\"<200\"},{\"test_name\":\"HDL\",\"result\":\"55\",\"unit\":\"mg/dL\",\"normal_range\":\">40\"},{\"test_name\":\"LDL\",\"result\":\"100\",\"unit\":\"mg/dL\",\"normal_range\":\"<130\"},{\"test_name\":\"Triglyceride\",\"result\":\"120\",\"unit\":\"mg/dL\",\"normal_range\":\"<150\"}]},{\"name\":\"Xét nghiệm chức năng gan\",\"results\":[{\"test_name\":\"ALT (GPT)\",\"result\":\"25\",\"unit\":\"U/L\",\"normal_range\":\"<40\"},{\"test_name\":\"AST (GOT)\",\"result\":\"22\",\"unit\":\"U/L\",\"normal_range\":\"<40\"},{\"test_name\":\"GGT\",\"result\":\"30\",\"unit\":\"U/L\",\"normal_range\":\"10-50\"},{\"test_name\":\"Bilirubin toàn phần\",\"result\":\"0.8\",\"unit\":\"mg/dL\",\"normal_range\":\"<1.2\"}]},{\"name\":\"Xét nghiệm chức năng thận\",\"results\":[{\"test_name\":\"Creatinine\",\"result\":\"1.0\",\"unit\":\"mg/dL\",\"normal_range\":\"0.7-1.3\"},{\"test_name\":\"Urea\",\"result\":\"18\",\"unit\":\"mg/dL\",\"normal_range\":\"10-50\"},{\"test_name\":\"eGFR\",\"result\":\"90\",\"unit\":\"mL/min/1.73m²\",\"normal_range\":\">60\"}]},{\"name\":\"Tổng phân tích tế bào máu\",\"results\":[{\"test_name\":\"WBC\",\"result\":\"6.5\",\"unit\":\"10^3/uL\",\"normal_range\":\"4.0-10.0\"},{\"test_name\":\"RBC\",\"result\":\"4.8\",\"unit\":\"10^6/uL\",\"normal_range\":\"4.2-5.9\"},{\"test_name\":\"Hemoglobin\",\"result\":\"14.5\",\"unit\":\"g/dL\",\"normal_range\":\"13.0-17.0\"},{\"test_name\":\"Hematocrit\",\"result\":\"42\",\"unit\":\"%\",\"normal_range\":\"38-50\"},{\"test_name\":\"Platelet\",\"result\":\"250\",\"unit\":\"10^3/uL\",\"normal_range\":\"150-450\"}]}]', '123123', NULL, '2025-05-28 14:13:57', '2025-05-28 14:13:57');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `examination_services`
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
-- Đang đổ dữ liệu cho bảng `examination_services`
--

INSERT INTO `examination_services` (`id`, `examination_id`, `service_id`, `price`, `created_at`, `updated_at`) VALUES
(200, 178, 28, 120000, '2025-05-24 13:08:35', '2025-05-24 13:08:35'),
(201, 178, 28, 120000, '2025-05-24 13:08:35', '2025-05-24 13:08:35'),
(202, 178, 28, 120000, '2025-05-24 13:08:35', '2025-05-24 13:08:35'),
(203, 179, 30, 120000, '2025-05-24 13:08:55', '2025-05-24 13:08:55'),
(204, 179, 16, 100000, '2025-05-24 13:08:55', '2025-05-24 13:08:55'),
(205, 179, 50, 120000, '2025-05-24 13:08:55', '2025-05-24 13:08:55'),
(206, 180, 19, 100000, '2025-05-24 13:32:16', '2025-05-24 13:32:16'),
(207, 181, 21, 100000, '2025-05-24 13:37:11', '2025-05-24 13:37:11'),
(208, 182, 35, 120000, '2025-05-24 13:40:11', '2025-05-24 13:40:11'),
(209, 182, 23, 100000, '2025-05-24 13:40:11', '2025-05-24 13:40:11'),
(210, 183, 28, 120000, '2025-05-25 03:20:21', '2025-05-25 03:20:21'),
(211, 184, 52, 1, '2025-05-25 03:33:24', '2025-05-25 03:33:24'),
(212, 185, 53, 1, '2025-05-25 03:34:58', '2025-05-25 03:34:58'),
(213, 186, 20, 100000, '2025-05-25 04:01:51', '2025-05-25 04:01:51'),
(214, 189, 28, 120000, '2025-05-26 09:02:55', '2025-05-26 09:02:55'),
(215, 189, 28, 120000, '2025-05-26 09:02:55', '2025-05-26 09:02:55'),
(216, 189, 28, 120000, '2025-05-26 09:02:55', '2025-05-26 09:02:55'),
(217, 189, 29, 120000, '2025-05-26 09:02:55', '2025-05-26 09:02:55'),
(218, 189, 30, 120000, '2025-05-26 09:02:55', '2025-05-26 09:02:55'),
(219, 190, 52, 1, '2025-05-26 10:10:25', '2025-05-26 10:10:25'),
(220, 191, 28, 120000, '2025-05-26 15:48:26', '2025-05-26 15:48:26'),
(221, 191, 28, 120000, '2025-05-26 15:48:26', '2025-05-26 15:48:26'),
(222, 193, 28, 120000, '2025-05-27 01:43:41', '2025-05-27 01:43:41'),
(223, 194, 28, 120000, '2025-05-27 01:55:49', '2025-05-27 01:55:49'),
(224, 194, 29, 120000, '2025-05-27 01:55:49', '2025-05-27 01:55:49'),
(225, 195, 28, 120000, '2025-05-27 02:00:05', '2025-05-27 02:00:05'),
(226, 195, 28, 120000, '2025-05-27 02:00:05', '2025-05-27 02:00:05'),
(227, 195, 28, 120000, '2025-05-27 02:00:05', '2025-05-27 02:00:05'),
(228, 196, 1, 100000, '2025-05-27 02:25:48', '2025-05-27 02:25:48'),
(229, 196, 52, 1, '2025-05-27 02:25:48', '2025-05-27 02:25:48'),
(230, 197, 1, 100000, '2025-05-27 02:25:56', '2025-05-27 02:25:56'),
(231, 197, 52, 1, '2025-05-27 02:25:56', '2025-05-27 02:25:56'),
(232, 197, 1, 100000, '2025-05-27 02:25:56', '2025-05-27 02:25:56'),
(233, 197, 52, 1, '2025-05-27 02:25:56', '2025-05-27 02:25:56'),
(234, 198, 1, 100000, '2025-05-27 02:26:24', '2025-05-27 02:26:24'),
(235, 198, 52, 1, '2025-05-27 02:26:24', '2025-05-27 02:26:24'),
(236, 198, 1, 100000, '2025-05-27 02:26:24', '2025-05-27 02:26:24'),
(237, 198, 52, 1, '2025-05-27 02:26:24', '2025-05-27 02:26:24'),
(238, 198, 1, 100000, '2025-05-27 02:26:24', '2025-05-27 02:26:24'),
(239, 199, 53, 1, '2025-05-27 02:52:56', '2025-05-27 02:52:56'),
(240, 200, 53, 1, '2025-05-27 02:53:03', '2025-05-27 02:53:03'),
(241, 200, 53, 1, '2025-05-27 02:53:03', '2025-05-27 02:53:03'),
(242, 201, 17, 100000, '2025-05-27 02:55:13', '2025-05-27 02:55:13'),
(243, 201, 18, 100000, '2025-05-27 02:55:13', '2025-05-27 02:55:13'),
(244, 202, 17, 100000, '2025-05-27 02:55:33', '2025-05-27 02:55:33'),
(245, 202, 18, 100000, '2025-05-27 02:55:33', '2025-05-27 02:55:33'),
(246, 202, 17, 100000, '2025-05-27 02:55:33', '2025-05-27 02:55:33'),
(247, 202, 16, 100000, '2025-05-27 02:55:33', '2025-05-27 02:55:33'),
(248, 203, 28, 120000, '2025-05-28 12:18:52', '2025-05-28 12:18:52'),
(249, 203, 41, 120000, '2025-05-28 12:18:52', '2025-05-28 12:18:52'),
(250, 204, 28, 120000, '2025-05-28 12:32:28', '2025-05-28 12:32:28'),
(251, 204, 29, 120000, '2025-05-28 12:32:28', '2025-05-28 12:32:28'),
(252, 205, 28, 120000, '2025-05-28 12:37:54', '2025-05-28 12:37:54'),
(253, 205, 30, 120000, '2025-05-28 12:37:54', '2025-05-28 12:37:54'),
(254, 205, 32, 120000, '2025-05-28 12:37:54', '2025-05-28 12:37:54'),
(255, 206, 28, 120000, '2025-05-28 12:39:02', '2025-05-28 12:39:02'),
(256, 206, 30, 120000, '2025-05-28 12:39:02', '2025-05-28 12:39:02'),
(257, 206, 40, 120000, '2025-05-28 12:39:02', '2025-05-28 12:39:02'),
(258, 207, 28, 120000, '2025-05-28 12:51:39', '2025-05-28 12:51:39'),
(259, 207, 33, 120000, '2025-05-28 12:51:39', '2025-05-28 12:51:39'),
(260, 207, 35, 120000, '2025-05-28 12:51:39', '2025-05-28 12:51:39'),
(261, 208, 28, 120000, '2025-05-28 12:53:19', '2025-05-28 12:53:19'),
(262, 208, 29, 120000, '2025-05-28 12:53:19', '2025-05-28 12:53:19'),
(263, 209, 52, 1, '2025-05-28 13:09:47', '2025-05-28 13:09:47'),
(264, 210, 28, 120000, '2025-05-28 13:47:35', '2025-05-28 13:47:35'),
(265, 210, 16, 100000, '2025-05-28 13:47:35', '2025-05-28 13:47:35'),
(266, 210, 39, 120000, '2025-05-28 13:47:35', '2025-05-28 13:47:35'),
(267, 210, 22, 100000, '2025-05-28 13:47:35', '2025-05-28 13:47:35'),
(268, 210, 52, 1, '2025-05-28 13:47:35', '2025-05-28 13:47:35'),
(269, 210, 53, 1, '2025-05-28 13:47:35', '2025-05-28 13:47:35'),
(270, 210, 1, 100000, '2025-05-28 13:47:35', '2025-05-28 13:47:35'),
(271, 210, 53, 1, '2025-05-28 13:47:35', '2025-05-28 13:47:35'),
(272, 211, 52, 1, '2025-05-28 14:02:07', '2025-05-28 14:02:07'),
(273, 211, 52, 1, '2025-05-28 14:02:07', '2025-05-28 14:02:07'),
(274, 211, 52, 1, '2025-05-28 14:02:07', '2025-05-28 14:02:07'),
(275, 211, 52, 1, '2025-05-28 14:02:07', '2025-05-28 14:02:07'),
(276, 211, 52, 1, '2025-05-28 14:02:07', '2025-05-28 14:02:07'),
(277, 211, 52, 1, '2025-05-28 14:02:07', '2025-05-28 14:02:07'),
(278, 211, 52, 1, '2025-05-28 14:02:07', '2025-05-28 14:02:07'),
(279, 211, 52, 1, '2025-05-28 14:02:07', '2025-05-28 14:02:07'),
(280, 211, 52, 1, '2025-05-28 14:02:07', '2025-05-28 14:02:07'),
(281, 211, 52, 1, '2025-05-28 14:02:07', '2025-05-28 14:02:07'),
(282, 211, 52, 1, '2025-05-28 14:02:07', '2025-05-28 14:02:07'),
(283, 211, 52, 1, '2025-05-28 14:02:07', '2025-05-28 14:02:07'),
(284, 211, 52, 1, '2025-05-28 14:02:07', '2025-05-28 14:02:07'),
(285, 211, 52, 1, '2025-05-28 14:02:07', '2025-05-28 14:02:07'),
(286, 212, 28, 120000, '2025-05-28 14:30:21', '2025-05-28 14:30:21'),
(287, 212, 30, 120000, '2025-05-28 14:30:21', '2025-05-28 14:30:21'),
(288, 212, 32, 120000, '2025-05-28 14:30:21', '2025-05-28 14:30:21'),
(289, 212, 36, 120000, '2025-05-28 14:30:21', '2025-05-28 14:30:21'),
(290, 213, 28, 120000, '2025-05-28 14:35:04', '2025-05-28 14:35:04'),
(291, 213, 37, 120000, '2025-05-28 14:35:04', '2025-05-28 14:35:04'),
(292, 213, 45, 120000, '2025-05-28 14:35:04', '2025-05-28 14:35:04');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `medications`
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
-- Đang đổ dữ liệu cho bảng `medications`
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
-- Cấu trúc bảng cho bảng `patients`
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
-- Đang đổ dữ liệu cho bảng `patients`
--

INSERT INTO `patients` (`id`, `name`, `date_of_birth`, `gender`, `phone`, `address`, `created_at`, `updated_at`) VALUES
(85, 'Nguyễn Văn An', '1987-11-12', 'Nam', '0925369147', 'Vĩnh Long', '2025-05-18 12:15:23', '2025-05-28 12:08:43'),
(86, 'Nguyễn Văn An', '1987-11-12', 'Nam', '0925369147', 'Vĩnh Long', '2025-05-18 12:16:21', '2025-05-24 12:34:50'),
(87, 'Trần Thị Bích Ngọc', '1990-05-22', 'Nữ', '0912345678', 'TP. Hồ Chí Minh', '2025-05-18 12:16:21', '2025-05-18 12:16:21'),
(88, 'Lê Văn Hùng', '1985-03-15', 'Nam', '0987654321', 'Hà Nội', '2025-05-18 12:16:21', '2025-05-27 01:23:22'),
(89, 'Phạm Minh Châu', '1992-09-30', 'Nữ', '0932112233', 'Đà Nẵng', '2025-05-18 12:16:21', '2025-05-18 12:16:21'),
(90, 'Võ Thị Thu Trang', '1995-01-10', 'Nữ', '0969988776', 'Cần Thơ', '2025-05-18 12:16:21', '2025-05-27 02:48:07'),
(91, 'Đỗ Mạnh Hùng', '1980-07-07', 'Nam', '0971122334', 'Hải Phòng', '2025-05-18 12:16:21', '2025-05-27 01:47:01'),
(92, 'Ngô Thị Hằng', '1993-04-25', 'Nữ', '0901234567', 'Huế', '2025-05-18 12:16:21', '2025-05-27 01:45:37'),
(93, 'Bùi Văn Khánh', '1978-12-20', 'Nam', '0944556677', 'Nghệ An', '2025-05-18 12:16:21', '2025-05-27 01:43:19'),
(94, 'Hoàng Thị Mai', '1988-06-18', 'Nữ', '0911999888', 'Quảng Nam', '2025-05-18 12:16:21', '2025-05-28 13:47:06'),
(95, 'Trịnh Quốc Toàn', '1991-08-08', 'Nam', '0955778899', 'Bình Dương', '2025-05-18 12:16:21', '2025-05-27 01:25:30'),
(96, 'nguyễn Văn An', '1987-05-18', 'Nam', '09070161785', 'An Phước, Vĩnh Long 1', '2025-05-18 12:19:55', '2025-05-28 12:08:40'),
(97, 'nguyễn văn tính', '2025-05-18', 'Nam', '0845969989', 'bình phuoc', '2025-05-18 14:12:23', '2025-05-28 13:47:08'),
(100, '1231212', '2025-05-26', 'Nam', '12312', '123', '2025-05-26 13:28:33', '2025-05-27 01:23:47');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `services`
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
-- Đang đổ dữ liệu cho bảng `services`
--

INSERT INTO `services` (`id`, `name`, `type`, `content`, `price`, `created_at`, `updated_at`) VALUES
(1, 'Xét nghiệm công thức máu', 'Xét nghiệm', 'Phân tích các thành phần tế bào máu', 100000, '2025-01-10 02:00:00', '2025-04-04 13:26:16'),
(15, 'Siêu âm tuyến vú hai bên', 'Siêu âm', NULL, 100000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(16, 'Siêu âm thai quý 1', 'Siêu âm', NULL, 100000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(17, 'Siêu âm thai quý 2', 'Siêu âm', NULL, 100000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(18, 'Siêu âm thai quý 3', 'Siêu âm', NULL, 100000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(19, 'Siêu âm tuyến giáp', 'Siêu âm', NULL, 100000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(20, 'Siêu âm tổng quát nam', 'Siêu âm', NULL, 100000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(21, 'Siêu âm tổng quát nữ', 'Siêu âm', NULL, 100000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(22, 'Siêu âm tổng quát nữ - mãn kinh', 'Siêu âm', NULL, 100000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(23, 'Siêu âm tử cung phần phụ', 'Siêu âm', NULL, 100000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(24, 'Siêu âm mô mềm', 'Siêu âm', NULL, 100000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(25, 'Siêu âm tĩnh mạch chi dưới', 'Siêu âm', NULL, 150000, '2025-05-18 14:23:13', '2025-05-18 14:24:34'),
(26, 'Siêu âm động mạch cảnh', 'Siêu âm', NULL, 150000, '2025-05-18 14:23:13', '2025-05-18 14:24:43'),
(27, 'Siêu âm doppler tim', 'Siêu âm', NULL, 150000, '2025-05-18 14:23:13', '2025-05-18 14:24:22'),
(28, 'Xquang ngực thẳng', 'X-quang', NULL, 120000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(29, 'Xquang cột sống cổ chếch', 'X-quang', NULL, 120000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(30, 'Xquang cột sống cổ thẳng nghiêng', 'X-quang', NULL, 120000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(31, 'Xquang cột sống thắt lưng', 'X-quang', NULL, 120000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(32, 'Xquang vai', 'X-quang', NULL, 120000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(33, 'Xquang cánh tay', 'X-quang', NULL, 120000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(34, 'Xquang khuỷu tay', 'X-quang', NULL, 120000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(35, 'Xquang cẳng tay', 'X-quang', NULL, 120000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(36, 'Xquang cổ tay', 'X-quang', NULL, 120000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(37, 'Xquang bàn tay', 'X-quang', NULL, 120000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(38, 'Xquang khung chậu', 'X-quang', NULL, 120000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(39, 'Xquang xương đùi', 'X-quang', NULL, 120000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(40, 'Xquang khớp gối', 'X-quang', NULL, 120000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(41, 'Xquang cẳng chân', 'X-quang', NULL, 120000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(42, 'Xquang cổ chân', 'X-quang', NULL, 120000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(43, 'Xquang bàn chân', 'X-quang', NULL, 120000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(44, 'Xquang xương gót', 'X-quang', NULL, 120000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(45, 'Xquang bụng đứng', 'X-quang', NULL, 120000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(46, 'Xquang sọ', 'X-quang', NULL, 120000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(47, 'Xquang Blondeau', 'X-quang', NULL, 120000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(48, 'Xquang Hitz', 'X-quang', NULL, 120000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(49, 'Xquang xương mũi nghiêng', 'X-quang', NULL, 120000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(50, 'Xquang xương hàm chếch', 'X-quang', NULL, 120000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(51, 'Hệ niệu không chuẩn bị (KUB)', 'X-quang', NULL, 120000, '2025-05-18 14:23:13', '2025-05-18 14:23:13'),
(52, 'Xét nghiệm', 'Xét nghiệm', '1', 1, '2025-05-25 03:33:08', '2025-05-25 03:33:08'),
(53, 'ĐT', 'Điện tim', '1', 1, '2025-05-25 03:34:34', '2025-05-25 03:34:34');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `templates`
--

CREATE TABLE `templates` (
  `id` bigint(20) NOT NULL,
  `name` varchar(255) NOT NULL,
  `type` varchar(25) NOT NULL,
  `template_content` longtext NOT NULL,
  `result_content` varchar(200) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `templates`
--

INSERT INTO `templates` (`id`, `name`, `type`, `template_content`, `result_content`, `created_at`, `updated_at`) VALUES
(30, 'XQUANG NGỰC THẲNG', 'X-quang', '* Thành ngực:\r\n\r\n       - Mô mềm: Chưa ghi nhận hình ảnh bất thường.\r\n       - Xương: Chưa ghi nhận hình ảnh bất thường. \r\n* Phổi hai bên:\r\n      - Cơ hoành, màng phổi hai bên: Trong giới hạn bình thường.\r\n\r\n      - Phế trường phổi: Không ghi nhận tổn thương nhu mô phổi 2 bên.\r\n\r\n      - Cấu trúc rốn phổi: Chưa ghi nhận hình ảnh bất thường.\r\n\r\n* Trung thất:\r\n\r\n      - Bóng tim: Trong giới hạn bình thường.\r\n\r\n      - Các mạch máu chính: Trong giới hạn bình thường.\r\n\r\n* Ghi nhận khác: Hiện tại không có ghi nhận khác.', 'Hiện tại chưa ghi nhận hình ảnh bất thường trên phim.', '2025-05-18 12:35:55', '2025-05-18 13:43:45'),
(31, 'XQUANG CỘT SỐNG CỔ CHẾCH', 'X-quang', '- Lỗ liên hợp bên (P): Trong giới hạn bình thường.\r\n\r\n- Lỗ liên hợp bên (T): Trong giới hạn bình thường.\r\n\r\n- Khoảng gian đốt sống cổ: Trong giới hạn bình thường.', 'Hiện tại chưa ghi nhận hình ảnh bất thường trên phim.', '2025-05-18 13:37:23', '2025-05-18 13:43:49'),
(32, 'XQUANG CỘT SỐNG CỔ THẲNG NGHIÊNG', 'X-quang', '- Các đường cong sinh lý cạnh cột sống: Không thấy bất thường.\r\n\r\n- Các đốt sống cổ: Chưa phát hiện tổn thương. \r\n\r\n- Khoảng gian đốt sống cổ: Trong giới hạn bình thường.', 'Hiện tại chưa ghi nhận hình ảnh bất thường trên phim.', '2025-05-18 13:44:24', '2025-05-18 13:45:14'),
(33, 'XQUANG CỘT SỐNG THĂT LƯNG', 'X-quang', '- Các đường cong sinh lý: Trong giới hạn bình thường.\r\n\r\n- Các đốt sống thắt lưng: Không ghi nhận hình ảnh bất thường.\r\n\r\n- Gian đốt sống: Trong giới hạn bình thường.\r\n\r\n- Lỗ liên hợp : Hạn chế khảo sát.\r\n\r\n- Các bộ phận khác: Chưa phát hiện bất thường.', 'Hiện tại chưa ghi nhận hình ảnh bất thường trên phim Xquang.', '2025-05-18 13:45:07', '2025-05-18 13:45:07'),
(34, 'XQUANG VAI', 'X-quang', '- Đầu trên  xương cánh tay: Chưa phát hiện bất thường.\r\n\r\n- Mỏm cùng đòn: Chưa phát hiện bất thường.\r\n\r\n- Xương bả vai: Chưa phát hiện bất thường.\r\n\r\n- Xương đòn: Chưa phát hiện bất thường.', 'Chưa phát hiện bất thường trên phim Xquang.', '2025-05-18 13:45:43', '2025-05-18 13:56:05'),
(35, 'XQUANG CÁNH TAY', 'X-quang', '- Cấu trúc xương cánh tay: Chưa ghi nhận bất thường\r\n\r\n- Khớp vai: Chưa ghi nhận bất thường\r\n\r\n- Khớp khủyu: Chưa ghi nhận bất thường', 'Chưa phát hiện bất thường trên phim Xquang.', '2025-05-18 13:46:31', '2025-05-18 13:46:31'),
(36, 'XQUANG KHUỶU TAY', 'X-quang', '- Cấu trúc đầu dưới xương cánh tay: Chưa ghi nhận tổn thương.\r\n\r\n\r\n\r\n- Cấu trúc đầu trên xương trụ: Chưa ghi nhận tổn thương.\r\n\r\n\r\n\r\n- Cấu trúc đầu trên xương quay: Chưa ghi nhận tổn thương.', 'Chưa phát hiện bất thường trên phim Xquang.', '2025-05-18 13:46:45', '2025-05-18 13:46:45'),
(37, 'XQUANG CẲNG TAY', 'X-quang', '- Cấu trúc xương trụ: Chưa ghi nhận tổn thương.\r\n\r\n\r\n\r\n- Cấu trúc xương quay: Chưa ghi nhận tổn thương.\r\n\r\n\r\n\r\n- Khớp khủyu: Chưa ghi nhận tổn thương.\r\n\r\n\r\n\r\n - Khớp cổ tay: Chưa ghi nhận tổn thương.', 'Chưa phát hiện bất thường trên phim Xquang.', '2025-05-18 13:47:03', '2025-05-18 13:47:03'),
(38, 'XQUANG CỔ TAY', 'X-quang', '- Cấu trúc đầu dưới xương quay: Chưa phát hiện tổn thương. \r\n\r\n\r\n\r\n- Cấu trúc đầu dưới xương trụ: Chưa phát hiện tổn thương.\r\n\r\n\r\n\r\n- Cấu trúc các xương cổ tay: Chưa phát hiện tổn thương. \r\n\r\n\r\n\r\n- Khe khớp: Trong giới hạn bình thường.', 'Chưa phát hiện bất thường trên phim Xquang.', '2025-05-18 13:47:24', '2025-05-18 13:47:24'),
(39, 'XQUANG BÀN TAY', 'X-quang', '- Cấu trúc các xương đốt bàn: Không ghi nhận bất thương.\r\n\r\n\r\n\r\n- Cấu trúc các xương đốt ngón: Không ghi nhận bất thương.\r\n\r\n\r\n\r\n- Cấu trúc các xương cổ tay: Không ghi nhận bất thương.\r\n\r\n\r\n\r\n- Các khe khớp: Không hẹp khe khớp.', 'Hiện tại chưa ghi nhận bất thường trên phim.', '2025-05-18 13:47:42', '2025-05-18 13:47:42'),
(40, 'XQUANG KHUNG CHẬU', 'X-quang', '- Cấu trúc xương chậu: Không ghi nhận tổn thương\r\n\r\n- Cấu trúc đầu trên xương đùi hai bên: Không ghi nhận tổn thương\r\n\r\n- Cấu trúc chiều dài cổ xương đùi: Không ghi nhận bất  thường\r\n\r\n- Đường shenton: Không biến dạng\r\n\r\n- Ghi nhận khác: Không ghi nhận tổn thương', 'Hiện không ghi nhận tổn thương xương vùng chậu', '2025-05-18 13:48:08', '2025-05-18 13:48:08'),
(41, 'XQUANG XƯƠNG ĐÙI', 'X-quang', '- Cấu trúc mô mềm đùi: Không hình ảnh bất thường.   \r\n\r\n\r\n\r\n- Cấu trúc xương đùi: Không hình ảnh bất thường. \r\n\r\n\r\n\r\n- Ghi nhận khác: Không có', 'Hiện tại chưa ghi nhận bất thường trên phim.', '2025-05-18 13:48:28', '2025-05-18 13:48:28'),
(42, 'XQUANG KHỚP GỐI', 'X-quang', '- Cấu trúc mô mềm: Chưa ghi nhận hình ảnh bất thường.\r\n\r\n\r\n\r\n- Cấu trúc 1/3 dưới xương đùi: Chưa ghi nhận hình ảnh bất thường.\r\n\r\n\r\n\r\n- Cấu trúc xương bánh chè: Chưa ghi nhận hình ảnh bất thường.\r\n\r\n\r\n\r\n- Cấu trúc 1/3  trên xương chày: Chưa ghi nhận hình ảnh bất thường.\r\n\r\n\r\n\r\n- Cấu trúc 1/3  trên xương mác: Chưa ghi nhận hình ảnh bất thường.\r\n\r\n\r\n\r\n- Khe khớp gối: Trong giới hạn bình thường.', 'Hiện tại chưa ghi nhận bất thường trên phim.', '2025-05-18 13:48:59', '2025-05-18 13:48:59'),
(43, 'XQUANG CẲNG CHÂN', 'X-quang', '- Cấu trúc xương chày: Chưa phát hiện tổn thương.\r\n\r\n\r\n\r\n- Cấu trúc xương mác: Chưa phát hiện tổn thương.\r\n\r\n\r\n\r\n- Ghi nhận khác: Không có.', 'Hiện tại chưa ghi nhận bất thường trên phim.', '2025-05-18 13:49:20', '2025-05-18 13:49:20'),
(44, 'XQUANG CỔ CHÂN', 'X-quang', '- Cấu trúc đầu dưới  xương chày: Chưa ghi nhận tổn thương.\r\n\r\n- Cấu trúc đầu dưới xương mác: Chưa ghi nhận tổn thương.\r\n\r\n- Cấu trúc các xương cổ chân: Chưa ghi nhận tổn thương. \r\n\r\n- Cấu trúc các xương bàn chân: Chưa ghi nhận tổn thương.\r\n\r\n- Khe khớp: Không hẹp khe khớp.', 'Hiện tại chưa ghi nhận bất thường trên phim.', '2025-05-18 13:49:47', '2025-05-18 13:49:47'),
(45, 'XQUANG BÀN CHÂN', 'X-quang', '- Cấu trúc xương cổ chân + gót chân: Chưa phát hiện tổn thương.\r\n\r\n\r\n\r\n- Cấu trúc các xương bàn chân: Chưa phát hiện tổn thương. \r\n\r\n\r\n\r\n- Cấu trúc xương ngón chân: Chưa phát hiện tổn thương.\r\n\r\n\r\n\r\n- Khe khớp: Trong giới hạn bình thường.\r\n\r\n\r\n\r\n- Xương vừng: Chưa phát hiện tổn thương.', 'Hiện tại chưa ghi nhận bất thường trên phim.', '2025-05-18 13:50:06', '2025-05-18 13:50:06'),
(46, 'XQUANG XƯƠNG GÓT', 'X-quang', '- Xương gót: Chưa ghi nhận tổn  thương\r\n\r\n- Ghi nhận khác: Chưa ghi nhận tổn  thương\r\n\r\n- Góc Bohler: >20°.', 'Hiện tại chưa ghi nhận bất thường trên phim.', '2025-05-18 13:50:31', '2025-05-18 13:50:31'),
(47, 'XQUANG  BỤNG ĐỨNG', 'X-quang', '- Liềm hơi dưới hoành 2 bên:  Hiện tại chưa phát hiện bất thường.\r\n\r\n\r\n\r\n- Mực nước hơi bất thường: Trong giới hạn bình thường\r\n\r\n\r\n\r\n- Đóng vôi bất thường trong ổ bụng: Hiện tại chưa phát hiện bất thường.\r\n\r\n\r\n\r\n- Ghi nhận khác: Không có.', 'Hiện tại chưa ghi nhận bất thường trên phim.', '2025-05-18 13:50:48', '2025-05-18 13:50:48'),
(48, 'XQUANG SỌ', 'X-quang', '* Cấu trúc mô mềm: Không phát hiện hình ảnh bất thường trên phim.\r\n\r\n\r\n\r\n* Cấu trúc xương hộp sọ: Không phát hiện hình ảnh bất thường trên phim.\r\n\r\n\r\n\r\n* Các khớp sọ: Trong giới hạn bình thường.\r\n\r\n\r\n\r\n* Ghi nhận khác: Không có.', 'Hiện tại chưa ghi nhận bất thường trên phim.', '2025-05-18 13:51:08', '2025-05-18 13:51:08'),
(49, 'XQUANG BLONDEAU', 'X-quang', '- Cấu trúc các xương: Không ghi nhận tổn thương.\r\n\r\n- Vách ngăn mũi: Trong giới hạn bình thường.\r\n\r\n- Cấu trúc và độ sáng các xoang hàm hai bên: Trong giới hạn bình thường.\r\n\r\n- Cấu trúc và độ sáng các xoang trán hai bên: Trong giới hạn bình thường.\r\n\r\n- Cấu trúc và độ sáng các xoang sàng hai bên:Trong giới hạn bình thường.\r\n\r\n- Ghi nhận khác: Không.', 'Hiện tại chưa ghi nhận bất thường trên phim.', '2025-05-18 13:51:28', '2025-05-18 13:51:28'),
(50, 'XQUANG HITZ', 'X-quang', '- Cấu trúc các xương: Không ghi nhận tổn thương.\r\n\r\n\r\n\r\n- Cấu trúc và độ sáng các xoang hàm hai bên: Không ghi nhận tổn thương.\r\n\r\n\r\n\r\n- Cấu trúc và độ sáng các xoang sàng hai bên: Không ghi nhận tổn thương.\r\n\r\n\r\n\r\n - Ghi nhận khác: Không có.', 'Hiện tại chưa ghi nhận hình ảnh bất thường trên phim Xquang.', '2025-05-18 13:51:48', '2025-05-18 13:51:48'),
(51, 'XQUANG XƯƠNG MŨI NGHIÊNG', 'X-quang', '- Cấu trúc xương mũi: Chưa ghi nhận bất thường.\r\n\r\n\r\n\r\n- Ghi nhận khác: Không có.', 'Hiện tại chưa ghi nhận hình ảnh bất thường trên phim Xquang.', '2025-05-18 13:52:11', '2025-05-18 13:52:11'),
(52, 'XQUANG XƯƠNG HÀM CHẾCH', 'X-quang', '- Xương hàm dưới: Không ghi nhận hình ảnh bất thường.\r\n\r\n\r\n- Ghi nhận khác: Không.', 'Hiện tại chưa ghi nhận hình ảnh bất thường trên phim Xquang.', '2025-05-18 13:52:32', '2025-05-18 13:52:58'),
(53, 'Hệ niệu không chuẩn bị (KUB).', 'X-quang', '*  Bóng thận hai bên: Trong giới hạn bình thường.\r\n\r\n\r\n\r\n* Không ghi nhận hình ảnh sỏi cản quang hệ niệu.\r\n\r\n\r\n\r\n*  Các bộ phận khác: Không ghi nhận bất thương.', 'Hiện tai không phát hiện hình ảnh sỏi cản quang hệ niệu trên phim KUB.', '2025-05-18 13:53:58', '2025-05-18 13:53:58'),
(54, 'SIÊU ÂM TUYẾN VÚ HAI BÊN', 'Siêu âm', 'I. VÚ PHẢI:    \r\n- Mô dưới da: Echo kém, trong giới hạn bình thường.    \r\n- Mô tuyến vú: Echo dày, cấu trúc đồng nhất, mô sợi và mô tuyến vú phân bố đều.    \r\n- Tổn thương khu trú: Không.  \r\n- Hạch: Không.   \r\n    \r\n II. VÚ TRÁI:    \r\n- Mô dưới da: Echo kém, trong giới hạn bình thường.    \r\n- Mô tuyến vú: Echo dày, cấu trúc đồng nhất, mô sợi và mô tuyến vú phân bố đều.    \r\n- Tổn thương khu trú: Không.    \r\n- Hạch: Không', 'Hiện tại chưa phát hiện bệnh lý trên siêu âm', '2025-05-18 13:54:54', '2025-05-18 13:54:54'),
(55, 'SIÊU ÂM THAI QUÝ 1', 'Siêu âm', '* Tử cung: Trung gian, DAP = mm, lòng tử cung có 01 túi thai, bờ đều căng tròn, bên trong có yolksac, có phôi.\r\n\r\n*Tim thai (+)  lần/phút.\r\n\r\n* GS: mm\r\n \r\n* CRL:  mm\r\n\r\n* Buồng trứng phải: chưa ghi nhận bất thường.\r\n\r\n* Buồng trứng trái: chưa ghi nhận bất thường.\r\n\r\n* Túi cùng: không dịch \r\n\r\n* Ngày dự sanh (dương lịch):', 'MỘT TÚI THAI TRONG LÒNG TỬ CUNG, TUỔI THAI KHOẢNG  TUẦN.', '2025-05-18 14:00:31', '2025-05-18 14:00:31'),
(56, 'SIÊU ÂM THAI QUÝ 2', 'Siêu âm', '- 1/ Số thai: 01\r\n\r\n     + Ngôi thai: Di động\r\n\r\n     + Tim thai (+):  lần/phút, đều rõ\r\n\r\n- 2/ Nhau - dây rốn: \r\n\r\n    + Vi trí: bám mặt trước thân tử cung.\r\n\r\n     + Độ trưởng thành: 1\r\n\r\n     + Nhóm:  I  \r\n\r\n- 3/ Nước ối: Bình thường\r\n\r\n- 4/ Chỉ số sinh học:\r\n\r\n+ Đường kính lưỡng đỉnh (BPD): mm \r\n\r\n+ Chiều dài xương đùi (FL):  mm\r\n\r\n+ Chu vi vòng bụng (AC):  mm\r\n\r\n- 5/ Ước lượng tuổi thai:  tuần\r\n\r\n- 6/ Ước lượng cân nặng: # g\r\n\r\n- 7/ Dự sanh (dương lịch): (theo dự sanh 3 tháng đầu)\r\n\r\n- 8/ Bất thường: Không phát hiện bất thường', 'Một thai sống trong lòng tử cung, tuổi thai khoảng  tuần. Ngôi di động - Nước ối trung bình.', '2025-05-18 14:01:17', '2025-05-18 14:01:17'),
(57, 'SIÊU ÂM THAI QUÝ 3', 'Siêu âm', '1/ Số thai : 01    \r\n     + Ngôi thai: Đầu. \r\n     + Tim thai (+): lần/phút, đều rõ                        \r\n2/ Nhau - dây rốn:\r\n      +  Vị trí : Bám mặt trước thân tử cung. \r\n      + Nhóm:   I                 \r\n      + Độ trưởng thành:    3                                    \r\n3/ Nước ối:  AFI#  cm                  \r\n4/Chỉ số sinh học :\r\n\r\n              + ĐK lưỡng đỉnh (BPD): mm\r\n              + Chiều dài xương đùi: FL: mm\r\n              + Chu vi bụng (AC): mm        \r\n5/ Ước lượng cân nặng: # g             \r\n6/ Ước lượng tuổi thai: # tuần     \r\n7/Dự sanh (dương lịch): (theo dự sanh 3 tháng đầu)                                          \r\n8/Cơ quan khác:', 'Một thai sống trong lòng tử cung, tuổi thai khoảng  tuần. Ngôi thuận - Nước ối AFI# cm.', '2025-05-18 14:01:46', '2025-05-18 14:01:46'),
(58, 'SIÊU ÂM TUYẾN GIÁP', 'Siêu âm', '- Thùy phải: Kích thước không to, cấu trúc đồng nhất, không tăng sinh mạch máu.\r\n\r\n   + Đường kính ngang:  mm\r\n\r\n   + Đường kính dọc:  mm\r\n\r\n   + Bề dày:  mm\r\n   + Tổn thương khu trú: Chưa ghi nhận.\r\n\r\n - Thùy trái: Kích thước không to, cấu trúc đồng nhất, không tăng sinh mạch máu.\r\n\r\n   + Đường kính ngang:  mm\r\n\r\n   + Đường kính dọc:  mm\r\n\r\n   + Bề dày:  mm.\r\n   + Tổn thương khu trú: Chưa ghi nhận.\r\n\r\n- Eo giáp:  mm\r\n\r\n- Hạch cổ: Không phát hiện hạch bất thường.\r\n- Hạch góc hàm: Không phát hiện hạch bất thường.\r\n\r\n- Ghi nhận khác: Không có.', 'Hiện tại chưa phát hiện bất thường trên siêu âm.', '2025-05-18 14:02:06', '2025-05-18 14:02:06'),
(59, 'SIÊU ÂM TỔNG QUÁT NAM', 'Siêu âm', '- Gan: Phản âm đồng nhất, bờ đều, kích thước không lớn.\r\n\r\n- Túi mật: Túi mật không sỏi, thành không dày, đường mật trong ngoài gan không dãn.\r\n\r\n- Tụy: Phản âm đồng nhất, kích thước không lớn.\r\n\r\n- Lách: Phản âm đồng nhất, kích thước không lớn.\r\n\r\n- Thận phải: Không sỏi, không ứ nước, phân biệt vỏ tuỷ rõ.\r\n\r\n- Thận trái:  Không sỏi, không ứ nước, phân biệt vỏ tuỷ rõ.\r\n\r\n- Bàng quang: Không sỏi, thành không dày.\r\n\r\n- Tiền liệt tuyến : Cấu trúc đồng nhất, kích thước không to.\r\n\r\n- Dịch ở bụng, dịch màng phổi: Không có.\r\n- Ghi nhận khác: Không.', 'Hiện tại chưa phát hiện hình ảnh bất thường trên siêu âm.', '2025-05-18 14:02:23', '2025-05-18 14:02:23'),
(60, 'SIÊU ÂM TỔNG QUÁT NỮ', 'Siêu âm', '- Gan: Phản âm đồng nhất, bờ gan đều, kích thước không lớn.\r\n\r\n- Mật: Túi mật không sỏi, thành không dày, đường mật trong ngoài gan không dãn.\r\n\r\n- Tụy: Phản âm đồng nhất, kích thước không lớn.\r\n\r\n- Lách: Phản âm đồng nhất, kích thước không lớn. \r\n\r\n- Thận phải: Không sỏi, không ứ nước, phân biệt vỏ tuỷ rõ.\r\n\r\n- Thận trái: Không sỏi, không ứ nước, phân biệt vỏ tuỷ rõ.\r\n\r\n- Bàng quang: Không sỏi, thành không dày.\r\n\r\n- Tử cung: Trung gian, DAP mm, nội mạc mỏng, cấu trúc đồng nhất.\r\n\r\n- Hai phần phụ:  \r\n         + P: Chưa ghi nhận bất thường.\r\n\r\n        + T: Chưa ghi nhận bất thường.\r\n- Dịch ở bụng, dịch màng phổi: Không có.\r\n\r\n- Ghi nhận khác: Không.', 'Hiện tại chưa phát hiện bệnh lý trên siêu âm.', '2025-05-18 14:02:36', '2025-05-18 14:02:36'),
(61, 'SIÊU ÂM TỔNG QUÁT NỮ- MÃN KINH', 'Siêu âm', '- Gan: Phản âm đồng nhất, bờ gan đều, kích thước không lớn.\r\n\r\n- Mật: Túi mật không sỏi, thành không dày, đường mật trong ngoài gan không dãn.\r\n\r\n- Tụy: Phản âm đồng nhất, kích thước không lớn.\r\n\r\n- Lách: Phản âm đồng nhất, kích thước không lớn. \r\n\r\n- Thận phải: Không sỏi, không ứ nước, phân biệt vỏ tuỷ rõ.\r\n\r\n- Thận trái: Không sỏi, không ứ nước, phân biệt vỏ tuỷ rõ.\r\n\r\n- Bàng quang: Không sỏi, thành không dày.\r\n\r\n- Tử cung: Trung gian, DAP mm, nội mạc mỏng, cấu trúc đồng nhất.\r\n\r\n- Hai phần phụ:  Khó khảo sát.\r\n- Dịch ở bụng, dịch màng phổi: Không có.\r\n\r\n- Ghi nhận khác: Không.', 'Hiện tại chưa phát hiện bệnh lý trên siêu âm.', '2025-05-18 14:03:06', '2025-05-18 14:03:06'),
(62, 'SIÊU ÂM TỬ CUNG PHẦN PHỤ', 'Siêu âm', '- Tử cung: Trung gian,  DAP=  mm, cấu trúc cơ tử cung đồng dạng.\r\n\r\n- Nội mạc: mm\r\n\r\n- Buồng trứng trái: Chưa ghi nhận bất thường.\r\n\r\n- Buồng trứng phải: Chưa ghi nhận bất thường.\r\n\r\n- Túi cùng: Không có dịch.', 'HIỆN TẠI CHƯA GHI NHẬN BẤT THƯỜNG TRÊN SIÊU ÂM.', '2025-05-18 14:03:21', '2025-05-18 14:03:21'),
(63, 'Siêu âm mô mềm', 'Siêu âm', 'Mô mềm vị trí:\n-', 'Hiện tại chưa ghi nhận hình ảnh bất thường trên siêu âm.', '2025-05-18 14:03:55', '2025-05-18 14:03:55'),
(64, 'SIÊU ÂM TĨNH MẠCH CHI DƯỚI', 'Siêu âm', 'Mô tả siêu âm doppler hệ tĩnh mạch chi dưới hai bên.\r\n- Hình ảnh siêu âm 2D\r\n   + Hệ tĩnh mạch hai chi dưới không dãn, còn mềm mại, dễ đè xẹp, không có huyết khối trong lòng.\r\n- Hình ảnh siêu âm DOPPLER\r\n    + Hệ tĩnh mạch sâu: Phổ tĩnh mạch sâu chi dưới hai bên thay đổi tốt theo hô hấp, có dòng phổ âm đi ngược dòng phổ chính khi hít thở sâu và làm các nghiệm pháp,  bên phải T= s, bên trái T= s\r\n    + Hệ tĩnh mạch nông: Phổ tĩnh mạch nông chi dưới hai bên thay đổi tốt theo hô hấp, có dòng phổ âm đi ngược dòng phổ chính khi hít thở sâu và làm các nghiệm pháp,  bên phải T= s, bên trái T= s\r\n- Ghi nhận khác: không.', 'CHƯA GHI NHẬN HÌNH ẢNH BẤT THƯỜNG TRÊN SIÊU ÂM DOPPLER HỆ TĨNH MẠCH CHI DƯỚI HAI BÊN.', '2025-05-18 14:04:49', '2025-05-18 14:04:49'),
(65, 'SIÊU ÂM ĐỘNG MẠCH CẢNH', 'Siêu âm', '1. Động mạch\r\n- Hình ảnh 2D\r\n  + Hệ động mạch cảnh chung, cảnh trong, cảnh ngoài hai bên không dày, không xơ vữa, không tắc hẹp, không phình và bóc tách thành mạch, không có huyết khối trong lòng.\r\n  + Động mạch đốt sống hai bên: dòng chảy hướng não.\r\n  + Không có thông nối động - tĩnh mạch.\r\n- DOPPLER\r\n   + Phổ động mạch cảnh có vận tốc và phổ bình thường, không có vùng bắt màu bất thường, không có ổ tăng vận tốc khu trú.\r\n2. Tĩnh mạch\r\n- Hình ảnh 2D\r\n   + Hệ tĩnh mạch cảnh không dãn, còn mềm mại, dễ đè xẹp, không có huyết khối trong lòng.\r\n   + Không có thông nối động - tĩnh mạch', 'HIỆN TẠI CHƯA GHI NHẬN BẤT THƯỜNG TRÊN SIÊU ÂM DOPPLER HỆ ĐỘNG MẠCH CẢNH NGOÀI SỌ.', '2025-05-18 14:05:06', '2025-05-18 14:05:06'),
(66, 'KẾT QUẢ ĐIỆN TIM 1', 'Điện tim', '■ Vent.          rate                                        bpm\r\n\r\n■ PR              int.                                          ms\r\n\r\n■ QRS            dur.                                        ms\r\n\r\n■ QT / QTc     int.                                          ms\r\n\r\n■ P / QRS / T  axis                                         o\r\n\r\n■ RV5 / SV1   amp.                                       mV\r\n\r\n■ RV5+SV1     amp.                                       mV', '', '2025-05-18 14:05:32', '2025-05-18 14:05:32'),
(67, 'SIÊU ÂM DOPPLER TIM', 'Siêu âm', '- IVSd: mm        LVDd: mm    LVPWd: mm\r\n- IVSs: mm        LVDs: mm    LVPWs: mm \r\n- EF :   %        FS :   %\r\n- RV: mm;   AO: mm;  AVD: mm;  LA: mm.\r\n    1. Van động mạch phổi:  Hở van (-), Hẹp van (-)\r\n         - Vmax:   m/s,     Gpeak :   mmHg\r\n    2. Van 2 lá:  Hở van (-), Hẹp van (-)\r\n        -  Vmax:    m/s, Gpeak:  mmHg, E/A >1\r\n    3. Van động mạch chủ: Hở van (-), Hẹp van (-)\r\n        -  Vmax:     m/s,     Gpeak:    mmHg\r\n    4. Van 3 lá: Hở van (-), Hẹp van (-)\r\n       - Vmax: m/s, Gpeak: mmHg, PAPs: mmHg\r\n    5. Dòng bất thường qua vách liên thất:Không\r\n    6. Dòng bất thường qua vách liên nhĩ:Không', '- Không ghi nhận rối loạn vận động vùng.\r\n- Chức năng tâm thu thất trái bảo tồn, \r\nEF#  % (theo Teicholz) \r\n- Hở van 2 lá 1/4, hở van 3 lá 1/4. \r\n- Không tăng áp lực động mạch phổi.\r\n- Không tràn dịch', '2025-05-18 14:06:06', '2025-05-18 14:06:06'),
(68, 'Phiếu xét nghiệm huyết học cơ bản', 'Xét nghiệm', '[\n        {\n            \"name\": \"Xét nghiệm viêm gan B\",\n            \"results\": [\n                {\"test_name\": \"HBsAg\", \"result\": \"Negative\", \"unit\": \"\", \"normal_range\": \"Negative\"},\n                {\"test_name\": \"Anti-HBs\", \"result\": \"Positive\", \"unit\": \"\", \"normal_range\": \"Positive\"},\n                {\"test_name\": \"Anti-HBc\", \"result\": \"Negative\", \"unit\": \"\", \"normal_range\": \"Negative\"}\n            ]\n        },\n        {\n            \"name\": \"Xét nghiệm viêm gan C\",\n            \"results\": [\n                {\"test_name\": \"Anti-HCV\", \"result\": \"Negative\", \"unit\": \"\", \"normal_range\": \"Negative\"},\n                {\"test_name\": \"HCV RNA\", \"result\": \"Negative\", \"unit\": \"\", \"normal_range\": \"Negative\"}\n            ]\n        }\n    ]', '', '2025-05-26 10:15:04', '2025-05-26 10:19:04'),
(69, 'Xét nghiệm', 'Xét nghiệm', '[\r\n  {\r\n    \"name\": \"Xét nghiệm viêm gan B\",\r\n    \"results\": [\r\n      {\r\n        \"test_name\": \"HBsAg\",\r\n        \"result\": \"Negative\",\r\n        \"unit\": \"\",\r\n        \"normal_range\": \"Negative\"\r\n      },\r\n      {\r\n        \"test_name\": \"Anti-HBs\",\r\n        \"result\": \"Positive\",\r\n        \"unit\": \"\",\r\n        \"normal_range\": \"Positive\"\r\n      },\r\n      {\r\n        \"test_name\": \"Anti-HBc\",\r\n        \"result\": \"Negative\",\r\n        \"unit\": \"\",\r\n        \"normal_range\": \"Negative\"\r\n      }\r\n    ]\r\n  },\r\n  {\r\n    \"name\": \"Xét nghiệm viêm gan C\",\r\n    \"results\": [\r\n      {\r\n        \"test_name\": \"Anti-HCV\",\r\n        \"result\": \"Negative\",\r\n        \"unit\": \"\",\r\n        \"normal_range\": \"Negative\"\r\n      },\r\n      {\r\n        \"test_name\": \"HCV RNA\",\r\n        \"result\": \"Negative\",\r\n        \"unit\": \"\",\r\n        \"normal_range\": \"Negative\"\r\n      }\r\n    ]\r\n  },\r\n  {\r\n    \"name\": \"Xét nghiệm đường huyết\",\r\n    \"results\": [\r\n      {\r\n        \"test_name\": \"Glucose (FPG)\",\r\n        \"result\": \"95\",\r\n        \"unit\": \"mg/dL\",\r\n        \"normal_range\": \"70-100\"\r\n      },\r\n      {\r\n        \"test_name\": \"HbA1c\",\r\n        \"result\": \"5.2\",\r\n        \"unit\": \"%\",\r\n        \"normal_range\": \"<5.7\"\r\n      }\r\n    ]\r\n  },\r\n  {\r\n    \"name\": \"Xét nghiệm mỡ máu\",\r\n    \"results\": [\r\n      {\r\n        \"test_name\": \"Cholesterol toàn phần\",\r\n        \"result\": \"180\",\r\n        \"unit\": \"mg/dL\",\r\n        \"normal_range\": \"<200\"\r\n      },\r\n      {\r\n        \"test_name\": \"HDL\",\r\n        \"result\": \"55\",\r\n        \"unit\": \"mg/dL\",\r\n        \"normal_range\": \">40\"\r\n      },\r\n      {\r\n        \"test_name\": \"LDL\",\r\n        \"result\": \"100\",\r\n        \"unit\": \"mg/dL\",\r\n        \"normal_range\": \"<130\"\r\n      },\r\n      {\r\n        \"test_name\": \"Triglyceride\",\r\n        \"result\": \"120\",\r\n        \"unit\": \"mg/dL\",\r\n        \"normal_range\": \"<150\"\r\n      }\r\n    ]\r\n  },\r\n  {\r\n    \"name\": \"Xét nghiệm chức năng gan\",\r\n    \"results\": [\r\n      {\r\n        \"test_name\": \"ALT (GPT)\",\r\n        \"result\": \"25\",\r\n        \"unit\": \"U/L\",\r\n        \"normal_range\": \"<40\"\r\n      },\r\n      {\r\n        \"test_name\": \"AST (GOT)\",\r\n        \"result\": \"22\",\r\n        \"unit\": \"U/L\",\r\n        \"normal_range\": \"<40\"\r\n      },\r\n      {\r\n        \"test_name\": \"GGT\",\r\n        \"result\": \"30\",\r\n        \"unit\": \"U/L\",\r\n        \"normal_range\": \"10-50\"\r\n      },\r\n      {\r\n        \"test_name\": \"Bilirubin toàn phần\",\r\n        \"result\": \"0.8\",\r\n        \"unit\": \"mg/dL\",\r\n        \"normal_range\": \"<1.2\"\r\n      }\r\n    ]\r\n  },\r\n  {\r\n    \"name\": \"Xét nghiệm chức năng thận\",\r\n    \"results\": [\r\n      {\r\n        \"test_name\": \"Creatinine\",\r\n        \"result\": \"1.0\",\r\n        \"unit\": \"mg/dL\",\r\n        \"normal_range\": \"0.7-1.3\"\r\n      },\r\n      {\r\n        \"test_name\": \"Urea\",\r\n        \"result\": \"18\",\r\n        \"unit\": \"mg/dL\",\r\n        \"normal_range\": \"10-50\"\r\n      },\r\n      {\r\n        \"test_name\": \"eGFR\",\r\n        \"result\": \"90\",\r\n        \"unit\": \"mL/min/1.73m²\",\r\n        \"normal_range\": \">60\"\r\n      }\r\n    ]\r\n  },\r\n  {\r\n    \"name\": \"Tổng phân tích tế bào máu\",\r\n    \"results\": [\r\n      {\r\n        \"test_name\": \"WBC\",\r\n        \"result\": \"6.5\",\r\n        \"unit\": \"10^3/uL\",\r\n        \"normal_range\": \"4.0-10.0\"\r\n      },\r\n      {\r\n        \"test_name\": \"RBC\",\r\n        \"result\": \"4.8\",\r\n        \"unit\": \"10^6/uL\",\r\n        \"normal_range\": \"4.2-5.9\"\r\n      },\r\n      {\r\n        \"test_name\": \"Hemoglobin\",\r\n        \"result\": \"14.5\",\r\n        \"unit\": \"g/dL\",\r\n        \"normal_range\": \"13.0-17.0\"\r\n      },\r\n      {\r\n        \"test_name\": \"Hematocrit\",\r\n        \"result\": \"42\",\r\n        \"unit\": \"%\",\r\n        \"normal_range\": \"38-50\"\r\n      },\r\n      {\r\n        \"test_name\": \"Platelet\",\r\n        \"result\": \"250\",\r\n        \"unit\": \"10^3/uL\",\r\n        \"normal_range\": \"150-450\"\r\n      }\r\n    ]\r\n  }\r\n]', '', '2025-05-26 10:21:04', '2025-05-28 13:09:29'),
(70, 'xn111', 'Xét nghiệm', '[\r\n  {\r\n    \"name\": \"1\",\r\n    \"results\": [\r\n      {\r\n        \"test_name\": \"1\",\r\n        \"result\": \"1\",\r\n        \"unit\": \"1\",\r\n        \"normal_range\": \"1\"\r\n      }\r\n    ]\r\n  },\r\n  {\r\n    \"name\": \"2\",\r\n    \"results\": [\r\n      {\r\n        \"test_name\": \"2\",\r\n        \"result\": \"2\",\r\n        \"unit\": \"2\",\r\n        \"normal_range\": \"2\"\r\n      }\r\n    ]\r\n  }\r\n]', '123', '2025-05-26 11:13:29', '2025-05-26 11:13:29');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `name` varchar(60) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `role` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `users`
--

INSERT INTO `users` (`id`, `name`, `username`, `password`, `role`) VALUES
(15, 'ken', 'admin123', '123456', 'admin');

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `diagnoses`
--
ALTER TABLE `diagnoses`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `doctor_notes`
--
ALTER TABLE `doctor_notes`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `examinations`
--
ALTER TABLE `examinations`
  ADD PRIMARY KEY (`id`),
  ADD KEY `patient_id` (`patient_id`),
  ADD KEY `examinations_ibfk_2` (`diagnosis_id`),
  ADD KEY `examinations_ibfk_3` (`doctor_note_id`);

--
-- Chỉ mục cho bảng `examination_medications`
--
ALTER TABLE `examination_medications`
  ADD PRIMARY KEY (`id`),
  ADD KEY `examination_id` (`examination_id`),
  ADD KEY `medication_id` (`medication_id`);

--
-- Chỉ mục cho bảng `examination_results`
--
ALTER TABLE `examination_results`
  ADD PRIMARY KEY (`id`),
  ADD KEY `examination_service_id` (`examination_service_id`),
  ADD KEY `template_id` (`template_id`);

--
-- Chỉ mục cho bảng `examination_services`
--
ALTER TABLE `examination_services`
  ADD PRIMARY KEY (`id`),
  ADD KEY `examination_id` (`examination_id`),
  ADD KEY `service_id` (`service_id`);

--
-- Chỉ mục cho bảng `medications`
--
ALTER TABLE `medications`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `patients`
--
ALTER TABLE `patients`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `services`
--
ALTER TABLE `services`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unique_service_name` (`name`);

--
-- Chỉ mục cho bảng `templates`
--
ALTER TABLE `templates`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `diagnoses`
--
ALTER TABLE `diagnoses`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=127;

--
-- AUTO_INCREMENT cho bảng `doctor_notes`
--
ALTER TABLE `doctor_notes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT cho bảng `examinations`
--
ALTER TABLE `examinations`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=214;

--
-- AUTO_INCREMENT cho bảng `examination_medications`
--
ALTER TABLE `examination_medications`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=111;

--
-- AUTO_INCREMENT cho bảng `examination_results`
--
ALTER TABLE `examination_results`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=115;

--
-- AUTO_INCREMENT cho bảng `examination_services`
--
ALTER TABLE `examination_services`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=293;

--
-- AUTO_INCREMENT cho bảng `medications`
--
ALTER TABLE `medications`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT cho bảng `patients`
--
ALTER TABLE `patients`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=101;

--
-- AUTO_INCREMENT cho bảng `services`
--
ALTER TABLE `services`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=54;

--
-- AUTO_INCREMENT cho bảng `templates`
--
ALTER TABLE `templates`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=71;

--
-- AUTO_INCREMENT cho bảng `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `examinations`
--
ALTER TABLE `examinations`
  ADD CONSTRAINT `examinations_ibfk_1` FOREIGN KEY (`patient_id`) REFERENCES `patients` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `examinations_ibfk_2` FOREIGN KEY (`diagnosis_id`) REFERENCES `diagnoses` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `examinations_ibfk_3` FOREIGN KEY (`doctor_note_id`) REFERENCES `doctor_notes` (`id`);

--
-- Các ràng buộc cho bảng `examination_medications`
--
ALTER TABLE `examination_medications`
  ADD CONSTRAINT `examination_medications_ibfk_1` FOREIGN KEY (`examination_id`) REFERENCES `examinations` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `examination_medications_ibfk_2` FOREIGN KEY (`medication_id`) REFERENCES `medications` (`id`) ON DELETE CASCADE;

--
-- Các ràng buộc cho bảng `examination_results`
--
ALTER TABLE `examination_results`
  ADD CONSTRAINT `examination_results_ibfk_1` FOREIGN KEY (`examination_service_id`) REFERENCES `examination_services` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `examination_results_ibfk_2` FOREIGN KEY (`template_id`) REFERENCES `templates` (`id`) ON DELETE SET NULL;

--
-- Các ràng buộc cho bảng `examination_services`
--
ALTER TABLE `examination_services`
  ADD CONSTRAINT `examination_services_ibfk_1` FOREIGN KEY (`examination_id`) REFERENCES `examinations` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `examination_services_ibfk_2` FOREIGN KEY (`service_id`) REFERENCES `services` (`id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
