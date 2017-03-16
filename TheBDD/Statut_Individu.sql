CREATE TABLE [dbo].[Statut_Individu]
(
	[Id_individu] INT NOT NULL,
	[Id_statut] INT NOT NULL ,
	constraint [FK_statut_individu_statut] foreign key (Id_statut) references Statut (Id),
	constraint [FK_statut_individu_individu] foreign key (Id_individu) references Individus (Id)
);

Go 

CREATE CLUSTERED INDEX idx_statut_individu
ON dbo.Statut_Individu
(
Id_individu, Id_statut
);