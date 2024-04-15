/*
Docker run MS SQL:
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=4dev2024!" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest

DELETE FROM [OrderDB].[orders].[ClientOrder];
DELETE FROM [ClientDB].[clients].[Client];
DELETE FROM [ProductDB].[products].[Product];
*/


USE master

if db_id('ClientDB') is NULL
BEGIN
    create database ClientDB;
END

USE ClientDB;

IF schema_id('clients') is null
BEGIN
    exec ('create schema clients');
END
if OBJECT_ID('[clients].Client') is NULL
BEGIN
    create table [clients].[Client] (
        Id UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_clients_Client_Id DEFAULT(newid()),
        FirstName nvarchar(100) NOT NULL,
        LastName nvarchar(100) NOT NULL,
        Gender varchar(1) NOT NULL,
        Phone nvarchar(9) NULL CONSTRAINT CK_clients_Client_Phone_LenEqual CHECK (LEN(Phone)=9),
        [Address] nvarchar(255) not null,
        CONSTRAINT PK_clients_Client PRIMARY KEY (Id)
    )
END
GO
USE master

if db_id('ProductDB') is NULL
BEGIN
    create database ProductDB;
END

USE ProductDB;

if SCHEMA_ID('products') is NULL
BEGIN
    exec ('create schema products');
END

if OBJECT_ID('[products].Product') is NULL
BEGIN
    create table [products].[Product] (
        Id UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_products_Product_Id DEFAULT(newid()),
        [Name] nvarchar(100) NOT NULL,
        UnitPrice decimal(9,2) NOT NULL,
        TaxValue decimal(4,2) NOT NULL,
        CONSTRAINT PK_products_Product PRIMARY KEY (Id)
    )
END
GO
USE master

if db_id('OrderDB') is NULL
BEGIN
    create database OrderDB;
END

USE [OrderDB];

if SCHEMA_ID('orders') is NULL
BEGIN
    exec ('create schema orders');
END

if OBJECT_ID('[orders].ClientOrder') is NULL
BEGIN
    CREATE table [orders].[ClientOrder]
    (
        Id UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_orders_ClientOrder_Id DEFAULT(newid()),
        FirstName nvarchar(100) NOT NULL,
        LastName nvarchar(100) NOT NULL,
        ClientId UNIQUEIDENTIFIER NOT NULL,
        Phone nvarchar(9) NULL CONSTRAINT CK_clients_Client_Phone_LenEqual CHECK (LEN(Phone)=9),
        [Address] nvarchar(255) not null,
        CONSTRAINT PK_orders_ClientOrder PRIMARY KEY (Id)
    )
END