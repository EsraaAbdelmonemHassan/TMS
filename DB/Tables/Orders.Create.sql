-- Orders Table ========================
CREATE TABLE Orders (
    Id uniqueidentifier PRIMARY KEY NONCLUSTERED,
    OrderDate datetime2  NOT NULL,
    Customer uniqueidentifier  NOT NULL,
    TotalAmount numeric(27, 2)  NOT NULL,
    IsApproved bit  NOT NULL,
    Status nvarchar(50)  NULL,
    StartDate datetime2  NULL,
    EndDate datetime2  NULL
);

