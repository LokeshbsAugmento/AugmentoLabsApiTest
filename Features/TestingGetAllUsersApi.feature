 Feature: TestingGetAllUsersApi
 
@Smoke
Scenario: Checking whether user is able to fetch all users data
	Given verify user is authorized to get all users data
	When user clicks the link or button to get all users data
	Then make sure user is able to get all users data