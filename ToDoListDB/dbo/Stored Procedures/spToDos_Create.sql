CREATE PROCEDURE [dbo].[spToDos_Create]
	@ToDotext nvarchar(100),
	@IsComplete bit,
	@OwnerId nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[ToDos] (ToDoText, OwnerId, IsComplete)
	VALUES (@ToDoText, @OwnerId, @IsComplete);

END