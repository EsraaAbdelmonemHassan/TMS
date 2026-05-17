-- Products Table ========================
CREATE TABLE Products (
    Id uniqueidentifier PRIMARY KEY NONCLUSTERED,
    Name nvarchar(250)  NOT NULL,
    Code nvarchar(50)  NOT NULL,
    Description nvarchar(MAX)  NULL,
    Price numeric(27, 2)  NOT NULL,
    Quantity int  NOT NULL,
    IsActive bit  NOT NULL,
    CreatedDate datetime2  NOT NULL,
    AvailableFrom datetime2  NULL,
    AvailableTo datetime2  NULL,
    Image nvarchar(500)  NULL,
    Manual nvarchar(500)  NULL,
    Category uniqueidentifier  NOT NULL
);

