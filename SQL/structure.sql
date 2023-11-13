CREATE DATABASE simpl_AgileProj;
USE simpl_AgileProj;

CREATE TABLE accounts(
   id_account INT AUTO_INCREMENT,
   username VARCHAR(50)  NOT NULL,
   password VARCHAR(100)  NOT NULL,
   PRIMARY KEY(id_account)
);

CREATE TABLE projects(
   id_project INT AUTO_INCREMENT,
   name_project VARCHAR(100)  NOT NULL,
   created_at_project DATETIME NOT NULL,
   PRIMARY KEY(id_project)
);

CREATE TABLE tasks(
   id_task INT AUTO_INCREMENT,
   title_task VARCHAR(100)  NOT NULL,
   description_task TEXT NOT NULL,
   status_task TINYINT NOT NULL,
   created_at_task DATETIME NOT NULL,
   end_at_task DATETIME NOT NULL,
   id_account INT,
   id_project INT,
   PRIMARY KEY(id_task),
   FOREIGN KEY(id_account) REFERENCES accounts(id_account),
   FOREIGN KEY(id_project) REFERENCES projects(id_project)
);

CREATE TABLE actions(
   id_action INT AUTO_INCREMENT,
   title_action VARCHAR(100)  NOT NULL,
   is_completed BOOLEAN,
   id_task INT,
   PRIMARY KEY(id_action),
   FOREIGN KEY(id_task) REFERENCES tasks(id_task)
);

CREATE TABLE take_part(
   id_account INT,
   id_project INT,
   PRIMARY KEY(id_account, id_project),
   FOREIGN KEY(id_account) REFERENCES accounts(id_account),
   FOREIGN KEY(id_project) REFERENCES projects(id_project)
);