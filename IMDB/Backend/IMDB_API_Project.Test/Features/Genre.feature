 Feature: Genre Resource

Scenario: Get Genre All
	Given I am a client
	When I make GET Request '/api/genres'
	Then Response code must be '200'
	And Response data must look like '[{"id":1,"name":"G1"},{"id":2,"name":"G2"}]'

Scenario: Get Genre By Id
	Given I am a client
	When I make GET Request '/api/genres/<genreId>'
	Then Response code must be '<statusCode>'
	And Response data must look like '<responseData>'
	Examples: 
	| genreId | statusCode | responseData                           |
	| 1       | 200        | {"id":1,"name":"G1"}                   |
	| 100     | 404        | {"message":"Genre Id '100' not found"} |                                                                        

Scenario: Post a Genre
	Given I am a client
	When I make POST Request to '/api/genres' with the following Data '<requestData>'
	Then Response code must be '<statusCode>'
	And Response data must look like '<responseData>'
	Examples: 
	| requestData   | statusCode | responseData |
	| {"name":"G1"} | 201        | 1            |

Scenario: Put a Genre
	Given I am a client
	When I make PUT Request '/api/genres/<genreId>' with the following Data '<requestData>'
	Then Response code must be '<statusCode>'
	And Response data must look like '<responseData>'
	Examples: 
	| genreId | requestData   | statusCode | responseData                           |
	| 1       | {"name":"G1"} | 200        | Updated Successfully                   |
	| 100     | {"name":"G2"} | 404        | {"message":"Genre Id '100' not found"} |           

Scenario: Delete a Genre
	Given I am a client
	When I make DELETE Request '/api/genres/<genreId>'
	Then Response code must be '<statusCode>'
	And Response data must look like '<responseData>'
	Examples: 
	| genreId | statusCode | responseData                           |
	| 1       | 200        | Deleted Successfully                   |
	| 100     | 404        | {"message":"Genre Id '100' not found"} |
