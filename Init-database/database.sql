CREATE DATABASE gestione_torneo;

USE gestione_torneo;

-- DROP SCHEMA dbo;

-- CREATE SCHEMA dbo;
-- gestione_torneo.dbo.[__EFMigrationsHistory] definition

-- Drop table

-- DROP TABLE gestione_torneo.dbo.[__EFMigrationsHistory];

CREATE TABLE gestione_torneo.dbo.[__EFMigrationsHistory] (
	MigrationId nvarchar(150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	ProductVersion nvarchar(32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK___EFMigrationsHistory PRIMARY KEY (MigrationId)
);


-- gestione_torneo.dbo.griglia_di_gioco definition

-- Drop table

-- DROP TABLE gestione_torneo.dbo.griglia_di_gioco;

CREATE TABLE gestione_torneo.dbo.griglia_di_gioco (
	id_griglia_di_gioco int IDENTITY(1,1) NOT NULL,
	schema_griglia_avversario text COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__griglia___2C1584AE14464DD3 PRIMARY KEY (id_griglia_di_gioco)
);


-- gestione_torneo.dbo.partita definition

-- Drop table

-- DROP TABLE gestione_torneo.dbo.partita;

CREATE TABLE gestione_torneo.dbo.partita (
	id_partita int IDENTITY(1,1) NOT NULL,
	CONSTRAINT PK__partita__42D8BC5E7BD38438 PRIMARY KEY (id_partita)
);


-- gestione_torneo.dbo.stanza definition

-- Drop table

-- DROP TABLE gestione_torneo.dbo.stanza;

CREATE TABLE gestione_torneo.dbo.stanza (
	id_stanza int IDENTITY(1,1) NOT NULL,
	id_stanza_padre int NULL,
	id_partita int NULL,
	nome_stanza varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	livello int NULL,
	fase_del_gioco char(2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__stanza__4B92981692EB16F2 PRIMARY KEY (id_stanza),
	CONSTRAINT FK__stanza__id_parti__33D4B598 FOREIGN KEY (id_partita) REFERENCES gestione_torneo.dbo.partita(id_partita),
	CONSTRAINT FK__stanza__id_stanz__32E0915F FOREIGN KEY (id_stanza_padre) REFERENCES gestione_torneo.dbo.stanza(id_stanza)
);


-- gestione_torneo.dbo.utente definition

-- Drop table

-- DROP TABLE gestione_torneo.dbo.utente;

CREATE TABLE gestione_torneo.dbo.utente (
	id_utente int IDENTITY(1,1) NOT NULL,
	username varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	password varchar(16) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	ruolo char(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	id_stanza int NULL,
	CONSTRAINT PK__utente__43BCA62EE15FB77F PRIMARY KEY (id_utente),
	CONSTRAINT FK__utente__id_stanz__31EC6D26 FOREIGN KEY (id_stanza) REFERENCES gestione_torneo.dbo.stanza(id_stanza)
);


-- gestione_torneo.dbo.griglia_partita definition

-- Drop table

-- DROP TABLE gestione_torneo.dbo.griglia_partita;

CREATE TABLE gestione_torneo.dbo.griglia_partita (
	id_griglia_partita int IDENTITY(1,1) NOT NULL,
	id_griglia_di_gioco int NULL,
	id_partita int NULL,
	id_utente int NULL,
	schema_griglia_navi text COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__griglia___39299032E8C54700 PRIMARY KEY (id_griglia_partita),
	CONSTRAINT FK__griglia_p__id_gr__2E1BDC42 FOREIGN KEY (id_griglia_di_gioco) REFERENCES gestione_torneo.dbo.griglia_di_gioco(id_griglia_di_gioco),
	CONSTRAINT FK__griglia_p__id_pa__2F10007B FOREIGN KEY (id_partita) REFERENCES gestione_torneo.dbo.partita(id_partita),
	CONSTRAINT FK__griglia_p__id_ut__47DBAE45 FOREIGN KEY (id_utente) REFERENCES gestione_torneo.dbo.utente(id_utente)
);


-- gestione_torneo.dbo.mossa definition

-- Drop table

-- DROP TABLE gestione_torneo.dbo.mossa;

CREATE TABLE gestione_torneo.dbo.mossa (
	id_mossa int IDENTITY(1,1) NOT NULL,
	id_griglia_partita int NULL,
	id_utente int NULL,
	numero_mossa int NULL,
	mossa_eseguita char(3) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT PK__mossa__FB4C599D82A32630 PRIMARY KEY (id_mossa),
	CONSTRAINT FK__mossa__id_grigli__300424B4 FOREIGN KEY (id_griglia_partita) REFERENCES gestione_torneo.dbo.griglia_partita(id_griglia_partita),
	CONSTRAINT FK__mossa__id_utente__30F848ED FOREIGN KEY (id_utente) REFERENCES gestione_torneo.dbo.utente(id_utente)
);