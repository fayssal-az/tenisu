CREATE TABLE players (
    id INT PRIMARY KEY,
    firstname VARCHAR(50),
    lastname VARCHAR(50),
    shortname VARCHAR(10),
    sex CHAR(1),
    country_code VARCHAR(3),
    country_picture VARCHAR(255),
    picture VARCHAR(255),
    `rank` INT,
    points INT,
    weight INT,
    height INT,
    age INT
);

CREATE TABLE player_last_results (
    player_id INT,
    result_index INT,
    result INT,
    PRIMARY KEY (player_id, result_index),
    FOREIGN KEY (player_id) REFERENCES players(id)
);