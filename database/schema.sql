DROP DATABASE IF EXISTS [todoAPi];
GO

CREATE DATABASE [todoAPi];
GO

USE [todoAPi];
GO

CREATE TABLE [User] (
    [Id] int NOT NULL IDENTITY(1,1),
    [Firstname] nvarchar(max) NOT NULL,
    [Lastname] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id]),
    CONSTRAINT [UK_User] UNIQUE ([Email])
);
GO

CREATE TABLE [Topic] (
    [Id] int NOT NULL IDENTITY(1, 1),
    [Content] nvarchar(max),
    [Title] nvarchar(max),
    CONSTRAINT [PK_Topic] PRIMARY KEY ([Id])
);
GO

INSERT INTO [User] (Firstname, Lastname, Email, Password) VALUES
('Juan', 'Dela Cruz', 'juan@email.com', 'secret');
GO

INSERT INTO [Topic] (Title, Content) VALUES
('Why open source is good?', 'From the development perspective, today one of the best ways to benefit with open source is to use the SaaS business model. It makes sense if you have a fully-fledged application capable of generating demand. The SaaS model is a popular way to license software because it’s flexible and offers rapid deployment and decreased costs. The software is stored in the cloud; users only need a web browser to access an application, so it also makes SaaS attractive.');
GO