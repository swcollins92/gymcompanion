
-- Switch to the system (aka master) database
USE master;
GO

-- Delete the DemoDB Database (IF EXISTS)
IF EXISTS(select * from sys.databases where name='Oscar_Workout')
DROP DATABASE Oscar_Workout;
GO

-- Create a new DemoDB Database
CREATE DATABASE Oscar_Workout;
GO

-- Switch to the DemoDB Database
USE Oscar_Workout
GO

BEGIN TRANSACTION;

CREATE TABLE users
(
	id			int			identity(1,1),
	username	varchar(50)	not null,
	password	varchar(50)	not null,
	salt		varchar(50)	not null,
	role		varchar(50)	default('user'),

	constraint pk_users primary key (id)
);

CREATE TABLE Member_Details
(
userId int not null,
memberId int not null identity(1, 1),
memberName varchar(50) not null,
email varchar(50) not null,
workoutGoals varchar(50) not null,
workoutProfile varchar(50) not null,
photoPath varchar(50),

constraint pk_member_details primary key (memberId)
--constraint fk_member_user_id foreign key (userId) references users(id)
);

CREATE TABLE Schedule 
(
id int not null identity (1, 1),
name varchar (50) not null,
description varchar(250),
date datetime not null,

constraint pk_schedule primary key (id)
);

CREATE TABLE Member_Timelog
(
id int not null identity (1, 1),
member_id int not null,
check_in datetime,
check_out datetime

constraint pk_member_timelog primary key (id)
)

CREATE TABLE gym_equipment
(
id int not null identity (1, 1),
name varchar (30) not null,
usage varchar (250) not null,
photo_path varchar (50)

constraint pk_gym_equipment primary key (id)
)

CREATE TABLE gym_equipment_usage
(
id int not null identity (1, 1),
equipment_id int not null,
member_id int not null,
date_time datetime not null,
reps int not null,
weight int

constraint pk_gym_equipment_usage primary key (id)

)


INSERT INTO users (username, password, salt, role) VALUES ('arash', 'x4dbae/fWb1u5kZ1z5hhaKiMf7Q=', 'veeN6byI+yk=', 'Admin');
INSERT INTO users (username, password, salt, role) VALUES ('employee', 'lX0fQyhm2Eo6bvZH+0VXlZoK9EA=', 'fZFs7Oy8/HY=', 'Employee');
INSERT INTO users (username, password, salt, role) VALUES ('gymmember', 'Q2dT0T1etr0mr++alO6dm7st+kE=', '9l0TC2Xp0Js=', 'Member');

INSERT INTO Member_Details (userId,[memberName],[email],[workoutGoals],[workoutProfile],[photoPath])
VALUES(2,'employee','employee@employee.com','Get RIPPED', 'Huge','batman');

INSERT INTO Member_Details (userId,[memberName],[email],[workoutGoals],[workoutProfile],[photoPath])
VALUES(3,'Lance Armstrong','lance@bikes.com','Get Faster', 'Fast','pikachu');
      
      
      
      
      



INSERT INTO Member_Timelog (member_id, check_in, check_out) VALUES (3,' 2020-04-13 12:06:44.757', '2020-04-13 13:06:44.757')
INSERT INTO Member_Timelog (member_id, check_in, check_out) VALUES (3,' 2020-04-12 12:00:44.757', '2020-04-12 13:06:44.757')
INSERT INTO Member_Timelog (member_id, check_in, check_out) VALUES (3,' 2020-04-11 11:30:44.757', '2020-04-11 13:06:44.757')

INSERT INTO gym_equipment (name, usage, photo_path) VALUES ('Treadmill', 'Keep your head up. If you are new to the treadmill, you may be tempted to look at your feet as you run.', 'treadmill');
INSERT INTO gym_equipment (name, usage, photo_path) VALUES ('Bench Press', 'Make sure you have a spotter with you, do slow easy reps.', 'benchpress');
INSERT INTO gym_equipment (name, usage, photo_path) VALUES ('Bicep Curl Machine', 'Start with lower weights and do slow easy reps.', 'bicep');
INSERT INTO gym_equipment (name, usage, photo_path) VALUES ('Squat Rack', 'Do not over do it! Make sure you squat with the heels of your feet. Practise form before you attempt this beast!', 'squatrack');
INSERT INTO gym_equipment_usage (equipment_id,member_id, date_time, reps, weight) VALUES (2,99 ,'2022-04-14 10:35:33.000', 200, 450);
COMMIT TRANSACTION;