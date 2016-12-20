CREATE PROCEDURE [dbo].[csp_newClient_i]
	@Name AS nvarchar(100),
	@Email AS nvarchar(230), 
	@Country AS nvarchar(60),
	@Address AS nvarchar(100),
	@ClientNr AS bigint OUTPUT
AS
	
	
	IF @Name IS NULL
		RETURN -1;
	IF @Email IS NULL
		RETURN -1;
	IF @Country IS NULL
		RETURN -1;	
	IF @Address IS NULL
		RETURN -1;
	IF @Email NOT LIKE '%_@__%.__%'
		RETURN -1;
	IF LEN(@Country) > 60
		RETURN -1; 		 

		--SCOPE_IDENTITY()
	SELECT @ClientNr = 1;	



		
	
RETURN 0
