CREATE TABLE [dbo].[Stage]
(
	[Id] INT Identity, 
	[Titre] NVARCHAR(128) NOT NULL,
    CONSTRAINT [PK_Stage] PRIMARY KEY ([Id]),
	CONSTRAINT [UK_Stage_Titre] UNIQUE ([Titre])
)
