ALTER TABLE Users DROP CONSTRAINT PK__Users__3214EC074D8D2C8C

ALTER TABLE Users ADD CONSTRAINT PK_Id_Username PRIMARY KEY(Id, Username)