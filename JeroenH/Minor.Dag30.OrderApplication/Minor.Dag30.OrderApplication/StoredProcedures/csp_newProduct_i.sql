CREATE PROCEDURE [dbo].[csp_newProduct_i]
	@ProductNr int,
	@ProductPrice decimal(9,2)
AS
	SELECT @ProductNr, @ProductPrice
RETURN 0
