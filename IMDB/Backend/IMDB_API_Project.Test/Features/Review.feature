 Feature: Review Resource

Scenario: Get Review All
	Given I am a client
	When I make GET Request '/api/movies/<movieId>/reviews'
	Then Response code must be '<statusCode>'
	And Response data must look like '<responseData>'
	Examples: 
	| movieId | statusCode | responseData                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |
	| 1       | 200        | [{"id":1,"message":"R1","movie":{"id":1,"name":"M1","yearOfRelease":"0001-01-01T00:00:00","plot":null,"producer":{"id":1,"name":"P1","bio":null,"dob":"0001-01-01T00:00:00","gender":null},"actors":[{"id":1,"name":"A1","bio":null,"dob":"0001-01-01T00:00:00","gender":null},{"id":2,"name":"A2","bio":null,"dob":"0001-01-01T00:00:00","gender":null}],"genres":[{"id":1,"name":"G1"},{"id":2,"name":"G2"}],"imageUrl":null}},{"id":2,"message":"R2","movie":{"id":1,"name":"M1","yearOfRelease":"0001-01-01T00:00:00","plot":null,"producer":{"id":1,"name":"P1","bio":null,"dob":"0001-01-01T00:00:00","gender":null},"actors":[{"id":1,"name":"A1","bio":null,"dob":"0001-01-01T00:00:00","gender":null},{"id":2,"name":"A2","bio":null,"dob":"0001-01-01T00:00:00","gender":null}],"genres":[{"id":1,"name":"G1"},{"id":2,"name":"G2"}],"imageUrl":null}}] |
	| 100     | 404        | {"message":"Movie Id '100' not found"}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            | 

Scenario: Get Review By Id
	Given I am a client
	When I make GET Request '/api/movies/<movieId>/reviews/<reviewId>'
	Then Response code must be '<statusCode>'
	And Response data must look like '<responseData>'
	Examples: 
	| movieId | reviewId | statusCode | responseData                                                                                                                                                                                                                                                                                                                                                                                                                    |
	| 1       | 1        | 200        | {"id":1,"message":"R1","movie":{"id":1,"name":"M1","yearOfRelease":"0001-01-01T00:00:00","plot":null,"producer":{"id":1,"name":"P1","bio":null,"dob":"0001-01-01T00:00:00","gender":null},"actors":[{"id":1,"name":"A1","bio":null,"dob":"0001-01-01T00:00:00","gender":null},{"id":2,"name":"A2","bio":null,"dob":"0001-01-01T00:00:00","gender":null}],"genres":[{"id":1,"name":"G1"},{"id":2,"name":"G2"}],"imageUrl":null}} |
	| 1       | 100      | 404        | {"message":"Review Id '100' not found for Movie Id '1'"}                                                                                                                                                                                                                                                                                                                                                                        |
	| 100     | 100      | 404        | {"message":"Movie Id '100' not found"}                                                                                                                                                                                                                                                                                                                                                                                          |                                                                     

Scenario: Post a Review
	Given I am a client
	When I make POST Request to '/api/movies/<movieId>/reviews' with the following Data '<requestData>'
	Then Response code must be '<statusCode>'
	And Response data must look like '<responseData>'
	Examples: 
	| movieId | requestData                    | statusCode | responseData                                                            |
	| 1       | {"message":"R1","movieid":1}   | 201        | 1                                                                       |
	| 1       | {"message":"R1","movieid":100} | 400        | {"message":"Route Movie Id '1' and body Movie Id '100' should be same"} |
	| 100     | {"message":"R1","movieid":100} | 404        | {"message":"Movie Id '100' not found"}                                  |

Scenario: Put a Review
	Given I am a client
	When I make PUT Request '/api/movies/<movieId>/reviews/<reviewId>' with the following Data '<requestData>'
	Then Response code must be '<statusCode>'
	And Response data must look like '<responseData>'
	Examples: 
	| movieId | reviewId | requestData                    | statusCode | responseData                                                            |
	| 1       | 1        | {"message":"R1","movieid":1}   | 200        | Updated Successfully                                                    |
	| 1       | 1        | {"message":"R1","movieid":100} | 400        | {"message":"Route Movie Id '1' and body Movie Id '100' should be same"} |
	| 1       | 100      | {"message":"R1","movieid":100} | 404        | {"message":"Review Id '100' not found for Movie Id '1'"}                |
	| 100     | 100      | {"message":"R1","movieid":100} | 404        | {"message":"Movie Id '100' not found"}                                  |         

Scenario: Delete a Reviw
	Given I am a client
	When I make DELETE Request '/api/movies/<movieId>/reviews/<reviewId>'
	Then Response code must be '<statusCode>'
	And Response data must look like '<responseData>'
	Examples: 
	| movieId | reviewId | statusCode | responseData                                             |
	| 1       | 1        | 200        | Deleted Successfully                                     |
	| 1       | 100      | 404        | {"message":"Review Id '100' not found for Movie Id '1'"} |
	| 100     | 100      | 404        | {"message":"Movie Id '100' not found"}                   |
