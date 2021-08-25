IF NOT EXISTS (SELECT 1
               FROM   sys.databases
               WHERE  name = 'Aliquota')
  CREATE DATABASE Aliquota

go

USE Aliquota

go

IF NOT EXISTS (SELECT 1
               FROM   sys.tables
               WHERE  name = 'Cliente')
  CREATE TABLE Cliente
    (
       ClienteID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
       Nome      VARCHAR (255) NOT NULL,
       Cpf       VARCHAR(11) NOT NULL
    );

go

IF NOT EXISTS (SELECT 1
               FROM   sys.tables
               WHERE  name = 'Aplicacao')
  CREATE TABLE Aplicacao
    (
       AplicacaoID   INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
       Data          DATETIME NOT NULL,
       Valor         FLOAT NOT NULL,
       TaxaLucro     FLOAT NOT NULL,
       Periodicidade CHAR(1) NOT NULL,
       Resgatado     BIT NOT NULL,
       ClienteID     INT FOREIGN KEY REFERENCES Cliente(ClienteID) ON DELETE CASCADE
    );

go

IF NOT EXISTS (SELECT 1
               FROM   sys.tables
               WHERE  name = 'Resgate')
  CREATE TABLE Resgate
    (
       ResgateID   INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
       Data        DATETIME NOT NULL,
       Valor       FLOAT NOT NULL,
       ValorIR     FLOAT NOT NULL,
       AplicacaoID INT UNIQUE FOREIGN KEY REFERENCES Aplicacao(AplicacaoID) ON DELETE CASCADE
    );

go 
