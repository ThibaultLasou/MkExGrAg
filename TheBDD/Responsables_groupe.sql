CREATE TABLE [dbo].[Responsables_groupe]
(
	[Id_individu] INT NOT NULL ,
	[Id_groupe] INT NOT NULL ,
	constraint [FK_groupe_reponsable_groupe] foreign key (Id_groupe) references Groupes (Id),
	constraint [FK_groupe_reponsable_individu] foreign key (Id_individu) references Individus (Id)
);

Go

CREATE CLUSTERED INDEX idx_Respondable
ON dbo.Responsables_groupe
(
Id_individu, Id_groupe
);

