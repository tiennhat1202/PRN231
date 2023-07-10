
Create database Hotel_Booking

use Hotel_Booking

-- Tạo bảng Hotel
CREATE TABLE Hotel (
    hotel_id INT PRIMARY KEY IDENTITY(1, 1),
    hotel_name VARCHAR(255),
    [address] VARCHAR(255),
    [state] VARCHAR(255),
    country VARCHAR(255),
    contact VARCHAR(255),
    email VARCHAR(255),
    [description] VARCHAR(MAX),
	[status] VARCHAR(50)
);

-- Tạo bảng RoomTypes
CREATE TABLE RoomType (
    room_type_id INT PRIMARY KEY IDENTITY(1, 1),
    room_type_name VARCHAR(255),
    [description] VARCHAR(MAX)
);
-- Tạo bảng Rooms
CREATE TABLE Room (
    room_id INT PRIMARY KEY IDENTITY(1, 1),
    room_name VARCHAR(255),
    room_type_id INT,
    price_per_night DECIMAL(10, 2),
    [status] VARCHAR(50),
    [description] VARCHAR(MAX),
	hotel_id INT,
    FOREIGN KEY (room_type_id) REFERENCES RoomType(room_type_id),
	FOREIGN KEY (hotel_id) REFERENCES Hotel(hotel_id)
);

-- Tạo bảng Roles
CREATE TABLE [Role] (
    role_id INT PRIMARY KEY IDENTITY(1, 1),
    role_name VARCHAR(255)
);

-- Tạo bảng Users
CREATE TABLE [User] (
    [user_id] INT PRIMARY KEY IDENTITY(1, 1),
    role_id INT,
    username VARCHAR(255),
    [password] VARCHAR(255),
    email VARCHAR(255),
    phone VARCHAR(20),
    FOREIGN KEY (role_id) REFERENCES [Role](role_id)
);

-- Tạo bảng Bookings
CREATE TABLE Booking (
    booking_id INT PRIMARY KEY IDENTITY(1, 1),
    room_id INT,
    [user_id] INT,
    check_in_date DATE,
    check_out_date DATE,
    total_price DECIMAL(10, 2),
    FOREIGN KEY (room_id) REFERENCES Room(room_id),
    FOREIGN KEY (user_id) REFERENCES [User](user_id)
);

-- Tạo bảng Payment
CREATE TABLE Payment (
    payment_id INT PRIMARY KEY IDENTITY(1, 1),
    booking_id INT,
    payment_method VARCHAR(255),
    payment_date DATE,
    FOREIGN KEY (booking_id) REFERENCES Booking(booking_id)
);

CREATE TABLE HotelImage (
    image_id INT PRIMARY KEY IDENTITY(1, 1),
    hotel_id INT,
    image_url VARCHAR(255),
    FOREIGN KEY (hotel_id) REFERENCES Hotel(hotel_id)
);

CREATE TABLE RoomImage (
    image_id INT PRIMARY KEY IDENTITY(1, 1),
    room_id INT,
    image_url VARCHAR(255),
    FOREIGN KEY (room_id) REFERENCES Room(room_id)
);

