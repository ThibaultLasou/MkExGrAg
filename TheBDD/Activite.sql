CREATE TABLE [dbo].[Activites]
(
	[Id] INT NOT NULL PRIMARY KEY,
	Id_cours int NOT NULL,
	Id_reunion int not null,
	constraint [FK_Cours_activite] foreign key (Id_cours) references Cours (Id),
)

