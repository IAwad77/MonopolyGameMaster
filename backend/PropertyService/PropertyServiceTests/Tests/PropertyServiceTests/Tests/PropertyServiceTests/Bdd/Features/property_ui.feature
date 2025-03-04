Feature: Property list UI
  Scenario: Add property and view in UI
    Given the React app is on property page
    When I add property "Boardwalk" priced 400
    Then the UI properties list should include "Boardwalk"
