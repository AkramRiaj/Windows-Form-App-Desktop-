USE master;
GO
If DB_ID('EmployeeInfo') IS NOT NULL DROP DATABASE EmployeeInfo;
GO

CREATE DATABASE EmployeeInfo;

GO

USE EmployeeInfo;

GO

CREATE TABLE Job(		JobID INT IDENTITY PRIMARY KEY NOT NULL,
						JobTitle VARCHAR(20),
						Salary VARCHAR(20));
GO

INSERT INTO Job VALUES ('Officer','60000'),('Senior officer','40000'), ('Junior Officer','20000'),('Manager','90000');

GO

CREATE TABLE Department(	DepartmentID INT IDENTITY PRIMARY KEY NOT NULL,
							DepartmentName VARCHAR(50));

GO


INSERT INTO Department VALUES ('HR & Admin Department'), ('Marketing Department'), ('Accounts Department'), ('Production Department') ;

GO

CREATE TABLE Employee(	EmployeeID INT IDENTITY PRIMARY KEY,
						FirstName VARCHAR(20),
						Lastname VARCHAR(20),
						Address VARCHAR(50),
						Contact VARCHAR(20),
						DepartmentID INT REFERENCES	Department (DepartmentID),
						JobID INT REFERENCES Job(JobID),
						ImageFile VARCHAR(200));


					

		
GO
INSERT INTO Employee    VALUES ('Md.', 'Alauddin', 'Saignboard, Narayanganj', '01725-874598', 1,4, '~/Image/333.jpg'),
						('Md.', 'Ontu Sarkar', 'Malibag, Dhaka', '01758-446898', 3,1, '~/Image/111.jpg'), 
					   ('Md.', 'Imran Hossen', 'Demra, Dhaka', '01725-875988',4, 4, '~/Image/222.jpg'),
					   ('Mrs.', 'Benojir Khanam', 'Chasara, Narayanganj', '01758-223498',2, 1, '~/Image/444.jpg'),
					   ('Md.', 'Zulhas Uddin', 'Ghatarchar, Mohammadpur', '01725-846978',1, 2, '~/Image/666.jpg'),
					   ('Md.', 'Robiul Hossain', 'Farmgate, Dhaka', '01725-876488',4, 1, '~/Image/777.jpg'),
					   ('Md.', 'Kawser Ahmed', 'Badda, Dhaka', '01725-976598',3,3, '~/Image/888.jpg'),
					   ('Mrs.', 'Sharmin Akter', 'Adomzi, Narayanganj', '01725-897488',1,3, '~/Image/555.jpg'),
					   ('Mrs.', 'Rokeya Akter', 'Saignboard, Narayanganj', '01725-887952',2,3, '~/Image/999.jpg');
					   
		
GO

CREATE TABLE LogIn(		ID INT IDENTITY PRIMARY KEY NOT NULL,
						UserName VARCHAR(20),
						PassWord VARCHAR(20));
						
GO

INSERT INTO LogIn  VALUES ('user', 'user123');

SELECT * from Employee;








