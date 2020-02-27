CREATE PROCEDURE [dbo].[spToDos_UpdateCompletionStatus]
	@Id int,
	@IsComplete bit,
	@OwnerId nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[ToDos]
	SET IsComplete = @IsComplete
	WHERE Id = @Id AND OwnerId = @OwnerId;

END