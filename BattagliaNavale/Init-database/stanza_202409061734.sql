INSERT INTO gestione_torneo.dbo.stanza (id_stanza_padre,id_partita,nome_stanza,livello,fase_del_gioco) VALUES
	 (NULL,1,N'finale',0,N'AG'),
	 (1,NULL,N'semifinale stanza 1',1,NULL),
	 (1,NULL,N'semifinale stanza 2',1,NULL),
	 (2,NULL,N'quarti stanza 1_1',2,N'PO'),
	 (2,3,N'quarti stanza 1_2',2,N'AG'),
	 (3,NULL,N'quarti stanza 2_1',2,NULL),
	 (3,NULL,N'quarti stanza 2_2',2,N'PO');
