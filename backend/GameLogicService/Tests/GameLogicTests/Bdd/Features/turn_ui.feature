Feature: Turn rotation UI
  Scenario: Player ends turn via UI
    Given the React game page is open
    When I click "End Turn"
    Then the displayed current player should change
