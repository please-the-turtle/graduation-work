CREATE TABLE task_statuses(
    header varchar(25) PRIMARY KEY,
    description varchar(250)
);

CREATE TABLE task_priorities(
    header varchar(25) PRIMARY KEY,
    description varchar(250)
);

CREATE TABLE tasks(
    id int GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    status varchar(25) REFERENCES task_statuses(header) NOT NULL,
    priority varchar(25) REFERENCES task_priorities(header) NOT NULL,
    project int REFERENCES projects(id) ON DELETE CASCADE NOT NULL,
    parent int REFERENCES tasks(id) ON DELETE CASCADE,
    description varchar(250),
    lead_time interval NOT NULL,
    deadline timestamp 
);

CREATE TABLE projects(
    id int GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    name varchar(25),
    description varchar(250)
);

CREATE TABLE user_roles(
    header varchar(25) PRIMARY KEY,
    description varchar(250)
);

CREATE TABLE users(
    id int GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    login varchar(25) NOT NULL,
    password varchar(25) NOT NULL,
    position varchar(25),
    firstname varchar(25),
    lastname varchar(25), 
    date_of_birth timestamp,
    about_me varchar(250)
);

CREATE TABLE user_role_on_project(
    user_id int REFERENCES users(id) ON DELETE CASCADE,
    project int REFERENCES projects(id) ON DELETE CASCADE,
    role varchar(25) REFERENCES user_roles(header) NOT NULL,
    PRIMARY KEY(user_id, project) --user have only one role on the project
);
