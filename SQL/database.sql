use MEI_DAN;

create table Status (
	Id int identity(1, 1) primary key,
	Descricao varchar(255) not null
)

create table Task (
	Id int identity(1, 1) primary key,
	Titulo varchar(100) not null,
	Descricao varchar(255) null,
	DataDeCriacao datetime default(getdate()),
	DataDeConclusao datetime null,
	StatusId int foreign key references Status(Id)
);

insert into Status (descricao) values ('Pendente'),('EmProgresso'),('Concluída')

select * from Task

select * from Status