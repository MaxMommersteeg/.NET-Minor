CREATE TABLE [dbo].[OrderItem]
(
	[OrderItemNr] BIGINT NOT NULL PRIMARY KEY, 
    [OrderNr] BIGINT NOT NULL, 
    [ProductNr] BIGINT NOT NULL, 
    [NumberOfUnits] INT NOT NULL, 
    CONSTRAINT [FK_OrderItem_Order] FOREIGN KEY (OrderNr) REFERENCES [Order](OrderNr), 
    CONSTRAINT [FK_OrderItem_Product] FOREIGN KEY (ProductNr) REFERENCES [Product](ProductNr)
)
