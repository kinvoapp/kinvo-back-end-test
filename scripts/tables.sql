-- Create table client
CREATE TABLE public.client (
	id int4 NOT NULL GENERATED ALWAYS AS IDENTITY,
	fantasy_name varchar(30) NOT NULL,
	"document" varchar NOT NULL,
	CONSTRAINT client_pkey PRIMARY KEY (id)
);

-- Create table application
CREATE TABLE public.application (
	id int4 NOT NULL GENERATED ALWAYS AS IDENTITY,
	application_date date NOT NULL,
	application_value money NOT NULL,
	withdraw_date date NULL,
	withdraw_value money NULL,
	is_active bool NOT NULL,
	client_id int4 NOT NULL
);

-- public.application foreign keys

ALTER TABLE public.application ADD CONSTRAINT client_id FOREIGN KEY (client_id) REFERENCES public.client(id);