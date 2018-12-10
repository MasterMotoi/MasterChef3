CREATE TABLE [masterchef3].[materiel_lavable] (
    [id_materiel_lavable] INT           IDENTITY (1, 1) NOT NULL,
    [machine]             NVARCHAR (50) NOT NULL,
    [propre]              SMALLINT      NOT NULL,
    [id_materiel]         INT           NOT NULL,
    CONSTRAINT [PK_materiel_lavable_id_materiel_lavable] PRIMARY KEY CLUSTERED ([id_materiel_lavable] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_SSMA_SOURCE', @value = N'masterchef3.materiel_lavable', @level0type = N'SCHEMA', @level0name = N'masterchef3', @level1type = N'TABLE', @level1name = N'materiel_lavable';

