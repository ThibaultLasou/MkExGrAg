CREATE TABLE [dbo].[Doc_Web]
(
	[Id] INT NOT NULL PRIMARY KEY,
	nom VARCHAR(30) not null,
	[Id_contenu] int not null,
	constraint [fk_docWeb_contenu] foreign key (Id_contenu)REFERENCES Sous_doc_Web (Id)
)
