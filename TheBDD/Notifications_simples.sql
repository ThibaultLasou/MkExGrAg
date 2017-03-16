CREATE TABLE [dbo].[Notifications_simples]
(
	[Id_message] INT NOT NULL ,
	Id_individu int not null,
	constraint [FK_Snotif_message] foreign key (Id_message) references Messages (Id),
	Constraint [FK_Snotif_individu] Foreign key (Id_individu) references Individus (Id),
);

Go

CREATE CLUSTERED INDEX idx_notif_simpl
ON dbo.Notifications_simples
(
Id_message, Id_individu
);
