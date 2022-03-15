CREATE OR REPLACE PROCEDURE create_user(
    _login varchar(50),
    _password varchar(50),
    _position varchar(50),
    _firstname varchar(50),
    _lastname varchar(50), 
    _date_of_birth timestamp,
    _about_me varchar(500)
    )
    LANGUAGE SQL
    AS $body$
        INSERT INTO users(login,
                          password,
                          position,
                          firstname,
                          lastname,
                          date_of_birth,
                          about_me
                         )
        VALUES(_login,
               _password,
               _position,
               _firstname,
               _lastname,
               _date_of_birth,
               _about_me
              )

    $body$;

CREATE OR REPLACE PROCEDURE delete_user(_id int)
    LANGUAGE SQL
    AS $body$
    DELETE FROM users
    WHERE id = _id
    $body$;

CREATE OR REPLACE PROCEDURE update_user(
    _id int,
    _login varchar(50),
    _password varchar(50),
    _position varchar(50),
    _firstname varchar(50),
    _lastname varchar(50), 
    _date_of_birth timestamp,
    _about_me varchar(500)
    )
    LANGUAGE SQL
    AS $body$
        UPDATE users
        SET login = _login,
            password = _password,
            position = _position,
            firstname = _firstname,
            lastname = _lastname,
            date_of_birth = _date_of_birth,
            about_me = _about_me
        WHERE id = _id
    $body$;

CREATE OR REPLACE PROCEDURE get_user_by_id(_id int)
    LANGUAGE SQL
    AS $body$
        SELECT login,
               mail,
               password,
               position,
               firstname,
               lastname, 
               date_of_birth,
               about_me
        FROM users
        WHERE id = _id
    $body$;

CREATE OR REPLACE PROCEDURE get_user_by_login(_login varchar(50))
    LANGUAGE SQL
    AS $body$
        SELECT login,
               mail,
               password,
               position,
               firstname,
               lastname, 
               date_of_birth,
               about_me
        FROM users
        WHERE login = _login
    $body$;

CREATE OR REPLACE PROCEDURE get_user_by_mail(_mail email)
    LANGUAGE SQL
    AS $body$
        SELECT login,
               mail,
               password,
               position,
               firstname,
               lastname, 
               date_of_birth,
               about_me
        FROM users
        WHERE mail = _mail
    $body$;


