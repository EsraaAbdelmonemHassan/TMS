-- Departments Table ========================
CREATE TABLE Departments (
    Id uniqueidentifier PRIMARY KEY NONCLUSTERED,
    Name nvarchar(200)  NOT NULL,
    Description nvarchar(200)  NULL
);

