Feature: Single user validation

@Smoke
Scenario: verifying getting single user
	Given All the Headers and Authorization are given
    When Api Uri with endpoints  hit the server
	Then verify the response status code 200
	And verify the response

	