Feature: Producer Resource

Scenario: Get Producer All
	Given I am a client
	When I make GET Request '/api/producers'
	Then Response code must be '200'
	And Response data must look like '[{"id":1,"name":"A1","bio":"xyz","dob":"2000-03-07T00:00:00","gender":"Male"},{"id":2,"name":"A2","bio":"xyz","dob":"2001-03-07T00:00:00","gender":"Male"}]'

Scenario: Get Producer By Id
	Given I am a client
	When I make GET Request '/api/producers/<producerId>'
	Then Response code must be '<statusCode>'
	And Response data must look like '<responseData>'
	Examples: 
	| producerId | statusCode | responseData                                                                 |
	| 1          | 200        | {"id":1,"name":"A1","bio":"xyz","dob":"2000-03-07T00:00:00","gender":"Male"} |
	| 100        | 404        | {"message":"Producer Id '100' not found"}                                    |                                                                       

Scenario: Post a Producer
	Given I am a client
	When I make POST Request to '/api/producers' with the following Data '<requestData>'
	Then Response code must be '<statusCode>'
	And Response data must look like '<responseData>'
	Examples: 
	| requestData                                                           | statusCode | responseData |
	| {"name":"A1","bio":"xyz","dob":"2000-03-07T00:00:00","gender":"Male"} | 201        | 1            |

Scenario: Put a Producer
	Given I am a client
	When I make PUT Request '/api/producers/<producerId>' with the following Data '<requestData>'
	Then Response code must be '<statusCode>'
	And Response data must look like '<responseData>'
	Examples: 
	| producerId | requestData                                                           | statusCode | responseData                              |
	| 1          | {"name":"A1","bio":"xyz","dob":"2000-03-07T00:00:00","gender":"Male"} | 200        | Updated Successfully                      |
	| 100        | {"name":"A2","bio":"xyz","dob":"2000-03-07T00:00:00","gender":"Male"} | 404        | {"message":"Producer Id '100' not found"} |            

Scenario: Delete a Producer
	Given I am a client
	When I make DELETE Request '/api/producers/<producerId>'
	Then Response code must be '<statusCode>'
	And Response data must look like '<responseData>'
	Examples: 
	| producerId | statusCode | responseData                              |
	| 1          | 200        | Deleted Successfully                      |
	| 100        | 404        | {"message":"Producer Id '100' not found"} |
