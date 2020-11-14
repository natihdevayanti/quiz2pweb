CREATE TABLE [dbo].[Book] (
    [Id]        INT           NOT NULL IDENTITY,
    [Name]      VARCHAR (256) NOT NULL,
    [Author]    VARCHAR (100) NOT NULL,
    [Publisher] VARCHAR (100) NOT NULL,
    [Review]    TEXT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

