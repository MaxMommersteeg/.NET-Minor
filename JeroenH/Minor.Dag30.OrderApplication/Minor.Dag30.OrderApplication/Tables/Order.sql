CREATE TABLE [dbo].[Order]
(
	[OrderNr] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [ClientNr] BIGINT NOT NULL, 
    [OrderDate] DATETIME2(0) NOT NULL, 
    [BillingAddress] BIGINT NOT NULL, 
    [ShippingAddress] BIGINT NOT NULL, 
    CONSTRAINT FK_Order_Client FOREIGN KEY (ClientNr) REFERENCES Client(ClientNr), 
    CONSTRAINT [FK_Order_Address] FOREIGN KEY ([BillingAddress]) REFERENCES [Address](AddressNr), 
)
