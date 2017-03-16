CREATE TABLE [dbo].[Messages]
(
	[Id] INT NOT NULL PRIMARY KEY,
	Id_expediteur int NOT NULL,
	contenu text NOT NULL, 
    [recu] BIT NOT NULL,
	lu BIT NOT NULL,
	constraint [FK_expediteur_message] foreign key (Id_expediteur) references Individus (Id)

)
