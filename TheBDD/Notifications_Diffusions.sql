CREATE TABLE [dbo].[Notifications_Diffusions]
(
	[Id_groupe] INT NOT NULL ,
	Id_message int NOT NULL ,
	constraint [Fk_Dif_Notif_groupe] foreign key (Id_groupe) references Groupes (Id),
	constraint [Fk_Dif_Notif_message] foreign key (Id_message) references Messages (Id),
);
go
CREATE CLUSTERED INDEX idx_Notif_diff
ON dbo.Notifications_Diffusions
(
Id_groupe, Id_message
);