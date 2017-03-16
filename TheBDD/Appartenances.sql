CREATE TABLE [dbo].[Appartenances]
(
	[Id_groupe] INT NOT NULL ,
	Id_individu int not null,
	constraint [FK_Appat_groupe] foreign key (Id_groupe) references Groupes (Id),
	constraint [FK_Appat_individu] foreign key (Id_individu) references Individus (Id),
);
Go
CREATE CLUSTERED INDEX idx_Appartenance
ON dbo.Appartenances
(
Id_groupe, Id_individu
);
