-- Employees Table ========================
CREATE TABLE Employees (
    Id uniqueidentifier PRIMARY KEY NONCLUSTERED,
    FirstName nvarchar(100)  NOT NULL,
    LastName nvarchar(100)  NOT NULL,
    Email nvarchar(250)  NOT NULL,
    PhoneNumber nvarchar(50)  NULL,
    CreatedDate datetime2  NOT NULL,
    EmployeeNumber nvarchar(50)  NOT NULL,
    [Position] nvarchar(100)  NULL,
    Department uniqueidentifier  NOT NULL
);

