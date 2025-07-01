Feature: Bank transactions via UI
  Scenario: Deposit money and see it in history
    Given the React app is on bank page
    When I submit a deposit of 200
    Then the transaction list should show "deposit" of 200
