CREATE TABLE share(
    id serial primary key,
    fantasy_name varchar(200) not null,
    value money not null,
    application_date timestamp not null,
    withdraw_date timestamp
);