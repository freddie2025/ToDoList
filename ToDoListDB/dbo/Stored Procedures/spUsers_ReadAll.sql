CREATE PROCEDURE [dbo].[spUsers_ReadAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	Users.Id, 
			Users.UserId, 
			Users.UserEmail,
			Users.PermittedToDoCount
	FROM	[dbo].[Users];

END