CREATE TABLE [dbo].[Address]
(
	[AddressNr] BIGINT NOT NULL PRIMARY KEY, 
    [Country] NVARCHAR(60) NOT NULL, 
    [Address] NVARCHAR(100) NOT NULL
)
