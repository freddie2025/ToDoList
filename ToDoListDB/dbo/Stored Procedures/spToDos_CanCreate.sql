CREATE PROCEDURE [dbo].[spToDos_CanCreate]
	@UserId nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	Users.PermittedToDoCount, 
			(
				SELECT	COUNT(1) 
				FROM	[dbo].[ToDos] 
				WHERE	ToDos.OwnerID = @UserId
			) 
			AS TotalToDos
	FROM	[dbo].[Users]
	WHERE	Users.UserId = @UserId

END 