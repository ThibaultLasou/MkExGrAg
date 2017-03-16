CREATE TABLE [dbo].[Cours]
(
	[Id] INT NOT NULL PRIMARY KEY,
	Id_prof int not null,
	Id_groupe int not null,
	constraint [Fk_cours_prof] foreign key (Id_prof) references Individus (Id),
	constraint [Fk_cours_groupe] foreign key (Id_groupe) references Groupes (Id),
)
