ALTER TABLE Employees ADD Constraint
                [FK_Employee.Department]
                FOREIGN KEY (Department)
                REFERENCES Departments (ID)
                ON DELETE NO ACTION;
GO