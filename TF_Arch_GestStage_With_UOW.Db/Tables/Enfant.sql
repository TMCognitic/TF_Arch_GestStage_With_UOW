CREATE TABLE [dbo].[Enfant]
(
	[Id] INT IDENTITY, 
    [Nom] NVARCHAR(50) NOT NULL, 
    [Prenom] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Enfant] PRIMARY KEY ([Id]),
    CONSTRAINT [UK_Enfant_NomComplet] UNIQUE ([Nom], [Prenom])
)
