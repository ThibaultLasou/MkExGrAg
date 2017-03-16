CREATE TABLE [dbo].[Document_Groupe]
(
	[Id_Document] INT NOT NULL,
	Id_groupe int not null,
	constraint [FK_doc_groupe_DocWeb] foreign key (Id_Document) references Doc_Web (Id),
	constraint [FK_doc_groupe_groupe] foreign key (Id_groupe) references Groupes (Id)
);

Go

CREATE CLUSTERED INDEX idx_Document_grp
ON dbo.Document_Groupe
(
Id_Document, Id_groupe
);
