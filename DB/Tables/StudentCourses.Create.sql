-- StudentCourses Table ========================
CREATE TABLE StudentCourses (
    Id uniqueidentifier PRIMARY KEY NONCLUSTERED,
    Student uniqueidentifier  NOT NULL,
    Course uniqueidentifier  NOT NULL
);

