CREATE TYPE ProductWithQuantity AS TABLE (ProductNr bigint, NumberOfUnits int)
GO
CREATE PROCEDURE [dbo].[csp_newOrder_i] (
	@ProductList ProductWithQuantity READONLY,
	@ClientNr bigint,
	@BillingAddressNr bigint,
	@ShippingAddressNr bigint
	)

AS
	SELECT @ProductList, @ClientNr,@BillingAddressNr,@ShippingAddressNr
RETURN 0
