Feature: Languages in MARS QA Application


Scenario: Verify the UI elements in Languages section
Given I am on the Mars home page
	And I open the Language section
When I click on Add New button 
	And I type the language name as English and select language level as Basic
	And I click add button
Then The language English gets added to my profile



Scenario Outline: User adds 4 languages to the profile
 Given User is logged into MarsQA application
 When User adds new language name '<LanguageName>'
	And User selects the level '<LanguageLevel>'
 Then Newly added language is displaying as '<LanguageName>','<LanguageLevel>'
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

  Scenario: User edits an existing language entry
  Given User is logged into MarsQA application
  When User edits an existing language entry
  Then Language entry has been edited successfully

  Scenario: User deletes all existing languages
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






#Scenario: Add two numbers
#	Given the first number is 50
#	And the second number is 70
#	When the two numbers are added
#	Then the result should be 120