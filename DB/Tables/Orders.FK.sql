ALTER TABLE Orders ADD Constraint
                [FK_Order.Customer]
                FOREIGN KEY (Customer)
                REFERENCES Customers (ID)
                ON DELETE NO ACTION;
GO