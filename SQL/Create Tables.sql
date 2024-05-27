/*
--CREACIÓN DE MI BASE DE DATOS "DVP"

use master;

--Asegurar de que no exista la BD, luego crear la BD.
GO
IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE NAME = 'DVP')
CREATE DATABASE DVP
*/
GO

USE DVP

GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'EntidadPersonas')
CREATE TABLE EntidadPersonas (
    Identificador INT PRIMARY KEY IDENTITY(1,1),
    Nombres VARCHAR(50),
    Apellidos VARCHAR(50),
    NumeroIdentificacion VARCHAR(20),
    Email VARCHAR(50),
    TipoIdentificacion VARCHAR(20),
    FechaCreacion DATETIME DEFAULT GETDATE(),
    IdentificacíonCompleta AS CONCAT(TipoIdentificacion, '-', NumeroIdentificacion),
    NombreCompleto AS CONCAT(Nombres, ' ', Apellidos)
);

GO

--CREACIÓN DE UN STORE PROCEDURE PARA CONSULTAR LAS PERSONAS CREADAS

CREATE PROCEDURE ConsultarPersonas
AS
BEGIN
    SELECT * FROM EntidadPersonas;
END

GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'EntidadUsuario')
CREATE TABLE EntidadUsuario (
    Identificador INT PRIMARY KEY IDENTITY(1,1),
    Usuario VARCHAR(50) UNIQUE	,
    Pass VARCHAR(50),
    FechaCreacion DATETIME DEFAULT GETDATE()
);