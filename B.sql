CREATE PROCEDURE `restoreTableBD` ()
LANGUAGE SQL
DETERMINISTIC
SQL SECURITY DEFINER
BEGIN
START TRANSACTION;
DROP TABLE IF EXISTS coin;
CREATE TABLE IF NOT EXISTS coin
SELECT * FROM coin;
COMMIT;
END
