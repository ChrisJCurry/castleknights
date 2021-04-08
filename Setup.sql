-- CREATE TABLE castles
-- (
--     id INT NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     year INT NOT NULL,
--     kingName VARCHAR(255),
--     size VARCHAR(255) NOT NULL,

--     PRIMARY KEY (id)
-- );
-- DROP TABLE knights;
CREATE TABLE knights
(
    id INT NOT NULL AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    title VARCHAR(255) NOT NULL,
    age INT NOT NULL,
    castleId INT NOT NULL,

    PRIMARY KEY (id),

    FOREIGN KEY (castleId)
        REFERENCES castles (id)
        ON DELETE CASCADE
);