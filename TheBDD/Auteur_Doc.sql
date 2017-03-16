CREATE TABLE [dbo].[Auteur_Doc]
(
	[Id_individu] INT NOT NULL ,
	[Id_Doc] INT NOT NULL ,
	constraint [FK_Auteur_individu] foreign key (Id_individu) references Individus (Id),
	constraint [FK_Auteur_doc] foreign key (Id_Doc) references Doc_Web (Id),
);

Go

CREATE CLUSTERED INDEX idx_Auteur
ON dbo.Auteur_Doc
(
Id_individu, Id_Doc
);
