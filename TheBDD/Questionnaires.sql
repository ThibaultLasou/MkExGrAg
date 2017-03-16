CREATE TABLE [dbo].[Questionnaires]
(
	[Id] INT NOT NULL PRIMARY KEY,
	Id_message int not null,
	Id_Option int not null,
	[type] varchar(15) not null,
	constraint [FK_option_questionnaire] foreign key (Id_Option) references Options_Questionnaire (Id),
	constraint [FK_contenu_questionnaire] foreign key (Id_message) references Messages (Id),
	constraint [FK_Type_Questionnaire] foreign key ([type]) references Types_Questionnaire ([type])
)
