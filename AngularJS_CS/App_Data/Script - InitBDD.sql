CREATE TABLE [dbo].[Groupe]
(
	[Id] INT NOT NULL PRIMARY KEY,
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
	[Id] INT NOT NULL PRIMARY KEY,
	Id_prof int not null,
	Id_groupe int not null,
	constraint [Fk_cours_prof] foreign key (Id_prof) references Individu (Id),
	constraint [Fk_cours_groupe] foreign key (Id_groupe) references Groupe (Id),
)


CREATE TABLE [dbo].[Activite]
(
	[Id] INT NOT NULL PRIMARY KEY,
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
	[Id] INT NOT NULL PRIMARY KEY,
	contenu_html text not null,
)


CREATE TABLE [dbo].[Doc_Web]
(
	[Id] INT NOT NULL PRIMARY KEY,
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
	[Id] INT NOT NULL PRIMARY KEY,
	Id_expediteur int NOT NULL,
	contenu text NOT NULL, 
    [recu] BIT NOT NULL,
	lu BIT NOT NULL,
	constraint [FK_expediteur_message] foreign key (Id_expediteur) references Individu (Id)

)

CREATE TABLE [dbo].[Notification_Diffusion]
(
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

CREATE TABLE [dbo].[Notification_Simple]
(
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

CREATE TABLE [dbo].[Option_Questionnaire]
(
	[Id] INT NOT NULL PRIMARY KEY,
	valeur Ntext Not null,
)

CREATE TABLE [dbo].[Type_Questionnaire]
(
	[type] VARCHAR(15) NOT NULL PRIMARY KEY
)


CREATE TABLE [dbo].[Questionnaire]
(
	[Id] INT NOT NULL PRIMARY KEY,
	Id_message int not null,
	Id_Option int not null,
	[type] varchar(15) not null,
	constraint [FK_option_questionnaire] foreign key (Id_Option) references Option_Questionnaire (Id),
	constraint [FK_contenu_questionnaire] foreign key (Id_message) references Message (Id),
	constraint [FK_Type_Questionnaire] foreign key ([type]) references Type_Questionnaire ([type])
)


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

