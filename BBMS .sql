


create database BloodBank
go

use BloodBank
go




/*         table BloodGroup             */

	create  table BloodGroup
	(
		BG_ID int primary key  ,
		BloodGroup_Name varchar(15) not null

	)
	go
	--DROP TABLE BloodGroup; 

select BG_ID, BloodGroup_Name from  BloodGroup
go
 
 insert into BloodGroup values
 
 ('A+')

 go

  insert into BloodGroup values
 (3, 'A-'),
 (4, 'B-'),
 (5, 'AB+'),
 (6, 'AB-'),
 (7, 'O+'),
 (8, 'O-')

 go




 /*         table Donor            */


	create table Donor
	(
		ID int primary key ,
		Name varchar(30) not null,
		Gender nvarchar(30) null,
		Age int  not null ,
		BG_ID int references  BloodGroup (BG_ID),
		Unit_ml char(10)   null,
		Date date not null,
		Address varchar(35) not null,
		ContactNo varchar (20) not null,
		Email varchar(30)   null,
		Photo varbinary(max) NULL	,
		
	)
		
		
	go

	SELECT * FROM Donor
	GO

	--DROP TABLE Donor; 
	select*from Donor
		 go

		-- select  D.D_Name,D.D_Gender,D.D_age,B.Blood_Group_Name,D.D_Unit_ml,D.D_Date,
		-- D.D_address,D.D_contactNo,D.D_Email,D.D_photo  from Donor D
		--inner join BloodGroup B on D.Blood_ID=B.Blood_ID

		--UPDATE Donor SET D_ID,D_Name,D_Gender, D_age,Blood_ID,D_Unit_ml,D_Date,D_Address,D_contactNo,D_Email,D_photo WHERE D_ID=1


		 go


		 insert into Donor values
		('Asha','female',30,20,'2020-05-15','Dhaka',0122322323,'Asha@gmail.com',1,1)

		go




		/*         table Recipient             */

	create table  Recipient
	(
		ID int  primary key ,
		Name varchar(30) not null,
		Gender nvarchar(30) null,
		age int not null,
		BG_ID int references  BloodGroup (BG_ID),
		Unit_ml nvarchar(10)   null,
		Date date NOT NULL ,
		Address varchar(100) not null,
		ContactNo varchar(15) not null,
		Email varchar(30)   null,
		Photo VARBINARY(MAX) NULL,
	
	)
	go
		--DROP TABLE Recipient; 

		select*from Recipient
		 go

	



		-- select  R.R_Name,R.R_Gender,R.R_age,B.Blood_Group_Name,R.R_Unit_ml,R.R_Date,
		-- R.R_address,R.R_contactNo,R.R_Email,R.R_photo  from Recipient R
		--inner join BloodGroup B on R.Blood_ID=B.Blood_ID


	insert into Recipient  values
	('Asifa','female',30,20,'2020-05-15','Savar',0122322323,'Asifa@gmail.com',1,1),
		('Asia','female',30,20,'2020-05-15','Savar',0122322323,'Asifa@gmail.com',1,1)

		go


	

		create table BloodStock
		(
			S_ID int primary key ,
			Unit_ml nvarchar(100)   null,
			Stock nvarchar(6) null,
			BG_ID int references  BloodGroup (BG_ID),

		)

		go

		select* from BloodStock
		go


		select s.S_ID as ID,b.BloodGroup_Name,s.Unit_ml  as Total_unit ,s.Stock  from BloodStock s
		inner join BloodGroup b on s.S_ID=b.BG_ID order by s.BG_ID
		--go
 
  

		insert into BloodStock values
		(1,20,'yes',1)
		go



	--create table  BloodDetails
		
	--	(

	--	B_ID int primary key ,
	--	N_Donor  int NULL,
	--	N_Recipient int  NULL,
	--	Blood_ID int references  BloodGroup (Blood_ID),
	--	BloodStock int references  BloodStock (Stock_ID)

	--	)
		
		
	--	 select * from BloodDetails
	--	 go

		 
	--insert into BloodDetails  values
	--(2,10,20,15)
	

		
	--	select  gr.Blood_Group_Name as BG_Name,st.T_Unit_ml as Unit_ml , be.N_Donor,be.N_Recipient from BloodDetails be  

	--	inner join BloodGroup gr on  gr.Blood_ID=be.Blood_ID
	--	inner join BloodStock st on  be.B_ID=st.Blood_ID
	--	go


