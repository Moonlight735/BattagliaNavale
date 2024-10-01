ALTER TABLE utente NOCHECK CONSTRAINT ALL;
ALTER TABLE stanza NOCHECK CONSTRAINT ALL;
ALTER TABLE partita NOCHECK CONSTRAINT ALL;
ALTER TABLE mossa NOCHECK CONSTRAINT ALL;
ALTER TABLE griglia_partita NOCHECK CONSTRAINT ALL;
ALTER TABLE griglia_di_gioco NOCHECK CONSTRAINT ALL;
ALTER TABLE __EFMigrationsHistory NOCHECK CONSTRAINT ALL;

INSERT INTO gestione_torneo.dbo.stanza (id_stanza_padre,id_partita,nome_stanza,livello,fase_del_gioco) VALUES
	 (NULL,1,N'finale',0,N'AG'),
	 (1,NULL,N'semifinale stanza 1',1,NULL),
	 (1,NULL,N'semifinale stanza 2',1,NULL),
	 (2,NULL,N'quarti stanza 1_1',2,N'PO'),
	 (2,3,N'quarti stanza 1_2',2,N'AG'),
	 (3,NULL,N'quarti stanza 2_1',2,NULL),
	 (3,NULL,N'quarti stanza 2_2',2,N'PO');

SET IDENTITY_INSERT gestione_torneo.dbo.partita ON;
INSERT INTO gestione_torneo.dbo.partita (id_partita) VALUES
	 (1),
	 (2),
	 (3);
SET IDENTITY_INSERT gestione_torneo.dbo.partita OFF;

INSERT INTO gestione_torneo.dbo.mossa (id_griglia_partita,id_utente,numero_mossa,mossa_eseguita) VALUES
	 (1,1,1,N'C3'),
	 (2,2,2,N'D7'),
	 (1,2,100,N'A2'),
	 (1,1,101,N'B1'),
	 (1,1,104,N'C1'),
	 (3,3,105,N'A1'),
	 (3,3,105,N'A2'),
	 (3,3,109,N'A1'),
	 (3,3,110,N'A2'),
	 (4,4,120,N'C3');

INSERT INTO gestione_torneo.dbo.griglia_partita (id_griglia_di_gioco,id_partita,id_utente,schema_griglia_navi) VALUES
	 (1,1,1,N'{"Dimensione":10,"Celle":[["X","X","P1","P1","P1","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["C1","C1","C1","C1","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["I1","I1","I1","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["S1","S1","S1","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["K1","K1","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"]],"Navi":{"P1":{"Id":"1","Tipo":0,"Lunghezza":5,"ColpiRicevuti":2},"C1":{"Id":"1","Tipo":1,"Lunghezza":4,"ColpiRicevuti":0},"I1":{"Id":"1","Tipo":2,"Lunghezza":3,"ColpiRicevuti":0},"S1":{"Id":"1","Tipo":3,"Lunghezza":3,"ColpiRicevuti":0},"K1":{"Id":"1","Tipo":4,"Lunghezza":2,"ColpiRicevuti":0}}}'),
	 (2,1,2,N'{"Dimensione":10,"Celle":[["X","P1","X","P1","P1","~","~","~","~","~"],["O","~","~","~","~","~","~","~","~","~"],["C1","C1","C1","C1","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["S1","S1","S1","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["I1","I1","I1","~","~","~","~","~","~","~"],["K1","~","~","~","~","~","~","~","~","~"],["K1","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"]],"Navi":{"P1":{"Id":"1","Tipo":0,"Lunghezza":5,"ColpiRicevuti":2},"C1":{"Id":"1","Tipo":1,"Lunghezza":4,"ColpiRicevuti":0},"I1":{"Id":"1","Tipo":2,"Lunghezza":3,"ColpiRicevuti":0},"S1":{"Id":"1","Tipo":3,"Lunghezza":3,"ColpiRicevuti":0},"K1":{"Id":"1","Tipo":4,"Lunghezza":2,"ColpiRicevuti":0}}}'),
	 (1004,2,3,N'{"Dimensione":10,"Celle":[["~","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["~","~","X","I1","I1","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"]],"Navi":{"I1":{"Id":"1","Tipo":2,"Lunghezza":3,"ColpiRicevuti":1}}}'),
	 (1005,2,4,N'{"Dimensione":10,"Celle":[["X","~","~","~","~","~","~","~","~","~"],["X","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"]],"Navi":{"K1":{"Id":"1","Tipo":4,"Lunghezza":2,"ColpiRicevuti":2}}}');

INSERT INTO gestione_torneo.dbo.griglia_di_gioco (schema_griglia_avversario) VALUES
	 (N'{"Dimensione":10,"Celle":[["X","P1","X","P1","P1","~","~","~","~","~"],["O","~","~","~","~","~","~","~","~","~"],["C1","C1","C1","C1","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["S1","S1","S1","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["I1","I1","I1","~","~","~","~","~","~","~"],["K1","~","~","~","~","~","~","~","~","~"],["K1","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"]],"Navi":{"P1":{"Id":"1","Tipo":0,"Lunghezza":5,"ColpiRicevuti":2},"C1":{"Id":"1","Tipo":1,"Lunghezza":4,"ColpiRicevuti":0},"I1":{"Id":"1","Tipo":2,"Lunghezza":3,"ColpiRicevuti":0},"S1":{"Id":"1","Tipo":3,"Lunghezza":3,"ColpiRicevuti":0},"K1":{"Id":"1","Tipo":4,"Lunghezza":2,"ColpiRicevuti":0}}}'),
	 (N'{"Dimensione":10,"Celle":[["X","X","P1","P1","P1","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["C1","C1","C1","C1","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["I1","I1","I1","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["S1","S1","S1","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["K1","K1","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"]],"Navi":{"P1":{"Id":"1","Tipo":0,"Lunghezza":5,"ColpiRicevuti":2},"C1":{"Id":"1","Tipo":1,"Lunghezza":4,"ColpiRicevuti":0},"I1":{"Id":"1","Tipo":2,"Lunghezza":3,"ColpiRicevuti":0},"S1":{"Id":"1","Tipo":3,"Lunghezza":3,"ColpiRicevuti":0},"K1":{"Id":"1","Tipo":4,"Lunghezza":2,"ColpiRicevuti":0}}}'),
	 (N'{"Dimensione":10,"Celle":[["X","~","~","~","~","~","~","~","~","~"],["X","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"]],"Navi":{"K1":{"Id":"1","Tipo":4,"Lunghezza":2,"ColpiRicevuti":2}}}'),
	 (N'{"Dimensione":10,"Celle":[["~","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["~","~","X","I1","I1","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"],["~","~","~","~","~","~","~","~","~","~"]],"Navi":{"I1":{"Id":"1","Tipo":2,"Lunghezza":3,"ColpiRicevuti":1}}}');

INSERT INTO gestione_torneo.dbo.utente (username,password,ruolo,id_stanza) VALUES
	 (N'user01',N'pswd01',N'G',1),
	 (N'user02',N'pswd02',N'G',1),
	 (N'user03',N'pswd03',N'G',2),
	 (N'user04',N'pswd04',N'G',2),
	 (N'user05',N'pswd05',N'S',1),
	 (N'user06',N'pswd06',N'S',5),
	 (N'user07',N'pswd07',N'S',5),
	 (N'user08',N'pswd08',N'G',5);










ALTER TABLE utente CHECK CONSTRAINT ALL;
ALTER TABLE stanza CHECK CONSTRAINT ALL;
ALTER TABLE partita CHECK CONSTRAINT ALL;
ALTER TABLE mossa CHECK CONSTRAINT ALL;
ALTER TABLE griglia_partita CHECK CONSTRAINT ALL;
ALTER TABLE griglia_di_gioco CHECK CONSTRAINT ALL;
ALTER TABLE __EFMigrationsHistory CHECK CONSTRAINT ALL;