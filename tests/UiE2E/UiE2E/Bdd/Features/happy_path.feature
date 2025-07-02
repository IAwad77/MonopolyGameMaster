Feature: Full happy path
  Scenario: User logs in and uploads CSV
       Given the login page is open
       When I log in with default creds
       And I upload a sample CSV
       Then I should see the player "Alice" in the list