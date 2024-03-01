Query per creare le tabelle che ho utilizzato
//TAB ANAGRAFICA
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


INSERT INTO [Prova Weekly].[dbo].[ANAGRAFICA] ([Cognome], [Nome], [Indirizzo], [Città], [Cap], [Cod_Fisc])
VALUES
    ('Ferrari', 'Giovanni', 'Via Milano 10', 'Roma', '00100', 'FRRGNN01A01H234A'),
    ('Russo', 'Maria', 'Corso Vittorio Emanuele 20', 'Milano', '20100', 'RSSMAR02A02H567B'),
    ('Romano', 'Paolo', 'Via Napoli 30', 'Napoli', '80100', 'RMNPLA03A03H890C'),
    ('Gallo', 'Francesca', 'Piazza Garibaldi 40', 'Firenze', '50100', 'GLLFNC04A04H123D'),
    ('Conti', 'Alessandro', 'Viale Kennedy 50', 'Torino', '10100', 'CNTALS05A05H456E'),
    ('Mancini', 'Giulia', 'Via Dante 60', 'Bologna', '40100', 'MNCGIU06A06H789F'),
    ('Costa', 'Marco', 'Corso Italia 70', 'Genova', '16100', 'CSTMRC07A07H012G'),
    ('Barbieri', 'Laura', 'Piazza Duomo 80', 'Palermo', '90100', 'BRBLRA08A08H345H'),
    ('Greco', 'Sara', 'Viale Roma 90', 'Catania', '95100', 'GRCRSA09A09H678I'),
    ('Lombardi', 'Luca', 'Corso Umberto 100', 'Bari', '70100', 'LMBLCA10A10H901J');



//TAB TIPO VIOLAZIONE




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



INSERT INTO [Prova Weekly].[dbo].[TIPO VIOLAZIONE] ([Descrizione])
VALUES
    ('Eccesso di velocità'),
    ('Mancato rispetto del semaforo rosso'),
    ('Guida in stato di ebbrezza'),
    ('Utilizzo del telefono cellulare mentre si guida'),
    ('Guida senza cintura di sicurezza'),
    ('Superamento dei limiti di alcol nel sangue'),
    ('Guida contromano'),
    ('Freno di emergenza non funzionante'),
    ('Mancanza di revisione del veicolo'),
    ('Sosta vietata');


//VERBALI




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


INSERT INTO [Prova Weekly].[dbo].[VERBALE] 
    ([DataViolazione], [IndirizzoViolazione], [Nominativo_Agente], [DataTrascrizioneVerbale], [Importo], [DecurtamentoPunti], [idviolazione], [idanagrafica])
VALUES
    ('2024-03-15', 'Via Roma 123', 'Marco Rossi', '2024-03-16', 100, 3, 1, 1),
    ('2024-03-16', 'Via Garibaldi 456', 'Luca Bianchi', '2024-03-17', 150, 4, 2, 2),
    ('2024-03-17', 'Via Dante 789', 'Giulia Verdi', '2024-03-18', 200, 5, 3, 3),
    ('2024-03-18', 'Corso Vittorio Emanuele 1011', 'Paolo Neri', '2024-03-19', 250, 6, 4, 4),
    ('2024-03-19', 'Piazza Duomo 1213', 'Anna Gialli', '2024-03-20', 300, 7, 5, 5),
    ('2024-03-20', 'Via della Pace 1415', 'Sara Rossi', '2024-03-21', 350, 8, 6, 6),
    ('2024-03-21', 'Via delle Rose 1617', 'Mario Verdi', '2024-03-22', 400, 9, 7, 7),
    ('2024-03-22', 'Corso Italia 1819', 'Giovanni Bianchi', '2024-03-23', 450, 10, 8, 8),
    ('2024-03-23', 'Via Milano 2021', 'Laura Neri', '2024-03-24', 500, 11, 9, 9),
    ('2024-03-24', 'Via Napoli 2223', 'Roberto Gialli', '2024-03-25', 550, 12, 10, 10);




