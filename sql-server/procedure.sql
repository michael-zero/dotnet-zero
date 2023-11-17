
INSERT INTO [Student] VALUES(NEWID(),'Michael Lesley','mlmb@gmail.com','1111','988167642','1998-06-05', GETDATE());

SELECT * FROM [Student];

CREATE OR ALTER PROCEDURE [spDeleteStudent] (
    @StudentId UNIQUEIDENTIFIER
)
AS
    BEGIN TRANSACTION
        DELETE FROM 
            [StudentCourse] 
        WHERE 
            [StudentId] = @StudentId

        DELETE FROM 
            [Student] 
        WHERE 
            [Id] = @StudentId
    COMMIT
GO