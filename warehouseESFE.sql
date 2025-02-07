-- Crear la base de datos
CREATE DATABASE warehouseESFE;
GO

USE warehouseESFE;
GO

-- Crear tablas
CREATE TABLE Roles (
    RoleId INT IDENTITY(1,1) PRIMARY KEY,
    RolName VARCHAR(50) NOT NULL
);

CREATE TABLE Statuses (
    StatusId INT IDENTITY(1,1) PRIMARY KEY,
    StatusName VARCHAR(25) NOT NULL
);

CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY, 
    FullName VARCHAR(200),
    UserName VARCHAR(200),
    Email VARCHAR(100),
    Passwords VARCHAR(100),
    RoleId INT NOT NULL FOREIGN KEY REFERENCES Roles(RoleId),
    StatusId INT NOT NULL FOREIGN KEY REFERENCES Statuses(StatusId)
);

CREATE TABLE Categories (
    CategoryId INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName VARCHAR(100) NOT NULL
);

CREATE TABLE MeasurementUnits (
    UnitId INT IDENTITY(1,1) PRIMARY KEY,
    MeasurementUnitName VARCHAR(50) NOT NULL
);

CREATE TABLE Brands (
    BrandId INT IDENTITY(1,1) PRIMARY KEY,
    BrandName VARCHAR(100) NOT NULL
);

CREATE TABLE Articles (
    ArticleId INT IDENTITY(1,1) PRIMARY KEY,
    UniqueCode VARCHAR(50) NOT NULL,
    ArticleName VARCHAR(200) NOT NULL,
    Descriptions VARCHAR(500),
    Stock INT NOT NULL,
    IsReturnable VARCHAR(2) DEFAULT 'Sí',
    CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(CategoryId),
    UnitId INT NOT NULL FOREIGN KEY REFERENCES MeasurementUnits(UnitId),
    BrandId INT NOT NULL FOREIGN KEY REFERENCES Brands(BrandId),
    StatusId INT NOT NULL FOREIGN KEY REFERENCES Statuses(StatusId)
);

CREATE TABLE Loans (
    LoanId INT IDENTITY(1,1) PRIMARY KEY,
    DepartureDate DATETIME NOT NULL,
    ReturnDate DATETIME NULL,
    StatusId INT NOT NULL FOREIGN KEY REFERENCES Statuses(StatusId),
    GrocerId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId), 
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId) 
);

CREATE TABLE LoanDetails (
    LoanDetailId INT IDENTITY(1,1) PRIMARY KEY,
    Quantity INT NOT NULL,
    Observations VARCHAR(200) NOT NULL,
    IsReturnable VARCHAR(2) DEFAULT 'Sí',
    LoanId INT NOT NULL FOREIGN KEY REFERENCES Loans(LoanId),
    ArticleId INT NOT NULL FOREIGN KEY REFERENCES Articles(ArticleId)
);

CREATE TABLE LoanValidation (
    LoanValidationId INT IDENTITY(1,1) PRIMARY KEY,
    ValidationDate DATETIME NOT NULL,
    Observations VARCHAR(200) NOT NULL,
    LoanId INT NOT NULL FOREIGN KEY REFERENCES Loans(LoanId),
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId),
    IsApproved VARCHAR(3) DEFAULT 'No' NOT NULL
);

-- Insertar datos iniciales
INSERT INTO Roles (RolName)
VALUES 
('Bodeguero'),
('Admin'),
('Docente'),
('Invitado'),
('Administrativo');

INSERT INTO Statuses (StatusName)
VALUES 
('Activo'),
('Inactivo'),
('Pendiente'),
('Aprobado'),
('Rechazado');

INSERT INTO Users (FullName, UserName, Email, Passwords, RoleId, StatusId)
VALUES
('Roberto Escobar', 're23009', 're23009@esfe.agape.edu.sv', 'password123', 1, 1), -- Bodeguero
('Ana Martínez', 'am23010', 'am23010@esfe.agape.edu.sv', 'password456', 2, 1),    -- Admin
('Luis Pérez', 'lp23011', 'lp23011@esfe.agape.edu.sv', 'password789', 3, 1),     -- Docente
('María López', 'ml23012', 'ml23012@esfe.agape.edu.sv', 'password321', 4, 1),    -- Invitado
('Carlos Gómez', 'cg23013', 'cg23013@esfe.agape.edu.sv', 'password654', 5, 1);   -- Administrativo

INSERT INTO Categories (CategoryName)
VALUES 
('Herramientas'),
('Componentes de PC'),
('Consumibles'),
('Repuestos'),
('Otros');

INSERT INTO MeasurementUnits (MeasurementUnitName)
VALUES 
('Pieza'),
('Metro'),
('Litro'),
('Paquete'),
('Caja');

INSERT INTO Brands (BrandName)
VALUES 
('Stanley'),
('Bosch'),
('Dell'),
('HP'),
('Kingston');

INSERT INTO Articles (UniqueCode, ArticleName, Descriptions, Stock, IsReturnable, CategoryId, UnitId, BrandId, StatusId)
VALUES
('ART-001', 'Cable HDMI', 'Cable HDMI de 1.5 metros', 50, 'Sí', 2, 2, 3, 1),
('ART-002', 'Martillo', 'Martillo con mango de goma', 20, 'Sí', 1, 1, 1, 1),
('ART-003', 'Taladro', 'Taladro eléctrico de 500W', 10, 'No', 1, 1, 2, 1),
('ART-004', 'Memoria RAM 8GB', 'Memoria RAM DDR4 8GB', 30, 'Sí', 2, 1, 5, 1),
('ART-005', 'Paquete de tornillos', 'Tornillos para mantenimiento', 100, 'Sí', 3, 4, 4, 1);

INSERT INTO Loans (DepartureDate, ReturnDate, StatusId, GrocerId, UserId)
VALUES
('2025-01-20', NULL, 1, 1, 3),
('2025-01-18', '2025-01-20', 4, 1, 2),
('2025-01-15', '2025-01-18', 5, 1, 4);

INSERT INTO LoanDetails (Quantity, Observations, IsReturnable, LoanId, ArticleId)
VALUES
(2, 'Uso en mantenimiento de computadoras', 'Sí', 1, 1),
(1, 'Reparación de muebles', 'No', 2, 2),
(5, 'Stock para proyectos escolares', 'Sí', 3, 5);

INSERT INTO LoanValidation (ValidationDate, Observations, LoanId, UserId, IsApproved)
VALUES
('2025-01-20', 'Validación completada sin problemas', 1, 2, 'Sí'),
('2025-01-18', 'El usuario devolvió el equipo correctamente', 2, 2, 'Sí'),
('2025-01-15', 'El préstamo fue rechazado debido a daños previos', 3, 2, 'No');

-- Consultar datos
SELECT * FROM Roles;
SELECT * FROM Statuses;
SELECT * FROM Users;
SELECT * FROM Categories;
SELECT * FROM MeasurementUnits;
SELECT * FROM Brands;
SELECT * FROM Articles;
SELECT * FROM Loans;
SELECT * FROM LoanDetails;
SELECT * FROM LoanValidation;
