Feature: Player list updates on UI
  Scenario: Add a player and refresh UI
    Given the React app is open
    When I add a player named ""Charlie"" with balance 1500 via API
    Then the UI player list should show ""Charlie""
