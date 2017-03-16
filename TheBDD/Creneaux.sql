CREATE TABLE [dbo].[Creneaux]
(
    [debut] DATETIME2 not NULL,
	fin DATETIME2 not null,
	Id_Salle int NOT null,
	Id_Activite int not null,
	constraint [fk_creneau_salle] foreign key (Id_Salle) references Salles (Id),
	constraint [fk_activite_creneau] foreign key (Id_Activite) references Activites (Id)
);
Go
CREATE CLUSTERED INDEX idx_Creneaux
ON dbo.Creneaux
(
debut, fin, Id_Salle
);
