CREATE PROCEDURE [dbo].[spUsers_Update]
	@Id int,
	@PermittedToDoCount int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Users]
	SET PermittedToDoCount = @PermittedToDoCount
	WHERE Id = @Id;

END