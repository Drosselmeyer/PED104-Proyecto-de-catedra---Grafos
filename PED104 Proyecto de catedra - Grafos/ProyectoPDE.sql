CREATE DATABASE ProyectoPED;
GO

USE ProyectoPED;
GO

CREATE TABLE Usuario
(
    Id INT PRIMARY KEY,
	NombreCompleto varchar (50) NOT NULL,
)
GO
CREATE TABLE Embuticion
(
    IdEmbuticion INT PRIMARY KEY,
	Llantas INT,
	Chasis INT,
	Volante INT,
	Motor INT, 
)
GO

CREATE TABLE Ensamblado
(
	IdEnsamblado INT PRIMARY KEY,
    ParteEnsamblada VARCHAR(30) NOT NULL,
    IdLinea INT NOT NULL,
	Color VARCHAR (25) NOT NULL,
	Fecha DATE NOT NULL,
)
GO

CREATE TABLE Linea_Produccion
(
	IdLinea INT  PRIMARY KEY,
    NombreLinea VARCHAR(25),
	TiempoEnsamblado CHAR (10)
)
GO

CREATE TABLE Automovil
(
	IdAutomovil INT PRIMARY KEY NOT NULL,
    Marca VARCHAR(25) NOT NULL,
    Modelo VARCHAR (25) NOT NULL,
	Color VARCHAR (25) NOT NULL,
	Costo DECIMAL NOT NULL,
	DetalleProducto VARCHAR(60),  
)
GO

CREATE TABLE Producto_Ensamblado
(
	IdProductoEnsamblado INT NOT NULL,
    IdProducto INT NOT NULL,
    IdEnsamblado INT NOT NULL,
	IdLinea_Ensamblado INT NOT NULL,
	IdUsuario INT NOT NULL,
	IdEmbuticion INT NOT NULL,
    PRIMARY KEY (IdProductoEnsamblado),
    FOREIGN KEY (IdProducto) REFERENCES Automovil(IdAutomovil),
    FOREIGN KEY (IdEnsamblado) REFERENCES Ensamblado(IdEnsamblado),
	FOREIGN KEY (IdLinea_Ensamblado) REFERENCES Linea_Produccion(IdLinea),
	FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id),
	FOREIGN KEY (IdEmbuticion) REFERENCES Embuticion (IdEmbuticion)
)
GO


INSERT INTO Usuario VALUES
(1,'Alexander Rubio')

INSERT INTO Embuticion VALUES
(1, 4, 1, 1, 1)

INSERT INTO Ensamblado VALUES
(1,'Partes 7',1,'Rojo','3/30/2022')

INSERT INTO Linea_Produccion VALUES
(1,'Full Extra', '1 Mes')

INSERT INTO Automovil VALUES
(1,'TOYOTA','HILUX','ROJO',30000,'Terminado')

INSERT INTO Producto_Ensamblado VALUES
(1,1,1,1,1,1)

SELECT * FROM Usuario
SELECT * FROM Embuticion
SELECT * FROM Ensamblado
SELECT * FROM Linea_Produccion
SELECT * FROM Automovil
SELECT * FROM Producto_Ensamblado
