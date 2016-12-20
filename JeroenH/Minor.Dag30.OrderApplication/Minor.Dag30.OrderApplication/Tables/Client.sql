CREATE TABLE [dbo].[Client]
(
	[ClientNr] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Email] NVARCHAR(230) NOT NULL, 
    [AddressNr] BIGINT NOT NULL, 
    CONSTRAINT [FK_Client_Address] FOREIGN KEY (AddressNr) REFERENCES [Address](AddressNr)
)

GO
