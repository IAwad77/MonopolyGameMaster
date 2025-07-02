
Feature: CSV upload UI
  Scenario: User uploads a valid player CSV
    Given the upload page is open
    When I choose "players.csv" and click Upload
    Then I should see "Alice" in the parsed list
