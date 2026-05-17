ALTER TABLE Products ADD Constraint
                [FK_Product.Category]
                FOREIGN KEY (Category)
                REFERENCES Categories (ID)
                ON DELETE NO ACTION;
GO