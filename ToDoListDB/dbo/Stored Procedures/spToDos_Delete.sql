CREATE PROCEDURE [dbo].[spToDos_Delete]
	@Id int,
	@OwnerId nvarchar(50)
AS
BEGIN 
	SET NOCOUNT ON;

	DELETE [dbo].[ToDos]
	WHERE Id = @Id AND OwnerId = @OwnerId;

END
