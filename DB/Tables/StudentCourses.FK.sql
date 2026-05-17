ALTER TABLE StudentCourses ADD Constraint
                [FK_StudentCourse.Student]
                FOREIGN KEY (Student)
                REFERENCES Students (ID)
                ON DELETE NO ACTION;
GO
ALTER TABLE StudentCourses ADD Constraint
                [FK_StudentCourse.Course]
                FOREIGN KEY (Course)
                REFERENCES Courses (ID)
                ON DELETE NO ACTION;
GO