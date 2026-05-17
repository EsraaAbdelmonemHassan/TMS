-- OrderItems Table ========================
CREATE TABLE OrderItems (
    Id uniqueidentifier PRIMARY KEY NONCLUSTERED,
    [Order] uniqueidentifier  NOT NULL,
    Product uniqueidentifier  NOT NULL,
    Quantity int  NOT NULL,
    UnitPrice numeric(27, 2)  NOT NULL
);

