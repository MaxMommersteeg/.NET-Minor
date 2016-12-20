/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

USE [Minor.Dag30.OrderApplicatie]
GO

ALTER DATABASE [Minor.Dag30.OrderApplicatie]                 
      MODIFY FILE ( NAME = N'Minor.Dag30.OrderApplicatie_log' 
                  , SIZE = 100MB 
				  , FILEGROWTH = 100MB
				  , MAXSIZE = UNLIMITED);
GO
ALTER DATABASE [Minor.Dag30.OrderApplicatie]                 
      MODIFY FILE ( NAME = N'Minor.Dag30.OrderApplicatie'  
                  , SIZE = 100MB 
				  , FILEGROWTH = 100MB);
GO
