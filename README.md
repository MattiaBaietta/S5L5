Query per creare le tabelle che ho utilizzato

USE [Prova Weekly]
GO

/****** Object:  Table [dbo].[ANAGRAFICA]    Script Date: 01/03/2024 16:31:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ANAGRAFICA](
	[idanagrafica] [int] IDENTITY(1,1) NOT NULL,
	[Cognome] [varchar](50) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Indirizzo] [varchar](50) NOT NULL,
	[Città] [varchar](50) NOT NULL,
	[Cap] [int] NOT NULL,
	[Cod_Fisc] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ANAGRAFICA] PRIMARY KEY CLUSTERED 
(
	[idanagrafica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



USE [Prova Weekly]
GO

/****** Object:  Table [dbo].[TIPO VIOLAZIONE]    Script Date: 01/03/2024 16:33:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TIPO VIOLAZIONE](
	[idviolazione] [int] IDENTITY(1,1) NOT NULL,
	[Descrizione] [varchar](max) NOT NULL,
 CONSTRAINT [PK_TIPO VIOLAZIONE] PRIMARY KEY CLUSTERED 
(
	[idviolazione] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

USE [Prova Weekly]
GO

/****** Object:  Table [dbo].[VERBALE]    Script Date: 01/03/2024 16:33:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VERBALE](
	[idverbale] [int] IDENTITY(1,1) NOT NULL,
	[DataViolazione] [date] NULL,
	[IndirizzoViolazione] [varchar](50) NULL,
	[Nominativo_Agente] [varchar](50) NULL,
	[DataTrascrizioneVerbale] [date] NULL,
	[Importo] [int] NULL,
	[DecurtamentoPunti] [int] NULL,
	[idviolazione] [int] NULL,
	[idanagrafica] [int] NULL,
 CONSTRAINT [PK_VERBALE] PRIMARY KEY CLUSTERED 
(
	[idverbale] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[VERBALE]  WITH CHECK ADD  CONSTRAINT [FK_VERBALE_ANAGRAFICA] FOREIGN KEY([idanagrafica])
REFERENCES [dbo].[ANAGRAFICA] ([idanagrafica])
GO

ALTER TABLE [dbo].[VERBALE] CHECK CONSTRAINT [FK_VERBALE_ANAGRAFICA]
GO

ALTER TABLE [dbo].[VERBALE]  WITH CHECK ADD  CONSTRAINT [FK_VERBALE_TIPO VIOLAZIONE] FOREIGN KEY([idviolazione])
REFERENCES [dbo].[TIPO VIOLAZIONE] ([idviolazione])
GO

ALTER TABLE [dbo].[VERBALE] CHECK CONSTRAINT [FK_VERBALE_TIPO VIOLAZIONE]
GO





