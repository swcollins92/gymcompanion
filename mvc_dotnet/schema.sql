
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

COMMIT TRANSACTION;