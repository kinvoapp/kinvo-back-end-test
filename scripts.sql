create table client(
	client_cpf varchar(200) unique not null,
	id serial primary key
);

CREATE TABLE application (
	id serial primary key,
	client_id serial not null,
	application_value money not null check (application_value > money '0'),
	withdraw_value money,
	application_date timestamp not null,
	withdraw_date timestamp,	
	foreign key (client_id) references client (id)
);