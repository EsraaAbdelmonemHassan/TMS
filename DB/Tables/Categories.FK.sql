ALTER TABLE Categories ADD Constraint
                [FK_Category.Parent->Category]
                FOREIGN KEY (Parent)
                REFERENCES Categories (ID)
                ON DELETE NO ACTION;
GO