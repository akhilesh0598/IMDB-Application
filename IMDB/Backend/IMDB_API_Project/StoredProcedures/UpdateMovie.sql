CREATE PROCEDURE usp_UpdateMovie 
	@MovieId INT
	,@Name NVARCHAR(MAX)
	,@YearOfRelease DATETIME
	,@Plot VARCHAR(MAX)
	,@ProducerId INT
	,@ImageUrl VARCHAR(MAX)
	,@ActorsIds VARCHAR(MAX)
	,@GenresIds VARCHAR(MAX)
AS
BEGIN
	UPDATE [dbo].Movies
	SET [Name] = @Name
		,[YearOfRelease] = @YearOfRelease
		,[Plot] = @Plot
		,[ProducerId] = @ProducerId
		,[ImageUrl] = @ImageUrl
	WHERE [Id] = @MovieId;

	DELETE
	FROM ActorsMoviesMapping
	WHERE [MovieId] = @MovieId;

	DELETE
	FROM GenresMoviesMapping
	WHERE [MovieId] = @MovieId;

	INSERT INTO ActorsMoviesMapping
	SELECT @movieId [MovieId]
		,VALUE [ActorId]
	FROM string_split(@ActorsIds, ',');

	INSERT INTO GenresMoviesMapping
	SELECT @movieId [MovieId]
		,VALUE [GenreId]
	FROM string_split(@GenresIds, ',');
END