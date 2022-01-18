 Feature: Movie Resource

Scenario: Get Movie All
	Given I am a client
	When I make GET Request '/api/movies'
	Then Response code must be '200'
	And Response data must look like '[{"id":1,"name":"M1","yearOfRelease":"0001-01-01T00:00:00","plot":null,"producer":{"id":1,"name":"P1","bio":null,"dob":"0001-01-01T00:00:00","gender":null},"actors":[{"id":1,"name":"A1","bio":null,"dob":"0001-01-01T00:00:00","gender":null},{"id":2,"name":"A2","bio":null,"dob":"0001-01-01T00:00:00","gender":null}],"genres":[{"id":1,"name":"G1"},{"id":2,"name":"G2"}],"imageUrl":null},{"id":2,"name":"M2","yearOfRelease":"0001-01-01T00:00:00","plot":null,"producer":{"id":1,"name":"P1","bio":null,"dob":"0001-01-01T00:00:00","gender":null},"actors":[{"id":1,"name":"A1","bio":null,"dob":"0001-01-01T00:00:00","gender":null}],"genres":[{"id":1,"name":"G1"}],"imageUrl":null}]'

Scenario: Get Movie By Id
	Given I am a client
	When I make GET Request '/api/movies/<movieId>'
	Then Response code must be '<statusCode>'
	And Response data must look like '<responseData>'
	Examples: 
	| movieId | statusCode | responseData                                                                                                                                                                                                                                                                                                                                                                                    |
	| 1       | 200        | {"id":1,"name":"M1","yearOfRelease":"0001-01-01T00:00:00","plot":null,"producer":{"id":1,"name":"P1","bio":null,"dob":"0001-01-01T00:00:00","gender":null},"actors":[{"id":1,"name":"A1","bio":null,"dob":"0001-01-01T00:00:00","gender":null},{"id":2,"name":"A2","bio":null,"dob":"0001-01-01T00:00:00","gender":null}],"genres":[{"id":1,"name":"G1"},{"id":2,"name":"G2"}],"imageUrl":null} |
	| 100     | 404        | {"message":"Movie Id '100' not found"}                                                                                                                                                                                                                                                                                                                                                          |                                                                      

	Scenario: Post a Movie
	Given I am a client
	When I make POST Request to '/api/movies' with the following Data '<requestData>'
	Then Response code must be '<statusCode>'
	And Response data must look like '<responseData>'
	Examples: 
	| requestData                                                                                                                                           | statusCode | responseData                                      |
	| {"name":"M1","yearOfRelease":"2000-03-07T00:00:00","plot":"abc","producerId":1,"actorsIds":[1],"genresIds":[1],"imageUrl":"img1"}         | 201        | 1                                                 |
	| {"name":"M1","yearOfRelease":"2000-03-07T00:00:00","plot":"abc","producerId":100,"actorsIds":[1],"genresIds":[1],"imageUrl":"img1"}       | 400        | {"message":"Producer Id '100' not found"}         |
	| {"name":"M1","yearOfRelease":"2000-03-07T00:00:00","plot":"abc","producerId":1,"actorsIds":[1,100,200],"genresIds":[1],"imageUrl":"img1"} | 400        | {"message":"These Actors Id '100,200' not found"} |
	| {"name":"M1","yearOfRelease":"2000-03-07T00:00:00","plot":"abc","producerId":1,"actorsIds":[1],"genresIds":[1,100,200],"imageUrl":"img1"} | 400        | {"message":"These Genres Id '100,200' not found"} |

Scenario: Put a Movie
	Given I am a client
	When I make PUT Request '/api/movies/<movieId>' with the following Data '<requestData>'
	Then Response code must be '<statusCode>'
	And Response data must look like '<responseData>'
	Examples: 
	| movieId | requestData                                                                                                                                           | statusCode | responseData                                      |
	| 1       | {"name":"M1","yearOfRelease":"2000-03-07T00:00:00","plot":"abc","producerId":1,"actorsIds":[1],"genresIds":[1],"imageUrl":"img1"}         | 200        | Updated Successfully                              |
	| 1       | {"name":"M1","yearOfRelease":"2000-03-07T00:00:00","plot":"abc","producerId":100,"actorsIds":[1],"genresIds":[1],"imageUrl":"img1"}       | 400        | {"message":"Producer Id '100' not found"}         |
	| 1       | {"name":"M1","yearOfRelease":"2000-03-07T00:00:00","plot":"abc","producerId":1,"actorsIds":[1,100,200],"genresIds":[1],"imageUrl":"img1"} | 400        | {"message":"These Actors Id '100,200' not found"} |
	| 1       | {"name":"M1","yearOfRelease":"2000-03-07T00:00:00","plot":"abc","producerId":1,"actorsIds":[1],"genresIds":[1,100,200],"imageUrl":"img1"} | 400        | {"message":"These Genres Id '100,200' not found"} |
	| 100     | {"name":"M1","yearOfRelease":"2000-03-07T00:00:00","plot":"abc","producerId":1,"actorsIds":[1],"genresIds":[1],"imageUrl":"img1"}         | 404        | {"message":"Movie Id '100' not found"}            |        

Scenario: Delete a Movie
	Given I am a client
	When I make DELETE Request '/api/movies/<movieId>'
	Then Response code must be '<statusCode>'
	And Response data must look like '<responseData>'
	Examples: 
	| movieId | statusCode | responseData                           |
	| 1       | 200        | Deleted Successfully                   |
	| 100     | 404        | {"message":"Movie Id '100' not found"} |
