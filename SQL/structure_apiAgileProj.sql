CREATE DATABASE simpl_AgileProj;
USE simpl_AgileProj;

CREATE TABLE account(
   id INT AUTO_INCREMENT primary key not null,
   username VARCHAR(50)  NOT NULL,
   password VARCHAR(100)  NOT NULL
)engine=InnoDB;

CREATE TABLE project(
   id INT AUTO_INCREMENT primary key not null,
   name_project VARCHAR(100)  NOT NULL,
   created_at_project DATETIME NOT NULL
)engine=InnoDB;

CREATE TABLE task(
   id INT AUTO_INCREMENT primary key not null,
   title_task VARCHAR(100)  NOT NULL,
   description_task TEXT NOT NULL,
   status_task TINYINT NOT NULL,
   created_at_task DATETIME NOT NULL,
   end_at_task DATETIME NOT NULL,
   idaccount INT NOT NULL,
   idproject INT NOT NULL
)engine=InnoDB;

CREATE TABLE action(
   id INT AUTO_INCREMENT primary key not null,
   title_action VARCHAR(100)  NOT NULL,
   is_completed BOOLEAN,
   idtask INT NOT NULL
)engine=InnoDB;

CREATE TABLE take_part(
   idaccount INT NOT NULL,
   idproject INT NOT NULL
)engine=InnoDB;

alter table task
add constraint fk_beResponsible_account
foreign key(idaccount)
REFERENCES account(id);

alter table task
add constraint fk_possess_project
FOREIGN KEY(idproject)
REFERENCES project(id);

alter table action
add constraint fk_have_tasks
FOREIGN KEY(idtask)
REFERENCES task(id);

alter table take_part
add constraint fk_takepart_account
FOREIGN KEY(idaccount) 
REFERENCES account(id);

alter table take_part
add constraint fk_takepart_projects
FOREIGN KEY(idproject) 
REFERENCES project(id);
