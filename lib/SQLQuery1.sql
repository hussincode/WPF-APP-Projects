create database LibraryDB;  

use LibraryDB

CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    Role NVARCHAR(20) NOT NULL CHECK (Role IN ('Librarian', 'Member'))
);

CREATE TABLE Books (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(200) NOT NULL,
    Author NVARCHAR(100) NOT NULL,
    Category NVARCHAR(100) NOT NULL,
    ISBN NVARCHAR(50) UNIQUE NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity >= 0),
    Description NVARCHAR(MAX),
    CoverImagePath NVARCHAR(255)
);

CREATE TABLE BorrowRecords (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    BookId INT NOT NULL,
    BorrowDate DATETIME NOT NULL,
    ReturnDate DATETIME NULL,
    Status NVARCHAR(20) NOT NULL CHECK (Status IN ('Borrowed', 'Returned')),

    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (BookId) REFERENCES Books(Id)
);

INSERT INTO Users (FullName, Email, Password, Role)
VALUES
('Ahmed Hassan', 'ahmed@library.com', '123456', 'Librarian'),
('Sara Mohamed', 'sara@library.com', '123456', 'Member'),
('Omar Ali', 'omar@library.com', '123456', 'Member'),
('Mona Khaled', 'mona@library.com', '123456', 'Member'),
('Youssef Adel', 'youssef@library.com', '123456', 'Member'),
('Nour Ibrahim', 'nour@library.com', '123456', 'Member'),
('Hassan Mahmoud', 'hassan@library.com', '123456', 'Librarian'),
('Laila Samir', 'laila@library.com', '123456', 'Member'),
('Karim Mostafa', 'karim@library.com', '123456', 'Member'),
('Salma Hany', 'salma@library.com', '123456', 'Member');

INSERT INTO Books (Title, Author, Category, ISBN, Quantity, Description, CoverImagePath)
VALUES
('C# Programming', 'John Smith', 'Programming', 'ISBN001', 5, 'Learn C# fundamentals.', 'Images/csharp.jpg'),
('ASP.NET Core', 'David Miller', 'Programming', 'ISBN002', 4, 'Web development with ASP.NET Core.', 'Images/aspnet.jpg'),
('SQL Server Basics', 'Michael Brown', 'Database', 'ISBN003', 6, 'Introduction to SQL Server.', 'Images/sql.jpg'),
('WPF Guide', 'Emily Davis', 'Programming', 'ISBN004', 3, 'WPF step by step tutorial.', 'Images/wpf.jpg'),
('Data Structures', 'Robert King', 'Computer Science', 'ISBN005', 5, 'Understanding data structures.', 'Images/ds.jpg'),
('Algorithms', 'Thomas Cormen', 'Computer Science', 'ISBN006', 2, 'Algorithm design concepts.', 'Images/algo.jpg'),
('Machine Learning', 'Andrew Ng', 'AI', 'ISBN007', 4, 'ML basics and applications.', 'Images/ml.jpg'),
('Operating Systems', 'Silberschatz', 'Computer Science', 'ISBN008', 3, 'Operating system concepts.', 'Images/os.jpg'),
('Computer Networks', 'James Kurose', 'Networking', 'ISBN009', 5, 'Networking fundamentals.', 'Images/network.jpg'),
('Cyber Security', 'William Stallings', 'Security', 'ISBN010', 4, 'Security principles.', 'Images/security.jpg');




INSERT INTO BorrowRecords (UserId, BookId, BorrowDate, ReturnDate, Status)
VALUES
(2, 1, GETDATE(), NULL, 'Borrowed'),
(3, 2, GETDATE(), NULL, 'Borrowed'),
(4, 3, DATEADD(DAY, -5, GETDATE()), GETDATE(), 'Returned'),
(5, 4, GETDATE(), NULL, 'Borrowed'),
(6, 5, DATEADD(DAY, -7, GETDATE()), GETDATE(), 'Returned'),
(7, 6, GETDATE(), NULL, 'Borrowed'),
(8, 7, GETDATE(), NULL, 'Borrowed'),
(9, 8, DATEADD(DAY, -3, GETDATE()), GETDATE(), 'Returned'),
(10, 9, GETDATE(), NULL, 'Borrowed'),
(2, 10, GETDATE(), NULL, 'Borrowed');

select * from Users