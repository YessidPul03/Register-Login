--CREACIÓN DE MI BASE DE DATOS "DVP"

use master;

--Asegurar de que no exista la BD, luego crear la BD.
GO
IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE NAME = 'DVP')
CREATE DATABASE DVP
