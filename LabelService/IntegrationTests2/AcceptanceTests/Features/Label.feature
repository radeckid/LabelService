Feature: LabelSpecFlow
	In order generate a label

@LabelGenerator
Scenario: Check labelling flow

	Given I have provided sender address 
	| Company  | Name | Surname          | Street      | HomeNo | Zip    | City         |
	| Metapack | Szef | SzukaProgramisty | Kostrzynska | 6      | 65-127 | Zielona Gora |
	
	And I have provided sender country of 'United States'

	And I have provided sender mobile number of 'number' and sender email of 'address' 

	And I have provided receiver address
	| Company | Name  | Surname     | Street  | HomeNo | Zip    | City         | 
	|         | Kamil | Programista | Konicza | 12     | 65-127 | Zielona Gora | 

	And I have provided receiver country of 'United Kingdom'

	And I have provided receiver mobile number of 'number' and receiver email of 'address' 

	And I have provided Price of '5' with Currency 'PLN'

	And I have provided Delivery Instruction of 'test'

	When I send a consigment

	Then The result should be correct label

	Given I have provided label identcode of '000000000001'

	When I send get request to get label

	Then The result should be correct existing label

	Given I have provided label identcode of '000000000001' to delete

	When I send post request to delete label

	When I send get request to get deletion label with identcode provided to deletion

	Then The result should be Not Found status