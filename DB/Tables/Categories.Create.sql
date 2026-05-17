-- Categories Table ========================
CREATE TABLE Categories (
    Id uniqueidentifier PRIMARY KEY NONCLUSTERED,
    Name nvarchar(200)  NOT NULL,
    Description nvarchar(1000)  NULL,
    SortOrder int  NOT NULL,
    IsActive bit  NOT NULL,
    Parent uniqueidentifier  NULL
);

