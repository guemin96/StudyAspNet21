CREATE TABLE [dbo].[Todos] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Title]        NVARCHAR (150) NOT NULL,
    [IsDone]       BIT            NULL,
    [CreationDate] DATETIME       CONSTRAINT [DF__Todos__CreationD__3B75D760] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK__Todos__3214EC0785D8960C] PRIMARY KEY CLUSTERED ([Id] ASC)
);

