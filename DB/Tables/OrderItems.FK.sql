ALTER TABLE OrderItems ADD Constraint
                [FK_OrderItem.Order]
                FOREIGN KEY ([Order])
                REFERENCES Orders (ID)
                ON DELETE NO ACTION;
GO
ALTER TABLE OrderItems ADD Constraint
                [FK_OrderItem.Product]
                FOREIGN KEY (Product)
                REFERENCES Products (ID)
                ON DELETE NO ACTION;
GO