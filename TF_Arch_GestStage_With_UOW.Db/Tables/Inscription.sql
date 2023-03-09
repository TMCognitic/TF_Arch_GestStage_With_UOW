CREATE TABLE [dbo].[Inscription]
(
	[EnfantId] INT NOT NULL,
	[StageId] INT NOT NULL,
	[Date] DATE NOT NULL
		CONSTRAINT DF_Inscription_Date DEFAULT (GETDATE()), 
    CONSTRAINT [PK_Inscription] PRIMARY KEY ([EnfantId], [StageId]), 
    CONSTRAINT [FK_Insrciption_Enfant] FOREIGN KEY ([EnfantId]) REFERENCES [Enfant]([Id]), 
    CONSTRAINT [FK_Inscription_Stage] FOREIGN KEY ([StageId]) REFERENCES [Stage]([Id]),
	
)
