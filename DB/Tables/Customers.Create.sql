-- Customers Table ========================
CREATE TABLE Customers (
    Id uniqueidentifier PRIMARY KEY NONCLUSTERED,
    FirstName nvarchar(100)  NOT NULL,
    LastName nvarchar(100)  NOT NULL,
    Email nvarchar(250)  NOT NULL,
    PhoneNumber nvarchar(50)  NULL,
    CreatedDate datetime2  NOT NULL,
    CustomerCode nvarchar(50)  NOT NULL,
    CreditLimit numeric(27, 2)  NOT NULL
);

