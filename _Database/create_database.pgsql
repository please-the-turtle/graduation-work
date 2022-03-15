CREATE EXTENSION citext;
CREATE DOMAIN email AS citext
    CHECK ( value ~ '^[a-zA-Z0-9.!#$%&''*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$' );

CREATE TABLE task_statuses(
    header varchar(50) PRIMARY KEY,
    description varchar(500)
);

CREATE TABLE task_priorities(
    header varchar(50) PRIMARY KEY,
    description varchar(500)
);

CREATE TABLE projects(
    id int GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    name varchar(50),
    description varchar(500)
);

CREATE TABLE tasks(
    id int GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    status varchar(50) REFERENCES task_statuses(header) NOT NULL,
    priority varchar(50) REFERENCES task_priorities(header) NOT NULL,
    project int REFERENCES projects(id) ON DELETE CASCADE NOT NULL,
    parent int REFERENCES tasks(id) ON DELETE CASCADE,
    description varchar(500),
    lead_time interval NOT NULL,
    deadline timestamp 
);

CREATE TABLE user_roles(
    header varchar(50) PRIMARY KEY,
    description varchar(500)
);

CREATE TABLE users(
    id int GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    mail email NOT NULL UNIQUE ,
    login varchar(50) NOT NULL,
    password varchar(50) NOT NULL,
    position varchar(50),
    firstname varchar(50),
    lastname varchar(50), 
    date_of_birth timestamp,
    about_me varchar(500)
);

CREATE TABLE user_role_on_project(
    user_id int REFERENCES users(id) ON DELETE CASCADE,
    project int REFERENCES projects(id) ON DELETE CASCADE,
    role varchar(50) REFERENCES user_roles(header) NOT NULL,
    PRIMARY KEY(user_id, project) --user have only one role on the project
);
