Feature: Login
User logs in with valid credentials (username, password)
Homepage will load after successful login

Background: 
	Given User will be on the login page

@positive
Scenario Outline: Login with valid credentials
	When User will enter username'<Username>'
	And User will enter password'<Password>'
	And User will click on login button
	Then User will be redirected to homepage
Examples:
	| Username    | Password |
	| abc@xyz.com | 12345    |
	| def@xyz.com | 98765    |


@negative
Scenario Outline: Login with invalid credentials
	When User will enter username'<Username>'
	And User will click on login button
	Then Error message for password length should be thrown
Examples:
	| Username    |
	| abc@xyz.com |
	| def@xyz.com |

@regression
Scenario Outline: Check for password hidden display
	When User will enter password'<Password>'
	And User will click on show link in the password input
	Then The password characters should be shown
Examples:
	| Password |
	| 12345    |

@regression
Scenario Outline: Check for password show display
	When User will enter password'<Password>'
	And User will click on show link in the password input
	And User will click on show hide in the password input
	Then The password characters should be hidden
Examples:
	| Password |
	| 12345    |