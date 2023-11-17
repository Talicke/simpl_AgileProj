use simpl_agileproj;

INSERT INTO account(username, password)
VALUES 
	('Alpha','1111'),
    ('Bravo', '2222'),
    ('Charlie', '3333'),
    ('Delta', '4444');
    
INSERT INTO project (name_project, created_at_project)
VALUES 
	('Projet 01','2023-11-14 12:00:00'),
    ('Projet 02','2023-11-14 12:00:00'),
    ('Projet 03','2023-11-14 12:00:00'),
    ('Projet 04','2023-11-14 12:00:00'),
    ('Projet 05','2023-11-14 12:00:00'),
    ('Projet 06','2023-11-14 12:00:00'),
    ('Projet 07','2023-11-14 12:00:00'),
    ('Projet 08','2023-11-14 12:00:00'),
    ('Projet 09','2023-11-14 12:00:00'),
    ('Projet 10','2023-11-14 12:00:00');
    
INSERT INTO take_part(idaccount, idproject)
VALUES 
	(1,1),
    (1,2),
    (1,3),
    (1,4),
    (1,5),
    (1,6),
    (1,7),
    (1,8),
    (1,9),
    (1,10),
    (2,1),
    (2,2),
    (2,3),
    (2,4),
    (2,5),
    (2,6),
    (2,7),
    (2,8),
    (3,1),
    (3,2),
    (3,3),
    (3,4),
    (3,5),
    (3,6),
    (4,1),
    (4,2),
    (4,3),
    (4,4),
    (5,1),
    (5,2);
    
INSERT INTO task(title_task, description_task, status_task, created_at_task, end_at_task, idaccount, idproject) 
VALUES 
	('P01 Ticket 01','Description P01T01',1,'2023-11-14 12:00:00','2023-11-20 12:00:00',1,1),
    ('P01 Ticket 02','Description P01T02',2,'2023-11-14 12:00:00','2023-11-20 12:00:00',2,1),
    ('P01 Ticket 03','Description P01T03',3,'2023-11-14 12:00:00','2023-11-20 12:00:00',3,1),
    ('P02 Ticket 01','Description P02T01',1,'2023-11-14 12:00:00','2023-11-20 12:00:00',1,2),
    ('P02 Ticket 02','Description P02T02',2,'2023-11-14 12:00:00','2023-11-20 12:00:00',2,2),
    ('P02 Ticket 03','Description P02T03',3,'2023-11-14 12:00:00','2023-11-20 12:00:00',3,2),
    ('P03 Ticket 01','Description P03T01',1,'2023-11-14 12:00:00','2023-11-20 12:00:00',1,3),
    ('P03 Ticket 02','Description P03T02',2,'2023-11-14 12:00:00','2023-11-20 12:00:00',2,3),
    ('P03 Ticket 03','Description P03T03',3,'2023-11-14 12:00:00','2023-11-20 12:00:00',3,3),
    ('P04 Ticket 01','Description P04T01',1,'2023-11-14 12:00:00','2023-11-20 12:00:00',1,4),
    ('P04 Ticket 02','Description P04T02',2,'2023-11-14 12:00:00','2023-11-20 12:00:00',2,4),
    ('P04 Ticket 03','Description P04T01',3,'2023-11-14 12:00:00','2023-11-20 12:00:00',3,4),
    ('P05 Ticket 01','Description P05T01',1,'2023-11-14 12:00:00','2023-11-20 12:00:00',1,5),
    ('P05 Ticket 02','Description P05T02',2,'2023-11-14 12:00:00','2023-11-20 12:00:00',2,5),
    ('P05 Ticket 03','Description P05T03',3,'2023-11-14 12:00:00','2023-11-20 12:00:00',3,5);
    
INSERT INTO action( title_action, is_completed, idtask)
VALUES
	('P01T01A01', false, 1),
    ('P01T01A02', false, 1),
	('P01T02A01', false, 2),
    ('P01T02A02', false, 2),
    ('P01T03A01', false, 3),
    ('P02T01A01', false, 4),
    ('P02T02A01', false, 5),
    ('P02T03A01', false, 6),
    ('P03T01A01', false, 7),
    ('P03T02A01', false, 8),
    ('P03T03A01', false, 9),
    ('P04T01A01', false, 10),
    ('P04T02A01', false, 11),
    ('P04T03A01', false, 12),
    ('P05T01A01', false, 13),
    ('P05T02A01', false, 14),
    ('P05T03A01', false, 15);