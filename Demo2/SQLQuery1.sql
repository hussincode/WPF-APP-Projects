CREATE DATABASE TaskManagement;

use TaskManagement;

CREATE TABLE  Persone(
    UserID INT PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NOT NULL UNIQUE,
    Role NVARCHAR(20) NOT NULL,
    
    CONSTRAINT CHK_User_Role
    CHECK (Role IN ('Manager', 'Employee'))
);


CREATE TABLE Tasks (
    TaskID INT PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(500),
    Status NVARCHAR(20) NOT NULL,
    DueDate DATETIME,
    
    CONSTRAINT CHK_Task_Status
    CHECK (Status IN ('Pending', 'In Progress', 'Completed'))
);

INSERT INTO  Persone(UserID, Name, Password, Email, Role) VALUES
(1, 'Ahmed Ali', 'pass123', 'ahmed@company.com', 'Manager'),
(2, 'Sara Mohamed', 'pass234', 'sara@company.com', 'Employee'),
(3, 'Omar Hassan', 'pass345', 'omar@company.com', 'Employee'),
(4, 'Mona Ibrahim', 'pass456', 'mona@company.com', 'Manager'),
(5, 'Youssef Adel', 'pass567', 'youssef@company.com', 'Employee'),
(6, 'Nour Khaled', 'pass678', 'nour@company.com', 'Employee'),
(7, 'Hana Mostafa', 'pass789', 'hana@company.com', 'Employee'),
(8, 'Karim Samir', 'pass890', 'karim@company.com', 'Manager'),
(9, 'Laila Tarek', 'pass901', 'laila@company.com', 'Employee'),
(10, 'Mahmoud Fathy', 'pass012', 'mahmoud@company.com', 'Employee');


INSERT INTO Tasks (TaskID, Title, Description, Status, DueDate) VALUES
(1, 'Design Database', 'Create ERD and tables', 'Pending', '2026-03-01'),
(2, 'Develop Login Page', 'Create authentication module', 'In Progress', '2026-03-05'),
(3, 'Implement API', 'Build RESTful services', 'Pending', '2026-03-10'),
(4, 'Fix Bugs', 'Resolve reported issues', 'Completed', '2026-02-20'),
(5, 'Write Documentation', 'Prepare system documentation', 'Pending', '2026-03-15'),
(6, 'UI Improvements', 'Enhance user interface', 'In Progress', '2026-03-08'),
(7, 'Testing Phase', 'Perform system testing', 'Pending', '2026-03-18'),
(8, 'Deploy System', 'Deploy to production server', 'Pending', '2026-03-25'),
(9, 'Security Check', 'Run security audit', 'Completed', '2026-02-22'),
(10, 'Backup Setup', 'Configure automatic backups', 'In Progress', '2026-03-12');



