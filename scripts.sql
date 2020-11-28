CREATE TABLE user_pub_evaluation (
	id serial not null primary key,
	user_id serial not null,
	pub_id serial not null,
	evaluation numeric (2, 1) not null, 
	foreign key (user_id) references application_user (id),
	foreign key (user_id) references application_user (id)
);

CREATE TABLE application_user (
	id serial not null primary key,
	user_name varchar not null unique,
	"password" varchar not null,
	email varchar not null,
	address varchar not null,
	is_admin bool not null
);

CREATE TABLE application_pub (
	id serial not null primary key,
	"name" varchar not null,
	address varchar not null,
	description varchar not null,
	contact varchar not null,
	evaluation numeric not null
);
