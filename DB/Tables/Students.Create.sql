-- Students Table ========================
CREATE TABLE Students (
    Id uniqueidentifier PRIMARY KEY NONCLUSTERED,
    FirstName nvarchar(100)  NOT NULL,
    LastName nvarchar(100)  NOT NULL
);

