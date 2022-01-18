 Feature: Actor Resource

Scenario: Get Actor All
	Given I am a client
	When I make GET Request '/api/actors'
	Then Response code must be '200'
	And Response data must look like '[{"id":1,"name":"A1","bio":"xyz","dob":"2000-03-07T00:00:00","gender":"Male"},{"id":2,"name":"A2","bio":"xyz","dob":"2001-03-07T00:00:00","gender":"Male"}]'

Scenario: Get Actor By Id
	Given I am a client
	When I make GET Request '/api/actors/<actorId>'
	Then Response code must be '<statusCode>'
	And Response data must look like '<responseData>'
	Examples: 
	| actorId | statusCode | responseData                                                                 |
	| 1       | 200        | {"id":1,"name":"A1","bio":"xyz","dob":"2000-03-07T00:00:00","gender":"Male"} |
	| 100     | 404        | {"message":"Actor Id '100' not found"}                                       |                                                                        

Scenario: Post a Actor
	Given I am a client
	When I make POST Request to '/api/actors' with the following Data '<requestData>'
	Then Response code must be '<statusCode>'
	And Response data must look like '<responseData>'
	Examples: 
	| requestData                                                           | statusCode | responseData |
	| {"name":"A1","bio":"xyz","dob":"2000-03-07T00:00:00","gender":"Male"} | 201        | 1            |

Scenario: Put a Actor
	Given I am a client
	When I make PUT Request '/api/actors/<actorId>' with the following Data '<requestData>'
	Then Response code must be '<statusCode>'
	And Response data must look like '<responseData>'
	Examples: 
	| actorId | requestData                                                           | statusCode | responseData                           |
	| 1       | {"name":"A1","bio":"xyz","dob":"2000-03-07T00:00:00","gender":"Male"} | 200        | Updated Successfully                   |
	| 100     | {"name":"A2","bio":"xyz","dob":"2000-03-07T00:00:00","gender":"Male"} | 404        | {"message":"Actor Id '100' not found"} |         

Scenario: Delete a Actor
	Given I am a client
	When I make DELETE Request '/api/actors/<actorId>'
	Then Response code must be '<statusCode>'
	And Response data must look like '<responseData>'
	Examples: 
	| actorId | statusCode | responseData                           |
	| 1       | 200        | Deleted Successfully                   |
	| 100     | 404        | {"message":"Actor Id '100' not found"} |
