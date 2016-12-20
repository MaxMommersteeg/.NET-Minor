CREATE TABLE [dbo].[Product]
(
	[ProductNr] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [ProductPrice] DECIMAL(9, 2) NOT NULL
)
