CREATE PROCEDURE [dbo].[spToDos_ReadById]
	@OwnerId nvarchar(50),
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	ToDos.Id, 
			ToDos.ToDoText, 
			ToDos.IsComplete
	FROM	[dbo].[ToDos]
	WHERE	ToDos.OwnerId = @OwnerId AND Todos.Id = @Id;

END