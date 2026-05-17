-- ApplicationEventLogs Table ========================
CREATE TABLE ApplicationEventLogs (
    Id uniqueidentifier PRIMARY KEY NONCLUSTERED,
    [Timestamp] datetime2  NOT NULL,
    UserName nvarchar(250)  NULL,
    EventType nvarchar(100)  NOT NULL,
    Description nvarchar(2000)  NULL,
    EntityName nvarchar(200)  NULL,
    EntityId uniqueidentifier  NULL
);

