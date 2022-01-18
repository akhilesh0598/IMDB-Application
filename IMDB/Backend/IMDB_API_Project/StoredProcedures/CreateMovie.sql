CREATE PROCEDURE csp_CreateMovie 
	@Name NVARCHAR(MAX)
	,@YearOfRelease DATETIME
	,@Plot NVARCHAR(MAX)
	,@ProducerId INT
	,@ImageUrl NVARCHAR(MAX)
	,@ActorsIds NVARCHAR(MAX)
	,@GenresIds NVARCHAR(MAX)
AS
BEGIN
	INSERT INTO dbo.Movies (
		[Name]
		,[YearOfRelease]
		,[Plot]
		,[ProducerId]
		,[ImageUrl]
		)
	VALUES (
		@Name
		,@YearOfRelease
		,@Plot
		,@ProducerId
		,@ImageUrl
		);

	DECLARE @movieId INT

	SELECT @movieId = CAST(SCOPE_IDENTITY() AS INT);

	INSERT INTO ActorsMoviesMapping
	SELECT @movieId [MovieId]
		,VALUE [ActorId]
	FROM string_split(@ActorsIds, ',');

	INSERT INTO GenresMoviesMapping
	SELECT @movieId [MovieId]
		,VALUE [GenreId] 
	FROM string_split(@GenresIds, ',');

	SELECT @movieId;
END