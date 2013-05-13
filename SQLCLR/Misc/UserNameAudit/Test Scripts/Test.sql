CREATE TABLE Users
(
    UserName    NVARCHAR(200)    NOT NULL,
    Pass    NVARCHAR(200)    NOT NULL
)

CREATE TABLE UsersAudit
(
    UserName    NVARCHAR(200)    NOT NULL
)

select * from Users
select * from UsersAudit

--delete from Users

-- Insert one user name that is not an e-mail address and one that is
INSERT INTO Users(UserName, Pass) VALUES(N'someone', N'cnffjbeq')
INSERT INTO Users(UserName, Pass) VALUES(N'someone@example.com', N'cnffjbeq')

select * from Users
select * from UsersAudit




