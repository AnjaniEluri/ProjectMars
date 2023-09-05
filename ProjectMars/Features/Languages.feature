Feature: Languages in MARS QA Application

Scenario: User can see language level and add new buttons in the language tab
Given the user is logged in 
And they are on the user profile page
When they navigate to the language tab
Then they should see the language level displayed
And they should see the "Add New" button
When they click the "Add New" button
Then a new language entry form should appear
And they should be able to enter language details
When they save the new language entry
Then the language level should be updated
And the new language should be added to the list

Scenario: Verify the UI elements in Languages section
Given I am on the Mars home page
	And I open the Language section
When I click on Add New button 
	And I type the language name as English and select language level as Basic
	And I click add button
Then The language English gets added to my profile



Scenario Outline: User adds 4 languages to the profile
 Given User is logged into MarsQA application
 When User adds new language including '<LanguageName>','<LanguageLevel>'
 Then Newly added language is displaying including '<LanguageName>','<LanguageLevel>'
 Examples: 
 | LanguageName | LanguageLevel    |
 | English      | Basic            |
 | Sanskrit     | Conversational   |
 | Hindi        | Fluent           |
 | Telugu       | Native/Bilingual |

 Scenario: User can't add more than four languages 
  Given User is logged into MarsQA application
  And User deletes all existing languages
  When User adds four new languages
  Then User is not able to add any more languages because Add New button is not visible

  Scenario: User edits newly added language 
  Given User is logged into MarsQA application
  When User edits newly added language
  Then Language is edited successfully

  Scenario: User deletes newly added language
  Given User is logged into MarsQA application
  When User deletes all existing languages
  Then All Languages are deleted successfully

  Scenario: User cancels while adding a language
  Given User is logged into MarsQA application
  And User deletes all existing languages
  When User enters the values for language name and language level
  And Clicks on cancel button
  Then The changes made by user are not saved and the language is not added

  Scenario: User can't add duplicate language
  Given User is logged into MarsQA application
  And User deletes all existing languages 
  When User tries to add same language twice
  Then Error is displayed and user is not able to add duplicate language

  Scenarios: User 




#Scenario: Add two numbers
#	Given the first number is 50
#	And the second number is 70
#	When the two numbers are added
#	Then the result should be 120