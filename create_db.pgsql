CREATE TABLE task_status(
    header varchar(25) PRIMARY KEY,
    description varchar(250),
)

CREATE TABLE task_priority(
    header varchar(25) PRIMARY KEY,
    description varchar(250),
)

CREATE TABLE task_has_parent(
    task_id int REFERENCES task (id) PRIMARY KEY,
    child_id int REFERENCES task (id) PRIMARY KEY
)

CREATE TABLE task(
    id int PRIMARY KEY,
    status varchar(25) REFERENCES task_status (header) NOT NULL,
    priority varchar(25) REFERENCES task_priority (header) NOT NULL,a
    description varchar(250),
    lead_time interval NOT NULL,
    deadline timestamp 
)

CREATE TABLE user_status(
    header varchar(25) PRIMARY KEY,
    description varchar(250),
)

CREATE TABLE project(
    id int PRIMARY KEY,
    name varchar(25),
    description varchar(250),

);

