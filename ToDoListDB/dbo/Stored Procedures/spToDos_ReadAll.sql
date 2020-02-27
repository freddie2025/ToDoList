CREATE PROCEDURE [dbo].[spToDos_ReadAll]
	@OwnerId NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	[ToDos].[Id], 
			[ToDos].[ToDoText], 
			[ToDos].[IsComplete]
	FROM	[dbo].[ToDos]
	WHERE	[ToDos].[OwnerId] = @OwnerId;

END