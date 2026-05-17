-- Courses Table ========================
CREATE TABLE Courses (
    Id uniqueidentifier PRIMARY KEY NONCLUSTERED,
    Name nvarchar(200)  NOT NULL,
    Code nvarchar(50)  NOT NULL
);

