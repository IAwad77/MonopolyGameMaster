Feature: Login page
  Scenario: User logs in successfully
    Given the login page is open
    When I submit "admin" and "password"
    Then I should see "token"
