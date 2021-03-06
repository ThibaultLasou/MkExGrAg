/* Drop all Foreign Key constraints */
DECLARE @name VARCHAR(128)
DECLARE @constraint VARCHAR(254)
DECLARE @SQL VARCHAR(254)

SELECT @name = (SELECT TOP 1 TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'FOREIGN KEY' ORDER BY TABLE_NAME)

WHILE @name is not null
BEGIN
    SELECT @constraint = (SELECT TOP 1 CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'FOREIGN KEY' AND TABLE_NAME = @name ORDER BY CONSTRAINT_NAME)
    WHILE @constraint IS NOT NULL
    BEGIN
        SELECT @SQL = 'ALTER TABLE [dbo].[' + RTRIM(@name) +'] DROP CONSTRAINT [' + RTRIM(@constraint) +']'
        EXEC (@SQL)
        PRINT 'Dropped FK Constraint: ' + @constraint + ' on ' + @name
        SELECT @constraint = (SELECT TOP 1 CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'FOREIGN KEY' AND CONSTRAINT_NAME <> @constraint AND TABLE_NAME = @name ORDER BY CONSTRAINT_NAME)
    END
SELECT @name = (SELECT TOP 1 TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'FOREIGN KEY' ORDER BY TABLE_NAME)
END
GO

/* Drop all Primary Key constraints */
DECLARE @name VARCHAR(128)
DECLARE @constraint VARCHAR(254)
DECLARE @SQL VARCHAR(254)

SELECT @name = (SELECT TOP 1 TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'PRIMARY KEY' ORDER BY TABLE_NAME)

WHILE @name IS NOT NULL
BEGIN
    SELECT @constraint = (SELECT TOP 1 CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'PRIMARY KEY' AND TABLE_NAME = @name ORDER BY CONSTRAINT_NAME)
    WHILE @constraint is not null
    BEGIN
        SELECT @SQL = 'ALTER TABLE [dbo].[' + RTRIM(@name) +'] DROP CONSTRAINT [' + RTRIM(@constraint)+']'
        EXEC (@SQL)
        PRINT 'Dropped PK Constraint: ' + @constraint + ' on ' + @name
        SELECT @constraint = (SELECT TOP 1 CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'PRIMARY KEY' AND CONSTRAINT_NAME <> @constraint AND TABLE_NAME = @name ORDER BY CONSTRAINT_NAME)
    END
SELECT @name = (SELECT TOP 1 TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE constraint_catalog=DB_NAME() AND CONSTRAINT_TYPE = 'PRIMARY KEY' ORDER BY TABLE_NAME)
END
GO


/* Drop all tables */
DECLARE @name VARCHAR(128)
DECLARE @SQL VARCHAR(254)

SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] = 'U' AND category = 0 ORDER BY [name])

WHILE @name IS NOT NULL
BEGIN
    SELECT @SQL = 'DROP TABLE [dbo].[' + RTRIM(@name) +']'
    EXEC (@SQL)
    PRINT 'Dropped Table: ' + @name
    SELECT @name = (SELECT TOP 1 [name] FROM sysobjects WHERE [type] = 'U' AND category = 0 AND [name] > @name ORDER BY [name])
END
GO

CREATE TABLE [dbo].[Groupe]
(
	[Id] INT NOT NULL Identity(1,1) PRIMARY KEY,
	nom VARCHAR (15) NOT NULL,
)


CREATE TABLE [dbo].[Individu]
(
	[Id] INT NOT NULL PRIMARY KEY,
	prenom VARCHAR(25) NOT  NULL,
	nom VArCHAR (30) NOT NULL,
	userLogin VARCHAR(8) NOT NULL,
	numCarte VARCHAR(8) NOT NULL,
)


CREATE TABLE [dbo].[Cours]
(
	[Id] INT NOT NULL Identity(1,1) PRIMARY KEY,
	Id_prof int not null,
	Id_groupe int not null,
	constraint [Fk_cours_prof] foreign key (Id_prof) references Individu (Id),
	constraint [Fk_cours_groupe] foreign key (Id_groupe) references Groupe (Id),
)


CREATE TABLE [dbo].[Activite]
(
	[Id] INT NOT NULL Identity(1,1) PRIMARY KEY,
	Id_cours int NOT NULL,
	Id_reunion int not null,
	constraint [FK_Cours_activite] foreign key (Id_cours) references Cours (Id),
)

CREATE TABLE [dbo].[Appartenance]
(
	[Id_groupe] INT NOT NULL ,
	Id_individu int not null,
	constraint [FK_Appat_groupe] foreign key (Id_groupe) references Groupe (Id),
	constraint [FK_Appat_individu] foreign key (Id_individu) references Individu (Id),
);
Go
CREATE CLUSTERED INDEX idx_Appartenance
ON dbo.Appartenance
(
Id_groupe, Id_individu
);


CREATE TABLE [dbo].[Sous_doc_Web]
(
	[Id] INT NOT NULL Identity(1,1) PRIMARY KEY,
	contenu_html text not null,
)


CREATE TABLE [dbo].[Doc_Web]
(
	[Id] INT NOT NULL Identity(1,1) PRIMARY KEY,
	nom VARCHAR(30) not null,
);

CREATE TABLE [dbo].[Doc_Contenu]
(
	[Id_doc] INT NOT NULL ,
	Id_contenu int not null,
	constraint [FK_Main_doc] foreign key (Id_doc) references Doc_Web (Id),
	constraint [FK_Sub_doc] foreign key (Id_contenu) references Sous_doc_Web (Id),
);
Go
CREATE CLUSTERED INDEX idx_Sous_doc
ON dbo.Doc_Contenu
(
Id_doc, Id_contenu
);

CREATE TABLE [dbo].[Auteur_Doc]
(
	[Id_individu] INT NOT NULL ,
	[Id_Doc] INT NOT NULL ,
	constraint [FK_Auteur_individu] foreign key (Id_individu) references Individu (Id),
	constraint [FK_Auteur_doc] foreign key (Id_Doc) references Doc_Web (Id),
);

Go

CREATE CLUSTERED INDEX idx_Auteur
ON dbo.Auteur_Doc
(
Id_individu, Id_Doc
);

CREATE TABLE [dbo].[Salle]
(
	[Id] INT NOT NULL PRIMARY KEY,
	nom VARCHAR(20) not null,
	capacite int not null,	
)


CREATE TABLE [dbo].[Creneau]
(
id int identity(1,1),
    [debut] DATETIME2 not NULL,
	fin DATETIME2 not null,
	Id_Salle int NOT null,
	Id_Activite int not null,
	constraint [fk_creneau_salle] foreign key (Id_Salle) references Salle (Id),
	constraint [fk_activite_creneau] foreign key (Id_Activite) references Activite (Id)
);
Go
CREATE CLUSTERED INDEX idx_Creneau
ON dbo.Creneau
(
debut, fin, Id_Salle
);

CREATE TABLE [dbo].[Document_Groupe]
(
	[Id_Document] INT NOT NULL,
	Id_groupe int not null,
	constraint [FK_doc_groupe_DocWeb] foreign key (Id_Document) references Doc_Web (Id),
	constraint [FK_doc_groupe_groupe] foreign key (Id_groupe) references Groupe (Id)
);

Go

CREATE CLUSTERED INDEX idx_Document_grp
ON dbo.Document_Groupe
(
Id_Document, Id_groupe
);

CREATE TABLE [dbo].[Message]
(
	[Id] INT NOT NULL Identity(1,1) PRIMARY KEY,
	Id_expediteur int NOT NULL,
	sujet varchar(40) null,
    [recu] BIT NOT NULL,
	lu BIT NOT NULL,
	envoi DATETIME2 not null,
	lecture DATETIME2 not null,
	contenu text NOT NULL, 
	constraint [FK_expediteur_message] foreign key (Id_expediteur) references Individu (Id)

)

CREATE TABLE [dbo].[Notification_Diffusion]
(
	Id int identity(1,1) not null,
	[Id_groupe] INT NOT NULL ,
	Id_message int NOT NULL ,
	constraint [Fk_Dif_Notif_groupe] foreign key (Id_groupe) references Groupe (Id),
	constraint [Fk_Dif_Notif_message] foreign key (Id_message) references Message (Id),
);
go
CREATE CLUSTERED INDEX idx_Notif_diff
ON dbo.Notification_Diffusion
(
Id_groupe, Id_message
);
ALTER TABLE Notification_Diffusion Add constraint PK_Notif_Diff PRIMARY KEY (Id);

CREATE TABLE [dbo].[Notification_Simple]
(
	Id int identity(1,1) not null,
	[Id_message] INT NOT NULL ,
	Id_individu int not null,
	constraint [FK_Snotif_message] foreign key (Id_message) references Message (Id),
	Constraint [FK_Snotif_individu] Foreign key (Id_individu) references Individu (Id),
);

Go

CREATE CLUSTERED INDEX idx_notif_simpl
ON dbo.Notification_Simple
(
Id_message, Id_individu
);

ALTER TABLE Notification_Simple Add constraint PK_Notif_Simp PRIMARY KEY (Id);
CREATE TABLE [dbo].[Option_Questionnaire]
(
Id int Identity(1,1) not null primary key,
	valeur varchar(30) Not null,
)

CREATE TABLE [dbo].[Type_Questionnaire]
(
Id int not null Identity(1,1) primary key,
	[type] VARCHAR(15) NOT NULL
)


CREATE TABLE [dbo].[Questionnaire]
(
	[Id] INT NOT NULL Identity(1,1) PRIMARY KEY,
	Id_message int not null,
	[type] int not null,
	Id_rep int null,
	constraint [FK_givenRep] foreign key (Id_rep) references Option_Questionnaire(Id),
	constraint [FK_contenu_questionnaire] foreign key (Id_message) references Message (Id),
	constraint [FK_Type_Questionnaire] foreign key ([type]) references Type_Questionnaire ([Id])
)

Create Table [dbo].[Reponses](
	Id int identity(1,1) not null,
	Id_question int not null,
	Id_reponse int not null,
	constraint [FK_option_questionnaire] foreign key (Id_question) references Questionnaire (Id),
	constraint FK_rep_quest foreign key (Id_reponse) references Option_Questionnaire (Id),
);
Go
Create Clustered Index rep_pos_ques
On dbo.Reponses(
Id_question,Id_reponse
);

ALTER TABLE Reponses Add constraint PK_rep PRIMARY KEY (Id);

CREATE TABLE [dbo].[Responsable_groupe]
(
	[Id_individu] INT NOT NULL ,
	[Id_groupe] INT NOT NULL ,
	constraint [FK_groupe_reponsable_groupe] foreign key (Id_groupe) references Groupe (Id),
	constraint [FK_groupe_reponsable_individu] foreign key (Id_individu) references Individu (Id)
);

Go

CREATE CLUSTERED INDEX idx_Respondable
ON dbo.Responsable_groupe
(
Id_individu, Id_groupe
);

CREATE TABLE [dbo].[Statut]
(
	[Id] INT  NOT NULL PRIMARY KEY,
	nom VARCHAR(15) NOT NULL, 
)


CREATE TABLE [dbo].[Statut_Individu]
(
	[Id_individu] INT NOT NULL,
	[Id_statut] INT NOT NULL ,
	constraint [FK_statut_individu_statut] foreign key (Id_statut) references Statut (Id),
	constraint [FK_statut_individu_individu] foreign key (Id_individu) references Individu (Id)
);

Go 

CREATE CLUSTERED INDEX idx_statut_individu
ON dbo.Statut_Individu
(
Id_individu, Id_statut
);

CREATE TABLE [dbo].[Tâche]
(
	[Id] INT NOT NULL PRIMARY KEY
)

/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
 INSERT INTO Statut (Id, nom) VALUES (1,'Etudiant'); 
 INSERT INTO Statut (Id, nom) VALUES (2, 'Professeur');
 

 INSERT INTO Individu (Id, nom, prenom, userLogin, numCarte) VALUES (1,  'martin','bob', 'bobmart', 11111111);
 INSERT INTO Individu (Id, nom, prenom, userLogin, numCarte) VALUES (2,  'matin','martin', 'martmati', 22222222);
 INSERT INTO Individu (Id, nom, prenom, userLogin, numCarte) VALUES (3,  'dop','stephane', 'stepdop', 33333333);
  insert into Statut_Individu (Id_individu, Id_statut) VALUES (1, 2);
  insert into Statut_Individu (Id_individu, Id_statut) VALUES (3, 2);
  insert into Statut_Individu (Id_individu, Id_statut) VALUES (2, 1);
  insert into Individu (Id, prenom, nom, userLogin, numCarte) Values (4, 'Mathieu', 'Louvet', 'louvmath', 44444444),
  (5, 'T-Bow', 'Lasou', 'lasothib', 55555555),
  (6, 'Tristan', 'Hermant', 'hermtris', 66666666),
  (7, 'Yasmine', 'Kertous', 'kertyasm', 77777777),
  (8, 'Bryan', 'Vigee', 'vigebrya', 88888888);
Insert into Option_Questionnaire (valeur) VALUES ('Oui'),('Non'),('Peut-Etre'),
('Eventuellement'),('Lundi'),('Mardi'),
('Mercredi'),('Jeudi'),('Vendredi'),
('Samedi'),('Toujours'),('Jamais');
Insert INTO Type_Questionnaire (type) VALUES ('Oui-Non'),('Oui-Non+'),('Choix de Jour'),('Custom');

INSERT INTO Doc_Web (nom) VALUES ('Doc_1');
INSERT INTO Sous_doc_Web (contenu_html) VALUES ('<h1>Document 1</h1>');
INSERT INTO Sous_doc_Web (contenu_html) VALUES ('<p>Ceci est du texte</p>');
INSERT INTO Doc_Contenu (Id_doc, Id_contenu) VALUES (1,1), (1,2);
INSERT INTO Auteur_Doc (Id_individu, Id_Doc) VALUEs (5,1);
INSERT INTO Doc_Web (nom) VALUES ('Doc_2');
INSERT INTO Sous_doc_Web (contenu_html) VALUES ('<h1>Document 2</h1>');
INSERT INTO Sous_doc_Web (contenu_html) VALUES ('<p>Ceci est du texte</p>');
INSERT INTO Doc_Contenu (Id_doc, Id_contenu) VALUES (2,3), (2,4);
INSERT INTO Auteur_Doc (Id_individu, Id_Doc) VALUEs (5,2);